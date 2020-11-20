/* Разработать алгоритмы и оформить их в виде программы вычисления концевых, смежных элементов, 
 * несущих цепочек для древовидной системы. Объект имеет свойства:
 * bases = [] – массив базовых элементов;
 * ends = [] – массив концевых элементов (первый элемент массива ends[0] содержит количество 
 * найденных концевых элементов);
 * adjac = [] – двумерный массив номеров смежных элементов системы; 
 * adjac [i][j] – элемент с номером j, смежный i-му;
 * adjac [i][0] – количество элементов, смежных i-му;
 * supp = [] – двумерный массив номеров несущих элементов (заполняется),
 * supp [i][j] – элемент с номером j, входящий в несущую цепочку i-го элемента;
 * supp [i][0] – количество элементов, входящих в несущую цепочку i-го элемента.
*/

using System.Collections.Generic;

namespace TreeSystem
{
    class TreeSystem
    {
        public int[] Bases { get; set; } // базовые элементы
        public List<int> Ends { get; set; } // концевые элементы
        public List<List<int>> Adjac { get; set; } // смежные элементы
        public List<List<int>> Supp { get; set; } // элементы в несущей цепочке

        public TreeSystem(int[] bases)
        {
            int N = bases.Length; // количество элементов
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
            // Поиск концевых элементов дерева. Номер элемента не встрачается в массиве Bases

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
            // Поиск смежных элементов. Элементы имеют один и тот же номер базового элемента
            Adjac.Add(new List<int> { });
            for (int i = 1; i < Bases[0] + 1; ++i)
            {
                Adjac.Add(new List<int> {0});
                for (int j = i + 1; j < Bases[0] + 1; ++j)
                {
                    if(Bases[j] == i)
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
            for(int i = 1; i < Bases[0] + 1; ++i)
            {
                List<int> list = new List<int> { };
                recurs(i, ref list);
                Supp.Add(list);
            }

            void recurs(int i, ref List<int> list)
            {
                list.Add(i);
                if (Bases[i] != 0) recurs(Bases[i], ref list);
                else
                {
                    list.Add(0);
                    return ;
                }
                    
            }
            return Supp;
        }
    }
}
