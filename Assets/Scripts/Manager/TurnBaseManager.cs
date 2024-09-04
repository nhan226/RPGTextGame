using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn
{
    PlayerTurn,
    EnemyTurn
}

public class TurnBaseManager : Singleton<TurnBaseManager>
{
    private Turn currentTurn = Turn.PlayerTurn;
    private Player player;
    private Enemy enemy;

    public Turn CurrentTurn { get; set; }
    public Player Player { get; set; }
    public Enemy Enemy { get; set; }

    private void Start()
    {
        CurrentTurn = currentTurn;
        Player = player;
        Enemy = enemy;
    }
}
