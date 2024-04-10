﻿using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string optionSelected = Console.ReadLine();
            return Convert.ToInt32(optionSelected);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowTaskList();

                string taskNumber = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskNumber) - 1;

                if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
                {
                    Console.WriteLine("El número de tarea ingresado no es válido.");
                }
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string removedTask = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea '{removedTask}' eliminada");
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al remover la tarea.");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList?.Count > 0)
            {
                ShowTaskList();
            } 
            else
            {
                Console.WriteLine("No hay tareas por realizar");
            }
        }

        public static void ShowTaskList()
        {
            Console.WriteLine("----------------------------------------");
            var taskIndex = 0;
            TaskList.ForEach(t => Console.WriteLine($"{++taskIndex}. {t}"));
            Console.WriteLine("----------------------------------------");
        }

        public enum Menu
        {
            Add = 1,
            Remove = 2,
            List = 3, 
            Exit = 4
        }
    }
}
