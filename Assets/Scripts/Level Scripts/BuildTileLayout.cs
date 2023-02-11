using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTileLayout : MonoBehaviour
{

    // private Vector2Int tileDimensions = new Vector2Int(52, 100);
    // private Vector2Int tileDimensions = WindowLayoutUtils.GetTileDimensions(WindowLayoutUtils.WindowLayout.GRID2);
    private bool[,] windowMap;
    private bool[,] doorMap;

    private static readonly WindowLayoutUtils.WindowLayout selectedLayout = WindowLayoutUtils.WindowLayout.GRID2;

    private Vector3 zeroTilePosition = new Vector3(-15f, -5f);

    //private RectInt door = new RectInt(12, 0, 4, 4);
    // private RectInt door = new RectInt(12, 0, 4, 5);
    // private RectInt door = new RectInt(24, 0, 4, 6);

    // private RectInt[] windows = new RectInt[] { new RectInt(2, 2, 4, 3), new RectInt(7, 2, 4, 3), /*new RectInt(12, 2, 4, 2),*/ new RectInt(17, 2, 4, 3), new RectInt(22, 2, 4, 3), new RectInt(2, 6, 4, 3), new RectInt(7, 6, 4, 3), new RectInt(12, 6, 4, 3), new RectInt(17, 6, 4, 3), new RectInt(22, 6, 4, 3)};
    // private RectInt[] windows = new RectInt[] { new RectInt(2, 2, 3, 2), new RectInt(6, 2, 3, 2), new RectInt(11, 2, 3, 2), new RectInt(15, 2, 3, 2) };
    // private RectInt[] windows = new RectInt[] { new RectInt(2, 2, 4, 4), new RectInt(6, 2, 8, 4) };
    // private RectInt[] windows = new RectInt[] { new RectInt(0, 0, 2, 2) };
    /*
    private RectInt[] windows = new RectInt[] { new RectInt(2, 2, 6, 4), new RectInt(9, 2, 6, 4), new RectInt(16, 2, 6, 4), new RectInt(30, 2, 6, 4), new RectInt(37, 2, 6, 4),
        new RectInt(44, 2, 6, 4), new RectInt(2, 8, 6, 4), new RectInt(9, 8, 6, 4), new RectInt(16, 8, 6, 4), new RectInt(23, 8, 6, 4), new RectInt(30, 8, 6, 4), new RectInt(37, 8, 6, 4),
        new RectInt(44, 8, 6, 4),new RectInt(2, 14, 6, 4), new RectInt(9, 14, 6, 4), new RectInt(16, 14, 6, 4), new RectInt(23, 14, 6, 4), new RectInt(30, 14, 6, 4),
        new RectInt(37, 14, 6, 4), new RectInt(44, 14, 6, 4),
    };
    */

    private Vector2Int tileDimensions = WindowLayoutUtils.GetTileDimensions(selectedLayout);
    private RectInt door = WindowLayoutUtils.GetDoorDimensions(selectedLayout);
    private RectInt[] windows = WindowLayoutUtils.GetWindowLayout(selectedLayout);

    // public GameObject building;
    public GameObject wallTile;
    public GameObject windowTile;

    // Start is called before the first frame update
    void Start()
    {

        // building = new GameObject();
        // building.transform.position = zeroTilePosition;
        windowMap = new bool[tileDimensions.x, tileDimensions.y];
        doorMap = new bool[tileDimensions.x, tileDimensions.y];
        foreach (RectInt rect in windows) {

            for(int x = rect.x; x < (rect.x + rect.width); x++) {
                for (int y = rect.y; y < (rect.y + rect.height); y++) {
                    windowMap[x, y] = true;
                }
            }
        }
        for (int x = door.x; x < (door.x + door.width); x++) {
            for (int y = door.y; y < (door.y + door.height); y++) {
                doorMap[x, y] = true;
            }
        }

        Vector3 tilePosition = zeroTilePosition;
        Vector3 xInc = new Vector3(1f, 0f);
        Vector3 yInc = new Vector3(0f, 1f);
        for (int x = 0; x < tileDimensions.x; x++, tilePosition += xInc) {
            for (int y = 0; y < tileDimensions.y; y++, tilePosition += yInc) {

                if(!doorMap[x,y]) {
                    if (windowMap[x, y]) {
                        Instantiate(windowTile, tilePosition, transform.rotation);
                    } else {
                        Instantiate(wallTile, tilePosition, transform.rotation);
                    }
                }
            }

            tilePosition.y = zeroTilePosition.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
