Console.WriteLine("\n*************************** Resposta questão 2 ***********************");
#region Resposta da questão 2
    // sbyte: Armazena inteiros de 8 bits com sinal (-128 a 127)
    sbyte mySByte = -50;

    // byte: Armazena inteiros de 8 bits sem sinal (0 a 255)
    byte myByte = 200;

    // short (ou Int16): Armazena inteiros de 16 bits com sinal (-32,768 a 32,767)
    short myShort = 1500;

    // ushort (ou UInt16): Armazena inteiros de 16 bits sem sinal (0 a 65,535)
    ushort myUShort = 60000;

    // int (ou Int32): Armazena inteiros de 32 bits com sinal (-2,147,483,648 a 2,147,483,647)
    int myInt = -200000;

    // uint (ou UInt32): Armazena inteiros de 32 bits sem sinal (0 a 4,294,967,295)
    uint myUInt = 4000000000;

    // long (ou Int64): Armazena inteiros de 64 bits com sinal (-9,223,372,036,854,775,808 a 9,223,372,036,854,775,807)
    long myLong = -9000000000000000000;

    // ulong (ou UInt64): Armazena inteiros de 64 bits sem sinal (0 a 18,446,744,073,709,551,615)
    ulong myULong = 18000000000000000000;

    Console.WriteLine($"sbyte: {mySByte}");
    Console.WriteLine($"byte: {myByte}");
    Console.WriteLine($"short: {myShort}");
    Console.WriteLine($"ushort: {myUShort}");
    Console.WriteLine($"int: {myInt}");
    Console.WriteLine($"uint: {myUInt}");
    Console.WriteLine($"long: {myLong}");
    Console.WriteLine($"ulong: {myULong}");
#endregion


Console.WriteLine("\n*************************** Resposta questão 3 ***********************");
#region Resposta questão 3

    double dbl = 356.52;

    int inteiro1 = (int)dbl;

    Console.WriteLine($" {inteiro1}");

#endregion

Console.WriteLine("\n*************************** Resposta questão 4 ***********************");
#region Resposta questão 4
    int x = 10, y = 3;

    Console.WriteLine($"Adição: {x} + {y} = " + (x + y));
    Console.WriteLine($"Subtração: {x} - {y} = " + (x - y));
    Console.WriteLine($"Divisão: {x} / {y} = " + (x / y));
    Console.WriteLine($"Multiplicação: {x} * {y} = " + (x * y));
#endregion

Console.WriteLine("\n*************************** Resposta questão 5 ***********************");
#region Resposta questão 5
    int a = 5, b = 8;

    if(a > b)
        Console.WriteLine($"{a} > {b}");
    else
        Console.WriteLine($"{b} > {a}");

#endregion

Console.WriteLine("\n*************************** Resposta questão 6 ***********************");
#region Resposta questão 6

    string str1 = "Hello", str2 = "World";

    if(str1 == str2)
        Console.WriteLine("São iguais.");
    else 
        Console.WriteLine("Não são iguais.");
#endregion

Console.WriteLine("\n*************************** Resposta questão 7 ***********************");
#region Resposta questão 7
    bool condicao1 = true, condicao2 = false;

    if(condicao1 && condicao2) 
        Console.WriteLine("São verdadeiras.");
    else
        Console.WriteLine("Não são verdadeiras");

#endregion

Console.WriteLine("\n*************************** Resposta questão 8 ***********************");


#region Resposta questão 8
    int num1 = 7, num2 = 3, num3 = 10;

    if(num1 > num2 && num3 == (num1 + num2))
        Console.WriteLine($"{num1} é maior que {num2} e {num1} + {num2} é igual a {num3}.");
    else 
        Console.WriteLine("Condição falsa");
#endregion

