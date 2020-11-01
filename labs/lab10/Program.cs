using System;
using System.Text.RegularExpressions;

/* Лабораторная работа 10. Структуры */

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Задача 1. Описать структуру с именем STUDENT, содержащую следующие поля: фамилия и инициалы;
             * номер группы; успеваемость(массив из пяти элементов). Написать программу, выполняющую 
             * следующие действия: ввод с клавиатуры данных в массив, состоящий из десяти структур 
             * типа STUDENT (записи должны быть упорядочены по возрастанию номера группы); вывод на 
             * экран фамилий и номеров групп для всех студентов, включенных в массив, если средний 
             * балл студента больше 4,0 (если таких студентов нет, вывести соответствующее сообщение).
            */
            byte count = 2, marksCount = 5;
            STUDENT[] students = new STUDENT[count];
            string[] marks = new string[marksCount];
            string name;
            short group;
            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine("Фамилия студента с инициалами (пр. Иванов В.П.):");
                name = Console.ReadLine();
                Console.WriteLine("Номер группы (пр. 257):");
                group = short.Parse(Console.ReadLine());
                Console.WriteLine("Оценки студента через запятую:");
                marks = Regex.Split(Console.ReadLine(), @",\s*");
                students[i] = new STUDENT(name, group, marks);
            }
            //students[0].Marks = new string[] { "4", "4", "4", "4", "4" };

            string topStudents = "";
            string[] st;
            int sum = 0;
            for (int i = 0; i < count; ++i)
            {
                sum = 0;
                st = students[i].Marks;
                //st 
                for (int j = 0; j < marksCount; ++j)
                {
                    sum += Int32.Parse(st[j]);
                }
                if (sum / marksCount >= 4)
                {
                    topStudents += students[i].Name + " ";
                }
            }
            Console.WriteLine(topStudents);

            /* Задача 10. Описать структуру с именем MARSH, содержащую следующие поля: 
             * название начального пункта маршрута;	название конечного пункта маршрута; 
             * номер маршрута. Написать программу, выполняющую следующие действия: ввод с 
             * клавиатуры данных в массив, состоящий из восьми элементов типа MARSH (записи 
             * должны быть упорядочены по номерам маршрутов); вывод на экран информации о 
             * маршруте, номер которого введен с клавиатуры (если таких маршрутов нет, вывести 
             * соответствующее сообщение).
             */
            int counts = 2;
            string begin, finish;
            MARSH[] marsh = new MARSH[counts];
            for (int i = 0; i < counts; ++i)
            {
                marsh[i] = new MARSH();
                Console.WriteLine("Начальная станция");
                begin = Console.ReadLine();
                Console.WriteLine("Конечная станция");
                finish = Console.ReadLine();
                marsh[i].Marsh = new string[] { begin, finish };
            }

            while (true)
            {
                Console.WriteLine("Введите начальную или конечную станцию (q - выход): ");
                string station = Console.ReadLine();
                if (station == "q") break;
                string[] tmpMarsh;
                for (int i = 0; i < counts; ++i)
                {
                    tmpMarsh = marsh[i].Marsh;
                    if (tmpMarsh[0] == station || tmpMarsh[1] == station)
                        Console.WriteLine(marsh[i].Info());
                }
            }
            
        }
    }
}
