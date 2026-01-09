using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

     List<int> numbers = new List<int>();
        
        
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter number (Enter 0 to quit): ");
            
            string userReply = Console.ReadLine();
            userNumber = int.Parse(userReply);
            
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        
        int large = numbers[0];

        foreach (int number in numbers)
        {
            if (number > large)
            {
                large = number;
            }
        }

        Console.WriteLine($"The largest number is: {large}");

    }
}