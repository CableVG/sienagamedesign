using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClass : MonoBehaviour
{
    // Construction
    // The test map.
    public int[,] testMap = new int[,] {
        {0,0,0,0},
        {0,1,1,1},
        {3,3,3,3},
        {0,2,2,0}
    };

    public int width = 4;//testMap.GetLength(0);
    public int height = 4;//testMap.GetLength(1);

    [SerializeField]
    public GameObject[] floorTiles; // Array of floor prefabs
    // Keep hiearchy clean 
    private Transform boardHolder;



    void MapSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;

        // Unity has origin in middle of screen instead of top left. 
        int drawHeight = height;
        // So normal reading of an array translated onto the screen is flipped
        for (int row = 0; row < height; row++)//(int row = height - 1; row >= 0; row--)
        {
            for (int col = 0; col < width; col++)//(int col = width - 1; col >= 0; col--)
            {
                //Choose a tile from our array of floor tile prefabs and prepare to instantiate it.
                GameObject toInstantiate = floorTiles[testMap[row, col]];
                //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                GameObject instance = Instantiate(toInstantiate, new Vector3(col, drawHeight, 0f), Quaternion.identity) as GameObject;
                //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                instance.transform.SetParent(boardHolder);
            }
            // Setting height of the map based on Unity's grid system (Basicly drawing from the top to bottom)
            drawHeight--;
        }
    }

    private void Start()
    {
        MapSetup();
    }
}