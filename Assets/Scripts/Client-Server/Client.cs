using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;

public class Client : MonoBehaviour
{
    public static Client instance;
    public static int dataBufferSize = 4096;

    public string ip = "192.168.50.238";
    public int port = 26950;
    public int myID = 0;
    public TCP tcp;
    public UDP udp;
    private delegate void PacketHandler(Packet _packet);
    private static Dictionary<int,PacketHandler> packetHandlers;

    private bool isConnected = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }
    private void OnApplicationQuit()
    {
        Disconnect();
    }
    private void Start()
    {
        tcp = new TCP();
        udp = new UDP();
    }
    public void ConnectToServer()
    {
        InitializeClientData();
        isConnected = true;
        tcp.Connect();
    }
    public class TCP
    {
        public TcpClient socket;
        private NetworkStream stream;
        private byte[] receiveBuffer;
        private Packet receivedData;

        public void Connect()
        {
            socket = new TcpClient
            {
                ReceiveBufferSize = dataBufferSize,
                SendBufferSize = dataBufferSize
            };
            receiveBuffer = new byte[dataBufferSize];
            socket.BeginConnect(instance.ip,instance.port,ConnectCallback,socket);

        }
        private void ConnectCallback(IAsyncResult _result)
        {
            socket.EndConnect(_result);
            if (!socket.Connected)
            {
                return;

            }
            stream = socket.GetStream();

            receivedData = new Packet();

            stream.BeginRead(receiveBuffer,0,dataBufferSize,RecieveCallback,null);

        }
        public void SendData(Packet _packet)
        {
            try
            {
                stream.BeginWrite(_packet.ToArray(),0,_packet.Length(),null,null);
            }catch(Exception _ex)
            {
                Debug.Log($"failure to send packet: {_ex}");
            }
        }
        private void RecieveCallback(IAsyncResult _result)
        {
            try
            {
                int _byteLength = stream.EndRead(_result);
                if (_byteLength <= 0)
                {
                    instance.Disconnect();
                    return;
                }
                byte[] _data = new byte[_byteLength];
                Array.Copy(receiveBuffer,_data,_byteLength);

                receivedData.Reset(HandleData(_data));

                stream.BeginRead(receiveBuffer,0,dataBufferSize,RecieveCallback,null);
            }
            catch 
            {
                Disconnect();
                Console.WriteLine("Something went fucky");
            }
        }
        private bool HandleData(byte[] _data)
        {
            int _packetLength = 0;

            receivedData.SetBytes(_data);
           
            if (receivedData.UnreadLength() >= 4)
            {
                _packetLength = receivedData.ReadInt();
                if (_packetLength <= 0)
                {
                    return true;
                }
            }
            while (_packetLength > 0 && _packetLength <= receivedData.UnreadLength())
            {
                byte[] _packetByte = receivedData.ReadBytes(_packetLength);
                ThreadManager.ExecuteOnMainThread(() =>
                {
                    using (Packet _packet = new Packet(_packetByte))
                    {
                        int _packetId = _packet.ReadInt();
                        packetHandlers[_packetId](_packet);
                    }
                });
                _packetLength = 0;
                if (receivedData.UnreadLength() >= 4)
                {
                    _packetLength = receivedData.ReadInt();
                    if (_packetLength <= 0)
                    {
                        return true;
                    }
                }
            }
            if (_packetLength <= 1)
            {
                return true;
            }
            return false;
        }
        private void Disconnect()
        {
            instance.Disconnect();
            stream = null;
            receivedData = null;
            receiveBuffer = null;
            socket = null;
        }
  
}

    public class UDP
    {
        public UdpClient socket;
        public IPEndPoint endPoint;
        public UDP()
        {
            endPoint = new IPEndPoint(IPAddress.Parse(instance.ip),instance.port);
        }
        public void Connect(int _localPort)
        {
            socket = new UdpClient(_localPort);
            socket.Connect(endPoint);
            socket.BeginReceive(ReceiveCallback,null);

            using (Packet _packet = new Packet())
            {
                SendData(_packet);
            }
        }
        public void SendData(Packet _packet)
        {
            try
            {
                _packet.InsertInt(instance.myID);
                if (socket != null)
                {
                    socket.BeginSend(_packet.ToArray(),_packet.Length(),null,null);
                }
            }
            catch (Exception _ex)
            {
                Debug.Log($"Error Sending Data to server via UDP: {_ex}");
            }
        }
        private void ReceiveCallback(IAsyncResult _result)
        {
            try
            {
                byte[] _data = socket.EndReceive(_result,ref endPoint);
                socket.BeginReceive(ReceiveCallback,null);
                if (_data.Length < 4)
                {
                    Debug.Log("Cya Cowboy");
                    instance.Disconnect();
                    return;
                }
               // Debug.Log("Heyo DATA");
                HandleData(_data);
            }
            catch
            {
                Disconnect();
            }
        }
        private void HandleData(byte[] _data)
        {
            using (Packet _packet = new Packet(_data))
            {
                int _packetLength = _packet.ReadInt();
                _data = _packet.ReadBytes(_packetLength);

            }

            ThreadManager.ExecuteOnMainThread(() =>
            {
                using (Packet _packet = new Packet(_data))
                {
                    int _packetId = _packet.ReadInt();
                    packetHandlers[_packetId](_packet);
                };
            });
        }
        private void Disconnect()
        {
            instance.Disconnect();

            endPoint = null;
            socket = null;
        }
    }
    private void InitializeClientData()
    {
        packetHandlers = new Dictionary<int,PacketHandler>()
            {
                {(int)ServerPackets.welcome, ClientHandle.Welcome },
            {(int)ServerPackets.spawnPlayer, ClientHandle.SpawnPlayer},
            {(int)ServerPackets.playerPosition, ClientHandle.PlayerPosition},
            {(int)ServerPackets.playerRotation, ClientHandle.PlayerRotation},
            {(int)ServerPackets.Pong, ClientHandle.Pong},
            {(int)ServerPackets.TestMissile, ClientHandle.TestMissile },
            {(int)ServerPackets.UpdateNetworkObject, ClientHandle.NetworkObjectUpdate },
            {(int)ServerPackets.MissileDestroyed, ClientHandle.MissileDestroyed },
             {(int)ServerPackets.SpawnPickup, ClientHandle.SpawnPickup },
              {(int)ServerPackets.KillPickup, ClientHandle.KillPickup },
              {(int)ServerPackets.SetAmmo, ClientHandle.SetAmmo },
              {(int)ServerPackets.KillPlayer, ClientHandle.KillPlayer },
              {(int)ServerPackets.RemovePlayer, ClientHandle.RemovePlayer },
              {(int)ServerPackets.SetHealth, ClientHandle.SetHealth },
            { (int)ServerPackets.SetEnergy, ClientHandle.SetEnergy }
            ,{(int)ServerPackets.SetTurbo, ClientHandle.SetTurbo }
            ,{(int)ServerPackets.ToggleDebuffs, ClientHandle.ToggleDebuff },
            {(int)ServerPackets.CarPosition, ClientHandle.CarPosition}
            };
        Debug.Log("Initialized Client");
    }
    private void Disconnect()
    {
        if (isConnected)
        {
            isConnected = false;
            tcp.socket.Close();
            udp.socket.Close();

            Debug.Log("Disconnected from server");
        }
    }
}
