using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet1;

    public GameObject bullet3;

    public GameObject player;
    public bool lookRight;
    public bool moved;

    public float timer;
    public float timer2;
    public float timer3;
    public float timer4;

    public AudioSource shootSound;
    

    public bool shooting;
    public float shots = 3;


    void Update()
    {
        Inputboi();
    }


    void Inputboi()
    {
        float horizontalShoot = Input.GetAxisRaw("Horizontal");

        if (horizontalShoot == 1 && Input.GetButtonDown("Fire1") && shots > 0 && moved == true)
        {
            Instantiate(bullet1, transform.position, Quaternion.identity);
            shots -= 1;
            shootSound.Play(0);
        }
        else if (lookRight == true && Input.GetButtonDown("Fire1") && shots > 0 && moved == true)
        {
            Instantiate(bullet1, transform.position, Quaternion.identity);
            shots -= 1;
            shootSound.Play(0);
        }
        else if (lookRight == false && Input.GetButtonDown("Fire1") && shots > 0 && moved == true)
        {
            Instantiate(bullet3, transform.position, Quaternion.identity);
            shots -= 1;
            shootSound.Play(0);
        }
        else if (horizontalShoot == -1 && Input.GetButtonDown("Fire1") && shots > 0 && moved == true)
        {
            Instantiate(bullet3, transform.position, Quaternion.identity);
            shots -= 1;
            shootSound.Play(0);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            moved = true;

        }

        if (shots <= 0)
        {
            timer -= Time.deltaTime;

        }
        if(timer <= 0)
        {
            shots = 3;
            timer = timer2;
            timer3 = timer4;
        }
        if(shots < 3)
        {
            timer3 -= Time.deltaTime;
        }
        if(timer3 <= 0)
        {
            timer3 = timer4;
            shots = 3;
        }

        if (horizontalShoot == 1)
        {
            lookRight = true;
        }
        else if (horizontalShoot == -1)
        {
            lookRight = false;
        }
    }
}