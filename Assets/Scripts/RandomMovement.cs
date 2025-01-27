using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    public float speed = 20f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidbody2D.linearVelocity = Random.insideUnitCircle.normalized * speed;
    }

    void Update()
    {

    }
}
