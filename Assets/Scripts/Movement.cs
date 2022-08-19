using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private Animator _animator;
   
    private Character_Animation_Controller _animationcontroller;




    // Start is called before the first frame update
    public float Left = 0.0f;

    public float Right = 0.0f;

     public float Center = 0.0f;


    [SerializeField] private Transform _EndPoint;

    private Sequence _sequence1;

    private void Start()
    {
        _animationcontroller = new Character_Animation_Controller(_animator);

        Climbing();
     

        
        
    }

    private void Climbing()
    {

        _sequence1.Kill();

        Vector3 New_position = new Vector3(this.gameObject.transform.position.x, _EndPoint.position.y,this. gameObject.transform.position.z);

        transform.position = this.gameObject.transform.position;

        _sequence1 = DOTween.Sequence().AppendCallback(PlayClimbAnimation).Join(transform.DOMove(New_position, 10.0f));

     

    }

    private void RightJumping()
    {




        _sequence1.Kill();

        
        
            Vector3 New_position = new Vector3(gameObject.transform.position.x-17, gameObject.transform.position.y+12, gameObject.transform.position.z);

            transform.position = this.gameObject.transform.position;

            _sequence1 = DOTween.Sequence().AppendCallback(PlayJumpAnimation).Join(transform.DOMove(New_position, 0.5f)).AppendCallback(Climbing);

        

      
      
    }


    private void LeftJumping()
    {



        
            _sequence1.Kill();


            Vector3 New_position = new Vector3(gameObject.transform.position.x + 17, gameObject.transform.position.y+12, gameObject.transform.position.z);

            transform.position = this.gameObject.transform.position;

            _sequence1 = DOTween.Sequence().AppendCallback(PlayJumpAnimation).Join(transform.DOMove(New_position, 0.5f)).AppendCallback(Climbing);

        



    }

    public void ClickJumpRight()
    {

        if (this.gameObject.transform.position.x < Left+6 && this.gameObject.transform.position.x > Left - 6 | this.gameObject.transform.position.x < Center+4 && this.gameObject.transform.position.x > Center - 4)
        {
            RightJumping();

        }

    }


    public void ClickJumpLeft()
    {

        if (this.gameObject.transform.position.x > Right-4 && this.gameObject.transform.position.x < Right+4  |  this.gameObject.transform.position.x > Center-4  && this.gameObject.transform.position.x < Center+4)
        {
            LeftJumping();

        }

    }

    public void ClickClimb()
    {
        Climbing();

    }
    private void Update()
    {
      
        

        

    }
    private void PlayJumpAnimation() => _animationcontroller.PlayAnimation(Types.Jump);
    private void PlayClimbAnimation() => _animationcontroller.PlayAnimation(Types.Climb);
}
