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

    [Header("Game-Logic")]
    [SerializeField]
    private QuizData quizData;
    [SerializeField] 
    private Question selectedQuestion;
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

            selectedQuestion = quizData.questions.FirstOrDefault(q => q.level == gamestasts.GetLevel());
            UpdateCanvas();
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
    
    public void CeckAnswer(string answer)
    {
        if (answer.Equals(selectedQuestion.correctAnswer))
        {
            gamestasts.IncrementScore();
            gamestasts.SetLevel();
            Debug.Log(gamestasts.GetLevel() + " " + gamestasts.GetScore());
            gamestasts.ReloadScene();
        }
        else
        {
            Debug.Log("Wrong Message");
            gamestasts.DecrementScore();
            UpdateCanvas();
        }
    }

    private void UpdateCanvas()
    {
        questionText.text = selectedQuestion.question;
        answerA.text = selectedQuestion.answers.A;
        answerB.text = selectedQuestion.answers.B;
        answerC.text = selectedQuestion.answers.C;
        answerD.text = selectedQuestion.answers.D;
        statsUI.text = "Level: " + gamestasts.GetLevel() + " | " + "Score: " + gamestasts.GetScore();
    }
}