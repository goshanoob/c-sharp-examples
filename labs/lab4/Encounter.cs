using System;
/*   Класс, реализиующий шестнадцатеричный счетчкик. 
     Класс имеет закрытое поле счетчика, свойство, возвращающее его значение,
     два метода инкремента и декремента счетчика. Если счетчик выходит за допустимый диапазон значений,
     генерируется исключение */
class Enconter16
{
    private int counter;

    public Enconter16()
    {
        counter = 0x1;
    }

    public Enconter16(int a)
    {
        counter = a;
    }

    public int getCounter
    {
        get
        {
            return counter;
        }
    }

    public void Increm()
    {
        if (counter < 0x5)
        {
            ++counter;
        }
        else GenExept();
    }
    public void Decrem()
    {
        if (counter > -0x5)
        {
            --counter;
        }
        else GenExept();
    }

    static private void GenExept()
    {
        throw new Exception("Вышли за границу значений счетчика");
    }
}