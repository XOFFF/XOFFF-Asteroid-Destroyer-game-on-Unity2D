using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddsSpawn : MonoBehaviour
{
    float randAddsType;
    float screenTop;
    float screenBottom;
    float screenRight;
    float screenLeft;
    Vector2 randPos;
    public GameObject pill;
    public GameObject bolt;
    public float cooldownTime = 10f;
    float nextSpawnTime = 5f;

    void Start()
    {
        screenTop = GetComponent<AsteroidSpawn>().screenTop;
        screenRight = GetComponent<AsteroidSpawn>().screenRight;
        screenBottom = screenTop * -1;
        screenLeft = screenRight * -1;
    }

    void FixedUpdate()
    {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + cooldownTime; // Wait cooldown time till spawn again
        }
    }

    void Spawn()
    {
        randAddsType = Random.Range(0f, 1f); // Decide random type of add
        randPos = new Vector2(Random.Range(screenBottom, screenTop), Random.Range(screenLeft, screenRight)); // Decide random position to add

        if(randAddsType >= 0.5f)
            Instantiate(pill, randPos, transform.rotation); // Spawn pill
        else if(randAddsType < 0.5f)
            Instantiate(bolt, randPos, transform.rotation); // Spawn bolt
    }
}
