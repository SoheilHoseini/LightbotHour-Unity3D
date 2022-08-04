using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] GameCore gameCoreScript;

    // Seperate Model(GameCore) from Presenter(GamePlay)
    void Start()
    {
        //gameCoreScript.levelIndex = gameCoreScript.levelsSetting.levelIndx;
        //gameCoreScript.nextLevelBtn.SetActive(false);
        //gameCoreScript.DesignLevelsScene();
        //gameCoreScript.GenerateLevel(gameCoreScript.levelIndex);

        //gameCoreScript.DesignPlayerPosition();
        //gameCoreScript.DesignPlayerRotation();
        //gameCoreScript.GeneratePlayer(gameCoreScript.levelIndex);
    }
}
