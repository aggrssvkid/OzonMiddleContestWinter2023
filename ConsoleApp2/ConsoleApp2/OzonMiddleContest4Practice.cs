using System;
using System.Collections.Generic;
using System.Text;
/*
Вам необходимо написать часть функциональности обработки сортировок в электронных таблицах.

Задана прямоугольная таблица n×m
 (n
 строк по m
 столбцов) из целых чисел.

Если кликнуть по заголовку i
-го столбца, то строки таблицы пересортируются таким образом,
что в этом столбце значения будут идти по неубыванию (то есть возрастанию или равенству). 
При этом, если у двух строк одинаковое значение в этом столбце, то относительный порядок строк не изменится

Заметим, что если кликнуть подряд два раза в один столбец, 
то после второго клика таблица не изменится (в момент второго клика она уже отсортирована по этому столбцу).

Обработайте последовательность кликов и выведите состояние таблицы после всех кликов.
*/

namespace ConsoleApp2
{
    class OzonMiddleContest4Practice
    {
    }
}
/*
using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int numOfTests = Convert.ToInt32(Console.ReadLine());
        int[][][] arrOfMatrixes = new int[numOfTests][][];
        arrOfMatrixes[0] = new int[3][];
        for (int test = 0; test < numOfTests; test++)
        {
            // Zapolnyaem i inicializiruem dannie
            Console.ReadLine();
            string[] datas = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(datas[0]);
            int m = Convert.ToInt32(datas[1]);
            arrOfMatrixes[test] = new int[n][];
            for (int strNum = 0; strNum < n; strNum++)
            {
                datas = Console.ReadLine().Split(' ');
                arrOfMatrixes[test][strNum] = new int[m];
                for (int column = 0; column < m; column++)
                    arrOfMatrixes[test][strNum][column] = Convert.ToInt32(datas[column]);
            }
            int clicksNum = Convert.ToInt32(Console.ReadLine());
            datas = Console.ReadLine().Split(' ');

            int[] columnClicks = new int[clicksNum];
            for (int column = 0; column < clicksNum; column++)
                columnClicks[column] = Convert.ToInt32(datas[column]);

            // Sortiruem stroki v matrice 
            Col[] col = new Col[n];
            for (int i = 0; i < n; i++)
                col[i] = new Col(arrOfMatrixes[test][i], i);
            for (int click = 0; click < clicksNum; click++)
            {
                for (int k = 0; k < col.Length; k++)
                    col[k].Column = columnClicks[click] - 1;
                Array.Sort(col, new Col());
                for (int k = 0; k < col.Length; k++)
                    col[k].StrIdx = k;
                for (int i = 0; i < n; i++)
                    arrOfMatrixes[test][i] = col[i].StrValues;
            }
        }
        for (int r = 0; r < numOfTests; r++)
        {
            for (int i = 0; i < arrOfMatrixes[r].GetLength(0); i++)
            {
                for (int j = 0; j < arrOfMatrixes[r][i].GetLength(0); j++)
                    Console.Write($"{arrOfMatrixes[r][i][j]} ");
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
    class Col : IComparer<Col>
    {
        int[] strValues;
        int strIdx;
        int column;

        public int[] StrValues
        {
            get { return strValues; }
            set { strValues = value; }
        }

        public int StrIdx
        {
            get { return strIdx; }
            set { strIdx = value; }
        }

        public int Column
        {
            get { return column; }
            set { column = value; }
        }
        public Col() { }

        public Col(int[] arrOfvalues, int strBaseIdx)
        {
            this.strValues = arrOfvalues;
            this.strIdx = strBaseIdx;
        }

        public int Compare(Col x, Col y)
        {
            if (x.strValues[x.column] > y.strValues[y.column])
                return 1;
            else if (x.strValues[x.column] < y.strValues[y.column])
                return -1;
            else
            {
                if (x.strIdx > y.strIdx)
                    return 1;
                else if (x.strIdx < y.strIdx)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
*/
