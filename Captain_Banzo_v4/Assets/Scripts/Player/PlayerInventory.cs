using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Reference to the counter UI Text
    private int debrisCount = 0;        // Tracks collected debris count

    public void AddDebris(GameObject debris)
    {
        debrisCount++; // Increase count when debris is collected
        UpdateCounterUI(); // Update the UI
        Debug.Log("Debris collected! Total: " + debrisCount);
    }

    private void UpdateCounterUI()
    {
        if (counterText != null)
        {
            counterText.text = "Debris: " + debrisCount;
        }
        else
        {
            Debug.LogWarning("Counter Text is not assigned!");
        }
    }
}
