using System;
using System.Collections.Generic;
using System.Text;

/*Вы разрабатываете программу автоматической генерации стихотворений. 
 * Один из модулей этой программы должен подбирать рифмы к словам из некоторого словаря.

Словарь содержит n
 различных слов. Словами будем называть последовательности из 1
—10
 строчных букв латинского алфавита.

Зарифмованность двух слов — это длина их наибольшего общего суффикса
(суффиксом будем называть какое-то количество букв в конце слова). Например:

task и flask имеют зарифмованность 3
 (наибольший общий суффикс — ask);
decide и code имеют зарифмованность 2
 (наибольший общий суффикс — de);
id и void имеют зарифмованность 2
 (наибольший общий суффикс — id);
code и forces имеют зарифмованность 0
.
Ваша программа должна обработать q
 запросов следующего вида: дано слово ti
 (возможно, принадлежащее словарю), необходимо найти слово из словаря, которое не совпадает с ti
 и имеет максимальную зарифмованность с ti
 среди всех слов словаря, не совпадающих с ti
. Если подходящих слов несколько — выведите любое из них.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
Первая строка содержит одно целое число n
 (2≤n≤50000
) — размер словаря.

Далее следуют n
 строк, i
-я строка содержит одну строку si
 (1≤|si|≤10
) — i
-е слово из словаря. В словаре все слова различны.

Следующая строка содержит одно целое число q
 (1≤q≤50000
) — количество запросов.

Далее следуют q
 строк, i
-я строка содержит одну строку ti
 (1≤|ti|≤10
) — i
-й запрос.

Каждая строка si
 и каждая строка ti
 состоит только из строчных букв латинского алфавита.

Выходные данные
Для каждого запроса выведите одну строку — слово из словаря, которое не совпадает с
заданным в запросе и имеет с ним максимальную зарифмованность (если таких несколько — выведите любое
*/
namespace ConsoleApp2
{
    class OzonMiddleContest9Practice
    {
        // NOT OPTIMAL SOLUTION
    }
}

/*
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
public class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        Dictionary<string, char> dict = new Dictionary<string, char>(size);
        for (int i = 0; i < size; i++)
            dict.Add(Console.ReadLine(), 'a');

        int requestsNum = int.Parse(Console.ReadLine());
        string[] answer = new string[requestsNum];
        

        for (int i = 0; i < requestsNum; i++)
        {
            string request = Console.ReadLine();
            int currentMax = -1;
            int lastSymbolIdx = request.Length - 1;
            Parallel.ForEach(dict, word =>
           {
               int requestPtr = lastSymbolIdx;
               int wordPtr = word.Key.Length - 1;
               if (request.Equals(word.Key) == false)
               {
                   int nowMax = 0;
                   while (requestPtr >= 0 && wordPtr >= 0 && request[requestPtr] == word.Key[wordPtr])
                   {
                       nowMax++;
                       requestPtr--;
                       wordPtr--;
                   }
                   if (nowMax > currentMax)
                   {
                       currentMax = nowMax;
                       answer[i] = word.Key;
                   }
               }
           });
        }
        for (int i = 0; i < requestsNum; i++)
            Console.WriteLine(answer[i]);
    }
}
*/






/*********************RESHENIE CHEREZ LISTI NO TAM EWE NADO MAP VMESTO MASSIVA LISTOV************************/


/*

using System;
using System.Collections.Generic;
using System.Text;
public class Program
{
    static void Main(string[] args)
    {
        int dictSize = int.Parse(Console.ReadLine());
        Node startNode = new Node('!');
        string getLine;
        for (int i = 0; i < dictSize; i++)
        {
            getLine = Console.ReadLine();
            var node = startNode;
            for (int j = 0; j < getLine.Length; j++)
            {
                char s = getLine[j];
                int nextNodeIdx = FindNode(node.nextNodes, s);
                if (nextNodeIdx == -2)
                {
                    node.nextNodes = new List<Node>();
                    Node nxt = new Node(s);
                    node.nextNodes.Add(nxt);
                    node = nxt;
                }
                else if (nextNodeIdx == -1)
                {
                    Node nxt = new Node(s);
                    node.nextNodes.Add(nxt);
                    node = nxt;
                }
                else
                    node = node.nextNodes[nextNodeIdx];
            }
        }
        //int requestsNum = int.Parse(Console.ReadLine());
        //string[] answer = new string[requestsNum];
        StringBuilder @string = new StringBuilder("");
        Console.WriteLine("Vvedite slovo mb kakoe?!");
        string word = Console.ReadLine();
        int k = 0;
        Node finder = startNode;
        int flag = 1;
        while (flag > 0 && k < word.Length - 1)
        {
            flag = -1;
            if (finder.nextNodes != null)
            {
                for (int i = 0; i < finder.nextNodes.Count; i++)
                    Console.WriteLine(finder.nextNodes[i].currentSymbol);
                Console.WriteLine("Next Waeer");
                for (int i = 0; i < finder.nextNodes.Count; i++)
                {
                    if (finder.nextNodes[i].currentSymbol == word[k])
                    {
                        @string.Append(word[k]);
                        k++;
                        flag = 1;
                        finder = finder.nextNodes[i];
                        break;
                    }
                }
            }
        }
        Console.WriteLine(@string.ToString());
    }

    public class Node
    {
        public char currentSymbol;

        public List<Node> nextNodes;

        public Node() { nextNodes = null; }

        public Node(char getSymbol)
        {
            this.currentSymbol = getSymbol;
            this.nextNodes = null;
        }
    }

    public static int FindNode(List<Node> nodes, char symbol)
    {
        if (nodes == null)
            return -2;
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].currentSymbol == symbol)
                return i;
        }
        return -1;
    }
}
*/

//Regex form1 = new Regex(@"^[A-Z, a-z]\d\d[A-Z, a-z][A-Z, a-z]$");
//Regex form2 = new Regex(@"^[A-Z, a-z]\d[A-Z, a-z][A-Z, a-z]$");