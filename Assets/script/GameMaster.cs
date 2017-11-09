using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public ulong userManiWheelCounter = 0;
    public ulong allManiWheelCounter = 0;
    AWSCommunication awscommunication;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        allManiWheelCounter = awscommunication.masterCounter;
        Debug.Log(allManiWheelCounter);
	}
}
