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
            ""name"": ""PlayerMoment"",
            ""id"": ""2b6ebe38-1a9a-4a3b-a082-d2d2c2d06d81"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""9bbf9f5c-772a-4b36-80e5-20e36d93e013"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6b7507e9-ff44-402c-baa0-3e79e0299271"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""4957d509-c9a8-4dcf-a0e7-61c7e7ecb8f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""8b672f39-9870-4650-9638-d33816c76302"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""c2c847ff-416c-41d8-89d7-d9b253da7f45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""2de43414-d5d7-4c17-bdf0-9f9c0ab2222c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""fe370991-fe14-4bdf-b81e-3c29e79c2771"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""039d81f2-e6c6-49e7-beae-04dc5ed6e1ea"",
                    ""path"": ""<XInputController>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e311d94b-d53b-4aad-980d-e82f37e985ec"",
                    ""path"": ""<XInputController>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0ede8773-5836-414d-b887-971fb5a597d6"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a1673e7-6cfa-439f-af24-747d22bee40e"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5ebbec2-6366-4248-b973-0b161415bf5e"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""316d42ac-51e8-4b2c-991c-6b53fcca0f84"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ff42132-02db-432f-88a1-ac447a6d3115"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMoment
        m_PlayerMoment = asset.FindActionMap("PlayerMoment", throwIfNotFound: true);
        m_PlayerMoment_Move = m_PlayerMoment.FindAction("Move", throwIfNotFound: true);
        m_PlayerMoment_Jump = m_PlayerMoment.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMoment_Attack = m_PlayerMoment.FindAction("Attack", throwIfNotFound: true);
        m_PlayerMoment_Shoot = m_PlayerMoment.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerMoment_Crouch = m_PlayerMoment.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerMoment_Dodge = m_PlayerMoment.FindAction("Dodge", throwIfNotFound: true);
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

    // PlayerMoment
    private readonly InputActionMap m_PlayerMoment;
    private IPlayerMomentActions m_PlayerMomentActionsCallbackInterface;
    private readonly InputAction m_PlayerMoment_Move;
    private readonly InputAction m_PlayerMoment_Jump;
    private readonly InputAction m_PlayerMoment_Attack;
    private readonly InputAction m_PlayerMoment_Shoot;
    private readonly InputAction m_PlayerMoment_Crouch;
    private readonly InputAction m_PlayerMoment_Dodge;
    public struct PlayerMomentActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMomentActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMoment_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerMoment_Jump;
        public InputAction @Attack => m_Wrapper.m_PlayerMoment_Attack;
        public InputAction @Shoot => m_Wrapper.m_PlayerMoment_Shoot;
        public InputAction @Crouch => m_Wrapper.m_PlayerMoment_Crouch;
        public InputAction @Dodge => m_Wrapper.m_PlayerMoment_Dodge;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMoment; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMomentActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMomentActions instance)
        {
            if (m_Wrapper.m_PlayerMomentActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnAttack;
                @Shoot.started -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnShoot;
                @Crouch.started -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnCrouch;
                @Dodge.started -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_PlayerMomentActionsCallbackInterface.OnDodge;
            }
            m_Wrapper.m_PlayerMomentActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
            }
        }
    }
    public PlayerMomentActions @PlayerMoment => new PlayerMomentActions(this);
    public interface IPlayerMomentActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
    }
}