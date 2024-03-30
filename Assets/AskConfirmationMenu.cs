using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AskConfirmationMenu : MonoBehaviour
{
    [SerializeField] Button askButton;
    [SerializeField] Button cancelButton;

    Engine Engine => Engine.instance;

    public void Awake()
    {
        cancelButton.onClick.AddListener(() => HideMenu());
        HideMenu();
    }

    private void HideMenu()
    {
        gameObject.SetActive(false);
    }

    public void OpenMenu(GameObjectStatement statement)
    {
        gameObject.SetActive(true);

        askButton.onClick.RemoveAllListeners();
        askButton.onClick.AddListener(() => Ask(statement));
    }

    private void Ask(GameObjectStatement statement)
    {
        HideMenu();
        Engine.Ask(statement.Statement.statement);
    }
}
