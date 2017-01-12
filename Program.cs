using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
    // 1)Вывести только те слова сообщения, которые содержат не более чем n букв
    // 2) Удалить из сообщения все слова, в которых есть заданная буква
    // 3) Найти самое длинное слово сообщения (вывожу кол букв в таком слове)
    // 4) Найти все слова с таким количеством букв
    {
        string str;
        string[] str_parts;

        public Task_2(int n, char w)
        {
            str = "Предложение с разными, знаками! пунктуации. И разным? количеством букв: в словах, вот и все?!";
            Console.WriteLine($"Начальное предложение:\n{str}");
            Console.WriteLine($"Слова которые имеют меньше {n} букв:");
            word_with_number_of_letters(n);
            Console.WriteLine($"Слова без буквы '{w}':");
            word_without_letter(w);
            word_with_greatest_num_of_letter();
        }

        void word_with_greatest_num_of_letter()
        {
            int max_letter = str_parts[0].Length, count = 0;

            for (int i = 1; i < str_parts.Length; i++)
                if (str_parts[i].Length > max_letter)
                    max_letter = str_parts[i].Length;

            for (int i = 0; i < str_parts.Length; i++)
                if (str_parts[i].Length == max_letter)
                    count++;

            Console.WriteLine($"Наибольшее количество букв в слове: {max_letter}");
            Console.Write($"Слов с таким количеством букв: {count}");
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
            int[] empty = new int[str_parts.Length];
            int count = 0, count2 = 0;
            string[] new_str;
            for (int i = 0; i < str_parts.Length; i++)
                empty[i] = i; // Заполнили поле длиной(кол. слов в str) значениями порядкового номера

            for (int i = 0; i < str_parts.Length; i++)
                if (str_parts[i].IndexOf(w) != -1 | str_parts[i] == "")
                {
                    empty[i] = -1; count++;
                }

            new_str = new string[str_parts.Length-count];

            for (int i = 0; i < str_parts.Length; i++)
                if (empty[i] != -1)
                {
                    new_str[count2] = str_parts[i]; count2++;
                }

            for (int i = 0; i < new_str.Length; i++)
                Console.WriteLine(new_str[i]);
        }
    }

    class Task_3
    {
        string fname = "Two_lines.txt";
        StreamReader str;
        string[] str_lines;

        public Task_3()
        {
            read_lines(); // считали все строки в str_lines[2]
            reshafle();
        }

        void reshafle()
        {
            int count = 0;
            int n_letter = str_lines[0].Length;
            foreach (char c in str_lines[1])
                if (str_lines[0].IndexOf(c) != -1)
                    count++;
            if (count == n_letter)
                Console.WriteLine("Вторая строка является перестановкой первой строки");
            else Console.WriteLine("Вторая строка не является перестановкой первой строки");
        }

        void read_lines()
        {
            str = new StreamReader(fname);
            int n_lines = File.ReadAllLines(fname).Length;
            str_lines = new string[n_lines];
            for (int i = 0; i < n_lines; i++)
                str_lines[i] = str.ReadLine();

            for (int i = 0; i < n_lines; i++)
                Console.WriteLine(str_lines[i]);

            str.Close();
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
            Task_2 start = new Task_2(5, 'а');
        }

        static void Task_3_start()
        {
            Task_3 start = new Task_3();
        }

        static void Main(string[] args)
        {
            Task_1_start();
            Task_2_start();
            Task_3_start();

            Console.ReadKey();
        }
    }
}
