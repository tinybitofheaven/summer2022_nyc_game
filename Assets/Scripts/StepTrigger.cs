using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrigger : MonoBehaviour
{

    public GameObject initalText;
    public GameObject secondaryText;

    public GameObject thirdText;

    // private PlayerController _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject _player = GameObject.FindGameObjectWithTag("Player");
            if (_player.GetComponent<PlayerController>().openDoor)
            {
                secondaryText.SetActive(false);
                thirdText.SetActive(true);
            }
            else if (_player.GetComponent<PlayerController>().hasKey)
            {
                _player.GetComponent<PlayerController>().atDoor = true;
                secondaryText.SetActive(true);
            }
            else
            {
                initalText.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject _player = GameObject.FindGameObjectWithTag("Player");
            if (_player.GetComponent<PlayerController>().openDoor)
            {
                secondaryText.SetActive(false);
                thirdText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject _player = GameObject.FindGameObjectWithTag("Player");
            if (_player.GetComponent<PlayerController>().openDoor)
            {
                secondaryText.SetActive(false);
                thirdText.SetActive(false);
            }
            else if (_player.GetComponent<PlayerController>().hasKey)
            {
                _player.GetComponent<PlayerController>().atDoor = false;
                secondaryText.SetActive(false);
            }
            else
            {
                initalText.SetActive(false);
            }
        }
    }
}
