using DarkTreeFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject controller;
    public GameObject Sold;
    public GameObject Sold1;
    public GameObject Sold2;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject Ammo;
    public GameObject Ammo1;
    public GameObject Ammo2;
    public GameObject Ammo3;
     void Start()
    {
        Ammo1.GetComponent<Button>().interactable = false;
        Ammo2.GetComponent<Button>().interactable = false;
        Ammo3.GetComponent<Button>().interactable = false;

    }
    // Update is called once per frame
    void Update()
    {
        if(controller.GetComponent<FPSController>().IsAR15)
        {
            Sold.SetActive(true);
            Sold1.SetActive(false);
            Sold2.SetActive(false);
            button1.GetComponent<Button>().interactable = false;
            button2.GetComponent<Button>().interactable = true;
            button3.GetComponent<Button>().interactable = true;

            Ammo.GetComponent<Button>().interactable = false;
            Ammo1.GetComponent<Button>().interactable = true;
            Ammo2.GetComponent<Button>().interactable = false;
            Ammo3.GetComponent<Button>().interactable = false;
        }
        if (controller.GetComponent<FPSController>().IsScar)
        {
            Sold.SetActive(false);
            Sold1.SetActive(true);
            Sold2.SetActive(false);
            button1.GetComponent<Button>().interactable = true;
            button2.GetComponent<Button>().interactable = false;
            button3.GetComponent<Button>().interactable = true;

            Ammo.GetComponent<Button>().interactable = false;
            Ammo1.GetComponent<Button>().interactable = false;
            Ammo2.GetComponent<Button>().interactable = true;
            Ammo3.GetComponent<Button>().interactable = false;
        }
        if (controller.GetComponent<FPSController>().IsSniper)
        {
            Sold.SetActive(false);
            Sold1.SetActive(false);
            Sold2.SetActive(true);
            button1.GetComponent<Button>().interactable = true;
            button2.GetComponent<Button>().interactable = true;
            button3.GetComponent<Button>().interactable = false;

            Ammo.GetComponent<Button>().interactable = false;
            Ammo1.GetComponent<Button>().interactable = false;
            Ammo2.GetComponent<Button>().interactable = false;
            Ammo3.GetComponent<Button>().interactable = true;
        }
    }
}
