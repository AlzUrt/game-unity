using UnityEngine;

public class Rupee : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
        // if player collides with rupee, destroy rupee

    }
}
