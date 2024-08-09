// namespace console
// {
//     internal class Program
//     {
//         // If structure
//         static void StudentsGrade()
//         {

//             Console.WriteLine($"What is the student's grade?");
//             //também é possivel usar o "Convert.ToInt32"
//             int grade = int.Parse(Console.ReadLine());
            
//             if(grade < 5)
//             {
//                 Console.WriteLine($"Disapproved");
//             }
//             if(grade >= 5 && grade <= 10)
//             {
//                 Console.WriteLine($"Aproved");
//             }
//             else
//             {
//                 Console.WriteLine($"That's a valid grade");
//             }
//         }
//     }
// }





// int[] numeros = [1, 5, 8, 2, 9];

// for(int i = 0; i < numeros.Length; i++)
// {
// 	Console.WriteLine(numeros[i]);
// }



// Implementar um programa que solicita ao usuário um número e imprime a tabuada desse número

// Console.WriteLine($"Tell me a number");
// int number = int.Parse(Console.ReadLine());

// int[] table = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];

// for(int n = 1; n < table.Length; n++)
// {
//     Console.WriteLine($"{number} x {n} = {number * n}");
// }


// Calcular a soma dos números pares de 1 a 100

// int contador = 1;
// int soma = 0;
// while(contador <= 100)
// {
//     if(contador % 2 == 0)
//     {
//         soma += contador;
//     }
//     contador++;

// }
// Console.WriteLine($"{soma}");

// Desafio
// Crie um programa que gere um número aleatório entre 1 e 10. O usuário deve tentar adivinhar esse número. O programa deve continuar pedindo um palpite até 
// o usuário acerte o número. Ao final, mostre quantas tentivas foram necessárias

// Random randNum = new Random();
// int number = randNum.Next(10);
// int attempts = 0;

// Console.WriteLine($"{number}");
// Console.WriteLine($"Guess the number!");

// int guessedNumber = 0;
// while(guessedNumber != number)
// {
//     guessedNumber = int.Parse(Console.ReadLine());
//     attempts++;
    
//     if(guessedNumber < number)
//     {
//     	Console.WriteLine($"Incorrect! It's a bigger number");
//     	Console.WriteLine($"May you try again!");
//     } 
//     else if(guessedNumber > number)
//     {
//         Console.WriteLine($"Incorrect! It's a smaller number");
//     	Console.WriteLine($"May you try again!");
//     }
//     else
//     {
//         Console.WriteLine($"Congratulations, you're correct!");
//         if(attempts <= 5)
//         {
//             Console.WriteLine($"You tried exactly {attempts} times");
//             Console.WriteLine($"You are a genius!");
//         }
//         if(attempts >= 5)
//         {
//             Console.WriteLine($"You tried exactly {attempts} times");
//             Console.WriteLine($"You are not good at this game");
//         }
//     }
// }