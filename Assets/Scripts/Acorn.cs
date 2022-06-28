using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Renderer>().sortingLayerName == gameObject.GetComponent<Renderer>().sortingLayerName)
            {
                other.gameObject.GetComponent<PlayerController>().cheeseCount++;
                Destroy(gameObject);
            }
        }
    }
}
