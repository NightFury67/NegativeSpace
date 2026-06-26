using UnityEngine;
using UnityEngine.SceneManagement;

public class NegativeSpaceTrigger : MonoBehaviour
{
    [SerializeField] private float trigggerposition;
    [SerializeField] private bool leftrigger = true;
    private bool isTriggered = true;
    private Transform player;
    [SerializeField] private string Levelname;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SessionData.ReturningFromNegativeSpace==false && trigggerposition > SessionData.ReturnPosition.x)
        {
            isTriggered = false;
        }
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered == true || player == null)
        {
            return;
        }

        bool passed = leftrigger ? player.position.x >= trigggerposition : player.position.x < trigggerposition;

        if (passed==true)
        {
            SessionData.ReturningFromNegativeSpace = true;
            SessionData.ReturnPosition = player.position;
            SceneManager.LoadScene(Levelname);
        }

    }
}
