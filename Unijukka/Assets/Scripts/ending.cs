using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    float time = 6;    


    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
}
