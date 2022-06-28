using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // _player.atPole = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().atPipeSide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // _player.atPole = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().atPipeSide = false;
        }
    }
}
