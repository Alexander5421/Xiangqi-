using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MyListWrapper {
    public List<int> myList;
}
public class GameManager : MonoBehaviour
{
    public Chess chessInstance;
    public List<Transform> piecePositions;
    public List<GameObject> piecePrefabs;
    public Transform piecesHolder;
    private Transform IndexToPos (int x, int y)
    {
        return piecePositions[x * 9 + y];
    } 
    
    [ContextMenu("Test serialize")]
    public void TestSerialize()
    {
        // first initialize the chessInstance
        chessInstance = new Chess();
        // add some pieces
        chessInstance.AddPiece(PieceType.Cannon, 1, 1, true);
        chessInstance.AddPiece(PieceType.Soldier, 2, 2, false);
        // serialize the chessInstance
        Debug.Log(chessInstance.SerializeToJson());
        // Save to "Assets/TestCases/chess.json"
        System.IO.File.WriteAllText("Assets/TestCases/chess.json", chessInstance.SerializeToJson());
    }
    [ContextMenu("Test deserialize")]
    public void TestDeserialize()
    {
        // load the chessInstance from "Assets/TestCases/chess.json"
        chessInstance.LoadFromJson("Assets/TestCases/standard.json");
        PutPieces();
    }

    public void PutPieces()
    {
        int count = 0;
        // destroy all the children of piecesHolder
        while (piecesHolder.childCount>0&&count<100)
        {
            count++;
            DestroyImmediate(piecesHolder.GetChild(0).gameObject);
        }
        // based on chessInstance.pieces, put the pieces on the board
        foreach (var piece in chessInstance.pieces)
        {
            int idx = (int)piece.type + (piece.isRed ? 0 : 7);
            // instantiate a new piecePrefab
            GameObject pieceObj = Instantiate(piecePrefabs[idx], piecesHolder, true);
            // set the rotation of the piecePrefab to be the same as the piecePrefab
            pieceObj.transform.localRotation = Quaternion.Euler(0,-5,0);
            // set the position of the piecePrefab
            pieceObj.transform.position = IndexToPos(piece.x, piece.y).position;
            // set the parent of the piecePrefab to be the current gameObject
        }
    }

    private void Start()
    {
        // MyListWrapper list = new MyListWrapper();
        // list.myList = new List<int>() {1, 2, 3, 4, 5};
        // Debug.Log(JsonUtility.ToJson(list));
        //
    }
}
