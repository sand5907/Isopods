using UnityEngine;
using LEVEL = Isopods.Constants.LEVEL_CONST;

public class ChildCollide : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.SendMessageUpwards("notOnGround");
    }


}

