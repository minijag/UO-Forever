#region References
using Server.Items;
#endregion

namespace Server.Mobiles
{
	[CorpseName("a wanderer of the void corpse")]
	public class WandererOfTheVoid : BaseCreature
	{
		public override string DefaultName { get { return "a wanderer of the void"; } }

		[Constructable]
		public WandererOfTheVoid()
			: base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Body = 316;
			BaseSoundID = 377;

			SetStr(111, 200);
			SetDex(101, 125);
			SetInt(301, 390);

			SetHits(351, 400);

            Alignment = Alignment.Demon;

			SetDamage(11, 13);

			SetSkill(SkillName.EvalInt, 60.1, 70.0);
			SetSkill(SkillName.Magery, 60.1, 70.0);
			SetSkill(SkillName.Meditation, 60.1, 70.0);
			SetSkill(SkillName.MagicResist, 50.1, 75.0);
			SetSkill(SkillName.Tactics, 60.1, 70.0);
			SetSkill(SkillName.Wrestling, 60.1, 70.0);

			Fame = 20000;
			Karma = -20000;

			VirtualArmor = 44;

			int count = Utility.RandomMinMax(2, 3);

			for (int i = 0; i < count; ++i)
			{
				PackItem(new TreasureMap(3, Map.Felucca));
			}
		}

		public override bool BleedImmune { get { return true; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }
		public override int TreasureMapLevel { get { return EraAOS ? 4 : 1; } }

		public override void GenerateLoot()
		{
			AddLoot(LootPack.FilthyRich);
		}

		public WandererOfTheVoid(Serial serial)
			: base(serial)
		{ }

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