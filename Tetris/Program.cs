using System;
using System.Threading;

class Tetris
{
    static void Main()
    {
        int width = 10;
        int height = 20;
        bool[,] playfield = new bool[height, width];
        int currentRow = 0;
        int currentCol = width / 2;

        bool isGameOver = false;

        // Массивы для различных фигур
        int[][,] tetrominoes =
        {
            new int[,] { { 1, 1, 1, 1 } },   // I-фигура
            new int[,] { { 1, 1, 0 }, { 0, 1, 1 } },   // Z-фигура
            new int[,] { { 0, 1, 1 }, { 1, 1, 0 } },   // S-фигура
            new int[,] { { 1, 1 }, { 1, 1 } },   // O-фигура
            new int[,] { { 1, 1, 1 }, { 0, 1, 0 } },   // T-фигура
            new int[,] { { 1, 1, 1 }, { 1, 0, 0 } },   // J-фигура
            new int[,] { { 1, 1, 1 }, { 0, 0, 1 } }    // L-фигура
        };

        Random random = new Random();
        int currentTetromino = random.Next(0, tetrominoes.Length);
        int[,] tetromino = tetrominoes[currentTetromino];
        int tetrominoWidth = tetromino.GetLength(1);
        int tetrominoHeight = tetromino.GetLength(0);

        // Дополнительный массив для фигуры I, где элементы в строке идут через запятую
        int[,] iShape = new int[,] { { 1 }, { 1 }, { 1 }, { 1 } };
        tetrominoes[0] = iShape;

        // Остальные фигуры инициализированы как было в предыдущем примере

        while (!isGameOver)
        {
            Console.Clear();

            // Отображение игрового поля
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if ((row >= currentRow && row < currentRow + tetrominoHeight) &&
                        (col >= currentCol && col < currentCol + tetrominoWidth) &&
                        (tetromino[row - currentRow, col - currentCol] == 1))
                    {
                        Console.Write("* ");
                    }
                    else if (playfield[row, col])
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }

            // Проверка на завершение игры и обработка клавиш для управления
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (currentCol > 0)
                    {
                        currentCol--;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (currentCol < width - tetrominoWidth)
                    {
                        currentCol++;
                    }
                }
            }

            // Падение фигуры
            if (currentRow < height - tetrominoHeight)
            {
                currentRow++;
            }
            else
            {
                // Если достигнута нижняя часть поля
                for (int row = 0; row < tetrominoHeight; row++)
                {
                    for (int col = 0; col < tetrominoWidth; col++)
                    {
                        if (tetromino[row, col] == 1)
                        {
                            playfield[currentRow + row - 1, currentCol + col] = true;
                        }
                    }
                }

                currentTetromino = random.Next(0, tetrominoes.Length);
                tetromino = tetrominoes[currentTetromino];
                tetrominoWidth = tetromino.GetLength(1);
                tetrominoHeight = tetromino.GetLength(0);
                currentRow = 0;
                currentCol = width / 2;

                // Проверка на конец игры
                for (int col = 0; col < width; col++)
                {
                    if (playfield[0, col])
                    {
                        isGameOver = true;
                        break;
                    }
                }
            }

            // Задержка перед следующим циклом
            Thread.Sleep(200);
        }

        Console.WriteLine("Игра окончена!");
    }
}