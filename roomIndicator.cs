using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomIndicator : MonoBehaviour
{
    private float waitTime = 4f;

    public bool collisionWithSpawnPoint;

    void Start()
    {
        Destroy(gameObject, waitTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("SpawnPoint"))
        {
            collisionWithSpawnPoint = true;
        }
    }
}
