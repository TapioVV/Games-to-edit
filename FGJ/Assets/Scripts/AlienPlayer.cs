using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    //[SerializeField] Transform center;
    bool playerIsActivated;


    //[SerializeField] BoxCollider2D bx;

    //AudioSource aS;

    //[SerializeField] AudioSource scrapCollectAudio;

    //Animator anim;

    //SpriteRenderer sr;

    //public bool activated;

    //private void Start()
    //{
    //    bx = GetComponent<BoxCollider2D>();
    //    sr = GetComponent<SpriteRenderer>();
    //    anim = GetComponent<Animator>();

    //    aS = GetComponent<AudioSource>();
    //}
    private void Start()
    {
        DayState.activatePlayerDelegate += GetBoolFromDayState;
    }
    private void OnDisable()
    {
        DayState.activatePlayerDelegate -= GetBoolFromDayState;
    }

    void GetBoolFromDayState(bool active)
    {
        playerIsActivated = active;
    }

    void Update()
    {
        //if (inputX > 0)
        //{
        //    sr.flipX = false;
        //}
        //if (inputX < 0)
        //{
        //    sr.flipX = true;
        //}
        //if (inputX != 0)
        //{
        //    anim.Play("Walk");
        //}
        //else
        //{
        //    anim.Play("Idle");
        //}

        float inputX = Input.GetAxisRaw("Horizontal");
        if (playerIsActivated)
        {
            transform.RotateAround(Vector2.zero, Vector3.forward, -inputX * moveSpeed * Time.deltaTime);
        }
    }


    //public void WalkSoundPlay()
    //{
    //    if (activated == true)
    //    {
    //        aS.Play();
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Gold")
    //    {
    //        po.Money += 5;
    //        scrapCollectAudio.Play();
    //        Destroy(collision.gameObject);
    //    }
    //}
}
