using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarGraph : MonoBehaviour
{
    [SerializeField]
    private BarValue[] bars;

    [SerializeField]
    private BarInstance barPrefab;

    [SerializeField]
    private LineRenderer line;
    
    private BarInstance[] _instances;
    
    private void Start()
    {
        Vector3 newPos = Vector3.zero;

        _instances = new BarInstance[bars.Length];
        int index = 0;
        
        foreach (var bar in bars)
        {
            BarInstance instance = Instantiate(barPrefab, transform);
            
            instance.transform.localPosition = Vector3.zero;
            _instances[index] = instance;
            
            index++;
            
            newPos = UpdateBar(instance, bar, newPos);
        }
    }

    private void Update()
    {
        Vector3 newPos = Vector3.zero;

        for (var i = 0; i < _instances.Length; i++)
        {
            var bar = _instances[i];
            var barVal = bars[i];
            newPos = UpdateBar(bar, barVal, newPos);
        }
        
        UpdateLine();
    }
    
    private Vector3 UpdateBar(BarInstance instance, BarValue bar, Vector3 newPos)
    {
        instance.meshRenderer.material = new Material(instance.meshRenderer.material);
        instance.meshRenderer.material.color = bar.barColor;
        instance.text.text = bar.name;

        var barPos = instance.bar.transform.localPosition;
        barPos.y = bar.value / 2;

        instance.transform.position = newPos;
        instance.bar.transform.localPosition = barPos;
        instance.bar.transform.localScale = new Vector3(1, bar.value, 1);
        newPos.x += 3;
        return newPos;
    }

    private void UpdateLine()
    {
        line.positionCount = _instances.Length;
        
        for (int i = 0; i < _instances.Length; i++)
        {
            BarInstance bar = _instances[i];
            BarValue value = bars[i];
            Vector3 pos = bar.transform.localPosition;
            pos.y += value.value;

            line.SetPosition(i, pos);
        }
    }
}
