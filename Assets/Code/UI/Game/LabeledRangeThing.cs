using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LabeledRangeThing : MonoBehaviour
{
    public event UnityAction<float> OnValueChanged;
    
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
    [SerializeField, Tooltip("How much over the base range user can go (e.g. instead of up to 100% (1) they can go 150% (1.5))")] 
    private float _maxOver = 0;
    [SerializeField, Tooltip("To how many decimals should the number be rounded")] 
    private int _rounding = 2;
    [SerializeField]
    private string _labelText = "Default Label";
    [SerializeField]
    private bool _usePercentage = true;
    [SerializeField]
    private bool _wholeNumbersOnly = false;
    
    private void SetValue(float newVal)
    {
        float val = _usePercentage ? ((newVal - _minValue) / (_maxValue - _minValue) * 100) : newVal;
        _value.text = $"{Math.Round(val, _rounding)}{(_usePercentage ? "%" : "")}";
        _rangeThing.value = newVal;
        OnValueChanged?.Invoke(newVal);
    }
    
    protected virtual void Awake()
    {
        _label.text = _labelText;
        _rangeThing.minValue = _minValue;
        _rangeThing.maxValue = _maxValue+_maxOver;
        _rangeThing.wholeNumbers = _wholeNumbersOnly;
        SetValue(_defaultValue);
        _rangeThing.onValueChanged.AddListener(OnChange);
    }

    protected virtual void OnChange(float value)
    {
        SetValue(value);
    }
}
