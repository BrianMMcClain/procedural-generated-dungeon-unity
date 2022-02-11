using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Room
{
    private Room lastRoom;
    private Room nextRoom;
    private int x;
    private int y;

    public Room(int x, int y, Room lastRoom)
    {
        this.x = x;
        this.y = y;
        this.lastRoom = lastRoom;
        nextRoom = null;
    }

    public Room(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.lastRoom = null;
        nextRoom = null;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public Room GetLastRoom()
    {
        return this.lastRoom;
    }

    public Room GetNextRoom()
    {
        return this.nextRoom;
    }

    public void SetNextRoom(Room room)
    {
        this.nextRoom = room;
    }

    public bool HasNextRoom()
    {
        if (this.nextRoom != null)
            return true;
        return false;
    }
}

public class DungeonSpawner : MonoBehaviour
{
    public int roomCount = 5;
    private int roomsGenerated;
    private Room[,] layout;
    private List<Room> rooms;
    private int roomOffset = 10;

    public GameObject roomPrefab;

    void Start()
    {
        layout = new Room[roomCount * 2, roomCount * 2];
        rooms = new List<Room>();
        int layoutX = roomCount;
        int layoutY = roomCount;
        Room startRoom = new Room(layoutX, layoutY);
        rooms.Add(startRoom);
        layout[layoutX, layoutX] = startRoom;
        roomsGenerated = 1;
        GenerateLayout(startRoom);
        GenerateDungeon(startRoom);
        Debug.Log(rooms.Count);
    }

    void Update()
    {
        
    }

    private void DebugDungeon()
    {
        string debugString = "";
        for (int y = 0; y < layout.GetLength(0); y++)
        {
            for (int x = 0; x < layout.GetLength(1); x++)
            {
                if (layout[x, y] != null)
                {
                    debugString += "X";
                } else
                {
                    debugString += "_";
                }
            }
            debugString += "\n";
        }
        Debug.Log(debugString);
    }

    private void GenerateLayout(Room startRoom)
    {
        int layoutX = startRoom.GetX();
        int layoutY = startRoom.GetY();
        Room lastRoom = startRoom;

        while (roomsGenerated < roomCount)
        {
            bool roomGenerated = false;
            int tries = 0;

            while (!roomGenerated && tries < 10)
            {
                int direction = Random.Range(0, 4);
                int potentialX = lastRoom.GetX();
                int potentialY = lastRoom.GetY();
                switch (direction)
                {
                    case 0:
                        // Up
                        potentialX = lastRoom.GetX();
                        potentialY = lastRoom.GetY() - 1;
                        if (potentialY >= 0 && layout[potentialX, potentialY] == null)
                        {
                            roomGenerated = true;
                        }
                        break;
                    case 1:
                        // Down
                        potentialX = lastRoom.GetX();
                        potentialY = lastRoom.GetY() + 1;
                        if (potentialY < roomCount * 2 && layout[potentialX, potentialY] == null)
                        {
                            roomGenerated = true;
                        }
                        break;
                    case 2:
                        // Left
                        potentialX = lastRoom.GetX() - 1;
                        potentialY = lastRoom.GetY();
                        if (potentialX >= 0 && layout[potentialX, potentialY] == null)
                        {
                            roomGenerated = true;
                        }
                        break;
                    case 3:
                        // Right
                        potentialX = lastRoom.GetX() + 1;
                        potentialY = lastRoom.GetY();
                        if (potentialX < roomCount * 2 && layout[potentialX, potentialY] == null)
                        {
                            roomGenerated = true;
                        }
                        break;
                }

                if (roomGenerated)
                {
                    Room newRoom = new Room(potentialX, potentialY, lastRoom);
                    rooms.Add(newRoom);
                    layout[potentialX, potentialY] = newRoom;
                    lastRoom.SetNextRoom(newRoom);
                    lastRoom = newRoom;
                    layoutX = potentialX;
                    layoutY = potentialY;
                    roomsGenerated++;
                } else
                {
                    tries++;
                }
            }

            if (!roomGenerated)
            {
                lastRoom = lastRoom.GetLastRoom();
            }
        }
    }

    private void GenerateDungeon(Room startRoom)
    {
        Room currentRoom = startRoom;
        while (currentRoom != null)
        {
            Vector3 loc = new Vector3(currentRoom.GetX() * roomOffset, 0, currentRoom.GetY() * roomOffset);
            Instantiate(roomPrefab, loc, transform.rotation);
            currentRoom = currentRoom.GetNextRoom();
        }
    }
}
