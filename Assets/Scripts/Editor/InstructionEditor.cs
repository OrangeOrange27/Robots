using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Instruction))]
public class InstructionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        var _target = (Instruction)target;

        GUILayout.Label("Add a component:");
        GUILayout.Space(10);
        if (GUILayout.Button("Add Move Command"))
        {
            var cmd = _target.gameObject.AddComponent<MoveCommand>();
        }
        GUILayout.Space(20);
        if (GUILayout.Button("Add Change Color Command"))
        {
            var cmd = _target.gameObject.AddComponent<ChangeColorCommand>();
        }
        GUILayout.Space(20);
        if (GUILayout.Button("Add Rotate Command"))
        {
            var cmd = _target.gameObject.AddComponent<RotateCommand>();
        }
    }
}
