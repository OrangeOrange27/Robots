using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RobotController))]
public class RobotControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        var _target = (RobotController)target;
        
        GUILayout.Space(20);
        GUILayout.Label("Creates a child component of Instruction");
        if (GUILayout.Button("Add Instruction"))
        {
            var instruction = new GameObject("Instruction").AddComponent<Instruction>();
            instruction.transform.SetParent(_target.transform);
        }
    }
}
