using System;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myList = GetList();
            ShowList(myList);
            Console.WriteLine(Fold(myList, '+', 1));
            Console.WriteLine(Fold(myList, '*', 1));



            Console.ReadLine();
        }

        public static string[] GetList()
        {
            Console.WriteLine("Enter a list:");

            return Console.ReadLine().Split(" ");
        }

        public static void ShowList(string[] list)
        {
            Console.WriteLine("[" + string.Join(",", list) + "]");
        }

        public static string Head(string[] list)
        {
            return list[0];
        }

        public static string[] Tail(string[] list)
        {
            string[] newList = new string[list.Length - 1];

            for (int i = 0; i < newList.Length; i++)
            {
                newList[i] = list[i + 1];
            }

            return newList;
        }

        public static string[] Map(string[] list, char operation, int operand)
        {
            string[] newList = new string[list.Length];

            for (int i = 0; i < list.Length; i++)
            {
                int value = int.Parse(list[i]);

                switch (operation)
                {
                    case '+':
                        value = value + operand;
                        break;
                    case '-':
                        value = value - operand;
                        break;
                    case '/':
                        value = value / operand;
                        break;
                    case '*':
                        value = value * operand;
                        break;
                }

                newList[i] = value.ToString();
            }

            return newList;
        }

        public static int Fold(string[] list, char operation, int operand)
        {

            int value = operand;

            switch (operation)
            {
                case '+':
                    value = value + int.Parse(Head(list));
                    break;
                case '-':
                    value = value - int.Parse(Head(list));
                    break;
                case '/':
                    value = value / int.Parse(Head(list));
                    break;
                case '*':
                    value = value * int.Parse(Head(list));
                    break;
            }

            if (list.Length == 1)
            {
                return value;
            }
            else
            {
                return Fold(Tail(list), operation, value);
            }
        }


    }
}
