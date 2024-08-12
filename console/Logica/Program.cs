Console.WriteLine("Tell me a number");

if (int.TryParse(Console.ReadLine(), out int number))
{
    bool choosedNumber(int num)
    {
        return num % 2 == 0;
    }

    if (choosedNumber(number))
    {
        Console.WriteLine("The number is even!");
    }
    else
    {
        Console.WriteLine("The number is odd!");
    }
}
else
{
    Console.WriteLine("Please enter a valid number.");
}