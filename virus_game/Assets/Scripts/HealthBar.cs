using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthImage;
    float maxHealth = 100;

    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        healthImage = GetComponent<Image>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = health / maxHealth;
        Debug.Log("healthBar" + health/maxHealth);

    }
}
