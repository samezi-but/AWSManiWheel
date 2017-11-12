using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(yourKudokuSaveAndLoad))]
public class saveEditor : Editor
{
    // 調査用メソッド
    private string setCounter;

    public override void OnInspectorGUI()
    {

        //　シリアライズオブジェクトの更新
        serializedObject.Update();
        Rect rect = GUILayoutUtility.GetRect(10, 20);
        if (GUILayout.Button("ローカルにセーブ"))
        {
            PlayerPrefs.SetString("KUDOKU", "999998");
        }
        //　シリアライズオブジェクトのプロパティの変更を更新
        serializedObject.ApplyModifiedProperties();


    }
}