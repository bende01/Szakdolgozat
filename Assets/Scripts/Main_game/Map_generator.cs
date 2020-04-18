using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map_generator : MonoBehaviour
{
    Tilemap tilemap;

    public TileBase tile;
    public int width = 100;
    private int height;

    public int minSectionWidth;
    public int maxSectionWidth;


    void Start()
    {
        height = width / minSectionWidth * 6 + width / minSectionWidth * 8 + 2;  //== max possible elevation + max possible demotion
        tilemap = GetComponent<Tilemap>();
        var map = GenerateArray(width, height, true);

        //map = PerlinNoise(map, 0f);
        map = RandomWalkTopSmoothed(map,minSectionWidth,maxSectionWidth);
        //map = RandomWalkTop(map, 123123);

        RenderMap(map, tilemap, tile);

        //UpdateMap(map, tilemap);
        tilemap.CompressBounds();
        tilemap.gameObject.transform.localPosition=new Vector3(0, 0, 0);
        

    }

    // Update is called once per frame
    void Update()
    {

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

    public static void RenderMap(int[,] map, Tilemap tilemap, TileBase tile)
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
            }
        }
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

    public static int[,] RandomWalkTop(int[,] map, float seed)
    {
        //Seed our random
        System.Random rand = new System.Random(seed.GetHashCode());

        //Set our starting height
        int lastHeight = UnityEngine.Random.Range(0, map.GetUpperBound(1));

        //Cycle through our width
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            //Flip a coin
            int nextMove = rand.Next(2);

            //If heads, and we aren't near the bottom, minus some height
            if (nextMove == 0 && lastHeight > 2)
            {
                lastHeight--;
            }
            //If tails, and we aren't near the top, add some height
            else if (nextMove == 1 && lastHeight < map.GetUpperBound(1) - 2)
            {
                lastHeight++;
            }

            //Circle through from the lastheight to the bottom
            for (int y = lastHeight; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }
        //Return the map
        return map;
    }
    public static int[,] RandomWalkTopSmoothed(int[,] map, int minSectionWidth, int maxSectionWidth)
    {
        //Seed random
        


        int x,y;
        
        
        y = map.GetUpperBound(0) / minSectionWidth * 8+2; //Start from here to not get out of boudns

        int thickness=3;

        map = GenerateSection(map,0,y,7,thickness);


       
        int nextWidth;
        int nextHeight;

        
        int currentSectionWidth;

        //Work through the array width
        for ( x = 8; x <= map.GetUpperBound(0)-maxSectionWidth; x++)
        {
            //Determine the next move -- 0 down -- 1 up
            nextHeight = UnityEngine.Random.Range(-8,6);

            //Only change the height if we have used the current height more than the minimum required section width
            if (nextHeight+y <= y+3 && nextHeight+y>=y-thickness+1)
            {
                nextWidth = UnityEngine.Random.Range(1, 5);
                
                currentSectionWidth = UnityEngine.Random.Range(minSectionWidth, maxSectionWidth);
                y = y + nextHeight;
                x = x + nextWidth;
                map = GenerateSection(map, x, y, currentSectionWidth, thickness);

                x = x + currentSectionWidth - 1;
                

            }
            else if (nextHeight+y >y+3)
            {
                nextWidth = UnityEngine.Random.Range(-4, 4);
                
                currentSectionWidth = UnityEngine.Random.Range(minSectionWidth, maxSectionWidth);
                y = y + nextHeight;
                x = x + nextWidth;
                map = GenerateSection(map, x, y, currentSectionWidth, thickness);

                x = x + currentSectionWidth - 1;
            }
            else
            {
                nextWidth = UnityEngine.Random.Range(-4,6);
               
                currentSectionWidth = UnityEngine.Random.Range(minSectionWidth, maxSectionWidth);
                y = y + nextHeight;
                x = x + nextWidth;
                map = GenerateSection(map, x, y, currentSectionWidth, thickness);

                x = x + currentSectionWidth - 1;
            }
            //Increment the section width
           
        }

        //Return the modified map
        return map;
    }



    public static int[,] GenerateSection(int[,] map,int x, int y, int sectionWidth, int thickness)
    {
        for (int i = x; i < x+sectionWidth; i++)
        {
            for (int j = 0; j < thickness; j++)
            {
                map[i, y - j] = 1;
            }
        }

        return map;
    }
}
