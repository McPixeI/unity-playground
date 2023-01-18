using UnityEngine;

public class Door : Interactable
{
    private bool isOpen;
    private Animator animator;
    private string startPrompt;

    void Start()
    {
        animator = GetComponent<Animator>();
        startPrompt = promptMessage;
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Closed"))
        {
            promptMessage = startPrompt;
        }
        else
        {
            promptMessage = "Cerrar";
        }

    }
    protected override void Interact()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
    }
}
