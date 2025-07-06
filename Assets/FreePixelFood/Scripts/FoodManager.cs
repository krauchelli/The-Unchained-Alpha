using UnityEngine;
using TMPro;

public class FoodManager : MonoBehaviour
{
    public static FoodManager instance;

    public int FoodCount { get; private set; }
    [SerializeField] private TMP_Text foodCountText;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void OnGUI()
    {
        foodCountText.text = FoodCount.ToString();
    }

    public void ChangeFoodCount(int amount)
    {
        FoodCount += amount;
    }
}
