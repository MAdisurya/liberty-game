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
[RequireComponent(typeof(EMJCharacterStates.CharacterAnimState))]
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

    void Start()
    {
        if (m_CharacterType == CharacterType.AI)
        {
            // Register enemy into enemy manager
            EnemyManager.Instance.RegisterEnemy(this);
        }
    }

    public void Die()
    {
        // Set current state to DEAD
        if (m_CharacterStateMachine == null) { return; }

        m_CharacterStateMachine.SetState(EMJCharacterStates.CharacterStates.DEAD);

        // Deregister enemy from enemy manager
        EnemyManager.Instance.DeregisterEnemy(this);

        // Destroy this object
        Destroy(gameObject);

        if (EnemyManager.Instance.EnemyCount <= 0)
        {
            LevelManager.Instance.GoToNextScene();
        }

        if (m_CharacterType == CharacterType.PLAYER)
        {
            LevelManager.Instance.GoToScene("03_GameOver");
        }
    }
}
