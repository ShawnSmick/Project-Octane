using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int,PlayerManager> players = new Dictionary<int,PlayerManager>();
    public static Dictionary<int,MissileBase> missiles = new Dictionary<int,MissileBase>();
    public static Dictionary<int,Pickup> pickups = new Dictionary<int,Pickup>();
    public Text PingText;
    
    public GameObject localPlayerPrefab;
    public GameObject playerPrefab,CameraCopter,bigprefab,biglocal;
    public GameObject[] Missiles,Pickups;
    public string[] MissileNames;
    public int[] Ammo;
    public int currentAmmo = 1;
   // public int Health;
    public bool connecting = false;
    public float reconnect = 5f;
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Ammo = new int[Missiles.Length];
    }
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
    public void Update()
    {
        if (connecting)
        {
            if (reconnect < 0)
            {
                Client.instance.ConnectToServer();
                reconnect = 5f;
            }
            else
            {
                reconnect -= Time.deltaTime;
            }
           
        }
    }
    public void SpawnPlayer(int _id,string _username,int Health,Vector3 _position,Quaternion _rotation)
    {
        if (players.ContainsKey(_id))
        {
            Destroy(players[_id].gameObject);
            players.Remove(_id);
        }
        GameObject _player;
        if (_id == Client.instance.myID)
        {
            _player = Instantiate(_username=="GLORIOUSBIGBOY"?biglocal:localPlayerPrefab,_position,_rotation);
         //   GameManager.players[_id].Health = Health;
        }
        else
        {
            _player = Instantiate(_username == "GLORIOUSBIGBOY" ?bigprefab: playerPrefab,_position,_rotation);
            
        }
        PlayerManager _pmanage = _player.GetComponent<PlayerManager>();
        _pmanage.id = _id;
        _pmanage.SetName(_username);
        Debug.Log($"Adding Player {_id}");
        players.Add(_id,_player.GetComponent<PlayerManager>());

    }
    public void SpawnMissile(int _fromClient,int _id,int type,Vector3 _position,Quaternion _rotation)
    {
        MissileBase _missile = Instantiate(Missiles[type],_position,_rotation).GetComponent<MissileBase>();
        AddMissile(_id,_missile);
        if(_fromClient!= -1)
            _missile.SetParent(players[_fromClient].gameObject);
    }
    public static void AddMissile(int _id,MissileBase _missile)
    {
        if (missiles.ContainsKey(_id))
        {
            missiles[_id].isKill();
            
        }
        
        _missile.id = _id;
        missiles.Add(_id,_missile);
        
    }
    public void SpawnPickup(int _id,int _type,Vector3 _position)
    {
        Pickup _pickup = Instantiate(Pickups[_type],_position,Quaternion.identity).GetComponent<Pickup>();
        AddPickup(_id,_pickup);
    }
    public static void AddPickup(int _id,Pickup _pickup)
    {
        if (pickups.ContainsKey(_id))
        {
            pickups[_id].isKill();

        }

        _pickup.id = _id;
        pickups.Add(_id,_pickup);

    }
}
