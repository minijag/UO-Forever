using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "pirate crew corpse" )]
	public class EdwardHarker : BaseCreature
	{
		public override string DefaultName{ get{ return "Edward Harker"; } }


		[Constructable]
		public EdwardHarker() : base( AIType.AI_Melee, FightMode.Strongest, 10, 1, 0.2, 0.4 )
		{
			Body = 0x190;

			Title = "the First Mate";

			SetStr( 300, 350 );
			SetDex( 70, 80 );
			SetInt( 250 );
			SetHits( 1200 );
			SetMana( 250 );

			SetDamage( 15, 20 );

			SetSkill( SkillName.EvalInt, 120.0 );
			SetSkill( SkillName.Magery, 120.0 );
			SetSkill( SkillName.Meditation, 120.0 );
			SetSkill( SkillName.MagicResist, 250.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Anatomy, 120.0 );
			SetSkill( SkillName.Healing, 120.0 );
			SetSkill( SkillName.Swords, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0 );
			SetSkill( SkillName.Poisoning, 120.0 );

			Fame = 5000;
			Karma = -10000;

			VirtualArmor = 60;

			HairItemID = 0x2047;
			HairHue = 2052;
			FacialHairItemID = 0x2040;
			FacialHairHue = 2052;

			AddItem( NotCorpseCont( new SkullCap( 2052 ) ) );
			AddItem( NotCorpseCont( Renamed( new JinBaori( 1001 ), "a vest" ) ) );
			AddItem( NotCorpseCont( new ShortPants( 2052 ) ) );
			AddItem( new Shirt() );
			AddItem( new Shoes() );
			AddItem( new Scimitar() );

	//		AddItem( NotCorpseCont( new Scimitar() ) );
		}

		public override bool AutoDispel{ get{ return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 5; } }

		public EdwardHarker( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
    }
}
