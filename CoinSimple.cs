using UnityEngine;

public class CoinSimple : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(value);
            Destroy(gameObject);
        }
    }
}