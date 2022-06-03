using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private DataHolder levelUnlock;
    [SerializeField]
    private Button[] buttons;

    void Start()
    {
        levelUnlock.LoadFromFile();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelUnlock.dataItem.level; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
