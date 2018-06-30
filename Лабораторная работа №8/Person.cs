using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_Работа_8
{
    class Person
    {
        public string FIO;
        public string Passport;
        public string Telefone;
        public Person(string fio, string pasport, string telefone)
        {
            FIO = fio;
            Passport = pasport;
            Telefone = telefone;
        }

        public int GetHash(int m)
        {
            return GetHashForKey(Passport, m);
        }

        public static int GetHashForKey(string key, int m)
        {
            return (int) long.Parse(key) % m;
        }

        public override string ToString()
        {
            return $"Паспорт:{Passport}; ФИО:{FIO}; Телефон:{Telefone};";
        }
    }
}
