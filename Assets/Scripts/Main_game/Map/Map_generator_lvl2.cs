using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map_generator_lvl2 : MonoBehaviour
{
    Tilemap tilemap;
    public Tilemap backgroundMap;
    public GameObject spawner;



    public TileBase tile;
    public TileBase backgroundTile;
    public TileBase deathTile;
    public TileBase lightTile;
    public TileBase endTile;

    public int width = 100;
    private int height;

    public float holeChance = 30;
    public int holeWidth= 4;

    public int minSectionWidth;
    public int maxSectionWidth;

    public int minElevation = 2;
    public int maxElevation = 8;

    public int spawnChance = 10;


    void Start()
    {
        height = width / minSectionWidth * 16+2;  //== max possible elevation + max possible demotion
        tilemap = GetComponent<Tilemap>();
        var map = GenerateArray(width, height, true);


        map = CreateMap(map);


        RenderMap(map, tilemap);

        //UpdateMap(map, tilemap);



       tilemap.CompressBounds();
        tilemap.transform.position = new Vector3(0, -(map.GetUpperBound(1)/2), 0);


        RenderBeckground(map);
        backgroundMap.CompressBounds();
        backgroundMap.transform.position = new Vector3(0, -(map.GetUpperBound(1) / 2), 0);

    }

    private void RenderBeckground(int[,] map)
    {
        backgroundMap.ClearAllTiles();


        int maxY = (map.GetUpperBound(1) / 2);
        int minY = maxY;

        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {

                if (map[x, y] == 1)
                {
                    if (y > maxY) maxY = y;
                    if (y < minY) minY = y;

                }



            }
        }

        for (int x = -15; x < map.GetUpperBound(0) + 15; x++)
        {
            for (int y = minY - 15; y <= maxY + 15; y++)
            {
                backgroundMap.SetTile(new Vector3Int(x, y, 0), backgroundTile);

                if (x % 10 == 0 && y % 10 == 0)
                {
                    backgroundMap.SetTile(new Vector3Int(x, y, 0), lightTile);

                }
            }
        }

        for (int x = -15; x < map.GetUpperBound(0) + 15; x++)
        {
            tilemap.SetTile(new Vector3Int(x, minY - 15, 0), deathTile);
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

    public void RenderMap(int[,] map, Tilemap tilemap)
    {
        //Clear the map (ensures we dont overlap)
        tilemap.ClearAllTiles();

        int deathY = 0;

        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                // 1 = tile, 0 = no tile
                if (map[x, y] == 1)
                {
                    if (y < deathY) { deathY = y; }
                    
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);


                }
            }
        }

        int i = map.GetUpperBound(0) - 1;
        int j = map.GetUpperBound(1) - 1;
        while (map[i, j] != 1)
        {
            i--;
            j = map.GetUpperBound(1) - 1;

            while (map[i, j] != 1 && j > 0)
            {
                j--;
                // Debug.Log(i + " " + j);
            }

        }
        tilemap.SetTile(new Vector3Int(i - 1, j + 2, 0), endTile);

    }


    public static void UpdateMap(int[,] map, Tilemap tilemap) //In game update if needed
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {

                // Things we want to do with map in game

                if (map[x, y] == 0)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
    }


    public int[,] CreateMap(int[,] map)
    {
        //Seed random

        int x, y;


        y = (map.GetUpperBound(1) / 2);
                                            //Start from here to not get out of boudns
        int minY = y;

        int nextDirection;
        int nextWidht;

        bool hasHole = false;

        for (x = 0; x < 8; x++)
        {
            map[x, y] = 1;
        }

        while (x < map.GetUpperBound(0) - maxSectionWidth-1)
        {
            //Determine the next direction: 1up,0 even,-1down

            nextDirection = UnityEngine.Random.Range(-1, 2);

            hasHole = UnityEngine.Random.Range(0, 101) < holeChance;
            

            if (nextDirection == 1)
            {
                y = y + UnityEngine.Random.Range (minElevation, maxElevation);
                nextWidht = UnityEngine.Random.Range(minSectionWidth, maxSectionWidth);

                if (hasHole)
                {
                    x += holeWidth;
                }

                GenerateSection(map, x, y, nextWidht);
                x += nextWidht;
                
            }else if(nextDirection == 0)
            {
                x += holeWidth;
                nextWidht = UnityEngine.Random.Range(minSectionWidth, maxSectionWidth);
                GenerateSection(map, x, y, nextWidht);


            }
            else if (nextDirection == -1)
            {
                y = y - UnityEngine.Random.Range(minElevation, maxElevation);
                nextWidht = UnityEngine.Random.Range(minSectionWidth, maxSectionWidth);

                if (hasHole)
                {
                    x += holeWidth;
                }

                GenerateSection(map, x, y, nextWidht);

                x += nextWidht;

            }
            

            if (y < minY) { minY = y; }

            

        }

        minY -= 6;

        for (int i = 0; i < map.GetUpperBound(0); i++)
        {
            for (int j = map.GetUpperBound(1); j >minY; j--)
            {
                if (map[i, j] == 1)
                {
                    map[i, j - 1] = 1;
                }
            }
        }

        


        return map;
    }

    private  void GenerateSection(int[,] map, int x, int y, int nextWidht)
    {
        for (int i = x; i < x + nextWidht; i++)
        {

            map[i, y] = 1;
            int chance = UnityEngine.Random.Range(0, 101);
            if (chance <= spawnChance && x >= 8)
            {
                GameObject.Instantiate(spawner, new Vector3(i, y + 4 - (map.GetUpperBound(1) / 2), 0), new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
