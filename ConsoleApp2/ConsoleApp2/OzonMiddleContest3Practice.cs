using System;
using System.Collections.Generic;
using System.Text;
/*
В компании работает n
 разработчиков, где n
 — четное число. Сумасшедший менеджер решил разбить всех разработчиков на команды по два человека.

Для этого он составил список всех разработчиков и назначил каждому из них номер по списку (от 1
 до n
) и значение ai
 — уровень мастерства i
-го в списке разработчика.

Очередную команду он составляет следующим образом:

первый разработчик в команде тот, кто идет первым в списке;
ему в пару подбирается такой, что разница их уровней минимальна (то есть минимально значение |ai−aj|
, где |x|
 — это модуль числа x
); если таких кандидатов несколько, то выбирается из них тот, кто находится раньше в списке;
эти два разработчика образуют команду и удаляются из списка.
Например, если массив a
 равен [2,1,3,1,1,4]
, то формирование команд будет происходить следующим образом:

назначим разработчикам номера [1,2,3,4,5,6]
в соответствии с их положением в списке, первый среди них имеет номер 1
, его уровень мастерства a1=2
, подходящими (с минимальной абсолютной разностью) являются разработчики с номерами 2,3,4,5
, первый среди них 2
, таким образом первая команда — это разработчики с номерами 1
 и 2
;
оставшиеся разработчики теперь имеют номера [3,4,5,6]
, первый среди них 3
, его уровень a3=3
, разработчик с минимальной абсолютной разностью только один (номер 6
), таким образом команда — разработчики с номерами 3
 и 6
;
оставшиеся разработчики имеют номера [4,5]
, первый среди них 4
, его уровень a4=1
, остался только разработчик с номером 5
, таким образом третья команда — разработчики с номерами 4
 и 5
.
Ваша задача — помочь сумасшедшему менеджеру промоделировать процесс разбиения на команды. Обратите внимание, что команды должны быть выведены в порядке, описанном выше в условии.

Входные данные
Первая строка содержит одно целое число t
 (1≤t≤50
) — количество наборов входных данных.

Первая строка каждого набора содержит одно целое число n
 (2≤n≤50
; n
 четное) — количество разработчиков.

Вторая строка содержит n
 целых чисел a1, a2,…, an
 (1≤ai≤100
), где ai
 — уровень мастерства i
-го разработчика.

Выходные данные
Для каждого набора входных данных выведите n2
 строк, i
-я строка должна содержать пару чисел — номер первого и второго разработчика в i
-й команде в порядке, описанном в условии.

Выводите пустую строку между выводами для наборов входных данных.
*/
namespace ConsoleApp2
{
    class OzonMiddleContest3Practice
    {
    }
}
        /*
        using System;
        using System.Collections.Generic;
        using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int numOfTests = int.Parse(Console.ReadLine()); // Poluchaem kol-vo vvodov dannih
        List<int[]> arraysOfPairs = new List<int[]>(numOfTests); // sozdaem massiv vivoda dannih v vide listov s massivami
        int currentList = 0;
        while (numOfTests > 0)
        {
            int developersNum = int.Parse(Console.ReadLine());
            arraysOfPairs.Add(new int[developersNum]);
            string[] strLvl = Console.ReadLine().Split(' ');

            int[] lvl = new int[strLvl.Length]; // otsortirovanniy nabor chisel po vozrastaniyu
            int[] baseLvl = new int[strLvl.Length]; // startoviy nabor chisel (masterstva)
            int[] sortedIdx = new int[strLvl.Length]; // massiv s otsortirovanimi indexami po masterstvu
            int[] baseDevIdx = new int[strLvl.Length]; // nabor indexov po poryadku

            for (int i = 0; i < strLvl.Length; i++)
            {
                lvl[i] = Convert.ToInt32(strLvl[i]);
                baseLvl[i] = lvl[i];
                sortedIdx[i] = i + 1;
                baseDevIdx[i] = i + 1;
            }

            Sort.QuickSort(ref lvl, ref sortedIdx, 0, lvl.Length - 1);
            List<int> baseDevIdxL = new List<int>(baseDevIdx);
            // Dalee sortiruem po indexam ravnie chisla (Navernyaka eto mozhno sdelat v QSort odnovremenno)
            for (int i = 0; i < sortedIdx.Length - 1; i++)
            {
                if (baseLvl[sortedIdx[i] - 1] == baseLvl[sortedIdx[i + 1] - 1])
                {
                    int start = i;
                    while (i != sortedIdx.Length - 1 && baseLvl[sortedIdx[i] - 1] == baseLvl[sortedIdx[i + 1] - 1])
                        i++;
                    Array.Sort(sortedIdx, start, i - start + 1);
                }
            }
            
            List<int> sortedIdxL = sortedIdx.ToList();
            int mainIdx;
            int pairIdx;
            int j = 0;
            // nahodim paru chisel
            while (baseDevIdxL.Any() == true)
            {
                mainIdx = sortedIdxL.IndexOf(baseDevIdxL[0]);
                if (mainIdx == sortedIdxL.Count - 1)
                {
                    pairIdx = mainIdx - 1;
                    while (pairIdx != 0 && baseLvl[sortedIdxL[pairIdx] - 1] == baseLvl[sortedIdxL[pairIdx - 1] - 1])
                        pairIdx--;
                }
                else if (mainIdx == 0)
                    pairIdx = mainIdx + 1;
                else
                {
                    if ((baseLvl[sortedIdxL[mainIdx] - 1] - baseLvl[sortedIdxL[mainIdx - 1] - 1]) > (baseLvl[sortedIdxL[mainIdx + 1] - 1] - baseLvl[sortedIdxL[mainIdx] - 1]))
                        pairIdx = mainIdx + 1;
                    else if ((baseLvl[sortedIdxL[mainIdx] - 1] - baseLvl[sortedIdxL[mainIdx - 1] - 1]) < (baseLvl[sortedIdxL[mainIdx + 1] - 1] - baseLvl[sortedIdxL[mainIdx] - 1]))
                    {
                        pairIdx = mainIdx - 1;
                        while (pairIdx != 0 && baseLvl[sortedIdxL[pairIdx] - 1] == baseLvl[sortedIdxL[pairIdx - 1] - 1])
                            pairIdx--;
                    }
                    else
                    {
                        pairIdx = mainIdx - 1;
                        while (pairIdx != 0 && baseLvl[sortedIdxL[pairIdx] - 1] == baseLvl[sortedIdxL[pairIdx - 1] - 1])
                            pairIdx--;
                        if (sortedIdxL[pairIdx] > sortedIdxL[mainIdx + 1])
                            pairIdx = mainIdx + 1;
                    }
                }
                arraysOfPairs[currentList][j] = sortedIdxL[mainIdx];
                arraysOfPairs[currentList][j + 1] = sortedIdxL[pairIdx];
                j = j + 2;
                int main = baseDevIdxL[0];
                int pair = sortedIdxL[pairIdx];
                baseDevIdxL.Remove(main);
                baseDevIdxL.Remove(pair);
                sortedIdxL.Remove(main);
                sortedIdxL.Remove(pair);
            }
            numOfTests--;
            currentList++;
        }
        int last = arraysOfPairs.Count - 1;
        for (int i = 0; i < arraysOfPairs.Count; i++)
        {
            for (int j = 0; j < arraysOfPairs[i].Length - 1; j += 2)
                Console.WriteLine($"{arraysOfPairs[i][j]} {arraysOfPairs[i][j + 1]}");
            if (i != last)
                Console.WriteLine("");
        }
    }

    class Sort
    {
        public static void QuickSort(ref int[] arr, ref int[] indexArr, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
                return;

            int pivotIndex = getPivotAndSort(ref arr, ref indexArr, leftIndex, rightIndex);

            QuickSort(ref arr, ref indexArr, leftIndex, pivotIndex - 1);

            QuickSort(ref arr, ref indexArr, pivotIndex + 1, rightIndex);
        }

        private static int getPivotAndSort(ref int[] arr, ref int[] indexArr, int left, int right)
        {
            int pivot = (left + right) / 2;

            while (left != pivot || right != pivot)
            {
                while (arr[left] < arr[pivot])
                    left++;
                while (arr[right] > arr[pivot])
                    right--;
                if (left != pivot)
                {
                    if (right != pivot)
                    {
                        swap(ref arr, ref indexArr, left, right);
                        left++;
                        right--;
                    }
                    else
                    {
                        swap(ref arr, ref indexArr, left, right);
                        pivot = left;
                        right--;
                    }
                }
                else if (right != pivot)
                {
                    swap(ref arr, ref indexArr, left, right);
                    pivot = right;
                    left++;
                }
            }
            return pivot;
        }

        private static void swap(ref int[] arr, ref int[]indexArr, int left, int right)
        {
            var tmp = arr[left];
            arr[left] = arr[right];
            arr[right] = tmp;
            tmp = indexArr[left];
            indexArr[left] = indexArr[right];
            indexArr[right] = tmp;
        }
    }
}
    }*/

