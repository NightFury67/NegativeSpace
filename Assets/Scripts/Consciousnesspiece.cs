using UnityEngine;

public class Consciousnesspiece : MonoBehaviour
{
    private bool iscollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (iscollected == true)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            iscollected = true;
            CounsciousnessCounter.Instance.IncreaseCounter();
            gameObject.SetActive(false);
        }
    }
   

}
