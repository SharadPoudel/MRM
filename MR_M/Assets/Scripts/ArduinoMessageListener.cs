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

/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class ArduinoMessageListener : MonoBehaviour
{

    public GameObject ObjectToSpawn;
    public GameObject Backgroud;
    public PostProcessVolume PostProcessVolume;
    public Color[] Colors;
    public Material[] Materials;

    private Bloom Bloom;
    private ColorParameter ColorParameter;
    private double RoundedValue;
    private int NumberOfRobots = 0;

    private void Start()
    {
        Bloom = PostProcessVolume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
        ColorParameter = new UnityEngine.Rendering.PostProcessing.ColorParameter();
    }

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);

        if (msg.Equals("Pressed"))
        {
            if (NumberOfRobots < 3)
            {
                Instantiate(ObjectToSpawn, new Vector3((-0.075f + (NumberOfRobots * 0.0705f)), 0.125f, -0.1f), Quaternion.identity);
                NumberOfRobots++;
            }
        }
        else
        {
            RoundedValue = Math.Round(float.Parse(msg) / 1000f, 1);
            if (RoundedValue >= 0 && RoundedValue <= 0.25)
            {
                ColorParameter.value = Colors[0];
                Backgroud.GetComponent<MeshRenderer>().material = Materials[0];
            }
            else if (RoundedValue > 0.25 && RoundedValue <= 0.5)
            {
                ColorParameter.value = Colors[1];
                Backgroud.GetComponent<MeshRenderer>().material = Materials[1];
            }
            else if (RoundedValue > 0.5 && RoundedValue <= 0.75)
            {
                ColorParameter.value = Colors[2];
                Backgroud.GetComponent<MeshRenderer>().material = Materials[2];
            }
            else if (RoundedValue > 0.75 && RoundedValue <= 1)
            {
                ColorParameter.value = Colors[3];
                Backgroud.GetComponent<MeshRenderer>().material = Materials[3];
            }
            else
            {
                RoundedValue = 0;

            }

            Bloom.color.Override(ColorParameter);
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
