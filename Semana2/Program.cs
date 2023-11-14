
#region Exemplos aulas
// aqui temos um array, assunto da próxima aula
string[] colecao= { "Item1", "Item2", "Item3", "Item4" };
foreach (string item in colecao)
{
 Console.WriteLine(item );
}
#endregion

#region Atividades

/*
1. Escreva um programa em C# que imprime todos os números que são
divisíveis por 3 ou por 4 entre 0 e 30;

2. Faça um programa em C# que imprima os primeiros números da série de
Fibonacci até passar de 100. A série de Fibonacci é a seguinte: 0, 1, 1, 2, 3,
5, 8, 13, 21 etc... Para calculá-la, o primeiro elemento vale 0, o segundo vale
1, daí por diante, o n-ésimo elemento vale o (n-1)-ésimo elemento somado
ao (n-2)-ésimo elemento (ex: 8 = 5 + 3)

3. Faça um programa que imprima a seguinte tabela até o nível 8:*/

Console.WriteLine("\n*******Atividade 1*********"); 

  for (int i = 1; i < 30; i++)
    {

        if (4 % i == 0 || 3 %  i == 0 )
        {

            Console.WriteLine(i); 
        }
    }



   Console.WriteLine("\n*******Atividade 2*********"); 

   int limite = 100;

        int a = 0, b = 1, c = 0;

        Console.WriteLine("Os primeiros números da série de Fibonacci até passar de 100 são:");

        for (int i = 1; i <= limite; i++)
        {
            Console.Write(c + "-");

            c = a + b;
            a = b;
            b = c;
        }

        Console.WriteLine();

Console.WriteLine("\n*******Atividade 3*********"); 


#endregion



Console.WriteLine("\n*******Exercicio parte II da aula*********"); 
#region 



Console.WriteLine("\nDigite seu nome"); 
String name = Console.ReadLine();



#endregion





