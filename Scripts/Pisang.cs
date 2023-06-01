using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Pisang : MonoBehaviour
{
    public GameObject stroke1, stroke2, imageTarget;
    public VideoPlayer videoplayer1, videoplayer2;
    public GameObject buttonUIplay, buttonUIreplay, buttonNext, buttonPrev;
    public ObjectData objectData;

    void Update()
    {
        transform.Rotate(new Vector3(0, 1f, 0), Space.Self);
    }

    public void buttonClicked()
    {
        if (objectData.targetname == "pisang")
        {
            buttonUIplay.SetActive(false);
            buttonUIreplay.SetActive(true);
            buttonNext.SetActive(true);
            gameObject.SetActive(false);
            stroke1.SetActive(true);
            videoplayer1.time = 0;
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
        if (objectData.targetname == "pisang")
        {
            if (stroke1.activeInHierarchy)
            {
                stroke1.SetActive(false);
                stroke2.SetActive(true);
                videoplayer2.Play();
                buttonPrev.SetActive(true);
                buttonNext.SetActive(false);
            }
            else if (stroke2.activeInHierarchy)
            {
                stroke2.SetActive(false);
                stroke1.SetActive(true);
                videoplayer1.Play();
                buttonNext.SetActive(true);
                buttonPrev.SetActive(false);
            }
        }
    }
    public void found()
    {
        buttonUIplay.SetActive(true);
        objectData.targetname = "pisang";
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
