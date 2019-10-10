using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Player : IPlayer
  {
    public Player(string name)
    {
      Name = name;
      Inventory = new List<Item>();
    }
    public string Name { get; set; }
    public List<Item> Inventory { get; set; }

    public string GetInventory()
    {
      string template = "Inventory \n";
      foreach (var item in Inventory)
      {
        template += $"{item.Name}";
      }
      if (Inventory.Count < 1)
      {
        template = "You have no items";
      }
      return template;
    }
  }
}