using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC_Dialogue : MonoBehaviour
{
    public GameObject Canvas_Text;
    private Text message;
    public string Output_Text;
    private float Time_Delay = 2f;

    public static bool onHold = false;

    void Start()
    {
        message = Canvas_Text.GetComponent<Text>();

        message.text = "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.text = Output_Text;

            StartCoroutine(ShortPause());
        }
    }

    IEnumerator ShortPause()
    {
        onHold = true;
        yield return new WaitForSeconds(Time_Delay);
        onHold = false;
        message.text = "";
        Destroy(this);
    }
}


