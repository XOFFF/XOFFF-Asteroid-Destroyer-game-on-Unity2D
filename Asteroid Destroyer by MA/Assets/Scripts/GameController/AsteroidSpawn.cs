using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject bigAsteroid;
    public GameObject smallAsteroid;

    public float screenTop;
    float screenBottom;
    public float screenRight;
    float screenLeft;
    public float asteroidsNumber;
    public float cooldownTime = 5f;
    float nextSpawnTime = 0f;
    float randomAsteroidType;

    Vector2 newPos;

    void Start()
    {
        screenBottom = screenTop * -1;
        screenLeft = screenRight * -1;
    }

    void FixedUpdate()
    {
        if (Time.time > nextSpawnTime)
        {
            SetRandPos(); // Set random asteroid position
            AsteroidsSpawn(); // Spawn asteroids
            nextSpawnTime = Time.time + cooldownTime; // Wait cooldown time till spawn again
        }
    }

    void SetRandPos()
    {
        Vector2 randomPos = new Vector2(Random.Range(screenLeft, screenRight), Random.Range(screenTop, screenBottom));
        Vector2 randomAxis = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));

        if (randomAxis.x >= 0.5f)
            newPos = new Vector2(screenTop, randomPos.y);
        if (randomAxis.x < 0.5f)
            newPos = new Vector2(screenBottom, randomPos.y);
        if (randomAxis.y >= 0.5f)
            newPos = new Vector2(screenRight, randomPos.x);
        if (randomAxis.y < 0.5f)
            newPos = new Vector2(screenLeft, randomPos.x);
    }

    void AsteroidsSpawn()
    {
        for (int i = 0; i < asteroidsNumber; i++) // Spawn all asteroids till number
        {
            randomAsteroidType = Random.Range(0f, 1f); // Set random asteroid type

            if (randomAsteroidType >= 0.5f)
                Instantiate(bigAsteroid, newPos, bigAsteroid.transform.rotation); // Spawn big asteroid
            else if (randomAsteroidType < 0.5f)
                Instantiate(smallAsteroid, newPos, bigAsteroid.transform.rotation); // Spawn small asteroid
        }
    }
}
