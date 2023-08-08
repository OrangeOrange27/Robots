using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface ICommand
{
    UniTask Execute(Transform target);
}
