using UnityEngine;
using UnityEngine.UI;

public class WheelAddRotation : MonoBehaviour {
    public Transform mainWheel;
    public Rigidbody WheelRigidBody;
    public Text WheelRotationText;
    public int wheelIntCount = 0;

    private float defaultRotation;
    private bool rotationMinusSwitch = false;

	// Use this for initialization
	void Start () {
        defaultRotation = mainWheel.rotation.y;
	}

	// Update is called once per frame
	void Update () {
        Vector3 dir = Vector3.up; // Y軸ということ

        WheelRotationText.text = wheelIntCount.ToString();
        if (Input.GetMouseButtonDown(0) == true)
        {
            WheelRigidBody.AddTorque(dir, ForceMode.Impulse);
        }

        wheelCounter();

    }

    private void wheelCounter()
    {
        if(rotationMinusSwitch == true && mainWheel.rotation.y > defaultRotation)
        {
            wheelIntCount++;
        }

        if(mainWheel.rotation.y < 0.0f)
        {
            rotationMinusSwitch = true;
        }
        else
        {
            rotationMinusSwitch = false;
        }

    }
}