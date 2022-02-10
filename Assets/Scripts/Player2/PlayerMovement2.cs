using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public float Speed;

    public float JumpPower;

    public LayerMask Mask;
    public Animator PlayerAnimator;
    public SpriteRenderer SR;

    private Rigidbody2D RB;

    private float _startJumpPower;
    private float _startSpeed;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {

        RB = GetComponent<Rigidbody2D>();
        _startJumpPower = JumpPower;
        _startSpeed = Speed;

    }

    // Update is called once per frame
    void Update() {
        
        Vector2 movement = new Vector2(0,RB.velocity.y);



    float DistanceToGround = GetComponent<Collider2D>().bounds.extents.y;
    _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, DistanceToGround+0.5f, Mask);




        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -Speed;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = Speed;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded ==true)
        {
            RB.AddForce(new Vector2(0, JumpPower));
            _isGrounded = false;
        }

        if(movement.x !=0)
        {
            PlayerAnimator.SetBool("IsWalking", true);
        }
        else
        {
          PlayerAnimator.SetBool("IsWalking", false);

        }

        //hoppe animation
        if(movement.y > 0)
        {
            PlayerAnimator.SetBool("IsJumping", true);
        }
        else
        {
          PlayerAnimator.SetBool("IsJumping", false);
        }

        if(movement.x >0)
        {
            SR.flipX = false;
        }

        if (movement.x <0)
        {
            SR.flipX = true;
        }

        RB.velocity = movement;


    }


    public void JumpPowerUp(float seconds, float Power)
    {
            StartCoroutine(RunJumpPowerup(seconds, Power));
    }

    IEnumerator RunJumpPowerup(float seconds, float Power)
    {
        JumpPower= Power;
        yield return new WaitForSeconds(seconds);
        JumpPower = _startJumpPower;
    }

    public void SpeedPowerup(float seconds, float speedPower)
    {
            StartCoroutine(RunSpeedBoost(seconds, speedPower));
    }

    IEnumerator RunSpeedBoost(float seconds, float speedPower)
    {
        Speed= speedPower;
        yield return new WaitForSeconds(seconds);
        Speed = _startSpeed;
    }

}
