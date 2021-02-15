using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTracker
{
    private ArrayList _movements = new ArrayList();
    
    public MovementTracker()
    {

    }

    public void AddMovement(int faceRotated, float degreesRotated)
    {
        string movement = string.Concat(faceRotated, " ", degreesRotated);
        _movements.Add(movement);
        Debug.Log(movement);
    }

}
