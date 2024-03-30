using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvestigatedPersonMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI personNameTMP;
    [SerializeField] Image personNameBackgroundImage;

    [SerializeField] Image personAvatar;
    [SerializeField] Image personBackground;

    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Transform scrollAreaContent;

    [SerializeField, ReadOnly] Person person;
    public Person InvestigatedPerson => person;

    Engine Engine => Engine.instance;

    public void OpenMenu(Person personToOpenWith)
    {
        person = personToOpenWith;

        personNameTMP.text = person.name;
        personNameTMP.color = person.textColor;
        personNameBackgroundImage.color = person.backgroundColor;

        personAvatar.sprite = person.avatar;
        personBackground.sprite = person.background;

        personBackground.color = new Color(
            personBackground.color.r,
            personBackground.color.g,
            personBackground.color.b,
            personBackground.sprite == null ? 0 : 1);

        InstantiateRecording();
    }

    public void UpdateOpened()
    {
        InstantiateRecording();
        ScrollToBottom();
    }

    private void InstantiateRecording()
    {
        DestroyContentChildren();
        foreach (Statement statement in person.Recoroding)
        {
            GameObject prefab = statement is AskedStatement ? Engine.AskedStatementPrefab : Engine.AnsweredStatementPrefab;

            GameObject gameObjectStatement = Instantiate(prefab, scrollAreaContent);
            gameObjectStatement.GetComponent<GameObjectStatement>().InstantiatedInit(statement);
        }
    }

    private void DestroyContentChildren()
    {
        foreach (Transform child in scrollAreaContent)
        {
            Destroy(child.gameObject);
        }
    }

    private void ScrollToBottom()
    {
        scrollRect.normalizedPosition = new Vector2(0, 0);
    }
}
