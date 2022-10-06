using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetForShapes : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    public Vector3 Get()
    {
        return offset;
    }
    
}
