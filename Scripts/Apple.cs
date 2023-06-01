using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Apple : MonoBehaviour
{
    public GameObject stroke1, imageTarget, stroke2;
    public VideoPlayer videoplayer1, videoplayer2;
    public GameObject buttonUIplay, buttonUIreplay, buttonNext, buttonPrev;
    public ObjectData objectData;

    private void Start()
    {
        videoplayer1.Stop();
        videoplayer2.Stop();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1f, 0), Space.Self);
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void buttonClicked()
    {
        if(objectData.targetname == "apel") 
        {  
            buttonUIplay.SetActive(false);
            buttonUIreplay.SetActive(true);
            buttonNext.SetActive(true);
            gameObject.SetActive(false);
            stroke1.SetActive(true);
            videoplayer1.Play();
        }

    }

    public void replay()
    {
        videoplayer1.Stop();
        videoplayer1.time = 0;
        videoplayer1.Play();
        videoplayer2.Stop();
        videoplayer2.time = 0;
        videoplayer2.Play();
    }

    public void switchChar()
    {
        if(objectData.targetname == "apel")
        {
            if (stroke1.activeInHierarchy)
            {
                stroke1.SetActive(false);
                stroke2.SetActive(true);
                videoplayer2.Play();
                buttonNext.SetActive(false);
                buttonPrev.SetActive(true);
            } else if (stroke2.activeInHierarchy)
            {
                stroke2.SetActive(false);
                stroke1.SetActive(true);
                videoplayer1.Play();
                buttonPrev.SetActive(false);
                buttonNext.SetActive(true);
            }
        }
    }
    public void found()
    {
        buttonUIplay.SetActive(true);
        objectData.targetname = "apel";
    }

    public void lost()
    {
        buttonUIplay.SetActive(false);
        buttonUIreplay.SetActive(false);
        buttonNext.SetActive(false);
        buttonPrev.SetActive(false);
        gameObject.SetActive(true);
        stroke1.SetActive(false);
        stroke2.SetActive(false);
    }
}
