using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] private String[] interactionText = new string[2];

    public String GetTextBubble(bool isJewish)
    {
        if (isJewish)
        {
            return interactionText[0];
        }
        else
        {
            return interactionText[1];
        }

    }
}
