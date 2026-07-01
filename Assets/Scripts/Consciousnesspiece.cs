using UnityEngine;

public class Consciousnesspiece : MonoBehaviour
{
    private bool iscollected = false;

    [SerializeField] private float RotationSpeed = 0f;

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

    private void Update()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * RotationSpeed);
    }


}
