// data of a board of chinese chess

using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public enum PieceType
{
    // all pieces
    General, Advisor, Elephant, Horse, Chariot, Cannon, Soldier,
}
[Serializable]
public struct Piece
{
    public int x, y;
    public PieceType type;
    public bool isRed;
}
[Serializable]
public struct JsonPiece
{
    public string type;
    public int x, y;
    public bool isRed;
}


[Serializable]
public class Chess
{
    [Serializable]
    private class SerializationHelper
    {
        public List<JsonPiece> pieces;
    }
    public List<Piece> pieces = new List<Piece>();

    public void LoadFromJson(string jsonPath)
    {
        string json = System.IO.File.ReadAllText(jsonPath);
        List<JsonPiece> jsonPieces = JsonUtility.FromJson<SerializationHelper>(json).pieces;
        pieces = jsonPieces.ConvertAll(jsonPiece => new Piece
        {
            x = jsonPiece.x,
            y = jsonPiece.y,
            type = (PieceType)Enum.Parse(typeof(PieceType), jsonPiece.type),
            isRed = jsonPiece.isRed
        });

    }
    public string SerializeToJson()
    {
        // save the pieces list to json file named "chess.json"
        List<JsonPiece> jsonPieces = pieces.ConvertAll(piece => new JsonPiece
        {
            x = piece.x,
            y = piece.y,
            type = piece.type.ToString(),
            isRed = piece.isRed
        });
        SerializationHelper helper = new SerializationHelper { pieces = jsonPieces };
        return JsonUtility.ToJson(helper, true);
    }
    
    public void AddPiece(PieceType type, int x, int y, bool isRed)
    {
        Piece piece = new Piece();
        piece.type = type;
        piece.x = x;
        piece.y = y;
        piece.isRed = isRed;
        pieces.Add(piece);
    }
    public void DeletePiece(int x, int y)
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].x == x && pieces[i].y == y)
            {
                pieces.RemoveAt(i);
                break;
            }
        }
    }
}

