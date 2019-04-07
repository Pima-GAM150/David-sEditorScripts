using UnityEngine;
using UnityEditor;

public class EditorScript : EditorWindow
{
    public Vector3 scale;

    public int index = 0;
    bool xBoolChecked = false;
    bool yBoolChecked = false;
    bool zBoolChecked = false;
    bool inverseRotate = false;
    int invertRotation = 1;
    bool reset;
    public int Rotate;

    public string[] options = new string[] { "15 Degrees", "30 Degrees", "45 Degrees", "60 Degrees", "75 Degrees", "90 Degrees" };
    float[] optionValues = new float[] { 15f, 30f, 45f, 60f, 75f, 90f };
    public string[] scaleSetoptions = new string[] { "0.25", "0.5", "0.75", "1.5", "2", "5" };
    float[] scaleSetOptionValues = new float[] { 0.25f, 0.5f, 0.75f, 1.5f, 2f, 5f, };
    public string[] scaleMultiplyoptions = new string[] { "0.25", "0.5", "0.75", "1.5", "2", "5" };
    float[] scaleMultiplyOptionValues = new float[] { 0.25f, 0.5f, 0.75f, 1.5f, 2f, 5f, };

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
        reset = GUILayout.Button("Reset Rotation");
        if (reset)
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.GetComponent<Transform>().rotation *= Quaternion.identity;
            }
        }

        GUILayout.Label("Scale the Selected Object", EditorStyles.boldLabel);
        scale = EditorGUILayout.Vector3Field("Scale", scale);
        EditorGUILayout.Popup(index, scaleSetoptions);
        EditorGUILayout.Popup(index, scaleMultiplyoptions);
        EditorGUILayout.DropdownButton(new GUIContent("Setting Scale"), FocusType.Passive);

        if (GUILayout.Button("Reset Scale"))
        {
            scale = new Vector3(1f, 1f, 1f);
            Scale();
        }
        /*if (GUILayout.Button("Scale by 0.25"))
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
        }*/
        if (GUILayout.Button("Set Scale to 0.25"))
        {
            scale = new Vector3(0.25f, 0.25f, 0.25f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 0.5"))
        {
            scale = new Vector3(0.5f, 0.5f, 0.5f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 0.75"))
        {
            scale = new Vector3(0.75f, 0.75f, 0.75f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 1.5"))
        {
            scale = new Vector3(1.5f, 1.5f, 1.5f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 2"))
        {
            scale = new Vector3(2f, 2f, 2f);
            Scale();
        }
        if (GUILayout.Button("Set Scale to 5"))
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
    void RotationFunction()
    {
        Vector3 rotationToApply = new Vector3();
        if (xBoolChecked) rotationToApply.x = optionValues[index];
        if (yBoolChecked) rotationToApply.y = optionValues[index];
        if (zBoolChecked) rotationToApply.z = optionValues[index];

        foreach (GameObject obj in Selection.gameObjects)
        {
            obj.GetComponent<Transform>().rotation = Quaternion.Euler(invertRotation * rotationToApply.x, invertRotation * rotationToApply.y, invertRotation * rotationToApply.z);
        }

    }

    }
