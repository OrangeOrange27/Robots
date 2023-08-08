using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RobotController))]
public class RobotControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        var _target = (RobotController)target;

        
        if (GUILayout.Button("Add Move Command"))
        {
            var cmd = _target.gameObject.AddComponent<MoveCommand>();
        }
        
        if (GUILayout.Button("Add Change Color Command"))
        {
            var cmd = _target.gameObject.AddComponent<ChangeColorCommand>();
        }
        
        if (GUILayout.Button("Add Rotate Command"))
        {
            var cmd = _target.gameObject.AddComponent<RotateCommand>();
        }
    }
}
