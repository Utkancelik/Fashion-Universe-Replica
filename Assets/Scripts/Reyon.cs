using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Reyon : MonoBehaviour
{

    PlayerCollector collector;
    public List<GameObject> reyonList = new List<GameObject>();
    [SerializeField] private Transform itemHolderTransform;

    public int numOfItemsHolding = 0;
    public int maxNumOfItemsHolding = 3;
    private void Awake()
    {
        collector = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollector>();
        reyonList.Capacity = maxNumOfItemsHolding;
    }
    public void AddNewItem(Transform _itemToAdd)
    {
        
        _itemToAdd.DOJump(itemHolderTransform.position, 0.5f, 1, 0.0f).OnComplete(
        () =>
        {
            
            _itemToAdd.SetParent(itemHolderTransform, true);
            _itemToAdd.localPosition = Vector3.zero + new Vector3(0, 0, 0.75f * (reyonList.Count));
            _itemToAdd.localRotation = Quaternion.identity;
            reyonList.Add(_itemToAdd.gameObject);
            numOfItemsHolding++;

        }
        );


    }
}
