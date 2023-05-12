using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float speed = 2f;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement.y += speed*Time.deltaTime;
        
        //move the text scroll up slowly
         rb.MovePosition(movement);
    }
}
