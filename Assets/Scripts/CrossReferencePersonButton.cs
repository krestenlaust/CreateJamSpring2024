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

        personNameTMP.text = person.name;
        personNameTMP.color = person.textColor;
        backgroundImage.color = person.backgroundColor;

        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (person == Engine.InvestigatedPerson)
        {
            Engine.SwapInvestigationAndCrossReference();
        }
        else
        {
            Engine.OpenCrossReferenceConversation(person);
        }
    }
}
