using UnityEngine;
using System.Collections;

public class Character_Animation_Controller : MonoBehaviour
{

    private Animator _animator;

    private static int JumpKey = Animator.StringToHash("Jump");
    private static int ClimbKey = Animator.StringToHash("Climb");



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
   
}
