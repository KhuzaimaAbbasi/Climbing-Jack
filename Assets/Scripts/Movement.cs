using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Animation anim;

    [SerializeField] private Animator _animator;


    [SerializeField]


    private Character_Animation_Controller _animationcontroller;

   private void CallMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
           

            

            if (Input.mousePosition.x < Screen.width / 2)
            {

                ClickJumpLeft();
            }
            else if (Input.mousePosition.x > Screen.width / 2)
            {
                ClickJumpRight();
            }

            
        }
    }

    private void CallTouch()

    { 
        
        if (Input.touchCount > 0)
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

            Climbing();
}
    }

    // Start is called before the first frame update
    public float Left = 0.0f;

    public float Right = 0.0f;

    public float Center = 0.0f;


    [SerializeField] private Transform _EndPoint;

    private Sequence _sequence1;

    private Sequence _sequence2;


    private Sequence _sequence3;

    public Rigidbody RB;


    private void Start()
    {
        _animationcontroller = new Character_Animation_Controller(_animator);



        


    }

    public float speed = 0.3f;
    private void Climbing()
    {


        
      /* Vector3 New_position = new Vector3(this.gameObject.transform.position.x, _EndPoint.position.y, this.gameObject.transform.position.z);

       transform.position = this.gameObject.transform.position;

         _sequence1 = DOTween.Sequence().AppendCallback(PlayClimbAnimation).Append(transform.DOMove(New_position, 40.0f).SetEase(Ease.Linear));*/

        transform.Translate(Vector3.up * speed);

        PlayClimbAnimation();

        
    }

    public float jumpspeed = 5f;
    private void RightJumping()
    {








        Vector3 New_position = new Vector3(gameObject.transform.position.x - 85, gameObject.transform.position.y + 22, gameObject.transform.position.z);

        transform.position = this.gameObject.transform.position;

        _sequence2 = DOTween.Sequence().AppendCallback(PlayJumpAnimation).Join(transform.DOMove(New_position, 0.5f));






       /* Vector3 Temp = gameObject.transform.position;

        RB.velocity = new Vector3(-1 * 85, 1 * 22, 0);
        PlayJumpAnimation();

        if (Temp.x == -35)


        {
            if (gameObject.transform.position.x == -120)
            {
                RB.velocity = Vector3.zero;
                RB.angularVelocity = Vector3.zero;
            }

        }
        else if (Temp.x == 50)
        {
            if (gameObject.transform.position.x == -35)
            {
                RB.angularVelocity = Vector3.zero;

                RB.velocity = Vector3.zero;
            }


        }*/
    }
    private void LeftJumping()
    {



        



        Vector3 New_position = new Vector3(gameObject.transform.position.x + 85, gameObject.transform.position.y+22 , gameObject.transform.position.z);

        transform.position = this.gameObject.transform.position;

        _sequence2 = DOTween.Sequence().AppendCallback(PlayJumpAnimation).Join(transform.DOMove(New_position, 0.5f));




        

        
       /* Vector3 Temp = gameObject.transform.position;

        RB.velocity = new Vector3(1 * 85, 1 * 22, 0);

        PlayJumpAnimation();


        if (Temp.x == -35)


        {
            if (gameObject.transform.position.x == 50)
            {
                RB.velocity = Vector3.zero;
                RB.angularVelocity = Vector3.zero;
            }

        }
        else if (Temp.x == -120)
        {
            if (gameObject.transform.position.x == -35)
            {
                RB.velocity = Vector3.zero;
                RB.angularVelocity = Vector3.zero;
            }


        }*/


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

   
    private void Update()
    {
        CallMouse();


        Climbing();


        

    }


    const string Obstacle_Tag = "Obstacle";

    const string Cloud_Tag = "Cloud";

    public string Retry;
    private void OnCollisionEnter(Collision collision)
    {

        

        if (collision.gameObject.CompareTag(Obstacle_Tag))
        {

            



            Vector3 New_position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-300, this.gameObject.transform.position.z);

            transform.position = this.gameObject.transform.position;

            _sequence3 = DOTween.Sequence().AppendCallback(PlayDeathAnimation).Join(transform.DOMove(New_position, 6.0f));

            

            Invoke("Load_Scene_fail",2f);



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

    private void Load_Scene_fail()
    {
        SceneManager.LoadScene(Retry);


    }
    private void PlayJumpAnimation() => _animationcontroller.PlayAnimation(Types.Jump);
    private void PlayClimbAnimation() => _animationcontroller.PlayAnimation(Types.Climb);

    private void PlayDeathAnimation() => _animationcontroller.PlayAnimation(Types.Death);

    private void PlayGrabAnimation() => _animationcontroller.PlayAnimation(Types.Grab);


}
