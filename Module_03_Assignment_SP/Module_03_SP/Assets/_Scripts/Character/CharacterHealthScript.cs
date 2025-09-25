using UnityEngine;
using System;


public class CharacterHealthScript : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int startHealth = 100;
    [SerializeField] private GameObject self;
    [SerializeField] private CharacterHealthConfig healthConfig;

    public event Action<int, int> OnHealthChanged;

    private int currentHealth = 100;

        private void Awake()
        {
            maxHealth  = healthConfig != null ? healthConfig.maxHealth : maxHealth;
            startHealth = healthConfig != null ? healthConfig.startHealth : startHealth;
            currentHealth = startHealth;
            OnHealthChanged?.Invoke(currentHealth, maxHealth); //Sets initial text.
        }

    public void ChangeHealth (int amount)
        {
            if (amount != 0 && currentHealth > 0)
                {
                    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
                if (amount > 0)
                    {
                        OnHealthChanged?.Invoke(currentHealth, maxHealth);
                        Debug.Log("Healed");
                    }
                else
                    {
                        Debug.Log("DamageTaken");
                        if (currentHealth + amount <= 0)
                        {
                            OnHealthChanged?.Invoke(currentHealth, maxHealth);
                            OnDeath();
                        }
                        OnHealthChanged?.Invoke(currentHealth, maxHealth);
                    }
                }
        }
    private void OnDeath ()
        {
            Debug.Log ("I Died!");
            Destroy (self);
        }

}

