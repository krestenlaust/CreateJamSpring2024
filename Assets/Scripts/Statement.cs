using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Statement", menuName = "ScriptableObjects/Statement", order = 1)]
public class Statement : ScriptableObject
{
    [TextArea(10, 100)] public string statement;
}
