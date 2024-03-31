using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoMoreTimeMenu : MonoBehaviour
{
    [SerializeField] Button closeButton;

    [SerializeField] TextMeshProUGUI noMoreTimeTMP;

    [SerializeField] GameObject correct;
    [SerializeField] GameObject wrong;

    public void OpenMenu(bool timeLeft = true)
    {
        gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        noMoreTimeTMP.gameObject.SetActive(false);

        if (timeLeft == false)
        {
            noMoreTimeTMP.gameObject.SetActive(true);
            closeButton.gameObject.SetActive(false);
        }
    }

    public void CorrectGuess()
    {
        correct.SetActive(false);
    }

    public void WrongGuess()
    {
        wrong.SetActive(true);
    }
}
