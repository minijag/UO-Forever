using System;

namespace Server.Items
{
	[FlipableAttribute( 0x1450, 0x1455 )]
	public class DaemonGloves : BaseArmor
	{
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int OldStrReq{ get{ return 40; } }

		public override int OldDexBonus{ get{ return -1; } }

		public override int ArmorBase{ get{ return 46; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override int LabelNumber{ get{ return 1041373; } } // daemon bone gloves

		public override int Hue
		{
			get
			{	if ( (base.Hue % 16384) == 0 )
					return base.Hue + 0x648;
				else
					return base.Hue;
			}
			set
			{
				base.Hue = value;
			}
		}

		[Constructable]
		public DaemonGloves() : base( 0x1450 )
		{
			Weight = 2.0;
		}

		public DaemonGloves( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}