/*
Задача 1:
Задайте значения M и N. Напишите
программу, которая выведет все натуральные числа
в промежутке от M до N. Использовать рекурсию, не
использовать циклы.
Пример:
M = 1; N = 5 -> "1, 2, 3, 4, 5"
M = 4; N = 8 -> "4, 5, 6, 7, 8"
*/
Main();

void Main()
{
    int m = inputInt("Введите натуральное число - ");
    int n = inputInt("Введите другое натуральное число - ");
    
    Console.Write($"M = {m}; N = {n} -> \"");

    printRangeOfNaturalNumerals(m, n);

    Console.WriteLine("\"");

    void printRangeOfNaturalNumerals(int m, int n)
    {
        if (m < n)
        {
            Console.Write($"{m}, ");
            printRangeOfNaturalNumerals(++m, n);
        }
        else if(m > n)
        {
            Console.Write($"{m}, ");
            printRangeOfNaturalNumerals(--m, n);
        }
        else
        {
            Console.Write(m);
            return;
        }
    }

    int inputInt(string msg)
    {
        while (true)
        {
            Console.Write($"{msg}");
            if (int.TryParse(Console.ReadLine(), out int number))
                if (number >= 1)
                    return number;
            Console.WriteLine("Это не натуральное число! Попробуйте ещё раз.");
        }
    }
}