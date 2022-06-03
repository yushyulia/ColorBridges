using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompletionLvl : MonoBehaviour
{
    [SerializeField]
    private int pointsToWin;
    [SerializeField]
    private int moves;
    [SerializeField]
    private DataHolder dataHolder;
    [SerializeField]
    private Transform animatePerson;
    [SerializeField]
    private Text amountMoves;

    private int currentLevel;
    private int currentPoints;

    void Update()
    {
        amountMoves.text = moves.ToString();
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentPoints >= pointsToWin && moves >= 0)
        {
            animatePerson.gameObject.SetActive(true);
            if (animatePerson.gameObject.GetComponent<PlayerController>().stop)
            {
                transform.GetChild(0).gameObject.SetActive(true);

                if (currentLevel >= dataHolder.dataItem.level && SceneManager.sceneCount > currentLevel)
                {
                    dataHolder.dataItem.level++;
                    dataHolder.SaveToFile();
                }
            }
            
        }
        if (currentPoints < pointsToWin && moves == 0)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void AddPoint()
    {
        currentPoints++;
    }

    public void TakeMove()
    {
        moves--;
    }

    public void PressMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void NextLevel()
    {
            SceneManager.LoadScene(currentLevel + 1);
    }
}
