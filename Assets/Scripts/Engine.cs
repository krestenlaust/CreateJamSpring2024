using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public static Engine instance;

    [SerializeField] int startingMinutes;
    [SerializeField] int newInfoCostInMinutes;

    [SerializeField, ReadOnly] int minutesLeft;
    public int HoursLeft => Mathf.FloorToInt(minutesLeft / 60f);
    public int MinutesMinusHoursLeft => minutesLeft % 60;

    [SerializeField] List<Person> people;
    public List<Person> People => people;


    [SerializeField] CrossReferenceMenu crossReferenceMenu;
    public Person CrossReferencePerson => crossReferenceMenu.Person;

    [SerializeField] InvestigatedPersonMenu investigatedPersonMenu;
    public Person InvestigatedPerson => investigatedPersonMenu.InvestigatedPerson;

    [SerializeField] AskConfirmationMenu askConfirmationMenu;

    [SerializeField] GameObject askedStatementPrefab;
    public GameObject AskedStatementPrefab => askedStatementPrefab;
    [SerializeField] GameObject answeredStatementPrefab;
    public GameObject AnsweredStatementPrefab => answeredStatementPrefab;

    [SerializeField] TextMeshProUGUI timerTMP;

    private void Awake()
    {
        if (MakeSingleton())
        {
            ApplyStartConvo();
            minutesLeft = startingMinutes;
            UpdateTimer();
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

    private void ApplyStartConvo()
    {
        foreach (Person person in people)
        {
            person.ApplyStartingConvos();
        }
    }

    public void OpenInvestigateConversation(Person person)
    {
        investigatedPersonMenu.OpenMenu(person);
        crossReferenceMenu.UpdateButtons();
    }

    public void OpenCrossReferenceConversation(Person person) => 
        crossReferenceMenu.OpenMenu(person);

    public void OpenFirstAvailableCrossReference() =>
        crossReferenceMenu.OpenOnFirstAvailable();

    public void CrossReferenceStatementClicked(GameObjectStatement statement) => 
        askConfirmationMenu.OpenMenu(statement);

    public void Ask(ScriptableStatement statement)
    {
        InvestigatedPerson.AskStatement(statement, out bool newInfoGained);
        
        if (newInfoGained)
        {
            minutesLeft -= newInfoCostInMinutes;
        }

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerTMP.text = $"{HoursLeft}:{MinutesMinusHoursLeft}:0";
    }
}
