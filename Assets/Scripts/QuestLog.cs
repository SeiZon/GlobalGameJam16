using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class QuestLog : MonoBehaviour {
    
    public Dictionary<Quest.QuestNames, Quest> AllQuests = new Dictionary<Quest.QuestNames, Quest>();
    
    void Start()
    {
        Vector3 InitialPosition = transform.position;
        Quaternion InitialRotation = transform.rotation;

        //var PlaneDimensions = Quest.QuestPrefaIsBorn.GetComponent<Mesh>().bounds;
        var PlaneDimensions = Quest.QuestPrefaIsBorn.GetComponent<Renderer>().bounds.size;
        float PlaneWidth = PlaneDimensions[0];
        float PlaneHeight = PlaneDimensions[2];



        int i = 0;
        foreach (Quest q in GetComponents<Quest>())
        {
            Debug.Log("Started collecting defined quests.");
            q.MoveQuestPlane(transform.position + new Vector3(0,0,PlaneHeight) * i);
            
            Debug.Log("Quest plane position: " + q.QuestPosition.ToString());


            // Store each quest available
            AllQuests.Add(q.QuestId, q);
            i++;


        }
    }

    /// <summary>
    /// Takes the current order of quests, and position all of their planes, such that they align vertically. 
    /// </summary>
    public void OrientateQuestsInGameWorld()
    {
        
    }


    /// <summary>
    /// Completes a given quest. To be used by Game Logic. 
    /// </summary>
    /// <param name="name"></param>
    public void CompleteQuest(Quest.QuestNames name)
    {
        //Figure out, if there is a quest with that name
        if (this.AllQuests.ContainsKey(name))
        {
            this.AllQuests[name].QuestCompleted();
            Debug.Log("Completed a quest! Which one??");
        }
        else
            Debug.Log("Completed a non-existing quest!");
        
    }





}
