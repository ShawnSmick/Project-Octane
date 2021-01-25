using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public enum AA
{
    RearFire=1,
    Jump,
    Freeze
}
public class PlayerController : MonoBehaviour
{
    public float time = 0;
    public float time2 = 0;
    
    bool[] inputs;
    public Text AmmoText;
    public Text AmmoAmountText;
    public Text HealthText;
    public Slider healthSlider;
    public Text TurboText;
    public Slider TurboSlider;
    public Text EnergyText;
    public Slider EnergySlider;
    
    public bool wedgeAccel = false;
    PlayerControls controls;
    public ParticleSystem boosting;
    float AccelMultiTapTime = -100;
    float AAMultiTapTime = -100;
    Vector2 AALast = new Vector2();
    PlayerManager manager;
    CarEngine child;
    private void Awake()
    {
        child = GetComponent<CarEngine>();
        manager = GetComponent<PlayerManager>();
        controls = new PlayerControls();
        inputs = new bool[32];

        controls.Gameplay.Accelerate2.performed += ctx => {
            inputs[0] = true;
            if (AccelMultiTapTime + 0.4f > Time.time)
            {
                inputs[4] = true;
               
                AccelMultiTapTime = -100;
                
            }
            else
            {
                AccelMultiTapTime = Time.time;
            }
           
            
        };
        controls.Gameplay.Accelerate2.canceled += ctx => { inputs[0] = false; inputs[4] = false; };
        controls.Gameplay.AdvancedMoves.performed += ctx => {
            Debug.Log(ctx.ReadValue<Vector2>().y +":" + ctx.ReadValue<Vector2>().x);
            if (AAMultiTapTime + 0.4f > Time.time)
            {
                Debug.Log("ExcecutingAA");
                ExecuteAA(ctx.ReadValue<Vector2>());
                AAMultiTapTime = -100;
            }
            else
            {
                Debug.Log("Storing");
                AALast = ctx.ReadValue<Vector2>();
                AAMultiTapTime = Time.time;
            }
        };
        //controls.Gameplay.Turn.performed += ctx => { inputs[2] = ctx.ReadValue<Vector2>().x <0; inputs[3] = ctx.ReadValue<Vector2>().x > 0; };
        controls.Gameplay.FastTurn.performed += ctx => inputs[5] = true;
        controls.Gameplay.FastTurn.canceled += ctx => inputs[5] = false;
        controls.Gameplay.Boost.performed += ctx => { inputs[4] = true;  };
        controls.Gameplay.Boost.canceled += ctx => { inputs[4] = false;  };
        controls.Gameplay.CycleRight.performed += ctx => { if (controls.Gameplay.CycleLeft.ReadValue<float>() > 0) ExecuteAA((int)AA.Jump); CycleAmmo(); };
        controls.Gameplay.CycleLeft.performed += ctx => {
            if (controls.Gameplay.CycleRight.ReadValue<float>() > 0)
                ExecuteAA((int) AA.Jump); 
            CycleAmmoBack(); };
        controls.Gameplay.MainWeapon.performed += ctx => inputs[6] = true;
        controls.Gameplay.MainWeapon.canceled += ctx => inputs[6] = false;
        controls.Gameplay.SecondaryWeapon.performed += ctx => inputs[7] = true;
        controls.Gameplay.SecondaryWeapon.canceled += ctx => inputs[7] = false;
    }
    private void SetHealth(int Health)
    {
        if (Health > healthSlider.maxValue)
        {
            healthSlider.maxValue = Health;
        }
        healthSlider.value = Health;
    }
    private void SetTurbo(float _turbo)
    {
        if (_turbo > TurboSlider.maxValue)
        {
            TurboSlider.maxValue = _turbo;
        }
        TurboSlider.value = _turbo;
    }
    private void SetEnergy(int _energy)
    {
        if (_energy > EnergySlider.maxValue)
        {
            EnergySlider.maxValue = _energy;
        }
        EnergySlider.value = _energy;
    }
    private void ExecuteAA(int _AA)
    {

                Debug.Log("Quick AA");
                ClientSend.AA(_AA,GameManager.instance.currentAmmo);
  
        
    }
    private void ExecuteAA(Vector2 _AA)
    {
        
        if (AALast.y < -.5f && _AA.y < -.5f)
        {
            Debug.Log("Rear Fire!!!!");
            ClientSend.AA((int)AA.RearFire,GameManager.instance.currentAmmo);
        }
        if (AALast.y > .5f && _AA.y > .5f)
        {
            Debug.Log("Rear Fire!!!!");
            ClientSend.AA((int) AA.Freeze,GameManager.instance.currentAmmo);
        }
    }
    private void FixedUpdate()
    {
        SendInputToServer();
        time2 = Time.time - 3f;
        if (time < time2)
        {

            ClientSend.Ping();
            time = Time.time;
        }
        child.SetInputs(inputs,inputs[0] ? 1f : controls.Gameplay.Accelerate.ReadValue<Vector2>().y,controls.Gameplay.Turn.ReadValue<Vector2>().x);
    }
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    private void Update()
    {
        /*  if (Input.GetKeyDown(KeyCode.E))
          {
              CycleAmmo();
          }
          if (Input.GetKeyDown(KeyCode.Q))
          {
              CycleAmmoBack();
          }*/
        
        if (inputs[4] && manager.Turbo > Mathf.Epsilon)
        {
            if(!boosting.isPlaying)
                boosting.Play();
        }
        else
        {
            boosting.Stop();
        }
        AmmoText.text = $"Ammo Type : {GameManager.instance.MissileNames[GameManager.instance.currentAmmo]}";
        AmmoAmountText.text = $"Ammo Amount : {GameManager.instance.Ammo[GameManager.instance.currentAmmo]}";
        HealthText.text = $"{manager.Health}";
        SetHealth(manager.Health);
        TurboText.text = $"{(float)Mathf.Round(manager.Turbo*100)/100} secs";
        SetTurbo(manager.Turbo);
        EnergyText.text = $"{manager.Energy}";
        SetEnergy(manager.Energy);
        
    }
    private void SendInputToServer()
    {
        // inputs[0] = controls.Gameplay.Accelerate.ReadValue<float>() > 0.5f;

        //Debug.Log(controls.Gameplay.Accelerate.ReadValue<float>());
        inputs[2] = controls.Gameplay.Turn.ReadValue<Vector2>().x < 0;
        inputs[3] = controls.Gameplay.Turn.ReadValue<Vector2>().x > 0;

        ClientSend.PlayerMovement(inputs,GameManager.instance.currentAmmo,controls.Gameplay.Turn.ReadValue < Vector2 > ().x,inputs[0] ? 1f : controls.Gameplay.Accelerate.ReadValue < Vector2 > ().y);
    }
    public void CycleAmmo()
    {
        CycleAmmo(GameManager.instance.currentAmmo);
    }
    private void CycleAmmoBack()
    {
        CycleAmmoBack(GameManager.instance.currentAmmo);
    }
    private void CycleAmmo(int start)
    {
        GameManager.instance.currentAmmo++;
        if (GameManager.instance.currentAmmo >= GameManager.instance.Missiles.Length)
        {
            GameManager.instance.currentAmmo = 1;
        }
        if (GameManager.instance.Ammo[GameManager.instance.currentAmmo] == 0 && GameManager.instance.currentAmmo != start)
        {
            CycleAmmo(start);
        }
    }
    private void CycleAmmoBack(int start)
    {
        GameManager.instance.currentAmmo--;
        if (GameManager.instance.currentAmmo < 1)
        {
            GameManager.instance.currentAmmo = GameManager.instance.Missiles.Length-1;
        }
        if (GameManager.instance.Ammo[GameManager.instance.currentAmmo] == 0 && GameManager.instance.currentAmmo != start)
        {
            CycleAmmoBack(start);
        }
    }
  
}
