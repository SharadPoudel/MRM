using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering.PostProcessing;
using System.Collections.Generic;


public class RSImageDetection : MonoBehaviour
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
    public float ObjectNormalSize;
    public float ObjectBigSize;

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
    
    private List<int> TrackedImages;

    // Start is called before the first frame update
    void Start()
    {
        DataFlowsPink = new List<GameObject>();
        DataFlowsBlue = new List<GameObject>();
        DataFlowsGreen = new List<GameObject>();

        NormalSize = new Vector3(ObjectNormalSize, ObjectNormalSize, ObjectNormalSize);
        BiggerSize = new Vector3(ObjectBigSize, ObjectBigSize, ObjectBigSize);

        LinePinkFlow = Lines[0];
        LineBlueFlow = Lines[1];
        LineGreenFlow = Lines[2];

        PinkFlow = DataFlows[0];
        BlueFlow = DataFlows[1];
        GreenFlow = DataFlows[2];

        PinkFlowReverse = DataFlows[3];
        BlueFlowReverse = DataFlows[4];
        GreenFlowReverse = DataFlows[5];

        TrackedImages = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModeImageDetected(int Intent)
    {
        if ( Intent == 2 ) //Neutral mode changed ***0 to 2
        {
            Debug.Log("Neutral Mode");
            //Changing backgroung
            Backgroud.GetComponent<MeshRenderer>().material = Materials[0];

            //Changing lines color
            LinePinkFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
            LinePinkFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
            LineBlueFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
            LineBlueFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
            LineGreenFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);
            LineGreenFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);

            for (int i = 0; i < DataFlowsPink.Count; i++)
            {
                //Disabling flows
                DataFlowsPink[i].SetActive(true);
                DataFlowsBlue[i].SetActive(true);
                DataFlowsGreen[i].SetActive(true);

                //Changing size of flow
                DataFlowsPink[i].transform.localScale = NormalSize;
                DataFlowsBlue[i].transform.localScale = NormalSize;
                DataFlowsGreen[i].transform.localScale = NormalSize;

                //Changing color of  flow
                DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = LightColors[0];
                DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = LightColors[1];
                DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = LightColors[2];
            }
        }
        else if ( Intent == 3 ) //Pink mode it is actually  green *** changed 1 to 3
        {
            Debug.Log("Pink Mode");
            //Changing backgroung
            Backgroud.GetComponent<MeshRenderer>().material = Materials[1];

            //Changing lines color
            LinePinkFlow.GetComponent<LineRenderer>().startColor = new Color(BrightColors[0].r, BrightColors[0].g, BrightColors[0].b, 1.0f);
            LinePinkFlow.GetComponent<LineRenderer>().endColor = new Color(BrightColors[0].r, BrightColors[0].g, BrightColors[0].b, 1.0f);
            LineBlueFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
            LineBlueFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
            LineGreenFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);
            LineGreenFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);

            for (int i = 0; i < DataFlowsPink.Count; i++)
            {
                //Enabling flows
                DataFlowsPink[i].SetActive(true);
                DataFlowsBlue[i].SetActive(true);
                DataFlowsGreen[i].SetActive(true);

                //Changing size of flow
                DataFlowsPink[i].transform.localScale = BiggerSize;
                DataFlowsBlue[i].transform.localScale = NormalSize;
                DataFlowsGreen[i].transform.localScale = NormalSize;

                //Changing color of  flow
                DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = BrightColors[0];
                DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = LightColors[1];
                DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = LightColors[2];
            }
        }
        else if (Intent == 0) //Blue mode ***changed 0 to 2
        {
            Debug.Log("Blue Mode");
            
            //Changing backgroung
            Backgroud.GetComponent<MeshRenderer>().material = Materials[2];

            //Changing lines color
            LinePinkFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
            LinePinkFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
            LineBlueFlow.GetComponent<LineRenderer>().startColor = new Color(BrightColors[1].r, BrightColors[1].g, BrightColors[1].b, 1.0f);
            LineBlueFlow.GetComponent<LineRenderer>().endColor = new Color(BrightColors[1].r, BrightColors[1].g, BrightColors[1].b, 1.0f);
            LineGreenFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);
            LineGreenFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);

            for (int i = 0; i < DataFlowsPink.Count; i++)
            {
                //Enabling flows
                DataFlowsPink[i].SetActive(true);
                DataFlowsBlue[i].SetActive(true);
                DataFlowsGreen[i].SetActive(true);

                //Changing size of flow
                DataFlowsPink[i].transform.localScale = NormalSize;
                DataFlowsBlue[i].transform.localScale = BiggerSize;
                DataFlowsGreen[i].transform.localScale = NormalSize;

                //Changing color of  flow
                DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = LightColors[0];
                DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = BrightColors[1];
                DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = LightColors[2];
            }
        }
        else if (Intent == 1) //Green mode it is actually pint ***changed 3 to 1
        {
            Debug.Log("Green Mode");
            
            //Changing backgroung
            Backgroud.GetComponent<MeshRenderer>().material = Materials[3];

            //Changing lines color
            LinePinkFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
            LinePinkFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
            LineBlueFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
            LineBlueFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
            LineGreenFlow.GetComponent<LineRenderer>().startColor = new Color(BrightColors[2].r, BrightColors[2].g, BrightColors[2].b, 1.0f);
            LineGreenFlow.GetComponent<LineRenderer>().endColor = new Color(BrightColors[2].r, BrightColors[2].g, BrightColors[2].b, 1.0f);

            for (int i = 0; i < DataFlowsPink.Count; i++)
            {
                //Enabling flows
                DataFlowsPink[i].SetActive(true);
                DataFlowsBlue[i].SetActive(true);
                DataFlowsGreen[i].SetActive(true);

                //Changing size of flow
                DataFlowsPink[i].transform.localScale = NormalSize;
                DataFlowsBlue[i].transform.localScale = NormalSize;
                DataFlowsGreen[i].transform.localScale = BiggerSize;

                //Changing color of  flow
                DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = LightColors[0];
                DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = LightColors[1];
                DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = BrightColors[2];
            }
        }
    }

    public void RobotsImageDetected(int NumberOfRobot)
    {
        Debug.Log("Robot " + (NumberOfRobot + 1) + " Detected");

        if (!TrackedImages.Contains(NumberOfRobot))
        {
            //Adding robots in the box
            Instantiate(ObjectToSpawn, new Vector3((-0.075f + (TrackedImages.Count * 0.092f)), 0.125f, -0.1f), Quaternion.identity);
            TrackedImages.Add(NumberOfRobot);
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
    }
}
