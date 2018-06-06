using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Healing : MonoBehaviour
{

    public GameObject Canvas_Text;
    private Text message;
    private bool Heal = true;

    // Update is called once per frame
    void Update()
    {
        message = Canvas_Text.GetComponent<Text>();

        if (Input.GetKeyDown(KeyCode.E))
            Heal = false;

        if (Heal)
            message.text = "Heal";
        else
            message.text = "";
    }
}
