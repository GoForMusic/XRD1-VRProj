using System;
using System.Linq;
using UnityEngine;

namespace Unity.Template.VR.GameLogic
{
    public class CheckAnswer : MonoBehaviour
    {
        [SerializeField]
        public string rightAnswer = "A";

        public GameStats gamestasts;

        public void Start()
        {
            gamestasts = GameObject.Find("GameStats").GetComponent<GameStats>();
        }
        
        public void CeckAnswer(string answer)
        {
            if (answer.Equals(rightAnswer))
            {
                gamestasts.IncrementScore();
                gamestasts.SetLevel();
                Debug.Log(gamestasts.GetLevel() + " " + gamestasts.GetScore());
                gamestasts.ReloadScene();
            }
            else
            {
                Debug.Log("Wrong Message");
            }
        }
        
    }
}