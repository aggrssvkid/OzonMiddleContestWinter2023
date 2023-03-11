using System;
using System.Collections.Generic;
using System.Text;

/*
 * Директор IT-корпорации оценивает эффективность работы сотрудников по различным показателям и критериям. Один из этих критериев сформулирован следующим образом: приступив к некоторому заданию, сотрудник должен завершить его, не переключаясь на другие задания.

Чтобы проверить сотрудников на соответствие этому критерию, директор потребовал от каждого сотрудника отчет о том, какие задания он выполнял в последние n
 дней. Отчет — это последовательность из n
 целых чисел a1,a2,…,an
, где ai
 — идентификатор задания, которое сотрудник выполнял в i
-й день.

Вам необходимо написать программу, проверяющую, соответствует ли сотрудник критерию по его отчету. Сотрудник соответствует этому критерию, если не существует такого задания x
, которое выполнялось с перерывом (т. е. в некоторый день i
 сотрудник выполнял задание x
, в дни с i+1
 по j−1
 он занимался другими заданиями, а в день j
 сотрудник продолжил выполнение задания x
, при этом j>i+1
). Иными словами, каждое задание, которое выполнял сотрудник, должно занимать один непрерывный отрезок дней.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.
*/

namespace ConsoleApp2
{
    class OzonMiddleContest5Practice
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
        int numOfTests = int.Parse(Console.ReadLine());
        string[] allRight = new string[numOfTests];
        for (int test = 0; test < numOfTests; test++)
        {
            int nDays = int.Parse(Console.ReadLine());

            string[] getTasks = Console.ReadLine().Split(' ');

            int[] tasks = new int[nDays];
            for (int i = 0; i < nDays; i++)
                tasks[i] = int.Parse(getTasks[i]);
            Dictionary<int, int> tasksMap = new Dictionary<int, int>();
            for (int i = 0; i < nDays; i++)
            {
                if (tasksMap.TryAdd(tasks[i], 1) == false)
                {
                    allRight[test] = "NO";
                    break;
                }
                int currentTask = tasks[i];
                while (i < nDays - 1 && tasks[i + 1] == currentTask)
                    i++;
            }
            if (allRight[test] == null)
                allRight[test] = "YES";
        }
        for (int i = 0; i < numOfTests; i++)
            Console.WriteLine(allRight[i]);
    }
}

*/
