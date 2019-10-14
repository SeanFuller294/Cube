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


      string trapString()
      {
        int rand = random.Next(1, 4);
        string tString = "";
        if (rand == 1)
        {
          tString = "In a flash you see red before being consumed by fiery death";
        }
        else if (rand == 2)
        {
          tString = "Water floods the room. You try to go back, but the door is locked. You drown.";
        }
        else if (rand == 3)
        {
          tString = "Blades shoot out from every direction slicing you into pieces!";
        }
        else
        {
          tString = "Spikes shoot up from the floor impaling you!";
        }
        return tString;
      }
      //SECTION Add rooms
      Room room1 = new Room("room1", trapString(), true);
      Room room2 = new Room("room2", trapString(), true);
      Room room3 = new Room("room3", "You scan the room, not seeing anything noteworthy. What you do notice is that it smells faintly of onions.", false);
      Room room4 = new Room("room4", "A dim green light illuminates the room.", false);
      Room room5 = new Room("room5", "A strange room with doors on all sides and a ladder in the middle.", false);
      Room room6 = new Room("room6", trapString(), true);
      Room room7 = new Room("room7", "A dim blue light illuminates the room.", false);
      Room room8 = new Room("room8", "A bright red and yellow warning light flashes over and over.", false);
      Room room9 = new Room("room9", "You hear the distant sound of someone crying. You look around, but the room is empty.", false);
      Room room10 = new Room("room10", "A soft white light illuminates the room. You feel safe here.", false);
      Room room11 = new Room("room11", "Carved on the south wall is the words: 'No Hope'", false);
      Room room12 = new Room("room12", "It's Roomy", false);
      Room room13 = new Room("room13", "It's Roomy", false);
      Room room14 = new Room("room14", trapString(), true);
      Room room15 = new Room("room15", "It's Roomy", false);
      Room room16 = new Room("room16", "It's Roomy", false);
      Room room17 = new Room("room17", trapString(), true);
      Room room18 = new Room("room18", "It's Roomy", false);
      Room room19 = new Room("room19", "It's Roomy", false);
      Room room20 = new Room("room20", trapString(), true);
      Room room21 = new Room("room21", "It's Roomy", false);
      Room room22 = new Room("room22", "It's Roomy", false);
      Room room23 = new Room("room23", "It's Roomy", false);
      Room room24 = new Room("room24", "It's Roomy", false);
      Room room25 = new Room("room25", "It's Roomy", false);
      Room room26 = new Room("room26", trapString(), true);
      Room room27 = new Room("room27", trapString(), true);
      Room room28 = new Room("room28", "You have found the exit to the cube, you go through and escape this prison.", false);

      CurrentRoom = room5;

      //!SECTION 

      //SECTION First Floor Connections
      room3.AddExit("west", room2);
      room3.AddExit("up", room12);
      room3.AddExit("south", room6);

      room4.AddExit("north", room1);
      room4.AddExit("east", room5);
      room4.AddExit("south", room7);
      room4.AddExit("up", room13);

      room5.AddExit("north", room2);
      room5.AddExit("east", room6);
      room5.AddExit("south", room8);
      room5.AddExit("west", room4);
      room5.AddExit("up", room14);

      room7.AddExit("north", room4);
      room7.AddExit("east", room8);
      room7.AddExit("up", room16);

      room8.AddExit("north", room5);
      room8.AddExit("east", room9);
      room8.AddExit("west", room7);
      room8.AddExit("up", room17);

      room9.AddExit("north", room6);
      room9.AddExit("west", room8);
      room9.AddExit("up", room18);
      //!SECTION 

      //SECTION Second Floor Connections 
      room10.AddExit("east", room11);
      room10.AddExit("south", room13);
      room10.AddExit("down", room1);
      room10.AddExit("up", room19);

      room11.AddExit("east", room12);
      room11.AddExit("south", room14);
      room11.AddExit("west", room10);
      room11.AddExit("down", room2);
      room11.AddExit("up", room20);

      room12.AddExit("south", room15);
      room12.AddExit("west", room11);
      room12.AddExit("down", room3);
      room12.AddExit("up", room21);

      room13.AddExit("north", room10);
      room13.AddExit("east", room14);
      room13.AddExit("south", room16);
      room13.AddExit("down", room4);
      room13.AddExit("up", room22);

      room15.AddExit("north", room12);
      room15.AddExit("south", room18);
      room15.AddExit("west", room14);
      room15.AddExit("down", room6);
      room15.AddExit("up", room24);

      room16.AddExit("north", room13);
      room16.AddExit("east", room17);
      room16.AddExit("down", room7);
      room16.AddExit("up", room25);

      room18.AddExit("north", room15);
      room18.AddExit("west", room17);
      room18.AddExit("down", room9);
      room18.AddExit("up", room27);

      //!SECTION 

      //SECTION Third Floor Connections

      room19.AddExit("east", room20);
      room19.AddExit("south", room22);
      room19.AddExit("down", room10);

      room21.AddExit("south", room24);
      room21.AddExit("east", room20);
      room21.AddExit("down", room12);

      room22.AddExit("north", room19);
      room22.AddExit("east", room23);
      room22.AddExit("south", room25);
      room22.AddExit("down", room13);

      room23.AddExit("north", room20);
      room23.AddExit("east", room24);
      room23.AddExit("south", room26);
      room23.AddExit("west", room22);
      room23.AddExit("down", room14);

      room24.AddExit("north", room21);
      room24.AddExit("south", room27);
      room24.AddExit("west", room23);
      room24.AddExit("east", room28);
      room24.AddExit("down", room15);

      room25.AddExit("north", room22);
      room25.AddExit("east", room26);
      room25.AddExit("down", room16);

      //!SECTION


    }
  }
}