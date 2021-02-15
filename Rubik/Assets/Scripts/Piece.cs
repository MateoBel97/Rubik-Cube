using UnityEngine;

public class Piece : MonoBehaviour
{
    public string pieceType;
    public string[] pieceColors;
    public bool matched = true;
    void Start()
    {
        string name = transform.gameObject.name;
        pieceType = name.Split('_')[0];
        char[] colors = name.Split('_')[1].ToCharArray();
        pieceColors = new string[colors.Length];
        int i = 0;
        foreach(char color in colors)
        {
            pieceColors[i] = colors[i].ToString();
            i++;
        }
    }
}
