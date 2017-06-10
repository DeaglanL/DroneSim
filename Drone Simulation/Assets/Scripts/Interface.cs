using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    private GameObject drone;
    public GameObject GUI;
    public bool Paused;

    [Header("GUI objects")]
    public Text rollP;

    public Text rollI;
    public Text rollD;
    public Text pitchP;
    public Text pitchI;
    public Text pitchD;
    public Text yawP;
    public Text yawI;
    public Text yawD;

    // Use this for initialization
    private void Start()
    {
        drone = GameObject.FindGameObjectWithTag("Player");
        GUI.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        //opens PID gui if pause key is pressed and gui isnt open
        if (Input.GetButtonDown("PAUSE") && !GUI.activeSelf)
        {
            GUI.SetActive(true);
            GUIupdate();
        }
        else if (Input.GetButtonDown("PAUSE") && GUI.activeSelf) //closes gui if pause is press when gui is open
        {
            GUI.SetActive(false);
        }

        if (GUI.activeSelf)
        {
            GUIupdate();
        }

        exit();
    }

    //Updates PID values in gui
    private void GUIupdate()
    {
        rollP.text = string.Format("{0}", drone.GetComponent<FC>().rollPID[0].ToString("0.00"));
        rollI.text = string.Format("{0}", drone.GetComponent<FC>().rollPID[1].ToString("0.00"));
        rollD.text = string.Format("{0}", drone.GetComponent<FC>().rollPID[2].ToString("0.00"));

        pitchP.text = string.Format("{0}", drone.GetComponent<FC>().pitchPID[0].ToString("0.00"));
        pitchI.text = string.Format("{0}", drone.GetComponent<FC>().pitchPID[1].ToString("0.00"));
        pitchD.text = string.Format("{0}", drone.GetComponent<FC>().pitchPID[2].ToString("0.00"));

        yawP.text = string.Format("{0}", drone.GetComponent<FC>().yawPID[0].ToString("0.00"));
        yawI.text = string.Format("{0}", drone.GetComponent<FC>().yawPID[1].ToString("0.00"));
        yawD.text = string.Format("{0}", drone.GetComponent<FC>().yawPID[2].ToString("0.00"));
    }

    //If the escaple key is pressed the simulator closes
    private void exit()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}