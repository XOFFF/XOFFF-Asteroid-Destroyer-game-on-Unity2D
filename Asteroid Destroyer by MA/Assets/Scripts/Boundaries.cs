using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    Vector2 screenBounds;
    float teleportTop;
    float teleportBottom;
    float teleportLeft;
    float teleportRight;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    public void setTeleportCoordinates(GameObject gObject)
    {
        teleportTop = screenBounds.y + gObject.GetComponent<CircleCollider2D>().radius; // Set teleport Y coordinate by top of screen + GameObject radius
        teleportBottom = teleportTop * -1; // Set opposite coodinates
        teleportRight = screenBounds.x + gObject.GetComponent<CircleCollider2D>().radius;
        teleportLeft = teleportRight * -1;
    }

    public void TeleportObject(GameObject gObject)
    {
        setTeleportCoordinates(gObject);
        if (gObject.transform.position.y > teleportTop) // Check if GameObject Y coordinate is more than teleport coordinate
            gObject.transform.position = new Vector2(gObject.transform.position.x, teleportBottom); // Set GameObject teleport to opposite Y coordinate
        if (gObject.transform.position.y < teleportBottom)
            gObject.transform.position = new Vector2(gObject.transform.position.x, teleportTop);
        if (gObject.transform.position.x > teleportRight)
            gObject.transform.position = new Vector2(teleportLeft, gObject.transform.position.y);
        if (gObject.transform.position.x < teleportLeft)
            gObject.transform.position = new Vector2(teleportRight, gObject.transform.position.y);
    }
}
