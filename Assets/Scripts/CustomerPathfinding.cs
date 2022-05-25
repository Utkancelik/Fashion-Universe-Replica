using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerPathfinding : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool taken;
    public static bool gidiyoMuyum;
    private GameManager gameManager;

    [SerializeField] private List<Transform> reyonlar = new List<Transform>();
    [SerializeField] private Transform itemHolderTransform;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();


        reyonlar.Clear();
        
    }
    void Start()
    {

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Reyon").Length; i++)
        {
            reyonlar.Add(GameObject.FindGameObjectsWithTag("Reyon")[i].transform);
        }


    }


    void Update()
    {
        //reyonlardan hangisinin boþ olduðunu bul
        if (!taken)
        {
            for (int i = 0; i < reyonlar.Count; i++)
            {
                GameObject reyon = reyonlar[i].gameObject;
                if (reyon != null)
                {
                    Reyon reyonScript = reyon.GetComponent<Reyon>();
                    if (reyonScript.reyonList.Count > 0 && !reyonScript.banaGelenVarMi)
                    {
                        agent.SetDestination(reyon.transform.position);
                        reyonScript.banaGelenVarMi = true;
                    }
                }
            }
        }



        if (itemHolderTransform.transform.childCount > 0)
        {
            agent.SetDestination(GameObject.Find("GameManager").GetComponent<GameManager>().kasaTransform);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reyon") && !taken)
        {
            Reyon reyonScript = other.gameObject.GetComponent<Reyon>();
            for (int i = 0; i < reyonScript.reyonList.Count; i++)
            {
                if (reyonScript.reyonList[i] != null)
                {
                    reyonScript.reyonList[i].transform.SetParent(itemHolderTransform, true);
                    reyonScript.reyonList[i].transform.localPosition = Vector3.zero;
                    reyonScript.reyonList.RemoveAt(i);
                    taken = true;
                    reyonScript.banaGelenVarMi = false;
                    break;
                }
                else
                {
                    return;
                }
            }

        }


        if (other.CompareTag("Kasa"))
        {
            Destroy(itemHolderTransform.transform.GetChild(0).gameObject);
            agent.SetDestination(GameObject.Find("GameManager").GetComponent<GameManager>().exitPoint);
        }



        if (other.CompareTag("Door"))
        {
            Destroy(gameObject);
            gameManager.customerInField--;
            gameManager.customerList.Remove(gameObject);
        }
    }


}
