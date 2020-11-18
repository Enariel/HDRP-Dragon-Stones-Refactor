using UnityEngine;

namespace Dragon_Stones.Inventory_Systems
{
    [CreateAssetMenu(menuName = "Item/Weapon", fileName = "New Weapon")]
    class Weapon : Equipment
    {
        [Header("Weapon Details")]
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private bool canDualWield;
        public bool CanDualWield
		{
            get
			{
                switch (weaponType)
                {
                    case WeaponType.Dagger:
                        return canDualWield = true;
                    case WeaponType.Sword:
                        return canDualWield = true;
                    case WeaponType.Shield:
                        return canDualWield = true;
                }
                return canDualWield = false;
            }
		}

		public WeaponType WeaponType { get => weaponType; }

		public override void UseItem(Item aItem)
        {
            Debug.Log("This weapon is: " + Id + ". Dual wield enabled: " + CanDualWield);
        }
        public void EquipWeapon(Weapon aWeapon)
		{
            Debug.Log("Weapon equipped");
		}
    }
}
