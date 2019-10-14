using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;
using System;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void Go(string direction)
    {

      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        if (!_game.CurrentRoom.IsTrapped)
        {
          // Messages.Add(_game.CurrentRoom.Description);
          Messages.Add(((Room)_game.CurrentRoom).GetTemplate());
          if (_game.CurrentRoom.Items.Count > 0)
          {
            Messages.Add("The room contains:");
            foreach (Item item in _game.CurrentRoom.Items)
            {
              Messages.Add($"{item.Name}");
            }
          }

        }
        else
        {
          Console.WriteLine(_game.CurrentRoom.Description);
          Console.WriteLine("YOU LOSE\nWould you like to play again? (y/n)");
          string decision = Console.ReadLine().ToLower();
          if (decision == "y" || decision == "yes")
          {
            Reset();
          }
          else
          {
            Environment.Exit(0);
          }
        }
        if (_game.CurrentRoom.Name == "room28")
        {
          Console.WriteLine(_game.CurrentRoom.Description);
          Console.WriteLine("YOU WIN\nWould you like to play again? (y/n)");
          string decision = Console.ReadLine().ToLower();
          if (decision == "y" || decision == "yes")
          {
            Messages.Clear();
            Console.Clear();
            Reset();
          }
          else
          {
            Environment.Exit(0);
          }
        }
      }
      else
      {
        Messages.Add("You can't go that way");
      }
    }
    public void Help()
    {
      Messages.Add($@"
Command ------ Option
Go        -    (North, South, East, West, Up, Down) - Go to the next room in that direction
Use       -    (Shoe) - Use an item from your inventory
Take      -    (Shoe) - Take an item from the room you are in
---------------------
Look - Get a description of the room you are in
Inventory - Get a description of all Items in your inventory
Help - How did you get to this menu without knowing what to enter
Quit - Exits the application
Reset - Resets the game
");
    }

    public void Inventory()
    {
      foreach (Item item in _game.Player.Inventory)
      {
        Messages.Add($"{item.Name} - {item.Description}");
      }
    }

    public void Look()
    {
      // Messages.Add($"{_game.CurrentRoom.Description} - {_game.CurrentRoom.Name}");
      Messages.Add(((Room)_game.CurrentRoom).GetTemplate());
      if (_game.CurrentRoom.Items.Count > 0)
      {
        Messages.Add("The room contains:");
        foreach (Item item in _game.CurrentRoom.Items)
        {
          Messages.Add($"{item.Name}");
        }
      }
    }

    public void Quit()
    {
      Environment.Exit(0);
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      Console.WriteLine("What is your name?");
      string playerName = Console.ReadLine();
      Setup(playerName);
    }

    public void Setup(string playerName)
    {
      Player player = new Player(playerName);
      _game.Player = player;
      Item RightShoe = new Item("right shoe", "The loyal right shoe. This beauty has carried your weight for years! Together, you have trudged through dirt, mud, and other more questionable substances. With a shoe that has survived the harshest of obstacles with you; you would never bring yourself to toss it aside to be disintegrated by some lurking death machine... Would you ?");
      Item LeftShoe = new Item("left shoe", "It's a shoe, what did you expect?");
      player.Inventory.Add(RightShoe);
      player.Inventory.Add(LeftShoe);
      _game.Setup();
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Item i = new Item("", "");
      if (_game.CurrentRoom.Items.Count > 0)
      {
        foreach (Item item in _game.CurrentRoom.Items)
        {
          if (item.Name == itemName)
          {
            i = item;
          }
          else
          {
            Messages.Add("That item is not in this room");
          }
        }
        if (i.Name.Length > 1)
        {
          _game.Player.Inventory.Add(i);
          _game.CurrentRoom.Items.Remove(i);
        }
      }

      else
      {
        Messages.Add("There are no items to take...");
      }
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      Item i = new Item("", "");
      foreach (Item item in _game.Player.Inventory)
      {
        if (item.Name == itemName)
        {
          i = item;
        }
      }
      if (i.Name.Length > 0)
      {
        _game.Player.Inventory.Remove(i);
        Console.WriteLine("Which Direction?");
        string response = Console.ReadLine().ToLower();
        if (_game.CurrentRoom.Exits.ContainsKey(response))
        {

          if (!_game.CurrentRoom.Exits[response].IsTrapped)
          {
            _game.CurrentRoom.Exits[response].Items.Add(i);
            Messages.Add("The room appears to be safe");
          }
          else
          {
            Messages.Add("The Room Was Trapped and you have lost your shoe");
          }
        }
        else
        {
          _game.CurrentRoom.Items.Add(i);
          Messages.Add("You throw your shoe at the wall.");
        }

      }
      else
      {
        Messages.Add("You don't have that item...");
      }
    }
  }
}





