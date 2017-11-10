using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelAddRotation : MonoBehaviour {
    public wheelVolumeEnhanser wheelvolume;
    public Transform maniWheel;
    public Rigidbody WheelRigidBody;
    public int maxAngularVelocity = 14;
    public float soundMargin = 0.0000005f;
    public float soundCheckDuration = 3.0f;

    private float defaultRotation;
    private bool rotationMinusSwitch = false;

    public GameMaster gamemaster;

    private int beforeWheelRotation = 0;
	// Use this for initialization
	void Start () {
        defaultRotation = maniWheel.rotation.y;
        WheelRigidBody.maxAngularVelocity = maxAngularVelocity;
        StartCoroutine(soundCheckMin());
	}

	// Update is called once per frame
	void Update () {
        Vector3 dir = Vector3.up; // Y軸ということ

        if (Input.GetMouseButtonDown(0) == true)
        {
            WheelRigidBody.AddTorque(dir, ForceMode.Impulse);
            wheelvolume.wheelVolumeMaximum();
        }


        wheelCounter();

    }

    private IEnumerator soundCheckMin()
    {
        while (true) {
            if (beforeWheelRotation == (int)maniWheel.rotation.y)
            {
                wheelvolume.wheelVolumeMin();
            }
            beforeWheelRotation = (int)maniWheel.rotation.y;

            yield return new WaitForSeconds(soundCheckDuration);
        }
    }

    private void wheelCounter()
    {
        if(rotationMinusSwitch == true && maniWheel.rotation.y > defaultRotation)
        {
            gamemaster.userManiWheelCounterUp();
        }

        if(maniWheel.rotation.y < 0.0f)
        {
            rotationMinusSwitch = true;
        }
        else
        {
            rotationMinusSwitch = false;
        }

    }
}