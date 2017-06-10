using UnityEngine;

public class Prop_Rotation : MonoBehaviour
{
    public bool direction;
    private GameObject drone;
    public float maxRotation;
    private float rotationSpeed;

    // Use this for initialization
    private void Start()
    {
        drone = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        //rotates the props with throttle when armed
        if (drone.GetComponent<FC>().armed == true)
        {
            rotationSpeed = ((drone.GetComponent<FC>().throttle - 1000) / 1000) * maxRotation;
            rotationSpeed += 50;
        }

        if (direction)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rotationSpeed);
        }
    }
}