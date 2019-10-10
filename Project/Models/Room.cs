using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public Room(string name, string description, bool isTrapped)
    {
      Name = name;
      Description = description;
      IsTrapped = isTrapped;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsTrapped { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public IRoom Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      return this;
    }

    public string GetTemplate()
    {
      string template = $"Room #{Name}: {Description} \n There are exits to the";
      foreach (var exit in Exits)
      {
        template += $"\n{exit.Key}";
      }
      return template;
    }

    public void AddExit(string direction, IRoom room)
    {
      Exits.Add(direction, room);
    }

  }
}