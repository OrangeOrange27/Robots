using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private RobotController _robot;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener((() => _robot.Execute()));
    }
}
