using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int score = 0;

    [SerializeField]
    private Transform PlayerTransform;
    
    
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Global");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetLevel();
            IncrementScore();
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Scenes/MainScene");
    }
    
    public void SetLevel()
    {
        level++;
    }

    public void SetPlayerTransform(Transform transform)
    {
        this.PlayerTransform = transform;
    }

    public Transform GetPlayerTransform()
    {
        return PlayerTransform;
    }
    
    public void IncrementScore()
    {
        score += 100;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetLevel()
    {
        return level;
    }

}
