using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
    public float speed;
    public GameObject drone;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void LateUpdate() { 
        gameObject.transform.LookAt(drone.transform);
        gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
	}
}
