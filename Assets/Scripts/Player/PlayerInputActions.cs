// GENERATED AUTOMATICALLY FROM 'Assets/Resources/Miscellaneous/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace PlayerInputSystem
{
    public class @PlayerInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""702cf739-425e-40c0-9732-fd47ac3f0617"",
            ""actions"": [
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""d067e798-a51f-4de7-8cb5-84fc3fcaa25d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootBullet"",
                    ""type"": ""Button"",
                    ""id"": ""b84fcff9-ff1b-4035-bcd0-fc3cf04afd2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootLaser"",
                    ""type"": ""Button"",
                    ""id"": ""a711496a-0199-4151-89fb-e0a4ebde2b1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29cf3e85-b58a-48b3-bb9a-99b6c5c62929"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""PlayerControl"",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06343a29-8c02-4059-bf2f-bcfae157f628"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""PlayerControl"",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a51df4a-6922-4d3d-8762-b56a50180b87"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""PlayerControl"",
                    ""action"": ""ShootBullet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1809a4fa-8ff4-46cf-9b5d-e51b9be6c167"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""PlayerControl"",
                    ""action"": ""ShootLaser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlayerControl"",
            ""bindingGroup"": ""PlayerControl"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_MoveForward = m_Player.FindAction("MoveForward", throwIfNotFound: true);
            m_Player_ShootBullet = m_Player.FindAction("ShootBullet", throwIfNotFound: true);
            m_Player_ShootLaser = m_Player.FindAction("ShootLaser", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_MoveForward;
        private readonly InputAction m_Player_ShootBullet;
        private readonly InputAction m_Player_ShootLaser;
        public struct PlayerActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveForward => m_Wrapper.m_Player_MoveForward;
            public InputAction @ShootBullet => m_Wrapper.m_Player_ShootBullet;
            public InputAction @ShootLaser => m_Wrapper.m_Player_ShootLaser;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @MoveForward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveForward;
                    @MoveForward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveForward;
                    @MoveForward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveForward;
                    @ShootBullet.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootBullet;
                    @ShootBullet.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootBullet;
                    @ShootBullet.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootBullet;
                    @ShootLaser.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootLaser;
                    @ShootLaser.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootLaser;
                    @ShootLaser.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootLaser;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveForward.started += instance.OnMoveForward;
                    @MoveForward.performed += instance.OnMoveForward;
                    @MoveForward.canceled += instance.OnMoveForward;
                    @ShootBullet.started += instance.OnShootBullet;
                    @ShootBullet.performed += instance.OnShootBullet;
                    @ShootBullet.canceled += instance.OnShootBullet;
                    @ShootLaser.started += instance.OnShootLaser;
                    @ShootLaser.performed += instance.OnShootLaser;
                    @ShootLaser.canceled += instance.OnShootLaser;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        private int m_PlayerControlSchemeIndex = -1;
        public InputControlScheme PlayerControlScheme
        {
            get
            {
                if (m_PlayerControlSchemeIndex == -1) m_PlayerControlSchemeIndex = asset.FindControlSchemeIndex("PlayerControl");
                return asset.controlSchemes[m_PlayerControlSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnMoveForward(InputAction.CallbackContext context);
            void OnShootBullet(InputAction.CallbackContext context);
            void OnShootLaser(InputAction.CallbackContext context);
        }
    }
}
