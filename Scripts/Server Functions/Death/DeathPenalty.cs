using Server;
using Server.Mobiles;
using Server.Items;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Server.Misc
{
    class Death
    {
		public static void Penalty( Mobile from, bool allPenalty )
        { 
			Penalty(from, allPenalty, false);
		}

		public static void Penalty( Mobile from, bool allPenalty, bool ankh )
        {
			if ( from is PlayerMobile )
			{
				double val1 = 0.05;
				
				if ( !((PlayerMobile)from).NormalMode)
					val1 *= 2;
				
				double val2 = 0;
				
				int karma = Math.Abs(from.Karma);
				if ( karma < 1000)
					karma = 1000;

				if (from.Karma >= 0)
					val2 = ( (100 - ( (((double)AetherGlobe.DoomCurse / 100000.0) * ( ((double)karma / 15000) ) ) ) ) / 100 ) ;
				else 
					val2 = ( (100 - ( (((double)(100000-AetherGlobe.DoomCurse) / 100000.0) * ( ((double)karma / 15000) ) ) ) ) / 100 ) ;
				
				if (val2 >= 0.999)
					val2 = 0.999;

				if ( allPenalty )
				{
					if ( !((PlayerMobile)from).NormalMode )
						val1 *= 4;
					else 
						val1 *= 2;
					val2 = 1-((1-val2)*3);
				}
				else if ( !((PlayerMobile)from).NormalMode )
					val1 *= 2;
					
				if ( (from.RawStr + from.RawDex + from.RawInt) < 125  )
				{
					val2 = 1.0;
					val1 /= 2;
				}
				
				if (ankh )
				{
					val1 *= 2;
				}	

				if (val1 < 0.05)
					val1 = 0.05;
				
				if( from.Fame > 0 ) // FAME LOSS
				{
					int amount = (int)((double)from.Fame * val1);
					if ( from.Fame - amount < 0 ){ amount = from.Fame; }
						if ( from.Fame < 1 ){ from.Fame = 0; }
					Misc.Titles.AwardFame( from, -amount, true );
				}

				if( from.Karma > 0 ) // KARMA LOSS
				{
					int amount = (int)((double)from.Karma * val1);
					if ( from.Karma - amount < 0 ){ amount = from.Karma; }
						if ( from.Karma < 1 ){ from.Karma = 0; }
					Misc.Titles.AwardKarma( from, -amount, true );
				}

				if ( ((PlayerMobile)from).BalanceChampion || ((from.RawStr + from.RawDex + from.RawInt) < 125) || !((PlayerMobile)from).NormalMode)
				{
					if (((from.RawStr + from.RawDex + from.RawInt) < 125))
						from.SendMessage( "You would have lost skills here were you not so weak." );
					else if (((PlayerMobile)from).BalanceChampion)
						from.SendMessage( "Your strength overcomes the perils of death!" );
					else if ( !((PlayerMobile)from).NormalMode)
						from.SendMessage( "You avoid any serious penalty for your death due to your casual playstyle." );
					return;
				}

				double loss = val2;

				if( from.RawStr * loss > 10 )
				{
					if (allPenalty)
						from.RawStr = (int)(from.RawStr * loss);
					else if ( Utility.RandomDouble() < 0.33 )
						from.RawStr = (int)(from.RawStr * loss);
				}
				if ( from.RawStr < 10 ){ from.RawStr = 10; }
				
				if( from.RawInt * loss > 10 )
				{
					if (allPenalty)
						from.RawInt = (int)(from.RawInt * loss);
					else if ( Utility.RandomDouble() < 0.33 )
						from.RawInt = (int)(from.RawInt * loss);
				}					
				if ( from.RawInt < 10 ){ from.RawInt = 10; }
			
				if( from.RawDex * loss > 10 )
				{
					if (allPenalty)
						from.RawDex = (int)(from.RawDex * loss);
					else if ( Utility.RandomDouble() < 0.33 )				
						from.RawDex = (int)(from.RawDex * loss);
				}					
				if ( from.RawDex < 10 ){ from.RawDex = 10; }
						
				if ( allPenalty  )
				{
					for( int s = 0; s < from.Skills.Length; s++ )
					{
						if( (from.Skills[s].Base * loss) > 35 )
							from.Skills[s].Base *= loss;
	
					}	
					from.SendMessage( "Your body revives... but much weaker. " );
				}
				else 
				{
					for( int s = 0; s < from.Skills.Length; s++ )
					{
						if (from.Karma >= 0 && (from.Skills[s].Base * loss > 35) && (Utility.RandomDouble() < (((double)AetherGlobe.DoomCurse / 200000.0)) * ( 1+ ((double)from.Karma / 15000)))) 
							from.Skills[s].Base *= loss;
						else if ( (from.Skills[s].Base * loss > 35) && (Utility.RandomDouble() < (((100000-(double)AetherGlobe.DoomCurse) / 200000.0)) * ( 1+ ((double)Math.Abs(from.Karma) / 15000))))
							from.Skills[s].Base *= loss;
					}	
					from.SendMessage( "Your body revives... but a little weaker. " );
				}
						
			}
		}
	}
}