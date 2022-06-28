using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private int rand;
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(-1, 1);
        if (rand == 0)
        {
            rand = 1;
        }

        speed = Random.Range(5, 8);
    }

    // Update is called once per frame
    void Update()
    {
        //https://answers.unity.com/questions/52790/constant-rotation-to-an-object.html
        transform.Rotate(0, 0, (rand) * speed * 10 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
