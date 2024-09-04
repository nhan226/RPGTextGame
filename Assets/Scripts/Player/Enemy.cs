using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter
{
    private void Update()
    {
        if (TurnBaseManager.Instance.CurrentTurn == Turn.EnemyTurn)
        {
            switch (Random.Range(0, 3)) 
            {
                case 0:
                    NormalAttack();
                    break;
                case 1:
                    Skill01Attack();
                    break;
                case 2:
                    Skill02Attack();
                    break;
                case 3:
                    Skill03Attack();
                    break;
            }
        }
    }

    public override void NormalAttack()
    {
        TurnBaseManager.Instance.Player.TakenDmg(10);
    }

    public override void Skill01Attack()
    {
        TurnBaseManager.Instance.Player.TakenDmg(20);
    }

    public override void Skill02Attack()
    {
        TurnBaseManager.Instance.Player.TakenDmg(30);
    }

    public override void Skill03Attack()
    {
        TurnBaseManager.Instance.Player.TakenDmg(40);
    }
}
