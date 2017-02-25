using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovementView : MonoBehaviour {

    [SerializeField]
    protected Animator _animator;

    protected abstract void UpdateDirection();
}
