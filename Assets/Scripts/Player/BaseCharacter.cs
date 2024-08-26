using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECharacterType
{
    Warrior,
    Magical,
    Ranger
}

public class BaseCharacter : MonoBehaviour
{
    [SerializeField]
    private ECharacterType characterType;

    [Header("Stat")]
    protected float health;
    protected float damage;

    private void Start()
    {
        switch (characterType)
        {
            case ECharacterType.Warrior:
                health = 50f;
                damage = 30f;
                break;
            case ECharacterType.Magical:
                health = 30f;
                damage = 10f;
                break;
            case ECharacterType.Ranger:
                health = 20f;
                damage = 50f;
                break;
        }
    }

    protected virtual void TakenDmg(float damage)
    {
        health -= damage;
    }
}
