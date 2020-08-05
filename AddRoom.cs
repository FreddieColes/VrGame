﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;


    private void Start()
    {
        templates = GameObject.Find("Room Templates 3").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);

    }

}
