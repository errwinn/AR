using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class VirtualButtonApple1 : MonoBehaviour
{
    public GameObject stroke1, stroke2;
    public VideoPlayer stroke1vp;
    void Start()
    {
        this.gameObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        stroke2.SetActive(false);
        stroke1.SetActive(true);
        stroke1vp.Play();

    }

}
