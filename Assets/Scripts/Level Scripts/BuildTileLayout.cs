using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTileLayout : MonoBehaviour
{
    
    private bool[,] windowMap;
    private bool[,] doorMap;

    private static readonly WindowLayoutUtils.WindowLayout selectedLayout = WindowLayoutUtils.WindowLayout.GRID1;

    private Vector3 zeroTilePosition = new Vector3(-15f, -5f);

    private Vector2Int tileDimensions = WindowLayoutUtils.GetTileDimensions(selectedLayout);
    private RectInt door = WindowLayoutUtils.GetDoorDimensions(selectedLayout);
    private RectInt[] windows = WindowLayoutUtils.GetWindowLayout(selectedLayout);
    
    public GameObject wallTile;
    public GameObject windowTile;

    // Start is called before the first frame update
    void Start()
    {
        
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
