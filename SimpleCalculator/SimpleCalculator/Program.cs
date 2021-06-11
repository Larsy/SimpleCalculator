using System;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static bool keeprunning = true;
        static readonly string[] MenuItems =
        {
                "Avsluta",
                "Addera tal",
                "Subtrahera tal",
                "Multiplicera tal",
                "Dela tal",
                "Roten ur",
                "Upphöjt till",
        };


        static void Main()
        {
            PrintMenu();
            while (keeprunning)
            {
                DoMenuItems(Console.ReadLine().Trim());
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t--== Meny ==--\n");
            for (int i = 1; i < MenuItems.Length; i++)
            {
                Console.WriteLine("\t" + (i + "  ")[0..3] + MenuItems[i]);
            }
            //skriver ut menyval 0 utanför loopen för att jag alltid vill ha den nederst
            Console.WriteLine("\n\t0  " + MenuItems[0] + "\n");
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

            //Om användaren väljer en av posterna i menyn, då utförs den funktionen och visar resultatet, följt av Press any key.. för att indikera att
            //programmet är redo att rensa skärmen och återgå till menyn. Annars, om användaren matar in något annat än giltig inmatning, inklusive att
            //enbart trycka Enter, då ritas menyn om, eller om användaren skriver 0, så avslutas programmet utan denna uppmaning..

            if(int.TryParse(InputValue, out int numericinput) == true)
            {
                if (numericinput < MenuItems.Length && numericinput != 0)
                {
                    Console.WriteLine("\nPress any key..");
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
            //decimal[] nums;
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
            //decimal[] nums;
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

        //Min egen funktion, namngiven efter den som Oracle har i PL/SQL och som gör första bokstaven i strängen till versal.
        //Mycket bra att ha till hands och vill därför gärna lägga in den i alla mina projekt, utifall att..
        private static string InitCap(string s)
        {
            return string.IsNullOrEmpty(s) ? string.Empty : char.ToUpper(s[0]) + s[1..];
        }
    }
}
