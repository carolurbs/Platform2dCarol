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
    public Animator animator;
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
        animator.SetTrigger(soPlayer.triggerDeath);
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
             animator.speed = 2; 

         }
         else
         {
             _currentSpeed = soPlayer.speed; 
             animator.speed = 1;

         }
         if (Input.GetKey(KeyCode.LeftArrow))
         {
             //myRigidbody.MovePosition(myRigidbody.position-velocity*Time.deltaTime);
             myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x !=-1)
             {
                 myRigidbody.transform.DOScaleX (-1, soPlayer.playerSwipeduration);

             }
              animator.SetBool(soPlayer.triggerRun, true);
         }
         else if (Input.GetKey(KeyCode.RightArrow))
         {
             //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
             myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
             if (myRigidbody.transform.localScale.x != 1)
             {
                 myRigidbody.transform.DOScaleX(1, soPlayer.playerSwipeduration);

             }
            animator.SetBool(soPlayer.triggerRun, true);

         }
         else
         {
            animator.SetBool(soPlayer.triggerRun, false);

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
            animator.SetTrigger(soPlayer.triggerJump);

            myRigidbody.velocity = Vector2.up * soPlayer.forceJump;
          //  myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

             HandleScaleJump();

        }
    }
     private void HandleScaleJump()
     {
         myRigidbody.transform.DOScaleY(soPlayer.jumpScaleY, soPlayer.animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(soPlayer.ease);
       // myRigidbody.transform.DOScaleX(soPlayer.jumpScaleX, soPlayer.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer.ease);
        float initialScalex = 1;
        DOTween.To( delegate(float value)
           {
                int currentDirection = transform.localScale.x > 0 ? 1 : -1;
                float currentScale =Mathf.Abs(initialScalex)+(soPlayer.jumpScaleX-Mathf.Abs(initialScalex))*value;
                currentScale *= currentDirection;
                var scale =transform.localScale;
                scale.x = currentScale;
                transform.localScale = scale;

        },
        0,1,soPlayer.animationDuration).SetEase(soPlayer.ease).SetLoops(2,LoopType.Yoyo);
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
