// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Utility/Input/Dragon_Stones_Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Dragon_Stones.Input
{
    public class @Dragon_Stones_Input : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Dragon_Stones_Input()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Dragon_Stones_Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""816c2ff5-a7f6-4826-a93b-295f1a3d631a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""7179c350-e657-46dd-a0e0-f461d396a9c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""db0944e0-36ff-4f59-9351-63372ef9ba43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""1b5470ee-daf0-4801-82f6-21e345e96a19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera_Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""3fa5697f-71f7-4b03-bb62-0d8582c8a6c9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera_Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""1365c300-7349-43c9-8600-0a881e71ab0b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Value"",
                    ""id"": ""ca43aae2-4d7a-467b-baaa-08fcec815342"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""3fc7e86d-7b3b-421b-8517-555907e017cb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Movement_Gamepad"",
                    ""id"": ""42319969-5e10-4d9e-8dc7-cbcdcd26e1d9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b3af80c6-2dd9-4f94-bfa0-7608d5639c98"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0f57410b-1e00-478c-b41e-60e6dfefa424"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b0c7d0c9-61a4-4adc-8b52-6262f42705ba"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ff787bc5-1bff-4347-9578-73c109121726"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Movement_WASD"",
                    ""id"": ""77269d0e-2d44-4d37-8e80-0a5cd1ccef73"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""70d9aa42-dd6c-4d57-a87c-a0fe22eaa0d5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0cbfd50a-b88c-427d-ac72-a11f1c395d2a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1628ed3a-ffed-43c6-9e67-81a8589e2c0b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9afc2ba7-7840-45d2-a6e7-bbec9c846118"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""88d3d60e-62ae-43d2-8f2f-3d35e061cc8e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Rotate_MK"",
                    ""id"": ""dd5318a4-5c23-4fe8-acba-b009012b5f90"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""11aadf3d-9e8a-45b1-b336-4e6d8a3abcb9"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Camera_Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b752ff14-f4a7-4a30-83ae-6de88b5a4724"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Camera_Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Rotate_Gamepad"",
                    ""id"": ""7616eedd-0722-441c-8f27-3920372455f8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""465375a6-cfde-40eb-8476-57e8a7919a42"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Camera_Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b7d3a5e9-ab70-4901-ba42-288d6d494c04"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Camera_Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""43350ee6-cb6a-448c-9ac8-3c4180d08848"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""963b7238-b1ae-4062-a2c3-a86644339643"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76aae28f-787a-41cd-8641-80a7f69b6e22"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ba81df3-7165-4c62-933e-dd3847b2a9da"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83d35681-b82f-4083-ae42-46eec83f483f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Zoom_MK"",
                    ""id"": ""50e0e0b6-47aa-47a4-8c38-fd8113343522"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bcd3119e-ed06-427d-a99e-f1f7a59ef23a"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Camera_Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c0f7a197-739a-4c87-864d-dd6282e79f99"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Camera_Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Rotate_Gamepad"",
                    ""id"": ""5d61c19f-4b5f-44f4-8a78-beefa0e5ce14"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4755a3c6-b888-4455-8f0e-eb2f8e8c2a5c"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Camera_Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0edbbb0e-c451-4ffe-bd36-5e4656eaf207"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Camera_Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""adc99620-40b7-4515-b17d-1174883ae8b3"",
            ""actions"": [
                {
                    ""name"": ""Basic_Attack"",
                    ""type"": ""Button"",
                    ""id"": ""968750ed-c0bc-4714-b8ee-2aaf2a929468"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spell_1"",
                    ""type"": ""Button"",
                    ""id"": ""ea9ac235-74a0-428d-a43e-4e92bf8c7b4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spell_2"",
                    ""type"": ""Button"",
                    ""id"": ""c8f3a283-9e7c-4416-b5d6-66641f06383d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spell_3"",
                    ""type"": ""Button"",
                    ""id"": ""481addef-bc9b-4a90-8e6e-2bfbe97dc1bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spell_4"",
                    ""type"": ""Button"",
                    ""id"": ""533b1856-b3a2-4d14-8fb2-3e15f9bab925"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleSpells"",
                    ""type"": ""Button"",
                    ""id"": ""ae30051f-c2e6-4a14-932c-e7313e0e59e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchTarget"",
                    ""type"": ""Button"",
                    ""id"": ""3f6d3c0e-10ef-497a-9ebb-2c6451042f0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""59d2d904-1575-4823-af8e-ec61cef764fb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Basic_Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d6b8748-77c8-47b2-8280-7a79c5203c50"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Basic_Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed90181d-c33e-4c02-bd0d-16dd54b22e42"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Spell_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f79ac98-6398-45ce-8b5c-d88543511af1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Spell_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b004175-8332-482d-87d3-e208bc59f476"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Spell_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e695162a-07fb-4093-99d9-bbf66a132f66"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Spell_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5302be38-3afe-4f31-8350-ef95b1f85fc2"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Spell_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""650dd70b-9631-4048-90bf-81784e0ee54b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Spell_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee57c850-3030-4c7e-a2ba-f1fd9a8691aa"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Spell_4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1d7fe65-4f25-4b64-884b-fdb382241285"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""Spell_4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81a44f74-625d-4f55-aca9-6779b5f4f0cc"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""ToggleSpells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70719507-8e4f-4307-94a7-20494a2e7ec9"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""ToggleSpells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52dba7f2-abf5-4f26-896f-5f1a8a5db154"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""SwitchTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c73ab658-e01b-46f1-930c-219d7c6ea7c5"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""SwitchTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""ccce3c2e-a067-4675-bf98-9ddf66f223f9"",
            ""actions"": [
                {
                    ""name"": ""ExitMenu"",
                    ""type"": ""Button"",
                    ""id"": ""018691ad-0c6e-43bd-93e6-404d25d2d1c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GameMenu"",
                    ""type"": ""Button"",
                    ""id"": ""ea0f6ba1-d44f-4951-85ec-70809d766258"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""57bcee14-6ab4-4f14-8323-54dcf8663770"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""ExitMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51fac3a7-373f-45c4-84f3-b2b704b769fc"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""ExitMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73e9d600-5b7d-4026-be1e-afc09cbe60fb"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""GameMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""133a6665-463a-45bc-9a86-990edcac2d86"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dragon_Stones"",
                    ""action"": ""GameMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Dragon_Stones"",
            ""bindingGroup"": ""Dragon_Stones"",
            ""devices"": []
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
            m_Player_Camera_Rotate = m_Player.FindAction("Camera_Rotate", throwIfNotFound: true);
            m_Player_Camera_Zoom = m_Player.FindAction("Camera_Zoom", throwIfNotFound: true);
            m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
            // Combat
            m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
            m_Combat_Basic_Attack = m_Combat.FindAction("Basic_Attack", throwIfNotFound: true);
            m_Combat_Spell_1 = m_Combat.FindAction("Spell_1", throwIfNotFound: true);
            m_Combat_Spell_2 = m_Combat.FindAction("Spell_2", throwIfNotFound: true);
            m_Combat_Spell_3 = m_Combat.FindAction("Spell_3", throwIfNotFound: true);
            m_Combat_Spell_4 = m_Combat.FindAction("Spell_4", throwIfNotFound: true);
            m_Combat_ToggleSpells = m_Combat.FindAction("ToggleSpells", throwIfNotFound: true);
            m_Combat_SwitchTarget = m_Combat.FindAction("SwitchTarget", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_ExitMenu = m_UI.FindAction("ExitMenu", throwIfNotFound: true);
            m_UI_GameMenu = m_UI.FindAction("GameMenu", throwIfNotFound: true);
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
        private readonly InputAction m_Player_Movement;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Run;
        private readonly InputAction m_Player_Camera_Rotate;
        private readonly InputAction m_Player_Camera_Zoom;
        private readonly InputAction m_Player_Interact;
        public struct PlayerActions
        {
            private @Dragon_Stones_Input m_Wrapper;
            public PlayerActions(@Dragon_Stones_Input wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Player_Movement;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Run => m_Wrapper.m_Player_Run;
            public InputAction @Camera_Rotate => m_Wrapper.m_Player_Camera_Rotate;
            public InputAction @Camera_Zoom => m_Wrapper.m_Player_Camera_Zoom;
            public InputAction @Interact => m_Wrapper.m_Player_Interact;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                    @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                    @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                    @Camera_Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera_Rotate;
                    @Camera_Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera_Rotate;
                    @Camera_Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera_Rotate;
                    @Camera_Zoom.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera_Zoom;
                    @Camera_Zoom.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera_Zoom;
                    @Camera_Zoom.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera_Zoom;
                    @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Run.started += instance.OnRun;
                    @Run.performed += instance.OnRun;
                    @Run.canceled += instance.OnRun;
                    @Camera_Rotate.started += instance.OnCamera_Rotate;
                    @Camera_Rotate.performed += instance.OnCamera_Rotate;
                    @Camera_Rotate.canceled += instance.OnCamera_Rotate;
                    @Camera_Zoom.started += instance.OnCamera_Zoom;
                    @Camera_Zoom.performed += instance.OnCamera_Zoom;
                    @Camera_Zoom.canceled += instance.OnCamera_Zoom;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);

        // Combat
        private readonly InputActionMap m_Combat;
        private ICombatActions m_CombatActionsCallbackInterface;
        private readonly InputAction m_Combat_Basic_Attack;
        private readonly InputAction m_Combat_Spell_1;
        private readonly InputAction m_Combat_Spell_2;
        private readonly InputAction m_Combat_Spell_3;
        private readonly InputAction m_Combat_Spell_4;
        private readonly InputAction m_Combat_ToggleSpells;
        private readonly InputAction m_Combat_SwitchTarget;
        public struct CombatActions
        {
            private @Dragon_Stones_Input m_Wrapper;
            public CombatActions(@Dragon_Stones_Input wrapper) { m_Wrapper = wrapper; }
            public InputAction @Basic_Attack => m_Wrapper.m_Combat_Basic_Attack;
            public InputAction @Spell_1 => m_Wrapper.m_Combat_Spell_1;
            public InputAction @Spell_2 => m_Wrapper.m_Combat_Spell_2;
            public InputAction @Spell_3 => m_Wrapper.m_Combat_Spell_3;
            public InputAction @Spell_4 => m_Wrapper.m_Combat_Spell_4;
            public InputAction @ToggleSpells => m_Wrapper.m_Combat_ToggleSpells;
            public InputAction @SwitchTarget => m_Wrapper.m_Combat_SwitchTarget;
            public InputActionMap Get() { return m_Wrapper.m_Combat; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
            public void SetCallbacks(ICombatActions instance)
            {
                if (m_Wrapper.m_CombatActionsCallbackInterface != null)
                {
                    @Basic_Attack.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnBasic_Attack;
                    @Basic_Attack.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnBasic_Attack;
                    @Basic_Attack.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnBasic_Attack;
                    @Spell_1.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_1;
                    @Spell_1.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_1;
                    @Spell_1.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_1;
                    @Spell_2.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_2;
                    @Spell_2.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_2;
                    @Spell_2.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_2;
                    @Spell_3.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_3;
                    @Spell_3.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_3;
                    @Spell_3.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_3;
                    @Spell_4.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_4;
                    @Spell_4.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_4;
                    @Spell_4.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSpell_4;
                    @ToggleSpells.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnToggleSpells;
                    @ToggleSpells.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnToggleSpells;
                    @ToggleSpells.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnToggleSpells;
                    @SwitchTarget.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSwitchTarget;
                    @SwitchTarget.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSwitchTarget;
                    @SwitchTarget.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSwitchTarget;
                }
                m_Wrapper.m_CombatActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Basic_Attack.started += instance.OnBasic_Attack;
                    @Basic_Attack.performed += instance.OnBasic_Attack;
                    @Basic_Attack.canceled += instance.OnBasic_Attack;
                    @Spell_1.started += instance.OnSpell_1;
                    @Spell_1.performed += instance.OnSpell_1;
                    @Spell_1.canceled += instance.OnSpell_1;
                    @Spell_2.started += instance.OnSpell_2;
                    @Spell_2.performed += instance.OnSpell_2;
                    @Spell_2.canceled += instance.OnSpell_2;
                    @Spell_3.started += instance.OnSpell_3;
                    @Spell_3.performed += instance.OnSpell_3;
                    @Spell_3.canceled += instance.OnSpell_3;
                    @Spell_4.started += instance.OnSpell_4;
                    @Spell_4.performed += instance.OnSpell_4;
                    @Spell_4.canceled += instance.OnSpell_4;
                    @ToggleSpells.started += instance.OnToggleSpells;
                    @ToggleSpells.performed += instance.OnToggleSpells;
                    @ToggleSpells.canceled += instance.OnToggleSpells;
                    @SwitchTarget.started += instance.OnSwitchTarget;
                    @SwitchTarget.performed += instance.OnSwitchTarget;
                    @SwitchTarget.canceled += instance.OnSwitchTarget;
                }
            }
        }
        public CombatActions @Combat => new CombatActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_ExitMenu;
        private readonly InputAction m_UI_GameMenu;
        public struct UIActions
        {
            private @Dragon_Stones_Input m_Wrapper;
            public UIActions(@Dragon_Stones_Input wrapper) { m_Wrapper = wrapper; }
            public InputAction @ExitMenu => m_Wrapper.m_UI_ExitMenu;
            public InputAction @GameMenu => m_Wrapper.m_UI_GameMenu;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @ExitMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnExitMenu;
                    @ExitMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnExitMenu;
                    @ExitMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnExitMenu;
                    @GameMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnGameMenu;
                    @GameMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnGameMenu;
                    @GameMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnGameMenu;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ExitMenu.started += instance.OnExitMenu;
                    @ExitMenu.performed += instance.OnExitMenu;
                    @ExitMenu.canceled += instance.OnExitMenu;
                    @GameMenu.started += instance.OnGameMenu;
                    @GameMenu.performed += instance.OnGameMenu;
                    @GameMenu.canceled += instance.OnGameMenu;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
        private int m_Dragon_StonesSchemeIndex = -1;
        public InputControlScheme Dragon_StonesScheme
        {
            get
            {
                if (m_Dragon_StonesSchemeIndex == -1) m_Dragon_StonesSchemeIndex = asset.FindControlSchemeIndex("Dragon_Stones");
                return asset.controlSchemes[m_Dragon_StonesSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
            void OnCamera_Rotate(InputAction.CallbackContext context);
            void OnCamera_Zoom(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
        }
        public interface ICombatActions
        {
            void OnBasic_Attack(InputAction.CallbackContext context);
            void OnSpell_1(InputAction.CallbackContext context);
            void OnSpell_2(InputAction.CallbackContext context);
            void OnSpell_3(InputAction.CallbackContext context);
            void OnSpell_4(InputAction.CallbackContext context);
            void OnToggleSpells(InputAction.CallbackContext context);
            void OnSwitchTarget(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnExitMenu(InputAction.CallbackContext context);
            void OnGameMenu(InputAction.CallbackContext context);
        }
    }
}
