using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practos6
{
    public partial class Program
    {
        static string path;
        static public Daisy[] humans;
        static string name2;
        static string choice;
        static void Main(string[] args)
        {
            humans = Daisy.Human();
            // if (!File.Exists("DaisyTxt.txt")) WriteTxt();
            // if (!File.Exists("DaisyJson.json")) WriteJson();
            // if (!File.Exists("DaisyXml.xml")) WriteXml();
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Введите путь до файла вместе (с названием), который вы хотите открыть");
            Console.WriteLine("---------------------------------------------------------------------");
            CheckExt();

            switch (name2)
            {
                case "txt":
                    ReadWrite.ReadTxt(choice);
                    break;
                case "json":
                    ReadWrite.ReadJson(choice);
                    break;
                case "xml":
                    ReadWrite.ReadXml(choice);
                    break;
                default:
                    Console.WriteLine("Введен некоректный путь!!!");
                    break;
            }
            DisplayMenu();
        }
        static public void CheckExt()
        {
            choice = Console.ReadLine();
            int index = Array.IndexOf(choice.ToCharArray(), '.');
            name2 = null;

            for (int i = index + 1; i < choice.Length; i++)
            {
                name2 += choice[i].ToString();
            }
        }
        static public void Print()
        {
            Console.Clear();
            for (int i = 0; i < humans.Length; i++)
            {
                Console.WriteLine($"{humans[i].Client} - {humans[i].WeekDay}");
            }
            Console.WriteLine();
        }
        static void DisplayMenu()
        {
            Console.WriteLine("Для сохранения нажмите F3, для выхода Escape");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.F3)
            {
                Console.WriteLine("Введите путь для сохранения текста");
                Console.WriteLine("----------------------------------");
                CheckExt();

                switch (name2)
                {
                    case "txt":
                        ReadWrite.WriteTxt(choice);
                        break;
                    case "json":
                        ReadWrite.WriteJson(choice);
                        break;
                    case "xml":
                        ReadWrite.WriteXml(choice);
                        break;
                    default:
                        Console.WriteLine("Введен некоректный путь!!!");
                        break;
                }
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("");
            }
        }

    }
}

