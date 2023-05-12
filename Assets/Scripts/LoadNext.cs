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
        if (!col.gameObject.Equals(jewishPlayer))
        {
            col.gameObject.SetActive(false);
            jewishPlayer.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
