using System;

// Класс, реализиующий шестнадцатеричный счетчкик. 
// Класс имеет закрытое поле счетчика, свойство, возвращающее его значение,
// два метода для инкремента и декремента счетчика. Если счетчик выходит за допустимый диапазон значений,
// генерируется исключение.

internal class Enconter16
{
    // Используем закрытое поле и полную форму свойства для доступа к нему вместо автоматического для тренировки
    private int counter;

    public Enconter16()
    {
        counter = 0x1;
    }

    public Enconter16(int a)
    {
        counter = a;
    }

    public int GetCounter
    {
        get
        {
            return counter;
        }
    }

    public void Increm()
    {
        if (counter < 0xB)
        {
            ++counter;
        }
        else
            ThrowCountException();
    }
    public void Decrem()
    {
        if (counter > -0x5)
        {
            --counter;
        }
        else
            ThrowCountException();
    }

    static private void ThrowCountException()
    {
        throw new IndexOutOfRangeException("Вышли за границу значений счетчика");
    }
}