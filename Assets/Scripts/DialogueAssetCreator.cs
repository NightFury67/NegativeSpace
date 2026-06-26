using UnityEngine;

[System.Serializable]
public struct DialogueLine
{
    public string Speaker;
    [TextArea(2, 6)] public string lines;
}

[CreateAssetMenu(fileName = "DialogueData", menuName= "Dialogue/DialogueData")]
public class DialogueAssetCreator : ScriptableObject
{
    
    [SerializeField] private DialogueLine[] lines;
    public DialogueLine[] Lines => lines;
    
}
