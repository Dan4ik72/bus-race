using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerPrefsSaveService : ISaveService
{
    public float LoadFloat(string key)
    {
        CheckKeyOnExistInternal(key);

        return PlayerPrefs.GetFloat(key);
    }

    public int LoadInt(string key)
    {
        CheckKeyOnExistInternal(key);

        return PlayerPrefs.GetInt(key);
    }

    public string LoadString(string key)
    {
        CheckKeyOnExistInternal(key);

        return PlayerPrefs.GetString(key);
    }

    public void SaveFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public bool CheckKeyOnExist(string key) => PlayerPrefs.HasKey(key);

    private void CheckKeyOnExistInternal(string key)
    {
        if (PlayerPrefs.HasKey(key) == false)
            Debug.LogWarning("There is no key with name " + key);
    }
}

