
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

    if(userChoice == "A")
    {
        AddATodo(todos);
    }
} while (!isExit);


Console.ReadKey();
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
        foreach (var todo in todos)
        {
            Console.WriteLine("Todo is: " + todo);
        }
    }
    else
    {
        Console.WriteLine("No TODOs have been added yet");
    }
}

void AddATodo(List<string> todos)
{
    var todo = Console.ReadLine();
    if (todos.Contains(todo))
    {
        Console.WriteLine("The description must be unique.");
        return;
    }
    todos.Add(todo);
    Console.WriteLine($"TODO successfully added: {todo}");
}

string? HandleUserInput(string? input, out bool isExit)
{
    switch (input)
    {
        case "S":
            Console.WriteLine("Selected See All Todos");
            isExit =  false;
            return "S";
        case "A":
            Console.WriteLine("Selected Add a Todo");
            isExit = false;
            return "A";
        case "R":
            Console.WriteLine("Selected Remove a Todo");
            isExit = false;
            return "R";
        case "E":
            Console.WriteLine("Selected Exit");
            isExit = true;
            return "E";
        default:
            Console.WriteLine("Incorrect input");
            isExit = false;
            return "";
    }
}
