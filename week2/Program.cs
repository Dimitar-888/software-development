using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine($"Възраст: {age}");
            }
            else
            {
                Console.WriteLine("Невалидна възраст.");
            }

            Console.Write("Въведете клас на ученика: ");

            if (byte.TryParse(Console.ReadLine(), out byte grade))
            {
                Console.WriteLine($"Клас: {grade}");
            }
            else
            {
                Console.WriteLine("Невалиден клас.");
            }

            Console.Write("Въведете среден успех: ");

            if (double.TryParse(Console.ReadLine(), out double average))
            {
                Console.WriteLine($"Среден успех: {average}");
            }
            else
            {
                Console.WriteLine("Невалиден успех.");
            }

            Console.Write("Въведете парична стойност: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine($"Сума: {amount}");
            }
            else
            {
                Console.WriteLine("Невалидна стойност.");
            }

            Console.Write("Въведете true или false: ");

            if (bool.TryParse(Console.ReadLine(), out bool hasScholarship))
            {
                Console.WriteLine(hasScholarship);
            }
            else
            {
                Console.WriteLine("Невалидна стойност.");
            }

        }
    }
}

