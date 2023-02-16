using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // We need this line for uGUI to work.

public class LavaPit : MonoBehaviour
{
    static private LavaPit S;
    [Header("Inscribed")]

    public Text heightMark;
    public Vector3 stagePos;
    public Transform playerPos;
    public GameObject[] stages;

    [Header("Dynamic")]
    public GameObject stage;
    public GameMode mode = GameMode.idle;
    public int currentStage;
    public int maxStages;
    public int whichStage;
    public int previousStage;

    void Start()
    {
        S = this; // Define the Singleton

        whichStage = 0;
        previousStage = 1;
        maxStages = stages.Length;
        currentStage = 0;
    }
    void Update()
    {
        StageConveyor();
        // Update Height
        if (playerPos.position.y >= 0)
        {
            heightMark.text = ((int)playerPos.position.y + 10).ToString("#,0") + " FT";
        }
    }

    void StageConveyor()
    {
        if (playerPos.position.y >= (20 * currentStage) - 5 && playerPos.position.y <= (20 * currentStage) + 5) {
            if(previousStage == whichStage)
            {
                whichStage = (int)(Random.value * stages.Length);
            }
            stage = Instantiate<GameObject>(stages[whichStage]);
            stagePos.y = stagePos.y + 20;
            stage.transform.localScale = new Vector3(Mathf.RoundToInt(Random.value) * 2 - 1 , 1, 1);
            stage.transform.position = stagePos;
            currentStage += 1;
            previousStage = whichStage;
        }
    }

    static public GameObject GET_STAGE()
    {
        return S.stage;
    }
}
