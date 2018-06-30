using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лабораторная_Работа_8
{
    class Program
    {
        const int M = 40;

        static List<Person> persons = new List<Person>();

        static List<int>[] hashTable = new List<int>[M];

        static void Main(string[] args)
        {
            for (int i = 0; i < M; i++)
                hashTable[i] = new List<int>();

            for (int i = 0; i < 100; i++)
                AddPerson(i);

            string userCommand = null;
            do
            {try
                {
                    Console.WriteLine("1)Вывести список");
                    Console.WriteLine("2)Найти элемент по ключу");
                    Console.WriteLine("3)Подсчитать количество коллизий");
                    Console.WriteLine("4)Работа с записями");
                    Console.WriteLine("5)Выход");
                    Console.Write(">");
                    userCommand = Console.ReadLine();
                    Person p;
                    switch (userCommand)
                    {
                        case "1":
                            foreach (List<int> i in hashTable)
                                foreach (int l in i)
                                    Console.WriteLine(persons[l]);
                            break;
                        case "2":
                            try
                            {
                                Console.Write("Введите ключ:");
                                string key = Console.ReadLine();
                                int compCount = 0, ind = 0;
                                p = GetPersonByKey(key, out compCount, out ind);

                                if (p != null)
                                    Console.WriteLine($"{p.ToString()} ({compCount} сравнений)");
                                else
                                    Console.WriteLine($"Запись с ключом {key} не найдена ({compCount} сравнений).");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка обработки команды: " + ex.Message);
                            }
                            break;
                        case "3":
                            int count = CollisionCount();
                            Console.WriteLine($"Колличество коллизий равно {count}");
                            break;
                        case "4":
                            try
                            {
                                CrudMenu();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка обработки команды" + ex.Message);
                            }
                            break;
                        default:
                            Console.WriteLine("Неверная команда.");
                            break;
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("Ошибка обработки команды" + ex.Message);
                }
            } while (userCommand != "5");


        }

        private static Person AddPerson(int i)
        {
            Person p = CrudOperations.CreatePerson(persons);
            persons.Add(p);
            AddToHashTable(p.GetHash(M), i);
            return p;
        }

        static void CrudMenu()
        {
            Console.OutputEncoding = Encoding.Unicode;
            string userCommand = null;
            do
            {
                Console.WriteLine("1)Добавить запись");
                Console.WriteLine("2)Изменить запись");
                Console.WriteLine("3)Удалить запись");
                Console.WriteLine("4)Назад");
                Console.Write(">");
                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "1":
                        Person p = AddPerson(persons.Count);
                        Console.WriteLine($"Запись {p} добавлена.");
                        break;
                    case "2":
                        {
                            Console.Write("Введите ключ:");
                            string key = Console.ReadLine();
                            int compCount = 0, index = 0;
                            p = GetPersonByKey(key, out compCount, out index);
                            if (p != null)
                            {
                                // По возможности исправить. Не удалять!
                                /*Console.Write("Паспорт:");
                                SendKeys.SendWait(p.Passport);
                                p.Passport = Console.ReadLine();*/

                                Console.Write("ФИО:");
                                SendKeys.SendWait(p.FIO);
                                p.FIO = Console.ReadLine();

                                Console.Write("Телефон:");
                                SendKeys.SendWait(p.Telefone);
                                p.Telefone = Console.ReadLine();
                            }
                            else
                                Console.WriteLine($"Запись с ключом {key} не найдена ({compCount} сравнений).");
                        }
                        break;
                    case "3":
                        {
                            Console.Write("Введите ключ:");
                            string key = Console.ReadLine();
                            int compCount = 0, index = 0;
                            p = GetPersonByKey(key, out compCount, out index);

                            if (p != null)
                            {
                                List<int> list = hashTable[p.GetHash(M)];
                                list.Remove(index);
                                Console.WriteLine($"Запись с ключом \"{key}\" удалена");
                            }
                            else
                                Console.WriteLine($"Запись с ключом {key} не найдена ({compCount} сравнений).");

                        }
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "4");
        }
        static void AddToHashTable(int hashCode, int index)
        {
            hashTable[hashCode].Add(index);
        }

        static int CollisionCount()
        {
            int max = 0;

            max = int.MinValue;
            for(int i=0;i<hashTable.Length;i++)
            {
                if (hashTable[i].Count > max)
                    max = hashTable[i].Count;
            }

            return max;
        }
        static Person GetPersonByKey(string key, out int compCount, out int index)
        {
            compCount = 0; index = 0;
            int keyHash = Person.GetHashForKey(key, M);

            foreach (int i in hashTable[keyHash])
            {
                compCount++;
                if (persons[i].Passport == key)
                {
                    index = i;
                    return persons[i];
                }
            }

            return null;
        }

 
    }
}
