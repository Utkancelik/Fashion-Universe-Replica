using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform customerSpawnPoint;
    [SerializeField] GameObject customerPrefab;
    [HideInInspector] public Vector3 kasaTransform;
    [HideInInspector] public Vector3 exitPoint;
    public List<GameObject> customerList = new List<GameObject>();

    public GameObject reyonToBeCreated;
    public int customerInField = 0;
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
            if (customerInField < 3)
            {
                GameObject temp = Instantiate(customerPrefab, customerSpawnPoint.position, Quaternion.identity);
                customerList.Add(temp);
                CustomerPathfinding.gidiyoMuyum = false;
                customerInField++;
                yield return new WaitForSeconds(5.0f);
            }         
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

    private void Update()
    {
        Debug.Log("müþteri sayýsý: " + customerInField);
    }
}
