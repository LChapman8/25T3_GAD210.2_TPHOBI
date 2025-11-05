using UnityEngine;
using TMPro; 
public class DeathTracker : MonoBehaviour
{
    public static DeathTracker Instance;
    [Header("UI Reference")]
    public TextMeshProUGUI deathText;
    private int deathCount = 0;
    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateDeathText();
    }
    public void AddDeath()
    {
        deathCount++;
        UpdateDeathText();
    }
    private void UpdateDeathText()
    {
        if (deathText != null)
        {
            deathText.text = "Deaths: " + deathCount.ToString();
        }
    }
   
    public void ResetDeaths()
    {
        deathCount = 0;
        UpdateDeathText();
    }
    public int GetDeathCount()
    {
        return deathCount;
    }
}
