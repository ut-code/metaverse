using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LaunchManager : MonoBehaviourPunCallbacks
{   

    private void Awake(){
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;
    public GameObject LobbyPanel;

    //交流所参加用のパネル
    public GameObject ContactRoomPanel;

    //createRoomの部屋の名前
    public TMP_InputField createRoomNameInput;

    //joinRoomの部屋の名前
    public TMP_InputField joinRoomNameInput;

    // Start is called before the first frame update
    void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
        ContactRoomPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConnectToPhotonServer(){

        if(!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            ConnectionStatusPanel.SetActive(true);
            EnterGamePanel.SetActive(false);
        }   
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName + " Connected to Server.");
        // LobbyPanel.SetActive(true);
        ContactRoomPanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
    }

    public override void OnConnected()
    {
        Debug.Log("Connected to Internet");
    }

    public void JoinRandomRoom(){
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    
    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to" + PhotonNetwork.CurrentRoom.Name + " " + PhotonNetwork.CurrentRoom.PlayerCount);
    }



    
    //交流所に参加
    public void CreateAndJoinRoom(){

        string roomName = "contact";

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;


        PhotonNetwork.CreateRoom(roomName, roomOptions);  

    }

    public void CreateRoom() {

        string roomName = createRoomNameInput.text;


        PhotonNetwork.CreateRoom(roomName);
    }

    public void JoinRoom() {

        string roomName = joinRoomNameInput.text;

        PhotonNetwork.JoinRoom(roomName);
    }


}
