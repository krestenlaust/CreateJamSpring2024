using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInvestigateButtons : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;

    [SerializeField, ReadOnly] List<CrossReferencePersonButton> buttons = new();

    Engine Engine => Engine.instance;

    private void Start()
    {
        CreateButtons();
    }

    private void CreateButtons()
    {
        DestroyChildren();
        foreach (Person person in Engine.People)
        {
            GameObject button = Instantiate(buttonPrefab, transform);

            CrossReferencePersonButton crossReferenceButton = button.GetComponent<CrossReferencePersonButton>();
            crossReferenceButton.InstatiatedInit(person);
            buttons.Add(crossReferenceButton);
        }
    }

    private void DestroyChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
