using System;
using System.Collections.Generic;
using System.Text;

/*В Торгово-промышленную палату (ТПП) Берляндии были поданы n
 заявок на регистрацию товарных знаков. Каждая заявка — это непустая строка из букв латинского алфавита.

ТПП отклоняет очередную заявку, если ранее был зарегистрирован похожий товарный знак.
Если такого не было, то товарный знак регистрируется палатой.

Два товарных знака похожи, если их можно сделать равными с помощью нуля или более таких операций:

возьмём любой из двух знаков,
найдём в знаке две или более одинаковые идущие подряд буквы,
добавим в этот блок одинаковых букв ещё одну такую же букву.
Например:

товарные знаки Booble и Boooble похожи — берём в первом товарном знаке две подряд идущие буквы o
    и добавляем к ним ещё одну букву o, так получим второй товарный знак Boooble;
товарные знаки yyyess и yyessss похожи — сначала изменим второй товарный знак: yyessss →
 yyyessss, потом два раза изменим первый товарный знак: yyyess →
 yyyesss →
 yyyessss.Так с помощью последовательности операций получилось сделать оба знака равными yyyessss;
товарные знаки oooops и oooops похожи — операций производить не надо, знаки уже равны;
товарные знаки oooooopppss и ooooppssss похожи — например, сначала изменим второй товарный знак ooooppssss →
 oooooppssss →
 ooooooppssss →
 oooooopppssss, затем изменим первый: oooooopppss →
 oooooopppsss →
 oooooopppssss.
Обратите внимание, что добавлять букву можно только в блок идущих подряд двух или более одинаковых букв.
Строчные и прописные буквы следует различать.

Примеры пар непохожих товарных знаков: a и aa, MMM и mmm, yess и yyes.

Считая, что до обработки n
 заявок в ТПП не было зарегистрировано других товарных знаков, выведите количество знаков,
 которые будут в итоге зарегистрированы.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.
Входные данные
В первой строке входных данных записано целое число t
 (1≤t≤1000
) — количество наборов входных данных.

Наборы входных данных в тесте независимы. Друг на друга они никак не влияют.

В первой строке каждого набора записано целое число n
 (1≤n≤105
) — количество заявок. Далее следуют сами заявки, по одной заявке в строке.
Каждая заявка является непустой строкой из букв латинского алфавита.

Гарантируется, что сумма длин заявок по всем наборам входных данных теста не превосходит 106
.

Выходные данные
Выведите t
 чисел — для каждого набора входных данных выведите суммарное количество товарных знаков,
которые будут зарегистрированы палатой. Обратите внимание, что наборы входных данных
следует обрабатывать независимо (они не влияют друг на друга).

Пример
входные данные
3
8
Booble
yyyess
oooops
oooooopppss
Boooble
yyessss
oooops
ooooppssss
6
a
aa
MMM
mmm
yess
yyes
5
rrrrrrrr
rrrrrr
rrr
rr
r
выходные данные
4
6
2
 */

namespace ConsoleApp2
{
    class OzonMiddleContest_E
    {
        // NOT OPTIMAL SOLUTION
        // THINK ABOUT IT
        // MAYBE "MAP DATAS HOWEVER, IDK
    }
}


/*using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int numOfTests = int.Parse(Console.ReadLine());
        int[] answer = new int[numOfTests];
        for (int i = 0; i < numOfTests; i++)
        {
            int numOfNodes = int.Parse(Console.ReadLine());
            // Создаем связанный список всех товарных знаков. В виде связанного списка для того,
            // чтобы просто избавиться от всех элементов, которые являются "похожими" за один цикл
            // Странно, что это решение не является оптимальным. Неужели операция удаления настолько затратна?!
            LinkedList<string> brands = new LinkedList<string>();
            for (int n = 0; n < numOfNodes; n++)
                brands.AddLast(Console.ReadLine());
            int sum = 0;
            // Соответственно, пока в списке есть элементы, ищем набор похожих элементов 
            // и удаляем его из списка
            while (brands.Count > 0)
            {
                var start = brands.First;
                var finder = start.Next;
                while (finder != null)
                {
                    if (Same(start.Value, finder.Value))
                    {
                        var prvs = finder.Previous;
                        brands.Remove(finder);
                        finder = prvs;
                    }
                    finder = finder.Next;
                }
                brands.Remove(brands.First);
                sum++;
            }
            answer[i] = sum;
        }
        foreach (int res in answer)
            Console.WriteLine(res);
    }

    // Функция определения похожих элементов
    public static bool Same(string main, string current)
    {
        char symbol;
        int i = 0, j = 0;
        while (i != main.Length && j != current.Length)
        {
            if (main[i] != current[j])
                return false;
            symbol = main[i];
            int k = 0;
            int c = 0;
            while (i < main.Length && main[i] == symbol)
            {
                k++;
                i++;
            }
            while (j < current.Length && current[j] == symbol)
            {
                c++;
                j++;
            }
            if ((c == 1 && k > 1) || (k == 1 && c > 1))
                return false;
        }
        if (i != main.Length || j != current.Length)
            return false;
        return true;
    }
}*/
