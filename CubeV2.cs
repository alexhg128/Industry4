using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class CubeV2 : MonoBehaviour {

    private Shader shader;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private Color normal;

    SerialPort sp; //whatever COM arduino uses

    private void Awake()
    {
        ColorUtility.TryParseHtmlString("#2492A1FF", out normal);
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
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
                if(sp.ReadByte() == 49)
                {
                    GetComponent<Renderer>().material.SetVector("_Color", Color.red);
                }
                else
                {
                    GetComponent<Renderer>().material.SetVector("_Color", normal);
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
