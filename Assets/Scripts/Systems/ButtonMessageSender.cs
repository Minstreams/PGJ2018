using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Function/Botton Message Sender")]
public class ButtonMessageSender : Button
{
    [Header("请选择按钮功能")]
    [SerializeField]
    private GameSystem.MenuSystem.ButtonMessage message;

    protected override void OnBottonDown()
    {
        GameSystem.MenuSystem.SendButtonMessage(message);
    }
}
