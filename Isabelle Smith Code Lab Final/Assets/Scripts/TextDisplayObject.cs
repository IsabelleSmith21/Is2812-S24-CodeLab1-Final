using UnityEngine;

[CreateAssetMenu(fileName = "NewTextDisplay", menuName = "Text Display")]
public class TextDisplayObject : ScriptableObject
{
    [TextArea(3, 10)]
    public string displayText;
}

