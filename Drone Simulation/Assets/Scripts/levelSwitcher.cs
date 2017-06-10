using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSwitcher : MonoBehaviour
{
    public bool click;
    public int numOfScenes;

    // Use this for initialization
    private void Start()
    {
        click = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //When button is clicked load the next scene if there is no next scene load first scene
        if (click)
        {
            if (SceneManager.GetActiveScene().buildIndex >= numOfScenes)
            {
                SceneManager.LoadScene((1), LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1), LoadSceneMode.Single);
            }

            click = false;
        }
    }

    public bool Click
    {
        get { return click; }
        set { click = value; }
    }
}