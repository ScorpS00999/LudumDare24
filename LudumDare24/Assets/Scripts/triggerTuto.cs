using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class triggerTuto : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI interactionText;

    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactionText.gameObject.SetActive(true);
        if (gameObject.name == "tutoChampiJump")
        {
            interactionText.text = $"Jump on the mushroom";
        } else if (gameObject.name == "tutoJump")
        {
            string interactKey = InputControlPath.ToHumanReadableString(controls.Player.Jump.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
            string interactKey2 = InputControlPath.ToHumanReadableString(controls.Player.Jump.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
            interactionText.text = $"Press {interactKey} or {interactKey2} to jump";
        } else if (gameObject.name == "tutoPlateform")
        {
            string interactKey = InputControlPath.ToHumanReadableString(controls.Player.CreatePlatform.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
            string interactKey2 = InputControlPath.ToHumanReadableString(controls.Player.CreatePlatform.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
            interactionText.text = $"Press {interactKey} or {interactKey2} to create a platfrom";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactionText.gameObject.SetActive(false);
    }
}
