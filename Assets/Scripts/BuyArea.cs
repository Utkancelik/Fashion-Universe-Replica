using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyArea : MonoBehaviour
{
    public int cost, currentMoney;
    public GameObject reyonPrefab;
    private bool isCreated;
    public Text costText;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && currentMoney > 0)
        {        
            cost -= 1;
            CashierPoint.money -= 1;
            if (cost <= 0)
            {
                reyonPrefab.SetActive(true);
                isCreated = true;
            }
        }
    }

    private void Update()
    {
        currentMoney = CashierPoint.money;

        if (!isCreated)
        {
            costText.text = cost.ToString();
        }
        else
        {
            costText.text = "";
        }
    }

}
