using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrossReferencePersonButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI personNameTMP;
    [SerializeField] Image backgroundImage;

    [SerializeField] Button button;

    Engine Engine => Engine.instance;

    Person person;

    public void InstatiatedInit(Person personForButton)
    {
        person = personForButton;

        if (person == Engine.InvestigatedPerson) button.interactable = false;

        personNameTMP.text = person.name;
        personNameTMP.color = person.textColor;
        backgroundImage.color = person.backgroundColor;

        button.onClick.AddListener(
            () => Engine.OpenCrossReferenceConversation(person)
            );
    }
}
