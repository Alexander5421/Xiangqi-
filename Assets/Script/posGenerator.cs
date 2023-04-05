using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class posGenerator : MonoBehaviour
{
    public float interval = 1.0f;
    public Transform posRed = null;
    public GameObject posPrefab;

    [ContextMenu("Generate Piece Positions")]
    public void GeneratePiecePositions()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                // instantiate a new posPrefab
                GameObject pos = Instantiate(posPrefab, transform, true);
                pos.transform.localPosition = new Vector3(-j * interval, 0, i * interval);
                // set the name of the posPrefab to be the index of the posPrefab
                pos.name = i + "," + j;
                // set the position of the posPrefab
                
                
                // set the parent of the posPrefab to be the current gameObject
            }
        }        
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                // instantiate a new posPrefab
                GameObject pos = Instantiate(posPrefab, transform, true);
                pos.transform.localPosition = new Vector3(-j * interval+posRed.localPosition.x, 0, i * interval+posRed.localPosition.z);
                // set the name of the posPrefab to be the index of the posPrefab
                pos.name = i+5 + "," + j;
                // set the position of the posPrefab
                
                
                // set the parent of the posPrefab to be the current gameObject
            }
        }  
    }
}