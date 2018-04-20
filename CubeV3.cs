using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class CubeV3 : MonoBehaviour
{

    public GameObject M1;
    public GameObject M2;

    private Shader shader;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private Color normal;

    SerialPort sp; //whatever COM arduino uses

    private void Awake()
    {
        ColorUtility.TryParseHtmlString("#2492A1FF", out normal);
        
        try
        {
            sp = new SerialPort("COM3", 9600);
        }
        catch (System.Exception)
        {

        }
    }

    void Start()
    {

        try
        {
            sp.Open();
            sp.ReadTimeout = 1;
        }
        catch (System.Exception)
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                int s = sp.ReadByte();
                Debug.Log(s);
                if (s == 49)
                {
                    M1.GetComponent<Renderer>().material.SetVector("_Color", Color.red);
                    M2.GetComponent<Renderer>().material.SetVector("_Color", Color.green);
                } else if(s == 50)
                {
                    M1.GetComponent<Renderer>().material.SetVector("_Color", Color.red);
                    M2.GetComponent<Renderer>().material.SetVector("_Color", normal);
                }
                else if (s == 51)
                {
                    M1.GetComponent<Renderer>().material.SetVector("_Color", normal);
                    M2.GetComponent<Renderer>().material.SetVector("_Color", Color.green);
                }
                else
                {
                    M1.GetComponent<Renderer>().material.SetVector("_Color", normal);
                    M2.GetComponent<Renderer>().material.SetVector("_Color", normal);
                }
            }
            catch (System.Exception)
            {

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Do something
                Debug.Log("lee alterno");
            }
        }
    }
}