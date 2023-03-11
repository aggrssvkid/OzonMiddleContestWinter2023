using System;
using System.Collections.Generic;
using System.Text;
/*
Во многих социальных сетях у пользователей есть возможность указать других пользователей как своих друзей.
    Помимо этого, часто существует система рекомендации друзей, которая показывает пользователям людей,
    с которыми они знакомы косвенно (через кого-то из своих друзей), и предлагает добавить этих людей в
    список друзей. Вам предстоит разработать систему рекомендации друзей.

В интересующей нас социальной сети n
 пользователей, каждому из которых присвоен уникальный id от 1
 до n
. У каждого пользователя этой сети не более 5
 друзей. Очевидно, ни один пользователь не является другом самому себе, и если пользователь x
 в списке друзей у пользователя y
, то и пользователь y
 входит в список друзей пользователя x
.

Опишем, как должен формироваться список возможных друзей для каждого пользователя. Для пользователя x
 в список должны входить такие пользователи y
, что:

y
 не является другом x
 и не совпадает с x
;
у пользователя y
 и у пользователя x
 есть хотя бы один общий друг;
не существует такого пользователя y′
, который удовлетворяет первым двум ограничениям, и у которого строго больше общих друзей с x
, чем у y
 с x
.
Иными словами, в список возможных друзей пользователя x
 входят все такие пользователи, не являющиеся его друзьями, для которых количество общих друзей с x
 максимально. Обратите внимание, что список возможных друзей может быть пустым.

Вы должны написать программу, которая по заданной структуре социальной сети формирует
списки возможных друзей для всех пользователей сети.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
В первой строке заданы два целых числа n
 и m
 (2≤n≤50000
; 0≤m≤min(n(n−1)2, 5n2)
) — количество пользователей и количество пар друзей, соответственно.

Далее следуют m
 строк, в каждой из которых заданы два целых числа xi
 и yi
 (1≤xi, yi≤n
; xi≠yi
) — очередная пара друзей в социальной сети. Каждая пара друзей задается не более одного раза;
у каждого пользователя не более 5
 друзей.

Выходные данные
Для каждого пользователя от 1
 до n
 выведите в отдельной строке список его возможных друзей в следующем формате:

если список возможных друзей пуст, выведите одно целое число 0
;
иначе выведите id возможных друзей пользователя в возрастающем порядке.
*/

namespace ConsoleApp2
{
    class OzonMiddleContest7Practice
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
        string[] nXm = Console.ReadLine().Split(' ');

        int numOfPersons = int.Parse(nXm[0]);
        int numOfPairs = int.Parse(nXm[1]);
        Dictionary<int, Person> personMap = new Dictionary<int, Person>();
        for (int i = 1; i <= numOfPersons; i++)
            personMap.Add(i, new Person(i, new List<int>(5), new List<int>(3)));
        for (int i = 0; i < numOfPairs; i++)
        {
            string[] pair = Console.ReadLine().Split(' ');
            int first = int.Parse(pair[0]);
            int second = int.Parse(pair[1]);

            personMap[first].friends.Add(second);
            personMap[second].friends.Add(first);
        }
        for (int i = 1; i <= numOfPersons; i++)
        {
            var person = personMap[i]; // Current Person
            int maxFriends = 0;
            for (int k = 0; k < personMap[i].friends.Count; k++)
            {
                var personFriend = personMap[person.friends[k]]; // Current Friend of Current Person

                for (int p = 0; p < personFriend.friends.Count; p++)
                {
                    Person possibleFriend = personMap[personFriend.friends[p]];
                    if (possibleFriend.id != person.id && person.possibleFriends.Contains(possibleFriend.id) == false && person.friends.Contains(possibleFriend.id) == false)
                    {
                        int currentCrossOver = 0;
                        for (int curr = 0; curr < possibleFriend.friends.Count; curr++)
                        {
                            if (person.friends.Contains(possibleFriend.friends[curr]) == true)
                                currentCrossOver++;
                        }
                        if (currentCrossOver < maxFriends)
                            ;
                        else if (currentCrossOver == maxFriends)
                            person.possibleFriends.Add(possibleFriend.id);
                        else
                        {
                            maxFriends = currentCrossOver;
                            person.possibleFriends.Clear();
                            person.possibleFriends.Add(possibleFriend.id);
                        }
                    }
                }
            }
        }
        for (int i = 1; i <= numOfPersons; i++)
        {
            if (personMap[i].possibleFriends.Count == 0)
                Console.WriteLine(0);
            else
            {
                personMap[i].possibleFriends.Sort();
                for (int j = 0; j < personMap[i].possibleFriends.Count; j++)
                    Console.Write($"{personMap[i].possibleFriends[j]} ");
                if (i != numOfPersons)
                    Console.WriteLine("");
            }
        }
    }

    public class Person
    {
        public int id;

        public List<int> friends;

        public List<int> possibleFriends;

        public Person() { }

        public Person(int getId, List<int> getFriends, List<int> getPossible)
        {
            this.id = getId;
            this.friends = getFriends;
            this.possibleFriends = getPossible;
        }
    }
}

*/