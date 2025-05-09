using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;

    public string triggerToPlay = "Fly";
    public KeyCode KeyToTrigger = KeyCode.A;
    public KeyCode KeyToExit = KeyCode.S;

    private void OnValidate()
    {
        if(animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyToTrigger))
        {
            animator.SetTrigger(triggerToPlay);
        }

        /*
        if(Input.GetKeyDown(KeyToTrigger))
        {
            animator.SetBool(triggetToPlay, true);
        }
        else if (Input.GetKeyDown(KeyToTrigger))
        {
            animator.SetBool(triggerToPlay, false);
        }
        */
    }
}
