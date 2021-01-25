// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""33c18431-a16a-404b-b457-09fd18270f42"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Value"",
                    ""id"": ""06661ebb-abeb-4687-b1a0-2899a8eef2af"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn"",
                    ""type"": ""Value"",
                    ""id"": ""42b2a4b2-3fe5-4350-85fc-5a86b0a93310"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FastTurn"",
                    ""type"": ""Button"",
                    ""id"": ""db1d993b-b8c2-401a-8f96-f68b0f5a2ed0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""2aaa4359-7207-46f9-99f9-2482802e041f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cycle Right"",
                    ""type"": ""Button"",
                    ""id"": ""a63c641b-ad48-445f-963f-dd82ac4567ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cycle Left"",
                    ""type"": ""Button"",
                    ""id"": ""f8c69f28-2810-48ec-a1d5-715dfe34c9b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Main Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""e91bf83c-2cf2-41b7-9d20-7c37c4761ed8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""b07a060e-444e-4cfb-850b-a85eeb2d49c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerate2"",
                    ""type"": ""Button"",
                    ""id"": ""4c419a85-a6c2-4cd1-839d-cd6b2f220c85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AdvancedMoves"",
                    ""type"": ""Value"",
                    ""id"": ""789dbb0e-3624-4340-8bfc-ad40ad35d801"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dab7b34b-e2c0-4531-ab14-f41150f68452"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fa0db943-0630-4d25-a5d7-010c3d892087"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c5548282-1892-4ce7-aaec-b09e4a1fbf3a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2ffb7514-1912-402a-8b41-d00e936afc7a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b446d295-0025-41b3-861d-0f8dc69f7e03"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0ec17220-624a-48db-b9ad-205969a1a7cd"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""73741c55-5a9e-411c-b1c7-1bd5c49d6a97"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b5d58f25-c115-474e-91a0-05ab9a92539f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""3dd0abb1-a28d-47a2-9a81-8f05ea421cf0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""950b9a29-ab20-469e-b544-48eb4fe94202"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c87486ce-013f-43cd-b3c1-6fa044a19433"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FastTurn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d05ea523-a021-4fa3-a515-9b4d4d6772c4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FastTurn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2c06080-5231-4e19-9661-290d4a57b099"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FastTurn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0756cf83-4f36-429e-bf5c-ef9d7fee21ed"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df0e1ebd-a565-4fe4-b1f5-147564db4829"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47655a29-374b-4276-85ea-33a315cdb220"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cycle Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11e1c604-10f9-4f0d-9dd7-17560cfa2de8"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cycle Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f09ec67-2d07-4514-9f77-f6d82bbbae42"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cycle Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8bf8384-4dc0-4fd7-9a1e-d70f7b54aca8"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cycle Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebd1aabb-9d78-4104-a1ad-e3e19d3d9129"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Main Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ce79d7f-38a7-4a13-9957-6f8401692f7a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Main Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34a91423-db5a-4b2e-95fb-6b1874378cfb"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de4a057b-d498-45e6-ae4a-c16690d5cf17"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c15e56c-0dda-4adf-a525-615ef17b21d6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3897be4a-0d0f-4403-8a8a-c648556efb04"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d3092e3-435a-4a77-8be5-3228aa31de1e"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdvancedMoves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2e1fe527-b028-4798-8313-d5bb2197332b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdvancedMoves"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9e3171e1-f404-4433-87b9-a3f11329c164"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdvancedMoves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b0ed5ed7-5cc3-4d92-b38a-19f9fff13c80"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdvancedMoves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0191f863-b8cf-4aa9-89e0-3d0145c20aaf"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdvancedMoves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""27f38f6a-3c4b-4fa3-b9c0-c7de56be4cbe"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdvancedMoves"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Accelerate = m_Gameplay.FindAction("Accelerate", throwIfNotFound: true);
        m_Gameplay_Turn = m_Gameplay.FindAction("Turn", throwIfNotFound: true);
        m_Gameplay_FastTurn = m_Gameplay.FindAction("FastTurn", throwIfNotFound: true);
        m_Gameplay_Boost = m_Gameplay.FindAction("Boost", throwIfNotFound: true);
        m_Gameplay_CycleRight = m_Gameplay.FindAction("Cycle Right", throwIfNotFound: true);
        m_Gameplay_CycleLeft = m_Gameplay.FindAction("Cycle Left", throwIfNotFound: true);
        m_Gameplay_MainWeapon = m_Gameplay.FindAction("Main Weapon", throwIfNotFound: true);
        m_Gameplay_SecondaryWeapon = m_Gameplay.FindAction("Secondary Weapon", throwIfNotFound: true);
        m_Gameplay_Accelerate2 = m_Gameplay.FindAction("Accelerate2", throwIfNotFound: true);
        m_Gameplay_AdvancedMoves = m_Gameplay.FindAction("AdvancedMoves", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Accelerate;
    private readonly InputAction m_Gameplay_Turn;
    private readonly InputAction m_Gameplay_FastTurn;
    private readonly InputAction m_Gameplay_Boost;
    private readonly InputAction m_Gameplay_CycleRight;
    private readonly InputAction m_Gameplay_CycleLeft;
    private readonly InputAction m_Gameplay_MainWeapon;
    private readonly InputAction m_Gameplay_SecondaryWeapon;
    private readonly InputAction m_Gameplay_Accelerate2;
    private readonly InputAction m_Gameplay_AdvancedMoves;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_Gameplay_Accelerate;
        public InputAction @Turn => m_Wrapper.m_Gameplay_Turn;
        public InputAction @FastTurn => m_Wrapper.m_Gameplay_FastTurn;
        public InputAction @Boost => m_Wrapper.m_Gameplay_Boost;
        public InputAction @CycleRight => m_Wrapper.m_Gameplay_CycleRight;
        public InputAction @CycleLeft => m_Wrapper.m_Gameplay_CycleLeft;
        public InputAction @MainWeapon => m_Wrapper.m_Gameplay_MainWeapon;
        public InputAction @SecondaryWeapon => m_Wrapper.m_Gameplay_SecondaryWeapon;
        public InputAction @Accelerate2 => m_Wrapper.m_Gameplay_Accelerate2;
        public InputAction @AdvancedMoves => m_Wrapper.m_Gameplay_AdvancedMoves;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Accelerate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAccelerate;
                @Turn.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurn;
                @FastTurn.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFastTurn;
                @FastTurn.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFastTurn;
                @FastTurn.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFastTurn;
                @Boost.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBoost;
                @Boost.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBoost;
                @Boost.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBoost;
                @CycleRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCycleRight;
                @CycleRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCycleRight;
                @CycleRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCycleRight;
                @CycleLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCycleLeft;
                @CycleLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCycleLeft;
                @CycleLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCycleLeft;
                @MainWeapon.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMainWeapon;
                @MainWeapon.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMainWeapon;
                @MainWeapon.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMainWeapon;
                @SecondaryWeapon.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryWeapon;
                @SecondaryWeapon.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryWeapon;
                @SecondaryWeapon.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryWeapon;
                @Accelerate2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAccelerate2;
                @Accelerate2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAccelerate2;
                @Accelerate2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAccelerate2;
                @AdvancedMoves.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAdvancedMoves;
                @AdvancedMoves.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAdvancedMoves;
                @AdvancedMoves.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAdvancedMoves;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @FastTurn.started += instance.OnFastTurn;
                @FastTurn.performed += instance.OnFastTurn;
                @FastTurn.canceled += instance.OnFastTurn;
                @Boost.started += instance.OnBoost;
                @Boost.performed += instance.OnBoost;
                @Boost.canceled += instance.OnBoost;
                @CycleRight.started += instance.OnCycleRight;
                @CycleRight.performed += instance.OnCycleRight;
                @CycleRight.canceled += instance.OnCycleRight;
                @CycleLeft.started += instance.OnCycleLeft;
                @CycleLeft.performed += instance.OnCycleLeft;
                @CycleLeft.canceled += instance.OnCycleLeft;
                @MainWeapon.started += instance.OnMainWeapon;
                @MainWeapon.performed += instance.OnMainWeapon;
                @MainWeapon.canceled += instance.OnMainWeapon;
                @SecondaryWeapon.started += instance.OnSecondaryWeapon;
                @SecondaryWeapon.performed += instance.OnSecondaryWeapon;
                @SecondaryWeapon.canceled += instance.OnSecondaryWeapon;
                @Accelerate2.started += instance.OnAccelerate2;
                @Accelerate2.performed += instance.OnAccelerate2;
                @Accelerate2.canceled += instance.OnAccelerate2;
                @AdvancedMoves.started += instance.OnAdvancedMoves;
                @AdvancedMoves.performed += instance.OnAdvancedMoves;
                @AdvancedMoves.canceled += instance.OnAdvancedMoves;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
        void OnFastTurn(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnCycleRight(InputAction.CallbackContext context);
        void OnCycleLeft(InputAction.CallbackContext context);
        void OnMainWeapon(InputAction.CallbackContext context);
        void OnSecondaryWeapon(InputAction.CallbackContext context);
        void OnAccelerate2(InputAction.CallbackContext context);
        void OnAdvancedMoves(InputAction.CallbackContext context);
    }
}
