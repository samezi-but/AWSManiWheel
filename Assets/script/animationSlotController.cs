using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class animationSlotController : MonoBehaviour {
    const int ketaCount = 12; // DynamoDBがこの桁以上を渡すと溢れるようなのでこれを基準とする
    public slotSpinController[] yourSpinController = new slotSpinController[ketaCount];
    public slotSpinController[] masterSpinController = new slotSpinController[ketaCount];


    // Use this for initialization
    void Start () {
        setInitialSpinCounter(199998999999, yourSpinController);
    }

	// Update is called once per frame
	void Update () {

	}

    public void setInitialYourSpinCounter (ulong setCounter){
        setInitialSpinCounter(setCounter, yourSpinController);
    }

    public void setInitialAWSSpinCounter(ulong setCounter)
    {
        setInitialSpinCounter(setCounter, masterSpinController);
    }


    // カウンターを初期化する
    private void setInitialSpinCounter(ulong setCounter, slotSpinController[] slotSpinController)
    {
        ulong culcrateSetNumber = setCounter;
        for (ulong i = 1; i <= ketaCount; i++)
        {
            ulong answer = 0;
            answer = culcrateSetNumber % 10;

            slotSpinController[i - 1].setSlotNumber((int)answer);
            culcrateSetNumber = culcrateSetNumber / 10;
            if(culcrateSetNumber == 0)
            {
                break;
            }
        }
    }

    public void setCountUpYourSpinCounter()
    {
        setCountUpSpinCounter(yourSpinController);
    }

    // ありがたい功徳をカウントアップする
    private void setCountUpSpinCounter(slotSpinController[] slotSpinController)
    {
        int count = 0;
        count = slotSpinController[0].getSlotNumber();
        slotSpinController[0].slotCountUp();

        if(count == 9) {
            for(int i = 2; i <= ketaCount; i++)
            {
                count = slotSpinController[i - 1].getSlotNumber();
                Debug.LogWarning(count);
                slotSpinController[i - 1].slotCountUp();
                if (count != 9)
                {
                    break;
                }
            }
        }
    }
}
