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
            process.StartInfo.Arguments = "/server:localhost"; // Substitua "localhost" pelo nome ou endereço do servidor RDP
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            int numberOfSessions = CountRdpSessions(output);

            string statusMessage;
            string nagiosOutput;

            if (numberOfSessions == 1)
            {
                statusMessage = "WARN! Número de sessões RDP: " + numberOfSessions;
                nagiosOutput = "1";
            }
            else if (numberOfSessions > 1)
            {
                statusMessage = "OK! Número de sessões RDP: " + numberOfSessions;
                nagiosOutput = numberOfSessions.ToString();
            }
            else
            {
                statusMessage = "Critical! Número de sessões RDP: " + numberOfSessions;
                nagiosOutput = "2";
            }

            Console.WriteLine(statusMessage + " |sessoes=" + nagiosOutput);
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

