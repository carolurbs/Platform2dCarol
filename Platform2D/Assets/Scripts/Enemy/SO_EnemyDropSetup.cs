using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class SO_EnemyDropSetup : ScriptableObject
{
    public string enemyTipe;

    [SerializeField] public List<GameObject> loot = new List<GameObject>();
    public Vector2 enemyposition;
    public int minValue; 
    public int maxValue;
}
