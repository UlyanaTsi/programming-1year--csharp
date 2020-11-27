using System;
using System.IO;


namespace Faculty
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            do
            {
                IO files = new IO();
                MatrixMultiply mult = new MatrixMultiply();
                MatrixAddition add = new MatrixAddition();
                MatrixSum sum = new MatrixSum();
                MultiplyConstant cons = new MultiplyConstant();

                string path = Check("Введите путь к директориям");
                Console.Write("Введите комманды через пробел");
                string commands = Console.ReadLine();
                string[] command = commands.Split(' ');

                if (files.IsConstant($@"{path}\{1}.txt"))
                {
                    int constant = files.ReadInt($@"{path}\{1}.txt");
                    int[,] matrix = 
                }
                else
                {
                    var kek = files.ReadMatrix($@"{path}\{1}.txt");
                }

                for (int i = 1; i < Directory.GetFiles(path).Length; i++)
                {
                    try
                    {
                        switch (command[i])
                        {
                            case "MatrixMultiply":
                                mult.Do(kek, files.ReadMatrix($@"{path}\{i + 1}.txt"));
                                break;
                            case "MatrixSum":
                                sum.Do(kek, files.ReadMatrix($@"{path}\{i + 1}.txt"));
                                break;
                            case "MatrixAddition":
                                add.Do(kek, files.ReadMatrix($@"{path}\{i + 1}.txt"));
                                break;
                            case "MatrixConstant":
                                cons.Do(kek, files.ReadInt($@"{path}\{i + 1}.txt"));
                                break;
                            default:
                                throw new Exception();
                        }

                        string data = FromMatrixToDrata(matrix);
                        files.WriteData($@"{path}\{i}.txt", data);
                    }
                    catch 
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
                Console.WriteLine("Нажмите Escape  чтобы выйти");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static string FromMatrixToDrata(int[,] matrix)
        {
            string result = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result = result + matrix[i, j] + " ";
                }
            }
            return result;
        }

        static string Check(string info)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(info);
                    string input = Console.ReadLine();

                    if (File.Exists(input))
                        return input;
                    else
                        throw new IOException();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
    class MatrixAddition
    {
        public int[,] Do(int[,] left, int[,] right)
        {
            if(CheckOnCorrect(left, right) == false)
            {
                throw new IndexOutOfRangeException();
            }

            int[,] result = new int[left.GetLength(0), left.GetLength(1)];

            for (int i = 0; i < left.GetLength(0); i++)
            {
                for (int j = 0; j < left.GetLength(1); j++)
                {
                    result[i, j] = left[i, j] - right[i,j];
                }
            }
            return result;
        }

        public bool CheckOnCorrect(int[,] left, int[,] right)
        {
            return (left.GetLength(0) == right.GetLength(0) &&
                left.GetLength(1) == right.GetLength(1));
        }
    }

    class MultiplyConstant
    {
        public int[,] Do(int[,] left, int cons)
        {
            if (CheckOnCorrect(left, cons) == false)
            {
                throw new IndexOutOfRangeException();
            }

            int[,] result = new int[left.GetLength(0), left.GetLength(1)];

            for (int i = 0; i < left.GetLength(0); i++)
            {
                for (int j = 0; j < left.GetLength(1); j++)
                {
                    result[i, j] = left[i, j] * cons;
                }
            }
            return result;
        }

        public bool CheckOnCorrect(int[,] left, int cons)
        {
            return (left.GetLength(0) <= 0 || left.GetLength(1) <= 0);
        }
    }

    class MatrixMultiply
    {
        public int[,] Do(int[,] left, int[,] right)
        {
            if (CheckOnCorrect(left, right))
                throw new IndexOutOfRangeException();

            int aRows = left.GetLength(0); int aCols = left.GetLength(1);
            int bRows = right.GetLength(0); int bCols = right.GetLength(1);

            int[,] result = new int[left.GetLength(0), right.GetLength(1)];

            for (int i = 0; i < aRows; ++i) // каждая строка A
                for (int j = 0; j < bCols; ++j) // каждый столбец B
                    for (int k = 0; k < aCols; ++k)
                        result[i, j] += left[i, k] * right[k, j];
            return result;
        }

        public bool CheckOnCorrect(int[,] left, int[,] right)
        {
            if ((left.GetLength(1) == right.GetLength(0)))
                return true;
            else
                return false;
        }
    }


    class MatrixSum
    {
        public int[,] Do(int[,] left, int[,] right)
        {
            if (CheckOnCorrect(left, right))
                throw new IndexOutOfRangeException();

            int[,] result = new int[left.GetLength(0), right.GetLength(1)];

            for (int i = 0; i < left.GetLength(0); ++i)
                for (int j = 0; j < left.GetLength(1); ++j)
                    result[i, j] = left[i, j] + right[i, j];
            return result;
        }

        public bool CheckOnCorrect(int[,] left, int[,] right)
        {
            if ((left.GetLength(0) == right.GetLength(0)) && (left.GetLength(1) == right.GetLength(1)))
                return true;
            else
                return false;
        }
    }


    class IO
    {
        public bool IsConstant(string path)
        {
            string[] text = File.ReadAllLines(path);
            if (text.Length != 1)
            {
                return false;
            }
            else if (text[0].Split(' ').Length != 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public int[,] ReadMatrix(string path)
        {
            string[] text = File.ReadAllLines(path);
            int[,] result = new int[text.Length, text[0].Split(' ').Length];
            string[] bufer = new string[1];

            for (int i = 0; i < text.Length; i++)
            {
                bufer = text[i].Split(' ');
                for (int j = 0; j < bufer.Length; j++)
                {
                    result[i, j] = int.Parse(bufer[j]);
                }
            }

            return result;
        }

        public int ReadInt(string path)
        {
            string number = File.ReadAllText(path);
            int cons = int.Parse(number);
            return cons;
        }

        public void WriteData(string path, string data)
        {
            File.AppendAllText(path, data);
        }
    }
}
