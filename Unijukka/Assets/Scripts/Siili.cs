using UnityEngine;

public class Siili : MonoBehaviour
{
    public int maxHealth;
    public GameObject siili;
    public AudioSource singed;



    
    void Update()
    {
        if (maxHealth <= 0)
        {
            Destroy(siili, 0.2f) ;
            singed.Play(0);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            maxHealth -= 1;
            singed.Play(0);
        }
    }

}
