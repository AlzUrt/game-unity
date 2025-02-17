using UnityEngine;
using System;

public class Rupee : MonoBehaviour
{
    public event Action<Rupee> OnRupeeCollected;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnRupeeCollected?.Invoke(this);
            Destroy(gameObject);
        }

    }
}
