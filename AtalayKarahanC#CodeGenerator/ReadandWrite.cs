using AtalayKarahan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AtalayKarahanCodeGenerator
{
    public class ReadandWrite
    {
        public void Start()
        {
            Title = "Test yazısı";
            RunMainMenu();
            WriteLine("Press any key to exit...");
            ReadKey(true);
        }

        private void RunMainMenu()
        {
            string prompt = @"
/***
 *     █████╗ ████████╗ █████╗ ██╗      █████╗ ██╗   ██╗    ██╗  ██╗ █████╗ ██████╗  █████╗ ██╗  ██╗ █████╗ ███╗   ██╗                       
 *    ██╔══██╗╚══██╔══╝██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝    ██║ ██╔╝██╔══██╗██╔══██╗██╔══██╗██║  ██║██╔══██╗████╗  ██║                       
 *    ███████║   ██║   ███████║██║     ███████║ ╚████╔╝     █████╔╝ ███████║██████╔╝███████║███████║███████║██╔██╗ ██║                       
 *    ██╔══██║   ██║   ██╔══██║██║     ██╔══██║  ╚██╔╝      ██╔═██╗ ██╔══██║██╔══██╗██╔══██║██╔══██║██╔══██║██║╚██╗██║                       
 *    ██║  ██║   ██║   ██║  ██║███████╗██║  ██║   ██║       ██║  ██╗██║  ██║██║  ██║██║  ██║██║  ██║██║  ██║██║ ╚████║                       
 *    ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝   ╚═╝       ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝                       
 *                                                                                                                                           
 *     ██████╗ ██╗ ██╗      ██████╗ ██████╗ ██████╗ ███████╗     ██████╗ ███████╗███╗   ██╗███████╗██████╗  █████╗ ████████╗ ██████╗ ██████╗ 
 *    ██╔════╝████████╗    ██╔════╝██╔═══██╗██╔══██╗██╔════╝    ██╔════╝ ██╔════╝████╗  ██║██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗
 *    ██║     ╚██╔═██╔╝    ██║     ██║   ██║██║  ██║█████╗      ██║  ███╗█████╗  ██╔██╗ ██║█████╗  ██████╔╝███████║   ██║   ██║   ██║██████╔╝
 *    ██║     ████████╗    ██║     ██║   ██║██║  ██║██╔══╝      ██║   ██║██╔══╝  ██║╚██╗██║██╔══╝  ██╔══██╗██╔══██║   ██║   ██║   ██║██╔══██╗
 *    ╚██████╗╚██╔═██╔╝    ╚██████╗╚██████╔╝██████╔╝███████╗    ╚██████╔╝███████╗██║ ╚████║███████╗██║  ██║██║  ██║   ██║   ╚██████╔╝██║  ██║
 *     ╚═════╝ ╚═╝ ╚═╝      ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝     ╚═════╝ ╚══════╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
 *                                                                                                                                           
 */

Welcome To the Atalay Karahan's C# Code Generator. What would you like to do?
(Use the arrow keys to cycle through options and press enter to select an option.)";
            string[] options = { "Change The Template Folder", "Change The Export Folder", "Next", "Go Back" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    TemplateFolder();
                    break;
                case 1:
                    ExportFolder();
                    break;
                case 2:
                    Next();
                    break;
                case 3:
                    GoBack();
                    break;
                default:
                    break;
            }

        }

        private void TemplateFolder()
        {

        }

        private void ExportFolder()
        {

        }
        private void Next()
        {

        }
        private void GoBack()
        {
            Program myProgram = new Program();
            myProgram.MainMenu();
        }


    }
}
