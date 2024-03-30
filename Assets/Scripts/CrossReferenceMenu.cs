using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrossReferenceMenu : MonoBehaviour
{
    [SerializeField] CreateCrossReferenceButtons createCrossReferenceButtons;
    [SerializeField] Transform scrollAreaContent;

    [SerializeField, ReadOnly] Person person;
    public Person Person => person;

    Engine Engine => Engine.instance;

    public void OpenMenu(Person personToOpenWith)
    {
        person = personToOpenWith;

        InstantiateRecording();

        UpdateButtons();
    }

    private void InstantiateRecording()
    {
        DestroyContentChildren();
        foreach (Statement statement in person.Recoroding)
        {
            GameObject prefab = statement is AskedStatement ? Engine.AskedStatementPrefab : Engine.AnsweredStatementPrefab;

            GameObject gameObjectStatement = Instantiate(prefab, scrollAreaContent);
            gameObjectStatement.GetComponent<GameObjectStatement>().InstantiatedInit(statement, crossReference: true);
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

    public void UpdateButtons()
    {
        if (Engine.InvestigatedPerson == person)
        {
            Engine.OpenFirstAvailableCrossReference();
            return;
        }

        createCrossReferenceButtons.UpdateButtons(person);
    }
}
