using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class ShowClosestTile : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMap;

    [SerializeField] private Transform _player;

    [SerializeField] private Tile _tile;

    [SerializeField] private List<Vector3> _tilesAdresses = new List<Vector3>();
    private Vector3 _currentTileAdress;
    private Vector3 _previousTileAdress;

    private UnityEngine.Color _invisible = new UnityEngine.Color(0, 0, 0, 0);
    private UnityEngine.Color _visible = new UnityEngine.Color(1, 1, 1, 1);


    // Start is called before the first frame update
    void Start()
    {
        GetTileAdresses();
        
        foreach (var tileAdress in _tilesAdresses)
        {
            _tileMap.SetTileFlags(_tileMap.WorldToCell(tileAdress), TileFlags.None);
            _tileMap.SetColor(_tileMap.WorldToCell(tileAdress), _invisible);
            //_tileMap.RefreshTile(_tileMap.WorldToCell(tileAdress));
            
        }
        //_tileMap.RefreshAllTiles();
    }

    private void GetTileAdresses()
    {
        foreach (var position in _tileMap.cellBounds.allPositionsWithin)
        {
            //Vector3Int localPlace = (new Vector3Int(position.x, position.y, (int)_tileMap.transform.position.z));
            Vector3 place = _tileMap.CellToWorld(position);
            if (_tileMap.HasTile(position))
            {
                //Tile at "place"
                _tilesAdresses.Add(place);
            }
            else
            {
                //No tile at "place"
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestTile();
        ManageTiles();
        
    }

    private void ManageTiles()
    {
        //Debug.Log( _tileMap.GetColor(_tileMap.WorldToCell(_currentTileAdress)));
        _tileMap.SetColor(_tileMap.WorldToCell(_currentTileAdress), _visible);
        if (_currentTileAdress != _previousTileAdress)
        {
            _tileMap.SetColor(_tileMap.WorldToCell(_previousTileAdress), _invisible);
        }
        _tileMap.RefreshTile(_tileMap.WorldToCell(_previousTileAdress));
        _tileMap.RefreshTile(_tileMap.WorldToCell(_currentTileAdress));

    }

    private void FindClosestTile()
    {
        Vector3 closestTilePosition = default(Vector3);
        float minDist = Mathf.Infinity;
        Vector3 currentPos = _player.transform.position;
        foreach (var position in _tilesAdresses)
        {
            
            float dist = Vector3.Distance(position, currentPos);
            if (dist < minDist)
            {
                closestTilePosition = position;
                minDist = dist;
            }
        }

        _previousTileAdress = _currentTileAdress;
        _currentTileAdress = closestTilePosition;
    }
}
