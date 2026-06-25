using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueAssetCreator data;
    [SerializeField] private float trigggerposition;
    [SerializeField] private bool leftrigger = true;
    private bool isTriggered = false;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered == true || player == null)
        {
            return;
        }

        bool passed = leftrigger ? player.position.x>=trigggerposition : player.position.x<trigggerposition;

        if (passed) {
            isTriggered = true;
            Dialoguemanager.instance.startdialogue(data);
        }
    }
}
