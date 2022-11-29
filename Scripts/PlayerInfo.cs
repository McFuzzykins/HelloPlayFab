using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    [HideInInspector]
    public PlayerProfileModel profile;

    void Awake()
    {
        instance = this;
    }

    public void OnLoggedIn()
    {
        GetPlayerProfileRequest getProfileRequest = new GetPlayerProfileRequest
        {
            PlayFabId = LoginRegister.instance.playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowDisplayName = true
            }
        };

        PlayFabClientAPI.GetPlayerProfile(getProfileRequest,
            result =>
            {
                profile = result.PlayerProfile;
                Debug.Log("Load In Player: " + profile.DisplayName);
            },
            error =>
            {
                Debug.Log(error.ErrorMessage);
            }
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
