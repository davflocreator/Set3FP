using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Set3
{
    class Program
    {
        static void P1()
        {
            Console.WriteLine($"Suma numerelor din vector este {array.Sum()}");
        }
        static void P2()
        {
            Console.Write("Dati k:");
            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == k)
                {
                    Console.WriteLine($"Prima pozitie pe care apare {k} in vector este {i}");
                    return;
                }
            }
            Console.WriteLine($"{k} nu apare in secventa: {String.Join(" ", array)}");
        }
        static void P3()
        {
            Console.WriteLine($"Pozitia minimului este {Array.IndexOf(array, array.Min())}, pozitia maximului este {Array.IndexOf(array, array.Max())}");
        }
        static void P4()
        {
            int minVal = int.MaxValue, maxVal = int.MinValue, cntMin = 0, cntMax = 0;
            foreach (var el in array)
            {
                if (el > maxVal)
                {
                    maxVal = el;
                    cntMax = 1;
                }
                else if (el == maxVal) cntMax++;
                if (el < minVal)
                {
                    minVal = el;
                    cntMin = 1;
                }
                else if (el == minVal) cntMin++;
            }
            Console.WriteLine($"Minimul din vector e {minVal} si apare de {cntMin} ori\nMaximul este {maxVal} si apare de {cntMax} ori");
        }
        static void P5()
        { 
            Console.Write($"Dati valoarea e pe care doriti sa o inserati si pozitia k unde doriti sa o inserati(0<=k<={list.Count - 1}): ");
            var inputs = Console.ReadLine().Split(' ');
            int e = int.Parse(inputs[0]);
            int k = int.Parse(inputs[1]);

            list.Add(list.Last()); /
            for (int i = list.Count - 1; i > k; i--)
                list[i] = list[i - 1];
            list[k] = e;//insereaza elementul e pe pozitia k
            Console.WriteLine($"Vectorul dupa inserare: {String.Join(" ", list)}");
        }
        static void P6()
        {
            Console.Write($"Dati pozitia k din vector de unde vreti sa stergeti un element(0<=k<={list.Count - 1}): ");
            int k = int.Parse(Console.ReadLine());


            list.RemoveAt(k);
            Console.WriteLine($"Lista dupa eliminarea elementului de pe poz k: {String.Join(" ", list)}");
        }
        static void P7()
        {
            list.Reverse();
            Console.WriteLine($"Lista inversata: {String.Join(" ", list)}");
        }
        static void P8()
        {
            Console.WriteLine(instructions[8]);
            var list = ReadArray().ToList();
            RotateToLeft(list, 1);
            Console.WriteLine($"Lista inversata: {String.Join(" ", list)}");
        }

        static void RotateToLeft(List<int> list, int number)
        {
            for (int i = 0; i < number; i++)
            {
                list.Add(list[0]);
                list.RemoveAt(0);
            }
        }
        static void P9()
        {
            Console.WriteLine(instructions[9]);
            var list = ReadArray().ToList();
            Console.Write($"Dati k (nr de rotiri la stanga asupra listei)");
            int k = int.Parse(Console.ReadLine());

            RotateToLeft(list, k);
            Console.WriteLine($"Lista inversata: {String.Join(" ", list)}");
        }
        static void P10()
        {
            Console.WriteLine(instructions[10]);
            var array = ReadArray();
            Console.Write($"Dati k (elementul caruia vreti sa-i aflati pozitia din vector)");
            int k = int.Parse(Console.ReadLine());

            Array.Sort(array);
            int poz = BinarySearch(array, k, 0, array.Length - 1);

            if (poz != -1)
                Console.WriteLine($"{k} se gaseste la pozitia {poz} in vectorul {String.Join(" ", array)}");
            else
                Console.WriteLine($"{k} nu se gaseste in vectorul {String.Join(" ", array)}");
        }

        static int BinarySearch(int[] v, int x, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                if (v[mid] == x)
                    return mid;
                else if (v[mid] > x) return BinarySearch(v, x, 0, mid - 1);
                return BinarySearch(v, x, mid + 1, right);
            }
            else
                return -1;
        }
        static void P11()
        {
            Console.WriteLine(instructions[11]);
            Console.Write("Dati n:");
            int n = int.Parse(Console.ReadLine());
            bool[] ciur = new bool[n + 1];


            ciur[0] = ciur[1] = true;
            for (int i = 2; i * i <= n; i++)
            {
                if (!ciur[i])
                    for (int j = 2; j <= n / i; j++)
                        ciur[i * j] = true;
            }

            int counter = 0;
            for (int i = 2; i <= n; i++)
                if (!ciur[i])
                    counter++;

            Console.WriteLine($"Sunt {counter} numere prime mai mici decat numarul {n}");

        }
        static void P12()
        {
            Console.WriteLine(instructions[12]);
            var array = ReadArray();
            SelectionSort(array);
            Console.WriteLine($"Vectorul dupa sortare: {String.Join(" ", array)}");
        }

        private static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j] < array[minIndex])
                        minIndex = j;
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
            }
        }
        static void P13()
        {
            Console.WriteLine(instructions[13]);
            var array = ReadArray();
            InsertionSort(array);
            Console.WriteLine($"Vectorul dupa sortare: {String.Join(" ", array)}");
        }

        private static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int pos = i;
                int value = array[i];
                while (i > 0 && value < array[i - 1])
                    i--;
                (array[i], array[pos]) = (array[pos], array[i]);
            }
        }
        static void P14()
        {
            Console.WriteLine(instructions[14]);
            var array = ReadArray();
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                while (array[left] != 0)
                    left++;
                while (array[right] == 0)
                    right--;
                (array[left], array[right]) = (array[right], array[left]);
                left++;
                right--;
            }
            Console.WriteLine($"Vectorul dupa interschimbarea ceruta: {String.Join(" ", array)}");
        }
        static void P15()
        {
            Console.WriteLine(instructions[15]);
            var list = ReadArray().ToList();

            for (int i = 0; i < list.Count - 2; i++)
                for (int j = i + 1; j < list.Count - 1; j++)
                    if (list[i] == list[j])
                        list.RemoveAt(j);

            Console.WriteLine($"Vectorul dupa stergerea dublurilor: {String.Join(" ", list)}");
        }
        static void P16()
        {
            Console.WriteLine(instructions[16]);
            var array = ReadArray();

            int cmmdc = array[0];
            for (int i = 1; i < array.Length; i++)
                cmmdc = GCD(cmmdc, array[i]);

            Console.WriteLine($"{cmmdc} este cmmdc al vectorului {String.Join(" ", array)}");
        }
        private static int GCD(int a, int b)
        {
            while (b > 0)
            {
                a = b;
                b = a % b;
            }
            return a;
        }
        static void P17()
        {
            Console.WriteLine(instructions[17]);
            Console.Write("Dati n si b separate printr-un spatiu: ");
            var line = Console.ReadLine().Split(' ');
            int n = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            if (1 < b && b < 37)
            {
                string sol = Base10ToBaseB(b, n);
                Console.WriteLine($"{n} in baza 10 este {sol} in baza {b}");
            }
            else
                Console.WriteLine($"Nu se poate converti {n} in baza {b}");
        }
        private static string Base10ToBaseB(int b, int input)
        {
            char[] cifre = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string sol = "";
            Stack<char> stack = new Stack<char>();
            while (input > 0)
            {
                stack.Push(cifre[input % b]);
                input /= b;
            }
            foreach (char c in stack)
                sol += c;
            return sol;
        }
        static void P18()
        {
            Console.WriteLine(instructions[18]);
            var polinom = ReadArray();
            Console.WriteLine("Dati x: ");
            int x = int.Parse(Console.ReadLine());

            long grad = 1;
            long rezultat = 0;
            for (int i = 0; i < polinom.Length; i++)
            {
                rezultat += polinom[i] * grad;
                grad *= x;
            }

            Console.WriteLine($"Polinomul {String.Join(" ", polinom)} are valoarea {rezultat} in punctul {x}");
        }
        static void P19()
        {
            Console.WriteLine(instructions[19]);
            var s = ReadArray("s");
            var p = ReadArray("p");

            String sequence = String.Join("", s);
            String key = String.Join("", p);

            int counter = 0;
            for (int i = 0; i <= sequence.Length - key.Length; i++)
                if (key.CompareTo(sequence.Substring(i, key.Length)) == 0) 
                    counter++;

            Console.WriteLine($"Secventa {String.Join(" ", p)} apare de {counter} ori in vectorul {String.Join(" ", s)}");
        }     
        static void P20()
        {

            int cntMax = 0, cnt;
            for (int i = 0; i < Math.Max(s1.Count, s2.Count); i++)
            {
                cnt = 0;
                for (int j = 0; j < s1.Count; j++)
                    if (s1[j] == s2[j])
                        cnt++;

                if (cntMax < cnt)
                    cntMax = cnt;

                if (s1.Count > s2.Count)
                    RotateToLeft(s1, 1);
                else
                    RotateToLeft(s2, 1);
            }

            Console.WriteLine($"{cntMax} este numarul maxim de suprapuneri de aceeasi culoare a celor doua margele cu posibilitatea rotirilor");
        }
        static void P21()
        {
            Console.WriteLine(instructions[21]);
            var arr1 = ReadArray("n");
            var arr2 = ReadArray("m");

            String comp1 = String.Join("", arr1);
            String comp2 = String.Join("", arr2);

            if (comp1.CompareTo(comp2) == 0)
                Console.WriteLine("Sirurile sunt egale lexicografic");
            else
                if (comp1.CompareTo(comp2) < 0)
                Console.WriteLine("Primul sir este mai mic lexicografic decat al doilea");
            else
                Console.WriteLine("Primul sir este mai mare lexicografic decat al doilea");
        }
        static void P22()
        {
            Console.WriteLine(instructions[22]);
            var arr1 = ReadArray("M1");
            var arr2 = ReadArray("M2");
            SortedSet<int> M1 = new SortedSet<int>();
            foreach (var el in arr1)
                M1.Add(el);
            SortedSet<int> M2 = new SortedSet<int>();
            foreach (var el in arr2)
                M2.Add(el);

            SortedSet<int> difM1M2 = M1minusM2(M1, M2);
            SortedSet<int> difM2M1 = M1minusM2(M2, M1);
            SortedSet<int> intersection = SetsIntersection(M1, M2);
            SortedSet<int> reunion = SetsReunion(M1, M2);

            Console.WriteLine($"M1: {String.Join(" ", M1)}");
            Console.WriteLine($"M2: {String.Join(" ", M2)}");
            Console.WriteLine($"{String.Join(" ", difM1M2)} este diferenta M1-M2");
            Console.WriteLine($"{String.Join(" ", difM2M1)} este diferenta M2-M1");
            Console.WriteLine($"{String.Join(" ", intersection)} este intersectia M1 /\\ M1");
            Console.WriteLine($"{String.Join(" ", reunion)} este reuniunea M1 V M1");
        }
        private static SortedSet<int> SetsReunion(SortedSet<int> m1, SortedSet<int> m2)
        {
            var result = new SortedSet<int>();
            foreach (var el in m1)
                result.Add(el);
            foreach (var el in m2)
                result.Add(el);
            return result;
        }
        private static SortedSet<int> SetsIntersection(SortedSet<int> m1, SortedSet<int> m2)
        {
            var result = new SortedSet<int>();
            foreach (var el in m1)
                if (m2.Contains(el))
                    result.Add(el);
            return result;
        }
        private static SortedSet<int> M1minusM2(SortedSet<int> m1, SortedSet<int> m2)
        {
            SortedSet<int> sol = new SortedSet<int>();
            foreach (var el in m1)
                if (!m2.Contains(el))
                    sol.Add(el);
            return sol;
        }
        static void P24()
        {
            Console.WriteLine(instructions[24]);
            var arr1 = ReadArray("M1");
            var arr2 = ReadArray("M2");
            SortedSet<int> M1 = new SortedSet<int>();
            for (int i = 0; i < arr1.Length; i++)
                if (arr1[i] != 0)
                    M1.Add(i);
            SortedSet<int> M2 = new SortedSet<int>();
            for (int i = 0; i < arr2.Length; i++)
                if (arr2[i] != 0)
                    M2.Add(i);

            SortedSet<int> difM1M2 = M1minusM2(M1, M2);
            SortedSet<int> difM2M1 = M1minusM2(M2, M1);
            SortedSet<int> intersection = SetsIntersection(M1, M2);
            SortedSet<int> reunion = SetsReunion(M1, M2);

            Console.WriteLine($"M1: {String.Join(" ", M1)}");
            Console.WriteLine($"M2: {String.Join(" ", M2)}");
            Console.WriteLine($"{String.Join(" ", difM1M2)} este diferenta M1-M2");
            Console.WriteLine($"{String.Join(" ", difM2M1)} este diferenta M2-M1");
            Console.WriteLine($"{String.Join(" ", intersection)} este intersectia M1 /\\ M1");
            Console.WriteLine($"{String.Join(" ", reunion)} este reuniunea M1 V M1");
        }
        static void P25()
        {
            var list = new List<int>();

            Array.Sort(arr1);
            Array.Sort(arr2);

            int index1 = 0, index2 = 0;
            while (index1 < arr1.Length && index2 < arr2.Length)
            {
                if (arr1[index1] <= arr2[index2])
                    list.Add(arr1[index1++]);
                else
                    list.Add(arr2[index2++]);
            }

            while (index1 < arr1.Length)
                list.Add(arr1[index1++]);
            index1++;

            while (index2 < arr2.Length)
                list.Add(arr2[index2++]);

            Console.WriteLine($"{String.Join(" ", arr1)} + {String.Join(" ", arr2)} = {String.Join(" ", list)}");

        }
        static void P26()
        {
            var s1 = String.Join("", arr1);
            var s2 = String.Join("", arr2);
            BigInteger nr1 = BigInteger.Parse(s1);
            BigInteger nr2 = BigInteger.Parse(s2);

            Console.WriteLine($"{nr1}+ \n{nr2} \n={nr1 + nr2}");
            Console.WriteLine();
            Console.WriteLine($"{nr1}- \n{nr2} \n={nr1 - nr2}");
            Console.WriteLine();
            Console.WriteLine($"{nr1}* \n{nr2} \n={nr1 * nr2}");
            Console.WriteLine();
        }
        static void P27()
        {
            Console.Write($"Dati k (o pozitie din vector, 0<=k<={array.Length - 1})");
            int k = int.Parse(Console.ReadLine());

            Array.Sort(array);
            Console.WriteLine($"v[{k}] in urma sortarii este {array[k]}: {String.Join(" ", array)}");
        }
        static void P28()
        {
            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine($"Vectorul dupa sortare: {String.Join(" ", array)}");
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int p = partition(array, left, right);
                QuickSort(array, left, p - 1);
                QuickSort(array, p + 1, right);
            }
        }

        private static int partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
            i++;
            (array[i], array[right]) = (array[right], array[i]);
            return i;
        }
        static void P29()
        {
            int[] aux = new int[array.Length];
            MergeSort(array, aux, 0, array.Length - 1);
            Console.WriteLine($"Vectorul dupa sortare: {String.Join(" ", array)}");
        }

        private static void MergeSort(int[] array, int[] aux, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(array, aux, left, mid);
                MergeSort(array, aux, mid + 1, right);

                int i = left, j = mid + 1, k = 0;
                while (i <= mid && j <= right)
                    if (array[i] <= array[j])
                        aux[k++] = array[i++];
                    else
                        aux[k++] = array[j++];

                while (i <= mid)
                    aux[k++] = array[i++];

                while (j <= right)
                    aux[k++] = array[j++];

                for (i = left; i <= right; i++)
                    array[i] = aux[i - left];
            }
            else
                return;
        }
        static void P30()
        {
            Console.WriteLine(instructions[30]);
            var E = ReadArray();
            var W = ReadArray();
            if (E.Length == W.Length)
            {
                int[] aux1 = new int[E.Length];
                int[] aux2 = new int[E.Length];
                MergeSort(E, W, aux1, aux2, 0, E.Length - 1);
                Console.WriteLine($"Vectorii dupa sortare: \n{String.Join(" ", E)}\n{String.Join(" ", W)}");
            }
            else
                Console.WriteLine("Vectorii trebuie sa aiba aceeasi lungime!");
        }

        private static void MergeSort(int[] crt1, int[] crt2, int[] aux1, int[] aux2, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(crt1, crt2, aux1, aux2, left, mid);
                MergeSort(crt1, crt2, aux1, aux2, mid + 1, right);

                int i = left, j = mid + 1, k = 0;
                while (i <= mid && j <= right)
                    if (crt1[i] < crt1[j])
                    {
                        aux1[k] = crt1[i];
                        aux2[k++] = crt2[i++];
                    }
                    else
                        if (crt1[i] > crt1[j])
                    {
                        aux1[k] = crt1[j];
                        aux2[k++] = crt2[j++];
                    }
                    else
                    {
                        if (crt2[i] <= crt2[j])
                        {
                            aux1[k] = crt1[i];
                            aux2[k++] = crt2[i++];
                        }
                        else
                        {
                            aux1[k] = crt1[j];
                            aux2[k++] = crt2[j++];
                        }
                    }

                while (i <= mid)
                {
                    aux1[k] = crt1[i];
                    aux2[k++] = crt2[i++];
                }

                while (j <= right)
                {
                    aux1[k] = crt1[j];
                    aux2[k++] = crt2[j++];
                }

                for (i = left; i <= right; i++)
                {
                    crt1[i] = aux1[i - left];
                    crt2[i] = aux2[i - left];
                }
            }
            else
                return;
        }
        static void P31()
        {
            Console.WriteLine(instructions[31]);
            var array = ReadArray();

            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (var el in array)
            {
                if (!map.ContainsKey(el))
                    map.Add(el, 1);
                else
                    map[el]++;
            }

            int searchedValue = 0;
            bool ok = false;
            foreach (var pair in map)
            {
                if (pair.Value > array.Length / 2)
                {
                    ok = true;
                    searchedValue = pair.Key;
                    break;
                }
            }

            if (ok)
                Console.WriteLine($"{searchedValue} este element majoritar");
            else
                Console.WriteLine($"Vectorul {String.Join(" ", array)} nu are element majoritar");
        }
    }
}