using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Fruit
{
    public float duration = 8.0f;

    protected override void Eat(){
        FindObjectOfType<GameManager>().PowerPelletEaten(this);
    }
}
