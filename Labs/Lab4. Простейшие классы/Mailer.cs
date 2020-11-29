using System;
using System.Text.RegularExpressions;
/* Класс представляющий почтовый адрес организации. Определены поля для хранения почтового индекса,
 * названия города, улицы и здания. Заданы соотвествующие свойства для присвоения полям значений с проверкой 
 * вводимых значений. Единственный метод возвращает полный адрес. Добавлены два конструктора.
 */

class Mailer
{
    string postIndex, city, street, estate;
    const byte postLen = 6;

    public Mailer()
    {
        postIndex = "000000";
        city = "Paradise";
        street = "Lenina";
        estate = "11/1";
    }

    public Mailer(string p, string c, string st, string es)
    {
        this.Post = p;
        this.Сity = city;
        this.Street = st;
        this.Estate = es;
    }
    public string Post
    {
        get
        {
            return postIndex;
        }
        
        set {
            if (value.Length == postLen || Regex.IsMatch(value, @"\d{6}"))
            {
                postIndex = value;
            }
            else
            {
                throw new Exception("Неправльный почтовый индекс");
            }
            
        } 
    }

    public string Сity
    {
        get
        {
            return city;
        }
        set
        {
            if (value.Length != 0 || Regex.IsMatch(value, @"[\w\d\s]+"))
            {
                city = value;
            }
            else
            {
                throw new Exception("Ошибка в названии города");
            }

        }
    }

    public string Street
    {
        get
        {
            return street;
        }
        set
        {
            if (value.Length != 0 || Regex.IsMatch(value, @"[\w\d\s]+"))
            {
                street = value;
            }
            else
            {
                throw new Exception("Неправильное название улицы");
            }

        }
    }

    public string Estate
    {
        get
        {
            return estate;
        }
        set
        {
            if (value.Length == postLen || Regex.IsMatch(value, @"\d/?\w?"))
            {
                estate = value;
            }
            else
            {
                throw new Exception("Номер здания введен с ошибкой");
            }
        }
    }
    public string ShowAddres()
    {
        return postIndex + ", " + city + ", " + street + ", " + estate;
    }
}