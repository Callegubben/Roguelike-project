using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EffectManager))]
public class EffectManagerEditor : Editor
{
    int damageAmount;
    protected static bool ShowOffsetSettings = true;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EffectManager effectManager = (EffectManager)target;

        ShowOffsetSettings = EditorGUILayout.Foldout(ShowOffsetSettings, "Debug menu");

        if (ShowOffsetSettings)
        {
            GUILayout.BeginHorizontal();
            damageAmount = EditorGUILayout.IntSlider("Damage", damageAmount, 0, 100);
            if (GUILayout.Button("Do damage"))
            {
                effectManager.DoDamage(damageAmount);
            }
            GUILayout.EndHorizontal();
        }
    }
}
