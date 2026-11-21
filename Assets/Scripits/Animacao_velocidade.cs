using UnityEngine;
using UnityEngine.AI;

public class Animacao_velocidade : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float velocidade;

    [SerializeField]
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocidade = agent.velocity.sqrMagnitude;
        animator.SetFloat("Multivelocidade", velocidade);
    }
}
