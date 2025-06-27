using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{

    private float healthPoints = 100f;
    private bool isDead = false;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text healthText;


    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
        healthBar.maxValue = healthPoints;
        healthBar.value = healthPoints;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(float damage)
    {
        healthPoints = Mathf.Max(healthPoints - damage, 0);
        healthBar.value = healthPoints;
        DisplayHealth();
        if (healthPoints == 0)
        {
            Die();
        }
    }

    public void DisplayHealth() 
    {
        healthText.text = $"Health: {healthPoints}";
    }

    public bool IsDead()
        { return isDead; }

    public void Die()
    {
        if (isDead) return;
        isDead = true;
        gameOverText.gameObject.SetActive(true);
        GetComponentInChildren<Animator>().SetTrigger("Die");
    }
}
