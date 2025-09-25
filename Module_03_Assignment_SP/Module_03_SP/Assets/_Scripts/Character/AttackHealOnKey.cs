using UnityEngine;

public class AttackHealOnKey : MonoBehaviour
{

    [SerializeField] private CharacterHealthScript target;
    [SerializeField] private int damageAmount = -10;
    [SerializeField] private int healAmount = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            target?.ChangeHealth(damageAmount);
            Debug.Log("Fire");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            target?.ChangeHealth(healAmount);
            Debug.Log("Heal");
        }
    }
}
