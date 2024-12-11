using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected Rigidbody2D _rigid2D;

    protected virtual void Start()
    {
        _rigid2D = GetComponent<Rigidbody2D>();
    }

    public abstract void Move();

    public void StopImmediately()
    {
        _rigid2D.velocity = Vector3.zero;
        _rigid2D.AddForce(Vector3.zero);
    }
}
