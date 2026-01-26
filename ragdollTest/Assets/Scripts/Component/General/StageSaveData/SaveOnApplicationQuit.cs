using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//アプリを終える時にセーブする

public class SaveOnApplicationQuit : MonoBehaviour
{
    [SerializeField]
    SaveUtilityOnQuitNowPlaying _saveUtility;

    private void OnApplicationQuit()
    {
        _saveUtility.Save();
    }
}
