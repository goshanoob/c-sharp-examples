using System;
using System.Linq;

/* Класс Элемент. Элменты класса описывают элемент электрической схемы. Определены закрытые поля
 для имени элемента и количества входов и выходов. Заданы конструктор без параметров, конструктор,
опеределяющий имя элемента и конструктор для задания всех полей класса.



*/

namespace lab11
{
    abstract class Элемент
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

        public abstract void SetInputs(byte[] values);
        public abstract byte GetInputValue(byte i);
        public abstract byte GetOutputValue();

    }

    class Комбинационный : Элемент
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
    }

    class Регистр
    {
        byte reset; // сброс
        byte set; // установка - не выяснил, как работают. Пусть, если set == 1, то можно задавать входные сигналы, иначе - нельзя. При изменении reset в значение 1, все триггеры обнуляются.
        Память[] memory; // регистр состоит из набора триггеров 
        byte[,] inputValues; // входные сигналы регистра
        const byte capacity = 9; // разрядность регистра
        const byte inOutCount = 2; // количество входов и выходов у триггеров
        public Регистр()
        {
            memory = new Память[capacity];
            inputValues = new byte[capacity, inOutCount];
            for (int i = 0; i < capacity; ++i)
            {
                memory[i] = new Память();
            }
        }

        public Регистр(string name, byte[,] inpVal)
        {
            memory = new Память[capacity];
            inputValues = new byte[capacity, inOutCount];
            Array.Copy(inpVal, inputValues, capacity * inOutCount);
            byte[] row = new byte[inOutCount];
            for (int i = 0; i < capacity; ++i)
            {
                for(int j = 0; j < inOutCount; ++j)
                {
                    row[j] = inputValues[i, j];
                }
                //Array.Copy(inputValues, i * inOutCount, row, 0, inOutCount); // работает для массивом одинаковой размерности
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
            Array.Copy(inpVal, inputValues, capacity* inOutCount);
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
                result += " "+memory[i].GetOutputValue().ToString();
            }
            return result;
        }


        class Память : Элемент
        {
            private byte[] inputValues;
            private byte straightOutputValue; // состояние на прямом выходе
            private byte inversOutputValue; // состояние на инверсном выходе

            public Память()
            {
                InputCount = inOutCount; // количество входов TV-триггера равно 2
                OutputCount = inOutCount; // у триггера два выхода: прямой и инверсный
                inputValues = new byte[InputCount];
                straightOutputValue = 0; // здесь нужно посчитать, если на входе все нули
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
                straightOutputValue = 0; // здесь нужно вычислить
                inversOutputValue = 1;
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
                // вычисление значения TV-триггера
                return 0;
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
                if (a == null && this == null) return true;
                if (a == null || this == null) return false; // также как для обнуляемых типов
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
        }
    }
}
