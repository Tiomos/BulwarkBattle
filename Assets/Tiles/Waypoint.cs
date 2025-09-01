using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    Bank m_bank;

    void Start()
    {
        m_bank = FindObjectOfType<Bank>();
    }
    
    void  OnMouseDown() 
    {
        if (isPlaceable && m_bank.CurrentBalance >= 75)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = false;
        }

    }
}
