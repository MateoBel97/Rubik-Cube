using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face
{
    private GameObject[,] _pieces;
    private string _axis;
    private float _axisValue;
    private int _found;
    private Vector3 _target, _direction;

    public Face(string axis, float axisValue)
    {
        _pieces = new GameObject[3, 3];
        _axis = axis;
        _axisValue = axisValue;
        _found = 0;
        switch (axis)
        {
            case "x":
                _target = new Vector3(_axisValue, 0.0f, 0.0f);
                _direction = Vector3.left;
                break;
            case "y":
                _target = new Vector3(0.0f, _axisValue, 0.0f);
                _direction = Vector3.up;
                break;
            case "z":
                _target = new Vector3(0.0f, 0.0f, _axisValue);
                _direction = Vector3.forward;
                break;
        }
    }

    public void Rotate(float degrees, bool animate)
    {
        if (animate)
        {
            for (int i = 0; i < 9; i++)
            {
                Transform tr = _pieces[i / 3, i % 3].transform;
                tr.RotateAround(_target, _direction, degrees);
            }
        }
    }

    public void Update(GameObject piece)
    {
        if(_found < 9)
        {
            Transform tr = piece.transform;
            float pieceAxisValue = getPieceAxisValue(tr);
            if (pieceAxisValue == _axisValue)
            {
                _pieces[_found / 3, _found % 3] = piece;
                _found++;
            }
        }
    }

    public void FixPosition()
    {
        for (int i = 0; i < 9; i++)
        {
            FixPosition(_pieces[i / 3, i % 3].transform);
        }
    }
    public void FixPosition(Transform tr)
    {
        if (tr.position.x > 0.9)
        {
            tr.position = new Vector3(1f, tr.position.y, tr.position.z);
        }
        else if (tr.position.x < -0.9)
        {
            tr.position = new Vector3(-1f, tr.position.y, tr.position.z);
        }
        else
        {
            tr.position = new Vector3(0f, tr.position.y, tr.position.z);
        }

        // Fix Y Position
        if (tr.position.y > 0.9)
        {
            tr.position = new Vector3(tr.position.x, 1.0f, tr.position.z);
        }
        else if (tr.position.y < -0.9)
        {
            tr.position = new Vector3(tr.position.x, -1.0f, tr.position.z);
        }
        else
        {
            tr.position = new Vector3(tr.position.x, 0f, tr.position.z);
        }

        // Fix Z Position
        if (tr.position.z > 0.9)
        {
            tr.position = new Vector3(tr.position.x, tr.position.y, 1.0f);
        }
        else if (tr.position.z < -0.9)
        {
            tr.position = new Vector3(tr.position.x, tr.position.y, -1.0f);
        }
        else
        {
            tr.position = new Vector3(tr.position.x, tr.position.y, 0f); ;
        }
    }

    public void ResetCounter()
    {
        _found = 0;
    }

    float getPieceAxisValue (Transform tr)
    {
        switch (_axis)
        {
            case "x":
                return tr.position.x;
            case "y":
                return tr.position.y;
            case "z":
                return tr.position.z;
            default:
                return 5.0f;
        }
    }
}
