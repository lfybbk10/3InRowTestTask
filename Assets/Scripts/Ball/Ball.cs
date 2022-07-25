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

    public IEnumerator ToZeroScale(float timeInSec)
    {
        float segmentTime = 0.016f;
        float segmentScale = (transform.localScale.x/timeInSec) / (1 / segmentTime);
        while (transform.localScale.x>0)
        {
            transform.localScale = new Vector3(transform.localScale.x-segmentScale,transform.localScale.y-segmentScale,transform.localScale.z);
            yield return new WaitForSeconds(segmentTime);
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
            case BallType.Cyan:
                return Color.cyan;
            case BallType.Pink:
                return Color.magenta;
            default:
                return Color.white;
        }
    }
}
