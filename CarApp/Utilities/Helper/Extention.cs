using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper
{
    public static class Extention
    {
        /// <summary>
        /// Consola message verir
        /// </summary>
        /// <param name="color"></param>
        /// <param name="message"></param>
        public static void Print(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        /// <summary>
        /// Consola menu qaytarır
        /// </summary>
        public static void PrintMenu()
        {
            Print(ConsoleColor.Cyan, $"1-Create Brand\n" +
                $"2-Update Brand\n" +
                $"3-Remove Brand\n" +
                $"4-Get Brand\n" +
                $"5-GetAll Brand\n" +
                $"6-Add Model into Brand\n" +
                $"7-Update Model\n" +
                $"8-Remove Model\n" +
                $"9-GetAll Model\n" +
                $"10-Create Model\n" +
                $"11-Model Added Brand\n" +
                $"0-Quit");
        }
        /// <summary>
        /// Menu reqemlerin enum ile formas
        /// </summary>
        public enum Menu
        {
            Quit = 0,
            CreateBrand = 1,
            UpdateBrand = 2,
            RemoveBrand = 3,
            GetBrand = 4,
            GetAllBrand = 5,
            AddModelInBrand = 6,
            UpdateModel = 7,
            RemoveModel = 8,
            GetAllModel = 9,
            CreateModel = 10,
            ModelAddBrand = 11
        }
        /// <summary>
        /// Daxil edilmiş int type-ın boş ve integer olmasın yoxlayıb doğru neticeni yazmağa mecbur edir
        /// </summary>
        /// <returns></returns>
        public static int TryParseMethod()
        {
        T1: string num = Console.ReadLine();
            int input;
            bool isNum = int.TryParse(num, out input);
            if (isNum)
            {
                return input;
            }
            else
            {
                Extention.Print(ConsoleColor.Red, "Enter the ID correctly");
                goto T1;
            }

        }
        /// <summary>
        /// Daxil edilmiş string type-ın boş və null olmasın yoxlayır ve doldurmağa məcbur edir
        /// </summary>
        /// <returns></returns>
        public static string TryEmptyMethod()
        {
        T1: string num = Console.ReadLine();

            if (String.IsNullOrEmpty(num))
            {
                Extention.Print(ConsoleColor.Red, "Enter the correctly");
                goto T1;
            }
            return num;
        }
    }
}
