using UnityEngine;
using UnityEngine.UI;
using System;

public class CharacterHealthUI : MonoBehaviour
{
    [SerializeField] CharacterHealthScript HealthScript;
    [SerializeField] private UnityEngine.UI.Text text;
    [SerializeField] private Slider bar;

    void OnEnable ()
    {
        HealthScript.OnHealthChanged += HealthChanged;
    }
    void OnDisable ()
    {
        HealthScript.OnHealthChanged -= HealthChanged;
        Debug.Log ("Unsubscribing UI");
    }

    void HealthChanged (int newHealth, int maxHealth)
    { 
        //Debug.Log("RUNNING");
        if (text != null)
        {
            text.text = $"{newHealth}" + "/" + $"{maxHealth}";
            bar.minValue = 0; bar.maxValue = maxHealth; bar.value = newHealth;
        }
        
    }
}
