using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters.ThirdPerson;

public class NetworkManager : MonoBehaviour
{

    public Camera standByCamera;
    // Use this for initialization
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("1.0.0");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("OnJoinedLobby");
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");

        SpawnMyPlayer();
    }

    void SpawnMyPlayer()
    {
        GameObject myPlayerGo = PhotonNetwork.Instantiate("ThirdPersonController", transform.position, transform.rotation, 0);
        GameObject myCamera = PhotonNetwork.Instantiate("Camera", transform.position, transform.rotation, 0);
        myCamera.SetActive(true);
        myCamera.GetComponent<LookAtCamera>().enabled = true;
        myCamera.GetComponent<Camera>().enabled = true;
        myCamera.GetComponentInChildren<LookAtCamera>().target = myPlayerGo;
        //myCamera.GetComponent<LookAtCamera>().target = GameObject.Find("camTarget");
        myPlayerGo.SetActive(true);
        myPlayerGo.GetComponentInChildren<ThirdPersonUserControl>().enabled = true;
        myPlayerGo.GetComponentInChildren<ThirdPersonCharacter>().enabled = true;
        //myPlayerGo.GetComponentInChildren<CapsuleCollider>().enabled = true;
        //myPlayerGo.GetComponentInChildren<Animator>().enabled = true;
        //myPlayerGo.GetComponentInChildren<Camera>().enabled = true;
        //myPlayerGo.GetComponentInChildren<LookAtCamera>().enabled = true;
        
        //myPlayerGo.GetComponentInChildren<Camera> ().enabled = true; 
        //myPlayerGo.GetComponentInChildren<AudioListener> ().enabled = true;

        /*if (PhotonView.isMine) {
			myPlayerGo.GetComponentInChildren<CharacterController> ().enabled = true;
			myPlayerGo.GetComponentInChildren<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().enabled = true; 
			myPlayerGo.GetComponentInChildren<Camera> ().enabled = true; 
			myPlayerGo.GetComponentInChildren<AudioListener> ().enabled = true;
		} else {
			myPlayerGo.GetComponentInChildren<CharacterController> ().enabled = false;
			myPlayerGo.GetComponentInChildren<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().enabled = false; 
			myPlayerGo.GetComponentInChildren<Camera> ().enabled = false; 
			myPlayerGo.GetComponentInChildren<AudioListener> ().enabled = false;
		}*/

        /*standByCamera.enabled = false;
        GameObject myPlayerGo = (GameObject)PhotonNetwork.Instantiate ("FPSController", transform.position,     transform.rotation, 0);

		myPlayerGo.SetActive (true);

		try
		{
			CharacterController characterController = myPlayerGo.GetComponentInChildren<CharacterController>();
			if(characterController != null){
				characterController.enabled = true;
			}

			FirstPersonController FirstPerson = myPlayerGo.GetComponentInChildren<FirstPersonController>();
			if(FirstPerson != null){
				FirstPerson.enabled = true;
			}
			
			Camera childCam = myPlayerGo.GetComponentInChildren<Camera>();
			if(childCam != null){
				childCam.enabled = true;
			}

				
		}
			

		catch{
			Debug.LogError ("Error finding children");
		}*/


	
    }
}
