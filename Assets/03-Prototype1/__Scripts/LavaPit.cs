using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // We need this line for uGUI to work.

public class LavaPit : MonoBehaviour
{
    static private LavaPit S;
    [Header("Inscribed")]

    static public Text heightMark;
    public Vector3 stagePos;
    public Transform playerPos;
    public GameObject[] stages;
    public int currentStage;
    public int maxStages;
    public int whichStage;

    [Header("Dynamic")]
    public GameObject stage;
    public GameMode mode = GameMode.idle;

    void Start()
    {
        S = this; // Define the Singleton

        whichStage = 0;
        maxStages = stages.Length;
        currentStage = 0;
    }
    void Update()
    {
        BuildStage();
        // Update Height
        if(playerPos.position.y == 10) heightMark.text = (playerPos.position.y + 10) + " M";
    }

    void BuildStage()
    {
        if (playerPos.position.y >= 20 * currentStage) {
            whichStage = (int)(Random.value * stages.Length);
            stage = Instantiate<GameObject>(stages[whichStage]);
            stagePos.y = stagePos.y + 20;
            stage.transform.localScale = new Vector3(Mathf.RoundToInt(Random.value) * 2 - 1 , 1, 1);
            stage.transform.position = stagePos;
            currentStage += 1;
        }
    }

    static public GameObject GET_STAGE()
    {
        return S.stage;
    }
}
