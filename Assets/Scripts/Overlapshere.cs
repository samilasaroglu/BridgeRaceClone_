using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Overlapshere : MonoBehaviour
{
    public static Overlapshere instance;
    public Collider[] CemberIcindekiler; 
    public float yariCap;
    public LayerMask katman;
    public bool hedefVarMi;
    [SerializeField]private Vector3 hedef;
    [SerializeField] private bool yakinci, uzakci;
    public GameObject AnaHedef;
    public bool Anahedefe;
    public NavMeshAgent Agent;
    private Animator stickmanAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Agent = GetComponent<NavMeshAgent>();
        stickmanAnim = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Update()
    {
        CollectableBul();
    }

    public void CollectableBul()
    {
       if (!Anahedefe)
       {
           CemberIcindekiler = Physics.OverlapSphere(transform.position, yariCap,katman);
           if (CemberIcindekiler.Length > 0)
           {
                stickmanAnim.SetBool("Run", true);
                if (yakinci)
                {
                    hedef = CemberIcindekiler[CemberIcindekiler.Length - 1].transform.position;
                    Agent.SetDestination(hedef);
                }
                if (uzakci)
                {
                    hedef = CemberIcindekiler[0].transform.position;
                    Agent.SetDestination(hedef);
                }
           }
            else
            {
                //Sonra değiştirilecek
                Agent.SetDestination(new Vector3(0, -1, 10));
            }
       }
        else
        {
            Agent.SetDestination(AnaHedef.transform.position);
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position, yariCap);
    //}
}
