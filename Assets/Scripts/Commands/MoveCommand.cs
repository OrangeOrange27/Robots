using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MoveCommand : CommandBase
{
    [SerializeField] private Vector3 _moveToPosition;

    public override async UniTask Execute(Transform target)
    {
        StartCoroutine(Move(target));
        await UniTask.WaitUntil((() => _commandCompleted));
    }

    private IEnumerator Move(Transform target)
    {
        float t = 0;

        while (t < _duration)
        {
            t += Time.deltaTime;
            var currentPos = target.position;

            var time = Vector3.Distance(currentPos, _moveToPosition) / (_duration - t) * Time.deltaTime;

            target.position = Vector3.MoveTowards(currentPos, _moveToPosition, time);

            yield return null;
        }

        _commandCompleted = true;
    }
}
