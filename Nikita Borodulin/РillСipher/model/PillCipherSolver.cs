using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace РillСipher.model
{
    static class PillCipherSolver
    {
        #region Шифрование
        /*
         * Порядок шифрования методом Хила.
         * 1. Закодировать ключевое слово с помощью алфавита (А=1, Б=2 и т.д.). Поскольку длина ключа - квадрат (n*n), то сделаем из закодированного алфавита матрицу n*n
         * 2. Закодировать текст аналогичну алфавита. Разбить текст по символам по n символов в каждом (Если в последнем блоке не хватает символов сделано добавление пробелов)
         * 3. Шифруем блоки текста. Матрично умножаем каждый блок текста на матрицу ключа. Для каждого результата делаем mod (длина алфавита)
         * 4. Декодируем с помощью алфавита зашифрованные блоки текста, склеиваем их в одну строку
         */
        public static string Encrypt(string alphabet, string key, string text)
        {
            int size = (int)Math.Sqrt(key.Length);

            // 1 пункт
            int[][] keyMatrix = generateKeyMatrix(key, alphabet, size);

            // 2 пунки
            int[][] textBlocks = generateTextBlocks(text, alphabet, size);

            // 3 пункт
            int[][] encodedBlocks = codeBlocks(keyMatrix, textBlocks, size, alphabet.Length);

            // 4 пункт
            string result = codedBlockToString(encodedBlocks, alphabet);
            return result;
        }
        #endregion

        #region Расшифровка
        /*
         * Порядок дешифровки методом Хила.
         * 1. Кодируем шифротекст в цифры и разбиваем на блоки
         * 2. Закодировать ключевое слово с помощью алфавита (А=1, Б=2 и т.д.). Поскольку длина ключа - квадрат (n*n), то сделаем из закодированного алфавита матрицу n*n
         * 3. Найти определитель матрицы ключа (сделано с помощью метода Гаусса)
         * 4. Найти НОД между определителем и размером алфавита с помощью расширенного метода Евклида (причем нужен не сам результат, а коэффициент x)
         * 5. Найти обратный детерминанту элемент в кольце по модулю (размер алфавита)
         * 6. Получить матрицу алгебраических дополнений относительно матрицы ключа
         * 7. Произвести над матрицей алгебраических дополнений операции: mod (размер алфавита); умножение на обратный детерминанту элемент; mod (размер алфавита)
         * 8. Транспонировать полученную матрицу алгебраических дополнений
         * 9. Если элемент матрицы отрицательный, меняем его на другой, вычисленный по формуле (размер алфавита + элемент)
         * 10. Умножить блоки шифротекста на полученную матрицу алгебраических дополнений и выполнить mod (размер алфавита) над полученными блоками
         * 11. Декодируем с помощью алфавита расшифрованные блоки текста, склеиваем их в одну строку
         */
        public static string Decrypt(string alphabet, string key, string text)
        {
            int size = (int)Math.Sqrt(key.Length);

            // 1 пункт
            int[][] textBlocks = generateTextBlocks(text, alphabet, size);

            // 2 пункт
            int[][] keyMatrix = generateKeyMatrix(key, alphabet, size);

            // 3 пункт
            int determinantkey = getDeterminantGauss(keyMatrix, size);

            // 4 пункт
            int x = gcdExtendedEuclid(determinantkey, alphabet.Length);

            // 5 пункт
            int reverseDeterminant = 0;
            if ((determinantkey < 0 && x >= 0) || (determinantkey >= 0 && x >= 0))
            {
                reverseDeterminant = x;
            }
            if (determinantkey >= 0 && x < 0)
            {
                reverseDeterminant = alphabet.Length + x;
            }
            if (determinantkey < 0 && x < 0)
            {
                reverseDeterminant = -x;
            }

            // 6 пункт
            int[][] keyAlgDop = getAlgDop(keyMatrix, size);

            // 7 пункт
            modMatrix(keyAlgDop, size, alphabet.Length);
            multiplyMatrix(keyAlgDop, size, reverseDeterminant);
            modMatrix(keyAlgDop, size, alphabet.Length);

            // 8 пункт
            transposeMatrix(keyAlgDop, size);

            // 9 пункт
            modifyMatrix(keyAlgDop, size, alphabet.Length);

            // 10 пункт
            int[][] decodedBlocks = codeBlocks(keyAlgDop, textBlocks, size, alphabet.Length);

            // 11 пункт
            return codedBlockToString(decodedBlocks, alphabet);
        }

        // Получение определителя методом Гаусса
        private static int getDeterminantGauss(int[][] sourceMatrix, int size)
        {
            double[][] matrix = makeDoubleMatrix(sourceMatrix, size);
            double det = 1;

            for (int i = 0; i < size; i++)
            {
                int k = i;

                for (int j = i + 1; j < size; j++)
                {
                    if (Math.Abs(matrix[j][i]) > Math.Abs(matrix[k][i]))
                    {
                        k = j;
                    }
                }

                if (Math.Abs(matrix[k][i]) < 0.00001)
                {
                    det = 0;
                    break;
                }

                swapRows(matrix, i, k);
                if (i != k)
                {
                    det = -det;
                }

                det *= matrix[i][i];

                for (int j = i + 1; j < size; j++)
                {
                    matrix[i][j] /= matrix[i][i];
                }

                for (int j = 0; j < size; j++)
                {
                    if (j != i && Math.Abs(matrix[j][i]) > 0.00001)
                    {
                        for (int q = i + 1; q < size; q++)
                        {
                            matrix[j][q] -= matrix[i][q] * matrix[j][i];
                        }
                    }
                }
            }

            return (int)Math.Round(det);
        }

        // Создание копии исходной матрицы, только с типом double, не int
        private static double[][] makeDoubleMatrix(int[][] sourceMatrix, int size)
        {
            double[][] matrix = new double[size][];
            for (int i = 0; i < size; i++)
            {
                double[] tempRow = new double[size];
                for (int j = 0; j < size; j++)
                {
                    tempRow[j] = sourceMatrix[i][j];
                }
                matrix[i] = tempRow;
            }

            return matrix;
        }

        // Переместить 2 строки между собой в матрице
        private static void swapRows(double[][] matrix, int pivot_index, int i)
        {
            double[] tempRow = matrix[pivot_index];
            matrix[pivot_index] = matrix[i];
            matrix[i] = tempRow;
        }

        // Получение коэффициента x в расширенном методе Евклида
        private static int gcdExtendedEuclid(int d, int b)
        {
            int x = 1, xx = 0, y = 0, yy = 1;
            while (b != 0)
            {
                int q = d / b;
                int temp = d;
                d = b;
                b = temp % b;

                temp = x;
                x = xx;
                xx = temp - xx * q;

                temp = y;
                y = yy;
                yy = temp - yy * q;
            }

            return x;
        }

        // Создание алгебраического дополнения матрицы
        private static int[][] getAlgDop(int[][] matrix, int size)
        {
            int[][] result = new int[size][];

            for (int i = 0; i < size; i++)
            {
                int[] tempRow = new int[size];
                for (int j = 0; j < size; j++)
                {
                    int[][] minor = getMinor(matrix, size, j, i);
                    tempRow[j] = (int)Math.Pow(-1, i + 1 + j + 1) * getDeterminantGauss(minor, size - 1);
                }
                result[i] = tempRow;
            }

            return result;
        }

        // Получение минора матрицы (путем игнорирования заданного стобца и строки)
        private static int[][] getMinor(int[][] matrix, int size, int CuttedColumn, int CuttedRow)
        {
            int[][] minor = new int[size - 1][];

            int indexRow = 0;
            for (int i = 0; i < size; i++)
            {
                if (i != CuttedRow)
                {
                    int[] tempRow = new int[size - 1];
                    int indexColumn = 0;
                    for (int j = 0; j < size; j++)
                    {
                        if (j != CuttedColumn)
                        {
                            tempRow[indexColumn] = matrix[i][j];
                            indexColumn++;
                        }
                    }

                    minor[indexRow] = tempRow;
                    indexRow++;
                }
            }

            return minor;
        }

        // Выполнить операцию mod над всей матрицей
        private static void modMatrix(int[][] matrix, int size, int delimeter)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    bool isNegative = matrix[i][j] < 0;
                    matrix[i][j] = matrix[i][j] % delimeter;
                    if ((matrix[i][j] > 0 && isNegative) || (matrix[i][j] < 0 && !isNegative))
                    {
                        matrix[i][j] = -matrix[i][j];
                    }
                }
            }
        }

        // Умножить всю матрицу на число
        private static void multiplyMatrix(int[][] matrix, int size, int reverseDeterminant)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] *= reverseDeterminant;
                }
            }
        }

        // Транспонировать матрицу
        private static void transposeMatrix(int[][] matrix, int size)
        {
            int[][] resultMatrix = copyMatrix(matrix, size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] = resultMatrix[j][i];
                }
            }
        }

        // Сделать копию матрицы
        private static int[][] copyMatrix(int[][] matrix, int size)
        {
            int[][] resultMatrix = new int[size][];
            for (int i = 0; i < size; i++)
            {
                int[] tempRow = new int[size];
                for (int j = 0; j < size; j++)
                {
                    tempRow[j] = matrix[i][j];
                }
                resultMatrix[i] = tempRow;
            }

            return resultMatrix;
        }

        // Для пункта 9
        // Если элемент матрицы отрицательный, меняем его на другой, вычисленный по формуле (размер алфавита + элемент)
        private static void modifyMatrix(int[][] matrix, int size, int length)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] = matrix[i][j] < 0 ? length + matrix[i][j] : matrix[i][j];
                }
            }
        }
        #endregion

        #region Общие методы
        // Блок текста в строку
        private static string codedBlockToString(int[][] encodedBlocks, string alphabet)
        {
            string result = "";
            foreach (int[] block in encodedBlocks)
            {
                foreach (int index in block)
                {
                    result += alphabet[index];
                }
            }

            return result;
        }

        // Создание зашифрованных блоков текста
        private static int[][] codeBlocks(int[][] keyMatrix, int[][] textBlocks, int size, int alphabetSize)
        {
            int[][] result = new int[textBlocks.Length][];

            int index = 0;
            foreach (int[] textBlock in textBlocks)
            {
                if (textBlock.Length != size)
                {
                    MessageBox.Show("Нельзя умножить матрицы. Количество строк в тексте не равно количество стобцов ключа.");
                    return result;
                }

                int[] tempResult = new int[size];
                // Матричное умножение блока текста на матрицу ключа
                for (int columnKey = 0; columnKey < size; columnKey++)
                {
                    tempResult[columnKey] = 0;

                    for (int columnBlock = 0; columnBlock < textBlock.Length; columnBlock++)
                    {
                        tempResult[columnKey] += textBlock[columnBlock] * keyMatrix[columnBlock][columnKey];
                    }
                }
                result[index] = tempResult;
                index++;
                //
            }

            // mod (размер алфавита)
            index = 0;
            foreach (int[] encodedResult in result)
            {
                int[] tempResult = new int[size];
                int tempIndex = 0;
                foreach (int value in encodedResult)
                {
                    tempResult[tempIndex] = value % alphabetSize;
                    tempIndex++;
                }
                result[index] = tempResult;
                index++;
            }
            //

            return result;
        }

        // Генерация и кодирование блоков текста исходя из исходного текста, алфавита
        private static int[][] generateTextBlocks(string text, string alphabet, int size)
        {
            List<int[]> result = new List<int[]>();
            List<int> tempList = new List<int>();
            foreach (char c in text)
            {
                tempList.Add(alphabet.IndexOf(c));
                if (tempList.Count == size)
                {
                    result.Add(tempList.ToArray());
                    tempList.Clear();
                }
            }

            if (tempList.Count != 0)
            {
                while (tempList.Count != size)
                {
                    tempList.Add(alphabet.Length - 2);
                }
                result.Add(tempList.ToArray());
                tempList.Clear();
            }

            return result.ToArray();
        }

        // Генерация и кодирование матрицы ключа исходя из ключа, алфавита
        private static int[][] generateKeyMatrix(string key, string alphabet, int size)
        {
            int[][] result = new int[size][];

            for (int row = 0; row < size; row++)
            {
                int[] tempArray = new int[size];
                for (int column = 0; column < size; column++)
                {
                    tempArray[column] = alphabet.IndexOf(key[size * row + column]);
                }
                result[row] = tempArray;
            }

            return result;
        }
        #endregion



        


    }
}
