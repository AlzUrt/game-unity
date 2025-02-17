using UnityEngine;
using System;

public class Rupee : MonoBehaviour
{
    public event Action<Rupee> OnRupeeCollected;

    private RupeeData _data;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public RupeeData Data
    {
        get => _data;
        set
        {
            _data = value;
            _spriteRenderer.color = _data.color;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnRupeeCollected?.Invoke(this);
            Destroy(gameObject);
        }

    }
}
