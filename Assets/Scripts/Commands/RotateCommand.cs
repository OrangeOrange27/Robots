using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RotateCommand : CommandBase
{
    [SerializeField] private Vector3 _rotationAngles;

    public override async UniTask Execute(Transform target)
    {
        StartCoroutine(Rotate(target));
        await UniTask.WaitUntil((() => _commandCompleted));
    }

    private IEnumerator Rotate(Transform target)
    {
        var start = Quaternion.Euler(target.localEulerAngles);
        var end = Quaternion.Euler(_rotationAngles);
        
        float t = 0;

        while (t < _duration)
        {
            t += Time.deltaTime;

            target.localRotation = Quaternion.Slerp(start, end, t / _duration);

            yield return null;
        }

        _commandCompleted = true;
    }
}
