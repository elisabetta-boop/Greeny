// GENERATED AUTOMATICALLY FROM 'Assets/#Project/InputSystem/Zero.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Zero : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Zero()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Zero"",
    ""maps"": [
        {
            ""name"": ""ZeroPlayer"",
            ""id"": ""5d3ad3bb-ea7e-4fa2-8f25-f89c6864b634"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5fa56ecc-6dee-4ad0-a8a5-4cd1b4282760"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""de6f09ea-95a0-4a68-ba91-ea3d42a0c908"",
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
                    ""id"": ""5a5c3f52-295e-4a63-81ad-30f0c07ebf49"",
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
                    ""id"": ""330501dc-69ff-4c15-b872-6e6e3a7484b9"",
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
                    ""id"": ""1dfe4ff2-32f3-4708-9ea1-b2b711cd2594"",
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
                    ""id"": ""b94e010a-e912-47ed-9011-3e7af5677df6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Direction"",
                    ""id"": ""3b1a1f53-159d-4212-bae4-cf91443750df"",
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
                    ""id"": ""58f1c5ca-6c01-4388-84f0-3a52c82c3655"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3bee0d8e-3ed5-4d7f-a598-c02990a3b1e2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a77f0b6f-79a7-42b3-abca-cd195e1dda51"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f8077587-cd85-479a-906a-4ec5efeb9b7a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ZeroPlayer
        m_ZeroPlayer = asset.FindActionMap("ZeroPlayer", throwIfNotFound: true);
        m_ZeroPlayer_Move = m_ZeroPlayer.FindAction("Move", throwIfNotFound: true);
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

    // ZeroPlayer
    private readonly InputActionMap m_ZeroPlayer;
    private IZeroPlayerActions m_ZeroPlayerActionsCallbackInterface;
    private readonly InputAction m_ZeroPlayer_Move;
    public struct ZeroPlayerActions
    {
        private @Zero m_Wrapper;
        public ZeroPlayerActions(@Zero wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ZeroPlayer_Move;
        public InputActionMap Get() { return m_Wrapper.m_ZeroPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ZeroPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IZeroPlayerActions instance)
        {
            if (m_Wrapper.m_ZeroPlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ZeroPlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ZeroPlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ZeroPlayerActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_ZeroPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public ZeroPlayerActions @ZeroPlayer => new ZeroPlayerActions(this);
    public interface IZeroPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
