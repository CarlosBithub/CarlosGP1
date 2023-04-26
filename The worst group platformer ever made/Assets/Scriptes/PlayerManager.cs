using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //declare and set a variable for health
    public int maxHealth = 15;
    public int currentHealth = 1;
    PlayerMovement playerMovement;
    public int coinCount;

    private void Awake()
    {
        currentHealth = 5;
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void Update()
    {
        if (currentHealth <= 0)
        {
            PauseGame();
        }
    }

    public void healthPotion()
    {
        currentHealth += 5;
    }

    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
            {
            case "Coins":
        coinCount++;
            return true;
            case "Health+":
                healthPotion();
                return true;
            default:
            return false;
        }
    }
    //pause/stop our game when we need to
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    //create a function that will damage our player.
    public void TakeDamage()
    {
        currentHealth -= 1;
    }
}
