using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ChangeColorCommand :CommandBase
{
    [SerializeField] private Color _color;
    
    public override async UniTask Execute()
    {
        StartCoroutine(ChangeColor());
        await UniTask.WaitUntil((() => _commandCompleted));
    }
    
    private IEnumerator ChangeColor()
    {
        var renderer = GetComponent<Renderer>();
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
