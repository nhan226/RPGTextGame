using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECharacterType
{
    Warrior,
    Magical,
    Ranger
}

public struct FStat
{
    public float health;
    public float damage;

    public FStat(float health, float damage)
    {
        this.health = health;
        this.damage = damage;
    }
}

public class BaseCharacter : MonoBehaviour
{
    [SerializeField]
    private ECharacterType characterType;

    private FStat stat;
    public FStat Stat { get; set; }

    private void Start()
    {
        switch (characterType)
        {
            case ECharacterType.Warrior:
                stat = new FStat(50f, 20f);        
                break;
            case ECharacterType.Magical:
                stat = new FStat(30f, 10f);        
                break;
            case ECharacterType.Ranger:
                stat = new FStat(20f, 50f);        
                break;
        }
        Stat = stat;
    }

    protected virtual void Attack(BaseCharacter target, float damage)
    {
    }
}
