//Copyright (c) FuchsFarbe

using Dragon_Stones.Input;
using Dragon_Stones.Inventory_Systems;
using UnityEngine;
using UnityEngine.InputSystem;

/* ============================================
*               Canvas Manager 
* --------------------------------------------
*       Manages the input of canvas windows.
*  ===========================================
*/
namespace Dragon_Stones.UI
{
    public class Canvas_Manager : MonoBehaviour
    {
		public static Canvas_Manager instance;

        #region Variables

        //References
        [SerializeField] private GameObject inventoryWindow;
		private Dragon_Stones_Input input;
		//Variables

		//Input Events
		private InputAction inventoryButton;

		//Events
		public delegate void OnInventoryOpened();
		public static event OnInventoryOpened BagOpened;

		#endregion

		#region Unity Methods

		private void Awake()
		{
			input = new Dragon_Stones_Input();
			inventoryButton = input.UI.Bag;

			inventoryButton.performed += ctx => ToggleInvWindow(ctx);

			#region Singleton
			if (instance != null)
			{
				Debug.Log("More than one Canvas in scene.");
			}
			instance = this;
			#endregion
		}
		private void Start()
		{
			GetInventoryWindow();
		}

		void OnEnable()
		{
			inventoryButton.Enable();
		}
		void OnDisable()
		{
			inventoryButton.Disable();
		}

		#endregion

		private void GetInventoryWindow()
		{
			if (this.inventoryWindow == null)
			{
				Debug.Log("Inventory canvas not in scene");
			}
		}

		private void ToggleInvWindow(InputAction.CallbackContext ctx)
		{
			if (inventoryWindow.activeSelf != !inventoryWindow.activeSelf)
			{
				inventoryWindow.SetActive(!inventoryWindow.activeSelf);
				//TODO: play window animations

				//Trigger event
				BagOpened?.Invoke();
			}
		}
	}
}