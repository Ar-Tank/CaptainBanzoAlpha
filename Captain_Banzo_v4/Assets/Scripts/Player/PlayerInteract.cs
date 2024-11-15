using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] //Make it visible in editor
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        // Already has Camera cam set up within PlayerLook within Player Asset, calling it here for Interact function
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // Create ray at the centre of the camera, shooting forward
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // Store collision information
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            // Checking if object has an interactable component
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                // Storing interactable in a variable
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                // Showing message
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
