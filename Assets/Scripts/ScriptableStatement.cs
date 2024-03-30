using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Statement", menuName = "ScriptableObjects/Statement", order = 1)]
public class ScriptableStatement : ScriptableObject
{
    [SerializeField] Person whoSaidIt;
    public Person WhoSaidIt => whoSaidIt;
    [TextArea(10, 100)] public string statement;
}

[System.Serializable]
public abstract class Statement
{
    public ScriptableStatement statement;
}

[System.Serializable]
public class AskedStatement : Statement
{    
    public AskedStatement(ScriptableStatement statement)
    {
        this.statement = statement;
    }
}

[System.Serializable]
public class AnsweredStatement : Statement
{
    public AnsweredStatement(ScriptableStatement statement)
    {
        this.statement = statement;
    }
}
