using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    Vector2 velocity;
    new Rigidbody2D rigidbody;
    Animator anim;
    private bool isjump=false;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horInput = Input.GetAxisRaw("Horizontal");
        velocity = new Vector2(horInput,0);

        if(horInput>0){
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if(horInput<0){
            transform.rotation = Quaternion.Euler(0,180,0);
        }

        if(velocity.x !=0){
            anim.SetBool("isWalk",true);
        }
        else{
            anim.SetBool("isWalk",false);
        }
        if(Input.GetKeyDown(KeyCode.Z)&&!isjump){
            rigidbody.AddForce(new Vector2(0,250));
            anim.SetTrigger("isJump");
            isjump = true;
        }
    }
    void FixedUpdate(){
        rigidbody.velocity = new Vector2(velocity.x*speed,rigidbody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            isjump = false;
            anim.Play("AM_Idle");
        }
    }
    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag == "Ground"&&!isjump){
            anim.Play("AM_Falling");
        }
    }
    void upStatus(){
        Debug.Log("UP");
    }
    void downStatus(){
        Debug.Log("DOWN");
    }

}
