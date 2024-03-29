using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      Console.WriteLine("What is your name?");
      string name = Console.ReadLine();
      _gameService.Setup(name);
      Console.WriteLine("Type Help for a list of commands \npress the any key to continue");
      Console.ReadKey();
      while (true)
      {

        Print();
        GetUserInput();
      }
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      // string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      string[] inputArr = input.Split(" ");
      // string option = inputArr[1].Trim();
      string direction = "";
      string command = inputArr[0];
      if (inputArr.Length > 3)
      {
        option = inputArr[1];
        option += " " + inputArr[2];
      }
      if (inputArr.Length > 4)
      {
        direction = inputArr[3];
      }
      switch (command)
      {
        case "go":
          _gameService.Go(option);
          break;
        case "use":
          if (inputArr.Length > 4)
          {
            _gameService.UseItem(option, direction);
          }
          else
          {
            _gameService.UseItem(option);
          }
          break;
        case "take":
          _gameService.TakeItem(option);
          break;
        case "quit":
          _gameService.Quit();
          break;
        case "help":
          _gameService.Help();
          break;
        case "look":
          _gameService.Look();
          break;
        case "inventory":
          _gameService.Inventory();
          break;
        case "reset":
          _gameService.Reset();
          break;
        default:
          _gameService.Messages.Add("Don't do drugs\n");
          _gameService.Look();
          break;
      }
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"

    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      Console.Clear();
      foreach (string message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }

  }
}