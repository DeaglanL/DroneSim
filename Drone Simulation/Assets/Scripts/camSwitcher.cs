using UnityEngine;
using UnityEngine.UI;

public class camSwitcher : MonoBehaviour
{
    public GameObject fpvCamera;
    public GameObject losCamera;
    private Camera fpvCam;
    private Camera losCam;
    private bool camSwitch;
    private bool click;

    // Use this for initialization
    private void Start()
    {
        fpvCam = fpvCamera.GetComponent<Camera>();
        losCam = losCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        //runs the clicker method when the button that this script is attached to is clicked
        gameObject.GetComponent<Button>().onClick.AddListener(clicker);

        if (camSwitch)
        {
            losCam.enabled = true;
            fpvCam.enabled = false;
        }
        else if (!camSwitch)
        {
            fpvCam.enabled = true;
            losCam.enabled = false;
        }
    }

    private void clicker()
    {
        if (!click)
        {
            click = true;
        }
        else if (click)
        {
            click = false;
        }

        camSwitch = click;
    }
}