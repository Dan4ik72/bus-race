using TMPro;
using UnityEngine;

public class BusPartsExpandHandler
{
    private Transform _rightWall, _leftWall, _backWall, _frontWall;

    private Vector2 _expandValue;

    public BusPartsExpandHandler(Transform rightWall, Transform leftWall, Transform backWall, Transform frontWall)
    {
        _rightWall = rightWall;
        _leftWall = leftWall;
        _backWall = backWall;
        _frontWall = frontWall;
    }

    public void OnExpand(Vector2 expandValue)
    {
        _expandValue = expandValue;

        ExpandPart(_rightWall, new Vector3(0, 0, _expandValue.y / 2), new Vector3(_expandValue.x, 0, 0));
        ExpandPart(_leftWall, new Vector3(0, 0, -_expandValue.y / 2), new Vector3(_expandValue.x, 0, 0));
        ExpandPart(_frontWall, new Vector3(_expandValue.x / 2, 0 ,0) , new Vector3(_expandValue.y, 0, 0));
        ExpandPart(_backWall, new Vector3(-_expandValue.x / 2, 0 ,0) , new Vector3(_expandValue.y, 0, 0));
    }

    private void ExpandPart(Transform part, Vector3 positionOffcet, Vector3 scaleOffcet)
    {
        part.position = new Vector3(part.position.x + positionOffcet.x, part.position.y + positionOffcet.y, part.position.z + positionOffcet.z);
        part.localScale = new Vector3(part.localScale.x + scaleOffcet.x, part.localScale.y + scaleOffcet.y, part.localScale.z + scaleOffcet.z);
    }
}

