using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int lives;
    public float cooldownTime = 0.5f;
    public Text livesText;
    public Color invColor;
    public Color normalColor;
    public GameObject gameOverPanel;
    public AudioSource gruntSound;
    public AudioSource respawnSound;
    public AudioSource gameOverSound;
    SpriteRenderer sr;
    Vector2 respawn = new Vector2(0f, 0f);

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        livesText.text = "Lives: " + lives;
    }

    void MinusLife()
    {
        gruntSound.Play();
        lives--;

        transform.position = respawn;
        sr.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Shooting>().enabled = false;
        Invoke("Respawn", 2f);

        if (lives <= 0)
            GameOver();
    }

    void Respawn()
    {
        transform.position = respawn;
        sr.enabled = true;
        sr.color = invColor;
        Invoke("Invulnerable", 2f);
    }

    void Invulnerable()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Shooting>().enabled = true;
        sr.color = normalColor;
        respawnSound.Play();
    }

    void GameOver()
    {
        gameOverSound.Play();
        CancelInvoke();
        gameOverPanel.SetActive(true);
        livesText.text = "Lives: " + lives;
        Destroy(transform.gameObject);
    }

    void AddLife()
    {
        lives++;
    }
}
