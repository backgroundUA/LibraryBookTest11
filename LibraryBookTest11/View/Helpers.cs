using System;


namespace LibraryBookTest11.View
{
    partial class Helpers
    {
        public static void WriteHelpMessage()
        {
            Console.WriteLine($"{Command.AddBook} - Добавить новую книгу;");
            Console.WriteLine($"{Command.GetAllBooks} - Вывести полный списокдоступных книг; ");
            Console.WriteLine($"{Command.GiveBook} - Выдать книгу;");
            Console.WriteLine($"{Command.Exit} - Выход из приложения;");
            Console.WriteLine($"{Command.Help} - Помощь;");
            Console.WriteLine();
        }

        public  static void WriteErrorMessage(string message)
        {
            Console.WriteLine($"ОШИБКА! {message}");
        }

        public static string ReadNotEmptyLine(string title)
        {
            while (true)
            {
                Console.Write($"Введите {title}: ");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                WriteErrorMessage($"Значение {title} не должен быть пустым");
            }
        }

        public static int ReadIntLine(string title)
        {
            while (true)
            {
                var input = ReadNotEmptyLine(title);
                if (int.TryParse(input, out int result))
                {
                    return result;
                }

                WriteErrorMessage($"Введите целое число");
            }
        }

        public static Command ReadCommand()
        {
            while (true)
            {
                var input = ReadNotEmptyLine("команду");
                if (Enum.TryParse(input, true, out Command command))
                {
                    return command;
                }

                WriteErrorMessage("Не известная команда. Введите help для подсказки");
            }
        }
    }
}
