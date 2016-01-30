using UnityEngine;
using System.Collections;
using UnityEditor;


public class Quest : MonoBehaviour{
    public enum QuestNames : int { Baby = 42, Cake, Speech, JydeOnkel, Svigerfar };
    public static GameObject QuestPrefaIsBorn = Resources.Load("QuestPrefab") as GameObject;


    public bool QuestStatus = false;

    [SerializeField]
    public QuestNames QuestId;

    //[SerializeField]
    GameObject QuestPrefab; 
    
    private MeshRenderer planeRenderer;

    [SerializeField]
    private Texture StartTexture;

    [SerializeField]
    private Texture DoneTexture;

    public Vector3 QuestPosition;
    public Quaternion QuestRotation;

    private int CurrentTexture = 0;  //If 0, StartTexture, else DoneTexture 

    /// <summary>
    /// Unity-contructor. Does nothing but set the selected textures.. 
    /// </summary>
    void Start()
    {
        //Inherit position from QuestLog!!

        Debug.Log("Created a new Quest! It is " + QuestId.ToString());

        //Check if StartTexture and DoneTexture has been selected

        //Instantiate the quest Prefab
        //GameObject QuestPrefaIsBorn = Resources.Load("QuestPrefab") as GameObject;

        this.QuestPrefab = Instantiate(QuestPrefaIsBorn, QuestPosition, Quaternion.identity) as GameObject;

        Debug.Log("Positioned at " + QuestPosition.ToString());

        planeRenderer = this.QuestPrefab.GetComponent<MeshRenderer>();

        this.planeRenderer.material.mainTexture = this.StartTexture;
    }
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="newPosition"></param>
    public void MoveQuestPlane(Vector3 newPosition)
    {
        this.QuestPrefab.transform.position = newPosition;
    }

    /// <summary>
    /// Used to mark a quest completed
    /// </summary>
    public void QuestCompleted()
    {
        this.QuestStatus = true;
        this.ChangeTexture();
    }

    /// <summary>
    /// Changes texture from StartTexture to DoneTexture and vice versa
    /// </summary>
    private void ChangeTexture()
    {
        //TODO: Add check if a texture is missing??

        if (this.CurrentTexture == 0)
            this.planeRenderer.material.mainTexture = this.StartTexture;
        else
            this.planeRenderer.material.mainTexture = this.DoneTexture;
    }


}
