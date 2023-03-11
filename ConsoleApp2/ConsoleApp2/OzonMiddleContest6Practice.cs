using System;
using System.Collections.Generic;
using System.Text;
/*
Вам задан набор отрезков времени. Каждый отрезок задан в формате HH:MM: SS - 
    HH:MM: SS, то есть сначала заданы часы, минуты и секунды левой границы отрезка, а затем часы,
    минуты и секунды правой границы.

Вам необходимо выполнить валидацию заданного набора отрезков времени. Иными словами, 
вам нужно проверить следующие условия:

часы, минуты и секунды заданы корректно (то есть часы находятся в промежутке от 0
 до 23
, а минуты и секунды — в промежутке от 0
 до 59
);
левая граница отрезка находится не позже его правой границы (но границы могут быть равны);
никакая пара отрезков не пересекается (даже в граничных моментах времени).
Вам необходимо вывести YES, если заданный набор отрезков времени проходит валидацию, и NO в противном случае.

Вам необходимо ответить на t
 независимых наборов тестовых данных.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
Первая строка входных данных содержит одно целое число t
 (1≤t≤10
) — количество наборов тестовых данных. Затем следуют t
 наборов.

Первая строка набора содержит одно целое число n
 (1≤n≤2⋅104
) — количество отрезков времени. В следующих n
 строках следуют описания отрезков.

Описание отрезка времени задано в формате HH:MM: SS - HH:MM: SS, где HH, MM и SS — 
    последовательности из двух цифр. Заметьте,
    что никаких пробелов в описании формата нет. Также ни в одном описании нет пробелов в начале и конце строки.

Выходные данные
Для каждого набора тестовых данных выведите ответ — YES, если заданный набор отрезков времени проходит валидацию,
и NO в противном случае. Ответы выводите в порядке следования наборов во входных данных.
*/

namespace ConsoleApp2
{
    class OzonMiddleContest6Practice
    {
    }
}

/*
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
    static void Main(string[] args)
    {
        int numOfTests = int.Parse(Console.ReadLine());
        string[] answer = new string[numOfTests];
        Regex regex = new Regex(@"^\d\d[:]\d\d[:]\d\d[-]\d\d[:]\d\d[:]\d\d$");

        for (int test = 0; test < numOfTests; test++)
        {
            int numOfTimes = int.Parse(Console.ReadLine());
            string[] timesCollection = new string[numOfTimes];
            for (int i = 0; i < numOfTimes; i++)
                timesCollection[i] = Console.ReadLine();

            for (int i = 0; i < numOfTimes; i++)
            {

                // Proverka na bazoviy format vremeni
                if (regex.IsMatch(timesCollection[i]) == false)
                {
                    answer[test] = "NO";
                    break;
                }
                // Proveryaem chasi minuti i sekundi na correctnost
                bool right = true;
                for (int idx = 0; idx < timesCollection[i].Length; idx += 3)
                {
                    if (idx == 0 || idx == 9)
                        right = Checker.IsHoursCorrect(timesCollection[i].Substring(idx, 2));
                    else
                        right = Checker.IsMinSecCorrect(timesCollection[i].Substring(idx, 2));
                    if (!right)
                    {
                        answer[test] = "NO";
                        break;
                    }
                }
                if (answer[test] != null)
                    break;

                //Proverka na korrectnost odnogo intervala vremeni
                right = Checker.RightInterval(timesCollection[i].Substring(0, 8), timesCollection[i].Substring(9));
                if (right == false)
                {
                    answer[test] = "NO";
                    break;
                }
            }
            //Console.WriteLine("Proverka correctnosti vvoda dannih proshla uspeshno!");
            //Checkaem na peresecheniya intervali
            for (int i = 0; i < numOfTimes - 1; i++)
            {
                if (answer[test] != null)
                    break;
                for (int k = i + 1; k < numOfTimes; k++)
                {
                    if (Checker.CheckIntervalsIntersection(timesCollection[i], timesCollection[k]) == false)
                    {
                        answer[test] = "NO";
                        break;
                    }
                }
            }


            //right = Checker.IsEqualTimes
            if (answer[test] == null)
                answer[test] = "YES";
        }
        for (int i = 0; i < numOfTests; i++)
            Console.WriteLine(answer[i]);
    }

    class Checker
    {
        public static bool IsHoursCorrect(string hour)
        {
            //Console.WriteLine($"Check Hours: {hour}");
            if (hour[0] > '2')
                return false;
            else if (hour[0] == '2' && hour[1] > '3')
                return false;
            return true;
        }

        public static bool IsMinSecCorrect(string minSec)
        {
            //Console.WriteLine($"Check MinSec: {minSec}");
            if (minSec[0] > '5')
                return false;
            return true;
        }

        public static bool RightInterval(string leftTime, string rightTime)
        {
            int h = 0;

            //Console.WriteLine($"Compare: {leftTime} and {rightTime}");
            if (Convert.ToInt32(leftTime.Substring(h, 2)) > Convert.ToInt32(rightTime.Substring(h, 2)))
                return false;
            int m = h + 3;
            if (Convert.ToInt32(leftTime.Substring(h, 2)) == Convert.ToInt32(rightTime.Substring(h, 2))
                && Convert.ToInt32(leftTime.Substring(m, 2)) > Convert.ToInt32(rightTime.Substring(m, 2)))
                return false;
            int sec = h + 6;
            if (Convert.ToInt32(leftTime.Substring(h, 2)) == Convert.ToInt32(rightTime.Substring(h, 2))
                && Convert.ToInt32(leftTime.Substring(m, 2)) == Convert.ToInt32(rightTime.Substring(m, 2))
                && Convert.ToInt32(leftTime.Substring(sec, 2)) > Convert.ToInt32(rightTime.Substring(sec, 2)))
                return false;
            return true;
        }

        public static int CompareTime(string time1, string time2)
        {
            // mozhno ispolzovat tolko 2 peremennie i v nih perezapisivat dannie, no dlya udobstva
            // dlya chasov, minut i secund sozdadim svoi peremennie
            int hour1 = Convert.ToInt32(time1.Substring(0, 2));
            int hour2 = Convert.ToInt32(time2.Substring(0, 2));

            if (hour1 > hour2)
                return 1;
            else if (hour1 < hour2)
                return -1;
            else
            {
                int min1 = Convert.ToInt32(time1.Substring(3, 2));
                int min2 = Convert.ToInt32(time2.Substring(3, 2));

                if (min1 > min2)
                    return 1;
                else if (min1 < min2)
                    return -1;
                else
                {
                    int sec1 = Convert.ToInt32(time1.Substring(6, 2));
                    int sec2 = Convert.ToInt32(time2.Substring(6, 2));

                    if (sec1 > sec2)
                        return 1;
                    else if (sec1 < sec2)
                        return -1;
                    else
                        return 0;
                }
            }
        }

        public static bool CheckIntervalsIntersection(string currentTime, string nextTime)
        {
            string[] currentPair = currentTime.Split('-');
            string[] nextPair = nextTime.Split('-');

            string t1Low;
            string t1Hight;
            string t2Low;
            string t2Hight;
            int result;

            //Console.WriteLine($"current:{currentPair[0]}; next:{nextPair[0]}");
            result = CompareTime(currentPair[0], nextPair[0]);
            if (result == 0)
                return false;

            //init
            //Console.WriteLine(result);
            if (result == -1)
            {
                t1Low = currentPair[0];
                t1Hight = currentPair[1];
                t2Low = nextPair[0];
                t2Hight = nextPair[1];
            }
            else
            {
                t2Low = currentPair[0];
                t2Hight = currentPair[1];
                t1Low = nextPair[0];
                t1Hight = nextPair[1];
            }
            //Console.WriteLine($"t1Low:{t1Low}; t1Hight:{t1Hight}; t2Low:{t2Low}; t2Hight:{t2Hight}");
            //Go compare
            if (CompareTime(t1Hight, t2Low) == 1 || CompareTime(t1Hight, t2Low) == 0)
                return false;
            return true;
        }
    }
}
*/
