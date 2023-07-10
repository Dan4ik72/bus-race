using System;

public interface ISaveService
{
    void SaveInt(string key, int value);
    void SaveString(string key, string value);
    void SaveFloat(string key, float value);

    int LoadInt(string key);
    string LoadString(string key);
    float LoadFloat(string key);

    bool CheckKeyOnExist(string key);
}
