using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    private List<Instruction> _instructions;


    public void Execute()
    {
        _instructions = new List<Instruction>();
        
        _instructions.AddRange(
            gameObject.GetComponentsInChildren<Instruction>());
        
        HandleInstructions().Forget();
    }

    private async UniTask HandleInstructions()
    {
        foreach (var instruction in _instructions)
        {
            await instruction.Execute(transform);
        }
    }
}
