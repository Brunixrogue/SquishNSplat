using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public static int killCount;
    private Text killCountText;

    // Use this for initialization
    void Start()
    {
        killCount = 0;
        killCountText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //Update kill count
        killCount = BugController.killCount;
        killCountText.text = "" + killCount;
    }
}
