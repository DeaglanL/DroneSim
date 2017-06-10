using UnityEngine;

public class Motor : MonoBehaviour
{
    public GameObject motorHolder;
    private Transform[] motors;

    [Header("motor forces")]
    public float motorMaxForce;

    public float motorReactionTime;

    public float Force1;
    public float Force2;
    public float Force3;
    public float Force4;

    private float lastForce1;
    private float lastForce2;
    private float lastForce3;
    private float lastForce4;

    public float torqueLevel;

    // Use this for initialization
    private void Start()
    {
        //gets positions for the motors to add force from
        motors = motorHolder.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        //interpolate the force
        Force1 = Mathf.Lerp(lastForce1, Force1, motorReactionTime);
        Force2 = Mathf.Lerp(lastForce2, Force2, motorReactionTime);
        Force3 = Mathf.Lerp(lastForce3, Force3, motorReactionTime);
        Force4 = Mathf.Lerp(lastForce4, Force4, motorReactionTime);

        //save last force values
        lastForce1 = Force1;
        lastForce2 = Force2;
        lastForce3 = Force3;
        lastForce4 = Force4;

        //Provides vertical component of force
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition((motors[1].up * Force1), motors[1].position);
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition((motors[2].up * Force2), motors[2].position);
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition((motors[3].up * Force3), motors[3].position);
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition((motors[4].up * Force4), motors[4].position);

        //Provides torque forces
        gameObject.GetComponent<Rigidbody>().AddTorque(-transform.up * (Force1 * torqueLevel));
        gameObject.GetComponent<Rigidbody>().AddTorque(transform.up * (Force2 * torqueLevel));
        gameObject.GetComponent<Rigidbody>().AddTorque(transform.up * (Force3 * torqueLevel));
        gameObject.GetComponent<Rigidbody>().AddTorque(-transform.up * (Force4 * torqueLevel));
    }

    /// <summary>
    /// Converts the pwm to a percentage of max motor force
    /// </summary>
    /// <param name="input"></param>
    /// <param name="motorNumber"></param>
    public void convertToForce(float input, int motorNumber)
    {
        input -= 1000;
        input = input / 1000;
        input = input * motorMaxForce;

        if (input <= 0f)
        {
            input = 0;
        }

        switch (motorNumber)
        {
            case 1:
                Force1 = input;
                break;

            case 2:
                Force2 = input;
                break;

            case 3:
                Force3 = input;
                break;

            case 4:
                Force4 = input;
                break;

            default:
                break;
        }
    }
}