﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Base
{ 
    [SerializeField]
    private CharacterMovementModel MovementModel;
    [SerializeField]
    private CharacterMovementView MovementView;
    [SerializeField]
    private CharacterInteractionModel InteractionModel;
    [SerializeField]
    private CharacterInventoryModel InventoryModel;
	[SerializeField]
	private AttackableCharacter AttackableCharacter;
	[SerializeField]
	private CharacterAudio AudioCharacter;


    public static Character character;


    public static CharacterMovementModel m_MovementModel;
    public static CharacterMovementView m_MovementView;
    public static CharacterInteractionModel m_InteractionModel;
    public static CharacterInventoryModel m_InventoryModel;
	public static AttackableCharacter m_AttackableCharacter;
	public static CharacterAudio m_CharacterAudio;

    void Awake()
    {
        character = this;

        m_MovementModel = MovementModel;
        m_InteractionModel = InteractionModel;
        m_MovementView = MovementView;
        m_InventoryModel = InventoryModel;
		m_AttackableCharacter = AttackableCharacter;
		m_CharacterAudio = AudioCharacter;
    }
}
