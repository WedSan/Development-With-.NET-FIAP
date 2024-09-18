using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeCalculator
{

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Digite seu nome completo: ");
                String name = Console.ReadLine();

                Console.Write("Digite sua data de nascimento (formato: dd/MM/yyyy): ");
                String birthDataInput = Console.ReadLine();

                DateTime birthData;
                bool validDate = DateTime.TryParseExact(birthDataInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out birthData);

                if (!validDate)
                {
                    Console.WriteLine("Data de nascimento inválida. Por favor, tente novamente.");
                }
                else
                {
                    int age = CalculateAge(birthData);
                    Console.WriteLine($"{name}, você tem {age} anos");
                    Console.WriteLine("Fim do Programa");
                    Console.ReadKey();
                    break;

                }
                
                Console.ReadKey();
            }

        }

       static int CalculateAge(DateTime birthData)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthData.Year;

            if (currentDate < birthData.AddYears(age))
            {
                age--;
            }
            return age;
        }


    }
}
