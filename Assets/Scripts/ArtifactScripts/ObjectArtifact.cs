using Assets.Scripts.ArtifactScripts;
using Assets.Scripts.ArtifactScripts.Generation;
using Assets.Scripts.ArtifactScripts.UI;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum OAStates
{
    Idle, PlayerNear, ShowDeffects, CameraTooFar
}
public class ObjectArtifact : MonoBehaviour
{
    public ArtifactStats artifact;
    public int Number = 0;
    public bool IfRandom = true;
    public OAStates State = OAStates.Idle;
    private bool IfCameraTooFar;
    public Transform Canvas;

    public GameObject TextlinePrefab;
    public GameObject EffectListUIPrefab;

    private TMP_Text NameLine;
    private EffectListUIPrefabScript ProEffectList;
    private EffectListUIPrefabScript DeEffectList1;
    private EffectListUIPrefabScript DeEffectList2;
    //private TMP_Text DescriptionLine;

    private TMP_Text LeftGunKeyLine;
    private TMP_Text RightGunKeyLine;

    private List<ArtifactStats> ArtifactStats;


    //public 

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("ObjectUI");

        if (IfRandom == true)
            artifact = GenerateTier.Artifact1(); //36
        else
            artifact = GenerateTier.Artifact1();

        NameLine = Instantiate(TextlinePrefab, Canvas).transform.GetChild(0).GetComponent<TMP_Text>();
        NameLine.transform.parent.GetComponent<UIPositionAdjuster>().Owner = transform;
        NameLine.transform.parent.GetComponent<UIPositionAdjuster>().Offset = new Vector3(0, 2f);
        NameLine.text = artifact.Name;

        ProEffectList = Instantiate(EffectListUIPrefab, Canvas).GetComponent<EffectListUIPrefabScript>();
        ProEffectList.GetComponent<UIPositionAdjuster>().Owner = transform;
        ProEffectList.GetComponent<UIPositionAdjuster>().Offset = new Vector3(0, 1f);
        ProEffectList.Effects = artifact.ProEffects;

        DeEffectList1 = Instantiate(EffectListUIPrefab, Canvas).GetComponent<EffectListUIPrefabScript>();
        DeEffectList1.GetComponent<UIPositionAdjuster>().Owner = transform;
        DeEffectList1.GetComponent<UIPositionAdjuster>().Offset = new Vector3(-2.5f, 3f);
        DeEffectList1.Effects = artifact.Deffects1;
        DeEffectList1.gameObject.SetActive(false);

        DeEffectList2 = Instantiate(EffectListUIPrefab, Canvas).GetComponent<EffectListUIPrefabScript>();
        DeEffectList2.GetComponent<UIPositionAdjuster>().Owner = transform;
        DeEffectList2.GetComponent<UIPositionAdjuster>().Offset = new Vector3(2.5f, 3f);
        DeEffectList2.Effects = artifact.Deffects2;
        DeEffectList2.gameObject.SetActive(false);

        //DescriptionLine = Instantiate(TextlinePrefab, Canvas).GetComponent<TMP_Text>();
        //DescriptionLine.text = artifact.Description;

        LeftGunKeyLine = Instantiate(TextlinePrefab, Canvas).transform.GetChild(0).GetComponent<TMP_Text>();
        LeftGunKeyLine.text = "Q";
        LeftGunKeyLine.transform.parent.GetComponent<UIPositionAdjuster>().Owner = transform;
        LeftGunKeyLine.transform.parent.GetComponent<UIPositionAdjuster>().Offset = new Vector3(-1.5f, 2f);
        LeftGunKeyLine.gameObject.SetActive(false);

        RightGunKeyLine = Instantiate(TextlinePrefab, Canvas).transform.GetChild(0).GetComponent<TMP_Text>();
        RightGunKeyLine.text = "E";
        RightGunKeyLine.transform.parent.GetComponent<UIPositionAdjuster>().Owner = transform;
        RightGunKeyLine.transform.parent.GetComponent<UIPositionAdjuster>().Offset = new Vector3(1.5f, 2f);
        RightGunKeyLine.gameObject.SetActive(false);

       // Debug.Log(transform.position);
        //Debug.Log(cam.WorldToScreenPoint(transform.position + new Vector3(0, 0.5f)));
    }

    // Update is called once per frame
    void Update()
    {
        if ((State == OAStates.PlayerNear) || (State == OAStates.ShowDeffects))
        {
            Vector3 PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (Vector3.Distance(PlayerPosition, transform.position) > 3)
            {
                State = OAStates.Idle;
                LeftGunKeyLine.color = Color.white;
                RightGunKeyLine.color = Color.white;
            }
        }

        if (State == OAStates.PlayerNear)
        {
            LeftGunKeyLine.gameObject.SetActive(true);
            RightGunKeyLine.gameObject.SetActive(true);
            ProEffectList.gameObject.SetActive(true);

        }
        else if (State == OAStates.ShowDeffects)
        {
            LeftGunKeyLine.gameObject.SetActive(true);
            RightGunKeyLine.gameObject.SetActive(true);

        }
        else if (State == OAStates.Idle)
        {
            LeftGunKeyLine.gameObject.SetActive(false);
            RightGunKeyLine.gameObject.SetActive(false);
            DeEffectList1.gameObject.SetActive(false);
            DeEffectList2.gameObject.SetActive(false);
            ProEffectList.gameObject.SetActive(false);
            
        }

        
    }

    public void PickUp(ArtifactPlayerInventory artifactPlayerInventory, int i)
    {
        if (State == OAStates.PlayerNear)
        {
            if (i == 1)
            {
                ArtifactStats = artifactPlayerInventory.Gun1Artifacts;
                LeftGunKeyLine.color = Color.cyan;
                RightGunKeyLine.color = Color.white;
            }
            else if (i == 2)
            {
                ArtifactStats = artifactPlayerInventory.Gun2Artifacts;
                LeftGunKeyLine.color = Color.white;
                RightGunKeyLine.color = Color.cyan;
            }
            DeEffectList1.gameObject.SetActive(true);
            DeEffectList2.gameObject.SetActive(true);
            State = OAStates.ShowDeffects;
        }
        else if (State == OAStates.ShowDeffects)
        {
            if (i == 1)
            {
                artifact.chosenDeffect = 1;
                foreach (EffectKind effect in artifact.Deffects1.Keys)
                {
                    Debug.Log(effect + ":"+ artifact.Deffects1[effect]);
                }
                ArtifactStats.Add(artifact);
            }
            else if (i == 2)
            {
                artifact.chosenDeffect = 2;
                foreach (EffectKind effect in artifact.Deffects2.Keys)
                {
                    Debug.Log(effect + ":" + artifact.Deffects2[effect]);
                }
                ArtifactStats.Add(artifact);
            }
            artifactPlayerInventory.Refresh();
            Disapear();
            Destroy(gameObject);
        }
    }
    

    public void Disapear()
    {
        Destroy(NameLine.transform.parent.gameObject);
        //Destroy(DescriptionLine.gameObject);
        Destroy(ProEffectList.gameObject);
        Destroy(DeEffectList1.gameObject);
        Destroy(DeEffectList2.gameObject);
        Destroy(RightGunKeyLine.transform.parent.gameObject);
        Destroy(LeftGunKeyLine.transform.parent.gameObject);
    }
}
