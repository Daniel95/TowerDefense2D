﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    [SerializeField]
    protected float startHealth;

    protected float health;

    protected float startScale;

    protected Transform healthbar;

    private SpriteRenderer healthbarSprite;

    // Use this for initialization
    virtual protected void Awake()
    {
        healthbar = transform.Find("Healthbar");
        healthbarSprite = healthbar.GetComponent<SpriteRenderer>();
        startScale = healthbar.localScale.x;
    }

    public virtual void TakeDamage(float dmg) {
        health -= dmg;
        if (health > 0)
        {
            healthbar.localScale = new Vector3(health * startScale / startHealth, 1, 1);

            if (health < startHealth / 3) healthbarSprite.color = Color.red;
            else if (health < startHealth / 1.5f) healthbarSprite.color = Color.yellow;
        }
        else
        {
            //when buildings died and get rebuild, they need to start with a green color.
            healthbarSprite.color = Color.green;
            //set the scale to zero so it doesnt show the healthbar scale below zero.
            healthbar.localScale = new Vector3(0, 1, 1);
            Dead();
        }
    }

    public void RestoreHealth(float heal) {
        if (health < startHealth)
        {
            health += heal;
        }
        else healthbarSprite.color = Color.green;
        if (health < startHealth / 3) healthbarSprite.color = Color.red;
        else if(health < startHealth / 1.5f) healthbarSprite.color = Color.yellow;
    }

    protected virtual void Dead() {

    }
}
