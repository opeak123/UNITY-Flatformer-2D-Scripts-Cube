using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    //플레이어 애니메이션
    private Animator animator;
    private void Awake()
    {
        //할당
        animator = GetComponent<Animator>();
    }

    public void SetIsGrounded(bool isGrounded) //idle 애니메이션
    {
        animator.SetBool("idle", isGrounded);
    }

    public void SetSpeed(float speed)   //walk 애니메이션
    {
        animator.SetFloat("speed", speed);
    }

    public void TriggerJump()   //jump 애니메이션
    {
        animator.SetTrigger("jump");
    }

    public void TriggerDash() //dash 애니메이션
    {
        animator.SetTrigger("dash");
    }
    public void TriggerCrouch() //crouch 애니메이션
    {
        animator.SetTrigger("crouch");
    }
    public void TriggerSleep() //sleep 애니메이션
    {
        animator.SetBool("sleep", true);
    }

    public void TriggerWakeUp() //wake up 애니메이션
    {
        animator.SetBool("wakeUp", true);
    }
    public void TriggerLookingUp() // looking up 애니메이션
    {
        animator.SetTrigger("lookingUp");
    }
    public void BooleanLaddering(bool value) //laddering 애니메이션
    {
        animator.SetBool("laddering",true);
    }
}