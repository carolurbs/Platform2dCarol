using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("General Setup")]
    public Rigidbody2D myRigidbody;
    public HealthBase healthBase;
    private bool _isRunning;
    private float _currentSpeed;
    [Header("SO Setup")]
    public SO_PlayerSetup soPlayer;


    private void Awake()
    {
        if(healthBase !=null)
        {
            healthBase.OnKill +=OnPlayerKill;   
        }
    }
    private void  OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
       soPlayer.animator.SetTrigger(soPlayer.triggerDeath);
    }
    void Update()
    {
        VerticalMoviment();
        HorizontalMoviment();
    }

    void  HorizontalMoviment()

    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = soPlayer.speedRun;
            soPlayer.animator.speed = 2; 

        }
        else
        {
            _currentSpeed = soPlayer.speed; 
            soPlayer.animator.speed = 1;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position-velocity*Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
           if (myRigidbody.transform.localScale.x !=-1)
            {
                myRigidbody.transform.DOScaleX (-1, soPlayer.playerSwipeduration);

            }
            soPlayer. animator.SetBool(soPlayer.triggerRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayer.playerSwipeduration);

            }
            soPlayer.animator.SetBool(soPlayer.triggerRun, true);

        }
        else
        {
            soPlayer.animator.SetBool(soPlayer.triggerRun, false);

        }
        if (myRigidbody.velocity.x>0)
        {
            myRigidbody.velocity += soPlayer.friction;
        }
        else if (myRigidbody.velocity.x<0)
        {
            myRigidbody.velocity -= soPlayer.friction;

        }
    }
    void VerticalMoviment()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * soPlayer.forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

            HandleScaleJump();
        }
    }
    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(soPlayer.jumpScaleY, soPlayer.animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(soPlayer.ease);
        myRigidbody.transform.DOScaleX(soPlayer.jumpScaleX., soPlayer.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    /* void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="floor")
        {
            myRigidbody.transform.DOScaleY(-jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            myRigidbody.transform.DOScaleX(-jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);
        }
    }*/
}
