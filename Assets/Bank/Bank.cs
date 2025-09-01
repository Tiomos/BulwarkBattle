using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Bank : MonoBehaviour
{
    
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }
    [SerializeField] TextMeshProUGUI goldText;

   void Awake()
   {
        currentBalance = startingBalance;
   }

   void Start()
    {
        GoldDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        GoldDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        GoldDisplay();

        if(currentBalance < 0)
        {
            //Lose the game;
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private void GoldDisplay()
    {
        goldText.text = "Gold: " + currentBalance;
    }
}
