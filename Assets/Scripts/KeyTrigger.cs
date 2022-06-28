using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public GameObject text;

    // private PlayerController _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "post")
        {
            // _player.atPole = true;
            text.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().atKey = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "post")
        {
            text.SetActive(false);
            // _player.atPole = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().atKey = false;
        }
    }
}
