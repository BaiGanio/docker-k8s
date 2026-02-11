var counter = 0;
var max = args.Length is not 0 ? Convert.ToInt32(args[0]) : -1;
while (max is -1 || counter < max)
{
    TextColorizer($"Counter: {++counter}");
    await Task.Delay(TimeSpan.FromMilliseconds(1_000));
}

static void TextColorizer(string text)
{
	var colors = Enum.GetValues(typeof(ConsoleColor));
	var color = (ConsoleColor)colors.GetValue(Random.Shared.Next(colors.Length));	
	Console.ForegroundColor = color;
	Console.WriteLine($"{text} -> {color}");
	Console.ResetColor();
}