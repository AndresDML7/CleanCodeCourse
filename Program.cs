List<string> TaskList = new List<string>();

int menuSelected = 0;

do
{
    menuSelected = ShowMainMenu();
    if ((Menu) menuSelected == Menu.Add)
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
} 
while ((Menu)menuSelected != Menu.Exit) ;

/// <summary>
/// Show the task options
/// </summary>
/// <returns>Returns option indicated by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string optionSelected = Console.ReadLine();
    return Convert.ToInt32(optionSelected);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowTaskList();

        string taskNumber = Console.ReadLine();

        // Remove one position because array starts in 0.
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

void ShowMenuAdd()
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

void ShowMenuTaskList()
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

void ShowTaskList()
{
    Console.WriteLine("----------------------------------------");
    var taskIndex = 0;
    TaskList.ForEach(t => Console.WriteLine($"{++taskIndex}. {t}"));
    Console.WriteLine("----------------------------------------");
}

enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
