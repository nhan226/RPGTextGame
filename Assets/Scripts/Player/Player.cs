using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseCharacter
{
    public override void NormalAttack()
    {
        Attack(10);
    }

    public override void Skill01Attack()
    {
        Attack(20);
    }

    public override void Skill02Attack()
    {
        Attack(30);
    }

    public override void Skill03Attack()
    {
        Attack(40);
    }

    private void Attack(float dmg)
    {
        if (TurnBaseManager.Instance.CurrentTurn == Turn.PlayerTurn)
        {
            TurnBaseManager.Instance.Enemy.TakenDmg(dmg);

            TurnBaseManager.Instance.CurrentTurn = Turn.EnemyTurn;
        }
    }
}
