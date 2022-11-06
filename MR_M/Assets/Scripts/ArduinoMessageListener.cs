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
    //public Slider Slider;
    public Text IntentValue;
    public PostProcessVolume PostProcessVolume;
    public Color[] Colors;
    public double RoundedValue;

    private Bloom Bloom;
    private ColorParameter ColorParameter;
    private int NumberOfRobots = 0;

	private void Start()
	{
        Bloom = PostProcessVolume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
        ColorParameter = new UnityEngine.Rendering.PostProcessing.ColorParameter();
    }

	private void Update()
	{
        IntentValue.text = "Intent Value = " + RoundedValue.ToString();

        if (RoundedValue >= 0 && RoundedValue < 0.25)
        {
            ColorParameter.value = Colors[0];
        }
        else if (RoundedValue >= 0.25 && RoundedValue <= 0.5)
        {
            ColorParameter.value = Colors[1];
        }
        else if (RoundedValue >= 0.5 && RoundedValue < 0.75)
        {
            ColorParameter.value = Colors[2];
        }
        else
        {
            ColorParameter.value = Colors[3];
        }

        Bloom.color.Override(ColorParameter);
    }

	// Invoked when a line of data is received from the serial device.
	void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);

        if (msg.Equals("Pressed"))
		{
            if (NumberOfRobots <= 6)
            {
                Instantiate(ObjectToSpawn, new Vector3(NumberOfRobots, 0.196f, 0), Quaternion.identity);
                NumberOfRobots++;
            }
        }
        else
		{
            //double RoundedValue = Math.Round(float.Parse(msg) / 1000f, 1);

            //Slider.value = float.Parse(msg)/1000f;
            IntentValue.text = "Intent Value = " + RoundedValue.ToString();

            if (RoundedValue >=0 && RoundedValue < 0.25)
			{
                ColorParameter.value = Colors[0];
            }
            else if (RoundedValue >= 0.25 && RoundedValue <= 0.5)
            {
                ColorParameter.value = Colors[1];
            }
            else if (RoundedValue >= 0.5 && RoundedValue < 0.75)
            {
                ColorParameter.value = Colors[2];
            }
            else
            {
                ColorParameter.value = Colors[3];
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
