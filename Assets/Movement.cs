using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocity = 1.0f;

    public float jumping_power_left = 0.3f;

    public float jumping_power_right = 0.3f;
    


    public float Obj_right = 0;
    public float Obj_left = 0;

    //hello there
   

    public Rigidbody rb;
    void Start()
    {
        



    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        climb();


        if (this.gameObject.transform.position.x == Obj_right)
        {
            rb.velocity = Vector3.zero;

            climb();
          
            if (Input.GetKeyDown(KeyCode.A))

            {


                rb.AddForce(new Vector3(jumping_power_left, 0,0), ForceMode.Impulse);


            }


        }

        if (this.gameObject.transform.position.x == Obj_left)
        {

            rb.velocity = Vector3.zero;

            climb();
            if (Input.GetKeyDown(KeyCode.D))

            {

                rb.AddForce(new Vector3(jumping_power_left, 0, 0), ForceMode.Impulse);




            }



        }
    }

    public void climb()
    {

        rb.AddForce(new Vector3(0, velocity, 0), ForceMode.Force);


    }
}
