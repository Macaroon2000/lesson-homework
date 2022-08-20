using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Крылов Роман
namespace homework5
{
    internal class Program
    {
        /*
               * 2.Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
               а) Вывести только те слова сообщения, которые содержат не более n букв.
               б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
               в) Найти самое длинное слово сообщения.
               г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
               */
        static bool isThisPermutation(string s1, string s2)
        {
            return s1.Select(Char.ToUpper).OrderBy(x => x).SequenceEqual(s2.Select(Char.ToUpper).OrderBy(x => x));
        }


        static bool isThisPermutation2(string s1, string s2)
        {
            s1 = s1.ToLower();
            s2 = s2.ToLower();

            string news1 = s1[0].ToString();
            string news2 = s2[0].ToString();

            for (int i = 1; i < s1.Length; i++)
                putCharIntoStr(ref news1, s1[i]);

            for (int i = 1; i < s2.Length; i++)
                putCharIntoStr(ref news2, s2[i]);

            if (news1.Equals(news2))
                return true;
            else
                return false;
        }


        static void putCharIntoStr(ref string s, char ch)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > ch)
                {
                    s = s.Insert(i, ch.ToString());
                    break;
                }
                else
                    if (i == s.Length - 1)
                {
                    s += ch.ToString();
                    break;
                }
            }

        }
        public static class MyString
        {
            //Вывод слов короче заданной длины
            public static List<string> Short(string message, int length)
            {
                var returnList = new List<string>();
                foreach (var s in message.Split(new Char[] { ':', ';', '!', ' ', ',', '.', '-', '\n', '\t' }))
                {
                    if (length > s.Length) returnList.Add(s);
                }
                return returnList;
            }

            //Удаление слов с заданным окончанием
            public static List<string> RemoveEndsLetter(string message, char letter)
            {
                var returnList = new List<string>();
                foreach (var s in message.Split(new Char[] { ':', ';', '!', ' ', ',', '.', '-', '\n', '\t' }))
                {
                    if (!s.EndsWith(letter.ToString())) returnList.Add(s);
                }
                return returnList;
            }
            //Первое самое длинное слово из текста:
            public static string LongWord(string message)
            {
                var words = message.Split(new Char[] { ':', ';', '!', ' ', ',', '.', '-', '\n', '\t' });
                var longWord = "";
                foreach (var word in words)
                {
                    if (word.Length > longWord.Length) longWord = word;
                }
                return longWord;
            }



            static void Main(string[] args)
            {

                /*
                * 1.Создать программу, которая будет проверять корректность ввода логина. 
                * Корректным логином будет строка от 2 до 10 символов, 
                * содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой.
                */


                Console.Write("Введите логин: ");
                string login = Console.ReadLine();

                bool correct = true;


                if (login.Length < 2 || login.Length > 10)
                {
                    correct = false;
                    Console.WriteLine("Ошибка: логин меньше 2х или более 10 символов");

                }


                else if (Char.IsDigit(login[0]))
                {
                    correct = false;
                    Console.WriteLine("Ошибка: логин не может начинаться с цифры");

                }


                else
                {


                    for (int i = 0; i < login.Length; i++)
                    {

                        if (!(Char.IsDigit(login[i]) || (login[i] >= 'A' && login[i] <= 'Z') || (login[i] >= 'a' && login[i] <= 'z')))

                        {
                            correct = false;
                            Console.WriteLine("Ошибка: логин должен содержать только цифры и латинские буквы");
                            break;
                        }

                    }

                }


                if (correct)
                {
                    Console.WriteLine("Логин корректный");
                }
                else
                {
                    Console.WriteLine("Логин не корректный");
                }


                // конец первого задания
                Console.WriteLine();




                Console.Write("Введите текст для обработки: ");
                var text = Console.ReadLine();
                Console.Write("\nВведите ограничение по количеству символов: ");
                int nn = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nВывод слов, которые длиной " + nn + " или короче " + nn + " символов:");
                foreach (var cut in MyString.Short(text, ++nn))
                {
                    Console.WriteLine(cut);
                }

                Console.Write("\nИсключить из текста слова со следующим окончанием: ");
                char hhh = Convert.ToChar(Console.ReadLine());

                Console.Write("\nВывод слов, которые не заканчиваются на " + hhh + ": ");
                foreach (var cut in MyString.RemoveEndsLetter(text, hhh))
                {
                    Console.Write(cut + " ");
                }

                Console.WriteLine("\nПервое самое длинное слово: " + MyString.LongWord(text));



                // формируем список (result) из самых длинных слов текста: 

                int MaxWordLength = 0;
                string[] words = text.Split(new Char[] { ':', ';', '!', ' ', ',', '.', '-', '\n', '\t' });
                StringBuilder result = new StringBuilder();
                foreach (var word in words)
                {
                    if (word.Length > MaxWordLength) MaxWordLength = word.Length;
                }
                foreach (string word in words)
                {
                    if (word.Length == MaxWordLength)
                    {
                        result.Append(word.ToLower() + " ");
                    }
                }
                Console.WriteLine("Полученная строка самых длинных слов: " + result);
                // Следующее ЗАДАНИЕ 3


            
                
                    Console.WriteLine("Вас приветствует программа проверки является ли одна строка перестановкой другой.");
                    Console.WriteLine("Введите первую строку сравнения");
                    string first = Console.ReadLine();
                    Console.WriteLine("Введите вторую строку сравнения");
                    string second = Console.ReadLine();



                    Console.WriteLine("Проверим следующие строки: " + first + ", и " + second);

                    if (isThisPermutation(first, second) == true && isThisPermutation2(first, second) == true)
                        Console.WriteLine("Строки являются перестановками друг друга.");
                    else
                        Console.WriteLine("Строки состоят из разных символов.");

                    Console.ReadKey();
                // ЗАДАНИЕ ;
                // Инициализация переменных
                int MaxB = 3; // сколько худших учеников выдать
                double B; // средний балл
                string[] P; // массив учеников
                int q = 0; // количество фактически введенных учеников
                bool corect = false; // признак корректности ввода
                Console.Write("Введите количество учеников: ");
                int N = Convert.ToInt16(Console.ReadLine()); // Количество введенных учеников

                List<string> F = new List<string>(N); // список для сортировки


                if (N >= 10 && N <= 100) // проверяем количество учеников в диапазоне
                {
                    //Все окей
                    corect = true;
                    Console.WriteLine("Вводите ФИО учеников и их оценки по шаблону <Фамилия> <Имя> <оценки> по окончанию ввода нажмите Q и Enter\nПример:Иванов Петр 4 5 3");


                }



                else if (N > 100)
                {

                    Console.WriteLine("Ошибка: Количество учеников больше 100");

                }


                else
                {
                    Console.WriteLine("Ошибка: Количество учеников меньше 10");



                }


                if (corect)
                {
                    P = new string[N]; // создаем новый элемент массива учеников


                    for (int i = 0; i < N; i++) // цикл 
                    {
                        String str = Console.ReadLine(); // процедура выхода через нажатие Q
                        if (str == "Q" || str == "q")
                        {

                            Console.WriteLine("Вы закончили ввод.\nПроизвожу расчет...");
                            break;
                        }

                        else
                        {

                            P[i] = str; // Введенные данные записываем в элемент массива Иванов Петя 5 5 5

                            q++;

                        }

                    }

                    for (int i = 0; i < q; i++) // Цикл для создания списка для сортировки
                    {


                        string[] arr = P[i].Replace("  ", " ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // Разбиваем строку в массив в качестве разделителя пробел и убираем лишние двойные пробелы
                        B = (Convert.ToDouble(arr[2]) + Convert.ToDouble(arr[3]) + Convert.ToDouble(arr[4])) / 3; // подсчитываем средний балл
                        F.Add(B + " " + arr[0] + " " + arr[1]); // Добавляем новый элемент список где в начале стоит средний балл
                    }

                    Console.WriteLine("Худшие ученики:");

                    F.Sort(); // Сортируем список по возрастанию 
                    double curB = 5; // нужно для сравнения
                    double curA = 0; // нужно для сравнения
                    for (int i = 0; i < F.Count; i++) // цикл проганяем отсортированный список

                    {
                        string[] arr = F[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // разбиваем элемент списка в массив в качестве разделителя пробел
                        curA = Convert.ToDouble(arr[0]); // присваиваем текущее значение среднего балла промежуточной переменной
                        if (MaxB <= 0)  // Если количество худших учеников стало превышать 3
                        {
                            if (curA > curB) // Но при этом значение среднего балла больше чем у предыдущего ученика
                            {

                                break; // То выходим
                            }


                        }


                        Console.WriteLine("{0} {1} : средний балл {2}", arr[1], arr[2], arr[0]); // Выводим худших учеников
                        curB = Convert.ToDouble(arr[0]); // Присваиваем текущее значение среднего балла текущей переменной 
                        MaxB--; // Уменьшаем количество вывода учеников

                    }
                }

            }


        }
    }
}