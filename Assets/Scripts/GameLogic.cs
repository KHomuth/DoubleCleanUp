using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class GameLogic : MonoBehaviour {

	public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
	public GameObject bossPrefab;
	public GameObject missilePrefab;

	public Dictionary<int, Player> players = new Dictionary<int, Player> (); 

	void Awake () {
		AirConsole.instance.onMessage += OnMessage;	
		AirConsole.instance.onConnect += OnConnect;		
	}

	void OnConnect (int device){
        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0) {
			//change back to >=2
			if (AirConsole.instance.GetControllerDeviceIds ().Count >= 1) {
				//change back to 2
                AirConsole.instance.SetActivePlayers(1);
                List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
                foreach (int deviceID in connectedDevices) {
                    int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(deviceID);
                    AddNewPlayer(active_player);
                }
				AddBoss();
			} else {
				Debug.Log("NEED MORE PLAYERS");
			}
		}
	}

	private void AddNewPlayer(int deviceID){
		if (players.ContainsKey (deviceID)) {
			return;
		}

        if (deviceID == 0) {
            GameObject newPlayer = Instantiate (playerOnePrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject;
			newPlayer.transform.position = transform.position;
			players.Add(deviceID, newPlayer.GetComponent<Player>());
        } else if (deviceID == 1) {
            GameObject newPlayer = Instantiate (playerTwoPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject;
			newPlayer.transform.position = transform.position;
			players.Add(deviceID, newPlayer.GetComponent<Player>());
        }
	}

	private void AddBoss() {
		GameObject boss = Instantiate (bossPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject;
		boss.transform.position = transform.position;
		GameObject missile = Instantiate (missilePrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject;
		missile.transform.position = transform.position;
	}

	private void OnMessage (int device, JToken data){
		//When I get a message, I check if it's from any of the devices stored in my device Id dictionary
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device);
		if (players.ContainsKey(active_player) && data != null) {
            //I forward the command to the relevant player script, assigned by device ID
			players[active_player].ButtonInput(data);
		}
	}

	private void OnDestroy () {
		if (AirConsole.instance != null) {
			AirConsole.instance.onMessage -= OnMessage;	
			AirConsole.instance.onConnect -= OnConnect;		
		}
	}
}