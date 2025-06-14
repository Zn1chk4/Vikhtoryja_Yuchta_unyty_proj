using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class Inventory : MonoBehaviour
{
    public int mushroomCount = 0;
    public TextMeshProUGUI mushroomText; 

    public void AddMushroom()
    {
        mushroomCount++;
        UpdateMushroomUI();
    }

    void UpdateMushroomUI()
    {
        if (mushroomText != null)
        {
            mushroomText.text = "mushrooms:  " + mushroomCount.ToString();
        }
    }
}