using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatingText : MonoBehaviour
{
    public Text textbox;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  print(currentTime);
        if (currentTime < 1)
        {
            currentTime += Time.deltaTime * 2;
            if (currentTime > 0 && currentTime < 0.25f)
            {
                textbox.text = "Loading ";
            }
            if (currentTime > 0.25f && currentTime < 0.5f)
            {
                textbox.text = "Loading .";
            }

            if (currentTime > 0.5f && currentTime < 1)
            {
                textbox.text = "Loading . . ";
            }
        }

        if (currentTime > 1 )
        {
            textbox.text = "Loading . . .";
            currentTime = 0;
        }
    }
}
