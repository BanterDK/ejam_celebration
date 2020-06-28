using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraScript : MonoBehaviour
{
    [SerializeField]
    public float RotSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, RotSpeed * Time.deltaTime, 0f);
        //Rot += 0.01f * Time.deltaTime;
    }
}
