using System;
using System.Collections.Generic;
using System.Text;
/*
В этой задаче вам необходимо реализовать валидацию корректности карты для стратегической компьютерной игры.

Карта состоит из гексагонов (шестиугольников), каждый из которых принадлежит какому-то региону карты.
    В файлах игры карта представлена как n
 строк по m
 символов в каждой (строки и символы в них нумеруются с единицы). Каждый нечетный символ каждой четной строки и каждый
    четный символ каждой нечетной строки — точка (символ . с ASCII кодом 46
); все остальные символы соответствуют гексагонам и являются заглавными буквами
    латинского алфавита. Буква указывает на то, какому региону принадлежит гексагон.

Посмотрите на картинку ниже, чтобы понять, как описание карты в файлах игры соответствует карте из шестиугольников.

Соответствие описания карты в файле (слева) и самой карты (справа). Регионы R, G, V, Y и B окрашены в красный,
    зеленый, фиолетовый, желтый и синий цвет, соответственно.
Вы должны проверить, что каждый регион карты является одной связной областью. Иными словами,
не должно быть двух гексагонов, принадлежащих одному и тому же региону, которые не
соединены другими гексагонами этого же региона.

Карта слева является корректной. Карта справа не является корректной, так как гексагоны, обозначенные цифрами 1
 и 2
, принадлежат одному и тому же региону (обозначенному красным цветом), но не соединены другими гексагонами
    этого региона.
Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
В первой строке задано одно целое число t
 (1≤t≤100
) — количество наборов входных данных.

Первая строка набора входных данных содержит два целых числа n
 и m
 (2≤n, m≤20
) — количество строк и количество символов в каждой строке в описании карты.

Далее следуют n
 строк по m
 символов в каждой — описание карты. Каждый нечетный символ каждой четной строки и каждый 
    четный символ каждой нечетной строки — точка (символ . с ASCII кодом 46
); все остальные символы соответствуют гексагонам и являются заглавными буквами латинского алфавита.

Выходные данные
На каждый набор входных данных выведите ответ в отдельной строке — YES, если каждый
регион карты представляет связную область, или NO, если это не так.
*/

namespace ConsoleApp2
{
    class OzonMiddleContest8Practice
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
        int numOftests = int.Parse(Console.ReadLine());
        string[] answer = new string[numOftests];
        for (int test = 0; test < numOftests; test++)
        {
            string[] nXm = Console.ReadLine().Split(' ');
            int rows = int.Parse(nXm[0]);
            int columns = int.Parse(nXm[1]);
            string[] gameMap = new string[rows];

            Dictionary<char, (int, int)> parentMap = new Dictionary<char, (int, int)>(5);
            for (int i = 0; i < rows; i++)
            {
                gameMap[i] = Console.ReadLine().Replace(".", "");
                for (int j = 0; j < gameMap[i].Length; j++)
                    parentMap.TryAdd(gameMap[i][j], (i + 1, j + 1));
            }

            Dictionary<(int, int), char> weWereHere = new Dictionary<(int, int), char>(rows * (columns / 2 - 1));
            foreach (var parent in parentMap)
            {
                List<(int, int)> currentWaveFields = new List<(int, int)>();
                currentWaveFields.Add((parent.Value.Item1, parent.Value.Item2));
                while (currentWaveFields != null)
                {

                    for (int i = 0; i < currentWaveFields.Count; i++)
                        weWereHere.TryAdd((currentWaveFields[i].Item1, currentWaveFields[i].Item2), 'X');
                    currentWaveFields = Geksagon.FindNextLvl(currentWaveFields, weWereHere, parent.Key, ref gameMap);
                }
            }
            int numOfGeksagons = 0;
            for (int i = 0; i < gameMap.Length; i++)
                numOfGeksagons += gameMap[i].Length;
            if (numOfGeksagons == weWereHere.Count)
                answer[test] = "YES";
            else
                answer[test] = "NO";
        }
        for (int i = 0; i < numOftests; i++)
            Console.WriteLine(answer[i]);
    }

    public class Geksagon
    {
        public static List<(int, int)> FindNextLvl(List<(int, int)> currentList,
            Dictionary<(int, int), char> usedFields, char color, ref string[] map)
        {
            List<(int, int)> newList = new List<(int, int)>();

            for (int r = 0; r < currentList.Count; r++)
            {
                int i = currentList[r].Item1;
                int j = currentList[r].Item2;
                CheckLeftRight(i, j, ref newList, color, ref map, usedFields);
                CheckHightStr(i, j, ref newList, color, ref map, usedFields);
                CheckLowStr(i, j, ref newList, color, ref map, usedFields);
            }
            if (newList.Count == 0)
                return null;
            return newList;
        }

        private static void CheckLeftRight(int i, int j, ref List<(int, int)> newList, char color, ref string[] map,
            Dictionary<(int, int), char> usedFields)
        {
            int y = i;
            if (j - 1 > 0)
            {
                int x = j - 1;
                if (usedFields.ContainsKey((y, x)) == false && map[y - 1][x - 1] == color)
                    newList.Add((y, x));
            }
            if (j + 1 <= map[i - 1].Length)
            {
                int x = j + 1;
                if (map[y - 1][x - 1] == color && usedFields.ContainsKey((y, x)) == false)
                    newList.Add((y, x));
            }
        }

        private static void CheckHightStr(int i, int j, ref List<(int, int)> newList, char color, ref string[] map,
            Dictionary<(int, int), char> usedFields)
        {
            int y = i - 1;
            if (y < 1)
                return;
            if (i % 2 == 1)
            {
                int x = j - 1;
                if (x >= 1)
                {
                    if (map[y - 1][x - 1] == color && usedFields.ContainsKey((y, x)) == false)
                        newList.Add((y, x));
                }
                x = j;
                if (map[y - 1].Length >= x)
                {
                    if (map[y - 1][x - 1] == color && usedFields.ContainsKey((y, x)) == false)
                        newList.Add((y, x));
                }
            }
            else
            {
                int x = j;
                if (map[y - 1][x - 1] == color && usedFields.ContainsKey((y, x)) == false)
                    newList.Add((y, x));
                x = j + 1;
                if (x <= map[y - 1].Length)
                {
                    if (map[y - 1][x - 1] == color && usedFields.ContainsKey((y, x)) == false)
                        newList.Add((y, x));
                }
            }
        }

        private static void CheckLowStr(int i, int j, ref List<(int, int)> newList, char color, ref string[] map,
            Dictionary<(int, int), char> usedFields)
        {
            int y = i + 1;
            if (y > map.GetUpperBound(0) + 1)
                return;
            if (i % 2 == 1)
            {
                int x = j - 1;
                if (x > 0)
                {
                    if (map[y - 1][x - 1] == color && usedFields.ContainsKey((y, x)) == false)
                        newList.Add((y, x));
                }
                x = j;
                if (x <= map[y - 1].Length)
                {
                    if (map[y - 1][x - 1] == color && usedFields.ContainsKey((y, x)) == false)
                        newList.Add((y, x));
                }
            }
            else
            {
                int x = j;
                if (map[y - 1][x - 1] == color && usedFields.ContainsKey((y, x)) == false)
                    newList.Add((y, x));
                x = j + 1;
                if (x <= map[y - 1].Length)
                {
                    if (map[y - 1][x - 1] == color && usedFields.ContainsKey((y, x)) == false)
                        newList.Add((y, x));
                }
            }
        }
    }
}
*/