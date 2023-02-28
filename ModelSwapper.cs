using UnityEngine;
using Vuforia;

public class ModelSwapper : MonoBehaviour
{
    public ObserverBehaviour mTarget;
    private GameObject button;

    // Use this for initialization
    void Start()
    {
        if (mTarget == null)
        {
            Debug.Log("Warning: Target not set !!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(mTarget != null)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
    public void SwapModel()
    {
        // Disable any pre-existing augmentation
        GameObject mExistingModel = mTarget.gameObject;

        for (int i = 0; i < mExistingModel.transform.childCount; i++)
        {
            Transform child = mExistingModel.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

        // Create a simple cube object
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Re-parent the cube as child of the trackable gameObject
        cube.transform.parent = mTarget.transform;

        // Adjust the position and scale
        // so that it fits nicely on the target
        cube.transform.localPosition = new Vector3(0, 0.2f, 0);
        cube.transform.localRotation = Quaternion.identity;
        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        // Make sure it is active
        cube.SetActive(true);
    }
}