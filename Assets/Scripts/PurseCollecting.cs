using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurseCollecting : MonoBehaviour
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
     * �antalar� alma b�lgesine girdi�imizde geri say�m ba�las�n
     * 1 saniyelik geri say�m bitti�inde bir tane �anta yarat�p kolumuza ���nlayal�m
     * �anta olu�turulup kolumuza geldi�inde geri say�m tekrar ba�las�n
     * her 1 saniyede bir �anta yarat�p kolumuza ���nlayal�m
     * kolumuzun kapasitesi 3 
     * 3 �anta yarat�nca daha fazla geri say�m ve �anta olu�turma olmas�n
     
    
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
                wardrobeCanvas.transform.GetChild(0).GetComponent<Text>().text = (purseList.Count+1).ToString() + "/" + purseList.Capacity.ToString();
                canITakeMore = false;
                purseList.Add(Instantiate(pursePrefab,transform));
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
    


}
