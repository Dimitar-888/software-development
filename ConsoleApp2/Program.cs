using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string title, string description, DateTime deadline)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            IsCompleted = false;
        }
    }

    class Program
    {
        static List<TaskItem> tasks = new List<TaskItem>();

        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("===== TODO MANAGER =====");
                Console.WriteLine("1. Добави нова задача");
                Console.WriteLine("2. Виж всички задачи");
                Console.WriteLine("3. Маркирай задача като изпълнена");
                Console.WriteLine("4. Изтрий задача");
                Console.WriteLine("5. Приключи работа");
                Console.WriteLine("========================");
                Console.Write("Избери опция: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;

                    case "2":
                        ShowTasks();
                        break;

                    case "3":
                        CompleteTask();
                        break;

                    case "4":
                        DeleteTask();
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("Програмата приключи.");
                        break;

                    default:
                        Console.WriteLine("Невалидна опция!");
                        Pause();
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.Clear();

            Console.WriteLine("===== ДОБАВЯНЕ НА ЗАДАЧА =====");

            Console.Write("Заглавие: ");
            string title = Console.ReadLine();

            Console.Write("Описание: ");
            string description = Console.ReadLine();

            Console.Write("Краен срок (дд.ММ.гггг): ");
            DateTime deadline;

            while (!DateTime.TryParse(Console.ReadLine(), out deadline))
            {
                Console.Write("Невалидна дата. Въведи отново: ");
            }

            TaskItem task = new TaskItem(title, description, deadline);

            tasks.Add(task);

            Console.WriteLine("\nЗадачата е добавена успешно!");
            Pause();
        }

        static void ShowTasks()
        {
            Console.Clear();

            Console.WriteLine("===== ВСИЧКИ ЗАДАЧИ =====");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Няма добавени задачи.");
                Pause();
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                TaskItem task = tasks[i];

                Console.WriteLine($"\nЗадача #{i + 1}");
                Console.WriteLine($"Заглавие: {task.Title}");
                Console.WriteLine($"Описание: {task.Description}");
                Console.WriteLine($"Краен срок: {task.Deadline:dd.MM.yyyy}");
                Console.WriteLine($"Статус: {(task.IsCompleted ? "Изпълнена" : "Незавършена")}");
                Console.WriteLine("------------------------");
            }

            Pause();
        }

        static void CompleteTask()
        {
            Console.Clear();

            Console.WriteLine("===== МАРКИРАНЕ КАТО ИЗПЪЛНЕНА =====");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Няма задачи.");
                Pause();
                return;
            }

            ShowTasksWithoutPause();

            Console.Write("Въведи номер на задачата: ");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number >= 1 && number <= tasks.Count)
                {
                    tasks[number - 1].IsCompleted = true;

                    Console.WriteLine("Задачата е маркирана като изпълнена.");
                }
                else
                {
                    Console.WriteLine("Няма задача с този номер.");
                }
            }
            else
            {
                Console.WriteLine("Невалиден номер.");
            }

            Pause();
        }

        static void DeleteTask()
        {
            Console.Clear();

            Console.WriteLine("===== ИЗТРИВАНЕ НА ЗАДАЧА =====");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Няма задачи.");
                Pause();
                return;
            }

            ShowTasksWithoutPause();

            Console.Write("Въведи номер на задачата за изтриване: ");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number >= 1 && number <= tasks.Count)
                {
                    tasks.RemoveAt(number - 1);

                    Console.WriteLine("Задачата е изтрита.");
                }
                else
                {
                    Console.WriteLine("Няма задача с този номер.");
                }
            }
            else
            {
                Console.WriteLine("Невалиден номер.");
            }

            Pause();
        }

        static void ShowTasksWithoutPause()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                TaskItem task = tasks[i];

                Console.WriteLine(
                    $"{i + 1}. {task.Title} - " +
                    $"{(task.IsCompleted ? "Изпълнена" : "Незавършена")}"
                );
            }

            Console.WriteLine();
        }

        static void Pause()
        {
            Console.WriteLine("\nНатисни Enter за продължаване...");
            Console.ReadLine();
        }
    }
}
