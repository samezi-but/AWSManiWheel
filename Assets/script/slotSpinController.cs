using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotSpinController : MonoBehaviour {
    public Animator slotAnimator;

	// Use this for initialization
	void Start () {
        setSlotNumber(1);
        slotCountUp();
        slotCountUp();
        slotCountUp();
        slotCountUp();
        slotCountUp();
    }

	// Update is called once per frame
	void Update () {
    }

    public void setSlotNumber(int setNumber)
    {
        slotAnimator.SetInteger("InitializeDisplayNumber", setNumber);
    }

    public void slotCountUp()
    {
        slotAnimator.SetTrigger("CountUp");
    }
}
