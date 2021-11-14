using System;

namespace OOP_Lab4
{
    class Set
    {
        public int[] elements;
        public Set(int num)
        {
            elements = new int[num];
            for (int i = 0; i < num; ++i)
                elements[i] = -666;
        }
        int counter = 0;

        public void Show()
        {
            for (int i = 0; i < this.counter; ++i)
                Console.Write(this.elements[i] + " ");
            Console.WriteLine();
            return;
        }
        public void Add(int num)//добавление элемента
        {
            bool check = false;
            foreach (int el in elements)
                if (num == el)
                    check = true;
            if (!check)
            {
                elements[counter] = num;
                ++counter;
            }
        }

        public void Remove(int num)//удаление элемента
        {
            for (int i = 0; i < counter; ++i)
                if (this.elements[i] == num)
                {
                    for (int j = 0; j + i + 1 < counter; ++j)
                        elements[i + j] = elements[i + j + 1];
                    elements[counter] = -666;
                    --counter;
                }
        }

        public Set Union(Set B)//объединение множеств
        {
            Set buff = B;
            foreach (int numA in this.elements)
                foreach (int numB in B.elements)
                    if (numA == numB)
                        buff.Remove(numB);
            Set C = new Set(this.counter + buff.counter);
            for (int i = 0; i < this.counter; ++i)
                C.elements[i] = this.elements[i];
            for (int i = 0; i < B.counter; ++i)
                C.elements[this.counter + i] = B.elements[i];
            return C;
        }

        public Set Difference(Set B)//Элементы из А, которых нет в В
        {
            foreach (int numA in this.elements)
                foreach (int numB in B.elements)
                    if (numA == numB)
                        this.Remove(numB);
            Set C = new Set(this.counter);
            C = this;
            return C;
        }

        public Set Intersection(Set B)//элементы, которые есть и в А, и в В
        {
            Set buff = new Set(this.counter + B.counter);
            foreach (int numA in this.elements)
                foreach (int numB in B.elements)
                    if (numA == numB)
                        buff.Add(numA);
            Set C = new Set(buff.counter);
            for (int i = 0; i < buff.counter; ++i)
                C.elements[i] = buff.elements[i];
            return C;
        }

        public bool Subset(Set B)//является ли В подмножеством А?
        {
            bool answer = true;
            foreach (int numA in this.elements)
            {
                if (answer)
                    foreach (int numB in B.elements)
                    {
                        if (numB != numA)
                            answer = false;
                        else
                        {
                            answer = true;
                            break;
                        }
                    }
            }
            return answer;
        }

        public static Set operator ++(Set operator1)//добавление случайного элемента во множество (в диапазоне от -15 до 45)
        {
            Random random1 = new Random();
            operator1.Add(random1.Next(-15, 45));
            return operator1;
        }

        public static Set operator +(Set operator1, Set operator2)//объединенте множеств
        {
            Set operator3 = operator1;
            Set operator4 = operator2;
            return operator3.Union(operator4);
        }

        public static bool operator >=(Set operator1, Set operator2)// 0 - op1<op2; 1 - op1>op2
        {
            if (operator1.Subset(operator2))
                return false;
            else
                return true;
        }

        public static bool operator <=(Set operator1, Set operator2)// 0 - op1<op2; 1 - op1>op2
        {
            if (operator1.Subset(operator2))
                return true;
            else
                return false;
        }

        public static implicit operator int(Set operator1)//мощность множества
        {
            return operator1.counter;
        }

        public static int operator %(Set operator1, int operator2)//доступ к элементу в позиции
        {
            return operator1.elements[operator2];
        }

        class Owner                           //Owner этого класса
        {
            readonly string name            = "Евгений";
            readonly string organization    = "BSTU";
            readonly int    idOwner         = 15;
        }
        public class Date//вложенный класс с функцией получения теку
        {
            private DateTime actualTime = new DateTime(2020, 11, 7);
            public static void GetActualTime()
            {
                Console.WriteLine(DateTime.Now);
            }
        }

        static public class StaticOperation : System.Object
        {
            static public int Summ(Set set, int pos1, int pos2)//сумма 2 элементов в заданных позициях
            {
                if ((pos1 > set.counter) || (pos2 > set.counter))
                {
                    return -666;
                }
                int result = set.elements[pos1];
                result += set.elements[pos2];
                return result;
            }

            static public int Range(Set set)//разница между максимальным и минимальным значением
            {
                if (set.counter == 0)
                    return 0;
                int max = -320;
                int min = 320;
                for (int i = 0; i < set.counter; ++i)
                {
                    if (set.elements[i] <= min) min = set.elements[i];
                }
                for(int i = 0; i < set.counter; ++i)
                {
                    if (set.elements[i] >= max) max = set.elements[i];
                }
                return max - min;
            }

            static public int Size(Set set)//размер множества
            {
                return set.counter;
            }

            static public string Encrypt(string str)//шифрование строки
            {
                char[] result = new char[str.Length];
                for (int i = str.Length; i >= 0; ++i)
                {
                    result[str.Length - i] = str[i];
                }
                string answer = new string(result);
                return answer;
            }

            static public bool Orderliness(Set set)//является ли упорядоченным...
            {
                bool toHigh = true;//...по возрастанию
                bool toLow = true;//...по убыванию

                for (int i = 1; i < set.counter; ++i)
                {
                    if (set.elements[i] > set.elements[i - 1])
                        toHigh = false;
                    if (set.elements[i] < set.elements[i - 1])
                        toLow = false;
                }

                if (toHigh || toLow)
                    return true;
                else
                    return false;
            }
        }
    }


    class Program
    {
        public static void Main()
        {
            Set set1 = new Set(15);//создаю 2 множества, частично их заполняю
            Set set2 = new Set(10);

            set1.Add(12); set1.Add(13); set1.Add(14); set1.Add(15); set1++;
            ++set2; set2.Add(13); set2.Add(13); set2.Add(24); set2.Add(15); set2.Add(25);
            set1.Show();
            set2.Show();
            Console.WriteLine("---");
            {
                Set setinter = set1.Intersection(set2);//проверка работы функции (эл., которые есть и в А, и в В)
                foreach (int ch in setinter.elements)
                    Console.Write(ch + " ");
            }
            Console.WriteLine("\n---");
           /*{
                Set set1and2 = set1 + set2;
                foreach (int ch in set1and2.elements)
                    Console.Write(ch + " ");
            }*/
            Console.WriteLine("\n---");
            {
                Set.Date.GetActualTime();
            }
            Console.WriteLine("---");
            {
                Console.Write("Упорядочено ли множество 1: ");
                if (Set.StaticOperation.Orderliness(set1))
                    Console.WriteLine("Да");
                else
                    Console.WriteLine("Нет");
            }
            Console.WriteLine("---");
            {
                Console.Write("Разница между максимальным и минимальным элементами множества 2: ");
                Console.WriteLine(Set.StaticOperation.Range(set2));
            }
            Console.WriteLine("---");
            int a = set1;
        }
    }
}
