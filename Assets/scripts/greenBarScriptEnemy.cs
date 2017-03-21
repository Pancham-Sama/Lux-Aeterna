using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenBarScriptEnemy : MonoBehaviour
{
    public Transform Enemy;

    void Start ()
    {
        //EnemyBehaviourScript = Enemy.transform.GetComponent<EnemyBehaviourScript>(); //EnemyBehaviourScript = GameObject.Find(Enemy).GetComponent <EnemyBehaviourScript>();
    }
	void Update ()
    {
        //transform.localScale = new Vector3(EnemyBehaviourScript.life / 320, transform.localScale.y, transform.localScale.z);
    }
}