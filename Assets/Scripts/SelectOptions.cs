using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectOptions : MonoBehaviour
{
    [SerializeField] private GameObject[] options = new GameObject[2];

    public GameObject[] GetOptions()
    {
        return options;
    }
    
}
