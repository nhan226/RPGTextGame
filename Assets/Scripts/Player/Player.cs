using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseCharacter
{
    private void Update()
    {
        // FOR DEBUGING
        if (Input.GetKeyDown(KeyCode.N))
        {
            TakenDmg(10f);
        }
    }
}
