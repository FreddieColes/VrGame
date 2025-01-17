﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            Destroy(collision.gameObject);
        }
    }
}
