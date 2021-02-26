using UnityEngine;
using UnityEngine.UI;
 
public class FpsDisplay : MonoBehaviour
{
    public Text fpsText;
    public float hudRefreshRate = 1f;
 
    private float timer;
 
    private void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = fps + " FPS";
            timer = Time.unscaledTime + hudRefreshRate;
        }
    }
}