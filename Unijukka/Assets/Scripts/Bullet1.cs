using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public GameObject bullet;
    public Rigidbody2D rb;

    public float bulletSpeed;
    public float bulletTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(bullet, bulletTime);
    }
    void Update()
    {
        rb.velocity = new Vector2(bulletSpeed, 0);     
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(bullet, 0.1f);
        }
    }
}
