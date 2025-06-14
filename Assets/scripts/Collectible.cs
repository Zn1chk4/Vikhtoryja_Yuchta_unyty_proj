using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Inventory playerInventory = collision.GetComponent<Inventory>();
        if (playerInventory != null)
        {
            playerInventory.AddMushroom();
        }

        Destroy(gameObject);
    }
}