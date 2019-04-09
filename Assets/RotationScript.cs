using UnityEditor;
using UnityEngine;

public class RotationScript : EditorWindow
{


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
            InstantiatePrimitive();
        }
        reset = GUILayout.Button("Reset Rotation");
        if (reset)
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.GetComponent<Transform>().rotation *= Quaternion.identity;
            }
        }

    }

    void InstantiatePrimitive()
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
}


