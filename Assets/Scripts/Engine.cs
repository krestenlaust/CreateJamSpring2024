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

    [SerializeField] Person investigatedPerson;
    public Person InvestigatedPerson => investigatedPerson;

    [SerializeField] GameObject crossReferenceMenu;
    //public Person CrossReferencePerson => crossReferenceMenu.Person;

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

    public void OpenCrossReferenceConversation(Person person)
    {
        //crossReferenceMenu.Open(person);
    }
}
