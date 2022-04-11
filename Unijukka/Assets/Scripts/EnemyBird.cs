
using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    public int maxHealth;
    public GameObject bird;
    public AudioSource singed;



    void Update()
    {
        if (maxHealth <= 0)
        {
            Destroy(bird, 0.2f);
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

