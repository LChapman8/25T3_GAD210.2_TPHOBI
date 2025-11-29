using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DiceRollManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Button rollButton;
    public TMP_Text diceResultText;
    public Button failButton;
    public Button successButton;
    public TMP_Text successText;

    [Header("Dice Visuals")]
    public Image diceImage;
    public Sprite[] diceFaces;      // 20 dice sprites
    public float rollDuration = 1f; // how long animation runs
    public float rollSpeed = 0.05f; // delay between sprite swaps

    private void OnEnable()
    {
        ResetUI();
    }

    private void Start()
    {
        rollButton.onClick.AddListener(() => StartCoroutine(AnimateDiceRoll()));
    }

    void ResetUI()
    {
        diceResultText.text = "";
        rollButton.interactable = true;
        failButton.gameObject.SetActive(false);
        successButton.gameObject.SetActive(false);
        successText.gameObject.SetActive(false);

        if (diceImage != null && diceFaces.Length > 0)
        {
            diceImage.sprite = diceFaces[0]; // reset to 1
        }
    }

    IEnumerator AnimateDiceRoll()
    {
        rollButton.interactable = false;
        float timer = 0f;

        // Flicker dice faces quickly
        while (timer < rollDuration)
        {
            int randomFace = Random.Range(0, 20);
            diceImage.sprite = diceFaces[randomFace];
            timer += rollSpeed;
            yield return new WaitForSeconds(rollSpeed);
        }

        // Final actual roll
        int baseRoll = Random.Range(1, 21);
        int luckBonus = LuckManager.Instance.GetLuckBonus();
        int totalRoll = baseRoll + luckBonus;

        // Show final face
        diceImage.sprite = diceFaces[baseRoll - 1];

        // Update text
        if (luckBonus > 0)
            diceResultText.text = $"You rolled: {baseRoll} + {luckBonus} (Luck Bonus) = {totalRoll}";
        else
            diceResultText.text = $"You rolled: {baseRoll}";

        // Success or fail
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
