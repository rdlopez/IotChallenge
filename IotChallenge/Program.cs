using Model;
using System;
using System.IO;

namespace IotChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcomer to the income calculator");
                Console.WriteLine("Please specify the path where the file is located");
                var pathFile = Console.ReadLine();

                if (string.IsNullOrEmpty(pathFile))
                {
                    pathFile = "./Solution Items/EmployeesTestFile.txt";
                }

                string[] employees = File.ReadAllLines(pathFile);
                if (employees.Length > 0)
                {
                    foreach (string line in employees)
                    {
                        Employee employee = new Employee(line);
                        Console.WriteLine($"The amount to pay { employee.Name } is: {employee.Total} USD");
                    }
                }
                else
                {
                    Console.WriteLine("The file does not have records to proceed. Please verify the path and try again");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Something went wrong. Please contact our support team with this message  {ex.Message}" );
            }

            Console.ReadLine();
        }
    }
}
