using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    private Transform _target;
    private List<CommandBase> _commands;
    
    private bool _executed;

    public async UniTask Execute(Transform target)
    {
        if(_executed)
            return;

        _target = target;
        _commands = new List<CommandBase>();
        
        _commands.AddRange(
            gameObject.GetComponents<CommandBase>());
        
        await HandleCommands();

        _executed = true;
    }

    private async UniTask HandleCommands()
    {
        foreach (var command in _commands)
        {
            await command.Execute(_target);
        }
    }
}
