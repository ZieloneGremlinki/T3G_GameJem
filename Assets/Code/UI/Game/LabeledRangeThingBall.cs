using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LabeledRangeThingBall : LabeledRangeThing
{
    [Header("Ball elements")]
    [SerializeField] 
    private RetardationModifiers.Property prop;

    private RetardationModifiers _ballSc;
    
    private GameObject _ball;
    
    protected override void Awake()
    {
        base.Awake();
        
        _ball = GameObject.FindWithTag("Player");
        _ballSc = _ball.GetComponent<RetardationModifiers>();
    }

    protected override void OnChange(float value)
    {
        base.OnChange(value);
        _ballSc.UpdateGuitardationValues(prop, value);
    }
}
