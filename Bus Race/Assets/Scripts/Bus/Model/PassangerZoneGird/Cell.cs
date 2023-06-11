using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public const int Width = 1;
    public const int Height = 1;

    private Vector3 _position;
    private bool _isBusy;

    public bool IsBusy => _isBusy;
    public Vector3 Position => _position;
    
    public void SetBusy(bool isBusy)
    {
        _isBusy = isBusy;
    }
}
