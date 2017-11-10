using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotSpinController : MonoBehaviour {
    public Animator slotAnimator;

	// Use this for initialization
	void Start () {

    }

	// Update is called once per frame
	void Update () {
    }

    public void setSlotNumber(int setNumber)
    {
        slotAnimator.SetInteger("InitializeDisplayNumber", setNumber);
    }

    public int getSlotNumber()
    {
        return slotAnimator.GetInteger("InitializeDisplayNumber");
    }

    public void slotCountUp()
    {
        int wheelCounter = getSlotNumber();
        setSlotNumber(wheelCounter + 1);
        slotAnimator.SetTrigger("CountUp");

        wheelCounter = getSlotNumber();
        if(wheelCounter >= 10)
        {
            setSlotNumber(0);
        }
    }
}
