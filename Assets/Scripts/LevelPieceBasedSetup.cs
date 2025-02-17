using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class LevelPieceBasedSetup : ScriptableObject
{
    public ArtManager.ArtType artType;


    [Header("Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;

    public int piecesStartNumber = 3;
    public int piecesNumber = 11;
    public int piecesEndNumber = 1;
}
