using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadStart",2);
    }

    void LoadStart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
