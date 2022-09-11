using UnityEngine;
using System.Collections;

public class Character_Animation_Controller : MonoBehaviour
{

    private Animator _animator;

    private static int JumpKey = Animator.StringToHash("Jump");
    private static int ClimbKey = Animator.StringToHash("Climb");
    private static int DeathKey = Animator.StringToHash("Death");
    private static int DanceKey = Animator.StringToHash("Dance");

    public Character_Animation_Controller(Animator animator)
    {

        _animator = animator;


    }


    public void PlayAnimation(Types Type)
    {

        switch (Type)
        {
            case Types.Jump:
                PlayJump();
                break;
            case Types.Climb:
                PlayClimb();
                break;
            case Types.Death:
                PlayDeath();
                break;
            case Types.Dance:
                PlayDance();
                break;





        }


    }
    private void PlayJump()
    {

        _animator.SetTrigger(JumpKey);

    }
    private void PlayClimb()
    {

        _animator.SetTrigger(ClimbKey);

    }

    private void PlayDeath()
    {

        _animator.SetTrigger(DeathKey);

    }

    private void PlayDance()
    {

        _animator.SetTrigger(DanceKey);

    }

}
