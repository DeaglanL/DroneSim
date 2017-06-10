using UnityEngine;

public class FPV_CAM : MonoBehaviour
{
    public float angle;
    public float fov;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //set field of view of the fpv camera
        if (fov > 60 && fov < 120)
        {
            gameObject.GetComponent<Camera>().fieldOfView = fov;
        }

        //Sets the angle of the fpv camera
        gameObject.transform.localRotation = new Quaternion(angle, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z, gameObject.transform.localRotation.w);
    }

    public float setfov
    {
        get { return fov; }
        set { fov = value; }
    }

    public float setAngle
    {
        get { return angle; }
        set { angle = value; }
    }
}