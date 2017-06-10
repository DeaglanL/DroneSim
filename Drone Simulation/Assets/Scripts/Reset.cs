using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public GameObject drone;
    public bool reset;

    // Use this for initialization
    private void Start()
    {
        reset = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //reload the current level
        if (Input.GetButtonDown("Reset") || reset)
        {
            drone.GetComponent<RX>().armed = false;
            drone.GetComponent<FC>().armed = false;
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    public bool getReset
    {
        get { return reset; }
        set { reset = value; }
    }
}