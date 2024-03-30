using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInvestigateButtons : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;

    [SerializeField, ReadOnly] List<InvestigatePersonButton> buttons = new();

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

            InvestigatePersonButton investigationButton = button.GetComponent<InvestigatePersonButton>();
            investigationButton.InstatiatedInit(person);
            buttons.Add(investigationButton);
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
