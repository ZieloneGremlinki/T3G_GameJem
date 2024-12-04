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
    [SerializeField]
    private bool _usePercentage = true;
    
    private GameObject _ball;
    
    private void SetValue(float newVal)
    {
        float val = _usePercentage ? ((newVal / _rangeThing.maxValue) * 100) : newVal;
        _value.text = $"{Math.Round(val, 2)}{(_usePercentage ? "%" : "")}";
        _rangeThing.value = newVal;
    }
    
    private void Awake()
    {
        _ball = GameObject.FindWithTag("Player");
        
        RetardationModifiers ballSc = _ball.GetComponent<RetardationModifiers>();
        _label.text = _labelText;
        _rangeThing.minValue = _minValue;
        _rangeThing.maxValue = _maxValue;
        SetValue(_defaultValue);
        _rangeThing.onValueChanged.AddListener(newVal =>
        {
            SetValue(newVal);
            Debug.Log("AUIFGUAASDFGIUAFSDGIUSAFIUBADFGIU");
            ballSc.UpdateGuitardationValues(prop, newVal);
        });
    }
}
