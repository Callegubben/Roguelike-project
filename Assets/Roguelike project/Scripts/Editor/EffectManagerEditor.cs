using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EffectManager))]
public class EffectManagerEditor : Editor
{
    int damageAmount;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.BeginHorizontal();

        EffectManager effectManager = (EffectManager)target;

        damageAmount = EditorGUILayout.IntSlider(damageAmount, 0, 100);


        if (GUILayout.Button("Do damage"))
        {
            effectManager.DoDamage(damageAmount);
        }
        GUILayout.EndHorizontal();
    }

}
