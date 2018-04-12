using UnityEngine;
using System.Collections;

namespace UnityEngine.Networking
{
    [AddComponentMenu("Network/NetworkManagerHUD")]
    [RequireComponent(typeof(NetworkManager))]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]

    public class CustomNetworkManagerGUI : MonoBehaviour
    {
        public NetworkManager manager;
        [SerializeField]
        public bool showGUI = true;
        bool showServer = false;
        public GameObject InputIp;

        public void inputip(string ip)
        {
            Debug.Log(ip);
        }

        void Awake()
        {
            manager = GetComponent<NetworkManager>();
        }

        public void LanHost()//Хостим сервер вместе с клиентом 
        {
            if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
            {
                manager.StartServer();
            }
        }

        public void LanClient()//Подключаемся к серверу в локальной сети
        {
            if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
            {
                manager.StartClient();
            }
        }

        public void StartServerOnly()//Запускаем только сервер
        {
            if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
            {
                manager.StartServer();
                //manager.networkAddress = GameObject.Find("InputField").GetComponent<InputField>().text;
                //Debug.log(manager.networkAddres);
                //manager.networkAddress = manager.networkAddress = GUI.TextField(new Rect(xpos + 100, ypos, 95, 20), manager.networkAddress);
            }
        }
        public void ClientRed()
        {
            if (NetworkClient.active && !ClientScene.ready)
            {
                ClientScene.Ready(manager.client.connection);

                if (ClientScene.localPlayers.Count == 0)
                {
                    ClientScene.AddPlayer(0);
                }
            }
        }
        public void StopServer()//Остановка сервера 
        {
            if (NetworkServer.active || NetworkClient.active)
            {
                manager.StopHost();
            }
        } 
    }
}