using System;

// Класс Элемент. Элменты класса описывают элемент электрической схемы. Определены закрытые поля
// для имени элемента и количества входов и выходов. Заданы конструктор без параметров, конструктор,
// опеределяющий имя элемента и конструктор для задания всех полей класса. Класс не имеет полей, значения
// которых нужно вычислять на основе входных данных, но для него определены виртуальных 3 метода, которые
// будут переопределены в классах-потомках. Методы выозвращают произвольные знчения и не определены
// как абстрактные, чтобы можно было создавать экземпляры класса Элемента.
// Класс Комбинационный наследует от класса Элемент. Он имеет поле inputValues для хранения входных сигналов.
// Задать сигналы на вход можно при помощи метода SetInputs(). Произвольное значение на входе возвращает
// метод GetInputValue() по номеру входы. Состояние Компбинационного элемента вычисляет метод GetOutputValue().
// Методы переопределяют методы базового класса. Конструкторы перегружены три раза. Конструктор по умолчанию
// определяет восемь входов элемента, заполняя их нулями. Второй конструктор позволяет задать имя элементу и
// определить значения на входах с помощью массива. Третий конструктор реализует те же возможности, используя
// конструктор базового класса, но позволяет заполнить входные значения лишь частично (остальные по умолчанию
// примут значения 0).
// Класс Память является вложенным по отношению к классу Регистр и наследует от класса Элемент. Память является
// в данной предметной области является триггером, поэтому для класса объявлены поля задающие вычисляемые выходные значения.
// 
// Класс Регистр. Поля класса set и reset реализуют логику установки и сброса входных знчений регистра.
// Входные значения записываются в поле inputValues. Регистр является совокупностью модулей памяти, поэтому
// inputValues является двумерным массивом, первое измерение которого соотвествует номеру памяти. Память имеет
// два входа, поэтому длина второй размерности равна двум. Поле memory содержит экземпляры вложенного класса Память.
// Входные значения из inputValues передаются соотвествующим экземплярам класса Память.

namespace lab11
{
    class Элемент: IComparable
    {
        private string name;
        private byte inputCount;
        private byte outputCount;

        public Элемент()
        {
            name = "default";
            inputCount = 1;
            outputCount = 1;
        }

        public Элемент(string name) : this()
        {
            this.name = name;
        }

        public Элемент(string name, byte inpCount, byte outCount)
        {
            this.name = name;
            inputCount = inpCount;
            outputCount = outCount;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public byte InputCount
        {
            get
            {
                return inputCount;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Количество входов не может быть отрицательно!");
                }

                inputCount = value;
            }
        }

        public byte OutputCount
        {
            get
            {
                return outputCount;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Количество выходов не может быть отрицательно!");
                }

                outputCount = value;
            }
        }

        public virtual void SetInputs(byte[] values) { }
        public virtual byte GetInputValue(byte i) { return 0; }
        public virtual byte GetOutputValue() { return 0; }

        public virtual int CompareTo(object obj)
        {
            // Сравнение элементов по количеству входов
            if ((object)this == obj) return 0;
            Элемент tmp = (Элемент)obj;
            if (inputCount < tmp.inputCount) return -1;
            if (inputCount > tmp.inputCount) return 1;
            return 0;
        }

        public static bool operator <(Элемент a, Элемент b)
        {
            return (a.CompareTo(b) < 0);
        }
        public static bool operator >(Элемент a, Элемент b)
        {
            return (a.CompareTo(b) > 0);
        }

        public static bool operator <=(Элемент a, Элемент b)
        {
            return (a.CompareTo(b) <= 0);
        }
        public static bool operator >=(Элемент a, Элемент b)
        {
            return (a.CompareTo(b) >= 0);
        }

    }

    class Комбинационный : Элемент, IComparable
    {
        private byte[] inputValues;

        public Комбинационный()
        {
            InputCount = 8; // количество входов равно 8, один выход (по умолчанию)
            inputValues = new byte[InputCount];
        }

        public Комбинационный(string name, byte[] inpVal) : base(name)
        {
            InputCount = (byte)inpVal.Length;
            inputValues = new byte[InputCount];
            inpVal.CopyTo(inputValues, 0);
        }
        public Комбинационный(string name, byte inpCount, byte[] inpVal)
            : base(name, inpCount, 1) // комбинационный элемент имеет один выход
        {
            if (inpCount < inpVal.Length)
            {
                throw new Exception("Несоответствие в аргументах конструктора. Слишком много значений выходов");
            }
            inputValues = new byte[inpCount];
            inpVal.CopyTo(inputValues, 0);
        }

        public override void SetInputs(byte[] inpVal)
        {
            if (inpVal.Length > InputCount)
            {
                throw new Exception($"Слишком ного значений выходов. В данном элементе определено " +
                    $"количество выходов равным {InputCount}");
            }
            inpVal.CopyTo(inputValues, 0);
        }

        public override byte GetInputValue(byte i)
        {
            return inputValues[i];
        }
        public override byte GetOutputValue()
        {
            // Проверка операции ИЛИ-НЕ (инверсия дизъюнкции, стрелка Пирса)
            byte result = 1;
            for (int k = 0; k < inputValues.Length; ++k)
            {
                if (inputValues[k] != 0) result = 0;
            }
            return result;
        }

        public override int CompareTo(object obj)
        {
            // Сравнение по выходному значению
            if ((object)this == obj) return 0;
            Комбинационный tmp = (Комбинационный)obj;
            if (GetOutputValue() < tmp.GetOutputValue()) return -1;
            if (GetOutputValue() > tmp.GetOutputValue()) return 1;
            return 0;
        }

        public static bool operator <(Комбинационный a, Комбинационный b)
        {
            return (a.CompareTo(b) < 0);
        }
        public static bool operator >(Комбинационный a, Комбинационный b)
        {
            return (a.CompareTo(b) > 0);
        }

        public static bool operator <=(Комбинационный a, Комбинационный b)
        {
            return (a.CompareTo(b) <= 0);
        }
        public static bool operator >=(Комбинационный a, Комбинационный b)
        {
            return (a.CompareTo(b) >= 0);
        }
    }

    class Регистр : IComparable
    {
        byte reset; // сброс
        byte set; // установка - не выяснил, как работают. Пусть, если set == 1, то можно задавать входные сигналы, иначе - нельзя. При изменении reset в значение 1, все триггеры обнуляются.
        internal Память[] memory; // регистр состоит из набора триггеров 
        byte[,] inputValues; // входные сигналы регистра
        const byte capacity = 9; // разрядность регистра
        const byte inOutCount = 2; // количество входов и выходов у триггеров

        public byte Set
        {
            get
            {
                return set;
            }
            set
            {
                if (value != 0 || value != 1)
                {
                    throw new Exception("Значение set должно быть 0 или 1");
                }
                set = value;
            }
        }

        public byte Reset
        {
            // Свойство сбрасывающее значения элементов класса на занчения по умолчанию
            set
            {
                if (value == 1)
                {
                    inputValues = new byte[capacity, inOutCount];
                    for (int i = 0; i < capacity; ++i)
                    {
                        memory[i] = new Память();
                    }
                    reset = 0;
                }
            }
        }

        public Регистр()
        {
            set = 1;
            memory = new Память[capacity];
            inputValues = new byte[capacity, inOutCount];
            for (int i = 0; i < capacity; ++i)
            {
                memory[i] = new Память();
            }
        }

        public Регистр(string name, byte[,] inpVal)
        {
            set = 1;
            memory = new Память[capacity];
            inputValues = new byte[capacity, inOutCount];
            Array.Copy(inpVal, inputValues, capacity * inOutCount);
            byte[] row = new byte[inOutCount];
            for (int i = 0; i < capacity; ++i)
            {
                for (int j = 0; j < inOutCount; ++j)
                {
                    row[j] = inputValues[i, j];
                }
                //Array.Copy(inputValues, i * inOutCount, row, 0, inOutCount); // работает для массивов одинаковой размерности
                memory[i] = new Память(name, row);
            }
        }
        public void SetInputs(byte[,] inpVal)
        {
            if (inpVal.Length > inputValues.Length)
            {
                throw new Exception("Неправильное количество сигналов. " +
                    $"Данный регистр содержит {capacity} триггеров по {inOutCount} входа(-ов)");
            }
            if (set == 0)
            {
                throw new Exception("Нельзя задавать входные сигналы, так как set равен 0");
            }
            Array.Copy(inpVal, inputValues, capacity * inOutCount);
            byte[] row = new byte[inOutCount];
            for (int i = 0; i < capacity; ++i)
            {
                for (int j = 0; j < inOutCount; ++j)
                {
                    row[j] = inputValues[i, j];
                }
                memory[i].SetInputs(row);
            }
        }

        public byte GetInputValue(byte i, byte j)
        {
            return inputValues[i, j];
        }
        public string GetOutputValue()
        {
            string result = "";
            for (int i = 0; i < capacity; ++i)
            {
                result += " " + memory[i].GetOutputValue().ToString();
            }
            return result;
        }

        public int CompareTo(object obj)
        {
            if ((object)this == obj) return 0;
            Регистр tmp = (Регистр)obj;
            string[] outPutA = GetOutputValue().Split(" "); // выделить память?
            string[] outPutB = tmp.GetOutputValue().Split(" ");
            int sumA = 0, sumB = 0;
            for (int i = 0; i < capacity; ++i)
            {
                sumA += Int32.Parse(outPutA[i]);
                sumB += Int32.Parse(outPutB[i]);
            }
            // Больше тот регистр, у которого больше единиц на выходе
            if (sumA < sumB) return - 1;
            if (sumA > sumB) return 1;
            return 0;
        }

        public static bool operator <(Регистр a, Регистр b)
        {
            return (a.CompareTo(b) < 0);
        }
        public static bool operator >(Регистр a, Регистр b)
        {
            return (a.CompareTo(b) > 0);
        }

        public static bool operator <=(Регистр a, Регистр b)
        {
            return (a.CompareTo(b) <= 0);
        }
        public static bool operator >=(Регистр a, Регистр b)
        {
            return (a.CompareTo(b) >= 0);
        }

        internal class Память : Элемент, IComparable
        {
            private byte[] inputValues;
            private byte straightOutputValue; // состояние на прямом выходе
            private byte inversOutputValue; // состояние на инверсном выходе

            public Память()
            {
                InputCount = inOutCount; // количество входов TV-триггера равно 2
                OutputCount = inOutCount; // у триггера два выхода: прямой и инверсный
                inputValues = new byte[InputCount];
                straightOutputValue = 0;
                inversOutputValue = 1;
            }

            public Память(Память a)
            {
                // конструктор копирования объекта
                InputCount = a.InputCount;
                inputValues = new byte[InputCount];
                straightOutputValue = a.straightOutputValue;
                inversOutputValue = a.inversOutputValue;
                a.inputValues.CopyTo(inputValues, 0);
            }

            public Память(string name, byte[] inpVal) : base(name)
            {
                InputCount = (byte)inpVal.Length;
                OutputCount = inOutCount;
                inputValues = new byte[InputCount];
                straightOutputValue = inputValues[0];
                inversOutputValue = (byte)~straightOutputValue;
            }
            public override void SetInputs(byte[] inpVal)
            {
                if (inpVal.Length > InputCount)
                {
                    throw new Exception($"Слишком ного значений входов. В данном элементе определено " +
                        $"количество входов равным {InputCount}");
                }
                CalcOutput(inputValues, inpVal);
                inpVal.CopyTo(inputValues, 0);
            }

            public override byte GetInputValue(byte i)
            {
                return inputValues[i];
            }
            public override byte GetOutputValue()
            {
                return straightOutputValue;
            }

            private void CalcOutput(byte[] Q0, byte[] Q1)
            {
                /* Вычисление значения TV-триггера. Если на втором входе 1, то запись в триггер разрешается,
                 * в противном случае триггер не меняет состояние. Если на первом входе 0, то проверяется текущее
                 * значение триггера: если было 0, то 0 останется, если была 1 - останется 1. Если на первом входе 1,
                 * то также проверяется текущее значение: если было 0, то в результате станет 1, если было 1,
                 * то станет 0. Таким образом, TV-триггер реализует операцию исключающего или.
                */
                if (Q1[InputCount - 1] == 1)
                {
                    straightOutputValue = (byte)(Q0[0] ^ Q1[0]);
                    inversOutputValue = (byte)~straightOutputValue;
                }
            }

            public static bool operator ==(Память a, Память b)
            {
                return a.Equals(b);
            }
            public static bool operator !=(Память a, Память b)
            {
                return !a.Equals(b);
            }

            public override bool Equals(object a)
            {
                if (a == null && (object)this == null) return true;
                if (a == null || (object)this == null) return false; // также как для обнуляемых типов
                if ((object)this == a) return true; // сравнили с самим собой
                if (a.GetType() != GetType()) return false; // не совпал тип
                Память tmp = (Память)a;
                if (tmp.inputValues.Length != inputValues.Length) return false;
                int f = 0;
                foreach (byte i in tmp.inputValues)
                {
                    if (i != inputValues[f++])
                    {
                        return false;
                    }
                }
                return true;
            }

            public override int GetHashCode()
            {
                return (inputValues, straightOutputValue, inversOutputValue).GetHashCode();
            }

            public override int CompareTo(object obj)
            {
                // Сравнение по значению на прямом выходе
                if ((object)this == obj) return 0;
                Память tmp = (Память)obj;
                if (this.straightOutputValue < tmp.straightOutputValue) return -1;
                if (this.straightOutputValue > tmp.straightOutputValue) return 1;
                return 0;
            }

            public static bool operator <(Память a, Память b)
            {
                return (a.CompareTo(b) < 0);
            }

            public static bool operator >(Память a, Память b)
            {
                return (a.CompareTo(b) > 0);
            }
            public static bool operator <=(Память a, Память b)
            {
                return (a.CompareTo(b) <= 0);
            }
            public static bool operator >=(Память a, Память b)
            {
                return (a.CompareTo(b) >= 0);
            }
        }
    }
}

