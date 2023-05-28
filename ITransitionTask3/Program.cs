using ConsoleTables;
using ITransitionTask3;
using System;
using System.Security.Cryptography;

var gameMovesNumber = args.Length;

if (gameMovesNumber < 3)
{
    Console.WriteLine("You should pass three or more game moves. Try again, please");
    return;
}

if (gameMovesNumber % 2 == 0)
{
    Console.WriteLine("You should pass odd number of game moves. Try again, please");
    return;
}

if (args.Distinct().Count() != gameMovesNumber)
{
    Console.WriteLine("You should pass only unique game options. Try again, please");
    return;
}

var gameRules = Rules.DefineRules(gameMovesNumber);

// Game process
while (true)
{
    //Generate secret key
    var key = ITransitionTask3.HMAC.GenerateKey();
    //PrintByteArray(key);

    //PC move
    var pcMoveIndex = new Random().Next(0, args.Length);
    var pcMove = args[pcMoveIndex];
    //Console.WriteLine(pcMove);

    //Generate HMAC
    var hmac = ITransitionTask3.HMAC.GenerateHMAC(key, pcMove);
    Console.WriteLine($"HMAC: {hmac}");

    //Print game menu
    PrintGameMenu(args);

    // Player move
    Console.Write("Choose option: ");
    int playerMove = Convert.ToInt32(Console.ReadLine());

    if (playerMove == gameMovesNumber)
    {
        Console.WriteLine("Game rulse:");
        RulesTable.GenerateTable(gameRules, args);
        continue;
    }

    if (playerMove == gameMovesNumber + 1)
    {
        Console.WriteLine("See you soon.");
        return;
    } 

    // Check winner
    var gameResult = Rules.CheckWinner(pcMoveIndex, playerMove, gameRules);

    // Show result
    Console.WriteLine($"Your move: {args[playerMove]}");
    Console.WriteLine($"PC move: {pcMove}");
    Console.WriteLine(gameResult);
    Console.WriteLine($"HMAC key: {BitConverter.ToString(key).Replace("-", "")}");
    Console.WriteLine();
}

static void PrintGameMenu(string[] gameMoves)
{
    Console.WriteLine("Available moves");
    int i;

    for (i = 0; i < gameMoves.Length; i++)
    {
        Console.WriteLine($"{gameMoves[i]} - {i}");
    }

    Console.WriteLine($"help - {i++}");
    Console.WriteLine($"exit - {i++}");
    Console.WriteLine();
}
