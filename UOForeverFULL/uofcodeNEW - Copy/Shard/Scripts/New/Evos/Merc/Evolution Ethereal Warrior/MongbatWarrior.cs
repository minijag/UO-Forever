//Script Modified By: Crows Kingdom Shard

using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a mongbat warrior corpse" )]
	public class MongbatWarrior : BaseCreature
	{
		[Constructable]
		public MongbatWarrior() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a mongbat warrior";
			Body = 39;
			Hue = Utility.RandomList( 1157, 1175, 1172, 1171, 1170, 1169, 1168, 1167, 1166, 1165 );
			BaseSoundID = 422;

			SetStr( 596, 625 );
			SetDex( 86, 105 );
			SetInt( 226, 246 );

			SetHits( 600, 850 );

			SetDamage( 13, 19 );

			
			
			
			
			

			
			
			
			
			

			SetSkill( SkillName.Magery, 70.1, 80.0 );
			SetSkill( SkillName.Meditation, 70.1, 80.0 );
			SetSkill( SkillName.EvalInt, 70.1, 80.0 );
			SetSkill( SkillName.MagicResist, 75.1, 80.0 );
			SetSkill( SkillName.Tactics, 49.3, 64.0 );
			SetSkill( SkillName.Wrestling, 49.3, 64.0 );
			SetSkill( SkillName.Anatomy, 49.3, 64.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 50;

			PackGold( 900, 1300 );
			PackMagicItems( 3, 3, 0.95, 0.95 );
			PackMagicItems( 3, 3, 0.80, 0.65 );

			if ( Utility.RandomDouble() <= 0.25 )
			{
				int amount = Utility.RandomMinMax( 1, 5 );

				PackItem( new WarriorDust(amount) );
			}
		}

		public MongbatWarrior(Serial serial) : base(serial)
		{
		}

		private DateTime m_NextBreathe;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.UtcNow >= m_NextBreathe )
			{
				Breathe( combatant );

				m_NextBreathe = DateTime.UtcNow + TimeSpan.FromSeconds( 12.0 + (3.0 * Utility.RandomDouble()) ); // 12-15 seconds
			}
		}

		public void Breathe( Mobile m )
		{
			DoHarmful( m );

			new BreatheTimer( m, this ).Start();

			this.Frozen = true;

			this.MovingParticles( m, 0x1FAB, 1, 0, false, true, ( this.Hue - 1 ), 0, 9502, 6014, 0x11D, EffectLayer.Waist, 0 );
		}

		private class BreatheTimer : Timer
		{
			private MongbatWarrior d;
			private Mobile m_Mobile;

			public BreatheTimer( Mobile m, MongbatWarrior owner ) : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				d = owner;
				m_Mobile = m;
			}

			protected override void OnTick()
			{
				int damagemin = d.Hits / 20;
				int damagemax = d.Hits / 25;
				d.Frozen = false;

				m_Mobile.PlaySound( 0x11D );
                m_Mobile.Damage(Utility.RandomMinMax(damagemin, damagemax));
				Stop();
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}