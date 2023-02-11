using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLayoutUtils 
{

    /*
     * 
     * READ ME: Calculated grid layouts currently not tested for odd value dimensions on doors or windows, or even value column counts, may not work properly
     * 
    */

    public enum WindowLayout { GRID1, GRID2, ABSTRACT };
    public enum GridValue { WINDOW_W, WINDOW_H, WINDOW_COLS, WINDOW_ROWS, DOOR_X_IND, DOOR_W, DOOR_H, DOOR_X, DOOR_Y };

    private static int[] grid1Vals = new int[] { 6, 4, 5, 10, -1, 4, 6, 17, 0, 40, 32 };
    private static int[] grid2Vals = new int[] { 6, 4, 7, 25, -1, 4, 6, 24, 0, 52, 44 };

    public static Vector2Int GetTileDimensions(WindowLayout layout) {

        switch(layout) {
            case WindowLayout.GRID2:
                return GetTileDimensions(grid2Vals);
        }

        return GetTileDimensions(grid1Vals);
    }

    public static Vector2Int GetTileDimensions(int[] gridVals) {

        int width = (gridVals[(int)GridValue.WINDOW_COLS] * (gridVals[(int)GridValue.WINDOW_W] + 1)) + 3;
        int height = (gridVals[(int)GridValue.WINDOW_ROWS] * (gridVals[(int)GridValue.WINDOW_H] + 2)) + 2;

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
}
