using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training_4
{
    internal class Program
    {
        static void Main(string[] args)

        {
          // Инициализация переменных
            int MaxB = 3; // сколько худших учеников выдать
            double B; // средний балл
            string[] P; // массив учеников
            int q = 0; // количество фактически введенных учеников
            bool correct = false; // признак корректности ввода
            Console.Write("Введите количество учеников: ");
            int N = Convert.ToInt16(Console.ReadLine()); // Количество введенных учеников

            List<string> F = new List<string>(N); // список для сортировки


            if (N >= 10 && N <= 100) // проверяем количество учеников в диапазоне
            {
                //Все окей
                correct = true;
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


            if (correct)
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
                    B = (Convert.ToDouble(arr[2]) + Convert.ToDouble(arr[3]) + Convert.ToDouble(arr[4]))/3; // подсчитываем средний балл
                    F.Add(B + " " + arr[0] + " " + arr[1]); // Добавляем новый элемент список где в начале стоит средний балл
                }

                Console.WriteLine("Худшие ученики:");
                
                F.Sort(); // Сортируем список по возрастанию 
                double curB =5; // нужно для сравнения
                double curA =0; // нужно для сравнения
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


