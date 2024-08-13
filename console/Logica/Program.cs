// Console.WriteLine("Tell me a number");

// if (int.TryParse(Console.ReadLine(), out int number))
// {
//     bool choosedNumber(int num)
//     {
//         return num % 2 == 0;
//     }

//     if (choosedNumber(number))
//     {
//         Console.WriteLine("The number is even!");
//     }
//     else
//     {
//         Console.WriteLine("The number is odd!");
//     }
// }
// else
// {
//     Console.WriteLine("Please enter a valid number.");
// }

string[] names = new string[5];

        // Cadastro dos nomes
        for (int i = 0; i < names.Length; i++)
        {
            Console.Write($"Type a name {i + 1}: ");
            names[i] = Console.ReadLine();
        }

        // Ordenação dos nomes usando Bubble Sort
        for (int i = 0; i < names.Length - 1; i++)
        {
            for (int j = 0; j < names.Length - i - 1; j++)
            {
                if (string.Compare(names[j], names[j + 1]) > 0)
                {
                    // Troca os nomes
                    string temp = names[j];
                    names[j] = names[j + 1];
                    names[j + 1] = temp;
                }
            }
        }

        // Exibe os nomes em ordem alfabética
        Console.WriteLine("\nNames in the alphabetical order:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }