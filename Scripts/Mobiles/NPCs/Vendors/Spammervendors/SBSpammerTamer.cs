using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBSpammerTamer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSpammerTamer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{  
				Add( new AnimalBuyInfo( 1, typeof( FrenziedOstard ), 8000, 10, 204, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Horse ), 500, 10, 204, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Drake ), 10000, 10, 204, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Mongbat ), 500, 10, 204, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Nightmare ), 10000, 10, 204, 0 ) );
				Add (new GenericBuyInfo( typeof( PetControlDeed ), 25000, 20, 0x14F0, 0 ) );

				if ( Utility.RandomDouble() < 0.08 )
				{
				Add (new GenericBuyInfo( typeof( ParagonPetDeed ), 3500000, 1, 0x14F0, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.25 )
				{
				Add( new AnimalBuyInfo( 1, typeof( Beetle ), 10000, 10, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.25 )
				{
				Add( new AnimalBuyInfo( 1, typeof( Hiryu ), 20000, 10, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.15 )
				{
				Add( new AnimalBuyInfo( 1, typeof( Dragon ), 18000, 10, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.15 )
				{
				Add( new AnimalBuyInfo( 1, typeof( RuneBeetle ), 25000, 10, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.15 )
				{
				Add( new AnimalBuyInfo( 1, typeof( IronBeetle ), 200000, 10, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.10 )
				{
				Add( new AnimalBuyInfo( 1, typeof( Daemon ), 3000000, 10, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.10 )
				{
				Add( new AnimalBuyInfo( 1, typeof( SilverSerpent ), 190000, 10, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.10 )
				{
				Add( new AnimalBuyInfo( 1, typeof( CuSidhe ), 50000, 10, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.10 )
				{
				Add( new AnimalBuyInfo( 1, typeof( FireSteed ), 75000, 10, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.05 )
				{
				Add( new AnimalBuyInfo( 1, typeof( Ratman ), 550000, 5, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.05 )
				{
				Add( new AnimalBuyInfo( 1, typeof( Lich ), 1500000, 2, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.05 )
				{
				Add( new AnimalBuyInfo( 1, typeof( Wisp ), 750000, 1, 204, 0 ) );
				}

				if ( Utility.RandomDouble() < 0.02 )
				{
				Add( new AnimalBuyInfo( 1, typeof( OphidianMatriarch ), 1500000, 1, 204, 0 ) );
				}

			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ParagonPetDeed ), 500000 ); 

			}
		}
	}
}
