using System;
using System.Collections.Generic;
using System.Text;
/*
Представьте, вы собрали собственный сервер из n
 разнородных процессоров и теперь решили создать для него простейший планировщик задач.

Ваш сервер состоит из n
 процессоров. Но так как процессоры разные, то и достигают они 
 одинаковой скорости работы при разном энергопотреблении. А именно, i
-й процессор в нагрузке тратит ai
 энергии за одну секунду.

Вашему серверу в качестве тестовой нагрузки придет m
 задач. Про каждую задачу вам известны два значения: tj
 и lj
 — момент времени, когда задача j
 придет и время выполнения задачи в секундах.

Для начала вы решили реализовать простейший планировщик, ведущий себя следующим образом: в момент tj
 прихода задачи, вы выбираете свободный процессор с минимальным энергопотреблением
 и выполняете данную задачу на выбранном процессоре все заданное время.
 Если к моменту прихода задачи свободных процессоров нет, то вы просто отбрасываете задачу.

Процессор, на котором запущена задача j
 будет занят ровно lj
 секунд, то есть освободится ровно в момент tj+lj
 и в этот же момент уже может быть назначен для выполнения какой-то другой задачи.

Определите суммарное энергопотребление вашего сервера при обработке m
 заданных задач (будем считать, что процессоры в простое не потребляют энергию).

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
В первой строке заданы два целых числа n
 и m
 (1≤n, m≤3⋅105
) — количество процессоров и задач соответственно.

Во второй строке заданы n
 целых чисел a1, a2,…, an
 (1≤ai≤106
) — энергопотребление соответствующих процессоров под нагрузкой в секунду. Все энергопотребления различны.

В следующих m
 строках заданы описания задач: по одному в строке. В j
-й строке заданы два целых числа tj
 и lj
 (1≤tj≤109
; 1≤lj≤106
) — момент прихода j
-й задачи и время ее выполнения.

Все времена прихода tj
 различны, и задачи заданы в порядке времени прихода.

Выходные данные
Выведите единственное число — суммарное энергопотребление сервера, если потреблением энергии в простое можно пренебречь.
*/
namespace ConsoleApp2
{
    class OzonMiddleContest10Practice
    {
        // NOT OPTIMAL SOLUTION
    }
}

/*
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
public class Program
{
    static void Main(string[] args)
    {
        string[] nXm = Console.ReadLine().Split(' ');
        int procNum = int.Parse(nXm[0]);
        int tasksNum = int.Parse(nXm[1]);

        string[] energyConsumption = Console.ReadLine().Split(' ');
        ulong[] sortedProcConsumption = new ulong[energyConsumption.Length];
        for (int i = 0; i < procNum; i++)
            sortedProcConsumption[i] = Convert.ToUInt64(energyConsumption[i]);
        Array.Sort(sortedProcConsumption);
        Proc[] procArr = new Proc[procNum];
        for (int i = 0; i < sortedProcConsumption.Length; i++)
            procArr[i] = new Proc(sortedProcConsumption[i]);
        //init TasksLists
        List<Task> taskList = new List<Task>(tasksNum);
        for (int i = 0; i < tasksNum; i++)
        {
            string[] pair = Console.ReadLine().Split(' ');
            taskList.Add(new Task(Convert.ToUInt64(pair[0]), Convert.ToUInt64(pair[1])));
        }
        taskList.Sort(new Task());
        //Find all Tasks for evry Proc
        int k = 0;
        ulong sum = 0;
        while (k < procNum && taskList.Count > 0)
        {
            var proc = procArr[k];
            int idx = 0;
            while (-idx <= taskList.Count)
            {
                Task task = taskList[idx];
                sum += task.runTime * proc.energyPerSecond;
                ulong nextTime = task.startTime + task.runTime;
                taskList.RemoveAt(idx);
                idx = taskList.BinarySearch(new Task(nextTime));
                if (idx < 0 && -idx <= taskList.Count)
                    idx = -idx - 1;
            }
            k++;
        }
        Console.WriteLine(sum);
    }

    public class Proc
    {
        public ulong energyPerSecond;

        public Proc() { }

        public Proc(ulong getEnergy)
        {
            this.energyPerSecond = getEnergy;
        }
    }

    public class Task : IComparer<Task>, IComparable<Task>
    {
        public ulong startTime;
        public ulong runTime;

        public Task() { }
        public Task(ulong getStart) : this(getStart, 0) { }
        public Task(ulong getStart, ulong getRun)
        {
            this.startTime = getStart;
            this.runTime = getRun;
        }

        public int Compare([AllowNull] Task x, [AllowNull] Task y)
        {
            if (x.startTime > y.startTime)
                return 1;
            else if (x.startTime < y.startTime)
                return -1;
            else
                return 0;
        }

        public int CompareTo([AllowNull] Task other)
        {
            if (this.startTime > other.startTime)
                return 1;
            else if (this.startTime < other.startTime)
                return -1;
            else
                return 0;
        }
    }
}
*/