using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    PLAYER,
    AI
}

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterAim))]
[RequireComponent(typeof(CharacterDash))]
[RequireComponent(typeof(CharacterAttack))]
[RequireComponent(typeof(Rigidbody))]

public class Character : MonoBehaviour {
	
    public CharacterType m_CharacterType = CharacterType.AI;
}
