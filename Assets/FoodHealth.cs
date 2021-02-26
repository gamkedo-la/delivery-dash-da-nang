using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodHealth : MonoBehaviour
{
    public Animator healthBar;
    public Slider healthOfFood;
    int totalHealth = 100;
    public static float currentHealth = 100;

    // Start is called before the first frame update
    void OnEnable()
    {
        healthBar.SetBool("isOpen", true);
        currentHealth = 100;
        totalHealth = 100;
    }

    // Update is called once per frame
    void OnDisable()
    {
        healthBar.SetBool("isOpen", false);
    }

    private void Update()
    {
        healthOfFood.value = currentHealth / totalHealth;
    }
}
