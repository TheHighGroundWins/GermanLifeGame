using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BibPlayer : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"Bib.webm");    
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
