// Структура MARSH изпользуется для описания маршрутов при помощи полей начало маршрута (beginMarsh),
// конец маршрута (finishMarsh), номер маршрута (numberMarsh). Конструктор по умолчанию не определен,
// значения полей инициализируются значениями автоматически. Свойство Marsh позволяет определить 
// все поля, передав значения в виде строкового массива. Свойство возвращает аналогичный массив.
// Метод Info() возвращает строку с полной информацией о маршруте.

namespace lab10
{
    internal struct MARSH
    {
        private string _beginMarsh;
        private string _finishMarsh;
        private int _numberMarsh;

        public string[] Marsh
        {
            get
            {
                return new string[] { _beginMarsh, _finishMarsh, _numberMarsh.ToString("D4") };
            }
            set
            {
                _beginMarsh = value[0];
                _finishMarsh = value[1];
                //if (numberMarsh == 0) numberMarsh = 1;
                ++_numberMarsh;
            }
        }
        public string Info()
        {
            return $"Маршрут номер {_numberMarsh} из {_beginMarsh} в {_finishMarsh}";
        }
    }
}
