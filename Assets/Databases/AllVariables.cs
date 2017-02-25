using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllVariables : ScriptableObject
{
    public Variables baseVariables;
}

[System.Serializable]
public class Variables
{
    //----------------------------------------------------------------------------------------------------------------------
    //-----------------------------------               Inspector             ----------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------

    //Base
    [Header("Base Variables")]
    [SerializeField]
    private float Base_Speed = 5;
    [SerializeField]
    private float Base_PushVelocity = 15;
    [SerializeField]
    private float Base_PushTime = 0.1f;
    [SerializeField]
    private float Base_PushTimeout = 0.2f;

    //Character
    [Header("Character Variables")]
    [SerializeField]
    private float Character_Speed = 1;

    //Enemys
    [Header("Enemys Variables")]
    [SerializeField]
    private float Enemy_Speed = 1;

    //----------------------------------------------------------------------------------------------------------------------
    //-----------------------------------               Scripts             ------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------

    //Base Variables
    [HideInInspector]
    public float base_Speed { get { return Base_Speed; } set { Base_Speed = value; } }
    [HideInInspector]
    public float base_PushVelocity { get { return Base_PushVelocity; } set { Base_PushVelocity = value; } }
    [HideInInspector]
    public float base_PushTime { get { return Base_PushTime; } set { Base_PushTime = value; } }
    [HideInInspector]
    public float base_PushTimeout { get { return -Base_PushTimeout; } set { Base_PushTimeout = value; } }

    //Character Variables
    [HideInInspector]
    public float character_Speed { get { return Character_Speed * Base_Speed; } set { Character_Speed = value; } }

    //EnemyVariables
    [HideInInspector]
    public float enemy_Speed { get { return Enemy_Speed * Base_Speed; }set { Enemy_Speed = value; } }
}