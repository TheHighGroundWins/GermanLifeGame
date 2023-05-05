using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{
    //reference to player
    [SerializeField] private GameObject jewishPlayer;
    [SerializeField] private String nextScene;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Gentile" && SceneManager.GetActiveScene().name=="Intro")
        {
            col.gameObject.SetActive(false);
            jewishPlayer.SetActive(true);
        }
        else if(SceneManager.GetActiveScene().name=="Intro")
        {
            SceneManager.LoadScene(nextScene);
        }
        if (col.name == "Jewish" && SceneManager.GetActiveScene().name=="Mid")
        {
            col.gameObject.SetActive(false);
            jewishPlayer.SetActive(true);
        }
        else if(SceneManager.GetActiveScene().name=="Mid")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
