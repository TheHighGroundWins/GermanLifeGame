using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float speed = 4f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool allowMove = true;

    [SerializeField] private GameObject textBubble;
    [SerializeField] private GameObject textBubble2;


    // Start is called before the first frame update
    void Start()
    {
        //get rigid body
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //calculate the movement
    void Update()
    {
        //get input keyboard or controller
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Interact" && allowMove && col.name=="Interact")
        {
            textBubble.SetActive(true);
            allowMove = false;
        }
        if (col.tag == "Interact" && allowMove && col.name=="HorstWessel")
        {
            textBubble2.SetActive(true);
            allowMove = false;
        }
    }

    //move the player
    private void FixedUpdate()
    {
        if(allowMove)
        rb.MovePosition(rb.position+movement*speed*Time.fixedDeltaTime);
        if (Input.GetAxis("Interact")>0 && !allowMove)
        {
            textBubble.SetActive(false);
            if(textBubble2!=null)
            textBubble2.SetActive(false);
            allowMove = true;
        }
    }
}
