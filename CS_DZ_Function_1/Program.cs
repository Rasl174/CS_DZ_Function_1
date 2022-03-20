using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DZ_Function_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            string[] names = { };
            string[] positions = { };

            Console.WriteLine("Это программа для ведения досье\n");

            while (isExit == false)
            {
                Console.WriteLine("Для добавления досье введите 1 ");
                Console.WriteLine("Для просмотра всех досье введите 2 ");
                Console.WriteLine("Для удаления досье введите 3");
                Console.WriteLine("Для поиска досье по фамилии введите 4");
                Console.WriteLine("Для выхода введите 5 или exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateDossier(ref names,ref positions);
                        break;
                    case "2":
                        ShowAllDossier(names, positions);
                        break;
                    case "3":
                        DeleteDossier(ref names,ref positions);
                        break;
                    case "4":
                        FindDossier(names, positions);
                        break;
                    case "5":
                    case "exit":
                        isExit = true;
                        break;
                }
            }
        }

        static void CreateDossier(ref string[] name,ref string[] position)
        {
            string[] newName = new string[name.Length + 1];
            string[] newPosition = new string[position.Length + 1];

            for (int i = 0; i < name.Length; i++)
            {
                newName[i] = name[i];
                newPosition[i] = position[i];
            }

            name = newName;
            position = newPosition;

            Console.WriteLine("Введите ФИО: ");
            name[name.Length - 1] = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            position[position.Length - 1] = Console.ReadLine();
            Console.Clear();
        }

        static void ShowAllDossier(string[] names, string[] positions)
        {
            if(names.Length > 0 && positions.Length > 0)
            {
                Console.WriteLine("Все досье: ");

                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine((i + 1) + " - " + names[i] + " - " + positions[i]);
                }
            }
            else
                Console.WriteLine("Здесь нет еще ни одного досье!");
            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteDossier(ref string[] name,ref string[] position)
        {
            if(name.Length > 0 && position.Length > 0)
            {
                string[] newArrayName = new string[name.Length - 1];
                string[] newArrayPosition = new string[position.Length - 1];

                Console.WriteLine("Введите номер досье который хотите удалить: ");
                int userInput = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < userInput - 1; i++)
                {
                    newArrayName[i] = name[i];
                    newArrayPosition[i] = position[i];
                }
                for (int i = userInput; i < position.Length; i++)
                {
                    newArrayName[i - 1] = name[i];
                    newArrayPosition[i - 1] = position[i];
                }

                name = newArrayName;
                position = newArrayPosition;
            }
            else
                Console.WriteLine("Здесь нет еще ни одного досье!");
            
            Console.ReadKey();
            Console.Clear();
        }

        static void FindDossier(string[] name, string[] position)
        {
            if(name.Length > 0 && position.Length > 0)
            {
                Console.WriteLine("Введите фамилию: ");
                string userInput = Console.ReadLine();
                int indexDossier = 0;

                indexDossier = Array.FindIndex(name, fullName => fullName.ToLower().Contains(userInput.ToLower()));

                if (indexDossier == -1)
                {
                    Console.WriteLine("Такое досье не было найдено!");
                }
                else
                {
                    Console.WriteLine("Досье найдено!");
                    Console.WriteLine((indexDossier + 1) + " - " + name[indexDossier] + " - " + position[indexDossier]);
                }
            }
            else
                Console.WriteLine("Здесь еще нет ни одного досье!");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
