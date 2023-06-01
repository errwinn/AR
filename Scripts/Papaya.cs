using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Papaya : MonoBehaviour
{
    public Material materialStroke;
    public GameObject stroke1, stroke2, imageTarget;
    public VideoPlayer videoplayer1, videoplayer2;
    public GameObject buttonUIplay, buttonUIreplay, buttonNext, buttonPrev;
    public ObjectData objectData;

    private void Start()
    {
        videoplayer1.Pause();
        videoplayer2.Pause();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1f, 0), Space.Self);
    }

    public void buttonClicked()
    {
        if(objectData.targetname == "pepaya")
        {
            buttonUIplay.SetActive(false);
            buttonUIreplay.SetActive(true);
            buttonNext.SetActive(true);
            gameObject.SetActive(false);
            stroke1.SetActive(true);
            videoplayer1.Play();
        }
    }

    public void switchChar()
    {
        if (objectData.targetname == "pepaya")
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
                buttonPrev.SetActive(false);
                buttonNext.SetActive(true);
            }
        }
    }

    public void replay()
    {
        videoplayer1.time = 0f;
        videoplayer1.Play();
        videoplayer2.time = 0f;
        videoplayer2.Play();
    }

    public void found()
    {
        buttonUIplay.SetActive(true);
        objectData.targetname = "pepaya";
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
