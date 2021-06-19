using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpAdds : MonoBehaviour
{
    public GameObject pill;
    public GameObject bolt;
    public AudioSource bonusSound;

    private void OnTriggerEnter2D(Collider2D colInfo)
    {
        if (colInfo.gameObject.CompareTag("Pill"))
        {
            gameObject.SendMessage("AddLife");
            Destroy(colInfo.gameObject);
            bonusSound.Play();
        }

        if (colInfo.gameObject.CompareTag("Bolt"))
        {
            gameObject.SendMessage("ShootFaster");
            Destroy(colInfo.gameObject);
            bonusSound.Play();
        }
    }
}
