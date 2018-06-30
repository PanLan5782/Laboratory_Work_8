using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_Работа_8
{
    class CrudOperations
    {
        public static Person CreatePerson(List<Person> persons)
        {
            string fio = $"{GetRandomSecondName()} {GetRandomName()} {GetRandomPatronymic()}";
            Person p = new Person(fio, GetPasportNumber(persons), GetPhoneNumber());
            return p;
        }

        static Random rnd = new Random();
        static string GetRandomSecondName()
        {
            string[] data = new[]
            { "Иванов",
             "Печеников",
             "Топоров",
             "Халимдаров",
             "Хвостовский",
             "Висенин",
             "Цулукидзе",
             "Яшагин",
             "Жаглин",
             "Рыжков",
             "Кошкин",
             "Чучанов",
             "Коновалов",
             "Моряев",
             "Лекомцев",
             "Иванников",
             "Кайпанов",
             "Степанишин",
             "Сьянов",
             "Башкатов",
             "Щавлев"
            };
            int index = rnd.Next(0, data.Length);
            return data[index];
        }
        static string GetRandomName()
        {
            string[] data = new[]
            {
           "Евграф",
           "Матвей",
           "Давид",
           "Вацлав",
           "Григорий",
           "Юлий",
           "Зиновий",
           "Мирон",
           "Наум",
           "Святослав",
           "Геннадий",
           "Арсений",
           "Богдан",
           "Никон",
           "Рубен",
           "Ярослав",
           "Аркадий",
           "Захар",
           "Клавдий",
           "Осип",
           "Даниил"
            };
            int index = rnd.Next(0, data.Length);
            return data[index];
        }

        static string GetRandomPatronymic()
        {
            string[] data = new[]
            {
          "Гордеевич",
          "Богданович",
          "Ипатович",
          "Родионович",
          "Федотович",
          "Федорович",
          "Савелиевич",
          "Святославович",
          "Миронович",
          "Венедиктович",
          "Аникитевич",
          "Геннадиевич",
          "Владимирович",
          "Елизарович",
          "Брониславович",
          "Титович",
          "Назарович",
          "Платонович",
          "Филимонович",
          "Демьянович",
          "Капитонович"
                         };
            int index = rnd.Next(0, data.Length);
            return data[index];
        }

        static string GetPasportNumber(List<Person> persons)
        {
            string result;
            do
            {
                // Вариант №1 (стандартный размер паспорта):
                // result = rnd.Next(1000000000, int.MaxValue).ToString();
                result = rnd.Next(100, 999).ToString(); // Вариант №2 (для организации коллизий)
            }
            while (persons.Exists(p => p.Passport == result));

            return result;
        }

        static string GetPhoneNumber()
        {
            return $"{rnd.Next(0, 10)} ({rnd.Next(100, 1000)}) {rnd.Next(100, 1000)}-{rnd.Next(10, 100)}-{rnd.Next(10, 100)}";
        }
    }
}
