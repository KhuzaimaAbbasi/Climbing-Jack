using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    [SerializeField] private Animator _animator;


    [SerializeField]


    private Character_Animation_Controller _animationcontroller;

   private void CallMouse()
    { 
        
        if(Input.GetMouseButtonDown(0))
      {  
            {
            if (Input.mousePosition.x<Screen.width/2)
            {
                ClickJumpLeft();
}
            else if (Input.mousePosition.x > Screen.width / 2)
{
    ClickJumpRight();
}
        }


  }
       }

    private void CallTouch()
    { if (Input.touchCount > 0)
     {
         Touch touch = Input.GetTouch(0);



         if (touch.position.x < Screen.width / 2)
         {
             ClickJumpLeft();


         }


         else if (touch.position.x > Screen.width / 2)
         {
             ClickJumpRight();


         }


}
    }

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

        Vector3 New_position = new Vector3(this.gameObject.transform.position.x, _EndPoint.position.y, this.gameObject.transform.position.z);

        transform.position = this.gameObject.transform.position;

        _sequence1 = DOTween.Sequence().AppendCallback(PlayClimbAnimation).Join(transform.DOMove(New_position, 35.0f));



    }

    private void RightJumping()
    {




        _sequence1.Kill();



        Vector3 New_position = new Vector3(gameObject.transform.position.x - 85, gameObject.transform.position.y+22 ,gameObject.transform.position.z);

        transform.position = this.gameObject.transform.position;

        _sequence1 = DOTween.Sequence().Join(transform.DOMove(New_position, 0.5f)).AppendCallback(Climbing);





    }


    private void LeftJumping()
    {




        _sequence1.Kill();


        Vector3 New_position = new Vector3(gameObject.transform.position.x + 85, gameObject.transform.position.y+22 , gameObject.transform.position.z);

        transform.position = this.gameObject.transform.position;

        _sequence1 = DOTween.Sequence().Join(transform.DOMove(New_position, 0.5f)).AppendCallback(Climbing);





    }

    public void ClickJumpRight()
    {

        if (this.gameObject.transform.position.x < Left + 2 && this.gameObject.transform.position.x > Left - 2 | this.gameObject.transform.position.x < Center + 2 && this.gameObject.transform.position.x > Center - 2)
        {
            RightJumping();

        }

    }


    public void ClickJumpLeft()
    {

        if (this.gameObject.transform.position.x > Right - 2 && this.gameObject.transform.position.x < Right + 2 | this.gameObject.transform.position.x > Center - 2 && this.gameObject.transform.position.x < Center + 2)
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



        CallMouse();


    }







    const string Obstacle_Tag = "Obstacle";

    const string Cloud_Tag = "Cloud";
    private void OnCollisionEnter(Collision collision)
    {

        _sequence1.Kill();

        if (collision.gameObject.CompareTag(Obstacle_Tag))
        {

            



            Vector3 New_position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-10, this.gameObject.transform.position.z);

            transform.position = this.gameObject.transform.position;

            _sequence1 = DOTween.Sequence().Join(transform.DOMove(New_position, 2.0f));

            

            Invoke("Load_Scene_GameOver",1.7f);



        }

       else if (collision.gameObject.CompareTag(Cloud_Tag))
            {

            Load_Scene();

        }


    }

    public string Interlude;

    private void Load_Scene_GameOver()
    {
        SceneManager.LoadScene("Game_Over_Scene");



    }
    
    private void Load_Scene()
    {


        SceneManager.LoadScene(Interlude);


    }
    private void PlayJumpAnimation() => _animationcontroller.PlayAnimation(Types.Jump);
    private void PlayClimbAnimation() => _animationcontroller.PlayAnimation(Types.Climb);

    
}
