using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class animationSlotController : MonoBehaviour {
    const int ketaCount = 12; // DynamoDBがこの桁以上を渡すと溢れるようなのでこれを基準とする
    public slotSpinController[] yourSpinController = new slotSpinController[ketaCount];
    public slotSpinController[] masterSpinController = new slotSpinController[ketaCount];

    public GameMaster gamemaster;

    // Use this for initialization
    void Start () {

    }

	// Update is called once per frame
	void Update () {
	}

    public void setInitialYourSpinCounter (ulong setCounter)
    {
        setInitialSpinCounter(setCounter, yourSpinController);
    }

    public void setInitialAWSSpinCounter(ulong setCounter)
    {
        setInitialSpinCounter(setCounter, masterSpinController);
    }


    // カウンターを初期化する
    private void setInitialSpinCounter(ulong setCounter, slotSpinController[] slotSpinController)
    {
        slotSpinController[0].setSlotNumber(0);
        ulong culcrateSetNumber = setCounter;
        for (ulong i = 1; i <= ketaCount; i++)
        {
            ulong answer = 0;
            answer = culcrateSetNumber % 10;

            slotSpinController[i - 1].setSlotNumber((int)answer);
            culcrateSetNumber = culcrateSetNumber / 10;
            if(culcrateSetNumber == 0)
            {
                for(ulong j = i; j < ketaCount; j++)
                {
                    slotSpinController[j].setSlotNumber(0);
                }
                break;
            }
        }
    }


    public void setCountUpYourSpinCounter()
    {
        setCountUpSpinCounter(yourSpinController);
    }

    public void setCountUpAWSSpinCounter()
    {
        setCountUpSpinCounter(masterSpinController);
    }

    // ありがたい功徳をカウントアップする
    private void setCountUpSpinCounter(slotSpinController[] slotSpinController)
    {
        int nowNumber = slotSpinController[0].getSlotNumber();
        int beforeNumber = 0;
        bool[] flag = new bool[ketaCount];
        bool firstFlag = false;
        Debug.LogWarning("setCountUpSpinCounter firstSlotNumber is :" + nowNumber.ToString());
        if (nowNumber == 9)
        {
            for (int i = 1; i < ketaCount; i++)
            {
                beforeNumber = slotSpinController[i].getSlotNumber();
                if(firstFlag == false)
                {
                    flag[i] = true;
                }
                else {
                    flag[i] = false;
                }

                if (beforeNumber == 9)
                {
                    flag[i] = true;
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = 1; i < ketaCount; i++)
        {
            if (flag[i] == true)
            {
                //slotSpinController[i].slotCountUp();
                StartCoroutine(countUpShift(slotSpinController, flag));
            }
        }

        slotSpinController[0].slotCountUp();
    }

    private IEnumerator countUpShift(slotSpinController[] slotContloller, bool[] ketaUpFlag)
    {
        Debug.LogWarning("countUpShift calling");
        for(int i = 1; i<ketaCount; i++)
        {
            if (ketaUpFlag[i] == true)
            {
                Debug.LogWarning("counter:[" + ketaUpFlag[i].ToString()+"]");
                slotContloller[i].slotCountUp();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private int getSlotCount(ulong setCounter, int keta)
    {
        ulong answer = 0;
        for (ulong i = 0; i <= ketaCount; i++)
        {
            answer = 0;
            answer = setCounter % 10;
            setCounter = setCounter / 10;
            if ((ulong)keta == i)
            {
                break;
            }
        }
        return (int)answer;
    }
}
