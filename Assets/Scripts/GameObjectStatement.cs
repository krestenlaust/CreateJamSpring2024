using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectStatement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI statementTMP;
    [SerializeField] Image backgroundImage;

    public void InstantiatedInit(Statement statement, Person person)
    {
        statementTMP.text = statement.statement.statement;
        statementTMP.color = person.textColor;
        backgroundImage.color = person.backgroundColor;

    }
}
