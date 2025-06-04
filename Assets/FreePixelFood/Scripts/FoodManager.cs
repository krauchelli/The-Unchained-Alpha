using UnityEngine;
using TMPro;

public class FoodManager : MonoBehaviour
{
    public static FoodManager instance;

    private int foodCount;
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
        foodCountText.text = foodCount.ToString();
    }

    public void ChangeFoodCount(int amount)
    {
        foodCount += amount;
    }
}
