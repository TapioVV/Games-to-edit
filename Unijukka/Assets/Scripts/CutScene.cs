using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;

    public float timer;

    void Start()
    {
        
    }

    
    void Update()
    {
        Timer();
        Debug.Log(timer);
        if (timer > 6)
        {
            Image1.SetActive(true);
            Image2.SetActive(false);
            Image3.SetActive(false);
        }
        else if (timer < 6 && timer > 3)
        {
            Image1.SetActive(false);
            Image2.SetActive(true);
            Image3.SetActive(false);
        }
        else if (timer < 3)
        {
            Image1.SetActive(false);
            Image2.SetActive(false);
            Image3.SetActive(true);
        }
        if(timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    void Timer()
    {
        timer -= Time.deltaTime;
    }
}
