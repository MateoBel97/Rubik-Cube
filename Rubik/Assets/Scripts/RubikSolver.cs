using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubikSolver : MonoBehaviour
{
    public GameObject piecesContainer;

    private FirstFaceSolver _firstFaceSolver;
    public GameObject[] _centerPieces = new GameObject[6];
    public GameObject[] _sidePieces = new GameObject[12];
    public GameObject[] _cornerPieces = new GameObject[8];
    public GameObject _nonePiece;

    private string yP;

    /*
        Step 1: Choosing a color
    */
    // Start is called before the first frame update
    void ClasifyPieces()
    {
        int centerPiecesFound = 0;
        int sidePiecesFound = 0;
        int cornerPiecesFound = 0;

        for(int i = 0; i < 27; i++)
        {
            GameObject pieceObject = piecesContainer.transform.GetChild(i).gameObject;
            string pieceType = pieceObject.GetComponent<Piece>().pieceType;
            switch (pieceType)
            {
                case "Center":
                    _centerPieces[centerPiecesFound] = pieceObject;
                    centerPiecesFound++;
                    break;
                case "Side":
                    _sidePieces[sidePiecesFound] = pieceObject;
                    sidePiecesFound++;
                    break;
                case "Corner":
                    _cornerPieces[cornerPiecesFound] = pieceObject;
                    cornerPiecesFound++;
                    break;
                default:
                    _nonePiece = gameObject;
                    break;
            }
        }

        _firstFaceSolver = transform.GetComponent<FirstFaceSolver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClasifyPieces();
            Solve();
        }
    }

    void Solve()
    {
        _firstFaceSolver.Solve(_centerPieces, _sidePieces, _cornerPieces);
    }
}
