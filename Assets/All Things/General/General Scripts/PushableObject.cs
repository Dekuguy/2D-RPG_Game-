using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{

    [SerializeField]
    private float PushVelocity = 1;
    [SerializeField]
    private float Pushtime = 1;
    [SerializeField]
    private float PushTimeOut = 1;

    private Vector2 m_PushDirection;
    private float m_PushTime;

    private Rigidbody2D m_body;

    void Awake()
    {
        m_body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        m_PushTime = -1f;
    }
    void Update()
    {
        m_PushTime -= Time.deltaTime;
    }

    public bool isBeingPushed()
    {
        return m_PushTime >= 0;
    }
    public bool isBeingPushedTimeOut()
    {
        return m_PushTime >= DataBase.AllVariables.baseVariables.base_PushTimeout * PushTimeOut;
    }

    public Vector2 getPushDirection()
    {
        return m_PushDirection;
    }

    public void PushCharacterRel(Vector2 pushDirection, float relativetime)
    {
        m_PushTime = relativetime * DataBase.AllVariables.baseVariables.base_PushTime * Pushtime;
        m_PushDirection = pushDirection * PushVelocity * DataBase.AllVariables.baseVariables.base_PushVelocity;
		Debug.Log("Test");
    }
    public void PushCharacterAbs(Vector2 pushDirection, float absolutetime)
    {
        m_PushTime = absolutetime;
        m_PushDirection = pushDirection * PushVelocity * DataBase.AllVariables.baseVariables.base_PushVelocity;
    }

    void FixedUpdate()
    {
        if (m_PushTime >= 0)
        {
            m_body.velocity = m_PushDirection;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_PushTime >= 0)
        {
            m_PushTime = 0;
        }
    }
}
