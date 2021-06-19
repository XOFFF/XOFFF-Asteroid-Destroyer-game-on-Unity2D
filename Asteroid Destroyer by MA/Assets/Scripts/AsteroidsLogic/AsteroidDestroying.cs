using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroying : MonoBehaviour
{
    public GameObject smallAsteroid;
    public GameObject bigAsteroid;
    GameObject gameController;
    GameObject player;
    AudioSource crashSound;

    public int points;
    public float divideForce = 0.5f;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");
        crashSound = gameController.GetComponent<AudioControls>().CrashSound();
    }

    void OnTriggerEnter2D(Collider2D colInfo)
    {
        if (!colInfo.gameObject.CompareTag("Pill") && !colInfo.gameObject.CompareTag("Bolt") && !colInfo.gameObject.CompareTag("Cursor")) {
            if (transform.CompareTag("BigAsteroid"))
            {
                Divide();
            }

            Destroy(gameObject);
            crashSound.Play();

            if (colInfo.gameObject.CompareTag("Bullet"))
                Destroy(colInfo.gameObject);

            else if (colInfo.gameObject.CompareTag("Player"))
            {
                player.gameObject.SendMessage("MinusLife");
            }

            // Tell to score points
            gameController.SendMessage("ScorePoints", points);
        }
    }

    void Divide()
    {
        GameObject asteroid1 = Instantiate(smallAsteroid, transform.position, transform.rotation);
        Rigidbody2D rb1 = asteroid1.GetComponent<Rigidbody2D>();
        rb1.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * divideForce, ForceMode2D.Impulse);

        GameObject asteroid2 = Instantiate(smallAsteroid, transform.position, transform.rotation);
        Rigidbody2D rb2 = asteroid2.GetComponent<Rigidbody2D>();
        rb2.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * divideForce, ForceMode2D.Impulse);
    }
}
