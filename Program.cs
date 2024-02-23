using System;

public class Program
{
    static void Main(string[] args)
    {
        // Завдання 1
        Console.WriteLine("Завдання 1");
        double[] A = new double[5];
        double[,] B = new double[3, 4];

        // Заповнення масиву A введеними з клавіатури числами
        Console.WriteLine("Введіть елементи масиву A:");
        for (int i = 0; i < A.Length; i++)
        {
            A[i] = Convert.ToDouble(Console.ReadLine());
        }

        
        Random rnd = new Random();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                B[i, j] = rnd.NextDouble() * 10; 
            }
        }

        
        Console.Write("Масив A: ");
        foreach (var item in A)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\nМасив B:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(B[i, j] + " ");
            }
            Console.WriteLine();
        }

        
        double maxA = A[0], minA = A[0], sumA = 0, prodA = 1, sumEvenA = 0, sumOddColumnsB = 0;
        for (int i = 0; i < A.Length; i++)
        {
            sumA += A[i];
            prodA *= A[i];
            if (A[i] > maxA)
                maxA = A[i];
            if (A[i] < minA)
                minA = A[i];
            if (A[i] % 2 == 0)
                sumEvenA += A[i];
        }
        for (int j = 0; j < 4; j++)
        {
            if (j % 2 != 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    sumOddColumnsB += B[i, j];
                }
            }
        }
        Console.WriteLine($"Максимальний елемент масиву A: {maxA}");
        Console.WriteLine($"Мінімальний елемент масиву A: {minA}");
        Console.WriteLine($"Загальна сума елементів масиву A: {sumA}");
        Console.WriteLine($"Загальний добуток елементів масиву A: {prodA}");
        Console.WriteLine($"Сума парних елементів масиву A: {sumEvenA}");
        Console.WriteLine($"Сума непарних стовпців масиву B: {sumOddColumnsB}");

        // Завдання 2
        Console.WriteLine("\nЗавдання 2");
        int[,] array = new int[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                array[i, j] = rnd.Next(-100, 101);
            }
        }
        int minIndex = 0, maxIndex = 0;
        int min = array[0, 0], max = array[0, 0], sumBetweenMinMax = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (array[i, j] < min)
                {
                    min = array[i, j];
                    minIndex = i * 5 + j;
                }
                if (array[i, j] > max)
                {
                    max = array[i, j];
                    maxIndex = i * 5 + j;
                }
            }
        }
        int start = Math.Min(minIndex, maxIndex) + 1;
        int end = Math.Max(minIndex, maxIndex);
        for (int k = start; k < end; k++)
        {
            sumBetweenMinMax += array[k / 5, k % 5];
        }
        Console.WriteLine($"Мінімальний елемент: {min}, Максимальний елемент: {max}");
        Console.WriteLine($"Сума елементів між мінімальним та максимальним: {sumBetweenMinMax}");

        // Завдання 3
        Console.WriteLine("\nЗавдання 3");
        Console.WriteLine("Введіть рядок для шифрування:");
        string input = Console.ReadLine();
        string encryptedText = CaesarCipher(input, 3); 
        Console.WriteLine($"Зашифрований текст: {encryptedText}");
        string decryptedText = CaesarCipher(encryptedText, -3); 
        Console.WriteLine($"Розшифрований текст: {decryptedText}");
    }

    public static string CaesarCipher(string text, int shift)
    {
        string result = "";
        foreach (char ch in text)
        {
            if (char.IsLetter(ch))
            {
                char offset = char.IsUpper(ch) ? 'A' : 'a';
                result += (char)(((ch + shift - offset) % 26) + offset);
            }
            else
            {
                result += ch;
            }
        }
        return result;
    }
}
