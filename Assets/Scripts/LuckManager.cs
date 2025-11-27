using UnityEngine;

public class LuckManager : MonoBehaviour
{
    public static LuckManager Instance;

    private int luckBonus = 0;
    private bool hasOrb = false;

    private void Awake()
    {
        // Singleton setup (same pattern as DeathTracker)
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

    public void GainOrbOfLuck()
    {
        if (!hasOrb)
        {
            hasOrb = true;
            luckBonus = 4;
            Debug.Log("You picked up the Ring Of Luck! Future rolls are boosted by +4!");
        }
    }

    public int GetLuckBonus()
    {
        return luckBonus;
    }

    public void ResetLuck()
    {
        hasOrb = false;
        luckBonus = 0;
    }
}
