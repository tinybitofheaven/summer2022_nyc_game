using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadTrigger : MonoBehaviour
{
    public GameObject text;

    // private PlayerController _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // _player.atPole = true;
            text.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().atBread = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            // _player.atPole = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().atBread = false;
        }
    }
}
