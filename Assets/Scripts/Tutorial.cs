using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorial1;
    [SerializeField] private GameObject tutorial2;
    [SerializeField] private Player[] player = new Player[2];

    private void Start()
    {
        player[0].AllowMove = false;
        player[1].AllowMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial1.activeSelf)
        {
            if (Input.GetButtonDown("Interact"))
            {
                tutorial2.SetActive(true);
                tutorial1.SetActive(false);
            }
        }
        else
        {
            if (Input.GetButtonDown("Interact"))
            {
                tutorial2.SetActive(false);
                player[0].AllowMove = true;
                player[1].AllowMove = true;
                Destroy(this);
            }
        }
    }
}
