using UnityEngine;
using UnityEngine.UI;

public class armedUI : MonoBehaviour
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
        if (getFC.armed)
        {
            gameObject.GetComponent<Text>().text = "Armed";
        }
        else
        {
            gameObject.GetComponent<Text>().text = "Disarmed";
        }
    }
}