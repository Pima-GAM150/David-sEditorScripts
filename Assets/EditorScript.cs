using UnityEngine;
using UnityEditor;

public class EditorScript : EditorWindow
{
    public int index = 0;
    bool xBoolChecked = false;
    bool yBoolChecked = false;
    bool zBoolChecked = false;
    bool inverseRotate = false;
    int invertRotation = 1;
    bool rotationReset;
    public int Rotate;

    public string[] options = new string[] { "15 Degrees", "30 Degrees", "45 Degrees", "60 Degrees", "75 Degrees", "90 Degrees" };
    float[] optionValues = new float[] { 15f, 30f, 45f, 60f, 75f, 90f };

    public Vector3 scale;
    public int setIndex = 0;
    public int multIndex = 0;
    bool scaleReset;

    public string[] scaleSetOptions = new string[] { "0.25", "0.5", "0.75", "1.5", "2", "5" };
    float[] scaleSetOptionValues = new float[] { 0.25f, 0.5f, 0.75f, 1.5f, 2f, 5f };
    public string[] scaleMultiplyOptions = new string[] { "0.2", "0.5", "0.6667", "1.5", "2", "5" };
    float[] scaleMultiplyOptionValues = new float[] { 1 / 5f, 1 / 2f, 1 / 1.5f, 1.5f, 2f, 5f };

    [MenuItem("Window/Object Manipulator")]
    public static void ShowWindow()
    {
        GetWindow<EditorScript>("Object Manipulator");
    }

    private void OnGUI()
    {
        xBoolChecked = EditorGUILayout.Toggle("Rotate X", xBoolChecked);
        yBoolChecked = EditorGUILayout.Toggle("Rotate Y", yBoolChecked);
        zBoolChecked = EditorGUILayout.Toggle("Rotate Z", zBoolChecked);
        inverseRotate = EditorGUILayout.Toggle("Inverse Rotation", inverseRotate);
        if (inverseRotate)
        {
            invertRotation = -1;
        }
        else
        {
            invertRotation = 1;
        }
        index = EditorGUILayout.Popup(index, options);
        if (GUILayout.Button("Rotate"))
        {
            RotationFunction();
        }
        rotationReset = GUILayout.Button("Reset Rotation");
        if (rotationReset)
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.GetComponent<Transform>().rotation = Quaternion.identity;
            }
        }

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
                obj.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }


    }

    void RotationFunction()
    {
        Vector3 rotationToApply = new Vector3();
        if (xBoolChecked) rotationToApply.x = optionValues[index];
        if (yBoolChecked) rotationToApply.y = optionValues[index];
        if (zBoolChecked) rotationToApply.z = optionValues[index];

        foreach (GameObject obj in Selection.gameObjects)
        {
            obj.GetComponent<Transform>().rotation *= Quaternion.Euler(invertRotation * rotationToApply.x, invertRotation * rotationToApply.y, invertRotation * rotationToApply.z);
        }

    }

    void SetScalingFunction()
    {
        Vector3 scaleToSet = new Vector3(scaleSetOptionValues[setIndex], scaleSetOptionValues[setIndex], scaleSetOptionValues[setIndex]);
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