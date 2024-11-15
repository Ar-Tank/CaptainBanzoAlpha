using UnityEngine;

public class CollectibleDebris : Interactable
{
    private PlayerInventory playerInventory; // Reference to player's inventory

    void Start()
    {
        // Find the player's inventory at the start
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerInventory = player.GetComponent<PlayerInventory>();
        }

        // Set the prompt message for debris collection
        promptMessage = "Press F to collect debris.";
    }

    protected override void Interact()
    {
        // Add the debris to the inventory if possible
        if (playerInventory != null)
        {
            playerInventory.AddDebris(gameObject); // Add the debris to the inventory
            Debug.Log("Debris collected!"); // Log for confirmation
            Destroy(gameObject); // Destroy the debris after collection
        }
        else
        {
            Debug.LogWarning("Player inventory not found."); // Log a warning if no inventory
        }
    }
}
