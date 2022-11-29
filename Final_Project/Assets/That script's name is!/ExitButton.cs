using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class ExitButton : MonoBehaviour
{
    public Button exitButton;
    public InputField name;
    public InputField feedback; 

    // Start is called before the first frame update
    void Start()
    {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        if (name.text.Length != 0)
        {
            CreateText();
            LoadGame();
        }
        else 
        {
            EditorUtility.DisplayDialog("Oops", "Please enter name to exit!", "Ok");
        }

    }

    void LoadGame()
    {
        SceneManager.LoadScene("Start_Scene");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateText()
    {
        print("called CreateText");

        string path = Application.dataPath + "/Log.txt";

        if (!File.Exists(path))
        {
            print("Create text if");
            File.WriteAllText(path, "Player Data \n\n");
        }

        string playerID = "Player ID: " + name.text + "\n";
        string date = "Date/Time: " + System.DateTime.Now + "\n";
        string duration = "Duration: " + Main.S.timer.text + "\n";
        string score = "Score: " + Main.S.score + "\n";
        string userInput = feedback.text.Length == 0  ? "Feedback: No feedback provided" : "Feedback: " + feedback.text + "\n";

        File.AppendAllText(path, playerID);
        File.AppendAllText(path, date); 
        File.AppendAllText(path, duration); 
        File.AppendAllText(path, score); 
        File.AppendAllText(path, userInput); 
        File.AppendAllText(path, "\n"); 
    }
}
