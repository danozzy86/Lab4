using System;
using System.IO;
/* 
   Lab 4 - String Operations on a File - Programming 1
   Daniel Osborne Github - danozzy86
   Due 10/1 @ 4PM
*/
namespace Lab4
{
    class Program
    {
        public static bool exit = false;
        static void Main(string[] args)
        {
            while (!exit)
            {
                MainMenu();

                string choiceString = Console.ReadLine();
                int intChoice;
                string txtFile;

                //Verifies the user input to make sure that they are inputing a number integer option.3
                while (!int.TryParse(choiceString, out intChoice))
                {
                    Console.Clear();
                    MainMenu();
                    Console.WriteLine("Please enter a valid number.");
                    choiceString = Console.ReadLine();
                }

                switch (intChoice)
                {
                    case 1:
                        //Retrieves the text file input from the ReadFile method and puts it in the txtFile string.
                        txtFile = ReadFile();

                        if (txtFile != null)
                        {
                            Console.Clear();
                            Console.WriteLine(txtFile);
                            Console.WriteLine("The text file has {0} words.", StringOperators.WordCount(txtFile));
                            Console.WriteLine("The text file has {0} vowels", StringOperators.CharCount(txtFile, true));
                            Console.WriteLine("The text file has {0} letters", StringOperators.CharCount(txtFile, false));
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        //Creates an empty text file in user designated path and validates the path
                        CreateFile();
                        break;
                    case 3:
                        //Exits the program
                        Console.Clear();
                        exit = true;
                        break;
                    default:
                        //By default, will return to the beginingof the loop, most likely due to incorrect option being selected.
                        Console.Clear();
                        Console.WriteLine("Please enter a valid choice of 1, 2, or 3.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static string ReadFile()
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("            Read a Text File             ");
            Console.WriteLine("=========================================");
            Console.WriteLine("- Enter the File Path to the Text File - ");

            string path = Console.ReadLine();
            string input;

            try
            {
                input = File.ReadAllText(path);
            }
            catch
            {
                Console.WriteLine("The file could not be read or does not exist.");
                Console.ReadKey();
                return null;
            }
            return input;
        }
        public static void CreateFile()
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("           Create a Text File            ");
            Console.WriteLine("=========================================");
            Console.WriteLine("- Enter where you want the file to be located w/ name -");
            Console.WriteLine(@"- Example: c:\users\user\desktop\example.txt");

            string path = Convert.ToString(Console.ReadLine());

            if (!File.Exists(path))
            {
                try {
                    File.CreateText(path);
                } catch {
                    Console.WriteLine("The chosen file path is invalid.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("The file has been created!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Either the file already exists.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine(" Reading a Text File and Displaying Info ");
            Console.WriteLine("=========================================");
            Console.WriteLine("- Select an Option -");
            Console.WriteLine(" 1) Read a Text File");
            Console.WriteLine(" 2) Create a Text File");
            Console.WriteLine(" 3) Exit Program");
        }
    }
}
