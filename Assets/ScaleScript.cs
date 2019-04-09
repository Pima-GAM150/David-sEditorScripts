using UnityEditor;
using UnityEngine;

public class ScaleScript : EditorWindow
{
    public Vector3 scale;
    public int setIndex = 0;
    public int multIndex = 0;
    bool scaleReset;

    public string[] scaleSetOptions = new string[] { "0.25", "0.5", "0.75", "1.5", "2", "5" };
    float[] scaleSetOptionValues = new float[] { 0.25f, 0.5f, 0.75f, 1.5f, 2f, 5f};
    public string[] scaleMultiplyOptions = new string[] { "0.2", "0.5", "0.6667", "1.5", "2", "5" };
    float[] scaleMultiplyOptionValues = new float[] { 1/5f, 1/2f, 1/1.5f, 1.5f, 2f, 5f};



    private void OnGUI()
    {
        GUILayout.Label("Scale the Selected Object", EditorStyles.boldLabel);
        scale = EditorGUILayout.Vector3Field("Scale", scale);
        GUILayout.Label("Set the Scale of the Selected Object", EditorStyles.boldLabel);
        setIndex = EditorGUILayout.Popup(setIndex, scaleSetOptions);
        GUILayout.Label("Multiply the Scale of the Selected Object", EditorStyles.boldLabel);
        multIndex = EditorGUILayout.Popup(multIndex, scaleMultiplyOptions);

        if (GUILayout.Button("Set Scale"))
        {
            SetScalingFunction();
        }
        if (GUILayout.Button("Multiply Scale"))
        {
            MultScalingFunction();
        }
        scaleReset = GUILayout.Button("Reset Scale");
        if (scaleReset)
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.GetComponent<Transform>().localScale = new Vector3(1f,1f,1f);
            }
        }
    }

    void SetScalingFunction()
    {
        Vector3 scaleToSet = new Vector3( scaleSetOptionValues[setIndex], scaleSetOptionValues[setIndex], scaleSetOptionValues[setIndex]);
        foreach (GameObject obj in Selection.gameObjects)
        {
            obj.GetComponent<Transform>().localScale = scaleToSet;
        }
    }
    void MultScalingFunction()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            obj.GetComponent<Transform>().localScale *= scaleMultiplyOptionValues[multIndex];
        }
    }
}