using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodHealth : MonoBehaviour
{
    public Animator healthBar;
    public Slider healthOfFood;
    int totalHealth = 100;
    public static float currentHealth1 = 100;
    public static float currentHealth2 = 100;
    public static float currentHealth3 = 100;
    public static float currentHealth4 = 100;

    public bool player1, player2, player3, player4;

    // Start is called before the first frame update
    void OnEnable()
    {
        healthBar.SetBool("isOpen", true);
        if (player1)
        {
            currentHealth1 = 100;
            totalHealth = 100;
        }
        if (player2)
        {
            currentHealth2 = 100;
            totalHealth = 100;
        }
        if (player3)
        {
            currentHealth3 = 100;
            totalHealth = 100;
        }
        if (player4)
        {
            currentHealth4 = 100;
            totalHealth = 100;
        }

    }

    // Update is called once per frame
    void OnDisable()
    {
        healthBar.SetBool("isOpen", false);
    }

    private void Update()
    {
        if (player1)
        {
            healthOfFood.value = currentHealth1 / totalHealth;
        }
        if (player2)
        {
            healthOfFood.value = currentHealth2 / totalHealth;
        }
        if (player3)
        {
            healthOfFood.value = currentHealth3 / totalHealth;
        }
        if (player4)
        {
            healthOfFood.value = currentHealth4 / totalHealth;
        }
    }
}
