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

        NormalSize = new Vector3(0.02f, 0.02f, 0.02f);
        BiggerSize = new Vector3(0.025f, 0.025f, 0.025f);

        PinkFlow = DataFlows[0];
        BlueFlow = DataFlows[1];
        GreenFlow = DataFlows[2];

        DataFlowsPink.Add(PinkFlow);
        DataFlowsBlue.Add(BlueFlow);
        DataFlowsGreen.Add(GreenFlow);
    }

    private void Update()
    {
  //      //Button
  //      if (test.Equals("p"))
  //      {
  //          if (NumberOfRobots < 3)
  //          {
  //              Instantiate(ObjectToSpawn, new Vector3((-0.075f + (NumberOfRobots * 0.0705f)), 0.125f, -0.1f), Quaternion.identity);
  //              NumberOfRobots++;
  //              test = "";

  //              for (int i = 0; i <= 2; i++)
		//		{
  //                  GameObject InstantiatedPinkFlow = Instantiate(PinkFlow, PinkFlow.transform.position, Quaternion.identity);
  //                  InstantiatedPinkFlow.transform.SetParent(DataFlowsParent[0].transform);
  //                  InstantiatedPinkFlow.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (i + 1) * 0.15f;
  //                  DataFlowsPink.Add(InstantiatedPinkFlow);
                    
  //                  GameObject InstantiatedBlueFlow = Instantiate(BlueFlow, BlueFlow.transform.position, Quaternion.identity);
  //                  InstantiatedBlueFlow.transform.SetParent(DataFlowsParent[1].transform);
  //                  InstantiatedBlueFlow.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (i + 1) * 0.15f;
  //                  DataFlowsBlue.Add(InstantiatedBlueFlow);
                    
  //                  GameObject InstantiatedGreenFlow = Instantiate(GreenFlow, GreenFlow.transform.position, Quaternion.identity);
  //                  InstantiatedGreenFlow.transform.SetParent(DataFlowsParent[2].transform);
  //                  InstantiatedGreenFlow.GetComponent<BezierSolution.BezierWalkerWithSpeed>().NormalizedT = (i + 1) * 0.15f;
  //                  DataFlowsGreen.Add(InstantiatedGreenFlow);
  //              } 
                

  //          }
  //      }


  //      //Knob
  //      if (RoundedValue >= 0 && RoundedValue <= 0.25)
  //      {
  //          Backgroud.GetComponent<MeshRenderer>().material = Materials[0];
            
  //          for(int i = 0; i < DataFlowsPink.Count; i++)
		//	{
  //              DataFlowsPink[i].SetActive(false);
  //              DataFlowsBlue[i].SetActive(false);
  //              DataFlowsGreen[i].SetActive(false);
  //          }
		//}
  //      else if (RoundedValue > 0.25 && RoundedValue <= 0.5)
  //      {
  //          Backgroud.GetComponent<MeshRenderer>().material = Materials[1];

  //          for (int i = 0; i < DataFlowsPink.Count; i++)
  //          {
  //              DataFlowsPink[i].SetActive(true);
  //              DataFlowsBlue[i].SetActive(true);
  //              DataFlowsGreen[i].SetActive(true);

  //              DataFlowsPink[i].transform.localScale = BiggerSize;
  //              DataFlowsBlue[i].transform.localScale = NormalSize;
  //              DataFlowsGreen[i].transform.localScale = NormalSize;

  //              DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = BrightColors[0];
  //              DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = LightColors[1];
  //              DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = LightColors[2];
  //          }
  //          //PinkFlowBezier.speed = 0.5f;
  //          //BlueFlowBezier.speed = 0.3f;
  //          //GreenFlowBezier.speed = 0.3f;
  //      }
  //      else if (RoundedValue > 0.5 && RoundedValue <= 0.75)
  //      {
  //          Backgroud.GetComponent<MeshRenderer>().material = Materials[2];
            
  //          for (int i = 0; i < DataFlowsPink.Count; i++)
  //          {
  //              DataFlowsPink[i].SetActive(true);
  //              DataFlowsBlue[i].SetActive(true);
  //              DataFlowsGreen[i].SetActive(true);

  //              DataFlowsPink[i].transform.localScale = NormalSize;
  //              DataFlowsBlue[i].transform.localScale = BiggerSize;
  //              DataFlowsGreen[i].transform.localScale = NormalSize;

  //              DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = LightColors[0];
  //              DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = BrightColors[1];
  //              DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = LightColors[2];
  //          }

  //          //PinkFlowBezier.speed = 0.3f;
  //          //BlueFlowBezier.speed = 0.5f;
  //          //GreenFlowBezier.speed = 0.3f;
  //      }
  //      else if (RoundedValue > 0.75 && RoundedValue <= 1)
  //      {
  //          Backgroud.GetComponent<MeshRenderer>().material = Materials[3];

  //          for (int i = 0; i < DataFlowsPink.Count; i++)
  //          {
  //              DataFlowsPink[i].SetActive(true);
  //              DataFlowsBlue[i].SetActive(true);
  //              DataFlowsGreen[i].SetActive(true);

  //              DataFlowsPink[i].transform.localScale = NormalSize;
  //              DataFlowsBlue[i].transform.localScale = NormalSize;
  //              DataFlowsGreen[i].transform.localScale = BiggerSize;

  //              DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = LightColors[0];
  //              DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = LightColors[1];
  //              DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = BrightColors[2];
  //          }

  //          //PinkFlowBezier.speed = 0.3f;
  //          //BlueFlowBezier.speed = 0.3f;
  //          //GreenFlowBezier.speed = 0.5f;
  //      }
  //      else
  //      {
  //          RoundedValue = 0;
  //      }

  //      //Bloom.color.Override(ColorParameter);
    }

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);

        if (msg.Equals("Pressed")) //Button pressed
        {
            if (NumberOfRobots < 3)
            {
                //Adding robots in the box
                Instantiate(ObjectToSpawn, new Vector3((-0.075f + (NumberOfRobots * 0.0705f)), 0.125f, -0.1f), Quaternion.identity);
                NumberOfRobots++;

                //Adding more data flow to all three lines
                for (int i = 0; i <= 2; i++)
                {
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
                }
            }
        }
        else //Knob rotated
        {
            RoundedValue = Math.Round(float.Parse(msg) / 1000f, 1);

            if (RoundedValue >= 0 && RoundedValue < 0.25) //Neutral mode
            {
                //Changing backgroung
                Backgroud.GetComponent<MeshRenderer>().material = Materials[0];

                //Disabling flow
                for (int i = 0; i < DataFlowsPink.Count; i++)
                {
                    DataFlowsPink[i].SetActive(false);
                    DataFlowsBlue[i].SetActive(false);
                    DataFlowsGreen[i].SetActive(false);
                }
            }
            else if (RoundedValue >= 0.25 && RoundedValue < 0.5) //Pink mode
            {
                //Changing backgroung
                Backgroud.GetComponent<MeshRenderer>().material = Materials[1];

                for (int i = 0; i < DataFlowsPink.Count; i++)
                {
                    //Enabling flow
                    DataFlowsPink[i].SetActive(true);
                    DataFlowsBlue[i].SetActive(true);
                    DataFlowsGreen[i].SetActive(true);

                    //Changing size of selected flow
                    DataFlowsPink[i].transform.localScale = BiggerSize;
                    DataFlowsBlue[i].transform.localScale = NormalSize;
                    DataFlowsGreen[i].transform.localScale = NormalSize;

                    //Changing color of selected flow
                    DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = BrightColors[0];
                    DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = LightColors[1];
                    DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = LightColors[2];
                }
            }
            else if (RoundedValue >= 0.5 && RoundedValue < 0.75) //Blue mode
            {
                //Changing backgroung
                Backgroud.GetComponent<MeshRenderer>().material = Materials[2];

                for (int i = 0; i < DataFlowsPink.Count; i++)
                {
                    //Enabling flow
                    DataFlowsPink[i].SetActive(true);
                    DataFlowsBlue[i].SetActive(true);
                    DataFlowsGreen[i].SetActive(true);

                    //Changing size of selected flow
                    DataFlowsPink[i].transform.localScale = NormalSize;
                    DataFlowsBlue[i].transform.localScale = BiggerSize;
                    DataFlowsGreen[i].transform.localScale = NormalSize;
                    
                    //Changing color of selected flow
                    DataFlowsPink[i].GetComponent<MeshRenderer>().material.color = LightColors[0];
                    DataFlowsBlue[i].GetComponent<MeshRenderer>().material.color = BrightColors[1];
                    DataFlowsGreen[i].GetComponent<MeshRenderer>().material.color = LightColors[2];
                }
            }
            else if (RoundedValue >= 0.75 && RoundedValue < 1) //Green mode
            {
                //Changing backgroung
                Backgroud.GetComponent<MeshRenderer>().material = Materials[3];

                for (int i = 0; i < DataFlowsPink.Count; i++)
                {
                    //Enabling flow
                    DataFlowsPink[i].SetActive(true);
                    DataFlowsBlue[i].SetActive(true);
                    DataFlowsGreen[i].SetActive(true);

                    //Changing size of selected flow
                    DataFlowsPink[i].transform.localScale = NormalSize;
                    DataFlowsBlue[i].transform.localScale = NormalSize;
                    DataFlowsGreen[i].transform.localScale = BiggerSize;

                    //Changing color of selected flow
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
