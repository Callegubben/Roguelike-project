using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    protected static bool ShowOffsetSettings = true;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Inventory inventory = (Inventory)target;

        ShowOffsetSettings = EditorGUILayout.Foldout(ShowOffsetSettings, "Debug menu");

        if (ShowOffsetSettings)
        {

            if (GUILayout.Button("Clear inventory"))
            {
                inventory.ClearInventory();
            }
        }
    }
}
