using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;
using Cinemachine;
public class GameManager : Singleton<GameManager> 
{
    [Header("Cinemachine")]
    public CinemachineVirtualCamera virtualCamera;

    [Header("Player")]
    public GameObject playerPrefab;


    [Header("References")]
    public Transform startPoint;
   
    [Header("Animation setup")]
    public float duration = 1f;
    public float delay = .2f;
    public Ease ease = Ease.OutBack;
    
    private GameObject _currentPlayer;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        _currentPlayer=Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0,duration).SetEase(ease).From().SetDelay(delay);
        virtualCamera.Follow= _currentPlayer.transform;
        virtualCamera.LookAt = _currentPlayer.transform;
    }
}
