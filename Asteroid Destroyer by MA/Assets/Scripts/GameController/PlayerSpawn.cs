using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    Vector2 spawn = new Vector2(0f, 0f);
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.position = spawn;
    }
}
