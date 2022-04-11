using UnityEngine;

public class Platform : MonoBehaviour
{
    public BoxCollider2D bx;
    public CapsuleCollider2D cc;
    public GameObject platform;

    public bool onPlatform;


    void Start()
    {
        
        cc = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        platformFall();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            onPlatform = true;
            bx.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            onPlatform = false;
            bx.enabled = false;
        }
    } 
    
    void platformFall()
    {
        if(onPlatform == true && Input.GetKeyDown(KeyCode.DownArrow))
        {
            onPlatform = false;
            bx.enabled = false;
        }
    }
}
