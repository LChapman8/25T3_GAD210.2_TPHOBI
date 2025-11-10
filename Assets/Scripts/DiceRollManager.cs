using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceRollManagerTMP : MonoBehaviour
{
    [Header("UI Elements")]
    public Button rollButton;
    public TMP_Text diceResultText;    // Shows the dice roll
    public Button failButton;
    public Button successButton;
    public TMP_Text successText;       // Message shown on success

    private void Start()
    {
        // Hide outcome buttons and success text at start
        failButton.gameObject.SetActive(false);
        successButton.gameObject.SetActive(false);
        successText.gameObject.SetActive(false);

        // Assign roll button click event
        rollButton.onClick.AddListener(RollDice);
    }

    void RollDice()
    {
        int roll = Random.Range(1, 21); // D20 roll
        diceResultText.text = $"You rolled: {roll}";

        rollButton.interactable = false;

        if (roll <= 10)
        {
            failButton.gameObject.SetActive(true);
        }
        else
        {
            successButton.gameObject.SetActive(true);
            successText.gameObject.SetActive(true);
        }
    }
}
