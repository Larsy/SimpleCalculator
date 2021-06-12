using System;
using System.Linq;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        private static bool keeprunning = true;
        private static readonly SortedList<int, string> MenuItems = new SortedList<int, string>();

        static void Main()
        {
            MenuItems.Add(5, "Roten ur");
            MenuItems.Add(1, "Addera tal");
            MenuItems.Add(3, "Multiplicera tal");
            MenuItems.Add(2, "Subtrahera tal");
            MenuItems.Add(6, "Upphöjt till");
            MenuItems.Add(4, "Dela tal");

            PrintMenu();
            while (keeprunning == true)
            {
                DoMenuItems(Console.ReadLine().Trim());
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\t--== Meny ==--\n");
            foreach (KeyValuePair<int, string> kvp in MenuItems)
            {
                    Console.WriteLine("\t" + (kvp.Key + "  ")[0..3] + kvp.Value);
            }
            //Skriver ut menyval 0 utanför loopen för att jag alltid vill ha den nederst
            Console.WriteLine("\n\t0  Avsluta\n");
        }

        private static void DoMenuItems(string InputValue)
        {
            PrintMenu();
            switch (InputValue.Trim())
            {
                case "0": keeprunning = false; break;
                case "1": Addition(); break;
                case "2": Subtraction(); break;
                case "3": Multiplication(); break;
                case "4": Division(); break;
                case "5": SquareRoot(); break;
                case "6": RaiseToPower(); break;
                default: break;
            }

            //Om användaren väljer en av posterna i menyn, (förutom valet 0, som avslutar programmet utan denna uppmaning), så utförs den valda funktionen
            //och visar resultatet, följt av "Enter för att återgå till menyn.." för att indikera att programmet är redo att rensa skärmen och återgå till menyn.
            //Annars, om användaren matar in någonting annat än en giltig inmatning, inklusive att enbart trycka Enter, då ignoreras inmatningen och menyn ritas om.

            if (int.TryParse(InputValue, out int numericinput) == true)
            {
                if (MenuItems.ContainsKey(numericinput))
                {
                    Console.WriteLine("\nEnter för att återgå till menyn..");
                }
            }
        }

        private static void Addition()
        {
            Console.Write("Skriv valfritt antal tal du vill addera, separerade med + : ");
            string reply = Console.ReadLine().Trim();
            try
            {
                decimal[] nums = Array.ConvertAll(reply.Split('+'), decimal.Parse);
                Console.WriteLine("\tSumman av talen är: " + nums.Sum());
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return;
            }
        }

        private static void Subtraction()
        {
            Console.Write("Skriv valfritt antal tal du vill subtrahera, separerade med - : ");
            string reply = Console.ReadLine().Trim();
            try
            {
                decimal[] nums = Array.ConvertAll(reply.Split('-'), decimal.Parse);
                decimal result = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    result -= nums[i];
                }
                Console.WriteLine("\tResultatet av subtraktionen är: " + result);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return;
            }
        }

        private static void Multiplication()
        {
            Console.Write("Skriv valfritt antal tal du vill multiplicera, separerade med * : ");
            string reply = Console.ReadLine().Trim();
            try
            {
                decimal[] nums = Array.ConvertAll(reply.Split('*'), decimal.Parse);
                decimal result = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    result *= nums[i];
                }
                Console.WriteLine("\tProdukten av talen är: " + result);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return;
            }
        }
        private static void Division()
        {
            Console.Write("Skriv valfritt antal tal i divisionen, separerade med / : ");
            string reply = Console.ReadLine().Trim();
            try
            {
                decimal[] nums = Array.ConvertAll(reply.Split('/'), decimal.Parse);
                decimal result = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    result /= nums[i];
                }
                Console.WriteLine("\tResultatet av divisionen är: " + result);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return;
            }
        }

        private static void SquareRoot()
        {
            Console.Write("Ange tal ");
            string inputString = Console.ReadLine().Trim();
            if (double.TryParse(inputString, out double value) == true)
            {
                Console.WriteLine($"\tRoten ur {value} är {Math.Sqrt(value)}");
            }
            else
            {
                Console.WriteLine("Ogiltigt värde!");
            }
        }

        private static void RaiseToPower()
        {
            Console.Write("Ange tal: ");
            string inputString = Console.ReadLine().Trim();
            if (double.TryParse(inputString, out double basenumber) == true)
            {
                Console.Write("Upphöjt till: ");
                inputString = Console.ReadLine();
                if (double.TryParse(inputString, out double raiseto) == true)
                {
                    Console.WriteLine($"\t{basenumber} upphöjt till {raiseto} är {Math.Pow(basenumber, raiseto)}");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt värde!");
            }
        }
    }
}
