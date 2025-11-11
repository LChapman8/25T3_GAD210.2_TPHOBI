using UnityEngine;
using UnityEngine.UI;

public class PickUpOrbButton : MonoBehaviour
{
    public Button orbButton;

    private void Start()
    {
        orbButton.onClick.AddListener(PickUpOrb);
    }

    void PickUpOrb()
    {
        LuckManager.Instance.GainOrbOfLuck();
        orbButton.gameObject.SetActive(false); // Hide button once picked up
    }
}
