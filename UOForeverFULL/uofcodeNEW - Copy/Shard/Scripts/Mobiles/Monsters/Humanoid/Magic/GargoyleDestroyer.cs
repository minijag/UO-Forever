#region References

using Server.Items;

#endregion

namespace Server.Mobiles
{
    [CorpseName("a gargoyle corpse")]
    public class GargoyleDestroyer : BaseCreature
    {
        public override string DefaultName { get { return "a gargoyle destroyer"; } }

        [Constructable]
        public GargoyleDestroyer()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Body = 0x2F3;
            BaseSoundID = 0x174;

            Alignment = Alignment.Inhuman;

            SetStr(760, 850);
            SetDex(102, 150);
            SetInt(152, 200);

            SetHits(482, 485);

            SetDamage(7, 14);

            SetSkill(SkillName.Wrestling, 90.1, 100.0);
            SetSkill(SkillName.Tactics, 90.1, 100.0);
            SetSkill(SkillName.MagicResist, 120.4, 160.0);
            SetSkill(SkillName.Anatomy, 50.5, 100.0);
            SetSkill(SkillName.Swords, 90.1, 100.0);
            SetSkill(SkillName.Macing, 90.1, 100.0);
            SetSkill(SkillName.Fencing, 90.1, 100.0);
            SetSkill(SkillName.Magery, 90.1, 100.0);
            SetSkill(SkillName.EvalInt, 90.1, 100.0);
            SetSkill(SkillName.Meditation, 90.1, 100.0);

            Fame = 10000;
            Karma = -10000;

            VirtualArmor = 50;

            if (0.05 > Utility.RandomDouble())
            {
                PackItem(new GargoylesPickaxe());
            }
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.MedScrolls);
            AddLoot(LootPack.Gems, 2);
        }

        public override bool BardImmune { get { return !EraAOS; } }
        public override int Meat { get { return 1; } }

        public override void OnDamagedBySpell(Mobile from)
        {
            if (from != null && from.Alive && 0.4 > Utility.RandomDouble())
            {
                ThrowHatchet(from);
            }
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            if (attacker != null && attacker.Alive && attacker.Weapon is BaseRanged && 0.4 > Utility.RandomDouble())
            {
                ThrowHatchet(attacker);
            }
        }

        public void ThrowHatchet(Mobile to)
        {
            int damage = 50;
            MovingEffect(to, 0xF43, 10, 0, false, false);
            DoHarmful(to);
            to.Damage(damage, this);
        }

        public GargoyleDestroyer(Serial serial)
            : base(serial)
        {}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}