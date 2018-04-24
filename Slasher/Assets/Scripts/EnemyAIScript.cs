using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIScript : MonoBehaviour
{

    public GameObject Player;
    public float Distance;
    NavMeshAgent nav;
    public float Radius = 40;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, transform.position);
        if (Distance > Radius)
        {
            nav.enabled = false;
        }
        if (Distance < Radius)
        {
            nav.enabled = true;
            nav.SetDestination(Player.transform.position);
        }
    }
}