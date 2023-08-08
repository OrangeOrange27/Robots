using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RotateCommand : CommandBase
{
    [SerializeField] private Vector3 _rotationAngles;

    public override async UniTask Execute()
    {
        StartCoroutine(Rotate());
        await UniTask.WaitUntil((() => _commandCompleted));
    }

    private IEnumerator Rotate()
    {
        var start = Quaternion.Euler(transform.localEulerAngles);
        var target = Quaternion.Euler(_rotationAngles);
        
        float t = 0;

        while (t < _duration)
        {
            t += Time.deltaTime;

            transform.localRotation = Quaternion.Slerp(start, target, t / _duration);

            yield return null;
        }

        _commandCompleted = true;
    }
}
