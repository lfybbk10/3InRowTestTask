using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Button))]
public class Ball : MonoBehaviour
{
    private BallType _ballType;
    private SpriteRenderer _spriteRenderer;
    private Button _buttonComponent;

    public event Action<Ball> Clicked;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _buttonComponent = GetComponent<Button>();
        _buttonComponent.onClick.AddListener(onClick);
        BallType = _ballType;
    }

    public BallType BallType
    {
        get
        {
            return _ballType;
        }
        set
        {
            _ballType = value;
            if(_spriteRenderer!=null)
                _spriteRenderer.color = GetColorByBallType(value);
        }
    }

    private void onClick()
    {
        Clicked?.Invoke(this);
    }
    
    private Color GetColorByBallType(BallType ballType)
    {
        switch (ballType)
        {
            case BallType.Red:
                return Color.red;
            case BallType.Blue:
                return Color.blue;
            case BallType.Green:
                return Color.green;
            case BallType.Yellow:
                return Color.yellow;
            default:
                return Color.white;
        }
    }
}
