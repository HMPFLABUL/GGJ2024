using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharlieNpc : MonoBehaviour
{
    [SerializeField] Dialogue charlieDialogue;
    int applesCount=0;
    bool introDone=false;

    public void IntroOver()
    {
        introDone = true;
        if(applesCount<3)
            charlieDialogue.SetDialogue(1);
        else
            charlieDialogue.SetDialogue(2);
    }
    public void AppleFound()
    {
        applesCount++;
        if (applesCount == 3 && introDone)
        {
            charlieDialogue.SetDialogue(2);
        }
    }
    public void QuestComplete()
    {
        charlieDialogue.SetDialogue(3);
    }
}
