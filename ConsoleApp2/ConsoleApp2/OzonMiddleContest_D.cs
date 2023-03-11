using System;
using System.Collections.Generic;
using System.Text;


/*В соревновании по бегу приняли участие n
 спортсменов: i
- й из них пробежал дистанцию за ti
 секунд. Жюри хочет назначить места участникам по следующим правилам:

места пронумерованы от 1
 и далее (лучшее место — первое);
если у двух спортсменов результаты одинаковые или отличаются на одну секунду,
    то они делят место (в этом случае считаем, что они делят лучшее из поделенных мест);
участники делят место только в результате применения предыдущего правила (возможно, несколько раз);
если k
 участников делят место p
, то места следующих за ними участников нумеруются начиная с k+p
.
Рассмотрите следующие примеры, чтобы понять принцип назначения мест:

допустим, n = 4
 и t =[20, 10, 20, 30]
, тогда места имеют вид [2,1,2,4]
(второй спортсмен прибежал первым — у него первое место, первый и
    третий поделили второе место, четвёртый занял последнее четвёртое место);
допустим, n = 3
 и t =[5, 7, 6]
, тогда места имеют вид [1,1,1]
(так как t1 = 5
 и t3=6
 отличаются на 1
, то первый и третий спортсмены должны занять одинаковое место,
аналогично со вторым и третьим спортсменами, следовательно, все трое делят первое место);
допустим, n = 5
 и t =[6, 3, 4, 3, 1]
, тогда места имеют вид [5,2,2,2,1]
;
допустим, n = 5
 и t =[200, 10, 100, 11, 200]
, тогда места имеют вид [4,1,3,1,4]
.
По заданным значениям n
 и t1, t2,…, tn
 выведите последовательность мест, занятых спортсменами.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
В первой строке записано целое число t
 (1≤t≤1000
) — количество наборов входных данных в тесте.

Наборы входных данных в тесте независимы. Друг на друга они никак не влияют.

Первая строка каждого набора входных данных содержит целое число n
 (1≤n≤2⋅105
) — количество спортсменов.

Вторая строка набора содержит последовательность целых чисел t1, t2,…, tn
 (1≤ti≤109
), где ti
 — время в секундах, за которое i
-й спортсмен пробежал дистанцию.

Сумма значений n
 по всем наборам входных данных теста не превосходит 2⋅105
.

Выходные данные
Для каждого набора входных данных выведите n
 положительных чисел r1, r2,…, rn
, где ri
 — место i
-го спортсмена.

Пример
входные данные
6
4
20 10 20 30
3
5 7 6
5
6 3 4 3 1
5
200 10 100 11 200
1
1000000000
11
13 8 12 1 7 10 1 8 10 2 17
выходные данные
2 1 2 4 
1 1 1 
5 2 2 2 1 
4 1 3 1 4 
1 
9 4 9 1 4 7 1 4 7 1 11 */

namespace ConsoleApp2
{
    class OzonMiddleContest_D
    {
    }
}



/*using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
 
public class Program
{
    static void Main(string[] args)
    {
        int numOfTests = int.Parse(Console.ReadLine());
        string[] answer = new string[numOfTests];
        for (int i = 0; i < numOfTests; i++)
        {
            int numOfSportsman = int.Parse(Console.ReadLine());
            string[] strTime = Console.ReadLine().Split(' ');
            Sportsman[] sportsman = new Sportsman[numOfSportsman];
            for (int k = 0; k < numOfSportsman; k++)
                sportsman[k] = new Sportsman(k + 1, int.Parse(strTime[k]));
            var sortedSportsman = sportsman.OrderBy(x => x.time).ToArray();
            sortedSportsman[0].place = 1;
            for (int k = 1; k < numOfSportsman; k++)
            {
                var currentSportsman = sortedSportsman[k];
                var previousSportsman = sortedSportsman[k - 1];
                if (currentSportsman.time == previousSportsman.time || currentSportsman.time - 1
                        == previousSportsman.time)
                    currentSportsman.place = previousSportsman.place;
                else
                    currentSportsman.place = k + 1;
            }
            Array.Sort(sortedSportsman, new Sportsman());
            StringBuilder builder = new StringBuilder(numOfSportsman * 3);
            for (int k = 0; k < numOfSportsman; k++)
            {
                builder.Append(sortedSportsman[k].place);
                builder.Append(' ');
            }
            answer[i] = builder.ToString();
        }
        for (int i = 0; i < numOfTests; i++)
            Console.WriteLine(answer[i]);
    }
}

public class Sportsman : IComparer<Sportsman>
{
    public int id;

    public int time;

    public int place;

    public Sportsman() { }

    public Sportsman(int getId, int getTime)
    {
        this.id = getId;
        this.time = getTime;
    }

    public int Compare([AllowNull] Sportsman x, [AllowNull] Sportsman y)
    {
        if (x.id > y.id)
            return 1;
        else if (x.id < y.id)
            return -1;
        else
            return 0;
    }
}*/