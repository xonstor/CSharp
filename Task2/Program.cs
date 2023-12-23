using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter array length:");
        int length = Convert.ToInt32(Console.ReadLine());

        if (length <= 0)
        {
            Console.WriteLine("The length of the array must be a positive number.");
            return;
        }

        int[] numbers = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.WriteLine($"Enter number number {i + 1}:");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Final array:");

        foreach (int number in numbers)
        {
            Console.Write($"{number} ");
        }

        // Чтобы программа не завершалась сразу после вывода результата
        Console.ReadLine();
    }
}