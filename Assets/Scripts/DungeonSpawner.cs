using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    public int roomCount = 5;
    public GameObject roomPrefab;

    private bool[,] layout;
    private int roomOffset = 10;

    void Start()
    {
        layout = new bool[roomCount * 2, roomCount * 2];
        int layoutX = roomCount;
        int layoutY = roomCount;
        layout[layoutX, layoutX] = true;

        for (int i = 1; i < roomCount; i++)
        {
            float xDist = 0;
            float zDist = 0;

            bool roomGenerated = false;
            while (!roomGenerated)
            {
                int direction = Random.Range(1, 5);
                Debug.Log(direction);
                switch (direction)
                {
                    case 1:
                        // Up
                        if (layoutY > 0 && !layout[layoutX, layoutY-1])
                        {
                            zDist = roomOffset;
                            layoutY--;
                            roomGenerated = true;
                        }

                        break;
                    case 2:
                        // Down
                        if (layoutY < roomCount * 2 && !layout[layoutX, layoutY+1])
                        {
                            zDist = -roomOffset;
                            layoutY++;
                            roomGenerated = true;
                        }
                        break;
                    case 3:
                        // Left
                        if (layoutX > 0 && !layout[layoutX-1, layoutY])
                        {
                            xDist = -roomOffset;
                            layoutX--;
                            roomGenerated = true;
                        }
                        break;
                    case 4:
                        // Right
                        if (layoutX < roomCount * 2 && !layout[layoutX+1, layoutY])
                        {
                            Debug.Log("Right");
                            xDist = roomOffset;
                            layoutX++;
                            roomGenerated = true;
                        }
                        break;
                }
            }

            layout[layoutX, layoutY] = true;
            transform.Translate(new Vector3(xDist, 0, zDist));
            Instantiate(roomPrefab, transform.position, transform.rotation);
        }
    }

    void Update()
    {
        
    }
}
