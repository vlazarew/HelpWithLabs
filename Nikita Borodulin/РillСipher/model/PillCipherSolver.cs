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
        public static string Solve(string alphabet, string key, string text)
        {
            int size = (int)Math.Sqrt(key.Length);

            int[][] keyMatrix = generateKeyMatrix(key, alphabet, size);

            int[][] textBlocks = generateTextBlocks(text, alphabet, size);

            int[][] encodedBlocks = encodeBlocks(keyMatrix, textBlocks, size, alphabet.Length);

            string result = encodedBlockToString(encodedBlocks, alphabet);
            return result;
        }

        private static string encodedBlockToString(int[][] encodedBlocks, string alphabet)
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

        private static int[][] encodeBlocks(int[][] keyMatrix, int[][] textBlocks, int size, int alphabetSize)
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
            }

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

            return result;
        }

        private static int[][] generateTextBlocks(string text, string alphabet, int size)
        {
            List<int[]> t = new List<int[]>();
            List<int> tempList = new List<int>();
            foreach (char c in text)
            {
                tempList.Add(alphabet.IndexOf(c));
                if (tempList.Count == size)
                {
                    t.Add(tempList.ToArray());
                    tempList.Clear();
                }
            }

            if (tempList.Count != 0)
            {
                while (tempList.Count != size)
                {
                    tempList.Add(alphabet.Length - 2);
                }
                t.Add(tempList.ToArray());
                tempList.Clear();
            }

            return t.ToArray();
        }

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
    }
}
