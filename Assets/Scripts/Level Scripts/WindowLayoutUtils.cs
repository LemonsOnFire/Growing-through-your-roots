using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLayoutUtils 
{
    public enum WindowLayout { GRID1, GRID2, ABSTRACT };
    public enum GridValue { WINDOW_W, WINDOW_H, WINDOW_COLS, WINDOW_ROWS, DOOR_X_IND, DOOR_W, DOOR_H, DOOR_X, DOOR_Y/*, TILES_X, TILES_Y*/ };

    private static int[] grid1Vals = new int[] { 6, 4, 5, 10, -1, 4, 6, 17, 0, 40, 32 };
    private static int[] grid2Vals = new int[] { 6, 4, 7, 25, -1, 4, 6, 24, 0, 52, 44 };
    /*
    grid1
    WINDOW_W:6
    WINDOW_H:4
    WINDOW_COLS:5
    WINDOW_ROWS:10
    DOOR_X_IND:-1
    DOOR_W:4
    DOOR_H:6
    DOOR_X:17
    DOOR_Y:0
    TILES_X:40
    TILES_Y:32

    grid2
    WINDOW_W:6
    WINDOW_H:4
    WINDOW_COLS:7
    WINDOW_ROWS:25
    DOOR_X_IND:-1
    DOOR_W:4
    DOOR_H:6
    DOOR_X:24
    DOOR_Y:0
    TILES_X:52
    TILES_Y:44
    */

    public static Vector2Int GetTileDimensions(WindowLayout layout) {

        switch(layout) {
            case WindowLayout.GRID2:
                return GetTileDimensions(grid2Vals);
                // return new Vector2Int(grid2Vals[(int)GridValue.TILES_X], grid2Vals[(int)GridValue.TILES_Y]);
        }

        return GetTileDimensions(grid1Vals);
        // return new Vector2Int(grid1Vals[(int)GridValue.TILES_X], grid1Vals[(int)GridValue.TILES_Y]);
    }

    public static Vector2Int GetTileDimensions(int[] gridVals) {

        int width = (gridVals[(int)GridValue.WINDOW_COLS] * (gridVals[(int)GridValue.WINDOW_W] + 1)) + 3;
        int height = (gridVals[(int)GridValue.WINDOW_ROWS] * (gridVals[(int)GridValue.WINDOW_H] + 2)) + 2;

        Debug.Log("width: " + width + ", height: " + height);

        return new Vector2Int(width, height);
    }

    public static RectInt GetDoorDimensions(WindowLayout layout) {

        switch (layout) {
            case WindowLayout.GRID2:
                return new RectInt(grid2Vals[(int)GridValue.DOOR_X], grid2Vals[(int)GridValue.DOOR_Y], grid2Vals[(int)GridValue.DOOR_W], grid2Vals[(int)GridValue.DOOR_H]);
        }

        return new RectInt(grid1Vals[(int)GridValue.DOOR_X], grid1Vals[(int)GridValue.DOOR_Y], grid1Vals[(int)GridValue.DOOR_W], grid1Vals[(int)GridValue.DOOR_H]);
    }

    public static RectInt[] GetWindowLayout(WindowLayout layout) {

        switch (layout) {
            case WindowLayout.GRID2:
                return GetGridWindowLayout(grid2Vals);
            case WindowLayout.ABSTRACT:
                return new RectInt[] { };
        }

        return GetGridWindowLayout(grid1Vals);
    }

    private static RectInt[] GetGridWindowLayout(int[] gridVals) {

        if(gridVals[(int)GridValue.DOOR_X_IND] > -1) {
            return GetGridWindowLayout(gridVals[(int)GridValue.WINDOW_W], gridVals[(int)GridValue.WINDOW_H], gridVals[(int)GridValue.WINDOW_COLS], 
                gridVals[(int)GridValue.WINDOW_ROWS], gridVals[(int)GridValue.DOOR_X_IND]);
        }

        return GetGridWindowLayout(gridVals[(int)GridValue.WINDOW_W], gridVals[(int)GridValue.WINDOW_H], gridVals[(int)GridValue.WINDOW_COLS], gridVals[(int)GridValue.WINDOW_ROWS]);
    }

    private static RectInt[] GetGridWindowLayout(int windowWidth, int windowHeight, int windowCols, int windowRows) {
        return GetGridWindowLayout(windowWidth, windowHeight, windowCols, windowRows, windowCols / 2);
    }

    private static RectInt[] GetGridWindowLayout(int windowWidth, int windowHeight, int windowCols, int windowRows, int doorXInd) {
        
        int xInc = (windowWidth + 1);
        int yInc = (windowHeight + 2);
        int x0 = 2;
        int y0 = 2;

        RectInt[] windows = new RectInt[(windowCols * windowRows) - 1];
        int ind = 0;
        int xStart = x0;
        int yStart = y0;

        for (int x = 0; x < windowCols; x++, xStart += xInc) {

            for (int y = 0; y < windowRows; y++, yStart += yInc) {
                if (y != 0 || x != doorXInd) {
                    windows[ind++] = new RectInt(xStart, yStart, windowWidth, windowHeight);
                }
            }
            yStart = y0;
        }

        return windows;
    }

    /*

    public static void PrintGridValues() {

        string grid1 = "grid1\n";
        string grid2 = "grid2\n";

        for(int i = 0; i < grid1Vals.Length; i++) {
            grid1 += (GridValue)i;
            grid1 += ":" + grid1Vals[i] + "\n";
        }
        for (int i = 0; i < grid1Vals.Length; i++) {
            grid2 += (GridValue)i;
            grid2 += ":" + grid2Vals[i] + "\n";
        }

        Debug.Log(grid1);
        Debug.Log(grid2);
    }

    public static Vector2Int GetTileDimensions(WindowLayout layout) {

        switch(layout) {
            case WindowLayout.GRID2:
                return new Vector2Int(52, 44);
        }

        return new Vector2Int(40, 32);
    }

    public static RectInt GetDoorDimensions(WindowLayout layout) {

        switch (layout) {
            case WindowLayout.GRID2:
                return new RectInt(24, 0, 4, 6);
        }

        return new RectInt(17, 0, 4, 6);
    }
    
    private static RectInt GetGridDoorLayout(int doorX, int doorY, int doorWidth, int doorHeight) {
        return new RectInt(doorX, doorY, doorWidth, doorHeight);
    }

    private static RectInt[] GetGrid1WindowLayout() {
        eturn GetGridWindowLayout(6, 4, 5, 10);
    }

    private static RectInt[] GetGrid2WindowLayout() {
        return GetGridWindowLayout(6, 4, 7, 25);
    }

    private static RectInt GetGridDoorLayout(int doorX, int doorY, int doorWidth, int doorHeight) {
        return new RectInt(doorX, doorY, doorWidth, doorHeight);
    }

    public static RectInt[] GetWindowLayout(WindowLayout layout) {

        switch (layout) {
            case WindowLayout.GRID2:
                return GetGrid2WindowLayout();
            case WindowLayout.ABSTRACT:
                return new RectInt[] { };
        }

        return GetGrid1WindowLayout();
    }

    public static Vector2Int GetTileDimensions(WindowLayout layout) {

        switch(layout) {
            case WindowLayout.GRID2:
                new Vector2Int(52, 44);
                // new Vector2Int(52, 63);
                break;
        }

        return new Vector2Int(40, 42);
        // new Vector2Int(52, 63);
    }

    public static RectInt GetDoorDimensions(WindowLayout layout) {

        switch (layout) {
            case WindowLayout.GRID2:
                new RectInt(24, 0, 4, 6);
                break;
        }

        return new RectInt(17, 0, 4, 6);
    }

    private static RectInt GetGridDoorLayout(int doorX, int doorY, int doorWidth, int doorHeight) {
        return new RectInt(doorX, doorY, doorWidth, doorHeight);
    }

    public static RectInt[] GetWindowLayout(WindowLayout layout) {

        switch (layout) {
            case WindowLayout.GRID2:
                return GetGrid2WindowLayout();
            case WindowLayout.ABSTRACT:
                return new RectInt[] { };
        }

        return GetGrid1WindowLayout();
    }

    private static RectInt[] GetGrid1WindowLayout() {

        /*
        int cols = 7;
        int rows = 10;
        int mid = cols / 2;
        int width = 6;
        int height = 4;
        int xInc = (width + 1);
        int yInc = (height + 2);
        int x0 = 2;
        int y0 = 2;

        RectInt[] windows = new RectInt[(cols * rows) - 1];
        int ind = 0;
        int xStart = x0;
        int yStart = y0;

        for (int x = 0; x < 7; x++, xStart += xInc) {

            for (int y = 0; y < 7; y++, yStart += yInc) {
                if(y != 0 || x != mid) {
                    windows[ind++] = new RectInt(xStart, yStart, width, height);
                }
            }
            yStart = y0;
        }

        // return windows;
        return GetGridWindowLayout(6, 4, 5, 10);
    }

    private static RectInt[] GetGrid2WindowLayout() {
    
        int cols = 7;
        int rows = 25;
        int mid = cols / 2;
        int width = 6;
        int height = 4;
        int xInc = (width + 1);
        int yInc = (height + 2);
        int x0 = 2;
        int y0 = 2;

        RectInt[] windows = new RectInt[(cols * rows) - 1];
        int ind = 0;
        int xStart = x0;
        int yStart = y0;

        for (int x = 0; x < 7; x++, xStart += xInc) {

            for (int y = 0; y < 7; y++, yStart += yInc) {
                if (y != 0 || x != mid) {
                    windows[ind++] = new RectInt(xStart, yStart, width, height);
                }
            }
            yStart = y0;
        }

        // return windows;
        return GetGridWindowLayout(6, 4, 7, 25);
    }

    private static RectInt[] GetGridWindowLayout(int windowWidth, int windowHeight, int windowCols, int windowRows, int doorXInd) {

        // int cols = windowCols;
        // int rows = windowRows;
        // int mid = windowCols / 2;
        // int width = windowWidth;
        // int height = windowHeight;
        int xInc = (windowWidth + 1);
        int yInc = (windowHeight + 2);
        int x0 = 2;
        int y0 = 2;

        RectInt[] windows = new RectInt[(windowCols * windowRows) - 1];
        int ind = 0;
        int xStart = x0;
        int yStart = y0;

        for (int x = 0; x < windowCols; x++, xStart += xInc) {

            for (int y = 0; y < windowCols; y++, yStart += yInc) {
                if (y != 0 || x != doorXInd) {
                    windows[ind++] = new RectInt(xStart, yStart, windowWidth, windowHeight);
                }
            }
            yStart = y0;
        }

        return windows;
    }
    */
}
