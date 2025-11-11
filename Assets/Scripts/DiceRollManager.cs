using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceRollManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Button rollButton;
    public TMP_Text diceResultText;
    public Button failButton;
    public Button successButton;
    public TMP_Text successText;

    private void Start()
    {
        failButton.gameObject.SetActive(false);
        successButton.gameObject.SetActive(false);
        successText.gameObject.SetActive(false);
        rollButton.onClick.AddListener(RollDice);
    }

    void RollDice()
    {
        int baseRoll = Random.Range(1, 21);
        int luckBonus = LuckManager.Instance.GetLuckBonus();
        int totalRoll = baseRoll + luckBonus;

        // Build the text dynamically depending on whether the orb has been collected
        if (luckBonus > 0)
        {
            diceResultText.text = $"You rolled: {baseRoll} + {luckBonus} (Luck Bonus) = {totalRoll}";
        }
        else
        {
            diceResultText.text = $"You rolled: {baseRoll}";
        }

        rollButton.interactable = false;

        if (totalRoll <= 10)
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
