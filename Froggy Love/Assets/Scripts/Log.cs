using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{

    public GameObject position1;
    public GameObject position2;
    public GameObject position3;
    public GameObject position4;
    public GameObject position5;
    GameObject[] positions;
    bool[] positionOccupied;

    void Start()
    {
        positions = new GameObject[] { position1, position2, position3, position4, position5 };
        positionOccupied = new bool[] { false, false, false, false, false };
    }

    // gets the first free position in the list, returns null if there are no free positions
    public GameObject getFreePosition()
    {
        for (int i = 0; i < positionOccupied.Length; i++)
        {
            if (!positionOccupied[i])
            {
                return positions[i];
            }
        }
        return null;
    }

    //returns true if position can be occupied by the caller, false if it can't.
    public bool occupyPosition(GameObject position)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i].Equals(position) && !positionOccupied[i])
            {
                positionOccupied[i] = true;
                return true;
            }
        }
        return false;
    }

    //frees position. returns true if position could be freed, false if it couldn't
    public bool freePosition(GameObject position)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i].Equals(position) && positionOccupied[i])
            {
                positionOccupied[i] = false;
                return true;
            }
        }
        return false;
    }

    public bool isPositionStillFree(GameObject position){
        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i].Equals(position))
            if(positionOccupied[i])
            {
                return false;
            } else {
                return true;
            }
        }
        return false;
    }

}
