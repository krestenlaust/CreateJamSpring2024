using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public static Engine instance;

    [SerializeField] List<Person> people;
    public List<Person> People => people;

    public Person InvestigatedPerson => investigatedPersonMenu.InvestigatedPerson;

    [SerializeField] CrossReferenceMenu crossReferenceMenu;
    public Person CrossReferencePerson => crossReferenceMenu.Person;

    [SerializeField] InvestigatedPersonMenu investigatedPersonMenu;

    private void Awake()
    {
        if (MakeSingleton())
        {

        }
    }

    private bool MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return false;
        }

        instance = this;
        return true;
    }

    public void OpenInvestigateConversation(Person person) =>
        investigatedPersonMenu.OpenMenu(person);

    public void OpenCrossReferenceConversation(Person person) => 
        crossReferenceMenu.OpenMenu(person);
}
