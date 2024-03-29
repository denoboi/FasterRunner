﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using HCB.Core;
using HCB.Utilities;

public class DataEditor : OdinEditorWindow
{
    public PlayerData PlayerData;

    [MenuItem("HyperCasualBase/Data/Player Data Editor")]
    private static void OpenWindow()
    {
        GetWindow<DataEditor>().Show();

    }
    [Button]
    protected override void Initialize()
    {
        base.Initialize();
        PlayerData = SaveLoadManager.LoadPDP(SavedFileNameHolder.PlayerData, new PlayerData());
    }


    [Button]
    public void SaveData()
    {
        SaveLoadManager.SavePDP(PlayerData, SavedFileNameHolder.PlayerData);
    }

    [Button]
    public void DeleteData()
    {
        SaveLoadManager.DeleteFile(SavedFileNameHolder.PlayerData);
        PlayerPrefs.DeleteAll();
        PlayerData = new PlayerData();
    }

}
