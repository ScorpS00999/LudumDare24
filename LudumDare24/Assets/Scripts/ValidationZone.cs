using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationZone : MonoBehaviour
{
    void ValidationGlands()
    {
        this.gameObject.SendMessage("changerIndex", 1);
    }

    void ValidationEcurieul()
    {
        this.gameObject.SendMessage("changerIndex", 1);
    }
}
