using System;
using System.IO;
using System.Collections.Generic;
using AtalayKarahanCodeGenerator;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Reflection;
using static System.Console;

namespace AtalayKarahan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.MainMenu();
        }

        public void MainMenu()
        {
            Title = "ATALAY KARAHAN";
            string prompt = @"

 █████╗ ████████╗ █████╗ ██╗      █████╗ ██╗   ██╗    ██╗  ██╗ █████╗ ██████╗  █████╗ ██╗  ██╗ █████╗ ███╗   ██╗                       
██╔══██╗╚══██╔══╝██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝    ██║ ██╔╝██╔══██╗██╔══██╗██╔══██╗██║  ██║██╔══██╗████╗  ██║                       
███████║   ██║   ███████║██║     ███████║ ╚████╔╝     █████╔╝ ███████║██████╔╝███████║███████║███████║██╔██╗ ██║                       
██╔══██║   ██║   ██╔══██║██║     ██╔══██║  ╚██╔╝      ██╔═██╗ ██╔══██║██╔══██╗██╔══██║██╔══██║██╔══██║██║╚██╗██║                       
██║  ██║   ██║   ██║  ██║███████╗██║  ██║   ██║       ██║  ██╗██║  ██║██║  ██║██║  ██║██║  ██║██║  ██║██║ ╚████║                       
╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝   ╚═╝       ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝                       
                                                                                                                                       
 ██████╗ ██╗ ██╗      ██████╗ ██████╗ ██████╗ ███████╗    
██╔════╝████████╗    ██╔════╝██╔═══██╗██╔══██╗██╔════╝    
██║     ╚██╔═██╔╝    ██║     ██║   ██║██║  ██║█████╗      
██║     ████████╗    ██║     ██║   ██║██║  ██║██╔══╝      
╚██████╗╚██╔═██╔╝    ╚██████╗╚██████╔╝██████╔╝███████╗    
 ╚═════╝ ╚═╝ ╚═╝      ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝    

 ██████╗ ███████╗███╗   ██╗███████╗██████╗  █████╗ ████████╗ ██████╗ ██████╗ 
██╔════╝ ██╔════╝████╗  ██║██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗
██║  ███╗█████╗  ██╔██╗ ██║█████╗  ██████╔╝███████║   ██║   ██║   ██║██████╔╝
██║   ██║██╔══╝  ██║╚██╗██║██╔══╝  ██╔══██╗██╔══██║   ██║   ██║   ██║██╔══██╗
╚██████╔╝███████╗██║ ╚████║███████╗██║  ██║██║  ██║   ██║   ╚██████╔╝██║  ██║
 ╚═════╝ ╚══════╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
                                                                                                                                       
Welcome To the Atalay Karahan's C# Code Generator. What would you like to do?
(Use the arrow keys to cycle through options and press enter to select an option.)";
            string[] options = { "Read And Write(It reads the names of the files in the folder and produces new files in the template you choose for each name.)",
                                 "Read and Repeat(It reads the names of the files in the folder and creates a certain code you choose with the names of each file.)",
                                 "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    ReadandWriteRun();
                    break;
                case 1:
                    ReadandRepeatRun();
                    break;
                case 2:
                    Exit();
                    break;
                default:
                    break;
            }

        }

        private void ReadandWriteRun()
        {
            ReadandWrite myReadandWrite = new ReadandWrite();
            myReadandWrite.Start();
        }
        private void ReadandRepeatRun()
        {
            ReadandRepeat myReadandRepeat = new ReadandRepeat();
            myReadandRepeat.Start();
        }
        private void Exit()
        {
            Environment.Exit(0);
        }

    }

    
}


