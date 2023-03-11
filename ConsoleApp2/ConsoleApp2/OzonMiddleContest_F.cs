using System;
using System.Collections.Generic;
using System.Text;

/*Необходимо напечатать документ из k
 страниц. Его страницы пронумерованы от 1
 до k
.

Некоторые его страницы были уже предварительно напечатаны. Известно, что на принтер было отослано одно задание, которое содержало список страниц для печати.

Этот список содержит хотя бы одну страницу, и хотя бы одна страница от 1
 до k
 не попадает в этот список. Список страниц состоит из перечисленных через единичную запятую элементов списка, где каждый элемент — это:

либо конкретный номер одной страницы (целое число от 1
 до k
),
либо диапазон страниц, записанный в формате «l
-r
», где l
 — начало диапазона печати, а r
 — конец диапазона печати (и l
 и r
 целые числа, удовлетворяющие неравенству 1≤l≤r≤k
).
Страница может многократно присутствовать в списке на печать, но будет напечатана лишь единожды.

Иными словами, список страниц имеет формат, аналогичный тому, что используется в «Microsoft Word» или других подобных программах.

Например, если k=8
, то допустимые списки страниц:

7(была напечатана лишь страница 7
),
1,7,1(были напечатаны страницы 1
 и 7
),
1 - 5,1,7 - 7(были напечатаны страницы 1, 2, 3, 4, 5, 7
  ).
Примеры неправильных диапазонов для k=8
 (такие входные данные недопустимы):

1 - 8(хотя бы одна страница документа должна быть еще не напечатана),
1,,3(две запятые не могут идти подряд),
7 - 9(девятую страницу нельзя послать на печать),
1 - 5, (каждая запятая должна разделять два элемента, заканчивать список она не может),
,1,2,3 - 5(каждая запятая должна разделять два элемента, начинать список она не может),
3 - 4 - 7(нарушен формат элемента, так нельзя).
Выведите кратчайший список страниц в аналогичном формате, который надо дополнительно послать
    на печать, чтобы в итоге напечатать все страницы от 1
 до k
, не напечатанные ранее.

Иными словами, найдите такую наиболее короткую строку, которая является корректным
списком страниц и содержит те и только те страницы, которые еще не были напечатаны.

Если ответов несколько, то выведите любой из них.

Входные данные
В первой строке входных данных записано целое число t
 (1≤t≤100
) — количество наборов входных данных.

Наборы входных данных в тесте независимы. Друг на друга они никак не влияют.

В первой строке каждого набора записано целое число k
 (2≤k≤100
) — количество страниц в документе.

Вторая строка каждого набора содержит список страниц, которые уже были посланы
на печать. Этот список корректен и отформатирован строго по правилам, написанным выше. Он содержит только страницы от 1
 до k
, содержит хотя бы одну страницу, и хотя бы одна страница от 1
 до k
 в него не входит. Строка не содержит пробелы или какие-либо другие дополнительные символы. Длина этой строки — от 1
 до 400
, включительно.

Выходные данные
Выведите t
 строк — для каждого набора входных данных выведите кратчайшую строку, содержащую корректный
 список страниц, которые надо допечатать и только их. Если оптимальных ответов несколько, то выведите любой из них.
Пример
входные данные
7
8
7
8
1,7,1
8
1-5,1,7-7
10
1-5
10
1,2,3,4,5,6,8,9,10
3
1-2
100
1-2,3-7,10-20,100

выходные данные
8,1-6
2-6,8
6,8
6-10
7
3
9,21-99,8
 */

namespace ConsoleApp2
{
    class OzonMiddleContest_F
    {
    }
}


/*using System;
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
            foreach (var str in pages)
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
            foreach (var pair in printedPages)
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
}*/