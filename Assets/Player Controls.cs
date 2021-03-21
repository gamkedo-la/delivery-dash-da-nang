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
                    ""name"": ""NavigatePhoneStepInCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""eeb052d3-7302-4cf4-9ffb-016e61b8fd2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavigatePhoneStepOutCallbackInputs"",
                    ""type"": ""Button"",
                    ""id"": ""aaa5a70c-3f48-43cb-8f6c-b88d6cfed737"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""97cdcc78-c364-48e6-a313-1ad5857e1d40"",
                    ""path"": ""<Gamepad>/buttonWest"",
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
                    ""id"": ""91923e9d-cdb9-4aaf-91c2-f52aa1a25d10"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
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
                    ""id"": ""c9102391-2536-4a29-8b8a-93048d130bf4"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
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
                    ""id"": ""437ef529-5ba5-49d4-9d41-e9b376df1f84"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
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
                    ""id"": ""ffda7727-aaaa-4025-ab49-f7f9cb3d6a0b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
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
                    ""id"": ""28819c24-f48a-4e4b-8ffc-8ccf7884e4cd"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NavigatePhoneStepInCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2a2cb3c-0d1c-4994-9cff-61cdc9052de9"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""NavigatePhoneStepInCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3db67aff-52d5-4508-addb-40c7552ce31e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NavigatePhoneStepOutCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a841d71a-0188-454d-8640-54af9e9f929d"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""NavigatePhoneStepOutCallbackInputs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Main Menu"",
            ""id"": ""97cce64f-284c-4ff8-870e-211f48f8eba2"",
            ""actions"": [
                {
                    ""name"": ""DecreasePlayerCountCallbackBindings"",
                    ""type"": ""Button"",
                    ""id"": ""e941b729-581c-4628-b6e2-2162f924e217"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreasePlayerCountCallbackBindings"",
                    ""type"": ""Button"",
                    ""id"": ""9c4511b7-b9b1-4326-920d-b5d1a681f33e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CharacterSelectLeftCallbackBindings"",
                    ""type"": ""Button"",
                    ""id"": ""8a1294a9-705f-4bb3-9703-1f0bd091b18e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CharacterSelectRightCallbackBindings"",
                    ""type"": ""Button"",
                    ""id"": ""1853c6b1-acdc-4c0a-b0d6-975264cae8ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartGameCallbackBindings"",
                    ""type"": ""Button"",
                    ""id"": ""e5111e09-fef1-444d-97a4-8cff302ac9f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BackToTitleScreenCallbackBindings"",
                    ""type"": ""Button"",
                    ""id"": ""ec061e4a-66e8-4489-bb3b-2d1d228c0fe0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b27328bb-a57c-466b-9b5c-cb29c864e583"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DecreasePlayerCountCallbackBindings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12555897-5a79-43d3-b51a-cf44eb513f21"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""IncreasePlayerCountCallbackBindings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2f30543-197d-4663-a041-dc11e0a2c3df"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CharacterSelectLeftCallbackBindings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63024c86-01b8-4709-9849-8665c871c3d1"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CharacterSelectRightCallbackBindings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a763c1d-95f8-4a1a-8e4f-28fd3b907d56"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StartGameCallbackBindings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1ba3918-96b4-4d9d-abd4-37f404a2d00f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""StartGameCallbackBindings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67a49bf2-c246-4ede-894b-3596c28412c2"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""BackToTitleScreenCallbackBindings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""575b93d9-97d2-488a-8fe4-52e3b5607df0"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""BackToTitleScreenCallbackBindings"",
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
        m_GamePlay_navigateUIUpCallbackInputs = m_GamePlay.FindAction("navigateUIUpCallbackInputs", throwIfNotFound: true);
        m_GamePlay_navigateUIRightCallbackInputs = m_GamePlay.FindAction("navigateUIRightCallbackInputs", throwIfNotFound: true);
        m_GamePlay_navigateUIDownCallbackInputs = m_GamePlay.FindAction("navigateUIDownCallbackInputs", throwIfNotFound: true);
        m_GamePlay_navigateUILeftCallbackInputs = m_GamePlay.FindAction("navigateUILeftCallbackInputs", throwIfNotFound: true);
        m_GamePlay_NavigatePhoneStepInCallbackInputs = m_GamePlay.FindAction("NavigatePhoneStepInCallbackInputs", throwIfNotFound: true);
        m_GamePlay_NavigatePhoneStepOutCallbackInputs = m_GamePlay.FindAction("NavigatePhoneStepOutCallbackInputs", throwIfNotFound: true);
        // Main Menu
        m_MainMenu = asset.FindActionMap("Main Menu", throwIfNotFound: true);
        m_MainMenu_DecreasePlayerCountCallbackBindings = m_MainMenu.FindAction("DecreasePlayerCountCallbackBindings", throwIfNotFound: true);
        m_MainMenu_IncreasePlayerCountCallbackBindings = m_MainMenu.FindAction("IncreasePlayerCountCallbackBindings", throwIfNotFound: true);
        m_MainMenu_CharacterSelectLeftCallbackBindings = m_MainMenu.FindAction("CharacterSelectLeftCallbackBindings", throwIfNotFound: true);
        m_MainMenu_CharacterSelectRightCallbackBindings = m_MainMenu.FindAction("CharacterSelectRightCallbackBindings", throwIfNotFound: true);
        m_MainMenu_StartGameCallbackBindings = m_MainMenu.FindAction("StartGameCallbackBindings", throwIfNotFound: true);
        m_MainMenu_BackToTitleScreenCallbackBindings = m_MainMenu.FindAction("BackToTitleScreenCallbackBindings", throwIfNotFound: true);
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
    private readonly InputAction m_GamePlay_navigateUIUpCallbackInputs;
    private readonly InputAction m_GamePlay_navigateUIRightCallbackInputs;
    private readonly InputAction m_GamePlay_navigateUIDownCallbackInputs;
    private readonly InputAction m_GamePlay_navigateUILeftCallbackInputs;
    private readonly InputAction m_GamePlay_NavigatePhoneStepInCallbackInputs;
    private readonly InputAction m_GamePlay_NavigatePhoneStepOutCallbackInputs;
    public struct GamePlayActions
    {
        private @PlayerControls m_Wrapper;
        public GamePlayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @BrakeCallbackInputs => m_Wrapper.m_GamePlay_BrakeCallbackInputs;
        public InputAction @TurnRightCallbackInputs => m_Wrapper.m_GamePlay_TurnRightCallbackInputs;
        public InputAction @TurnLeftCallbackInputs => m_Wrapper.m_GamePlay_TurnLeftCallbackInputs;
        public InputAction @AccelerateCallbackInputs => m_Wrapper.m_GamePlay_AccelerateCallbackInputs;
        public InputAction @navigateUIUpCallbackInputs => m_Wrapper.m_GamePlay_navigateUIUpCallbackInputs;
        public InputAction @navigateUIRightCallbackInputs => m_Wrapper.m_GamePlay_navigateUIRightCallbackInputs;
        public InputAction @navigateUIDownCallbackInputs => m_Wrapper.m_GamePlay_navigateUIDownCallbackInputs;
        public InputAction @navigateUILeftCallbackInputs => m_Wrapper.m_GamePlay_navigateUILeftCallbackInputs;
        public InputAction @NavigatePhoneStepInCallbackInputs => m_Wrapper.m_GamePlay_NavigatePhoneStepInCallbackInputs;
        public InputAction @NavigatePhoneStepOutCallbackInputs => m_Wrapper.m_GamePlay_NavigatePhoneStepOutCallbackInputs;
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
                @NavigatePhoneStepInCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigatePhoneStepInCallbackInputs;
                @NavigatePhoneStepInCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigatePhoneStepInCallbackInputs;
                @NavigatePhoneStepInCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigatePhoneStepInCallbackInputs;
                @NavigatePhoneStepOutCallbackInputs.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigatePhoneStepOutCallbackInputs;
                @NavigatePhoneStepOutCallbackInputs.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigatePhoneStepOutCallbackInputs;
                @NavigatePhoneStepOutCallbackInputs.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNavigatePhoneStepOutCallbackInputs;
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
                @NavigatePhoneStepInCallbackInputs.started += instance.OnNavigatePhoneStepInCallbackInputs;
                @NavigatePhoneStepInCallbackInputs.performed += instance.OnNavigatePhoneStepInCallbackInputs;
                @NavigatePhoneStepInCallbackInputs.canceled += instance.OnNavigatePhoneStepInCallbackInputs;
                @NavigatePhoneStepOutCallbackInputs.started += instance.OnNavigatePhoneStepOutCallbackInputs;
                @NavigatePhoneStepOutCallbackInputs.performed += instance.OnNavigatePhoneStepOutCallbackInputs;
                @NavigatePhoneStepOutCallbackInputs.canceled += instance.OnNavigatePhoneStepOutCallbackInputs;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);

    // Main Menu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_DecreasePlayerCountCallbackBindings;
    private readonly InputAction m_MainMenu_IncreasePlayerCountCallbackBindings;
    private readonly InputAction m_MainMenu_CharacterSelectLeftCallbackBindings;
    private readonly InputAction m_MainMenu_CharacterSelectRightCallbackBindings;
    private readonly InputAction m_MainMenu_StartGameCallbackBindings;
    private readonly InputAction m_MainMenu_BackToTitleScreenCallbackBindings;
    public struct MainMenuActions
    {
        private @PlayerControls m_Wrapper;
        public MainMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @DecreasePlayerCountCallbackBindings => m_Wrapper.m_MainMenu_DecreasePlayerCountCallbackBindings;
        public InputAction @IncreasePlayerCountCallbackBindings => m_Wrapper.m_MainMenu_IncreasePlayerCountCallbackBindings;
        public InputAction @CharacterSelectLeftCallbackBindings => m_Wrapper.m_MainMenu_CharacterSelectLeftCallbackBindings;
        public InputAction @CharacterSelectRightCallbackBindings => m_Wrapper.m_MainMenu_CharacterSelectRightCallbackBindings;
        public InputAction @StartGameCallbackBindings => m_Wrapper.m_MainMenu_StartGameCallbackBindings;
        public InputAction @BackToTitleScreenCallbackBindings => m_Wrapper.m_MainMenu_BackToTitleScreenCallbackBindings;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @DecreasePlayerCountCallbackBindings.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDecreasePlayerCountCallbackBindings;
                @DecreasePlayerCountCallbackBindings.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDecreasePlayerCountCallbackBindings;
                @DecreasePlayerCountCallbackBindings.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDecreasePlayerCountCallbackBindings;
                @IncreasePlayerCountCallbackBindings.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnIncreasePlayerCountCallbackBindings;
                @IncreasePlayerCountCallbackBindings.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnIncreasePlayerCountCallbackBindings;
                @IncreasePlayerCountCallbackBindings.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnIncreasePlayerCountCallbackBindings;
                @CharacterSelectLeftCallbackBindings.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCharacterSelectLeftCallbackBindings;
                @CharacterSelectLeftCallbackBindings.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCharacterSelectLeftCallbackBindings;
                @CharacterSelectLeftCallbackBindings.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCharacterSelectLeftCallbackBindings;
                @CharacterSelectRightCallbackBindings.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCharacterSelectRightCallbackBindings;
                @CharacterSelectRightCallbackBindings.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCharacterSelectRightCallbackBindings;
                @CharacterSelectRightCallbackBindings.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCharacterSelectRightCallbackBindings;
                @StartGameCallbackBindings.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStartGameCallbackBindings;
                @StartGameCallbackBindings.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStartGameCallbackBindings;
                @StartGameCallbackBindings.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStartGameCallbackBindings;
                @BackToTitleScreenCallbackBindings.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBackToTitleScreenCallbackBindings;
                @BackToTitleScreenCallbackBindings.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBackToTitleScreenCallbackBindings;
                @BackToTitleScreenCallbackBindings.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBackToTitleScreenCallbackBindings;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DecreasePlayerCountCallbackBindings.started += instance.OnDecreasePlayerCountCallbackBindings;
                @DecreasePlayerCountCallbackBindings.performed += instance.OnDecreasePlayerCountCallbackBindings;
                @DecreasePlayerCountCallbackBindings.canceled += instance.OnDecreasePlayerCountCallbackBindings;
                @IncreasePlayerCountCallbackBindings.started += instance.OnIncreasePlayerCountCallbackBindings;
                @IncreasePlayerCountCallbackBindings.performed += instance.OnIncreasePlayerCountCallbackBindings;
                @IncreasePlayerCountCallbackBindings.canceled += instance.OnIncreasePlayerCountCallbackBindings;
                @CharacterSelectLeftCallbackBindings.started += instance.OnCharacterSelectLeftCallbackBindings;
                @CharacterSelectLeftCallbackBindings.performed += instance.OnCharacterSelectLeftCallbackBindings;
                @CharacterSelectLeftCallbackBindings.canceled += instance.OnCharacterSelectLeftCallbackBindings;
                @CharacterSelectRightCallbackBindings.started += instance.OnCharacterSelectRightCallbackBindings;
                @CharacterSelectRightCallbackBindings.performed += instance.OnCharacterSelectRightCallbackBindings;
                @CharacterSelectRightCallbackBindings.canceled += instance.OnCharacterSelectRightCallbackBindings;
                @StartGameCallbackBindings.started += instance.OnStartGameCallbackBindings;
                @StartGameCallbackBindings.performed += instance.OnStartGameCallbackBindings;
                @StartGameCallbackBindings.canceled += instance.OnStartGameCallbackBindings;
                @BackToTitleScreenCallbackBindings.started += instance.OnBackToTitleScreenCallbackBindings;
                @BackToTitleScreenCallbackBindings.performed += instance.OnBackToTitleScreenCallbackBindings;
                @BackToTitleScreenCallbackBindings.canceled += instance.OnBackToTitleScreenCallbackBindings;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
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
        void OnNavigateUIUpCallbackInputs(InputAction.CallbackContext context);
        void OnNavigateUIRightCallbackInputs(InputAction.CallbackContext context);
        void OnNavigateUIDownCallbackInputs(InputAction.CallbackContext context);
        void OnNavigateUILeftCallbackInputs(InputAction.CallbackContext context);
        void OnNavigatePhoneStepInCallbackInputs(InputAction.CallbackContext context);
        void OnNavigatePhoneStepOutCallbackInputs(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnDecreasePlayerCountCallbackBindings(InputAction.CallbackContext context);
        void OnIncreasePlayerCountCallbackBindings(InputAction.CallbackContext context);
        void OnCharacterSelectLeftCallbackBindings(InputAction.CallbackContext context);
        void OnCharacterSelectRightCallbackBindings(InputAction.CallbackContext context);
        void OnStartGameCallbackBindings(InputAction.CallbackContext context);
        void OnBackToTitleScreenCallbackBindings(InputAction.CallbackContext context);
    }
}
