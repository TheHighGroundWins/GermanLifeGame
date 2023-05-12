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

    private TMP_Text currentTextBubble;
    [SerializeField]
    private GameObject baseText;
    [SerializeField] private GameObject textBubble;
    [SerializeField] private bool jewish = true;

    // Start is called before the first frame update
    void Start()
    {
        //get rigid body
        rb = GetComponent<Rigidbody2D>();
        currentTextBubble = baseText.GetComponent<TMP_Text>();
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
        
        if (col.tag == "Interact" && allowMove)
        {
            //save reference to the text bubble in the object
            currentTextBubble.text = col.gameObject.GetComponent<Interactions>().GetTextBubble(jewish);
            textBubble.SetActive(true);
            allowMove = false;
        }
    }

    //move the player
    private void FixedUpdate()
    {
        if(allowMove)
        rb.MovePosition(rb.position+movement*speed*Time.fixedDeltaTime);
        if (Input.GetButtonDown("Interact") && !allowMove && textBubble.activeSelf)
        {
            textBubble.SetActive(false);
            allowMove = true;
        }
    }

    public bool GetJewish()
    {
        return jewish;
    }

    public bool AllowMove
    {
        get => allowMove;
        set => allowMove = value;
    }
}
