using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

/// <summary>
/// Script which deals with getting questions from the json file
/// </summary>
public class GetQuestions : MonoBehaviour
{

    [SerializeField]
    public QuizData quizData;
    public GameStats gamestasts;

    [Header("UI")]
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answerA;
    public TextMeshProUGUI answerB;
    public TextMeshProUGUI answerC;
    public TextMeshProUGUI answerD;
    public TextMeshProUGUI statsUI;


    void Start()
    {
        gamestasts = GameObject.Find("GameStats").GetComponent<GameStats>();

        string filePath = @"Assets\Scripts\JSon\apiResults.json";

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            ParseJSONData(jsonData);

            var QuestionResult = quizData.questions.FirstOrDefault(q => q.level == gamestasts.GetLevel());

            
            questionText.text = QuestionResult.question;
            answerA.text = QuestionResult.answers.A;
            answerB.text = QuestionResult.answers.B;
            answerC.text = QuestionResult.answers.C;
            answerD.text = QuestionResult.answers.D;
            statsUI.text = "Level: " + gamestasts.GetLevel() + " | " + "Score: " + gamestasts.GetScore();
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }

        
    }


    void ParseJSONData(string jsonData)
    {
        if (!string.IsNullOrEmpty(jsonData))
        {
            // Deserialize the JSON into a QuizData object
            quizData = JsonUtility.FromJson<QuizData>(jsonData);
        }
        else
        {
            Debug.LogError("JSON data is empty or invalid.");
        }
    }
}