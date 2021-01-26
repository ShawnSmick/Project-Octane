using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myID = _myId;
        ClientSend.WelcomeRecieved();
        GameManager.instance.connecting = false;
        Client.instance.udp.Connect(((IPEndPoint) Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }
    public static void SpawnPlayer(Packet _packet)
    {
        Debug.Log("Making our boy");
        GameManager.instance.SpawnPlayer(_packet.ReadInt(),_packet.ReadString(),_packet.ReadInt(), _packet.ReadVector3(),_packet.ReadQuaternion());
    }
    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        if (GameManager.players.ContainsKey(_id)){
            GameManager.players[_id].positionActual = _position;
        }
    }
    public static void Pong(Packet _packet)
    {
        float ping = (Time.time - _packet.ReadFloat()) * 1000;
        GameManager.instance.PingText.text = $"Ping: {Mathf.RoundToInt(ping)} ms";
        Debug.Log(ping + "ms ping");
    }
    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        if (GameManager.players.ContainsKey(_id))
        {

            GameManager.players[_id].transform.rotation = _packet.ReadQuaternion();
        }
        
    }
    public static void CarPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        //Vector3 _position = _packet.ReadVector3();
        if (GameManager.players.ContainsKey(_id))
        {

            GameManager.players[_id].GHOST.position =_packet.ReadVector3();
            GameManager.players[_id].GHOST.rotation =  _packet.ReadQuaternion();
            Vector3 velocity = _packet.ReadVector3(); //We will use this for client prediction.
            GameManager.players[_id].Health = _packet.ReadInt();
            GameManager.players[_id].Turbo = _packet.ReadFloat();
            GameManager.players[_id].Energy = _packet.ReadInt();
            uint timestamp = _packet.ReadUInt();
            

        }
    }
    public static void TestMissile(Packet _packet)
    {
        GameManager.instance.SpawnMissile(_packet.ReadInt(),_packet.ReadInt(),_packet.ReadInt(),_packet.ReadVector3(),_packet.ReadQuaternion());
    }
    /*  public static void MissileUpdate(Packet _packet)
      {
          int _id = _packet.ReadInt();
          Vector3 Position = _packet.ReadVector3();
          Quaternion Rotation = _packet.ReadQuaternion();
          if (GameManager.missiles.ContainsKey(_id))
          {
              GameManager.missiles[_id].updatePosition(Position,Rotation);
          }

      }*/
    public static void NetworkObjectUpdate(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 Position = _packet.ReadVector3();
        Quaternion Rotation = _packet.ReadQuaternion();
        if (GameManager.NetworkedObjects.ContainsKey(_id))
        {
            GameManager.NetworkedObjects[_id].UpdatePosition(Position,Rotation);
        }
    }
    public static void MissileDestroyed(Packet _packet)
    {
        int _id = _packet.ReadInt();
        if (GameManager.NetworkedObjects.ContainsKey(_id))
            GameManager.NetworkedObjects[_id].isKill();
    }
    public static void SpawnPickup(Packet _packet)
    {
        Debug.Log("spawning pickup");
        GameManager.instance.SpawnPickup(_packet.ReadInt(),_packet.ReadInt(),_packet.ReadVector3());
    }
    public static void KillPickup(Packet _packet)
    {
        int _id = _packet.ReadInt();
        if (GameManager.NetworkedObjects.ContainsKey(_id))
            GameManager.NetworkedObjects[_id].isKill();
    }
    public static void SetAmmo(Packet _packet)
    {
        for (int i = 0; i < GameManager.instance.Missiles.Length; i++)
        {
           // Debug.Log(i);
            GameManager.instance.Ammo[i] = _packet.ReadInt();
        }
        if (GameManager.instance.Ammo[GameManager.instance.currentAmmo] == 0)
        {
            GameManager.players[Client.instance.myID].GetComponent<PlayerController>().CycleAmmo();

        }
    }
    public static void KillPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        if (GameManager.players.ContainsKey(_id))
        {

            GameManager.players[_id].IsKill();
        }
    }
    public static void RemovePlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        PlayerManager _player = GameManager.players[_id];
        if (_id == Client.instance.myID)
        {

            Instantiate(GameManager.instance.CameraCopter,_player.transform.position,_player.transform.rotation);
            Destroy(_player.gameObject);
        }
        else
        {
            GameManager.players.Remove(_id);
            Destroy(_player.gameObject);
        }

    }
    public static void SetHealth(Packet _packet)
    {
        int _id = _packet.ReadInt();
        int _health = _packet.ReadInt();
        if (GameManager.players.ContainsKey(_id))
        {
            GameManager.players[_id].Health = _health;
        }
    }
    public static void SetEnergy(Packet _packet)
    {
        int _id = _packet.ReadInt();
        int _energy = _packet.ReadInt();
        if (GameManager.players.ContainsKey(_id))
        {
            GameManager.players[_id].Energy = _energy;
        }
    }
    public static void SetTurbo(Packet _packet)
    {
        int _id = _packet.ReadInt();
        float turbo = _packet.ReadFloat();
        if (GameManager.players.ContainsKey(_id))
        {
            GameManager.players[_id].Turbo = turbo;
        }
    }
    public static void ToggleDebuff(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string debuff = _packet.ReadString();
        switch (debuff)
        {
            case "Frozen":
                GameManager.players[_id].Frozen.SetActive(!GameManager.players[_id].Frozen.activeSelf);
                break;
            case "Burning":
                if (GameManager.players[_id].Burning.isPlaying)
                {
                    GameManager.players[_id].Burning.Stop();
                }
                else
                {
                    GameManager.players[_id].Burning.Play();
                }
                break;
        }
    }
}
