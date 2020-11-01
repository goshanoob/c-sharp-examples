using System;

/* Структура MARSH изпользуется для описания маршрутов при помощи полей начало маршрута (beginMarsh),
 * конец маршрута (finishMarsh), номер маршрута (numberMarsh). Конструктор по умолчанию не определен,
 * значения полей инициализируются значениями автоматически. Свойство Marsh позволяет определить 
 * все поля, передав значения в виде строкового массива. Свойство возвращает аналогичный массив.
 * Метод Info() возвращает строку с полной информацией о маршруте.
 */

namespace lab10
{
    struct MARSH
    {
        string beginMarsh;
        string finishMarsh;
        int numberMarsh;

        public string[] Marsh
        {
            get
            {
                return new string[] { beginMarsh, finishMarsh, numberMarsh.ToString("D4") };
            }
            set
            {
                beginMarsh = value[0];
                finishMarsh = value[1];
                //if (numberMarsh == 0) numberMarsh = 1;
                ++numberMarsh;
            }
        }
        public string Info()
        {
            return $"Маршрут номер {numberMarsh} из {beginMarsh} в {finishMarsh}";
        }
    }
}
