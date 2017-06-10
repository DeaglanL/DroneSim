using UnityEngine;

public class LOS_CAM : MonoBehaviour
{
    private GameObject drone;
    public float camDelay;

    // Use this for initialization
    private void Start()
    {
        drone = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        //change camera angle to look towards the drone
        transform.LookAt(drone.transform);
    }
}