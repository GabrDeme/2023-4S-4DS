// Exercício I
// Escreva um programa que peça ao usuário para digitar um número inteiro e informe se o
// número é par ou ímpar. Utilize uma estrutura condicional if/else para realizar o teste.

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

// Exercício II
// Crie um programa que permita que o usuário cadastre 5 nomes em um vetor. Após o
// cadastro, o programa deve imprimir na tela os nomes cadastrados em ordem alfabética.
// Utilize um laço for para o cadastro e um método de ordenação de sua preferência (por
// exemplo, bubble sort) para ordenar os nomes.

// string[] names = new string[5];

//         // Cadastro dos nomes
//         for (int i = 0; i < names.Length; i++)
//         {
//             Console.Write($"Type a name {i + 1}: ");
//             names[i] = Console.ReadLine();
//         }

//         // Ordenação dos nomes usando Bubble Sort
//         for (int i = 0; i < names.Length - 1; i++)
//         {
//             for (int j = 0; j < names.Length - i - 1; j++)
//             {
//                 if (string.Compare(names[j], names[j + 1]) > 0)
//                 {
//                     // Troca os nomes
//                     string temp = names[j];
//                     names[j] = names[j + 1];
//                     names[j + 1] = temp;
//                 }
//             }
//         }

//         // Exibe os nomes em ordem alfabética
//         Console.WriteLine("\nNames in the alphabetical order:");
//         foreach (var name in names)
//         {
//             Console.WriteLine(name);
//         }

// Exercício III
// Crie um programa que calcule a soma dos números pares de um vetor de 10 elementos.
// Utilize um laço for para percorrer o vetor e uma estrutura condicional if para identificar
// os números pares.

// int[] vetor = new int[10];
//         int soma = 0;

//         // Preencher o vetor (pode ser com valores fixos ou entrada do usuário)
//         for (int i = 0; i < vetor.Length; i++)
//         {
//             Console.Write($"Type {i + 1}º element: ");
//             vetor[i] = int.Parse(Console.ReadLine());
//         }

//         // Calcular a soma dos números pares
//         for (int i = 0; i < vetor.Length; i++)
//         {
//             if (vetor[i] % 2 == 0)
//             {
//                 soma += vetor[i];
//             }
//         }

//         // Exibir o resultado
//         Console.WriteLine($"The sum of the even numbers is: {soma}");

// Exercício IV
// Crie uma função que recebe um número como parâmetro e retorna a tabuada desse
// número até o número 10. Utilize um laço for para gerar os múltiplos do número.

Console.WriteLine($"Tell me a number");
int number = int.Parse(Console.ReadLine());

int[] table = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

for(int n = 1; n < table.Length; n++)
{
    Console.WriteLine($"{number} x {n} = {number * n}");
}