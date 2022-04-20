// GENERATED AUTOMATICALLY FROM 'Assets/_Scripts/InputSystem/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Locamotion"",
            ""id"": ""02b87a3b-a0c0-49d6-bcfe-b9d6561e7c20"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""14d03708-9010-44c7-819f-2b28b9d1b795"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a8d36c36-51ed-4b38-a280-34b4512f7d28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""dca4c0b8-8a91-4a3e-bfef-9025c9cb2330"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e9bdc82a-1774-4bbc-8352-c3a569e09116"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5a145e6f-7089-430c-87fb-0b441fad65dc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ab6bd3a7-44d4-4e44-a351-42774bb5ec14"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7c3e7855-58d2-4ea4-9d6c-c4c788290b7c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a06203a7-710c-4370-ba85-4085bb5bad37"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Locamotion
        m_Locamotion = asset.FindActionMap("Locamotion", throwIfNotFound: true);
        m_Locamotion_Move = m_Locamotion.FindAction("Move", throwIfNotFound: true);
        m_Locamotion_Jump = m_Locamotion.FindAction("Jump", throwIfNotFound: true);
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

    // Locamotion
    private readonly InputActionMap m_Locamotion;
    private ILocamotionActions m_LocamotionActionsCallbackInterface;
    private readonly InputAction m_Locamotion_Move;
    private readonly InputAction m_Locamotion_Jump;
    public struct LocamotionActions
    {
        private @Controls m_Wrapper;
        public LocamotionActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Locamotion_Move;
        public InputAction @Jump => m_Wrapper.m_Locamotion_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Locamotion; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LocamotionActions set) { return set.Get(); }
        public void SetCallbacks(ILocamotionActions instance)
        {
            if (m_Wrapper.m_LocamotionActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_LocamotionActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LocamotionActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LocamotionActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_LocamotionActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LocamotionActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LocamotionActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_LocamotionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public LocamotionActions @Locamotion => new LocamotionActions(this);
    public interface ILocamotionActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
