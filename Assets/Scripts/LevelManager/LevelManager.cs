using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> levels;

    [SerializeField] private int _index;

    [Header("Pieces")]
    public List<LevelPieceBase> levelsPiecesStart;
    public List<LevelPieceBase> levelsPieces;
    public List<LevelPieceBase> levelsPiecesEnd;
    public int pieceStartNumber = 3;
    public int pieceNumber = 5;
    public int pieceEndNumber = 1;
    public float timeBetweenPieces = .3f;

    private GameObject _currentLevel;

    public List<LevelPieceBase> _spawnedPieces;

    private void Awake()
    {
        //SpawnNextLevel();
        CreateLevelPieces();
    }

    private void SpawnNextLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    #region
    private void CreateLevelPieces()
    {
        //StartCoroutine(createLevelPiecesCoroutine());

        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < pieceStartNumber; i++)
        {
            CreateLevelPiece(levelsPiecesStart);
        }

        for (int i = 0; i < pieceNumber; i++)
        {
            CreateLevelPiece(levelsPieces);
        }

        for (int i = 0; i < pieceEndNumber; i++)
        {
            CreateLevelPiece(levelsPiecesEnd);
        }
    }
    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece  = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        _spawnedPieces.Add(spawnedPiece);

    }

    IEnumerator createLevelPiecesCoroutine()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < pieceNumber; i++)
        {
            CreateLevelPiece(levelsPieces);
            yield return new WaitForSeconds(timeBetweenPieces);
        }
    }
    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            SpawnNextLevel();
        }
    }
}
