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
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""3727ef0b-e495-4341-aaae-8dce1e5fbce2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PhoneOutIn"",
                    ""type"": ""Button"",
                    ""id"": ""81db9e80-2761-43b8-9d3f-fa8c82f8c2ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""navigateUIUp"",
                    ""type"": ""Button"",
                    ""id"": ""00534eff-b106-4ac2-82fb-ffb0a478a9bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""navigateUIRight"",
                    ""type"": ""Button"",
                    ""id"": ""1525414c-0015-4ced-98c9-67114093a332"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""navigateUIDown"",
                    ""type"": ""Button"",
                    ""id"": ""49fc7d99-dcd2-4fff-adbe-1101ff5d2dca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""navigateUILeft"",
                    ""type"": ""Button"",
                    ""id"": ""96e3032c-1def-4351-bf52-8f3fe9d90c13"",
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
                    ""id"": ""c0c759c9-d82f-4873-98f2-21778f461c89"",
                    ""path"": ""<Keyboard>/k"",
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
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f017667d-9462-4578-b980-849d38168b2a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61f993ba-1a0f-444d-af9f-e3d7c686f06c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PhoneOutIn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba289ce8-3860-407a-95e8-3c0cfe0d53fb"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""navigateUIUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94d90e01-94e8-4f31-ab0a-25bdddb81148"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""navigateUIRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f68ec0c8-82ae-4cf0-a4e6-c85699da66d9"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""navigateUIDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98ce9792-4f43-4e59-8fba-8a8857e6ebd1"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""navigateUILeft"",
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
        m_GamePlay_Brake = m_GamePlay.FindAction("Brake", throwIfNotFound: true);
        m_GamePlay_TurnRight = m_GamePlay.FindAction("TurnRight", throwIfNotFound: true);
        m_GamePlay_TurnLeft = m_GamePlay.FindAction("TurnLeft", throwIfNotFound: true);
        m_GamePlay_Accelerate = m_GamePlay.FindAction("Accelerate", throwIfNotFound: true);
        m_GamePlay_PhoneOutIn = m_GamePlay.FindAction("PhoneOutIn", throwIfNotFound: true);
        m_GamePlay_navigateUIUp = m_GamePlay.FindAction("navigateUIUp", throwIfNotFound: true);
        m_GamePlay_navigateUIRight = m_GamePlay.FindAction("navigateUIRight", throwIfNotFound: true);
        m_GamePlay_navigateUIDown = m_GamePlay.FindAction("navigateUIDown", throwIfNotFound: true);
        m_GamePlay_navigateUILeft = m_GamePlay.FindAction("navigateUILeft", throwIfNotFound: true);
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
    private readonly InputAction m_GamePlay_Brake;
    private readonly InputAction m_GamePlay_TurnRight;
    private readonly InputAction m_GamePlay_TurnLeft;
    private readonly InputAction m_GamePlay_Accelerate;
    private readonly InputAction m_GamePlay_PhoneOutIn;
    private readonly InputAction m_GamePlay_navigateUIUp;
    private readonly InputAction m_GamePlay_navigateUIRight;
    private readonly InputAction m_GamePlay_navigateUIDown;
    private readonly InputAction m_GamePlay_navigateUILeft;
    public struct GamePlayActions
    {
        private @PlayerControls m_Wrapper;
        public GamePlayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Brake => m_Wrapper.m_GamePlay_Brake;
        public InputAction @TurnRight => m_Wrapper.m_GamePlay_TurnRight;
        public InputAction @TurnLeft => m_Wrapper.m_GamePlay_TurnLeft;
        public InputAction @Accelerate => m_Wrapper.m_GamePlay_Accelerate;
        public InputAction @PhoneOutIn => m_Wrapper.m_GamePlay_PhoneOutIn;
        public InputAction @navigateUIUp => m_Wrapper.m_GamePlay_navigateUIUp;
        public InputAction @navigateUIRight => m_Wrapper.m_GamePlay_navigateUIRight;
        public InputAction @navigateUIDown => m_Wrapper.m_GamePlay_navigateUIDown;
        public InputAction @navigateUILeft => m_Wrapper.m_GamePlay_navigateUILeft;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Brake.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBrake;
                @TurnRight.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnRight;
                @TurnRight.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnRight;
                @TurnRight.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnRight;
                @TurnLeft.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnLeft;
                @Accelerate.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerate;
                @PhoneOutIn.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPhoneOutIn;
                @PhoneOutIn.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPhoneOutIn;
                @PhoneOutIn.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPhoneOutIn;
                @navigateUIUp.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIUp;
                @navigateUIUp.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIUp;
                @navigateUIUp.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIUp;
                @navigateUIRight.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIRight;
                @navigateUIRight.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIRight;
                @navigateUIRight.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIRight;
                @navigateUIDown.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIDown;
                @navigateUIDown.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIDown;
                @navigateUIDown.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIDown;
                @navigateUILeft.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUILeft;
                @navigateUILeft.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUILeft;
                @navigateUILeft.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUILeft;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @TurnRight.started += instance.OnTurnRight;
                @TurnRight.performed += instance.OnTurnRight;
                @TurnRight.canceled += instance.OnTurnRight;
                @TurnLeft.started += instance.OnTurnLeft;
                @TurnLeft.performed += instance.OnTurnLeft;
                @TurnLeft.canceled += instance.OnTurnLeft;
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @PhoneOutIn.started += instance.OnPhoneOutIn;
                @PhoneOutIn.performed += instance.OnPhoneOutIn;
                @PhoneOutIn.canceled += instance.OnPhoneOutIn;
                @navigateUIUp.started += instance.OnNavigateUIUp;
                @navigateUIUp.performed += instance.OnNavigateUIUp;
                @navigateUIUp.canceled += instance.OnNavigateUIUp;
                @navigateUIRight.started += instance.OnNavigateUIRight;
                @navigateUIRight.performed += instance.OnNavigateUIRight;
                @navigateUIRight.canceled += instance.OnNavigateUIRight;
                @navigateUIDown.started += instance.OnNavigateUIDown;
                @navigateUIDown.performed += instance.OnNavigateUIDown;
                @navigateUIDown.canceled += instance.OnNavigateUIDown;
                @navigateUILeft.started += instance.OnNavigateUILeft;
                @navigateUILeft.performed += instance.OnNavigateUILeft;
                @navigateUILeft.canceled += instance.OnNavigateUILeft;
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
        void OnBrake(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
        void OnPhoneOutIn(InputAction.CallbackContext context);
        void OnNavigateUIUp(InputAction.CallbackContext context);
        void OnNavigateUIRight(InputAction.CallbackContext context);
        void OnNavigateUIDown(InputAction.CallbackContext context);
        void OnNavigateUILeft(InputAction.CallbackContext context);
    }
}
