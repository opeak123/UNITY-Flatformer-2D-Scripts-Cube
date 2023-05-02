using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CUBE"))
        {
            Destroy(collision.gameObject);
        }
    }
}
