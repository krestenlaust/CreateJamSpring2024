using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameObjectStatement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI statementTMP;
    [SerializeField] Image backgroundImage;

    [SerializeField] Button button;

    [SerializeField] Statement statement;
    public Statement Statement => statement;

    Engine Engine => Engine.instance;

    public void InstantiatedInit(Statement statement, bool crossReference = false)
    {
        this.statement = statement;
        statementTMP.text = statement.statement.statement;
        statementTMP.color = statement.statement.WhoSaidIt.textColor;
        backgroundImage.color = statement.statement.WhoSaidIt.backgroundColor;

        if (crossReference) 
        {
            button.onClick.AddListener(() => Engine.CrossReferenceStatementClicked(this));
        }
    }

    
}
