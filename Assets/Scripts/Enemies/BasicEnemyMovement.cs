using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyMovement : MonoBehaviour
{

    private NavMeshAgent m_NavAgent;
    [SerializeField] public Transform goal;
    private Rigidbody m_Rigidbody;

    private bool m_Follow;

    // Start is called before the first frame update
    void Start()
    {
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
    }

    private void OnEnable()
    {
        //m_Rigidbody.isKinematic = false;
    }

    private void OnDisable()
    {
        //m_Rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Follow == false)
            return;

        m_NavAgent.SetDestination(goal.position);
        m_NavAgent.isStopped = false;
       
    }
}
