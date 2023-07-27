using AtalayKarahan;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace AtalayKarahanCodeGenerator
{
    public class ReadandWrite
    {
        string templatePath = string.Empty;
        String? exportPath;
        List<string>? replaceWords;
        List<string> cutExampleList;
        int startPosition;
        int endPosition;
        string? durumYazisi;
        string? finalYazisi;
        string option = "n";
        string? oldText;
        string? unchangedFiles;
        string[]? fileNames;


        public void Start()
        {
            Title = "Atalay Karahan's Read and Write";
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
                                                                                                                
██████╗ ███████╗ █████╗ ██████╗      █████╗ ███╗   ██╗██████╗     ██╗    ██╗██████╗ ██╗████████╗███████╗        
██╔══██╗██╔════╝██╔══██╗██╔══██╗    ██╔══██╗████╗  ██║██╔══██╗    ██║    ██║██╔══██╗██║╚══██╔══╝██╔════╝        
██████╔╝█████╗  ███████║██║  ██║    ███████║██╔██╗ ██║██║  ██║    ██║ █╗ ██║██████╔╝██║   ██║   █████╗          
██╔══██╗██╔══╝  ██╔══██║██║  ██║    ██╔══██║██║╚██╗██║██║  ██║    ██║███╗██║██╔══██╗██║   ██║   ██╔══╝          
██║  ██║███████╗██║  ██║██████╔╝    ██║  ██║██║ ╚████║██████╔╝    ╚███╔███╔╝██║  ██║██║   ██║   ███████╗        
╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═════╝     ╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝      ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝   ╚═╝   ╚══════╝        
--------------------------------------------------------------------------------------------------------
1) Open Template Folder and write your template text.
2) Select the Export file location.
3) Select 'Next' Option to continue processing.
(Use the arrow keys to cycle through options and press enter to select an option.)
----------------------------------------------------------------------------------";
            string[] options = { "Select The Template Folder", "Select The Export Folder", "Next", "Go Back" };
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
            //Kullanıcıdan dosyanın yolunu yapıştırmasını ister ve eğer hatalı yapıştırırsa tekrar ettirir.
            ConsoleKey keyPressed;
            do
            {
                do
                {
                    Clear();
                    Console.WriteLine("Lütfen notepad.txt türünde bir template dosyası oluşturun ve dosya yolunu girip enter tuşuna basın.\r\nÖrnek -> 'C:\\Users\\admin\\Desktop\\ExampleFolder\\templateFile.txt'");
                    templatePath = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(templatePath));

                Clear();
                Console.WriteLine("template dosyasının yolu aşağıdaki gibidir doğru girdiğinize emin misiniz? y/n\r\n" + templatePath);

                while (true)
                {
                    keyPressed = ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.Y || keyPressed == ConsoleKey.N)
                        break;
                }

            } while (keyPressed != ConsoleKey.Y);
            RunMainMenu();
        }

        private void ExportFolder()
        {
            Clear();

            ConsoleKey keyPressed;
            do
            {
                do
                {
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


                } while (string.IsNullOrWhiteSpace(exportPath));

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
                Console.WriteLine(comment + "\r\n" + exportPath);

                while (true)
                {
                    keyPressed = ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.Y || keyPressed == ConsoleKey.N)
                        break;
                }

                Clear();

            } while (keyPressed != ConsoleKey.Y);

            exportPath = exportPath + "\\";
            Start();

        }

        private void Next()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                //Değişmesini gereken kelimeyi seçtirdiğimiz yer
                do
                {
                    Console.WriteLine("Type the word you want changed");
                    oldText = Console.ReadLine();
                } while (string.IsNullOrEmpty(oldText));
                Clear();
                Console.WriteLine("Kelimeyi doğru yazdığınızı düşünüyorsanız tuşlara basın. y/n\r\n" + "Kelime ->" + oldText);
                while (true)
                {
                    keyPressed = ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.Y || keyPressed == ConsoleKey.N)
                        break;
                }

            } while (keyPressed != ConsoleKey.Y);

            do
            {
                Clear();
                do
                {
                    Console.WriteLine("paste the path of the folder with the names");
                    //İçinde isimlerin bulunduğu klasörün yolunu sorduğumuz nokta.
                    unchangedFiles = Console.ReadLine();

                } while (string.IsNullOrEmpty(unchangedFiles));
                Clear();
                Console.WriteLine("Dosya yolunu doğru yazdığınızı düşünüyorsanız tuşlara basın. y/n\r\n" + "dosya yolu ->" + unchangedFiles);
                while (true)
                {
                    keyPressed = ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.Y || keyPressed == ConsoleKey.N)
                        break;
                }
            } while (keyPressed != ConsoleKey.Y);

            fileNames = Directory.GetFiles(unchangedFiles);
            //Burda aldığımız isimler uzantı içindeki dosyalar ile isim listesi oluşturduk.
            replaceWords = new List<string>(fileNames);

            //isimleri baştan ve sondan kesmek için pozisyon belirleme fonksiyonu
            pozisyonBelirle();

            changeName();

            foreach (string word in replaceWords)
            {
                var olmasiGereken = word.Substring(startPosition, word.Length - startPosition - endPosition);
                //her defasında yeni isim yarattığı ve bu sayede yeni dosya oluşturduğu kısım
                string secondExportPath = exportPath + olmasiGereken + ".cs";
                string templateContent = File.ReadAllText(templatePath);

                templateContent = templateContent.Replace(oldText, olmasiGereken);

                using (FileStream fs = new FileStream(secondExportPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] contentBytes = System.Text.Encoding.UTF8.GetBytes(templateContent);
                    fs.Write(contentBytes, 0, contentBytes.Length);
                    fs.Close();
                }
            }

            Console.WriteLine("Dosyalarınız başarıyla oluştu!");
            Console.WriteLine("Dosyanızı şu yolda bulabilirsiniz.\r\n" + exportPath);
            Console.ReadKey();
            Start();

        }

        private void pozisyonBelirle()
        {
            ConsoleKey keyPressed;
            if (replaceWords != null && replaceWords.Count != 0)
            {
                do
                {
                    Clear();
                    do
                    {
                        Console.WriteLine("You have to enter number in the starting position.");

                        // replaceWords.Count ve 5 arasında minimum değeri alıyoruz.
                        int loopCount = Math.Min(replaceWords.Count, 5);
                        for (int i = 0; i < loopCount; i++)
                        {
                            Console.WriteLine(replaceWords[i]);
                        }
                        //Kullanıcıdan ismin ilk kesilicek halini aldığımız yer
                        startPosition = Convert.ToInt32(Console.ReadLine());
                    } while (string.IsNullOrEmpty(startPosition.ToString()));


                    Clear();
                    WriteLine("You have to cut " + startPosition + " letters from the beginning position it's looks like this after the letters are cut off If you're sure, you can press 'y', else, you  can press 'n'");
                    foreach (string words in replaceWords)
                    {
                        WriteLine(words.Substring(startPosition, (words.Length - startPosition)));
                    }

                    while (true)
                    {
                        keyPressed = ReadKey(true).Key;
                        if (keyPressed == ConsoleKey.Y || keyPressed == ConsoleKey.N)
                            break;
                    }

                } while (keyPressed != ConsoleKey.Y);
            }
            else
            {
                //Burada sonradan bir kontrol ile kullanıcıyı geri göndermen gerekli!!!
                Clear();
                WriteLine("isimlerin bulunduğu liste boş geliyor dosya yolunu kontrol edin!");
                Console.ReadKey();
                RunMainMenu();
            }


            //Sondan kesme işlemi başlangıç yeri
            do
            {
                Clear();
                do
                {
                    Console.WriteLine("sondan kesmek için kesim adına bir sayı değeri giriniz örn(3).\r\n" + finalYazisi);
                    endPosition = Convert.ToInt32(Console.ReadLine());

                } while (string.IsNullOrEmpty(endPosition.ToString()));

                //Pozisyon değeri girdikten sonra döngüden çıkıcak ve bu kısma gelicek.
                Clear();
                WriteLine("You have to cut " + endPosition + " letters from the ending position it's looks like this after the letters are cut off If you're sure, you can press 'y', else, you  can press 'n'");

                foreach (string word in replaceWords)
                {

                    WriteLine(word.Substring(startPosition, word.Length - startPosition - endPosition));

                }

                while (true)
                {
                    keyPressed = ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.Y || keyPressed == ConsoleKey.N)
                        break;
                }

            } while (keyPressed != ConsoleKey.Y);
        }

        private void changeName()
        {
            Clear();
            ConsoleKey keyPressed;
            string optionText = @"Oluşturulacak yeni dosyalarınızda herhangi bir yerlerinde isim değişikliği yapmak ister misiniz? y/n";
            Console.WriteLine(optionText);

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            while (keyPressed != ConsoleKey.Y & keyPressed != ConsoleKey.N)
            {
                Clear();
                Console.WriteLine(optionText + "\r\nPlese use only y/n key!!");
                keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

            }

            if (keyPressed == ConsoleKey.Y)
            {
                Clear();
                optionText = ("Eğer isimlerin başlarına ifade eklemek istiyorsanız <-- sol yön tuşu, isimlerin sonlarına ifade eklemek istiyorsanız --> sağ yön tuşu isimlerin iki taraflarınada ifade eklemek istiyorsanız yukarı tuşuna basın");
                Console.WriteLine(optionText);

                keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                while (keyPressed != ConsoleKey.LeftArrow & keyPressed != ConsoleKey.RightArrow & keyPressed != ConsoleKey.UpArrow)
                {
                    Clear();
                    Console.WriteLine(optionText + "\r\nPlese use only y/n key!!");
                    keyInfo = ReadKey(true);
                    keyPressed = keyInfo.Key;

                }

                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    Clear();
                    Console.WriteLine("Sol yön tuşuna basıldı");
                    Console.ReadKey();

                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    Clear();
                    Console.WriteLine("sağ yön tuşuna basıldı");
                    Console.ReadKey();
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    Clear();
                    Console.WriteLine("yukarı yön tuşuna basıldı");
                    Console.ReadKey();
                }

            }


            //do
            //{
            //    Console.WriteLine(optionText);

            //    ConsoleKeyInfo keyInfo = ReadKey(true);

            //    keyPressed = keyInfo.Key;

            //    pressControl(keyPressed, keyInfo, optionText);

            //    //while (keyPressed != ConsoleKey.Y & keyPressed != ConsoleKey.N)
            //    //{
            //    //    Clear();
            //    //    Console.WriteLine(optionText + "\r\nPlese use only y/n key!!");
            //    //    keyInfo = ReadKey(true);
            //    //    keyPressed = keyInfo.Key;

            //    //}

            //    if (keyPressed == ConsoleKey.Y)
            //    {
            //        keyInfo = ReadKey(false);

            //        Clear();
            //        Console.WriteLine(@"Eğer isimlerin başlarına ifade eklemek istiyorsanız <-- sol yön tuşu, isimlerin sonlarına ifade eklemek istiyorsanız --> sağ yön tuşu
            //        isimlerin iki taraflarınada ifade eklemek istiyorsanız yukarı tuşuna basın");
            //        keyInfo = ReadKey(true);
            //        keyPressed = keyInfo.Key;
            //        if (keyPressed == ConsoleKey.LeftArrow)
            //        {
            //            keyInfo = ReadKey(false);
            //            Clear();
            //            Console.WriteLine("Sol yön tuşuna basıldı");
            //            Console.ReadKey();

            //        }
            //        else if (keyPressed == ConsoleKey.RightArrow)
            //        {
            //            keyInfo = ReadKey(false);
            //            Clear();
            //            Console.WriteLine("sağ yön tuşuna basıldı");
            //            Console.ReadKey();
            //        }
            //        else if (keyPressed == ConsoleKey.UpArrow)
            //        {
            //            keyInfo = ReadKey(false);
            //            Clear();
            //            Console.WriteLine("yukarı yön tuşuna basıldı");
            //            Console.ReadKey();
            //        }


            //    }


            //} while (keyPressed == ConsoleKey.Y);






        }

        private void pressControl(ConsoleKey tusVurusu, ConsoleKeyInfo keyInfo, string yazi)
        {
            while (tusVurusu != ConsoleKey.Y & tusVurusu != ConsoleKey.N)
            {
                Clear();
                if (yazi != null)
                {
                    Console.WriteLine(yazi + "\r\nPlese use only y/n key!!");
                }
                else
                {
                    Console.WriteLine("Plese use only y/n key!!");
                }

                keyInfo = ReadKey(true);
                tusVurusu = keyInfo.Key;

            }
        }

        private void GoBack()
        {
            Program myProgram = new Program();
            myProgram.MainMenu();
        }




    }
}
