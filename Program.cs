
Console.WriteLine("Hello!");

var todos = new List<string>();
bool isExit;

do
{
    Console.WriteLine("What do you want to do?");
    DisplayUserChoices();

    var userInput = Console.ReadLine()?.ToUpper();
    var userChoice = HandleUserInput(userInput, out isExit);

    if (userChoice == "S")
    {
        SeeAllTodos(todos);
    }

    if (userChoice == "A")
    {
        bool isAdded;
        do
        {
            AddATodo(todos, out isAdded);
        } while (!isAdded);
    }

    if (userChoice == "R")
    {
        bool isRemovedOrEmpty = false;
        do
        {
            RemoveATodo(todos, out isRemovedOrEmpty);
        } while (!isRemovedOrEmpty);
    }
} while (!isExit);

void DisplayUserChoices()
{
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}

void SeeAllTodos(List<string> todos)
{
    if (todos.Count > 0)
    {
        var currentTodo = 1;
        foreach (var todo in todos)
        {
            Console.WriteLine($"{currentTodo}. " + todo);
            ++currentTodo;
        }
    }
    else
    {
        Console.WriteLine("No TODOs have been added yet");
    }
}

void AddATodo(List<string> todos, out bool isTodoAdded)
{
    Console.WriteLine("Enter the TODO description:");
    var todo = Console.ReadLine();

    if (todos.Contains(todo))
    {
        Console.WriteLine("The description must be unique.");
        isTodoAdded = false;
        return;
    }

    if (string.IsNullOrEmpty(todo))
    {
        Console.WriteLine("The description cannot be empty.");
        isTodoAdded = false;
        return;
    }

    todos.Add(todo);

    isTodoAdded = true;
    Console.WriteLine($"TODO successfully added: {todo}");
}

void RemoveATodo(List<string> todos, out bool isRemovedOrEmpty)
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
        isRemovedOrEmpty = true;
        return;
    }

    Console.WriteLine("Select the index of the TODO you want to remove:");
    var userSelectedIndex = Console.ReadLine();

    if (int.TryParse(userSelectedIndex, out int result))
    {
        if (result > todos.Count)
        {
            Console.WriteLine("Selected index cannot be empty.");
            isRemovedOrEmpty = false;
            return;
        }
        string removeItem = todos[result - 1];
        todos.RemoveAt(result - 1);

        Console.WriteLine("TODO removed: " + removeItem);
        isRemovedOrEmpty = true;
        return;
    }

    isRemovedOrEmpty = true;
    Console.WriteLine("remove todo here");
}

string? HandleUserInput(string? input, out bool isExit)
{
    switch (input)
    {
        case "S":
            isExit = false;
            return "S";
        case "A":
            isExit = false;
            return "A";
        case "R":
            isExit = false;
            return "R";
        case "E":
            isExit = true;
            return "E";
        default:
            Console.WriteLine("Incorrect input");
            isExit = false;
            return null;
    }
}
