using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        SceneManager.LoadScene("FirstScene");
        Time.timeScale = 1f;
    }
}
