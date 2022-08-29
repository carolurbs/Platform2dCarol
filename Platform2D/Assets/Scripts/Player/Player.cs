using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    [Header("Speed Setup")]
    public Vector2 friction = new Vector2 (-.1f,0);
    public float speed;
    public float speedRun;
    private float _currentSpeed;
    public float forceJump = 2;
    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = -.5f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    void Update()
    {
        VerticalMoviment();
        HorizontalMoviment();
    }

    void  HorizontalMoviment()

    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position-velocity*Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

        }
        if (myRigidbody.velocity.x>0)
        {
            myRigidbody.velocity += friction;
        }
        else if (myRigidbody.velocity.x<0)
        {
            myRigidbody.velocity -= friction;

        }
    }
    void VerticalMoviment()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

            HandleScaleJump();
        }
    }
    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY,animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="floor")
        {
            myRigidbody.transform.DOScaleY(-jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            myRigidbody.transform.DOScaleX(-jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);
        }
    }
}
