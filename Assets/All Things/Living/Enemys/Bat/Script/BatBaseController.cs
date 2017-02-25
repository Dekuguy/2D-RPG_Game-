using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBaseController : BaseControl {

    Bat scripts;

    private void Awake()
    {
        scripts = GetComponent<Bat>();
    }

    protected override void SetDirection(Vector2 direction) {
        scripts.MovementModel.SetDirection(direction);
    }
}
