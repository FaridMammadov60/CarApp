using System;


namespace Utilities.Helper
{
    public static class Extention
    {
        
        /// <summary>
        /// Methodu çağıranda Consola reng və message verir
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
        /// Consola qeyd edilmiş menu çıxarır
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
                $"12-Create Avto Salon\n" +
                $"13-Update Avto Salon\n" +
                $"14-Remove Avto Salon\n" +
                $"15-Get Avto Salon\n" +
                $"16-GetAll Avto Salon\n" +
                $"17-Model Added Avto Salon\n" +
                $"0-Quit");
        }
        /// <summary>
        /// Menu enum-ı reqemlerin enum ile formasi
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
            ModelAddBrand = 11,
            CreateAvtoSalon = 12,
            UpdateAvtoSalon = 13,
            RemoveAvtoSalon = 14,
            GetAvtoSalon = 15,
            GetAllAvtoSalon = 16,
            ModelAddedAvtoSalon = 17
        }
        #region EmptyNullInt
        /// <summary>
        /// Daxil edilmiş int type-ın boş ve integer olmasın yoxlayıb doğru neticə yazılana kimi 
        /// consoldan rəqəm istəyir
        /// </summary>
        /// <returns></returns>
        public static int TryParseMethod()
        {
        T1: string num = Console.ReadLine();
            int input;
            bool isNum = int.TryParse(num, out input);
            if (input < 0)
            {
                Extention.Print(ConsoleColor.Red, "Enter the correctly");
                goto T1;
            }
            else if (isNum)
            {                
                return input;
            }
            else
            {
                Extention.Print(ConsoleColor.Red, "Enter the correctly");
                goto T1;
            }

        }
        /// <summary>
        /// Daxil edilmiş string type-ın boş və null olmasın yoxlayır ve
        /// doğru neticə yazılana kimi təkrar edir
        /// </summary>
        /// <returns></returns>
        public static string TryEmptyMethod()
        {
        T1: string word = Console.ReadLine();

            if (String.IsNullOrEmpty(word))
            {
                Extention.Print(ConsoleColor.Red, "Enter the correctly");
                goto T1;
            }
            word = word.ToUpper();
            return word;
        }
        public static bool CheckId()
        {

            //baxilmali
            return true;
        }

        #endregion

    }
}
