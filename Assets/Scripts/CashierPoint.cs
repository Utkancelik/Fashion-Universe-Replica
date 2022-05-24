using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashierPoint : MonoBehaviour
{
    KasaScript kasaScript;

    public static int money = 0;

    public Text moneyText;
    private void Awake()
    {
        kasaScript = GameObject.FindGameObjectWithTag("Kasa").GetComponent<KasaScript>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && kasaScript.moneyList.Count > 0)
        {
            money += kasaScript.moneyList.Count * 5;
            for (int i = 0; i < kasaScript.moneyList.Count; i++)
            {
                Destroy(kasaScript.moneyList[i]);
                kasaScript.moneyList.Remove(kasaScript.moneyList [i]);
            }
        }
    }

    private void Update()
    {
        moneyText.text = "$"+money.ToString();
    }
}
