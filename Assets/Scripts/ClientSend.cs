using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);

    }
    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }
    public static void WelcomeRecieved()
    {
        using (Packet _packet = new Packet((int) ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myID);
            _packet.Write(UIManager.instance.usernameField.text);
            Debug.Log("Sending Welcome Recieved");
            SendTCPData(_packet);
        }
    }
    public static void PlayerMovement(bool[] _inputs,int _currentAmmo,float _Turn,float _Accel)
    {
        using (Packet _packet = new Packet((int) ClientPackets.playerMovement))
        {          
            _packet.Write(Utils.ConvertBoolArrayToUInt(_inputs));
            
            _packet.Write(_currentAmmo);
            _packet.Write(_Turn);
            _packet.Write(_Accel);
            // _packet.Write(GameManager.players[Client.instance.myID].transform.rotation);
            // Debug.Log("Sending Movement");
            SendUDPData(_packet);
        }

    }
    public static void Ping()
    {
        using (Packet _packet = new Packet((int) ClientPackets.Ping))
        {

            _packet.Write(Time.time);
          
            SendUDPData(_packet);
        }

    }
    public static void AA(int _aatype,int _currentAmmo)
    {
        using (Packet _packet = new Packet((int) ClientPackets.AA))
        {

            _packet.Write(_aatype);
            _packet.Write(_currentAmmo);
            SendTCPData(_packet);
        }
    }
}
