using UnityEngine;
using TMPro;

public class TextDisplayCollider : MonoBehaviour
{
    public TextDisplayObject textDisplayObject;
    public TMP_Text displayText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            displayText.text = textDisplayObject.displayText;
        }
    }
}

