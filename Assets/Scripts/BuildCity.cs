using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour {

    //Building stuff
    public GameObject[] buildings;
    public int mapWidth = 20;
    public int mapHeight = 20;
    public int spaceBetweenBuildings = 3;
    public float seed;

    //Street stuff
    public GameObject xStreet;
    public GameObject zStreet;
    public GameObject crossRoad;
    int[,] mapGrid;


    private void Start()
    {
        mapGrid = new int[mapWidth, mapHeight];

        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                mapGrid[h, w] = (int)(Mathf.PerlinNoise(w / 10f, h / 10f) * 10);
            }
        }

        int x = 0;
        for (int n = 0; n < 50; n++)
        {
            for (int h = 0; h < mapHeight; h++)
            {
                mapGrid[x, h] = -1;
            }
            x += Random.Range(2, 5);
            if (x >= mapWidth) break;
        }

        int z= 0;
        for (int n = 0; n < 50; n++)
        {
            for (int w = 0; w < mapHeight; w++)
            {
                if (mapGrid[w, z] == -1)
                    mapGrid[w, z] = -3;
                else
                    mapGrid[w, z] = -2;
            }
            z += Random.Range(3, 10);
            if (z >= mapHeight) break;
        }

        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                //spaceBetweenBuildings = (int)(Mathf.PerlinNoise(w / 5f, h / 5f) * 10);
                int result = mapGrid[w, h]; //(int)(Mathf.PerlinNoise(w / 5f + seed, h / 5f + seed) * 12);
                //Debug.Log(result);
                Vector3 pos = new Vector3(w * spaceBetweenBuildings, 0, h * spaceBetweenBuildings);
                if (result < -2)
                    Instantiate(crossRoad, pos, crossRoad.transform.rotation);
                else if (result < -1)
                    Instantiate(xStreet, pos, xStreet.transform.rotation);
                else if (result < 0)
                    Instantiate(zStreet, pos, zStreet.transform.rotation);
                else if (result < 2)
                    Instantiate(buildings[5], pos, Quaternion.identity);
                else if (result < 4)
                    Instantiate(buildings[4], pos, Quaternion.identity);
                else if (result < 6)
                    Instantiate(buildings[3], pos, Quaternion.identity);
                else if (result < 8)
                    Instantiate(buildings[2], pos, Quaternion.identity);
                else if (result < 10)
                    Instantiate(buildings[1], pos, Quaternion.identity);
                else if (result < 12)
                    Instantiate(buildings[0], pos, Quaternion.identity);
            }
        }
    }

}
