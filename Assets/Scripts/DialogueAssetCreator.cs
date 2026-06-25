using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName= "Dialogue/DialogueData")]
public class DialogueAssetCreator : ScriptableObject
{
    [SerializeField] private string Speaker;
    [SerializeField][TextArea(2, 6)] private string[] lines;

    public string Speakername => Speaker;
    public string[] Lines => lines;
    
    
    
 
}
