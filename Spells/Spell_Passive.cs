using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon_Stones.Spell_System
{
    public class Spell_Passive : Spell
    {
        [SerializeField] private GameObject onActivate, activeObjEffect;
        [SerializeField] private Material activeEffect;
        public override void Cast(GameObject caster)
        {

        }

        public void TickPassive()
        {

        }
    }
}