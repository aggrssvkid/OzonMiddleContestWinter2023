using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        int numOfTests = int.Parse(Console.ReadLine());
        string[] answer = new string[numOfTests];

        for (int i = 0; i < numOfTests; i++)
        {
            int k = int.Parse(Console.ReadLine());
            string inputStr = Console.ReadLine();
            // dalee reshenie
            string[] pages = inputStr.Split(',');

            // Создаем мапу, отсортированную по ключу. Добавляем туда все различные представленные диапазоны
            // Если диапазоны по ключу совпадают, то оставляем наибольший
            SortedDictionary<int, int> printedPages = new SortedDictionary<int, int>();
            foreach(var str in pages)
            {
                int key;
                int value;
                if (str.Contains('-') == false)
                {
                    key = int.Parse(str);
                    value = key;
                }
                else
                {
                    string[] diapazon = str.Split('-');
                    key = int.Parse(diapazon[0]);
                    value = int.Parse(diapazon[1]);
                }
                if (printedPages.TryAdd(key, value) == false)
                {
                    if (printedPages[key] < value)
                        printedPages[key] = value;
                }
            }
            // Устраняем возможные пересечения, так чтобы все числа шли в порядке возрастания
            // И не было пересечения диапазонов
            int prevKey = 0;
            int prevValue = 0;
            SortedDictionary<int, int> noAcross = new SortedDictionary<int, int>();
            foreach(var pair in printedPages)
            {
                if (pair.Key > prevValue)
                {
                    noAcross.Add(pair.Key, pair.Value);
                    prevKey = pair.Key;
                    prevValue = pair.Value;
                }
                else if (pair.Key <= prevValue && pair.Value <= prevValue)
                    ;
                else if (pair.Key <= prevValue && pair.Value > prevValue)
                {
                    noAcross[prevKey] = pair.Value;
                    prevValue = pair.Value;
                }
            }
            // Диапазоны значений, которых нет в нашем получившемся словаре и будут
            // "Потерянными страницами"
            SortedDictionary<int, int> lostPages = new SortedDictionary<int, int>();
            int pagesChecker = 1;
            foreach (var pair in noAcross)
            {
                if (pagesChecker >= pair.Key && pagesChecker <= pair.Value)
                    pagesChecker = pair.Value + 1;
                else
                {
                    lostPages.Add(pagesChecker, pair.Key - 1);
                    pagesChecker = pair.Value + 1;
                }
            }
            if (pagesChecker != k + 1)
                lostPages.TryAdd(pagesChecker, k);
            // Сохраняем все диапазоны потерянных страниц в виде строки
            StringBuilder @string = new StringBuilder(50);
            foreach (var pair in lostPages)
            {
                if (pair.Key == pair.Value)
                    @string.Append($"{pair.Key},");
                else
                    @string.Append($"{pair.Key}-{pair.Value},");
            }
            @string.Remove(@string.Length - 1, 1);
            answer[i] = @string.ToString();
        }
        foreach (var str in answer)
            Console.WriteLine(str);
    }
}
