using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map_boss_level : MonoBehaviour
{
    Tilemap tilemap;
    public Tilemap backgroundMap;



    public TileBase backgroundTile;
    public TileBase lightTile;




    void Start()
    {
        tilemap = GetComponent<Tilemap>();

        RenderBeckground();
        backgroundMap.CompressBounds();

    }

    private void RenderBeckground()
    {
        backgroundMap.ClearAllTiles();


        int maxX = tilemap.size.x;
        int maxY = tilemap.size.y;

       

        for (int x = -15; x < maxX + 15; x++)
        {
            for (int y =  - 15; y <= maxY + 15; y++)
            {
                backgroundMap.SetTile(new Vector3Int(x, y, 0), backgroundTile);

                if (x % 10 == 0 && y % 10 == 0)
                {
                    backgroundMap.SetTile(new Vector3Int(x, y, 0), lightTile);

                }
            }
        }

        

    }



    public static int[,] GenerateArray(int width, int height, bool empty)  //Generates the map
    {
        int[,] map = new int[width, height];
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (empty)
                {
                    map[x, y] = 0;
                }
                else
                {
                    map[x, y] = 1;
                }
            }
        }
        return map;
    }



}
