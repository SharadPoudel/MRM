using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering.PostProcessing;

public class ContainerCollider : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject Backgroud;
    //public PostProcessVolume PostProcessVolume;
    public Color[] LightColors;
    public Color[] BrightColors;
    public Material[] Materials;
    public GameObject[] DataFlows;
    public GameObject[] DataFlowsParent;
    public GameObject[] Lines;

    public double RoundedValue;
    public String test;

    //private Bloom Bloom;
    private ColorParameter ColorParameter;
    private int NumberOfRobots = 0;
    private Vector3 NormalSize;
    private Vector3 BiggerSize;

    private GameObject PinkFlow;
    private GameObject BlueFlow;
    private GameObject GreenFlow;

    private GameObject LinePinkFlow;
    private GameObject LineBlueFlow;
    private GameObject LineGreenFlow;

    private GameObject PinkFlowReverse;
    private GameObject BlueFlowReverse;
    private GameObject GreenFlowReverse;

    private List<GameObject> DataFlowsPink;
    private List<GameObject> DataFlowsBlue;
    private List<GameObject> DataFlowsGreen;

    public List<GameObject> colliderList = new List<GameObject>();

    private void Start()
    {
        //Bloom = PostProcessVolume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
        //ColorParameter = new UnityEngine.Rendering.PostProcessing.ColorParameter();
        DataFlowsPink = new List<GameObject>();
        DataFlowsBlue = new List<GameObject>();
        DataFlowsGreen = new List<GameObject>();

        NormalSize = new Vector3(0.02f, 0.02f, 0.02f);
        BiggerSize = new Vector3(0.025f, 0.025f, 0.025f);

        LinePinkFlow = Lines[0];
        LineBlueFlow = Lines[1];
        LineGreenFlow = Lines[2];

        PinkFlow = DataFlows[0];
        BlueFlow = DataFlows[1];
        GreenFlow = DataFlows[2];

        PinkFlowReverse = DataFlows[3];
        BlueFlowReverse = DataFlows[4];
        GreenFlowReverse = DataFlows[5];

        //DataFlowsPink.Add(PinkFlow);
        //DataFlowsBlue.Add(BlueFlow);
        //DataFlowsGreen.Add(GreenFlow);
    }


 
     public void OnTriggerEnter(Collider collider)
     {
         
        if (!colliderList.Contains(collider.gameObject))
         {
             colliderList.Add(collider.gameObject);
             Debug.Log("Added " + gameObject.name);
             Debug.Log("GameObjects in list: " + colliderList.Count);

            //cODE hERE 
            if (NumberOfRobots < 3)
            {
                //Adding robots in the box
                Instantiate(ObjectToSpawn, new Vector3((-0.075f + (NumberOfRobots * 0.0705f)), 0.125f, -0.1f), Quaternion.identity);
                NumberOfRobots++;

                for (int i = 0; i < 2; i++)
                {
                    //Adding more data flow to all three lines
                    GameObject InstantiatedPinkFlow = Instantiate(PinkFlow, PinkFlow.transform.position, Quaternion.identity);
                    InstantiatedPinkFlow.transform.SetParent(DataFlowsParent[0].transform);
                    InstantiatedPinkFlow.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (i + 1) * 0.15f;
                    DataFlowsPink.Add(InstantiatedPinkFlow);

                    GameObject InstantiatedBlueFlow = Instantiate(BlueFlow, BlueFlow.transform.position, Quaternion.identity);
                    InstantiatedBlueFlow.transform.SetParent(DataFlowsParent[1].transform);
                    InstantiatedBlueFlow.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (i + 1) * 0.15f;
                    DataFlowsBlue.Add(InstantiatedBlueFlow);

                    GameObject InstantiatedGreenFlow = Instantiate(GreenFlow, GreenFlow.transform.position, Quaternion.identity);
                    InstantiatedGreenFlow.transform.SetParent(DataFlowsParent[2].transform);
                    InstantiatedGreenFlow.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (i + 1) * 0.15f;
                    DataFlowsGreen.Add(InstantiatedGreenFlow);

                    //Adding more data flow to all three lines | Reverse
                    GameObject InstantiatedPinkFlowReverse = Instantiate(PinkFlowReverse, PinkFlowReverse.transform.position, Quaternion.identity);
                    InstantiatedPinkFlowReverse.transform.SetParent(DataFlowsParent[0].transform);
                    InstantiatedPinkFlowReverse.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (i + 1) * 0.15f;
                    DataFlowsPink.Add(InstantiatedPinkFlowReverse);

                    GameObject InstantiatedBlueFlowReverse = Instantiate(BlueFlowReverse, BlueFlowReverse.transform.position, Quaternion.identity);
                    InstantiatedBlueFlowReverse.transform.SetParent(DataFlowsParent[1].transform);
                    InstantiatedBlueFlowReverse.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (i + 1) * 0.15f;
                    DataFlowsBlue.Add(InstantiatedBlueFlowReverse);

                    GameObject InstantiatedGreenFlowReverse = Instantiate(GreenFlowReverse, GreenFlowReverse.transform.position, Quaternion.identity);
                    InstantiatedGreenFlowReverse.transform.SetParent(DataFlowsParent[2].transform);
                    InstantiatedGreenFlowReverse.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (i + 1) * 0.15f;
                    DataFlowsGreen.Add(InstantiatedGreenFlowReverse);
                }

                for (int i = 0; i < DataFlowsPink.Count; i++)
                {
                    //Disabling flows
                    DataFlowsPink[i].SetActive(true);
                    DataFlowsBlue[i].SetActive(true);
                    DataFlowsGreen[i].SetActive(true);
                }


                }



            //cODE TILL HERE

            if (collider.gameObject.tag == "Robot")
                Destroy(collider.gameObject);



            }
     }
 
     public void OnTriggerExit(Collider collider)
     {
         if(colliderList.Contains(collider.gameObject))
         {
             colliderList.Remove(collider.gameObject);
             Debug.Log("Removed " + gameObject.name);
             Debug.Log("GameObjects in list: " + colliderList.Count);
         }
     }

   
}


