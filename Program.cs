using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_Valery
{
    class Task_1
    // Проверка корректности ввода логина
    {
        StringBuilder login;

        public Task_1()
        {
            bool flag = true;
            
            do
            {
                Console.Write("Введите логин: ");
                login = new StringBuilder(Console.ReadLine());

                if (check_length() && check_digit())
                    flag = false;
            }
            while (flag);

            Console.WriteLine("Ok");
        }

        bool check_digit()
        {
            if (char.IsDigit(login[0]))
            {
                Console.WriteLine("Логин не должен начинаться на цифру");
                return false;
            }
            return true;
        }

        bool check_length()
        {
            if (login.Length < 2 || login.Length > 10)
            {
                Console.WriteLine("Логин должен быть длиной больше одного символа и меньшн одинадцати");
                return false;
            }
            return true;
        }
    }

    class Task_2
    {
        string str;
        string[] str_parts;

        public Task_2(int n, char w)
        {
            str = "Предложение с разными, знаками! пунктуации. И разным? количеством букв: в словах, вот и все?!";
            Console.WriteLine($"Начальное предложение:\n{str}");
            Console.WriteLine($"Слова которые имеют меньше {n} букв:");
            word_with_number_of_letters(n);
            Console.WriteLine($"Слова в которых есть буква '{w}':");
            word_without_letter(w);
        }

        void word_with_number_of_letters(int n)
        {
            char[] delimeter = {' ', ',', '.', ':', '?', '!'};
            str_parts = str.Split(delimeter);
            for (int i = 0; i < str_parts.Length; i++)
                if (str_parts[i].Length < n && str_parts[i].Length != 0)
                    Console.WriteLine(str_parts[i]);
        }

        void word_without_letter(char w)
        {
            for (int i = 0; i < str_parts.Length; i++)
                for (int k = 0; k < str_parts[i].Length; k++)
                    if (str_parts[i][k] == w && str_parts[i].Length != 0)

        }
    }

    class Program
    {
        static void Task_1_start()
        {
            Task_1 start = new Task_1();
        }

        static void Task_2_start()
        {
            //слова с количеством букв не более 5
            //удалить слова в которых есть буква 'a';
            Task_2 start = new Task_2(5, 'a');
        }

        static void Main(string[] args)
        {
            //Task_1_start();
            Task_2_start();

            Console.ReadKey();
        }
    }
}
