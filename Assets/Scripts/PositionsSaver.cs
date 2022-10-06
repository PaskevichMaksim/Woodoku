using System;
using System.Collections.Generic;
using UnityEngine;

public class PositionsSaver : MonoBehaviour
{
    private List<List<Vector3>> _positions = new List<List<Vector3>>();


    private void Awake ()
    {
        FindAndSavePositions();
    }

    private void FindAndSavePositions()
    {
        Vector3 tempScale = transform.localScale;
        Quaternion tempRotation = transform.rotation;
        transform.localScale = Vector3.one;
        transform.localPosition += transform.GetComponent<OffsetForShapes>().Get();

        for (int i = 0; i < 4; i++)
        {
            if(i!=0)
            transform.Rotate(0, 0, -90f);
            
            List<Vector3> tempList = new List<Vector3>();
            foreach (Transform square in transform)
            {
                tempList.Add(square.position);
            }
            _positions.Add(tempList);
        }
        
        transform.localPosition -= transform.GetComponent<OffsetForShapes>().Get();
        transform.localScale = tempScale;
        transform.rotation = tempRotation;
    }

    public List<List<Vector3>> GetPositions()
    {
        return _positions;
    }
}