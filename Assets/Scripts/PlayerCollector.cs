using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerCollector : MonoBehaviour
{
    /*
    public GameObject pursePrefab;

    public Transform armPos;


    [SerializeField] private Slider circleSlider;
    [SerializeField] private GameObject playerCanvas;
    [SerializeField] private GameObject wardrobeCanvas;


    private bool canITakeMore = true;



    public List<GameObject> purseList = new List<GameObject>();
    public Transform[] pursePositions = new Transform[3];

    /*
     * çantalarý alma bölgesine girdiðimizde geri sayým baþlasýn
     * 1 saniyelik geri sayým bittiðinde bir tane çanta yaratýp kolumuza ýþýnlayalým
     * çanta oluþturulup kolumuza geldiðinde geri sayým tekrar baþlasýn
     * her 1 saniyede bir çanta yaratýp kolumuza ýþýnlayalým
     * kolumuzun kapasitesi 3 
     * 3 çanta yaratýnca daha fazla geri sayým ve çanta oluþturma olmasýn
     
    
    private void Awake()
    {
        wardrobeCanvas.active = false;
        playerCanvas.active = false;
        purseList.Clear();
        purseList.Capacity = 3;

    }
    private void OnTriggerStay(Collider other)
    {
        // if I am in front of the wardrobe an I have capacity to take more purse
        if (other.tag == "pursePoint" && (purseList.Count < purseList.Capacity))
        {

            // then I can take more
            canITakeMore = true;
            playerCanvas.active = true;
            circleSlider.value += Time.deltaTime;
            if (circleSlider.value >= circleSlider.maxValue && canITakeMore)
            {
                wardrobeCanvas.active = true;
                wardrobeCanvas.transform.GetChild(0).GetComponent<Text>().text = (purseList.Count + 1).ToString() + "/" + purseList.Capacity.ToString();
                canITakeMore = false;
                purseList.Add(Instantiate(pursePrefab, transform));
                circleSlider.value = 0;
                for (int i = 0; i < purseList.Count; i++)
                {
                    purseList[i].transform.position = pursePositions[i].position;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "pursePoint")
        {
            wardrobeCanvas.active = false;
            wardrobeCanvas.transform.GetChild(0).GetComponent<Text>().text = "";
            playerCanvas.active = false;
        }
    }
    */
    public List<GameObject> purseList = new List<GameObject>();
    [SerializeField] private Transform itemHolderTransform;

    public Slider circleSlider;
    public int numOfItemsHolding = 0;
    public int maxNumOfItemsHolding = 3;
    private void Start()
    {
        circleSlider.gameObject.SetActive(false);
        purseList.Capacity = maxNumOfItemsHolding;

    }

    private void Update()
    {
        
    }

    public void AddNewItem(Transform _itemToAdd)
    {

        _itemToAdd.DOJump(itemHolderTransform.position, 0.5f, 1, 0.5f).OnComplete(
        () =>
        {
            
            _itemToAdd.SetParent(itemHolderTransform, true);
            _itemToAdd.localPosition = Vector3.zero + new Vector3(purseList.Count * 0.15f, 0, 0);
            purseList.Add(_itemToAdd.gameObject);
            //numOfItemsHolding++;
        }
        );



    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Reyon") && purseList.Count >0 )
        {

            // get reference to PlayerCollector script to use AddItem function
            Reyon reyonScript;
            
            if (other.TryGetComponent(out reyonScript) && (reyonScript.reyonList.Count < reyonScript.reyonList.Capacity))
            {
                
                //if number of items holding less than 3
                if (reyonScript.reyonList.Count < reyonScript.reyonList.Capacity)
                {
                    
                    // then activate the UI elements
                    for (int i = 0; i < purseList.Count; i++)
                    {
                        reyonScript.AddNewItem(purseList[i].transform);
                        purseList.Remove(purseList[i]);
                     
                    }
                    

                }
                // if number of items holding is equal to 3
                

                // wardrobe canvas is for checking how many items we hold
                //transform.GetChild(0).gameObject.SetActive(true);
                //transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = reyonScript.numOfItemsHolding + "/" + 3.ToString();


            }

        }
    }


    





}
