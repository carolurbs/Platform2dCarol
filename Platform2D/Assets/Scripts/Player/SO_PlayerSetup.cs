using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[CreateAssetMenu]
public class SO_PlayerSetup : ScriptableObject
{
    [Header("General Setup")]
    public HealthBase healthBase;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;
    [Header("Animation Setup")]
    public float jumpScaleY;
    public float jumpScaleX ;
    public float animationDuration;
    public Ease ease = Ease.OutBack;

    [Header("Animation Payer")]
    public string triggerRun = "Run";
    public string triggerDeath = "Death";
    public string triggerJump = "´Jump";

    public float playerSwipeduration = .1f;
}
