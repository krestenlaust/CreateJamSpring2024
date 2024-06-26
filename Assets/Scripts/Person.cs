using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Person", menuName = "ScriptableObjects/Person", order = 1)]
public class Person : ScriptableObject
{
    public new string name;
    public Sprite avatar;
    public Sprite background;
    public Color textColor;
    public Color backgroundColor;
    public List<Convo> convos;

    public List<ScriptableStatement> noAnswerStatements = new();

    [SerializeField] Convo startingConvo;

    [SerializeField, ReadOnly] List<Statement> recording = new();
    public List<Statement> Recoroding => recording;

    public void ApplyStartingConvos()
    {
        recording.Clear();
        Record(startingConvo.inputs[0], startingConvo.outputs);
    }

    public List<ScriptableStatement> AskStatement(ScriptableStatement asked, out bool newInfoGained)
    {
        List<ScriptableStatement> answerStatements;
        Convo convo = convos.Find(convo => convo.inputs.Any(statement => statement.statement == asked.statement));

        answerStatements = convo ? convo.outputs : new List<ScriptableStatement>() { GetRandomNoAnswerStatement() };

        newInfoGained = AnyDoesNotExistInRecording(answerStatements);

        Record(asked, answerStatements);

        return answerStatements;
    }

    public ScriptableStatement GetRandomNoAnswerStatement()
    {
        int statementIndex = Random.Range(0, noAnswerStatements.Count - 1);
        return noAnswerStatements[statementIndex];
    }

    public bool AnyExistInRecording(List<ScriptableStatement> statements)
    {
        foreach (ScriptableStatement scriptableStatement in statements)
        {
            if (ExistsInRecording(scriptableStatement))
            {
                return true;
            }
        }
        return false;
    }

    public bool ExistsInRecording(ScriptableStatement scriptableStatement)
    {
        bool exists = recording.Any(statement => statement.statement.statement == scriptableStatement.statement);
        return exists;
    }

    public bool AnyDoesNotExistInRecording(List<ScriptableStatement> statements)
    {
        foreach (ScriptableStatement scriptableStatement in statements)
        {
            if (DoesNotExistInRecording(scriptableStatement))
            {
                return true;
            }
        }
        return false;
    }

    public bool DoesNotExistInRecording(ScriptableStatement scriptableStatement)
    {
        bool exists = recording.Any(statement => statement.statement.statement == scriptableStatement.statement);
        return !exists;
    }

    private void Record(ScriptableStatement asked, List<ScriptableStatement> answered)
    {
        recording.Add(new AskedStatement(asked));

        foreach (ScriptableStatement statement in answered)
        {
            recording.Add(new AnsweredStatement(statement));
        }
    }
}
