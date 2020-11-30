using System.Collections.Generic;

namespace TreeSystem
{
    // В классе TreeSystem реализованы методы вычисления концевых, смежных элементов, 
    // несущих цепочек для древовидной системы. Объект имеет свойства:
    // Bases – массив номеров базовых элементов;
    // Ends – список концевых элементов (первый элемент списка Ends[0] содержит количество 
    // найденных концевых элементов);
    // Adjac – список списков номеров смежных элементов системы; 
    // Adjac [i][j] – элемент с номером j, смежный i-му;
    // Adjac [i][0] – количество элементов, смежных i-му;
    // Supp – список списков номеров несущих элементов (заполняется),
    // Supp [i][j] – элемент с номером j, входящий в несущую цепочку i-го элемента;
    // Supp [i][0] – количество элементов, входящих в несущую цепочку i-го элемента.
    class TreeSystem
    {
        public int[] Bases { get; set; }
        public List<int> Ends { get; set; }
        public List<List<int>> Adjac { get; set; }
        public List<List<int>> Supp { get; set; }

        public TreeSystem(int[] bases)
        {
            int N = bases.Length;
            Bases = new int[N + 1];
            Bases[0] = N;
            bases.CopyTo(Bases, 1);
            Ends = new List<int> { };
            Adjac = new List<List<int>> { };
            Supp = new List<List<int>> { };
        }
        public TreeSystem(int N)
        {
            Bases = new int[N + 1];
            Bases[0] = N;
            for (int i = 1; i <= N; ++i)
            {
                Bases[i] = i;
            }
            Ends = new List<int> { };
            Adjac = new List<List<int>> { };
            Supp = new List<List<int>> { };
        }

        public List<int> GetEnds()
        {
            // Поиск концевых элементов дерева. Номер элемента не встрачается в массиве Bases.
            bool isEnd;
            Ends.Add(0);
            for (int i = 1; i < Bases[0] + 1; ++i)
            {
                isEnd = true;
                for (int j = i + 1; j < Bases[0] + 1; ++j)
                {
                    if (Bases[j] == i || Ends.Contains(i))
                    {
                        isEnd = false;
                        break;
                    }
                }
                if (isEnd)
                    Ends.Add(i);
            }
            Ends[0] = Ends.Count - 1;
            return Ends;
        }

        public List<List<int>> GetAdjac()
        {
            // Поиск смежных элементов. Элементы имеют один и тот же номер базового элемента.
            Adjac.Add(new List<int> { });
            for (int i = 1; i < Bases[0] + 1; ++i)
            {
                Adjac.Add(new List<int> { 0 });
                for (int j = i + 1; j < Bases[0] + 1; ++j)
                {
                    if (Bases[j] == i)
                    {
                        Adjac[i].Add(j);
                    }
                }
                Adjac[i][0] = Adjac[i].Count - 1;
            }
            return Adjac;
        }

        public List<List<int>> GetSupp()
        {
            // Поиск несущих цепочек тел.
            Supp.Add(new List<int> { 1, 0 });
            for (int i = 1; i < Bases[0] + 1; ++i)
            {
                List<int> list = new List<int> { 0 };
                Supp.Add(Recurs(i, list));
                Supp[i][0] = Supp[i].Count - 1;
            }

            List<int> Recurs(int i, List<int> list)
            {
                list.Add(i);
                if (Bases[i] != 0)
                {
                    return Recurs(Bases[i], list);
                }
                else
                {
                    list.Add(0);
                    return list;
                }
            }
            return Supp;
        }
    }
}