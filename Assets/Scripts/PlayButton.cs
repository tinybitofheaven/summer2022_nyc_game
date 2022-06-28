using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        // return 1;
    }
}
