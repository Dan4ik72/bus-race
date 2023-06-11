using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public const int Width = 1;
    public const int Height = 1;

    private bool _isBusy = false;

    public void SetBusy(bool isBusy)
    {
        _isBusy = isBusy;
    }
}
