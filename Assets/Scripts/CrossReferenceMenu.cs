using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrossReferenceMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI personNameTMP;
    [SerializeField] Image personNameBackgroundImage;

    [SerializeField] CreateCrossReferenceButtons createCrossReferenceButtons;
    [SerializeField] Transform scrollAreaContent;

    [SerializeField] List<GameObjectStatement> statements;

    [SerializeField, ReadOnly] Person person;
    public Person Person => person;

    Engine Engine => Engine.instance;

    public void OpenMenu(Person personToOpenWith)
    {
        person = personToOpenWith;

        personNameTMP.text = $"{person.name}'s";
        personNameTMP.color = person.textColor;
        personNameBackgroundImage.color = person.backgroundColor;

        InstantiateRecording();        
    }

    private void InstantiateRecording()
    {
        DestroyContentChildren();
        statements.Clear();
        foreach (Statement statement in person.Recoroding)
        {
            GameObject prefab = statement is AskedStatement ? Engine.AskedStatementPrefab : Engine.AnsweredStatementPrefab;

            GameObject instantiatedStatement = Instantiate(prefab, scrollAreaContent);
            GameObjectStatement gameObjectStatement = instantiatedStatement.GetComponent<GameObjectStatement>();
            gameObjectStatement.InstantiatedInit(statement, crossReference: true);
            statements.Add(gameObjectStatement);
        }
    }

    private void DestroyContentChildren()
    {
        foreach (Transform child in scrollAreaContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void OpenOnFirstAvailable()
    {
        foreach (Person person in Engine.People)
        {
            if (person != Engine.InvestigatedPerson)
            {
                OpenMenu(person);
                return;
            }
        }
    }

    public void UpdateColorMultipliers()
    {
        foreach (GameObjectStatement gameObjectStatement in statements)
        {
            gameObjectStatement.UpdateColorMultiplier(crossReference: true);
        }
    }

    public void InvestigationMenuOpened(bool swap)
    {
        if (!swap && Engine.InvestigatedPerson == person)
        {
            Engine.OpenFirstAvailableCrossReference();
            return;
        }
    }
}
