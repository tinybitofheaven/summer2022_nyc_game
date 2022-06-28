using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTrigger : MonoBehaviour
{
    public GameObject initalText;
    public GameObject secondaryText;

    // private PlayerController _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "post")
        {
            GameObject _player = GameObject.FindGameObjectWithTag("Player");
            if (_player.GetComponent<PlayerController>().hasBread)
            {
                _player.GetComponent<PlayerController>().atBird = true;
                secondaryText.SetActive(true);
            }
            else
            {
                initalText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "post")
        {
            GameObject _player = GameObject.FindGameObjectWithTag("Player");
            if (_player.GetComponent<PlayerController>().hasBread)
            {
                _player.GetComponent<PlayerController>().atBird = false;
                secondaryText.SetActive(false);
            }
            else
            {
                initalText.SetActive(false);
            }
        }
    }
}
