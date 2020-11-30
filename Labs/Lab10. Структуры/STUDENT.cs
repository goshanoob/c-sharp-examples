using System;

// Структура STUDENT содержит поля для хранения фамилии студента, номера группы, оценок студента
// по пяти дисциплинам. Свойства Name, Group, Marks возвращают значения соотвествующих полей. Конструктор
// с тремя параметрами позволяет создать объект типа STUDENT и определить значения всех полей. Метод

namespace lab10
{
    internal struct STUDENT
    {
        // Фамилия студента с инициалами.
        private string _secondName;
        // Номер группы.
        private short _groupNum;
        // Оценки студента.
        private string[] _marks;
        // Количество дисциплин.
        private const byte marksCount = 5;

        public string Name
        {
            get
            {
                return _secondName;
            }
            set
            {
                _secondName = value;
            }
        }

        public short Group
        {
            get
            {
                return _groupNum;
            }
            set
            {
                _groupNum = value;
            }
        }

        public string[] Marks
        {
            get
            {
                return _marks;
            }
            set
            {
                if (value.Length > marksCount)
                {
                    throw new Exception($"Максисмальное количество оценок равно {marksCount}");
                }
                value.CopyTo(_marks, 0);
            }
        }

        public STUDENT(string name, short group, string[] mark)
        {
            _secondName = name;
            _groupNum = group;
            if (mark.Length > marksCount)
            {
                throw new Exception($"Максисмальное количество оценок равно {marksCount}");
            }
            _marks = new string[marksCount];
            mark.CopyTo(_marks, 0);
        }
    }
}