using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Convo", menuName = "ScriptableObjects/Convo", order = 1)]
public class Convo : ScriptableObject
{
    public List<ScriptableStatement> inputs;
    public List<ScriptableStatement> outputs;
}
