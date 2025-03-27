using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public ScoreManager scorer;
    public int level = 1;
    public int SP = 0;
    public float experience = 0.0f;
    public float ratio = 0.0f;
    public int lvlScaleFactor = 10;

    [Header("UI stuff")]
    public GameObject lvlText;
    public GameObject Xpcounter;
    public GameObject expBar;

    [Header("level up data")]
    public float expneeded;
    public float previousExperience;
    public float lowerVal = 0;
    public float upperVal = 0;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        experience = scorer.xp;
        lowerVal = (experience - previousExperience);
        upperVal = (expneeded - previousExperience);

        cm.seTxt(lvlText,level.ToString("0"));
        cm.seTxt(Xpcounter,(experience - previousExperience) + " / "+expneeded);
        expBar.GetComponent<UiBarManager>().ratio = ratio;
        SetExp();
    }

    public int ExpNeedToLvlUp(int currentLvl){
        if(currentLvl == 0){return 0;}
        return (currentLvl * currentLvl + currentLvl) * lvlScaleFactor;
    }

    public void SetExp(){
        expneeded = ExpNeedToLvlUp(level);
        previousExperience = ExpNeedToLvlUp(level - 1);

        // level up with exp
        if(experience >= expneeded){
            levelUP();
            expneeded = ExpNeedToLvlUp(level);
            previousExperience = ExpNeedToLvlUp(level -1);
        }

        // calculate ratio
        ratio = (float) (experience - previousExperience) / (expneeded - previousExperience);
        ratio = ratio == 1 ? 0 : ratio;
    }

    public void levelUP(){
        level++;
        SP += 1;
    }
}
