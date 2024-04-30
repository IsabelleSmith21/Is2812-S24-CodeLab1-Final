using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class PurchaseManager : MonoBehaviour
{
    public TMP_Text dayquilScoreText;
    public TMP_Text rubberDuckScoreText;
    public TMP_Text jsonScoreText;
    public TMP_Text messageText;

    public int dayquilScore = 0;
    public int rubberDuckScore = 0;
    public int jsonScore = 0;

    public GameObject[] dictionaryObjects; // Define dictionaryObjects here

    private Dictionary<string, int> itemCost = new Dictionary<string, int>()
    {
        { "JsonFile", 3 }
    };

    void Start()
    {
        UpdateScoreTexts();
    }

    void UpdateScoreTexts()
    {
        dayquilScoreText.text = "Dayquil Score: " + dayquilScore.ToString();
        rubberDuckScoreText.text = "Rubber Duck Score: " + rubberDuckScore.ToString();
        jsonScoreText.text = "Items for JSON: " + jsonScore.ToString();
    }

    public void PurchaseJSONWithRubberDuck()
    {
        PurchaseJSONWithScore("RubberDuck");
    }

    public void PurchaseJSONWithDayquil()
    {
        PurchaseJSONWithScore("Dayquil");
    }

    private void PurchaseJSONWithScore(string scoreType)
    {
        if (itemCost.ContainsKey("JsonFile"))
        {
            int cost = itemCost["JsonFile"];
            if (scoreType == "RubberDuck" && rubberDuckScore >= cost)
            {
                rubberDuckScore -= cost;
                jsonScore++;
                UpdateScoreTexts();
                messageText.text = "Purchased JSON effigy with RubberDuck!";
            }
            else if (scoreType == "Dayquil" && dayquilScore >= cost)
            {
                dayquilScore -= cost;
                jsonScore++;
                UpdateScoreTexts();
                messageText.text = "Purchased gift for JSON with Dayquil!";
            }
            else
            {
                messageText.text = "Go visit JSON!";
            }
        }
        else
        {
            messageText.text = "JSONFile cost not defined!";
        }
    }
}
