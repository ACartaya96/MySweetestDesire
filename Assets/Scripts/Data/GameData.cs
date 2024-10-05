using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;
    public PolygonCollider2D boundingBox;

    public GameData()
    {
        //Default Constructor
        playerPosition = Vector3.zero;
        boundingBox = null;
        
    }
}
