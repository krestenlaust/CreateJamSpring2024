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

    public void InstantiatedInit(Statement statement, Person person, bool crossReference = false)
    {
        this.statement = statement;
        statementTMP.text = statement.statement.statement;
        statementTMP.color = person.textColor;
        backgroundImage.color = person.backgroundColor;

        if (crossReference) 
        {
            button.onClick.AddListener(() => Engine.CrossReferenceStatementClicked(this));
        }
    }

    
}
