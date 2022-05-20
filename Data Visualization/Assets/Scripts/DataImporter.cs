using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[Serializable]
public class DataImportedEvent : UnityEvent<List<List<float>>> {}

public class DataImporter : MonoBehaviour
{
    [SerializeField]
    private DataImportedEvent onDataImported;

    private void Start()
    {
        const float min = 1;
        const float max = 3;
        
        List<List<float>> fakeData = new List<List<float>>()
        {
            new List<float>()
            {
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
            },
            new List<float>()
            {
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
            },new List<float>()
            {
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
            },
            new List<float>()
            {
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
                Random.Range(min, max),
            },
        };
        
        onDataImported.Invoke(fakeData);
    }
}
