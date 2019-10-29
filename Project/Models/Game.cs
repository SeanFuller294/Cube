using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {


    public IRoom CurrentRoom { get; set; }
    public IPlayer Player { get; set; }

    //NOTE Make your rooms here...
    public void Setup()
    {
      Random random = new Random();
      string roomString(int x)
      {
        if (x == 1)
        {
          int rand = random.Next(1, 4);
          switch (rand)
          {
            case 1: return "In a flash you see red before being consumed by fiery death";
            case 2: return "Water floods the room. You try to go back, but the door is locked. You drown.";
            case 3: return "Blades shoot out from every direction slicing you into pieces!";
            case 4: return "Spikes shoot up from the floor impaling you!";
          }
        }
        else
        {
          int rand = random.Next(1, 5);
          switch (rand)
          {
            case 1: return "A strange room with doors on all sides and a ladder in the middle. A dim red light illuminates the room.";
            case 2: return "A strange room with doors on all sides and a ladder in the middle. A dim orange light illuminates the room.";
            case 3: return "A strange room with doors on all sides and a ladder in the middle. A dim yellow light illuminates the room.";
            case 4: return "A strange room with doors on all sides and a ladder in the middle. A dim green light illuminates the room.";
            case 5: return "A strange room with doors on all sides and a ladder in the middle. A dim blue light illuminates the room.";
          }
        }
        return "";
      }
      var rooms = new Room[3, 3, 3];
      int i = 1;
      var trappedRooms = new HashSet<string>();
      trappedRooms.Add("0,2,0");
      trappedRooms.Add("1,2,0");
      trappedRooms.Add("2,1,0");
      trappedRooms.Add("1,0,1");
      trappedRooms.Add("1,1,1");
      trappedRooms.Add("1,0,2");
      trappedRooms.Add("1,2,2");
      trappedRooms.Add("2,0,2");
      for (int x = 0; x < rooms.GetLength(0); x++)
      {
        for (int y = 0; y < rooms.GetLength(1); y++)
        {
          for (int z = 0; z < rooms.GetLength(2); z++)
          {
            string xyz = $"{x},{y},{z}";
            if (trappedRooms.Contains(xyz))
            {
              rooms[x, y, z] = new Room($"room{i}", roomString(1), true);
            }
            else
            {
              rooms[x, y, z] = new Room($"room{i}", roomString(2), false);
            }
            i++;
          }
        }
      }
      for (int x = 0; x < rooms.GetLength(0); x++)
      {
        for (int y = 0; y < rooms.GetLength(1); y++)
        {
          for (int z = 0; z < rooms.GetLength(2); z++)
          {
            rooms[x, y, z].AddRooms(x, y, z, rooms);
          }
        }
      }
      Room room28 = new Room("room28", "You have found the exit to the cube, you go through and escape this prison.", false);
      rooms[2, 1, 2].AddExit("east", room28);
      CurrentRoom = rooms[1, 1, 0];
    }
  }
}

// case 1: return "You scan the room, not seeing anything noteworthy. What you do notice is that it smells faintly of onions.";
// case 2: return "A dim green light illuminates the room.";
// case 3: return "A bright red and yellow warning light flashes over and over.";
// case 4: return "A dim blue light illuminates the room.";
// case 5: return "An inch of water covers the floor. You don't like it here.";
// case 6: return "You hear the distant sound of someone crying. You look around, but the room is empty.";
// case 7: return "A soft white light illuminates the room. You feel safe here.";
// case 8: return "Carved on the south wall are the words: 'No Hope'";
// case 9: return "A room like the rest. This one has padded walls.";
// case 10: return "The walls are mirrored, you see your grimy reflection in every surface.";
// case 11: return "A toaster stands alone in the middle of the room. You feel the need to climb on top of it.";
// case 12: return "You look around and see a liquid dripping down the walls. The room smells musty. You don't like it here.";
// case 13: return "The room is black. The only light streams from one dim light on each door.";
// case 14: return "A skeleton sits in the corner. You try to pick up it's bones, but every one you touch crumbles in your fingers.";
// case 15: return "It's scary.";
// case 16: return "A dim yellow light illuminates the room.";
// case 17: return "You hear elevator music playing. You look around, but see no speakers.";