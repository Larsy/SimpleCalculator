using System;
using System.Linq;
using System.Collections.Generic;

namespace SimpleCalculator
{
    public class Program
    {
        private static decimal[] subtractionTestArray = { 3, -3, -2 };
        private static bool keeprunning = true;
        private static readonly IReadOnlyDictionary<string, string> MenuItems = new Dictionary<string, string>()
        {
            {"1", "Addera tal"},
            {"2", "Addera tal (tal1, tal2)"},
            {"3", "Subtrahera tal"},
            {"4", "Subtrahera tal (tal1, tal2)"},
            {"5", "Multiplicera tal"},
            {"6", "Dela tal"},
            {"7", "Roten ur"},
            {"8", "Upphöjt till"},
            {"9", "Omkrets av cirkel"},
            {"10", "Area av cirkel"},
            {"11", "Volym av klot"}
        };
        static void Main()
        {
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
            foreach (KeyValuePair<string, string> kvp in MenuItems)
            {
                Console.WriteLine("\t" + (kvp.Key + "  ")[0..3] + kvp.Value);
            }
            //Skriver ut menyval 0 utanför loopen för att jag alltid vill ha den nederst
            Console.WriteLine("\n\t0  Avsluta\n");
        }

        private static void DoMenuItems(string InputValue)
        {
            PrintMenu();
            switch (InputValue)
            {
                case "0": keeprunning = false; break;
                case "1": AdditionUI(false); break;
                case "2": AdditionUI(true); break;
                case "3": SubtractionUI(false); break;
                case "4": SubtractionUI(true); break;
                case "5": MultiplicationUI(); break;
                case "6": DivisionUI(); break;
                case "7": SquareRootUI(); break;
                case "8": RaiseToPowerUI(); break;
                case "9": CircleCircumferenceUI(); break;
                case "10": CircleAreaUI(); break;
                case "11": SphereVolumeUI(); break;
                case "12": Console.WriteLine(Subtraction(subtractionTestArray)); break;
                default: break;
            }

            //Om användaren väljer en av posterna i menyn, (förutom valet 0, som avslutar programmet utan denna uppmaning), så utförs den valda funktionen
            //och visar resultatet, följt av "Enter för att återgå till menyn.." för att indikera att programmet är redo att rensa skärmen och återgå till menyn.
            //Annars, om användaren matar in någonting annat än en giltig inmatning, inklusive att enbart trycka Enter, då ignoreras inmatningen och menyn ritas om.

            if (MenuItems.ContainsKey(InputValue))
            {
                Console.WriteLine("\nEnter för att återgå till menyn..");
            }
        }

        private static void AdditionUI(bool twoNums)
        {
            try
            {
                if (twoNums == true)
                {
                    Console.Write("Skriv första talet : ");
                    string reply = Console.ReadLine().Trim();
                    if (decimal.TryParse(reply, out decimal numA) == true)
                    {
                        Console.Write("Skriv andra talet : ");
                        reply = Console.ReadLine().Trim();
                        if (decimal.TryParse(reply, out decimal numB) == true)
                        {
                            Console.WriteLine($"\tSumman av talen är: {Addition(numA, numB)}");
                        }
                    }
                }
                else
                {
                    Console.Write("Skriv valfritt antal tal du vill addera, separerade med + : ");
                    string reply = Console.ReadLine().Trim();
                    decimal[] nums = Array.ConvertAll(reply.Split('+'), decimal.Parse);
                    Console.WriteLine($"\tSumman av talen är: {Addition(nums)}");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return;
            }
        }

        public static decimal Addition(decimal numA, decimal numB)
        {
            try
            {
                return numA + numB;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static decimal Addition(decimal[] nums)
        {
            try
            {
                return nums.Sum();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void SubtractionUI(bool twoNums)
        {
            try
            {
                if (twoNums == true)
                {
                    Console.Write("Skriv första talet : ");
                    string reply = Console.ReadLine().Trim();
                    if (decimal.TryParse(reply, out decimal numA) == true)
                    {
                        Console.Write("Skriv andra talet : ");
                        reply = Console.ReadLine().Trim();
                        if (decimal.TryParse(reply, out decimal numB) == true)
                        {
                            Console.WriteLine($"\tResultatet av subtraktionen är: {Subtraction(numA, numB)}");
                        }
                    }
                }
                else
                {
                    Console.Write("Skriv valfritt antal tal du vill subtrahera, separerade med - : ");
                    string reply = Console.ReadLine().Trim();
                    decimal[] nums = Array.ConvertAll(reply.Split('-'), decimal.Parse);
                    Console.WriteLine($"\tResultatet av subtraktionen är: {Subtraction(nums)}");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return;
            }
        }

        public static decimal Subtraction(decimal numA, decimal numB)
        {
            try
            {
                return numA - numB;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static decimal Subtraction(decimal[] nums)
        {
            try
            {
                decimal result = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    result -= (nums[i]);
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void MultiplicationUI()
        {
            Console.Write("Skriv valfritt antal tal du vill multiplicera, separerade med * : ");
            string reply = Console.ReadLine().Trim();
            try
            {
                decimal[] nums = Array.ConvertAll(reply.Split('*'), decimal.Parse);
                Console.WriteLine($"\tProdukten av talen är: {Multiplication(nums)}");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return;
            }
        }

        public static decimal Multiplication(decimal[] nums)
        {
            try
            {
                decimal result = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    result *= nums[i];
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void DivisionUI()
        {
            Console.Write("Skriv valfritt antal tal i divisionen, separerade med / : ");
            string reply = Console.ReadLine().Trim();
            try
            {
                decimal[] nums = Array.ConvertAll(reply.Split('/'), decimal.Parse);
                Console.WriteLine($"\tResultatet av divisionen är: {Division(nums)}");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return;
            }
        }

        public static decimal Division(decimal[] nums)
        {
            try
            {
                decimal result = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    result /= nums[i];
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void SquareRootUI()
        {
            Console.Write("Ange tal ");
            string inputString = Console.ReadLine().Trim();
            if (double.TryParse(inputString, out double value) == true)
            {
                Console.WriteLine($"\tRoten ur {value} är: {SquareRoot(value)}");
            }
            else
            {
                Console.WriteLine("Ogiltigt värde!");
            }
        }

        public static double SquareRoot(double value)
        {
            return Math.Sqrt(value);
        }

        private static void RaiseToPowerUI()
        {
            Console.Write("Ange tal: ");
            string inputString = Console.ReadLine().Trim();
            if (double.TryParse(inputString, out double basenumber) == true)
            {
                Console.Write("Upphöjt till: ");
                inputString = Console.ReadLine().Trim();
                if (double.TryParse(inputString, out double raiseto) == true)
                {
                    Console.WriteLine($"\tBasen {basenumber} upphöjd till {raiseto} är: {RaiseToPower(basenumber, raiseto)}");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt värde!");
            }
        }

        public static double RaiseToPower(double basenumber, double raiseto)
        {
            try
            {
                return Math.Pow(basenumber, raiseto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void CircleCircumferenceUI()
        {
            Console.Write("Ange cirkelns diameter i millimeter : ");
            string inputString = Console.ReadLine().Trim();
            if (double.TryParse(inputString, out double value) == true)
            {
                Console.WriteLine($"\tCirkeln med diameter {value} millimeter, har omkretsen: {CircleCircumference(value)} mm");
            }
            else
            {
                Console.WriteLine("Ogiltigt värde!");
            }
        }

        public static double CircleCircumference(double value)
        {
            return value * Math.PI;
        }

        private static void CircleAreaUI()
        {
            Console.Write("Ange cirkelns diameter i millimeter : ");
            string inputString = Console.ReadLine().Trim();
            if (double.TryParse(inputString, out double value) == true)
            {
                Console.WriteLine($"\tCirkeln med diameter {value} millimeter, har arean: {CircleArea(value)} mm²");
            }
            else
            {
                Console.WriteLine("Ogiltigt värde!");
            }
        }

        public static double CircleArea(double value)
        {
            return Math.Pow(value / 2, 2) * Math.PI;
        }

        private static void SphereVolumeUI()
        {
            Console.Write("Ange klotets diameter i millimeter : ");
            string inputString = Console.ReadLine().Trim();
            if (double.TryParse(inputString, out double value) == true)
            {
                Console.WriteLine($"\tKlotet med diameter {value} millimeter, har volymen: {SpereVolume(value)} mm³");
            }
            else
            {
                Console.WriteLine("Ogiltigt värde!");
            }
        }

        public static double SpereVolume(double value)
        {
            return 4 * Math.Pow(value / 2, 3) * Math.PI / 3;
        }
    }
}
