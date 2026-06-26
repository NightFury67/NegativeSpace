using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class CounsciousnessCounter : MonoBehaviour
{
    public static CounsciousnessCounter Instance;
    [SerializeField] private TMP_Text Counter;
    private int count = 0;
    [SerializeField] private int Target;

    private void Awake()
    {
        Instance = this;
        UpdateUI();
    }
    
    public void IncreaseCounter(int amount=1)
    {
        count += amount;
        if(count == Target)
        {
            SceneManager.LoadScene("Main-Cave");
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        Counter.text = count.ToString();
    }
}
