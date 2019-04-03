using UnityEngine;
using UnityEditor;

public class EditorScript : EditorWindow
{
    public Vector3 scale;

    [MenuItem("Window/Object Manipulator")]
    public static void ShowWindow()
    {
        GetWindow<EditorScript>("Object Manipulator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Scale the Selected Object", EditorStyles.boldLabel);
        scale = EditorGUILayout.Vector3Field("Scale", scale);
        EditorGUILayout.DropdownButton(new GUIContent("Scale Presets"), FocusType.Passive);
        EditorGUILayout.DropdownButton(new GUIContent("Multiplicative Scale"), FocusType.Passive);
        EditorGUILayout.DropdownButton(new GUIContent("Setting Scale"), FocusType.Passive);

        if (GUILayout.Button("Reset Scale"))
        {
            scale = new Vector3(1f, 1f, 1f);
            Scale();
        }
        if (GUILayout.Button("Scale by 0.25"))
        {
            scale = new Vector3(0.25f, 0.25f, 0.25f);
            Scale();
        }
        if (GUILayout.Button("Scale by 0.5"))
        {
            scale = new Vector3(0.5f, 0.5f, 0.5f);
            Scale();
        }
        if (GUILayout.Button("Scale by 0.75"))
        {
            scale = new Vector3(0.75f, 0.75f, 0.75f);
            Scale();
        }
        if (GUILayout.Button("Scale by 1.5"))
        {
            scale = new Vector3(1.5f, 1.5f, 1.5f);
            Scale();
        }
        if (GUILayout.Button("Scale by 2"))
        {
            scale = new Vector3(2f, 2f, 2f);
            Scale();
        }
        if (GUILayout.Button("Scale by 5"))
        {
            scale = new Vector3(5f, 5f, 5f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 0.25"))
        {
            scale = new Vector3(0.25f, 0.25f, 0.25f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 0.25"))
        {
            scale = new Vector3(0.5f, 0.5f, 0.5f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 0.25"))
        {
            scale = new Vector3(0.75f, 0.75f, 0.75f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 0.25"))
        {
            scale = new Vector3(1.5f, 1.5f, 1.5f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 0.25"))
        {
            scale = new Vector3(2f, 2f, 2f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 0.25"))
        {
            scale = new Vector3(5f, 5f, 5f);
            Scale();
        }
        if (GUILayout.Button("Apply Scale"))
        {
            Scale();
        }
    }

    void Scale()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            obj.GetComponent<Transform>().localScale = scale;
        }
    }
}
