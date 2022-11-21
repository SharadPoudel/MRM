/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering.PostProcessing;
using System.Collections.Generic;

/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class ArduinoMessageListener : MonoBehaviour
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

    private void Start()
    {
        //Bloom = PostProcessVolume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
        //ColorParameter = new UnityEngine.Rendering.PostProcessing.ColorParameter();
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

        //DataFlowsPink.Add(PinkFlow);
        //DataFlowsBlue.Add(BlueFlow);
        //DataFlowsGreen.Add(GreenFlow);
    }

	//private void Update()
	//{
	//	//Button
	//	if (test.Equals("p"))
	//	{
	//		if (NumberOfRobots < 3)
	//		{
	//			Instantiate(ObjectToSpawn, new Vector3((-0.075f + (NumberOfRobots * 0.0705f)), 0.125f, -0.1f), Quaternion.identity);
	//			NumberOfRobots++;
	//			test = "";

	//			GameObject InstantiatedPinkFlow = Instantiate(PinkFlow, PinkFlow.transform.position, Quaternion.identity);
	//			InstantiatedPinkFlow.transform.SetParent(DataFlowsParent[0].transform);
	//			InstantiatedPinkFlow.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (NumberOfRobots + 1) * 0.15f;
	//			DataFlowsPink.Add(InstantiatedPinkFlow);

	//			GameObject InstantiatedBlueFlow = Instantiate(BlueFlow, BlueFlow.transform.position, Quaternion.identity);
	//			InstantiatedBlueFlow.transform.SetParent(DataFlowsParent[1].transform);
	//			InstantiatedBlueFlow.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (NumberOfRobots + 1) * 0.15f;
	//			DataFlowsBlue.Add(InstantiatedBlueFlow);

	//			GameObject InstantiatedGreenFlow = Instantiate(GreenFlow, GreenFlow.transform.position, Quaternion.identity);
	//			InstantiatedGreenFlow.transform.SetParent(DataFlowsParent[2].transform);
	//			InstantiatedGreenFlow.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (NumberOfRobots + 1) * 0.15f;
	//			DataFlowsGreen.Add(InstantiatedGreenFlow);

 //               //Reverse
 //               GameObject InstantiatedPinkFlowReverse = Instantiate(PinkFlowReverse, PinkFlowReverse.transform.position, Quaternion.identity);
 //               InstantiatedPinkFlowReverse.transform.SetParent(DataFlowsParent[0].transform);
 //               InstantiatedPinkFlowReverse.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (NumberOfRobots + 1) * 0.15f;
 //               DataFlowsPink.Add(InstantiatedPinkFlowReverse);

 //               GameObject InstantiatedBlueFlowReverse = Instantiate(BlueFlowReverse, BlueFlowReverse.transform.position, Quaternion.identity);
 //               InstantiatedBlueFlowReverse.transform.SetParent(DataFlowsParent[1].transform);
 //               InstantiatedBlueFlowReverse.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (NumberOfRobots + 1) * 0.15f;
	//			DataFlowsBlue.Add(InstantiatedBlueFlowReverse);

	//			GameObject InstantiatedGreenFlowReverse = Instantiate(GreenFlowReverse, GreenFlowReverse.transform.position, Quaternion.identity);
 //               InstantiatedGreenFlowReverse.transform.SetParent(DataFlowsParent[2].transform);
 //               InstantiatedGreenFlowReverse.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (NumberOfRobots + 1) * 0.15f;
	//			DataFlowsGreen.Add(InstantiatedGreenFlowReverse);
	//		}
	//	}


	//	//Knob
	//	if (RoundedValue >= 0 && RoundedValue <= 0.25)
	//	{
	//		Backgroud.GetComponent<MeshRenderer>().material = Materials[0];

 //           LinePinkFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f );
 //           LinePinkFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
 //           LineBlueFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
 //           LineBlueFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
 //           LineGreenFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);
 //           LineGreenFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);

 //           for (int i = 0; i < DataFlowsPink.Count; i++)
	//		{
	//			DataFlowsPink[i].SetActive(false);
	//			DataFlowsBlue[i].SetActive(false);
	//			DataFlowsGreen[i].SetActive(false);
	//		}
	//	}
	//	else if (RoundedValue > 0.25 && RoundedValue <= 0.5)
	//	{
	//		Backgroud.GetComponent<MeshRenderer>().material = Materials[1];

 //           LinePinkFlow.GetComponent<LineRenderer>().startColor = new Color(BrightColors[0].r, BrightColors[0].g, BrightColors[0].b, 1.0f);
 //           LinePinkFlow.GetComponent<LineRenderer>().endColor = new Color(BrightColors[0].r, BrightColors[0].g, BrightColors[0].b, 1.0f);
 //           LineBlueFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
 //           LineBlueFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
 //           LineGreenFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);
 //           LineGreenFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);

 //           for (int i = 0; i < DataFlowsPink.Count; i++)
	//		{
	//			DataFlowsPink[i].SetActive(true);
	//			DataFlowsBlue[i].SetActive(true);
	//			DataFlowsGreen[i].SetActive(true);

	//			DataFlowsPink[i].transform.localScale = BiggerSize;
	//			DataFlowsBlue[i].transform.localScale = NormalSize;
	//			DataFlowsGreen[i].transform.localScale = NormalSize;

	//			DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = BrightColors[0];
	//			DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = LightColors[1];
	//			DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = LightColors[2];
 //           }
	//	}
	//	else if (RoundedValue > 0.5 && RoundedValue <= 0.75)
	//	{
	//		Backgroud.GetComponent<MeshRenderer>().material = Materials[2];

 //           LinePinkFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
 //           LinePinkFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
 //           LineBlueFlow.GetComponent<LineRenderer>().startColor = new Color(BrightColors[1].r, BrightColors[1].g, BrightColors[1].b, 1.0f);
 //           LineBlueFlow.GetComponent<LineRenderer>().endColor = new Color(BrightColors[1].r, BrightColors[1].g, BrightColors[1].b, 1.0f);
 //           LineGreenFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f);
 //           LineGreenFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[2].r, LightColors[2].g, LightColors[2].b, 1.0f); 
            
 //           for (int i = 0; i < DataFlowsPink.Count; i++)
	//		{
	//			DataFlowsPink[i].SetActive(true);
	//			DataFlowsBlue[i].SetActive(true);
	//			DataFlowsGreen[i].SetActive(true);

	//			DataFlowsPink[i].transform.localScale = NormalSize;
	//			DataFlowsBlue[i].transform.localScale = BiggerSize;
	//			DataFlowsGreen[i].transform.localScale = NormalSize;

	//			DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = LightColors[0];
	//			DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = BrightColors[1];
	//			DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = LightColors[2];
 //           }
	//	}
	//	else if (RoundedValue > 0.75 && RoundedValue <= 1)
	//	{
	//		Backgroud.GetComponent<MeshRenderer>().material = Materials[3];
            
 //           LinePinkFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
 //           LinePinkFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[0].r, LightColors[0].g, LightColors[0].b, 1.0f);
 //           LineBlueFlow.GetComponent<LineRenderer>().startColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
 //           LineBlueFlow.GetComponent<LineRenderer>().endColor = new Color(LightColors[1].r, LightColors[1].g, LightColors[1].b, 1.0f);
 //           LineGreenFlow.GetComponent<LineRenderer>().startColor = new Color(BrightColors[2].r, BrightColors[2].g, BrightColors[2].b, 1.0f);
 //           LineGreenFlow.GetComponent<LineRenderer>().endColor = new Color(BrightColors[2].r, BrightColors[2].g, BrightColors[2].b, 1.0f);

 //           for (int i = 0; i < DataFlowsPink.Count; i++)
	//		{
	//			DataFlowsPink[i].SetActive(true);
	//			DataFlowsBlue[i].SetActive(true);
	//			DataFlowsGreen[i].SetActive(true);

	//			DataFlowsPink[i].transform.localScale = NormalSize;
	//			DataFlowsBlue[i].transform.localScale = NormalSize;
	//			DataFlowsGreen[i].transform.localScale = BiggerSize;

	//			DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = LightColors[0];
	//			DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = LightColors[1];
	//			DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = BrightColors[2];
 //           }
	//	}
	//	else
	//	{
	//		RoundedValue = 0;
	//	}

	//}

	// Invoked when a line of data is received from the serial device.

	void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);

        if (msg.Equals("Pressed")) //Button pressed
        {
            if (NumberOfRobots < 3)
            {
                //Adding robots in the box
                Instantiate(ObjectToSpawn, new Vector3((-0.075f + (NumberOfRobots * 0.092f)), 0.125f, -0.1f), Quaternion.identity);
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
        else //Knob rotated
        {
            RoundedValue = Math.Round(float.Parse(msg), 1);

            if (RoundedValue >= 0 && RoundedValue < 4) //Neutral mode
            {
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
            else if (RoundedValue >= 4 && RoundedValue < 8) //Pink mode
            {
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
            else if (RoundedValue >= 8 && RoundedValue < 12) //Blue mode
            {
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
            else if (RoundedValue >= 12 && RoundedValue < 15) //Green mode
            {
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
            else //Reset
            {
                RoundedValue = 0;
            }
        }
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
