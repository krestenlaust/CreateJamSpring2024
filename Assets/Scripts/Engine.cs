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


    [SerializeField] CrossReferenceMenu crossReferenceMenu;
    public Person CrossReferencePerson => crossReferenceMenu.Person;

    [SerializeField] InvestigatedPersonMenu investigatedPersonMenu;
    public Person InvestigatedPerson => investigatedPersonMenu.InvestigatedPerson;

    [SerializeField] GameObject askedStatementPrefab;
    public GameObject AskedStatementPrefab => askedStatementPrefab;
    [SerializeField] GameObject answeredStatementPrefab;
    public GameObject AnsweredStatementPrefab => answeredStatementPrefab;

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

    public void OpenInvestigateConversation(Person person)
    {
        investigatedPersonMenu.OpenMenu(person);
        crossReferenceMenu.UpdateButtons();
    }

    public void OpenCrossReferenceConversation(Person person) => 
        crossReferenceMenu.OpenMenu(person);
}
