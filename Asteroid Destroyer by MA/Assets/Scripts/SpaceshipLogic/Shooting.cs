using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootSound;

    public float bulletForce = 20f;

    public float cooldownTime = 0.5f;
    float nextFireTime = 0f;

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + cooldownTime;
        }
    }

    void Shoot()
    {
        shootSound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 1f);
    }

    void ShootFaster()
    {
        if (cooldownTime > 0.1f) {
            cooldownTime -= 0.1f;
        }
    }
}