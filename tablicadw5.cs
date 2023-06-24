using System;

class tablicadw5
{
    static bool IsMagicSquare(int[,] square)
    {
        int n = square.GetLength(0);

        // Sprawdzenie warunku unikatowości
        int[] count = new int[n * n + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                count[square[i, j]]++;
                if (count[square[i, j]] > 1)
                    return false;
            }
        }

        // Obliczenie oczekiwanej sumy
        int expectedSum = n * (n * n + 1) / 2;

        // Sprawdzenie sum w wierszach i kolumnach
        for (int i = 0; i < n; i++)
        {
            int rowSum = 0;
            int colSum = 0;
            for (int j = 0; j < n; j++)
            {
                rowSum += square[i, j];
                colSum += square[j, i];
            }
            if (rowSum != expectedSum || colSum != expectedSum)
                return false;
        }

        // Sprawdzenie sum na przekątnych
        int diagSum1 = 0;
        int diagSum2 = 0;
        for (int i = 0; i < n; i++)
        {
            diagSum1 += square[i, i];
            diagSum2 += square[i, n - 1 - i];
        }
        if (diagSum1 != expectedSum || diagSum2 != expectedSum)
            return false;

        return true;
    }

    static void Main()
    {
        // Przykładowe kwadraty
        int[,] magicSquare = { { 2, 7, 6 }, { 9, 5, 1 }, { 4, 3, 8 } };
        int[,] nonUniqueSquare = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        int[,] nonSumSquare = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        // Wybór kwadratu do sprawdzenia
        Console.WriteLine("Wybierz kwadrat:");
        Console.WriteLine("1 - magiczny");
        Console.WriteLine("2 - niespełniający warunku unikatowości");
        Console.WriteLine("3 - niespełniający warunku sum");
        int choice = int.Parse(Console.ReadLine());

        int[,] square;
        switch (choice)
        {
            case 1:
                square = magicSquare;
                break;
            case 2:
                square = nonUniqueSquare;
                break;
            case 3:
                square = nonSumSquare;
                break;
            default:
                Console.WriteLine("Nieprawidłowy wybór.");
                return;
        }

        if (IsMagicSquare(square))
            Console.WriteLine("Podany kwadrat jest kwadratem magicznym.");
        else
            Console.WriteLine("Podany kwadrat nie jest kwadratem magicznym.");
    }
}
