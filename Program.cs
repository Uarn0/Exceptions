using System.Text;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        /*Random random = new Random();
        for (int i = 10; i <= 29; i++)
        {
            string fileName = $"{i}.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(random.Next(50, 100));
                writer.WriteLine(random.Next(10, 50));
            }
        }*/
        List<double> res = new List<double>();
        List<string> noFileList = new List<string>();
        List<string> badDataList = new List<string>();
        List<string> overflowList = new List<string>();
        for (int i = 10; i < 30; i++)
        {
            string fileName = $"{i}.txt";

            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    long number1 = long.Parse(sr.ReadLine());
                    long number2 = long.Parse(sr.ReadLine());
                    checked
                    {
                        long resOfMul = checked(number1 * number2);

                        res.Add(resOfMul);
                    }
                        
                    
                }
            }
            catch (FileNotFoundException)
            {
                noFileList.Add(fileName);
            }
            catch (FormatException)
            {
                badDataList.Add(fileName);
            }
            catch (OverflowException)
            {
                overflowList.Add(fileName);
            }

            try
            {
                File.WriteAllLines("no_file.txt", noFileList);
                File.WriteAllLines("bad_data.txt", badDataList);
                File.WriteAllLines("overflow.txt", overflowList);
            }
            catch 
            {
                Console.WriteLine("Помилка створенні одного із вихідних фалів.");
                return;
            }
            if(res.Count > 0) 
            {
                double avarage = res.Average();
                Console.WriteLine("Середнє арифметичне добутків " + avarage);
            }
            else
            {
                Console.WriteLine("Жодного конкретного добутку не було знайдено.");
            }
        }
    }
}