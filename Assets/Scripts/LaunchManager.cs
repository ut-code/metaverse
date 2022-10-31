using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LaunchManager : MonoBehaviourPunCallbacks
{   

    private void Awake(){
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Started Program");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConnectToPhotonServer(){

        if(!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            print("Connected to Photon Server");
        }   
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName + " Connected to Server.");
    }


    public override void OnConnected()
    {
        Debug.Log("Connected to Internet");
    }

    public void JoinRandomRoom(){
        PhotonNetwork.JoinRandomRoom();
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to" + PhotonNetwork.CurrentRoom.Name + " " + PhotonNetwork.CurrentRoom.PlayerCount);
    }


    void CreateAndJoinRoom(){

        string randomRoomName = "Room" + Random.Range(0,10000);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;


        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);  

    }
    
}

