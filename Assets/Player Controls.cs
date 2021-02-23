// GENERATED AUTOMATICALLY FROM 'Assets/Player Controls.inputactions'

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
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Game Play"",
            ""id"": ""0610ce19-76bd-47ba-8b24-669820581245"",
            ""actions"": [
                {
                    ""name"": ""AccelerateStick"",
                    ""type"": ""Value"",
                    ""id"": ""6d33f34e-d35b-4997-b4fc-87d157f617ff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""ce31eaac-89cb-43ff-9d85-35e52a0d003f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnRight"",
                    ""type"": ""Button"",
                    ""id"": ""ae27927e-dcef-49c6-b990-d36192c14793"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""30f67097-009e-487e-8350-c0e271d66421"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AccelerateKeyboard"",
                    ""type"": ""Button"",
                    ""id"": ""3727ef0b-e495-4341-aaae-8dce1e5fbce2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ReverseKeyboard"",
                    ""type"": ""Button"",
                    ""id"": ""dd5e320a-bd1d-4b7f-bac2-c370ddecf212"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""97cdcc78-c364-48e6-a313-1ad5857e1d40"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53e92038-22f9-47c0-8e0c-776dc7a42af1"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d10f397e-af29-4984-b655-d1620432b138"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f04fbcb-fcea-470c-ad17-3872889d20f7"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4085755-5504-467d-8028-4472db514335"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a2b35ae-dd07-4f2a-b4a6-d954b38277a6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""302dcfa9-688f-44ef-aafb-d5c3810bf505"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AccelerateKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9691cff-6abf-428c-97e0-dffbbb591c22"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReverseKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""142ec0fc-caf0-4c47-a734-80151827d5b6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.8,max=0.97)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AccelerateStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Game Play
        m_GamePlay = asset.FindActionMap("Game Play", throwIfNotFound: true);
        m_GamePlay_AccelerateStick = m_GamePlay.FindAction("AccelerateStick", throwIfNotFound: true);
        m_GamePlay_Brake = m_GamePlay.FindAction("Brake", throwIfNotFound: true);
        m_GamePlay_TurnRight = m_GamePlay.FindAction("TurnRight", throwIfNotFound: true);
        m_GamePlay_TurnLeft = m_GamePlay.FindAction("TurnLeft", throwIfNotFound: true);
        m_GamePlay_AccelerateKeyboard = m_GamePlay.FindAction("AccelerateKeyboard", throwIfNotFound: true);
        m_GamePlay_ReverseKeyboard = m_GamePlay.FindAction("ReverseKeyboard", throwIfNotFound: true);
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

    // Game Play
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_AccelerateStick;
    private readonly InputAction m_GamePlay_Brake;
    private readonly InputAction m_GamePlay_TurnRight;
    private readonly InputAction m_GamePlay_TurnLeft;
    private readonly InputAction m_GamePlay_AccelerateKeyboard;
    private readonly InputAction m_GamePlay_ReverseKeyboard;
    public struct GamePlayActions
    {
        private @PlayerControls m_Wrapper;
        public GamePlayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @AccelerateStick => m_Wrapper.m_GamePlay_AccelerateStick;
        public InputAction @Brake => m_Wrapper.m_GamePlay_Brake;
        public InputAction @TurnRight => m_Wrapper.m_GamePlay_TurnRight;
        public InputAction @TurnLeft => m_Wrapper.m_GamePlay_TurnLeft;
        public InputAction @AccelerateKeyboard => m_Wrapper.m_GamePlay_AccelerateKeyboard;
        public InputAction @ReverseKeyboard => m_Wrapper.m_GamePlay_ReverseKeyboard;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @AccelerateStick.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerateStick;
                @AccelerateStick.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerateStick;
                @AccelerateStick.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerateStick;
                @Brake.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBrake;
                @TurnRight.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnRight;
                @TurnRight.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnRight;
                @TurnRight.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnRight;
                @TurnLeft.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnLeft;
                @AccelerateKeyboard.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerateKeyboard;
                @AccelerateKeyboard.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerateKeyboard;
                @AccelerateKeyboard.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerateKeyboard;
                @ReverseKeyboard.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnReverseKeyboard;
                @ReverseKeyboard.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnReverseKeyboard;
                @ReverseKeyboard.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnReverseKeyboard;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AccelerateStick.started += instance.OnAccelerateStick;
                @AccelerateStick.performed += instance.OnAccelerateStick;
                @AccelerateStick.canceled += instance.OnAccelerateStick;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @TurnRight.started += instance.OnTurnRight;
                @TurnRight.performed += instance.OnTurnRight;
                @TurnRight.canceled += instance.OnTurnRight;
                @TurnLeft.started += instance.OnTurnLeft;
                @TurnLeft.performed += instance.OnTurnLeft;
                @TurnLeft.canceled += instance.OnTurnLeft;
                @AccelerateKeyboard.started += instance.OnAccelerateKeyboard;
                @AccelerateKeyboard.performed += instance.OnAccelerateKeyboard;
                @AccelerateKeyboard.canceled += instance.OnAccelerateKeyboard;
                @ReverseKeyboard.started += instance.OnReverseKeyboard;
                @ReverseKeyboard.performed += instance.OnReverseKeyboard;
                @ReverseKeyboard.canceled += instance.OnReverseKeyboard;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnAccelerateStick(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnAccelerateKeyboard(InputAction.CallbackContext context);
        void OnReverseKeyboard(InputAction.CallbackContext context);
    }
}
