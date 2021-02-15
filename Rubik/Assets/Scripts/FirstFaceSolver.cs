using UnityEngine;

public class FirstFaceSolver : MonoBehaviour
{
    public string _color;
    public GameObject _centerPiece;
    public GameObject[] _sidePieces = new GameObject[4];

    public void Solve(GameObject[] recievedCenterPieces, GameObject[] recievedSidePieces, GameObject[] recievedCornerPieces)
    {
        FindCenterPiece(recievedCenterPieces);
        FindSidePieces(recievedSidePieces);
    }

    void FindCenterPiece(GameObject[] recievedCenterPieces)
    {
        foreach(GameObject pieceObject in recievedCenterPieces)
        {
            string pieceType= pieceObject.GetComponent<Piece>().pieceType;

            if((pieceType == "Center") && (pieceObject.transform.position.y == 1))
            {
                _color = pieceObject.GetComponent<Piece>().pieceColors[0];
                _centerPiece = pieceObject;
            }
        }
    }

    void FindSidePieces(GameObject[] recievedSidePieces)
    {
        int sidePiecesFound = 0;
        foreach(GameObject pieceObject in recievedSidePieces)
        {
            string[] colors = pieceObject.GetComponent<Piece>().pieceColors;
            foreach(string color in colors)
            {
                if (color == _color)
                {
                    _sidePieces[sidePiecesFound] = pieceObject;
                    sidePiecesFound++;
                }
            }
        }
    }
}
