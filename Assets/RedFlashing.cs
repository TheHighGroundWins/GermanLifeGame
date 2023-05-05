using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedFlashing : MonoBehaviour
{
    [SerializeField] private Camera camera;
    bool isRunning = false;
    private float totalTime;
    
    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
            StartCoroutine(MyCoroutine());
        totalTime += Time.deltaTime;

        if (totalTime > 15)
        {
            SceneManager.LoadScene("Bibliography");
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
