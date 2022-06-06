using UnityEngine;
using UnityEditor;

public class EditModeFunctions : EditorWindow
{
    [MenuItem("Window/Edit Mode Functions")]
    public static void ShowWindow()
    {
        GetWindow<EditModeFunctions>("Edit Mode Functions");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Run Function"))
        {
            FunctionToRun();
        }
    }

    private void FunctionToRun()
    {
        Tile[] tiles = FindObjectsOfType<Tile>();
        foreach(Tile tile in tiles)
        {
            tile.GetSpriteRendererComponent();
            tile.UpdateTileColor();
        }
    }
}