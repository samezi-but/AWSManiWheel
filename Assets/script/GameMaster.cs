﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    private ulong userManiWheelCounter = 0;
    private ulong allManiWheelCounter = 0;
    private ulong userTempCounter = 0;
    public float postTimeDuration = 10.0f;

    public AWSCommunication awscommunication;
    public animationSlotController animationslot;

	// Use this for initialization
	void Start () {
        awscommunication.startGetWheelCount();
        StartCoroutine(postWheelCountAndResetTempCount());
	}

	// Update is called once per frame
	void Update () {

	}

    public void setAllManiWheelCounter(ulong setCount)
    {
        allManiWheelCounter = setCount;
        animationslot.setInitialAWSSpinCounter(setCount);
    }

    private IEnumerator postWheelCountAndResetTempCount()
    {
        while (true) {
            awscommunication.AWSManiwheelCountUp(userTempCounter);
            userTempCounter = 0;
            yield return new WaitForSeconds(postTimeDuration);
        }
    }

    public void userManiWheelCounterUp()
    {
        userTempCounter++;
        userManiWheelCounter++;
        animationslot.setCountUpYourSpinCounter();
    }

    public void allManiWheelCountUpDifference( ulong differCount)
    {
        StartCoroutine(AWSSpinAnimationStepCount(differCount));
    }

    private IEnumerator AWSSpinAnimationStepCount(ulong count)
    {
        ulong i = 0;

        while(i < count) {
            yield return new WaitForSeconds(1.0f);
            animationslot.setCountUpAWSSpinCounter();
            i++;
        }
    }
}
