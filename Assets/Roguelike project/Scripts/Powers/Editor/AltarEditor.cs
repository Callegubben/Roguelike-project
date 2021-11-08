using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Altar))]
public class AltarEditor : Editor
{
    protected static bool ShowOffsetSettings = true;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Altar altar = (Altar)target;

        ShowOffsetSettings = EditorGUILayout.Foldout(ShowOffsetSettings, "Debug menu");

        if (ShowOffsetSettings)
        {
            if (GUILayout.Button("Spawn power"))
            {
                altar.SpawnItemFromPool();
            }
        }
    }
}
