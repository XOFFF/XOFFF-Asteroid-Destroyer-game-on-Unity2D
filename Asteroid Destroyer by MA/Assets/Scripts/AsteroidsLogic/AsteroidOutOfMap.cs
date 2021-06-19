using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidOutOfMap : MonoBehaviour
{
    Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        mainCam.GetComponent<Boundaries>().TeleportObject(gameObject);
    }
}
