using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public Transform diamond;
    public NavMeshAgent enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("FPS").GetComponent<PlayerMovement>().Diamond == true)
        {
            enemy.SetDestination(diamond.position);
        }
        if (GameObject.Find("FPS").GetComponent<PlayerMovement>().Player == true)
        {
            enemy.SetDestination(target.position);
        }
    }
}

