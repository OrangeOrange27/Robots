using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class CommandBase : MonoBehaviour, ICommand
{
    [SerializeField] protected float _duration;
    
    protected bool _commandCompleted;
    public virtual UniTask Execute(Transform target)
    { 
        Debug.LogError(new System.NotImplementedException());
        return UniTask.CompletedTask;
    }
}
