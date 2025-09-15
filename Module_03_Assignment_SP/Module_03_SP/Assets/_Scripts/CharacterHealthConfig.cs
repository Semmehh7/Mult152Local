using UnityEngine;

[CreateAssetMenu(fileName = "CharacterHealthConfig", menuName = "Scriptable Objects/CharacterHealthConfig")]
public class CharacterHealthConfig : ScriptableObject
{
    public int maxHealth = 100;
    public int startHealth = 100;
}
