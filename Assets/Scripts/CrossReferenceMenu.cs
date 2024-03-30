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

    public void OpenMenu(Person personToOpenWith)
    {
        person = personToOpenWith;

        InstantiateRecording();

        createCrossReferenceButtons.UpdateButtons(person);


    }

    private void InstantiateRecording()
    {
        foreach (Statement item in person.Recoroding)
        {

        }
    }
}
