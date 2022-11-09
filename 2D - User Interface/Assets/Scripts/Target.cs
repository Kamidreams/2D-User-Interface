using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int PointValue = 1;

    public float MinSpeed = 12;

    public float MaxSpeed = 15;

    public float MaxTorque = 10;
    
    private Rigidbody2D _targetRB;

    // Start is called before the first frame update
    void Start()
    {
        _targetRB = GetComponent<Rigidbody2D>();
        // _targetRB.AddForce(Vector2.up * MinSpeed, ForceMode2D.Impulse);
        _targetRB.AddForce(Vector2.up * RandomizeForce(), ForceMode2D.Impulse); //impulse starts right away
        //_targetRB.AddTorque(MaxTorque);
        _targetRB.AddTorque(RandomizeTorque());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float RandomizeForce()
    {
        return Random.Range(MinSpeed, MaxSpeed);
    }

    private float RandomizeTorque()
    {
        return Random.Range(-MaxTorque, MaxTorque);
    }
}
