using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;
    Vector2 direction;

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    void Update()
    {
        // Get player mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        // Calculate directions from the player
        Vector2 posXY = new Vector2(transform.position.x, transform.position.y);
        direction = (mousePos - posXY).normalized;
    }

    void FixedUpdate()
    {
        // Rotate player to mouse
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        // Move player to mouse
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
}
