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
                    ""name"": ""BrakeCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""ce31eaac-89cb-43ff-9d85-35e52a0d003f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnRightCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""ae27927e-dcef-49c6-b990-d36192c14793"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnLeftCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""30f67097-009e-487e-8350-c0e271d66421"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AccelerateCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""3727ef0b-e495-4341-aaae-8dce1e5fbce2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PhoneOutInCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""81db9e80-2761-43b8-9d3f-fa8c82f8c2ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""navigateUIUpCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""00534eff-b106-4ac2-82fb-ffb0a478a9bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""navigateUIRightCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""1525414c-0015-4ced-98c9-67114093a332"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""navigateUIDownCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""49fc7d99-dcd2-4fff-adbe-1101ff5d2dca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""navigateUILeftCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""96e3032c-1def-4351-bf52-8f3fe9d90c13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuItemSelectionCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""d8a70795-3793-4a6d-9980-74a35ea70b41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""cdc4f854-8089-4e04-a1ae-38d9bb222700"",
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
                    ""action"": ""BrakeCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53e92038-22f9-47c0-8e0c-776dc7a42af1"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""BrakeCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0c759c9-d82f-4873-98f2-21778f461c89"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""BrakeCallbackInputs"",
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
                    ""action"": ""TurnRightCallbackInputs"",
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
                    ""action"": ""TurnRightCallbackInputs"",
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
                    ""action"": ""TurnLeftCallbackInputs"",
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
                    ""action"": ""TurnLeftCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""302dcfa9-688f-44ef-aafb-d5c3810bf505"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AccelerateCallbackInputs"",
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
                    ""action"": ""AccelerateCallbackInputs"",
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
                    ""action"": ""PhoneOutInCallbackInputs"",
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
                    ""action"": ""navigateUIUpCallbackInputs"",
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
                    ""action"": ""navigateUIRightCallbackInputs"",
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
                    ""action"": ""navigateUIDownCallbackInputs"",
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
                    ""action"": ""navigateUILeftCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d403524-51ce-4c29-8a57-a40e2f0bcf74"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""AccelerateCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed9fc1d4-c92d-421f-8bf4-085f847b8d1e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MenuItemSelectionCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9a0b28c-5938-43ab-978f-7c20f113c55a"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""MenuItemSelectionCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2719e938-290a-4f8d-bc1c-2cbd3fcdbead"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""New action"",
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
        },
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Game Play
        m_GamePlay = asset.FindActionMap("Game Play", throwIfNotFound: true);
        m_GamePlay_BrakeCallbackInputs = m_GamePlay.FindAction("BrakeCallbackInputs", throwIfNotFound: true);
        m_GamePlay_TurnRightCallbackInputs = m_GamePlay.FindAction("TurnRightCallbackInputs", throwIfNotFound: true);
        m_GamePlay_TurnLeftCallbackInputs = m_GamePlay.FindAction("TurnLeftCallbackInputs", throwIfNotFound: true);
        m_GamePlay_AccelerateCallbackInputs = m_GamePlay.FindAction("AccelerateCallbackInputs", throwIfNotFound: true);
        m_GamePlay_PhoneOutInCallbackInputs = m_GamePlay.FindAction("PhoneOutInCallbackInputs", throwIfNotFound: true);
        m_GamePlay_navigateUIUpCallbackInputs = m_GamePlay.FindAction("navigateUIUpCallbackInputs", throwIfNotFound: true);
        m_GamePlay_navigateUIRightCallbackInputs = m_GamePlay.FindAction("navigateUIRightCallbackInputs", throwIfNotFound: true);
        m_GamePlay_navigateUIDownCallbackInputs = m_GamePlay.FindAction("navigateUIDownCallbackInputs", throwIfNotFound: true);
        m_GamePlay_navigateUILeftCallbackInputs = m_GamePlay.FindAction("navigateUILeftCallbackInputs", throwIfNotFound: true);
        m_GamePlay_MenuItemSelectionCallbackInputs = m_GamePlay.FindAction("MenuItemSelectionCallbackInputs", throwIfNotFound: true);
        m_GamePlay_Newaction = m_GamePlay.FindAction("New action", throwIfNotFound: true);
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
    private readonly InputAction m_GamePlay_BrakeCallbackInputs;
    private readonly InputAction m_GamePlay_TurnRightCallbackInputs;
    private readonly InputAction m_GamePlay_TurnLeftCallbackInputs;
    private readonly InputAction m_GamePlay_AccelerateCallbackInputs;
    private readonly InputAction m_GamePlay_PhoneOutInCallbackInputs;
    private readonly InputAction m_GamePlay_navigateUIUpCallbackInputs;
    private readonly InputAction m_GamePlay_navigateUIRightCallbackInputs;
    private readonly InputAction m_GamePlay_navigateUIDownCallbackInputs;
    private readonly InputAction m_GamePlay_navigateUILeftCallbackInputs;
    private readonly InputAction m_GamePlay_MenuItemSelectionCallbackInputs;
    private readonly InputAction m_GamePlay_Newaction;
    public struct GamePlayActions
    {
        private @PlayerControls m_Wrapper;
        public GamePlayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @BrakeCallbackInputs => m_Wrapper.m_GamePlay_BrakeCallbackInputs;
        public InputAction @TurnRightCallbackInputs => m_Wrapper.m_GamePlay_TurnRightCallbackInputs;
        public InputAction @TurnLeftCallbackInputs => m_Wrapper.m_GamePlay_TurnLeftCallbackInputs;
        public InputAction @AccelerateCallbackInputs => m_Wrapper.m_GamePlay_AccelerateCallbackInputs;
        public InputAction @PhoneOutInCallbackInputs => m_Wrapper.m_GamePlay_PhoneOutInCallbackInputs;
        public InputAction @navigateUIUpCallbackInputs => m_Wrapper.m_GamePlay_navigateUIUpCallbackInputs;
        public InputAction @navigateUIRightCallbackInputs => m_Wrapper.m_GamePlay_navigateUIRightCallbackInputs;
        public InputAction @navigateUIDownCallbackInputs => m_Wrapper.m_GamePlay_navigateUIDownCallbackInputs;
        public InputAction @navigateUILeftCallbackInputs => m_Wrapper.m_GamePlay_navigateUILeftCallbackInputs;
        public InputAction @MenuItemSelectionCallbackInputs => m_Wrapper.m_GamePlay_MenuItemSelectionCallbackInputs;
        public InputAction @Newaction => m_Wrapper.m_GamePlay_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @BrakeCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBrakeCallbackInputs;
                @BrakeCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBrakeCallbackInputs;
                @BrakeCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBrakeCallbackInputs;
                @TurnRightCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnRightCallbackInputs;
                @TurnRightCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnRightCallbackInputs;
                @TurnRightCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnRightCallbackInputs;
                @TurnLeftCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnLeftCallbackInputs;
                @TurnLeftCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnLeftCallbackInputs;
                @TurnLeftCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnTurnLeftCallbackInputs;
                @AccelerateCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerateCallbackInputs;
                @AccelerateCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerateCallbackInputs;
                @AccelerateCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAccelerateCallbackInputs;
                @PhoneOutInCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPhoneOutInCallbackInputs;
                @PhoneOutInCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPhoneOutInCallbackInputs;
                @PhoneOutInCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPhoneOutInCallbackInputs;
                @navigateUIUpCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIUpCallbackInputs;
                @navigateUIUpCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIUpCallbackInputs;
                @navigateUIUpCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIUpCallbackInputs;
                @navigateUIRightCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIRightCallbackInputs;
                @navigateUIRightCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIRightCallbackInputs;
                @navigateUIRightCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIRightCallbackInputs;
                @navigateUIDownCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIDownCallbackInputs;
                @navigateUIDownCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIDownCallbackInputs;
                @navigateUIDownCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUIDownCallbackInputs;
                @navigateUILeftCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUILeftCallbackInputs;
                @navigateUILeftCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUILeftCallbackInputs;
                @navigateUILeftCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigateUILeftCallbackInputs;
                @MenuItemSelectionCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMenuItemSelectionCallbackInputs;
                @MenuItemSelectionCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMenuItemSelectionCallbackInputs;
                @MenuItemSelectionCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMenuItemSelectionCallbackInputs;
                @Newaction.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @BrakeCallbackInputs.started += instance.OnBrakeCallbackInputs;
                @BrakeCallbackInputs.performed += instance.OnBrakeCallbackInputs;
                @BrakeCallbackInputs.canceled += instance.OnBrakeCallbackInputs;
                @TurnRightCallbackInputs.started += instance.OnTurnRightCallbackInputs;
                @TurnRightCallbackInputs.performed += instance.OnTurnRightCallbackInputs;
                @TurnRightCallbackInputs.canceled += instance.OnTurnRightCallbackInputs;
                @TurnLeftCallbackInputs.started += instance.OnTurnLeftCallbackInputs;
                @TurnLeftCallbackInputs.performed += instance.OnTurnLeftCallbackInputs;
                @TurnLeftCallbackInputs.canceled += instance.OnTurnLeftCallbackInputs;
                @AccelerateCallbackInputs.started += instance.OnAccelerateCallbackInputs;
                @AccelerateCallbackInputs.performed += instance.OnAccelerateCallbackInputs;
                @AccelerateCallbackInputs.canceled += instance.OnAccelerateCallbackInputs;
                @PhoneOutInCallbackInputs.started += instance.OnPhoneOutInCallbackInputs;
                @PhoneOutInCallbackInputs.performed += instance.OnPhoneOutInCallbackInputs;
                @PhoneOutInCallbackInputs.canceled += instance.OnPhoneOutInCallbackInputs;
                @navigateUIUpCallbackInputs.started += instance.OnNavigateUIUpCallbackInputs;
                @navigateUIUpCallbackInputs.performed += instance.OnNavigateUIUpCallbackInputs;
                @navigateUIUpCallbackInputs.canceled += instance.OnNavigateUIUpCallbackInputs;
                @navigateUIRightCallbackInputs.started += instance.OnNavigateUIRightCallbackInputs;
                @navigateUIRightCallbackInputs.performed += instance.OnNavigateUIRightCallbackInputs;
                @navigateUIRightCallbackInputs.canceled += instance.OnNavigateUIRightCallbackInputs;
                @navigateUIDownCallbackInputs.started += instance.OnNavigateUIDownCallbackInputs;
                @navigateUIDownCallbackInputs.performed += instance.OnNavigateUIDownCallbackInputs;
                @navigateUIDownCallbackInputs.canceled += instance.OnNavigateUIDownCallbackInputs;
                @navigateUILeftCallbackInputs.started += instance.OnNavigateUILeftCallbackInputs;
                @navigateUILeftCallbackInputs.performed += instance.OnNavigateUILeftCallbackInputs;
                @navigateUILeftCallbackInputs.canceled += instance.OnNavigateUILeftCallbackInputs;
                @MenuItemSelectionCallbackInputs.started += instance.OnMenuItemSelectionCallbackInputs;
                @MenuItemSelectionCallbackInputs.performed += instance.OnMenuItemSelectionCallbackInputs;
                @MenuItemSelectionCallbackInputs.canceled += instance.OnMenuItemSelectionCallbackInputs;
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
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
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnBrakeCallbackInputs(InputAction.CallbackContext context);
        void OnTurnRightCallbackInputs(InputAction.CallbackContext context);
        void OnTurnLeftCallbackInputs(InputAction.CallbackContext context);
        void OnAccelerateCallbackInputs(InputAction.CallbackContext context);
        void OnPhoneOutInCallbackInputs(InputAction.CallbackContext context);
        void OnNavigateUIUpCallbackInputs(InputAction.CallbackContext context);
        void OnNavigateUIRightCallbackInputs(InputAction.CallbackContext context);
        void OnNavigateUIDownCallbackInputs(InputAction.CallbackContext context);
        void OnNavigateUILeftCallbackInputs(InputAction.CallbackContext context);
        void OnMenuItemSelectionCallbackInputs(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
    }
}
