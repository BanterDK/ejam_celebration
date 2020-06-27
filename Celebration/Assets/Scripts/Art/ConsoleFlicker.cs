using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleFlicker : MonoBehaviour
{
    private Texture[] flickerSprites;
    private Object[] obj;
    public Material mat_console;
    private int counter = 0;
    private int currentImage;
    public string location;

    // Start is called before the first frame update
    void Start()
    {
        {
            obj = Resources.LoadAll(location, typeof(Texture));

            flickerSprites = new Texture[obj.Length];
            for (int i = 0; i < obj.Length; i++)
                flickerSprites[i] = (Texture)obj[i];
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Call the 'PlayLoop' method as a coroutine with a 0.04 delay  
        StartCoroutine("PlayLoop", 0.04f);
        //Set the material's texture to the current value of the counter variable  
        mat_console.mainTexture = flickerSprites[counter];
    }

    //The following methods return a IEnumerator so they can be yielded:  
    //A method to play the animation in a loop  
    IEnumerator PlayLoop(float delay)
    {
        //Wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);

        //Advance one frame  
        counter = (++counter) % flickerSprites.Length;

        //Stop this coroutine  
        StopCoroutine("PlayLoop");
    }

    //A method to play the animation just once  
    IEnumerator Play(float delay)
    {
        //Wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);

        //If the frame counter isn't at the last frame  
        if (counter < flickerSprites.Length - 1)
        {
            //Advance one frame  
            ++counter;
        }

        //Stop this coroutine  
        StopCoroutine("PlayLoop");
    }
}
