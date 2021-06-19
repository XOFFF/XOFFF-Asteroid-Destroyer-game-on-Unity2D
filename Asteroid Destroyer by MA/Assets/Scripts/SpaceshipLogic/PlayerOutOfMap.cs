using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfMap : MonoBehaviour
{
    public Camera mainCam;

    void Update()
    {
        mainCam.GetComponent<Boundaries>().TeleportObject(gameObject);
    }
}
