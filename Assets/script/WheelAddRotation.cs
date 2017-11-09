using UnityEngine;
using UnityEngine.UI;

public class WheelAddRotation : MonoBehaviour {
    public Transform mainWheel;
    public Rigidbody WheelRigidBody;

    private float defaultRotation;
    private bool rotationMinusSwitch = false;

    public GameMaster gamemaster;
	// Use this for initialization
	void Start () {
        defaultRotation = mainWheel.rotation.y;
	}

	// Update is called once per frame
	void Update () {
        Vector3 dir = Vector3.up; // Y軸ということ

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
            gamemaster.userManiWheelCounterUp();
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