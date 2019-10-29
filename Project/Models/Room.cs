using System;
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
      string template = $"{Description} \nThere are exits to the";
      foreach (var exit in Exits)
      {
        template += $"\n\t{exit.Key}";
      }
      return template;
    }

    public void AddExit(string direction, IRoom room)
    {
      Exits.Add(direction, room);
    }

    public void AddRooms(int x, int y, int z, Room[,,] rooms)
    {
      if (x > 0)
      {
        AddExit("west", rooms[x - 1, y, z]);
      }
      if (x < rooms.GetLength(0) - 1)
      {
        AddExit("east", rooms[x + 1, y, z]);
      }
      if (y > 0)
      {
        AddExit("south", rooms[x, y - 1, z]);
      }
      if (y < rooms.GetLength(1) - 1)
      {
        AddExit("north", rooms[x, y + 1, z]);
      }
      if (z > 0)
      {
        AddExit("down", rooms[x, y, z - 1]);
      }
      if (z < rooms.GetLength(2) - 1)
      {
        AddExit("up", rooms[x, y, z + 1]);
      }
    }

  }
}