using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> bottom door
    // 2 --> top door
    // 3 --> left door
    // 4 --> right door

    public RoomTemplates templates;
    private RoomControl roomControl;
    public GameObject table;
    private int rand;
    public bool spawned = false;
    private bool started;
    public bool blocked;
    public bool initialSpawner;

    public int noOfRooms;

    private float waitTime = 6f;

    private void Start()
    {
        roomControl = GameObject.Find("RoomControl").GetComponent<RoomControl>();
    }

    private void Update()
    {
        noOfRooms = roomControl.noOfRooms;
        table = GameObject.FindGameObjectWithTag("TableRooms");
        started = roomControl.started;

        if (!blocked)
        {
            if(noOfRooms < 4)
            {
                templates = GameObject.Find("Room Templates Initial").GetComponent<RoomTemplates>();
            }
            if ((noOfRooms >= 4) && (noOfRooms < 10))
            {
                templates = GameObject.Find("Room Templates All").GetComponent<RoomTemplates>();
            }
            else if ((noOfRooms >= 10) && (noOfRooms < 16))
            {
                templates = GameObject.Find("Room Templates Small").GetComponent<RoomTemplates>();
            }
            else if (noOfRooms >= 16)
            {
                templates = GameObject.Find("Room Templates Small 1 Exit").GetComponent<RoomTemplates>();
            }
        }
        ButtonClickRoomSpawn();
    }

    public void ButtonClickRoomSpawn()
    {
        if (started)
        {
            Invoke("Spawn", 0.3f);
            Destroy(gameObject, waitTime);
        }
    }


    void Spawn()
    {
        if (!spawned)
        {
            spawned = true;
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation, table.transform);
                roomControl.AddRoom();
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation, table.transform);
                roomControl.AddRoom();
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation, table.transform);
                roomControl.AddRoom();
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation, table.transform);
                roomControl.AddRoom();
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("SpawnPoint"))
        {
            if (collider.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity, table.transform);
                Destroy(gameObject);
            }
            spawned = true;
        }
        if (collider.CompareTag("RoomIndicator"))
        {
            if (collider.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                templates = GameObject.Find("Room Templates Small 1 Exit").GetComponent<RoomTemplates>();
                blocked = true;
            }
            spawned = true;
        }
        if (collider.CompareTag("EdgeDetection1"))
        {
            blocked = true;
            if (noOfRooms < 12)
            {
                templates = GameObject.Find("Room Templates Edge 1").GetComponent<RoomTemplates>();
            }
            else
            {
                templates = GameObject.Find("Room Templates Small 1 Exit").GetComponent<RoomTemplates>();
            }

        }
        if (collider.CompareTag("EdgeDetection2"))
        {
            blocked = true;
            templates = GameObject.Find("Room Templates Small 1 Exit").GetComponent<RoomTemplates>();
        }
    }




}

