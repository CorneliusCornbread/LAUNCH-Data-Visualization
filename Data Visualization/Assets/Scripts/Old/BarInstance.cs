using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BarInstance : MonoBehaviour
{
    [FormerlySerializedAs("MeshRenderer")]
    public MeshRenderer meshRenderer;
    public TMP_Text text;
    public GameObject bar;
    public Canvas canvas;
}
