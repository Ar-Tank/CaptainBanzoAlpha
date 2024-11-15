using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCube : Interactable
{
    // GameObject called animator
    Animator animator;
    private string startPrompt;

    void Start()
    {
        animator = GetComponent<Animator>();
        startPrompt = promptMessage;
    }

    void Update()
    {
        transform.Rotate(-50 * Time.deltaTime, 50 * Time.deltaTime, 50 * Time.deltaTime, Space.Self);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
           promptMessage = startPrompt;
        }
        else
        {
            promptMessage = "Animating..";
        }
    }
    protected override void Interact()
    {
        animator.Play("Spin");
    }
}
