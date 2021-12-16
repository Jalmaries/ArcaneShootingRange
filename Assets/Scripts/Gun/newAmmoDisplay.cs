using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BNG
{
    public class newAmmoDisplay : MonoBehaviour
    {

        public RaycastWeapon Weapon;
        public Text AmmoLabel;

        void OnGUI()
        {
            AmmoLabel.text = "" + Weapon.GetBulletCount();
        }
    }
}
