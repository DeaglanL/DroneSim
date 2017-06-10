using UnityEngine;

public class RX : MonoBehaviour
{
    //true for xbox type, false for transmitter (set in gui)
    public bool controllerType;

    [Header("output")]
    //vars to be outputted to FC class (may not be needed)
    public float outputRightX;

    public float outputRightY;
    public float outputLeftX;
    public float outputLeftY;
    public float outputSwitch;
    public bool armed;
    public bool angleMode;
    public float outputModeSwitch;

    [Header("input")]
    //assign input from controller
    public float inputRightX;

    public float inputRightY;
    public float inputLeftX;
    public float inputLeftY;
    public bool inputSwitch;
    public bool inputModeSwitch;

    // Use this for initialization
    private void Start()
    {
        outputSwitch = 1000f;
    }

    // Update is called once per frame
    private void Update()
    {
        getInput();
        inputToPWM();
    }

    private void getInput()
    {
        //if inout type,
        //assign to input vars
        if (controllerType)
        {
            //inputs = xbox
            inputLeftX = Input.GetAxis("Horizontal");
            inputLeftY = Input.GetAxis("Vertical");
            inputRightX = Input.GetAxis("xboxRstickX");
            inputRightY = Input.GetAxis("xboxRstickY");
            inputSwitch = Input.GetButtonDown("Left bumper");
            inputModeSwitch = Input.GetButtonDown("Right bumper");
        }
        else
        {
            //inputs = tx
        }
    }

    /// <summary>
    /// takes the input vars and converts them to simulated pwm and outputs to the output vars
    /// </summary>
    private void inputToPWM()
    {
        if (controllerType)
        {
            outputLeftX = (((inputLeftX + 1f) / 2f)) * 1000 + 1000;
            outputLeftY = (((inputLeftY) / 1f)) * 1000 + 1000;
            outputRightX = (((inputRightX + 1f) / 2f)) * 1000 + 1000;
            outputRightY = (((inputRightY + 1f) / 2f)) * 1000 + 1000;

            if (outputLeftY < 1000) //dont allow xbox controller to go below zero throttle
            {
                outputLeftY = 1000;
            }

            if (!armed && inputSwitch == true)
            {
                outputSwitch = 2000f;
                armed = true;
            }
            else if (armed && inputSwitch == true)
            {
                outputSwitch = 1000f;
                armed = false;
            }

            if (!angleMode && inputModeSwitch == true)
            {
                outputModeSwitch = 2000f;
                angleMode = true;
            }
            else if (angleMode && inputModeSwitch == true)
            {
                outputModeSwitch = 1000f;
                angleMode = false;
            }
        }
    }
}