using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Stroberi : MonoBehaviour
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
        if (objectData.targetname == "stroberi")
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
        videoplayer1.time = 0.2f;
        videoplayer1.Play();
        videoplayer2.Stop();
        videoplayer2.time = 0.2f;
        videoplayer2.Play();
    }

    public void switchChar()
    {
        if (objectData.targetname == "stroberi")
        {
            if (stroke1.activeInHierarchy)
            {
                stroke1.SetActive(false);
                stroke2.SetActive(true);
                videoplayer2.Play();
                buttonNext.SetActive(false);
                buttonPrev.SetActive(true);
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
        objectData.targetname = "stroberi";
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
