using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDebug : MonoBehaviour
{
    Vector2 mousePos;
    float radius = 0.1f;
    GameObject player;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance <= radius)
            {
                player.gameObject.GetComponent<PlayerMovements>().MoveSpeed = 0f;
                player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else if (distance > radius)
            {
                player.gameObject.GetComponent<PlayerMovements>().MoveSpeed = 2f;
            }
        }
    }
}
