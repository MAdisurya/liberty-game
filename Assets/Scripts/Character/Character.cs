using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public enum CharacterType
{
    PLAYER,
    AI
}

[RequireComponent(typeof(EMJCharacterStates.CharacterStateMachine))]
[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterAim))]
[RequireComponent(typeof(CharacterDash))]
[RequireComponent(typeof(CharacterAttack))]
[RequireComponent(typeof(DamageOnHit))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody))]

public class Character : MonoBehaviour {

    /// <summary>
    /// Character type.
    /// </summary>
    [Tooltip("Character type.")]
    public CharacterType m_CharacterType = CharacterType.AI;

    /// <summary>
    /// The Characters state machine.
    /// </summary>
    [Tooltip("The characters state machine.")]
    public EMJCharacterStates.CharacterStateMachine m_CharacterStateMachine;

    void Awake()
    {
        Assert.IsNotNull(m_CharacterStateMachine);
    }

    public void Die()
    {
        // Set current state to DEAD
        if (m_CharacterStateMachine == null) { return; }

        m_CharacterStateMachine.SetState(EMJCharacterStates.CharacterStates.DEAD);

        // Destroy this object
        Destroy(gameObject);
    }
}
