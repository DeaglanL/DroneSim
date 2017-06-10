using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    bool start; 
	// Use this for initialization
	void Start () {
        start = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
	}
    public bool button
    {
        get { return start; }
        set { start = value; }
    }
}
