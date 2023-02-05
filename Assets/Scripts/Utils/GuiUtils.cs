using UnityEngine;

public class GuiUtils {

    public static float defaultLabelWidth = 250;
    public static float defaultLabelHeight = 20;

    public static void MakeValueFields(string[] labelArr, string[] valueArr, float baseX, float baseY) {
        MakeValueFields(labelArr, valueArr, baseX, baseY, defaultLabelWidth, defaultLabelHeight);
    }

    public static void MakeValueFields(string[] labelArr, string[] valueArr, float baseX, float baseY, float width, float height) {

        int size = Mathf.Min(labelArr.Length, valueArr.Length);
        for (int i = 0; i < size; i++) {
            GUI.Label(new Rect(baseX, baseY, width, height), labelArr[i] + valueArr[i]);
            baseY += 20;
        }
    }

    public static Texture2D MakeTexture(int width, int height, Color col) {
        Color[] pixels = new Color[width * height];
        for (int i = 0; i < pixels.Length; i++) {
            pixels[i] = col;
        }

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pixels);
        result.Apply();

        return result;
    }
}
