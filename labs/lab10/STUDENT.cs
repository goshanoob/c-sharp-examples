using System;

/* Структура STUDENT содержит поля для хранения фамилии студента, номера группы, оценок студента
 * по пяти дисциплинам. Свойства Name, Group, Marks возвращают значения соотвествующих полей. Конструктор
 * с тремя параметрами позволяет создать объект типа STUDENT и определить значения всех полей. Метод
 * MakeList() ...
*/

namespace lab10
{
    struct STUDENT
    {
        string secondName; // фамилия студента с инициалами
        short groupNum; // номер группы
        string[] marks; // оценки студента
        const byte marksCount = 5; // количество дисциплин

        public string Name
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
            }
        }

        public short Group
        {
            get
            {
                return groupNum;
            }
            set
            {
                groupNum = value;
            }
        }

        public string[] Marks
        {
            get
            {
                return marks;
            }
            set
            {
                value.CopyTo(marks, 0);
            }
        }

        public STUDENT(string name, short group, string[] mark)
        {
            secondName = name;
            groupNum = group;
            if (mark.Length > marksCount)
            {
                throw new Exception($"Максисмальное количество оценок равно {marksCount}");
            }
            marks = new string[marksCount];
            mark.CopyTo(marks, 0); // попробовать присваивание
        }

        private void MakeList()
        {

        }

    }
}

