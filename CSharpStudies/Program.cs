using System;

class Program
{
    static void Main()
    {
        // Запрос ввода двух чисел
        Console.WriteLine("Input two numbers:");

        // Считываем ввод пользователя и сохраняем в переменные
        double number1 = Convert.ToDouble(Console.ReadLine());
        double number2 = Convert.ToDouble(Console.ReadLine());

        // Вывод чисел
        Console.WriteLine($"Number 1: {number1}");
        Console.WriteLine($"Number 2: {number2}");

        // Сумма
        double sum = number1 + number2;
        Console.WriteLine($"Sum: {sum}");

        // Разность
        double difference = number1 - number2;
        Console.WriteLine($"Difference: {difference}");

        // Умножение
        double product = number1 * number2;
        Console.WriteLine($"Product: {product}");

        // Деление (проверка деления на 0)
        if (number2 != 0)
        {
            double division = number1 / number2;
            Console.WriteLine($"Division: {division}");
        }
        else
        {
            Console.WriteLine("You can't divide ny zero.");
        }

        // Чтобы программа не завершалась сразу после вывода результата
        Console.ReadLine();
    }
}