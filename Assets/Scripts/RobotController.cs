using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    private List<CommandBase> _commands;

    private bool _executed;

    public void Execute()
    {
        if(_executed)
            return;
        
        _commands = new List<CommandBase>();
        
        _commands.AddRange(
            gameObject.GetComponents<CommandBase>());
        
        HandleCommands().Forget();

        _executed = true;
    }

    private async UniTask HandleCommands()
    {
        foreach (var command in _commands)
        {
            await command.Execute();
        }
    }
}
