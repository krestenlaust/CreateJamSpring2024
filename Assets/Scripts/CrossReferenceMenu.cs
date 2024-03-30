using System.Collections;
using System.Collections.Generic;
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

        createCrossReferenceButtons.UpdateButtons(person);


    }

    private void InstantiateRecording()
    {
        DestroyContentChildren();
        foreach (Statement statement in person.Recoroding)
        {
            GameObject prefab = statement is AskedStatement ? Engine.AskedStatementPrefab : Engine.AnsweredStatementPrefab;

            GameObject gameObjectStatement = Instantiate(prefab, scrollAreaContent);
            gameObjectStatement.GetComponent<GameObjectStatement>().InstantiatedInit(statement, person);
        }
    }

    private void DestroyContentChildren()
    {
        foreach (Transform child in scrollAreaContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void UpdateButtons() => 
        createCrossReferenceButtons.UpdateButtons(person);
}
