using System.Collections;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class QuizData : IEnumerable
{
    public List<Question> questions;
    public IEnumerator GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}

[System.Serializable]
public class Question
{
    public string question;
    public Options answers;
    public string correctAnswer;
    public int level;
}

[System.Serializable]
public class Options
{
    public string A;
    public string B;
    public string C;
    public string D;
}