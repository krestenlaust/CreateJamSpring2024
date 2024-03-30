using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Statement", menuName = "ScriptableObjects/Statement", order = 1)]
public class ScriptableStatement : ScriptableObject
{
    [TextArea(10, 100)] public string statement;
}

public abstract class Statement
{
    public ScriptableStatement statement;
}

public class AskedStatement : Statement
{    
    public AskedStatement(ScriptableStatement statement)
    {
        this.statement = statement;
    }
}

public class AnsweredStatement : Statement
{
    public AnsweredStatement(ScriptableStatement statement)
    {
        this.statement = statement;
    }
}
