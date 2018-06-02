using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC_Dialogue : MonoBehaviour
{
    private Text message;

    public static bool onHold = false;

    void Start()
    {
        message = GameObject.Find("Message").GetComponent<Text>();

        // message.text = "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.text = "I better get going now...";

            StartCoroutine(ShortPause());
        }
    }

    IEnumerator ShortPause()
    {
        onHold = true;
        yield return new WaitForSeconds(1f);
        onHold = false;
        message.text = "";
        Destroy(this);
    }
}


