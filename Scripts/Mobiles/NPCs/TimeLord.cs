using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server.Gumps;

namespace Server.Mobiles
{
	public class TimeLord : BasePerson
	{
		private DateTime m_NextTalk;
		public DateTime NextTalk{ get{ return m_NextTalk; } set{ m_NextTalk = value; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if( m is PlayerMobile )
			{
				if ( DateTime.Now >= m_NextTalk && InRange( m, 4 ) && InLOS( m ) )
				{ 
					switch ( Utility.Random( 8 ))
					{
					case 0: Say("I watch the Balance tip here, tip there... "); break;
					case 1: Say("Back and forth, Back and forth goes the Balance."); break;
					case 2: Say("Good or evil, you mean nothing, Mortal."); break;
					case 3: Say("The power you seek is not found in petty squabbles."); break;
					case 4: Say("One day the Stranger will return to Sosaria."); break;
					case 5: Say("Although some speak of virtue, it is time who rules the balance."); break;
					case 6: Say("The order was Love, Sol, Moon, and Death."); break;
					case 7: Say("The strings of time show the Guardian is coming."); break;
					};

					m_NextTalk = (DateTime.Now + TimeSpan.FromSeconds( 30 ));
				}
			}
		}

		[Constructable]
		public TimeLord() : base( )
		{
			SpeechHue = Server.Misc.RandomThings.GetSpeechHue();
			NameHue = -1;
			Body = 0x190;
			Hue = 0x430;
			Name = "the Time Lord";

			AddItem( new Sandals() );
			AddItem( new ClothCowl() );
			AddItem( new SorcererRobe() );

			SetStr( 3000, 3000 );
			SetDex( 3000, 3000 );
			SetInt( 3000, 3000 );

			SetHits( 6000,6000 );
			SetDamage( 500, 900 );

			VirtualArmor = 3000;

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );
			SetDamageType( ResistanceType.Energy, 60 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 35, 40 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 35, 40 );

			SetSkill( SkillName.EvalInt, 130.1, 140.0 );
			SetSkill( SkillName.Magery, 130.1, 140.0 );
			SetSkill( SkillName.Meditation, 110.1, 111.0 );
			SetSkill( SkillName.Poisoning, 110.1, 111.0 );
			SetSkill( SkillName.MagicResist, 185.2, 210.0 );
			SetSkill( SkillName.Tactics, 100.1, 110.0 );
			SetSkill( SkillName.Wrestling, 85.1, 110.0 );
			SetSkill( SkillName.Macing, 85.1, 110.0 );
			
			CantWalk = true;
		}

		public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override bool Unprovokable { get { return true; } }
		public override bool Uncalmable{ get{ return true; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			switch ( Utility.Random( 4 ))  
			{
				case 0: Say("Time for your life to end."); break;
				case 1: Say("this cosmos will survive without your treachery."); break;
				case 2: Say("" + defender.Name + " will be erased from time."); break;
				case 3: Say("I have forseen this day, " + defender.Name + "."); break;
			};
		}

      public override bool HandlesOnSpeech( Mobile from ) 
      { 
         return true; 
      } 

		public override void OnSpeech( SpeechEventArgs e ) 
		{
			if ( !(e.Mobile is PlayerMobile) )
				return;
			  
			if( e.Mobile.InRange( this, 4 ))
			{
				if ( ( e.Speech.ToLower() == "balance" ) )
				{
					PlayerMobile mobile = (PlayerMobile) e.Mobile;
					if ( ! mobile.HasGump( typeof( TimeLordGump ) ) )
					{
						mobile.SendGump( new TimeLordGump( mobile ));	
					} 
				}
				else if ( ( e.Speech.ToLower() == "nectu" ) ) // Clatu Verrata Nectu for good
				{
						PlayerMobile mobile = (PlayerMobile) e.Mobile;
							
						if (mobile.BalanceStatus != 0)
						{
							Say("You have already pledged to a path, " + e.Mobile.Name + "."); 
							return;
						}
						
						if (e.Mobile.Karma < 0 )
							e.Mobile.Karma = 0;
						
						if (mobile.BalanceStatus <= 0)
							mobile.BalanceStatus = 1;
						
						Say("Your choice has been made, you are now confirmed in the path of creation and preservation.");
						Say("Take this and use it well.");

					mobile.AddToBackpack ( new BalanceSpike() );

						
				}
				else if ( ( e.Speech.ToLower() == "necti" ) ) // Clatu Verrata Necti for evil
				{
					PlayerMobile mobile = (PlayerMobile) e.Mobile;
					
					if (mobile.BalanceStatus != 0)
					{
						Say("You have already pledged to a path, " + e.Mobile.Name + "."); 
						return;
					}
				
					if (e.Mobile.Karma > 0 )
						e.Mobile.Karma = 0;
				
					if (mobile.BalanceStatus >= 0)
						mobile.BalanceStatus = -1;
				
					Say("Your choice has been made, you are now confirmed in the path of destruction.");
					Say("Take this, you'll need it.");

					mobile.AddToBackpack ( new BalanceSpike() );

				}
				else 
				{ 
					base.OnSpeech( e ); 
				}
			} 
		} 

		public TimeLord( Serial serial ) : base( serial )
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
		}
	}
}