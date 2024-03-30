using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvestigatedPersonMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI personNameTMP;
    [SerializeField] Image personNameBackgroundImage;

    [SerializeField, ReadOnly] Person person;
    public Person InvestigatedPerson => person;

    public void OpenMenu(Person personToOpenWith)
    {
        person = personToOpenWith;

        personNameTMP.text = person.name;
        personNameTMP.color = person.textColor;
        personNameBackgroundImage.color = person.backgroundColor;
    }
}
