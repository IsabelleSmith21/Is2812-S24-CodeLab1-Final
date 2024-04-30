using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class WASD : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public PurchaseManager purchaseManager; // Reference to the PurchaseManager script
    public TMP_Text dayquilScoreText; // Text object to display Dayquil score
    public TMP_Text rubberDuckScoreText; // Text object to display RubberDuck score
    public TMP_Text destructionOrderText;


    private Queue<string> destructionOrder = new Queue<string>(); // Queue to track destruction order

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        movement.Normalize();
        rb.velocity = movement * moveSpeed;

        // Update the UI text with the current scores and destruction order
        UpdateScoreTexts();
    }

    void UpdateScoreTexts()
    {
        // Update Dayquil score text
        dayquilScoreText.text = "Dayquil Score: " + purchaseManager.dayquilScore.ToString();

        // Update RubberDuck score text
        rubberDuckScoreText.text = "Rubber Duck Score: " + purchaseManager.rubberDuckScore.ToString();

        // Update destruction order text
        string orderText = "Destruction Order: ";
        foreach (string obj in destructionOrder)
        {
            orderText += obj + " ";
        }
        destructionOrderText.text = orderText;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dayquil"))
        {
            Destroy(other.gameObject);
            purchaseManager.dayquilScore++; // Update dayquilScore in PurchaseManager
            Debug.Log("Dayquil Score: " + purchaseManager.dayquilScore);
            destructionOrder.Enqueue("Dayquil"); // Add "Dayquil" to destruction order
        }
        
        if (other.CompareTag("RubberDuck"))
        {
            Destroy(other.gameObject);
            purchaseManager.rubberDuckScore++; // Update rubberDuckScore in PurchaseManager
            Debug.Log("Rubber Duck Score: " + purchaseManager.rubberDuckScore);
            destructionOrder.Enqueue("RubberDuck"); // Add "RubberDuck" to destruction order
        }
        
        if (other.CompareTag("Exit"))
        {
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            foreach (GameObject wall in walls)
            {
                wall.SetActive(false);
            }
            
            foreach (GameObject dictObject in purchaseManager.dictionaryObjects)
            {
                dictObject.SetActive(true);
            }
            Destroy(other.gameObject);
        }
    }
}
