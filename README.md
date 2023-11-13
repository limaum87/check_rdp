# RDP Session Checker

This is a simple utility developed in C# to check the number of active Remote Desktop (RDP) sessions on a server.

## How To Use

1. **Prerequisites:**
   - Make sure you have the .NET Core SDK installed on your machine. You can download it at https://dotnet.microsoft.com/download.

2. **Clone the Repository:**
   Clone this repository to your machine using the following command: https://github.com/limaum87/check_rdp.git
   
4. **Navigate to the Folder:**
 Use the terminal to navigate to the project folder:

5. **Run the Program:*
Compile the project with Visual Studio.

6. **Results:**
The program will display a message indicating the number of RDP sessions.
 - If there is 1 session, the message will be "WARN! Number of RDP sessions: 1".
 - If there is more than 1 session, the message will be "OK! Number of RDP sessions: [number]".
 - If there are no sessions, the message will be "Critical! Number of RDP sessions: 0".

## Personalização

- In the Program.cs file, you can modify the part that sets the variable process.StartInfo.Arguments to specify the name or address of the RDP server you want to check.

## Licença

This project is licensed under the MIT License. [MIT](LICENSE).
