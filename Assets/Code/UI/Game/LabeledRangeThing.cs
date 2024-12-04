using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LabeledRangeThing : MonoBehaviour
{
    [Header("Ball elements")]
    [SerializeField] 
    private RetardationModifiers.Property prop;
    [SerializeField]
    private GameObject Ball;
    [Header("UI Elements")]
    [SerializeField]
    private Slider _rangeThing;
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private TMP_Text _value;

    [Header("Slider Settings")]
    [SerializeField] 
    private float _minValue = 0;
    [SerializeField] 
    private float _maxValue = 1;
    [SerializeField] 
    private float _defaultValue = 1;
    [SerializeField]
    private string _labelText = "Default Label";

    private void SetValue(float newVal)
    {
        float val = (newVal / _rangeThing.maxValue) * 100;
        _value.text = $"{Math.Round(val, 2)}%";
    }
    
    private void Awake()
    {
       var ballSc = Ball.GetComponent<RetardationModifiers>();
        _label.text = _labelText;
        _rangeThing.minValue = _minValue;
        _rangeThing.maxValue = _maxValue;
        _rangeThing.SetValueWithoutNotify(_defaultValue);
        SetValue(_defaultValue);
        _rangeThing.onValueChanged.AddListener(newVal =>
        {
            SetValue(newVal);
            Debug.Log("AUIFGUAASDFGIUAFSDGIUSAFIUBADFGIU");
            ballSc.UpdateGuitardationValues(prop, newVal);
        });
    }
}
