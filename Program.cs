
    List<string> TodoList = new List<string>();

    
        Menu option;
        do
        {
            ShowMainMenu();
            option = (Menu)ReadNumber();
            if (option == Menu.Add)
            {
                ShowMenuAddOption();
            }
            else if (option == Menu.Remove)
            {
                ShowRemoveOption();
            }
            else if (option == Menu.List)
            {
                ShowPendingListOption();
            }
        } while (option != Menu.Exit);
    
    /// <summary>
    /// Show the list main options.
    /// </summary>
    void ShowMainMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Insert a option number: ");
        Console.WriteLine("1. New task");
        Console.WriteLine("2. Remove task");
        Console.WriteLine("3. Pending tasks");
        Console.WriteLine("4. Exit");
    }

    int ReadNumber()
    {
        string line = Console.ReadLine();
        int number;
        bool success = int.TryParse(line, out number);
        if (success)
        {
            return number;
        }
        else
        {
            Console.WriteLine("Error... You needed enter a number");
        }
        return number;
    }

    void ShowRemoveOption()
    {
        try
        {
            Console.WriteLine("Insert the number of tasks to remove:");
            ShowList();

            int line = ReadNumber();

            int indexToRemove = line - 1;
            if (indexToRemove > TodoList.Count - 1 || indexToRemove < 0)
            {
                Console.WriteLine("Invalid task number.");
            }
            else
            {
                if (indexToRemove > -1 && TodoList.Count > 0)
                {
                    string taskToRemove = TodoList[indexToRemove];
                    TodoList.RemoveAt(indexToRemove);
                    Console.WriteLine($"Task {taskToRemove} removed.");
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Error removing the task.");
        }
    }

    void ShowMenuAddOption()
    {
        try
        {
            Console.WriteLine("Insert the task name: ");
            string newTask = Console.ReadLine();
            TodoList.Add(newTask);
            Console.WriteLine("Task registered");
        }
        catch (Exception)
        {
            Console.WriteLine("Error adding the new task...");
        }
    }

    void ShowPendingListOption()
    {
        if (TodoList?.Count > 0)
            ShowList();
        else
            Console.WriteLine("You don't have pending tasks");
    }

    void ShowList()
    {
        Console.WriteLine("----------------------------------------");
        int index = 0;
        TodoList.ForEach(item =>
        {
            index++;
            Console.WriteLine($"{index}. {item}");
        });

        Console.WriteLine("----------------------------------------");
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }