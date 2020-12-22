using System; 
using System.Collections; 
using Server;
using Server.Misc; 
using Server.Items; 
using Server.Mobiles;
using Server.Gumps;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	public class BaseRed : BaseCreature 
	{ 
		public BaseRed(AIType ai, FightMode fm, int PR, int FR, double AS, double PS) : base( ai, fm, PR, FR, AS, PS )
		{
			SpeechHue = Utility.RandomDyedHue(); 
			Hue = Utility.RandomSkinHue();
			RangePerception = BaseCreature.DefaultRangePerception;
			Criminal = true;
			AIFullSpeedActive = AIFullSpeedPassive = true; // Force full speed
		}

		public override bool ReacquireOnMovement{ get { return false; } }
		public override TimeSpan ReacquireDelay{ get { return TimeSpan.FromSeconds( 3.0 ); } }
		public override bool BardImmune{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }

		public override bool IsEnemy( Mobile m )
		{
		    if ( m is BaseRed || m is Citizens || m is PlayerVendor || m is TownHerald || m is BaseVendor )
			return false;

		    if ( m is BaseCreature && ((BaseCreature)m).ControlMaster != null && m.Combatant != this)
		    {
			Mobile owner = ((BaseCreature)m).ControlMaster;
			if (owner is PlayerMobile && owner.Kills >= 5)
			    return false;
		    } 
			
			//if ( (Server.Misc.Worlds.GetRegionName( m.Map, m.Location ) == "The Pit") && (m.Kills >= 5 && m.Criminal) )
			//	return true;
			
		    if ( m is PlayerMobile && m.Criminal || m.Kills >= 5 )
				return false;

		    return true;
		}

		public virtual bool HealsYoungPlayers{ get{ return false; } }

		public virtual bool CheckResurrect( Mobile m )
		{
			return true;
		}

		public DateTime m_NextResurrect;
		public static TimeSpan ResurrectDelay = TimeSpan.FromSeconds( 20.0 );

		public virtual void OfferResurrection( Mobile m )
		{
			
			if (m.Criminal || m.Kills >= 5)
			{
				Direction = GetDirectionTo( m );
				Say("An Corp");

				m.PlaySound(0x1F2);
				m.FixedEffect( 0x376A, 10, 16 );
				
				m.Resurrect();

				//m.CloseGump( typeof( ResurrectGump ) );
//m.SendGump( new ResurrectGump( m, ResurrectMessage.Healer ) );
			}
		}

		public virtual void OfferHeal( PlayerMobile m )
		{
			Direction = GetDirectionTo( m );

			//if ( m.CheckYoungHealTime() )
			if ( DateTime.Now >= m_NextResurrect && m.Criminal && m.Kills >= 5 && !m.Hidden)
			{
				Say("Here's some help"); // You look like you need some healing my child.
				Say("In Vas Mani");

				m.PlaySound( 0x1F2 );
				m.FixedEffect( 0x376A, 9, 32 );

				m.Hits = (m.Hits + 50);
				m_NextResurrect = DateTime.Now + ResurrectDelay;
			}
			else
			{
				Say("You should be good"); // I can do no more for you at this time.
			}

		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( !m.Frozen && DateTime.Now >= m_NextResurrect && InRange( m, 4 ) && !InRange( oldLocation, 4 ) && InLOS( m ) )
			{
				if ( !m.Alive && (m is PlayerMobile && m.Criminal || m.Kills >= 5) )
				{
					m_NextResurrect = DateTime.Now + ResurrectDelay;

					if ( m.Map == null || !m.Map.CanFit( m.Location, 16, false, false ) )
					{
						m.SendLocalizedMessage( 502391 ); // Thou can not be resurrected there!
					}
					else if ( CheckResurrect( m ) )
					{
						OfferResurrection( m );
					}
				}
				else if ( m.Hits < m.HitsMax && (m is PlayerMobile && m.Criminal || m.Kills >= 5) )
				{
					OfferHeal( (PlayerMobile) m );
				}
			}
		}

		public override void OnThink()
		{
			base.OnThink();
			
			// Chug pots
			if ( this.Poisoned )
			{
				GreaterCurePotion m_CPot = (GreaterCurePotion)this.Backpack.FindItemByType( typeof ( GreaterCurePotion ) );
				if ( m_CPot != null )
					m_CPot.Drink( this );
			}

			if ( this.Hits <= (this.HitsMax * .7) ) // Will try to use heal pots if he's at or below 70% health
			{
				GreaterHealPotion m_HPot = (GreaterHealPotion)this.Backpack.FindItemByType( typeof ( GreaterHealPotion ) );
				if ( m_HPot != null )
					m_HPot.Drink( this );
			}
			
			if ( this.Stam <= (this.StamMax * .25) ) // Will use a refresh pot if he's at or below 25% stam
			{
				TotalRefreshPotion m_RPot = (TotalRefreshPotion)this.Backpack.FindItemByType( typeof ( TotalRefreshPotion) );
				if ( m_RPot != null )
					m_RPot.Drink( this );
			}
		}

		public BaseRed( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
			AIFullSpeedActive = AIFullSpeedPassive = true; // Force full speed
		} 
	} 
}   
