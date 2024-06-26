using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

	[SerializeField] TextMeshProUGUI middleTextTMP;

    [SerializeField] NoMoreTimeMenu noMoreTimeMenu;

	private void Awake()
    {
        if (MakeSingleton())
        {
            ApplyStartConvo();
            minutesLeft = startingMinutes;
            UpdateTimer();

            OpenInvestigateConversation(people[2]);
            OpenCrossReferenceConversation(people[0]);
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

    public void SwapInvestigationAndCrossReference()
    {
        Person oldInvestigatedPerson = InvestigatedPerson;
        OpenInvestigateConversation(CrossReferencePerson, swap: true);
        OpenCrossReferenceConversation(oldInvestigatedPerson);
    }

    public void OpenInvestigateConversation(Person person, bool swap = false)
    {
        investigatedPersonMenu.OpenMenu(person);
        crossReferenceMenu.InvestigationMenuOpened(swap);
    }

	public void OpenCrossReferenceConversation(Person person)
	{
		crossReferenceMenu.OpenMenu(person);
        FixNamesInMiddleBoxyThing();
	}

	private void FixNamesInMiddleBoxyThing()
	{
        if (CrossReferencePerson != null)
        {
			middleTextTMP.text = $"Asking <color=#{ColorUtility.ToHtmlStringRGBA(InvestigatedPerson.backgroundColor)}>{InvestigatedPerson.name}</color> about <color=#{ColorUtility.ToHtmlStringRGBA(CrossReferencePerson.backgroundColor)}>{CrossReferencePerson.name}'s</color> statements.";
		}
	}

	public void OpenFirstAvailableCrossReference() =>
        crossReferenceMenu.OpenOnFirstAvailable();

    public void CrossReferenceStatementClicked(GameObjectStatement statement)
    {
        if (minutesLeft > 0)
        {
            askConfirmationMenu.OpenMenu(statement);
        }
    }

    public void Ask(ScriptableStatement statement)
    {
        InvestigatedPerson.AskStatement(statement, out bool newInfoGained);
        
        if (newInfoGained)
        {
            minutesLeft -= newInfoCostInMinutes;
        }

        UpdateTimer();
        investigatedPersonMenu.UpdateOpened();
        crossReferenceMenu.UpdateColorMultipliers();
    }

    private void UpdateTimer()
    {
        timerTMP.text = $"{HoursLeft:00}:{MinutesMinusHoursLeft:00}:00";
    }

    public void Guess()
    {
        noMoreTimeMenu.OpenMenu(timeLeft: minutesLeft > 0);
    }
}
