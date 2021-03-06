﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map_generator : MonoBehaviour
{
    Tilemap tilemap;
    public Tilemap backgroundMap;
    public GameObject spawner;


    public TileBase endTile;
    public TileBase tile;
    public TileBase backgroundTile;
    public TileBase deathTile;
    public TileBase lightTile;

    public int width = 100;
    private int height;

    public int spawnChance = 10;

    public int minSectionWidth;
    public int maxSectionWidth;


    void Start()
    {
        height = width / minSectionWidth * 6 + width / minSectionWidth * 8 + 2;  //== max possible elevation + max possible demotion
        tilemap = GetComponent<Tilemap>();
        var map = GenerateArray(width, height, true);

        
        map = CreateMap(map, minSectionWidth, maxSectionWidth);
       

        RenderMap(map, tilemap);

        //UpdateMap(map, tilemap);



        tilemap.CompressBounds();
        tilemap.transform.position = new Vector3(0, -(map.GetUpperBound(0) / minSectionWidth * 8 + 2), 0);

        
         RenderBeckground(map);
        backgroundMap.CompressBounds();
        backgroundMap.transform.position = new Vector3(0, -(map.GetUpperBound(0) / minSectionWidth * 8 + 2), 0);

    }

    private void RenderBeckground(int[,] map)
    {
        backgroundMap.ClearAllTiles();

        
        int maxY = map.GetUpperBound(0) / minSectionWidth * 8 + 2;
        int minY = maxY;

        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
               
                if (map[x,y] == 1)
                {
                    if (y > maxY) maxY = y;
                    if (y < minY) minY = y;

                }
                    
                

            }
        }

        for (int x = -15; x< map.GetUpperBound(0)+15; x++)
        {
            for (int y = minY-15; y <= maxY+15; y++)
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


        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                // 1 = tile, 0 = no tile
                if (map[x, y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                   
                    
                }

                //Debug.Log(x + " " + y);
            }
        }

        int i = map.GetUpperBound(0) - 1;
        int j = map.GetUpperBound(1) - 1;
        while (map[i,j] != 1)
        {
            i--;
            j = map.GetUpperBound(1) - 1;
            
            while (map[i,j] != 1 && j>0)
            {
                j--;
               // Debug.Log(i + " " + j);
            }
            
        }
        tilemap.SetTile(new Vector3Int(i-1, j+2, 0), endTile); 
        /*tilemap.SetTile(new Vector3Int(i-1, j+1, 0), endTile);
        tilemap.SetTile(new Vector3Int(i, j+2, 0), endTile);
        tilemap.SetTile(new Vector3Int(i-1, j+2, 0), endTile);*/


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


    public  int[,] CreateMap(int[,] map, int minSectionWidth, int maxSectionWidth)
    {
        //Seed random

        int x,y;
        
        
        y = map.GetUpperBound(0) / minSectionWidth * 8+2; //Start from here to not get out of boudns
        int minY = y;

        int thickness=3;

        map = GenerateSection(map,0,y,7,thickness);


       
        int nextWidth;
        int nextHeight;

        
        int currentSectionWidth;

        x = 8;

       
        while (  x <= map.GetUpperBound(0)-maxSectionWidth)
        {
            //Determine the next move -- 0 down -- 1 up
            nextHeight = UnityEngine.Random.Range(-8,6);



            //Only change the height if we have used the current height more than the minimum required section width
            if (nextHeight+y <= y+3 && nextHeight+y>=y-thickness)
            {
                nextWidth = UnityEngine.Random.Range(2, 5);
                
                
                currentSectionWidth = UnityEngine.Random.Range(minSectionWidth, maxSectionWidth);
                y = y + nextHeight;
                x = x + nextWidth;

                if (map[x, y] != 1)
                {
                    map = GenerateSection(map, x, y, currentSectionWidth, thickness);

                    x = x + currentSectionWidth - 1;
                }
                

            }
            else if (nextHeight+y >y+3)
            {
                nextWidth = UnityEngine.Random.Range(-4, 4);
                
                currentSectionWidth = UnityEngine.Random.Range(minSectionWidth, maxSectionWidth);
                y = y + nextHeight;
                x = x + nextWidth;
                if (map[x, y] != 1)
                {
                    map = GenerateSection(map, x, y, currentSectionWidth, thickness);

                    x = x + currentSectionWidth - 1;
                }
            }
            else
            {
                nextWidth = UnityEngine.Random.Range(-4,6);
               
                currentSectionWidth = UnityEngine.Random.Range(minSectionWidth, maxSectionWidth);
                y = y + nextHeight;
                x = x + nextWidth;
                if (map[x, y] != 1)
                {
                    map = GenerateSection(map, x, y, currentSectionWidth, thickness);

                    x = x + currentSectionWidth - 1;
                }
            }

            if (y < minY) { minY = y; } 
           
        }

       

        
        return map;
    }



    public  int[,] GenerateSection(int[,] map,int x, int y, int sectionWidth, int thickness)
    {
        for (int i = x; i < x+sectionWidth; i++)
        {
            int chance = UnityEngine.Random.Range(0, 101);
            if (chance <= spawnChance && x>=8)
            {
                GameObject.Instantiate(spawner, new Vector3(i, y + 8-(map.GetUpperBound(0) / minSectionWidth * 8 + 2), 0), new Quaternion(0, 0, 0, 0));
            }
           
            for (int j = 0; j < thickness; j++)
            {
                map[i, y - j] = 1;
            }
        }

        return map;
    }
}
