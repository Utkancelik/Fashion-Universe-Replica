using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe : MonoBehaviour
{
    /*
    [SerializeField] private GameObject urunPrefab;
    private void OnTriggerEnter(Collider other)
    {
        // �anta ta��y�c�ysa
        if (other.tag == "Carriers")
        {
            GameObject Carrier = other.gameObject;
            int carrierUstundekiUrunSayisi = 0;
            int carrierUstundekiMaxUrunSayisi = 3;
    
            // ona �r�n ver
            // onda ne kadar �r�n oldu�unu tespit et ve kapasitesi ile olan fark kadar �r�n ver (saniyede 1 �ekilde)
            
            for (int i = 0; i < Carrier.transform.childCount; i++)
            {
                if (Carrier.transform.GetChild(i).tag == "�r�n")
                {
                    carrierUstundekiUrunSayisi++;
                }
            }

            if (carrierUstundekiUrunSayisi == carrierUstundekiMaxUrunSayisi)
            {
                return;
            }
            else
            {
                int eklenecekUrunSayisi = carrierUstundekiMaxUrunSayisi - carrierUstundekiUrunSayisi;
                // eklenecek �r�n say�s� kadar �r�n ekle,
                // eklenecek �r�n say�s� kadar �r�n� olu�tur.
                for (int i = 0; i < eklenecekUrunSayisi; i++)
                {
                    GameObject urun =  Instantiate(urunPrefab);
                    urun.transform.parent = null;
                    urun.transform.position = new Vector3(0, 0, 0);
                    urun.transform.parent = Carrier.transform;
                }

            }
            
        }
    }
    */

    [SerializeField] private GameObject PursePrefab;
    [SerializeField] private GameObject WardrobeCanvas;
    private void Start()
    {
        WardrobeCanvas.SetActive(false);
    }

    
    private void OnTriggerStay(Collider other)
    {
        // if collides with player
        if (other.CompareTag("Player"))
        {
            
            // get reference to PlayerCollector script to use AddItem function
            PlayerCollector plyrCol;

            if (other.TryGetComponent(out plyrCol))
            {
                //if number of items holding less than 3
                if (plyrCol.purseList.Count < plyrCol.purseList.Capacity)
                {
                    // then activate the UI elements
                    plyrCol.circleSlider.gameObject.SetActive(true);
                    plyrCol.circleSlider.value += Time.deltaTime;
                    if (plyrCol.circleSlider.value >= plyrCol.circleSlider.maxValue)
                    {
                        plyrCol.circleSlider.value = 0;
                        GameObject purse = Instantiate(PursePrefab, new Vector3(-5.9f, 1.573f, 7.289f), Quaternion.identity);
                        plyrCol.AddNewItem(purse.transform);
                    }
                }
                // if number of items holding is equal to 3
                else
                {
                    //then deactivate the slider
                    plyrCol.circleSlider.gameObject.SetActive(false);
                }

                // wardrobe canvas is for checking how many items we hold
                WardrobeCanvas.SetActive(true);
                WardrobeCanvas.transform.GetChild(0).GetComponent<Text>().text = plyrCol.purseList.Count + "/" + plyrCol.purseList.Capacity.ToString();


            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WardrobeCanvas.SetActive(false);
            PlayerCollector plyrScript;
            plyrScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollector>();
            plyrScript.circleSlider.value = 0;
            plyrScript.circleSlider.gameObject.SetActive(false);
        }
        
    }




}
