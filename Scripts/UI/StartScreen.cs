using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : Window
{
    public event Action PlayButtonClick;

    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}