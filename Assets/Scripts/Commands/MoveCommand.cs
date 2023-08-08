using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MoveCommand : CommandBase
{
    [SerializeField] private Vector3 _moveToPosition;

    public override async UniTask Execute()
    {
        StartCoroutine(Move());
        await UniTask.WaitUntil((() => _commandCompleted));
    }

    private IEnumerator Move()
    {
        float t = 0;

        while (t < _duration)
        {
            t += Time.deltaTime;
            var currentPos = transform.position;

            var time = Vector3.Distance(currentPos, _moveToPosition) / (_duration - t) * Time.deltaTime;

            transform.position = Vector3.MoveTowards(currentPos, _moveToPosition, time);

            yield return null;
        }

        _commandCompleted = true;
    }
}
