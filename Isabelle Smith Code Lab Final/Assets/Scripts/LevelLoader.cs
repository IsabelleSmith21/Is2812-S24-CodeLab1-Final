using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Define the single instance of LevelLoader
    private static LevelLoader _instance;

    // Property to access the instance from other scripts
    public static LevelLoader Instance
    {
        get { return _instance; }
    }

    int currentLevel = 0;
    GameObject level;
    string FILE_PATH;

    // Ensure only one instance is created
    private void Awake()
    {
        // If an instance already exists, destroy this instance
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        // Set the instance to this object
        _instance = this;
        // Ensure this object persists between scenes
        DontDestroyOnLoad(gameObject);

        // Initialize other variables
        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        // Your existing code for loading levels goes here
        Destroy(level);
        level = new GameObject("Level Objects");

        //Get the lines from the file
        string[] lines = File.ReadAllLines(
            FILE_PATH.Replace("Num", currentLevel + ""));

        for (int yLevelPos = 0; yLevelPos < lines.Length; yLevelPos++)
        {
            Debug.Log(lines[yLevelPos]);

            //Get a single line
            string line = lines[yLevelPos].ToUpper();

            //Turn line into a char array
            char[] characters = line.ToCharArray();

            for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
            {
                //get the first character
                char c = characters[xLevelPos];
                Debug.Log(c);

                GameObject newObject = null;

                switch (c)
                {
                    case 'W': //if the character is a 'W'
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Wall"));
                        break;
                    case 'P': //if the character is a 'P'
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                        //align the ca
                        break;
                    case 'R': //if the character is a 'W'
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/RubberDuck"));
                        break;
                    case 'E': //if the character is a 'W'
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Exit"));
                        break;
                    case 'G':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Goal"));
                        break;
                    default:
                        break;
                }

                if (newObject != null)
                {
                    newObject.transform.parent = level.transform;
                    //Give it a position based on where it was in the ASCII file
                    newObject.transform.position = new Vector2(xLevelPos, -yLevelPos);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here
    }

    // Other methods and properties...
}


