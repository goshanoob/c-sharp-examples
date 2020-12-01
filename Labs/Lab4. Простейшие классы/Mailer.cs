using System;
using System.Text.RegularExpressions;

// Класс представляющий почтовый адрес организации. Определены поля для хранения почтового индекса,
// названия города, улицы и здания. Заданы соотвествующие свойства для присвоения полям значений с проверкой 
// вводимых значений. Единственный метод возвращает полный адрес. Добавлены два конструктора.

class Mailer
{
    string _postIndex, _city, _street, _estate;
    const byte postLen = 6;

    public Mailer()
    {
        _postIndex = "000000";
        _city = "Paradise";
        _street = "Lenina";
        _estate = "11/1";
    }

    public Mailer(string post, string city, string street, string estate)
    {
        Post = post;
        Сity = city;
        Street = street;
        Estate = estate;
    }
    public string Post
    {
        get
        {
            return _postIndex;
        }

        set
        {
            if (value.Length == postLen || Regex.IsMatch(value, @"\d{6}"))
            {
                _postIndex = value;
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
            return _city;
        }
        set
        {
            if (value.Length != 0 || Regex.IsMatch(value, @"[\w\d\s]+"))
            {
                _city = value;
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
            return _street;
        }
        set
        {
            if (value.Length != 0 || Regex.IsMatch(value, @"[\w\d\s]+"))
            {
                _street = value;
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
            return _estate;
        }
        set
        {
            if (value.Length == postLen || Regex.IsMatch(value, @"\d/?\w?"))
            {
                _estate = value;
            }
            else
            {
                throw new Exception("Номер здания введен с ошибкой");
            }
        }
    }
    public string ShowAddres()
    {
        return $"{_postIndex}, {_city}, {_street}, {_estate}";
    }
}