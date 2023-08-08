using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ChangeColorCommand :CommandBase
{
    [SerializeField] private Color _color;
    
    public override async UniTask Execute(Transform target)
    {
        StartCoroutine(ChangeColor(target));
        await UniTask.WaitUntil((() => _commandCompleted));
    }
    
    private IEnumerator ChangeColor(Transform target)
    {
        var renderer = target.GetComponent<Renderer>();
        var startColor = renderer.material.color;

        float t = 0;

        while (t < _duration)
        {
            t += Time.deltaTime;
            
            renderer.material.color = Color.Lerp(startColor, _color, t/_duration);
            yield return null;
        }

        _commandCompleted = true;
    }
}
