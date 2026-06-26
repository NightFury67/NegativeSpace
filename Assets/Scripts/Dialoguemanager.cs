using System.Collections;

using TMPro;
using UnityEngine;


public class Dialoguemanager : MonoBehaviour
{
    public static Dialoguemanager instance;

    [SerializeField] private GameObject Dialoguepanel;
    [SerializeField] private TextMeshProUGUI speaker;
    [SerializeField] private TextMeshProUGUI dialogue;
    [SerializeField] private float TypeSpeed =0.06f;

    private bool isTyping = false;
    private bool DialogueActive = false;
    private DialogueLine[] currentline;
    private int LineIndex = 0;

    private float dialogueEndTime = 0f;

    void Awake()
    {
        instance= this;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueActive == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogue.text = currentline[LineIndex].lines;
                isTyping = false;
            }

            else
            {
                LineIndex++;
                if (LineIndex < currentline.Length)
                {
                    StartCoroutine(typeLine());
                }
                else
                {
                    endDialogue();
                }
            }
        }
    }


    public bool IsDialogueActive()
    {
        return DialogueActive || Time.time < dialogueEndTime + 0.1f;
    }

    public void startdialogue(DialogueAssetCreator data)
    {
        DialogueActive = true;
        currentline = data.Lines;
        LineIndex = 0;
        Dialoguepanel.SetActive(true);
        StartCoroutine(typeLine());
    }

    IEnumerator typeLine()
    {
        isTyping = true;
        speaker.text = currentline[LineIndex].Speaker;
        dialogue.text = "";
        foreach (char letter in currentline[LineIndex].lines)  
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(TypeSpeed);
        }
        isTyping = false;
    }


    void endDialogue()
    {
        DialogueActive = false;
        dialogueEndTime = Time.time;
        Dialoguepanel.SetActive(false);
        currentline = null;
        LineIndex = 0;
    }
}
