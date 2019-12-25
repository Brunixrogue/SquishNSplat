using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {
    public Texture2D fadeOutTexture; //image to overlay screen
    public float fadeSpeed = 1.0f;

    private int drawDepth = -1000; 
    private float alpha = 1.0f;
    private int fadeDir = -1; 

    void OnGUI(){
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        //set color of our GUI
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha); 
        GUI.depth = drawDepth; //make sure black texture renders on top
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); //make texture fit screen

    }

}
