using UnityEngine;

public class IMU : MonoBehaviour
{
    public float maxAngularVelocity;

    [Header("Gyro")]
    public Vector3 gyro;

    private Vector3 angSpeed = Vector3.zero;

    private Quaternion lastRot;
    private Quaternion deltaRot;

    private Vector3 eulerRot;

    public float gyroRoll;
    public float gyroPitch;
    public float gyroYaw;

    [Header("Acc")]
    public Quaternion acc;

    public float accRoll;
    public float accPitch;
    public float accYaw;
    public Vector3 accCalipoint;

    // Use this for initialization
    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().maxAngularVelocity = maxAngularVelocity;

        accCalipoint = gameObject.transform.eulerAngles;

        lastRot = transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        gyroUpdate();
    }

    //update the gyros values
    public void gyroUpdate()
    {
        //------------------------------------------------------------------------------------------------------------
        //Previous implementation using unitys rigidbody methods
        //gyro = gameObject.GetComponent<Rigidbody>().angularVelocity;

        //gyroPitch = Mathf.Rad2Deg * gyro.x;
        //gyroRoll = Mathf.Rad2Deg * gyro.z;
        //gyroYaw = Mathf.Rad2Deg * gyro.y;

        //------------------------------------------------------------------------------------------------------------
        deltaRot = transform.rotation * Quaternion.Inverse(lastRot); //work out the change in rotation
        eulerRot = new Vector3(Mathf.DeltaAngle(0, deltaRot.eulerAngles.x), Mathf.DeltaAngle(0, deltaRot.eulerAngles.y), Mathf.DeltaAngle(0, deltaRot.eulerAngles.z)); //convert to euler angles

        angSpeed = eulerRot / Time.deltaTime; //divide by the change in time to get per second val

        gyroPitch = angSpeed.x;
        gyroRoll = angSpeed.z;
        gyroYaw = angSpeed.y;

        lastRot = transform.rotation; //save last rotation
        //----------------------------------------------------------------------------------------------------------
        //Test to see if a different implementation would fix gyro issues
        //deltaRot = transform.rotation * Quaternion.Inverse(lastRot);
        //deltaRot.ToAngleAxis(out mag, out angSpeed);

        //var angularVelocity = (angSpeed * mag) / Time.deltaTime;

        //gyroPitch = angularVelocity.x;
        //gyroRoll = angularVelocity.z;
        //gyroYaw = angularVelocity.y;

        //lastRot = transform.rotation;
        //---------------------------------------------------------------------------------------------------------
    }

    //update the accelerometer values
    public void accUpdate()
    {
        accRoll = gameObject.transform.eulerAngles.z - accCalipoint.z;

        if (accRoll > 90 && accRoll < 270)
        {
            accRoll -= 180;
        }

        if (accRoll > 270 && accRoll < 360)
        {
            accRoll -= 360;
        }

        accPitch = gameObject.transform.eulerAngles.x - accCalipoint.x;

        if (accPitch > 90 && accPitch < 270)
        {
            accPitch -= 180;
        }

        if (accPitch > 270 && accPitch < 360)
        {
            accPitch -= 360;
        }
    }
}