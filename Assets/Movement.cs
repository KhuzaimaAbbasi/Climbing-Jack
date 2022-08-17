using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float Left = 0.0f;

    public float Right = 0.0f;

    public float Center = 0.0f;
    
    [SerializeField] private Transform _EndPoint;

    private Sequence _sequence1;

    private void Start()
    {
        Climbing();
    }

    private void Climbing()
    {

        _sequence1.Kill();

        Vector3 New_position = new Vector3(this.gameObject.transform.position.x, _EndPoint.position.y,this. gameObject.transform.position.z);

        transform.position = this.gameObject.transform.position;

        _sequence1 = DOTween.Sequence().Join(transform.DOMove(New_position, 10.0f));

     

    }

    private void RightJumping()
    {




        _sequence1.Kill();

        
        
            Vector3 New_position = new Vector3(gameObject.transform.position.x-10, gameObject.transform.position.y, gameObject.transform.position.z);

            transform.position = this.gameObject.transform.position;

            _sequence1 = DOTween.Sequence().Join(transform.DOMove(New_position, 2.0f)).AppendCallback(Climbing);

        

      
      
    }


    private void LeftJumping()
    {




        _sequence1.Kill();

       
            Vector3 New_position = new Vector3(gameObject.transform.position.x +10, gameObject.transform.position.y, gameObject.transform.position.z);

            transform.position = this.gameObject.transform.position;

            _sequence1 = DOTween.Sequence().Join(transform.DOMove(New_position, 2.0f)).AppendCallback(Climbing);

        



    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {

            if (this.gameObject.transform.position.x != Right)
            {
             RightJumping();
            
            }
                

            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {

            if (this.gameObject.transform.position.x != Left)
            {
                LeftJumping();



            }


        }



    }

}
