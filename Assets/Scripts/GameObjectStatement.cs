using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameObjectStatement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI statementTMP;
    [SerializeField] TextMeshProUGUI nameTMP;
    [SerializeField] Image backgroundImage;

    [SerializeField] Color askedColor = Color.gray;

    [SerializeField] Button button;

    [SerializeField] Statement statement;
    public Statement Statement => statement;

    Engine Engine => Engine.instance;

    public void InstantiatedInit(Statement statement, bool crossReference = false)
    {
        this.statement = statement;

        Color colorMultiplier = new(1, 1, 1);
        if (Engine.InvestigatedPerson.ExistsInRecording(statement.statement))
        {
            colorMultiplier = askedColor;
        }

        nameTMP.text = statement.statement.WhoSaidIt.name + ":";
        nameTMP.color = statement.statement.WhoSaidIt.textColor * colorMultiplier;

        statementTMP.text = statement.statement.statement;
        statementTMP.color = statement.statement.WhoSaidIt.textColor * colorMultiplier;
        backgroundImage.color = statement.statement.WhoSaidIt.backgroundColor * colorMultiplier;

        if (crossReference) 
        {
            button.onClick.AddListener(() => Engine.CrossReferenceStatementClicked(this));
        }
        else
        {
            button.enabled = false;
        }
    }

    
}
