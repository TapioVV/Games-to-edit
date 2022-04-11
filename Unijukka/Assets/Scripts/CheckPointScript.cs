using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPointScript : MonoBehaviour
{
    public bool activated = false;
    public static GameObject[] CheckPointsList;
    public GameObject checkPoint0;
    public GameObject checkPoint1;

    void Start()
    {
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint");
    }
    void Update()
    {
        if(activated == true)
        {
            checkPoint1.SetActive(true);
            checkPoint0.SetActive(false);
        }
        else if (activated == false)
        {
            checkPoint1.SetActive(false);
            checkPoint0.SetActive(true);
        }
    }


    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            activated = false;
            cp.GetComponent<CheckPointScript>().activated = false;
        }
        activated = true;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // If the player passes through the checkpoint, we activate it
        if (col.tag == "Player")
        {
            ActivateCheckPoint();
        }
    }
    public static Vector2 GetActiveCheckPointPosition()
    {
       
        Vector2 result = new Vector2(-106, -23);

        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                
                if (cp.GetComponent<CheckPointScript>().activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }
}

