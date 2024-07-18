Console.WriteLine("Hello!");
Console.WriteLine("What do you want to do?");
DisplayUserChoices();



Console.ReadKey();
void DisplayUserChoices()
{
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}
