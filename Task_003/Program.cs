/*
Задача 3:
Задайте произвольный массив. Выведете
его элементы, начиная с конца. Использовать
рекурсию, не использовать циклы.
Пример:
[1, 2, 5, 0, 10, 34] => 34 10 0 5 2 1 
*/
Main();

void Main()
{
    int size = inputInteger("Введите размер массива - ");
    int maxValue = inputInteger("Введите максимальное значение элементов массива - ");

    int[] array = getArray(size, maxValue);

    // Вывод форматированный под матрицу
    printArray(array);
    Console.Write(" => ");
    printInvArray(array, array.Length - 1);

    Console.WriteLine();

    // Вывод как в примере к задаче
    printArray(array);
    Console.Write(" => ");
    printInvArraySimple(array, array.Length - 1);

    // Вариант через инверсию массива с последующим стандартным выводом (тем же методом, как и исходного массива) 
    Console.WriteLine();
    printArray(array);
    Console.Write(" => ");
    printArray(invertArray(array));

}
//----------------------------------------------------
int inputInteger(string msg)
{
    while (true)
    {
        Console.Write($"{msg}");
        if (int.TryParse(Console.ReadLine(), out int number))
            if (number > 0)
                return number;
        Console.WriteLine("Это не натуральное число! Попробуйте ещё раз.");
    }
}

int[] getArray(int size, int maxValue)
{
    int[] arr = new int[size];
    Random rnd = new Random();
    for (int i = 0; i < size; i++)
        arr[i] = rnd.Next(maxValue + 1);
    return arr;
}

void printArray(int[] arr)
{
    Console.Write("[");
    for (int i = 0; i < arr.Length - 1; i++)
        Console.Write($"{arr[i]} ");
    Console.Write($"{arr[arr.Length - 1]}]");
}

void printInvArray(int[] arr, int index)
{
    if (arr.Length > 1)
    {
        if (index == arr.Length - 1)
        {
            Console.Write($"[{arr[index]} ");
            printInvArray(arr, --index);
        }
        else if (index == 0)
            Console.Write($"{arr[0]}]");
        else
        {
            Console.Write($"{arr[index]} ");
            printInvArray(arr, --index);
        }
    }
    else
        printArray(arr); // Нет нужды инвертировать
}

void printInvArraySimple(int[] arr, int index)
{
    Console.Write($"{arr[index]} ");
    if (index > 0)
        printInvArraySimple(arr, index - 1);
}

int[] invertArray(int[] arr)
{
    int size = arr.Length;
    int[] invArr = new int[size];
    change(arr, invArr, size -1);
    return invArr;
}

void change(int[] arr, int[] invArr, int index)
{
    invArr[invArr.Length - index - 1] = arr[index];
    if (index > 0)
        change(arr, invArr, index - 1);
}