﻿using System;
using System.Collections.Generic;
using System.Text;


/*В магазине акция: «купи три одинаковых товара и заплати только за два». Конечно, каждый купленный товар может участвовать лишь в одной акции. Акцию можно использовать многократно.

Например, если будут куплены 7
 товаров одного вида по цене 2
 за штуку и 5
 товаров другого вида по цене 3
 за штуку, то вместо 7⋅2+5⋅3
 надо будет оплатить 5⋅2+4⋅3=22
.

Считая, что одинаковые цены имеют только одинаковые товары, найдите сумму к оплате.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
В первой строке записано целое число t
 (1≤t≤104
) — количество наборов входных данных.

Далее записаны наборы входных данных. Каждый начинается строкой, которая содержит n
 (1≤n≤2⋅105
) — количество купленных товаров. Следующая строка содержит их цены p1, p2,…, pn
 (1≤pi≤104
). Если цены двух товаров одинаковые, то надо считать, что это один и тот товар.

Гарантируется, что сумма значений n
 по всем тестам не превосходит 2⋅105
.

Выходные данные
Выведите t
 целых чисел — суммы к оплате для каждого из наборов входных данных.*/
namespace ConsoleApp2
{
    class OzonMiddleContest2Practice
    {
        /*        string str = Console.ReadLine();
                int numOfTests = int.Parse(str);
                int[] costs = new int[numOfTests];
                for (int k = 0; k<numOfTests; k++)
                {
                    int goodsQty = int.Parse(Console.ReadLine());
                string strPrice = Console.ReadLine();
                string[] strArrPrice = strPrice.Split(' ');
                int[] goodsPrice = new int[strArrPrice.Length];
                    for (int i = 0; i<strArrPrice.Length; i++)
                        goodsPrice[i] = Convert.ToInt32(strArrPrice[i]);
                    Dictionary<int, int> goodQty = new Dictionary<int, int>();
                    for (int i = 0; i<goodsPrice.Length; i++)
                    {
                        if (goodQty.TryAdd(goodsPrice[i], 1) == false)
                            goodQty[goodsPrice[i]]++;
                    }
                    int sum = 0;
                    foreach(var good in goodQty)
                    {
                        int totalCost = good.Key * good.Value;
                        int sale = (good.Value / 3) * good.Key;
                        sum += (totalCost - sale);
                    }
                    costs[k] = sum;
                }
                for (int i = 0; i < costs.Length; i++)
                Console.WriteLine(costs[i]);
            */
    }

}
