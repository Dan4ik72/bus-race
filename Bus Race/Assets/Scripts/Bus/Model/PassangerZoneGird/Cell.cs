using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Cell
{
    public const int Width = 1;
    public const int Height = 1;

    Vector3 _position;
    [SerializeField] private bool _isBusy;

    public bool IsBusy => _isBusy;
    public Vector3 Position => _position;

    public Cell(Vector3 position)
    {   
        _position = position;
        _isBusy = false;
    }

    public void SetBusy(bool isBusy)
    {
        _isBusy = isBusy;
    }
}
