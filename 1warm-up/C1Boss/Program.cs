
HelpMe.PrintHeader();

string choice = "";
int counter = 1;

while (choice != "exit")
{
    HelpMe.PrintChoice(counter);

    choice = Console.ReadLine()?.Trim().ToLower();

    switch (choice)
    {
        case "0":
            HelpMe.Print(HelpMe.GetPlanets());
            break;

        case "exit":
            Console.WriteLine();
            Console.WriteLine(HelpMe.Center("🔥 You rest at the bonfire. Farewell. 🔥"));
            break;

        default:
            Console.WriteLine();
            Console.WriteLine(HelpMe.Center("✖ The abyss rejects your input... He-he ;/"));
            break;
    }

    counter++;
}

HelpMe.PrintFooter();