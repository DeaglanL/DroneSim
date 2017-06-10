using UnityEngine;

public class rotationTester : MonoBehaviour
{
    public float rollSpeed = 100f;
    public float pitchSpeed = 100f;
    public float yawSpeed = 100f;
    private Vector3 rot;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        rot = this.transform.rotation.eulerAngles;
        rot.z += rollSpeed * Time.deltaTime;
        rot.x += pitchSpeed * Time.deltaTime;
        rot.y += yawSpeed * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(rot);
    }
}