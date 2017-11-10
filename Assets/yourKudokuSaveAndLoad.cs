using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yourKudokuSaveAndLoad : MonoBehaviour {
    private const string yourKudoku = "KUDOKU";

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    public void saveKudoku(ulong kudokuCount)
    {
        string ketaStringCount = kudokuCount.ToString();
        PlayerPrefs.SetString(yourKudoku, ketaStringCount);
    }

    public ulong loadKudoku()
    {
        string tempString = PlayerPrefs.GetString(yourKudoku, "0");
        ulong returnUlong = ulong.Parse(tempString);

        return returnUlong;
    }
}
