using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform customerSpawnPoint;
    [SerializeField] GameObject customerPrefab;
    [HideInInspector] public Vector3 kasaTransform;
    [HideInInspector] public Vector3 exitPoint;
    private List<GameObject> customerList = new List<GameObject>();

    public GameObject reyonToBeCreated;
    private void Start()
    {
        exitPoint = GameObject.Find("DoorExitPoint").transform.position;
        kasaTransform = GameObject.FindGameObjectWithTag("Kasa").transform.position;
        
        StartCoroutine(SpawnCustomer());
    }
    IEnumerator SpawnCustomer()
    {
        while (true)
        {
            GameObject temp = Instantiate(customerPrefab,customerSpawnPoint.position,Quaternion.identity);        
            customerList.Add(temp);
            CustomerPathfinding.gidiyoMuyum = false;
            if (customerList.Count >= 3)
            {
                break;
            }
            yield return new WaitForSeconds(12.5f);

        }
        

    }

    private void SpawnNewReyon()
    {
        if (CashierPoint.money > 5)
        {
            CashierPoint.money -= 5;
            reyonToBeCreated.SetActive(true);
        }
    }
}
