using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace check_rdp
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();
            process.StartInfo.FileName = "qwinsta";
            process.StartInfo.Arguments = "/server:localhost"; 
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            int numberOfSessions = CountRdpSessions(output);

            string statusMessage;
            int nagiosOutput;

            if (numberOfSessions == 1)
            {
                statusMessage = "WARN! Number of RDP sessions: " + numberOfSessions;
                nagiosOutput = 1;
            }
            else if (numberOfSessions > 1)
            {
                statusMessage = "OK! Number of RDP sessions: " + numberOfSessions ;
                nagiosOutput = 0;
            }
            else
            {
                statusMessage = "Critical! Number of RDP sessions: " + numberOfSessions;
                nagiosOutput = 2;
            }

            Console.WriteLine(statusMessage + " |sessoes=" + numberOfSessions);
            Environment.Exit(nagiosOutput);
        }

        static int CountRdpSessions(string output)
        {
            int count = -1;
            string[] lines = output.Split('\n');

            foreach (string line in lines)
            {
                if (Regex.IsMatch(line, @"^\s*rdp-", RegexOptions.IgnoreCase))
                {
                    count++;
                }
            }

            return count;
        }
    }
}

