using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    TextMeshProUGUI killCounterTMP;
    [HideInInspector] public int killCount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateKillCounterUI()
    {
        killCounterTMP.text = killCount.ToString();
    }
}
