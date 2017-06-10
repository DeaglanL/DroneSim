using UnityEngine;
using UnityEngine.UI;

public class modeUI : MonoBehaviour
{
    private FC getFC;

    // Use this for initialization
    private void Start()
    {
        getFC = GameObject.FindGameObjectWithTag("Player").GetComponent<FC>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Updates UI with current mode
        if (getFC.angleMode)
        {
            gameObject.GetComponent<Text>().text = "Angle Mode";
        }
        else
        {
            gameObject.GetComponent<Text>().text = "Acro Mode";
        }
    }
}