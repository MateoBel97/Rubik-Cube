using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubikHandler : MonoBehaviour
{
    public GameObject piecesContainer;
    public GameObject shadesContainer;
    public GameObject xAxisShade, yAxisShade, zAxisShade;
    public float speed = 1000;
    public MovementTracker movementTracker = new MovementTracker();

    private int _faceToRotate;
    private int[] _indexArray = new int[2];
    private float _degreesMoved;
    private float _degreesToMove = 90;
    private float _movement = 1;
    private bool _isMoving = false;

    private GameObject[] _shades = new GameObject[12];
    private Face[] _faces = {
            new Face("x", -1.0f),
            new Face("x", 0.0f),
            new Face("x", 1.0f),
            new Face("y", -1.0f),
            new Face("y", 0.0f),
            new Face("y", 1.0f),
            new Face("z", -1.0f),
            new Face("z", 0.0f),
            new Face("z", 1.0f),
        };

    void Start()
    {
        _faceToRotate = 10;
        for (int i = 0; i < 9; i++)
        {
            GameObject shade = shadesContainer.transform.GetChild(i).gameObject;
            _shades[i] = shade;
        }
        _shades[9] = xAxisShade;
        _shades[10] = yAxisShade;
        _shades[11] = zAxisShade;

        _shades[_faceToRotate].SetActive(true);
        UpdateFaces();
    }

    void Update()
    {
        if (!_isMoving) { 
            GetKey();
            if (Input.GetMouseButtonDown(0))
            {
                _isMoving = true;
                _movement = 1.0f;
                RotateSelectedFace();
                movementTracker.AddMovement(_faceToRotate, _movement * _degreesToMove);

            }
            if (Input.GetMouseButtonDown(1))
            {
                _movement = -1.0f;
                _isMoving = true;
                RotateSelectedFace();
                movementTracker.AddMovement(_faceToRotate, _movement * _degreesToMove);
            }
        }
    }

    private IEnumerator AnimateFaceRotation()
    {
        while (_degreesMoved < _degreesToMove)
        {
            _degreesMoved += speed * Time.deltaTime;
            _faces[_faceToRotate].Rotate(_movement * speed * Time.deltaTime, true);
            if(_degreesMoved > _degreesToMove)
            {
                _faces[_faceToRotate].Rotate(_movement * (_degreesToMove - _degreesMoved) , true);
            }
            yield return null;
        }
        _faces[_faceToRotate].FixPosition();
        _isMoving = false;
        _degreesMoved = 0;
        UpdateFaces();
        yield return null;
    }

    private IEnumerator AnimateCubeRotation()
    {
        while(_degreesMoved < _degreesToMove)
        {
            _degreesMoved += speed * Time.deltaTime;
            for(int i = _indexArray[0]; i < _indexArray[1]; i++)
            {
                _faces[i].Rotate(_movement * speed * Time.deltaTime, true);
                if (_degreesMoved > _degreesToMove)
                {
                    _faces[i].Rotate(_movement * (_degreesToMove - _degreesMoved), true);
                }
            } 
            yield return null;
        }
        for (int i = _indexArray[0]; i < _indexArray[1]; i++) 
        { 
            _faces[i].FixPosition();
        }
        _isMoving = false;
        _degreesMoved = 0;
        UpdateFaces();
        yield return null;
    }

    void RotateSelectedFace()
    {
        switch (_faceToRotate)
        {
            case 9:
                _indexArray[0] = 0;
                _indexArray[1] = 3;
                StartCoroutine("AnimateCubeRotation");
                break;
            case 10:
                _indexArray[0] = 3;
                _indexArray[1] = 6;
                StartCoroutine("AnimateCubeRotation");
                break;
            case 11:
                _indexArray[0] = 6;
                _indexArray[1] = 9;
                StartCoroutine("AnimateCubeRotation");
                break;
            default:
                StartCoroutine("AnimateFaceRotation");
                break;
        }
    }

    void UpdateFaces()
    {
        ResetCounters();
        for (int i = 0; i < 27; i++)
        {
            GameObject currentPiece = piecesContainer.transform.GetChild(i).gameObject;
            for (int j = 0; j < _faces.Length; j++)
            {
                _faces[j].Update(currentPiece);
            }
        }
    }

    void ResetCounters()
    {
        for (int j = 0; j < _faces.Length; j++)
        {
            _faces[j].ResetCounter();
        }
    }

    void GetKey()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[0].SetActive(true);
            _faceToRotate = 0;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[1].SetActive(true);
            _faceToRotate = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[2].SetActive(true);
            _faceToRotate = 2;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[3].SetActive(true);
            _faceToRotate = 3;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[4].SetActive(true);
            _faceToRotate = 4;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[5].SetActive(true);
            _faceToRotate = 5;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[6].SetActive(true);
            _faceToRotate = 6;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[7].SetActive(true);
            _faceToRotate = 7;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[8].SetActive(true);
            _faceToRotate = 8;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[9].SetActive(true);
            _faceToRotate = 9;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[10].SetActive(true);
            _faceToRotate = 10;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            _shades[_faceToRotate].SetActive(false);
            _shades[11].SetActive(true);
            _faceToRotate = 11;
        }
    }
}
