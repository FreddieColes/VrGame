﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    public bool mainRoomTemplate;

    private void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false && mainRoomTemplate == true)
        {
            Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            spawnedBoss = true;

        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
