using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    Slider slider;

    public void Start()
    {
        slider = transform.GetComponent<Slider>();
    }

    public void SetMaxHealth(int health)
    {
        slider = transform.GetComponent<Slider>();
        slider.maxValue = health;
        slider.value = health;
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
