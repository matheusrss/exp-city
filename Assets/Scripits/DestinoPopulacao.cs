using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class DestinoPopulacao : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent pessoa;

    [SerializeField]
    private NavMeshObstacle pessoaObs;

    [SerializeField]
    private Transform[] pos;

    private RaycastHit hitCentral, hitDireita, hitEsquerda;

    private Quaternion rotPositivo = Quaternion.AngleAxis(60.0f, new Vector3(0, 1, 0));

    private Quaternion rotNegativo = Quaternion.AngleAxis(-60.0f, new Vector3(0, 1, 0));
    private int indice = 0;

    private int destinoAtual;

    private float intervaloPath = 7;

    [SerializeField]
    private Animator anim;

    private bool esperando = false;

    

    void Start()
    {
        {
            if (pos.Length == 0) return;

            pessoa.SetDestination(pos[indice].position);

        }
    }

    IEnumerator EsperaNode()
    {
        print("esperando");
        esperando = true;
        anim.SetBool("Parou", true);
        yield return new WaitForSeconds (5f);
        esperando = false;
        print("Parou a espera");
        anim.SetBool("Parou", false);
        indice = (indice + 1) % pos.Length; // volta pro 0 depois do último
        pessoa.SetDestination(pos[indice].position);
    }

   

    void Update()
    {
        if(intervaloPath > 0){
        intervaloPath -= Time.deltaTime;
        }
        intervaloPath = Mathf.Max(0, intervaloPath);

        //print (intervaloPath);

        if (pos.Length == 0) return;

        // chegou? (pathPending evita checar antes de o caminho existir)
        if (!pessoa.pathPending && pessoa.remainingDistance <= pessoa.stoppingDistance && esperando == false)
        {
            StartCoroutine(EsperaNode());
        }

            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hitCentral, 0.8f))
        {
            //print("Central");
            MudaDestinoCol();
        }
        else if(Physics.Raycast(transform.position,transform.TransformDirection(rotPositivo * Vector3.forward), out hitCentral, 0.7f))
        {
            //print("Positivo");
            MudaDestinoCol();
        }
        else if(Physics.Raycast(transform.position,transform.TransformDirection(rotNegativo * Vector3.forward), out hitCentral, 0.7f))
        {
            //print("Negativo");
            MudaDestinoCol();
        }

        Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward * 0.8f), Color.blue);
        Debug.DrawRay(transform.position,transform.TransformDirection(rotPositivo * Vector3.forward * 0.7f), Color.blue);
        Debug.DrawRay(transform.position,transform.TransformDirection(rotNegativo * Vector3.forward * 0.7f), Color.blue);
    }

    void MudaDestinoCol()
    {
        if(intervaloPath <= 0 && esperando == false)
        {
        destinoAtual = Random.Range(0, pos.Length);

        pessoa.SetDestination(pos[destinoAtual].transform.position);
        intervaloPath = 7;
        }
    }
    
}