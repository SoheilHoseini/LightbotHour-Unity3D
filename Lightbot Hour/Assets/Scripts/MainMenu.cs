using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int levelIndex;
    [SerializeField] LevelsSetting levelsSetting;
    [SerializeField] private Text levelText;

    private void Start()
    {
        levelText.text = levelIndex.ToString();
    }

    public void OpenGameScene()
    {
        levelsSetting.levelIndx = levelIndex;
        SceneManager.LoadScene(1);
    }
}
