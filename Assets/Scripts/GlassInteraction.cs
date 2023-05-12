using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlassInteraction : MonoBehaviour
{
    [SerializeField] private GameObject[] jPlayerSprites = new GameObject[2];
    [SerializeField] private String initialPrompt;
    [SerializeField] private String baseChoice;
    //0 is for Jewish, 1 is for Gentile
    [SerializeField] private String[] diffChoices = new string[2];
    [SerializeField] private GameObject optionDialogue;
    [SerializeField] private TMP_Text[] textOptions = new TMP_Text[3];
    [SerializeField] private GameObject jSpot;
    private bool topChoice = true;
    private bool isJewish = true;
    private bool playerPresent = false;
    private Player currentPlayer;
    private GameObject playerObject;
    
    //reference to top and bottom choices
    private GameObject[] choices;
    //timer
    private float totalTime;
    private bool startTimer = false;
    
    //same duty as level loader
    [SerializeField] private GameObject gentilePlayer;
    [SerializeField] private String nextScene;
    private void Start()
    {
        //put the initial prompt regardless
        textOptions[0].text = initialPrompt;
        textOptions[1].text = baseChoice;
        choices = optionDialogue.GetComponent<SelectOptions>().GetOptions();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
         optionDialogue.SetActive(true);
         isJewish = col.gameObject.GetComponent<Player>().GetJewish();
         currentPlayer = col.gameObject.GetComponent<Player>();
         playerObject = col.gameObject;
         if (isJewish)
         {
             textOptions[2].text = diffChoices[0];
             topChoice = true;
         }
         else
         {
             textOptions[2].text = diffChoices[1];
             topChoice = true;
         }

         currentPlayer.AllowMove = false;
         playerPresent = true;
    }

    //handle player choice
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0 && playerPresent)
        {
            topChoice = true;
            choices[0].SetActive(true);
            choices[1].SetActive(false);
        }
        else if(Input.GetAxis("Vertical") < 0 && playerPresent)
        {
            topChoice = false;
            choices[0].SetActive(false);
            choices[1].SetActive(true);
        }

        if (Input.GetButtonDown("Interact")&& playerPresent)
        {
            //reset the dialogue options
            choices[0].SetActive(true);
            choices[1].SetActive(false);
            optionDialogue.SetActive(false);
            
            //release the player if do nothing is chosen
            if (topChoice)
            {
                playerPresent = false;
                currentPlayer.AllowMove = true;
            }
            //otherwise set position and start timer
            else
            {
                //for the jewish player
                if (isJewish)
                {
                    playerObject.transform.position = jSpot.transform.position;
                    
                    //change player sprite/position
                    jPlayerSprites[0].SetActive(false);
                    jPlayerSprites[1].SetActive(true);
                }

                startTimer = true;
            }
        }

        if (startTimer)
        {
            totalTime += Time.deltaTime;
            if (totalTime > 6)
            {
                //load the next level
                if (isJewish)
                {
                    startTimer = false;
                    totalTime = 0;
                    gentilePlayer.SetActive(true);
                }
                else
                {
                    SceneManager.LoadScene(nextScene);
                }
            }
        }
    }
}
