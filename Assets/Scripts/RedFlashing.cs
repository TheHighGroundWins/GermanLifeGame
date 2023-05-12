using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RedFlashing : MonoBehaviour
{
    [SerializeField] private Camera camera;
    bool isRunning = false;
    private float totalTime;
    private Gamepad gamepad;

    private void Start()
    {
        //get gamepad
        gamepad = Gamepad.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
            StartCoroutine(MyCoroutine());
        totalTime += Time.deltaTime;

        RumblePulse(0.25f,1f);
        
        if (totalTime > 10)
        {
            StopRumble();
            SceneManager.LoadScene("KrisAftermath");
        }
    }

    void RumblePulse(float lowFrequency, float highFrequency)
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(lowFrequency, highFrequency);
        }
    }

    void StopRumble()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0,0);
        }
    }

    IEnumerator MyCoroutine(){
         isRunning = true;
        camera.backgroundColor = Color.red;
         yield return new WaitForSeconds(0.1f);
        camera.backgroundColor= Color.black;
         yield return new WaitForSeconds(0.5f);
         isRunning = false;
       }
}
