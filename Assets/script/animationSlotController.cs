using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class animationSlotController : MonoBehaviour {
    const int ketaCount = 12; // DynamoDBがこの桁以上を渡すと溢れるようなのでこれを基準とする
    public slotSpinController[] yourSpinController = new slotSpinController[ketaCount];
    public slotSpinController[] masterSpinController = new slotSpinController[ketaCount];


    // Use this for initialization
    void Start () {
        setInitialYourSpinCounter(199998999999);
    }

	// Update is called once per frame
	void Update () {

	}

    // カウンターを初期化する
    public void setInitialYourSpinCounter(ulong setCounter)
    {
        ulong culcrateSetNumber = setCounter;
        for (ulong i = 1; i <= ketaCount; i++)
        {
            ulong answer = 0;
            answer = culcrateSetNumber % 10;

            yourSpinController[i - 1].setSlotNumber((int)answer);
            culcrateSetNumber = culcrateSetNumber / 10;
            if(culcrateSetNumber == 0)
            {
                break;
            }
        }
    }

    // カウンターアップする
    public void setCountUpYourSpinCounter()
    {
        int count = 0;
        count = yourSpinController[0].getSlotNumber();
        yourSpinController[0].slotCountUp();

        if(count == 9) {
            for(int i = 2; i <= ketaCount; i++)
            {
                count = yourSpinController[i - 1].getSlotNumber();
                Debug.LogWarning(count);
                yourSpinController[i - 1].slotCountUp();
                if (count != 9)
                {
                    break;
                }
            }
        }
    }
}
