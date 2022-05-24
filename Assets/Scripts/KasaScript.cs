using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaScript : MonoBehaviour
{
    public GameObject moneyPrefab;
    public Transform moneyHolder;
    public List<GameObject> moneyList= new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            GameObject temp = Instantiate(moneyPrefab, moneyHolder);
            temp.transform.position = new Vector3(moneyHolder.position.x, moneyHolder.position.y + moneyList.Count/10.0f, moneyHolder.position.z);
            moneyList.Add(temp);
        }
    }
}
