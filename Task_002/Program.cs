/*
Задача 2:
Напишите программу вычисления функции
Аккермана с помощью рекурсии. Даны два
неотрицательных числа m и n.
Пример:                          /
m = 2, n = 3 -> A(m,n) = 29   -=<  Значение 29 будет при m = 3, n = 2, а не наоборот!
                                 \
*/ 
using System.Diagnostics;

Main();

void Main()
{
    int count = 0;
    int countTurbo = 0;
    Stopwatch stopwatch = new Stopwatch();
    Stopwatch stopwatchTurbo = new Stopwatch();

    // Для сравнения времени выполнения методов задайте m = 3, n = 11
    
    int n = inputInt("Введите неотрицательное число - ");
    int m = inputInt("Введите ещё одно неотрицательное число - ");

    stopwatch.Start();
    int result = ackermann(n, m);
    stopwatch.Stop();
    int temp = ackermannCount(n, m, ref count);

    Console.WriteLine($"Значение функции Аккермана         A({n}, {m}) = {result}. Время расчёта - {stopwatch.ElapsedMilliseconds} мс. Количество рекурсий - {count}");

    stopwatchTurbo.Start();
    result = ackermannTurbo(n, m);
    stopwatchTurbo.Stop();
    temp = ackermannTurboCount(n, m, ref countTurbo);

    Console.WriteLine($"Значение функции Аккермана - турбо A({n}, {m}) = {result}. Время расчёта - {stopwatchTurbo.ElapsedMilliseconds} мс. Количество рекурсий - {countTurbo}");
}

int ackermann(int m, int n)
{
    if (m == 0)
        return n + 1;
    else if (n == 0) // условие (n > 0 && m == 0) излише сложное, ибо в этом месте всегда n > 0 !!!
        return ackermann(m - 1, 1);
    else  // (n > 0 && m > 0)
        return ackermann(m - 1, ackermann(m, n - 1));
}

// Для расчёта количества рекурсий
int ackermannCount(int m, int n, ref int count)
{
    if (m == 0)
    {
        count++;
        return n + 1;
    }
    else if (n == 0)
    {
        count++;
        return ackermannCount(m - 1, 1, ref count);
    }
    else
    {
        count++;
        return ackermannCount(m - 1, ackermannCount(m, n - 1, ref count), ref count);
    }
}
// -----------------------------------------------------------------------------
// Это решение не противоречит условиям задачи:

int ackermannTurbo(int m, int n)
{
    while (m != 0)
    {
        if (n == 0)
            n = 1;
        else
            n = ackermannTurbo(m, n - 1);
        m = m - 1;
    }
    return n + 1;
}

// Для расчёта количества рекурсий
int ackermannTurboCount(int m, int n, ref int countTurbo)
{
    while (m != 0)
    {
        if (n == 0)
            n = 1;
        else
        {
            countTurbo++;
            n = ackermannTurboCount(m, n - 1, ref countTurbo);
        }
        m = m - 1;
    }
    return n + 1;
}

int inputInt(string msg)
{
    while (true)
    {
        Console.Write($"{msg}");
        if (int.TryParse(Console.ReadLine(), out int number))
            //if (number >= 1)
            if (number >= 0)
                return number;
        Console.WriteLine("Это не натуральное число! Попробуйте ещё раз.");
    }
}