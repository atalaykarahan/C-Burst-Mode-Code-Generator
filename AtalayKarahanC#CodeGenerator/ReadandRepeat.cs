using AtalayKarahan;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AtalayKarahanCodeGenerator
{
    public class ReadandRepeat
    {
        String? exportPath;
        string? templatePath;
        string? oldText;
        int startPosition;
        int endPosition;
        //string? newText;
        string? unchangedFiles;
        string[] fileNames;
        List<string> replaceWords;
        string finalYazisi;
        string durumYazisi;
        string option = "n";

        public void Start()
        {
            Title = "Atalay Karahan's Read and Repeat";
            RunMainMenu();
            WriteLine("Press any key to exit...");
            ReadKey(true);
        }

        private void RunMainMenu()
        {
            string prompt = @"
 █████╗ ████████╗ █████╗ ██╗      █████╗ ██╗   ██╗    ██╗  ██╗ █████╗ ██████╗  █████╗ ██╗  ██╗ █████╗ ███╗   ██╗   
██╔══██╗╚══██╔══╝██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝    ██║ ██╔╝██╔══██╗██╔══██╗██╔══██╗██║  ██║██╔══██╗████╗  ██║   
███████║   ██║   ███████║██║     ███████║ ╚████╔╝     █████╔╝ ███████║██████╔╝███████║███████║███████║██╔██╗ ██║   
██╔══██║   ██║   ██╔══██║██║     ██╔══██║  ╚██╔╝      ██╔═██╗ ██╔══██║██╔══██╗██╔══██║██╔══██║██╔══██║██║╚██╗██║   
██║  ██║   ██║   ██║  ██║███████╗██║  ██║   ██║       ██║  ██╗██║  ██║██║  ██║██║  ██║██║  ██║██║  ██║██║ ╚████║   
╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝   ╚═╝       ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   
                                                                                                                   
██████╗ ███████╗ █████╗ ██████╗      █████╗ ███╗   ██╗██████╗     ██████╗ ███████╗██████╗ ███████╗ █████╗ ████████╗
██╔══██╗██╔════╝██╔══██╗██╔══██╗    ██╔══██╗████╗  ██║██╔══██╗    ██╔══██╗██╔════╝██╔══██╗██╔════╝██╔══██╗╚══██╔══╝
██████╔╝█████╗  ███████║██║  ██║    ███████║██╔██╗ ██║██║  ██║    ██████╔╝█████╗  ██████╔╝█████╗  ███████║   ██║   
██╔══██╗██╔══╝  ██╔══██║██║  ██║    ██╔══██║██║╚██╗██║██║  ██║    ██╔══██╗██╔══╝  ██╔═══╝ ██╔══╝  ██╔══██║   ██║   
██║  ██║███████╗██║  ██║██████╔╝    ██║  ██║██║ ╚████║██████╔╝    ██║  ██║███████╗██║     ███████╗██║  ██║   ██║   
╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═════╝     ╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝     ╚═╝  ╚═╝╚══════╝╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝   
----------------------------------------------------------------------------------------------------------------

1)Open Template Folder and write your template text.
2)Select the Export file location.
3)Select 'Next' Option to continue processing.
(Use the arrow keys to cycle through options and press enter to select an option.)";
            string[] options = { "Open The Template Folder", "Select The Export Folder", "Next", "Go Back" };
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
            //Template olarak kullanılıcak dosyanın yolu
            templatePath = @"C:\Users\atala\Desktop\TestLabKrhn\Template\template.cs";

            //Dosyanın yolu bulunursa dosyayı açma işelmi
            if (File.Exists(templatePath))
            {
                Process.Start("notepad.exe", templatePath);
            }
            else
            {
                Console.WriteLine("Dosya Bulunamadı");
            }
            //Tüm işlemler bittikten sonra sayfa kapanmasın diye aynı sayfayı baştan çağırdığımız yer.
            RunMainMenu();
        }

        private void ExportFolder()
        {
            Clear();
       
            ConsoleKey keyPressed;
            do {
                Console.WriteLine(@"
         _________________
        |# :           : #|
        |  :           :  |
        |  :           :  |
        |  :           :  |
        |  :___________:  |
        |     _________   |
        |    | __      |  |
        |    ||  |     |  |
        \____||__|_____|__|
                                ");
                Console.WriteLine("Copy where you want to do execute file path then paste this screen after that press enter!");
                exportPath = Console.ReadLine();
                Clear();
                string comment = (@"
                      /|  /|  ---------------------------
                      ||__||  |                         |
                     /   O O\__    Are you sure this    |
                    /          \ folder path? use y/n   |
                   /      \     \                       |
                  /   _    \     \ ----------------------
                 /    |\____\     \      ||
                /     | | | |\____/      ||
               /       \| | | |/ |     __||
              /  /  \   -------  |_____| ||
             /   |   |           |       --|
             |   |   |           |_____  --|
             |  |_|_|_|          |     \----
             /\                  |
            / /\        |        /
           / /  |       |       |
       ___/ /   |       |       |
      |____/    c_c_c_C/ \C_c_c_c
                                                   ");
                Console.WriteLine(comment+"\r\n"+exportPath);


                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                while(keyPressed != ConsoleKey.Y & keyPressed != ConsoleKey.N)
                {
                    Clear();
                    Console.WriteLine(comment + "\r\nPlese use only y/n key!!");
                    keyInfo = ReadKey(true);
                    keyPressed = keyInfo.Key;
                } 
               
                Clear();

            } while (keyPressed != ConsoleKey.Y);
           
            exportPath = exportPath + @"\ReadandRepeat.cs";
            Start();

        }
        private void Next()
        {
            Clear();
            Console.WriteLine("Type the word you want changed");
            //Değişmesini gereken kelimeyi seçtirdiğimiz yer
            oldText = Console.ReadLine();

            Clear();
            Console.WriteLine("paste the path of the folder with the names");
            //İçinde isimlerin bulunduğu klasörün yolunu sorduğumuz nokta.
            unchangedFiles = Console.ReadLine();

            fileNames = Directory.GetFiles(unchangedFiles);
            //Burda aldığımız isimler uzantı içindeki dosyalar ile isim listesi oluşturduk.
            replaceWords = new List<string>(fileNames);

            //İsimleri doğru düzgün almak için isim kontrolü;
            pozisyonBelirle();

            //okuyacayı dosya yolu
            StringBuilder sb = new StringBuilder();

            //Döngü başlangıcı
            foreach (string word in replaceWords)
            {
                //Template üzerindeki değişiklik olacağından template yolunu sürekli yeniden okutuyoruz
                string templateContent = File.ReadAllText(templatePath);
                var olmasiGereken = word.Substring(startPosition, word.Length - startPosition - endPosition);
                templateContent = templateContent.Replace(oldText, olmasiGereken);

                // Her değiştirdiğinde metin string builder'a ekle
                sb.AppendLine(templateContent);

            }
            //exportPath = @"C:\Users\OsoftLenovoOld\Desktop\TestLabKrhn\Output\ReadandRepeat.cs";
            File.WriteAllText(exportPath, sb.ToString());
            Console.WriteLine("Dosya başarıyla oluştu!");
            Console.WriteLine("Dosyanızı şu yolda bulabilirsiniz.\r\n" + exportPath);
            Console.ReadKey();
            Start();
        }
        private void GoBack()
        {
            Program myProgram = new Program();
            myProgram.MainMenu();
        }

        private void pozisyonBelirle()
        {
            Clear();
            Console.WriteLine("You have to enter number in the starting position.");
            string testText1 = replaceWords[0];
            string testText2 = replaceWords[1];
            string testText3 = replaceWords[2];
            Console.WriteLine(testText1 + "\r\n" + testText2 + "\r\n" + testText3);

            //Kullanıcıdan ismin ilk kesilicek halini aldığımız yer
            startPosition = Convert.ToInt32(Console.ReadLine());
            Clear();
            durumYazisi = "You have to cut " + startPosition + " letters from the beginning position it's looks like this after the letters are cut off If you're sure, you can press 'y', else, you  can press 'n'";
            finalYazisi = testText1.Substring(startPosition, (testText1.Length - startPosition)) + "\r\n" +
                                 testText2.Substring(startPosition, (testText2.Length - startPosition)) + "\r\n" +
                                 testText3.Substring(startPosition, (testText3.Length - startPosition));
            Console.WriteLine(durumYazisi + "\r\n" + finalYazisi);
            option = Console.ReadLine();
            //Baştan kesme işlemi başlangıç yeri
            while (option == "n" || option == "N")
            {
                Clear();
                Console.WriteLine("En son girdiğiniz sayı: " + startPosition + "\r\nBaşlangıç posizyonunu tekrar girin.");
                startPosition = Convert.ToInt32(Console.ReadLine());
                durumYazisi = "You have to cut " + startPosition + " letters from the beginning position it's looks like this after the letters are cut off If you're sure, you can press 'y', else, you  can press 'n'";
                finalYazisi = testText1.Substring(startPosition, (testText1.Length - startPosition)) + "\r\n" +
                                 testText2.Substring(startPosition, (testText2.Length - startPosition)) + "\r\n" +
                                 testText3.Substring(startPosition, (testText3.Length - startPosition));
                Console.WriteLine(durumYazisi + "\r\n" + finalYazisi);
                option = Console.ReadLine();

            }
            //Sondan kesme işlemi başlangıç yeri
            Clear();
            Console.WriteLine("You have to enter number in the ending position.\r\n" + finalYazisi);
            endPosition = Convert.ToInt32(Console.ReadLine());
            Clear();
            durumYazisi = "You have to cut " + endPosition + " letters from the ending position it's looks like this after the letters are cut off If you're sure, you can press 'y', else, you  can press 'n'";
            finalYazisi = testText1.Substring(startPosition, testText1.Length - startPosition - endPosition) + "\r\n" +
                                 testText2.Substring(startPosition, testText2.Length - startPosition - endPosition) + "\r\n" +
                                 testText3.Substring(startPosition, testText3.Length - startPosition - endPosition);
            Console.WriteLine(durumYazisi + "\r\n" + finalYazisi);
            option = Console.ReadLine();

            while (option == "n" || option == "N")
            {
                Clear();
                Console.WriteLine("En son girdiğiniz sayı: " + endPosition + "\r\nBitiş posizyonunu tekrar girin.");
                endPosition = Convert.ToInt32(Console.ReadLine());
                durumYazisi = "You have to cut " + endPosition + " letters from the ending position it's looks like this after the letters are cut off If you're sure, you can press 'y', else, you  can press 'n'";
                finalYazisi = testText1.Substring(startPosition, testText1.Length - startPosition - endPosition) + "\r\n" +
                              testText2.Substring(startPosition, testText2.Length - startPosition - endPosition) + "\r\n" +
                              testText3.Substring(startPosition, testText3.Length - startPosition - endPosition);
                Console.WriteLine(durumYazisi + "\r\n" + finalYazisi);
                option = Console.ReadLine();

            }



        }

    }
}
