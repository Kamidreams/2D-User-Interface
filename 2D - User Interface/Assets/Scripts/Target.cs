using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int PointValue = 1;

    public float MinSpeed = 10;

    public float MaxSpeed = 20;

    public float MaxTorque = 10;
    
    private Rigidbody2D _targetRB;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _targetRB = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

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

    private void OnMouseDown() 
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        if(!other.gameObject.CompareTag("Bad")) // ! = opposite of "Bad" tag
        {
            //Debug.Log("Game Over");
            _gameManager.IsGameActive = false;
        }
    }
}
