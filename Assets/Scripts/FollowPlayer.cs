using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private Transform jTrans;
    [SerializeField] private Transform gTrans;

    [SerializeField] private GameObject jP;
    [SerializeField] private GameObject gP;
    
    
    // Update is called once per frame
    void Update()
    {
        if (jP.activeSelf)
        {
            transform.position =
                new Vector3(jTrans.position.x,
                    jTrans.position.y, transform.position.z);
        }

        if (gP.activeSelf)
        {
            transform.position =
                new Vector3(gTrans.position.x,
                    gTrans.position.y, transform.position.z);
        }
    }
}
