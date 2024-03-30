using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InvestigatePersonButton : MonoBehaviour
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

        button.onClick.AddListener(
            () => Engine.OpenInvestigateConversation(person)
            );
    }
}
