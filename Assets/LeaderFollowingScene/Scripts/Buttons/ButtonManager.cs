using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Button scatterButton;

    [SerializeField]
    private Button followButton;

    public void FollowButton() {
        followButton.interactable = false;
        scatterButton.interactable = true;
    }

    public void ScatterButton() {
        followButton.interactable = true;
        scatterButton.interactable = false;
    }
}
