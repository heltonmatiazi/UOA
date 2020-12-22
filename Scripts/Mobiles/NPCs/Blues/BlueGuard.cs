using System; 
using Server;
using System.Collections; 
using System.Collections.Generic;
using Server.Targeting;
using Server.Misc; 
using Server.Items; 
using Server.Network;
using Server.ContextMenus;
using Server.Gumps;
using Server.Mobiles; 
using Server.Targeting;

namespace Server.Mobiles 
{ 
	public class BlueGuard : BaseBlue
	{ 
		private bool m_Bandaging;
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 30.0 );
		public DateTime m_NextTalk;
		private bool leetguard = false;

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			#region Tass23/Raist
			if ( !( m is PlayerMobile ) )
				return;
			
			if ((m is PlayerMobile) && (m.AccessLevel == AccessLevel.Player))
			{
				if ( InRange( m, 4 ) && !InRange( oldLocation, 4 ) && InLOS( m ) )
				{
					if ( !m.Frozen && DateTime.Now >= m_NextResurrect && !m.Alive )
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
					else if ( !m.Hidden && DateTime.Now >= m_NextResurrect && this.HealsYoungPlayers && m.Hits < (m.HitsMax/2) && m is PlayerMobile || DateTime.Now >= m_NextResurrect && m.Hits < (m.HitsMax/2) && m is BaseBlue )
					{
						OfferHeal( (PlayerMobile) m );
					}
					else if ( DateTime.Now >= m_NextTalk && !m.Hidden) // check if its time to talk
					{
						m_NextTalk = DateTime.Now + TalkDelay; // set next talk time
						if (m.Karma < 0)
							switch (Utility.Random(6))
						{
							case 0: Emote("Watch it " + m.Name + ", we're keeping an eye on you"); break;
							case 1: Emote("I've heard bad things about you, " + m.Name + "..."); break;
							case 2: Emote("Behave, here."); break;

							
						}

						else if (m.Karma <= -7500 && (Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "Lamut County"))
							switch (Utility.Random(6))
						{
							case 0: Emote("Good evening... *wink*"); break;
							case 1: Emote("*nods*"); break;
							case 2: Emote("Good morning... *wink*"); break;

							
						}
						
						else if (m.Karma <= -7500)
							switch (Utility.Random(6))
						{
							case 0: Emote("It's " + m.Name + " we found them!"); break;
							case 1: Emote("Halt!  We don't tolerate dark arts here!"); break;
							case 2: Emote("Run!  And never come back!!"); break;

							
						}
							
						else
						{
						switch (Utility.Random(15))
						{
							case 0: Emote("Hello " + m.Name + " what's your business here?"); break;
							case 1: Emote("If you kill any wanted individuals, bring us their heads, we might reward you."); break;
							case 2: Emote("" + m.Name + ", keep your eyes pealed for the evils of the lands."); break;
							case 3: Emote("Keep safe"); break;
							case 4: Emote("Stay safe"); break;
							case 5: Emote("Thank you for helping us keep these lands safe, " + m.Name + "."); break;
							case 6: Emote("Do you require assistance?"); break;
							case 7: Emote("We're always on the lookout for criminals... bring us their heads for a reward"); break;
							
						}
						}
					}
					else if ( DateTime.Now >= m_NextTalk && m.Hidden)
					{
						switch (Utility.Random(6))
						{
							case 0: Emote("What's that noise?"); break;
							case 1: Emote("Why does it smell so bad all of a sudden?"); break;
							case 2: Emote("Wait... I hear something... "); break;

							
						}
					}
						
				}
			}
			if (m is BlueGuard && this.Combatant != null)
            {
                if (m.Combatant == null)
                {
                    m.Combatant = Combatant;
					if (Utility.RandomBool())
						m.Say("I will aid thee!");  // what does the guard getting called say
					if (Utility.RandomBool())
						Say("Join me in battle!"); // what does the guard doing the calling say
                }
            }
			#endregion
		}

		public override bool CheckResurrect( Mobile m )
		{
			if ( m.Criminal )
			{
				Say("Thou art a Criminal!!! I will Smite Thee!"); // Thou art a criminal.  I shall not resurrect thee.
				return false;
			}
			else if ( m.Kills >= 5 )
			{
				Say("Thou art a murderer!  I will Smite Thee!"); // Thou'rt not a decent and good person. I shall not resurrect thee.
				return false;
			}
			else if ( m.Karma < -7500 )
			{
				Say("I have heard negative reports of Thee, but I shall set a good example."); // Thou hast strayed from the path of virtue, but thou still deservest a second chance.
				return false;
			}
			else if ( m.Karma < 0 )
			{
				Say("I have heard negative reports of Thee, but I shall set a good example and help you."); // Thou hast strayed from the path of virtue, but thou still deservest a second chance.
			}
			return true;
		}

		[Constructable] 
		public BlueGuard() : base( AIType.AI_Melee, FightMode.Closest, 25, 1, 0.4, 0.3 ) 
		{
			
			Job = JobFragment.guard;
			Karma = Utility.RandomMinMax( 13, -45 );
			AIFullSpeedActive = true; // Force full speed
			AIFullSpeedPassive = false;

			//bool leetguard = false;
			if (Utility.RandomDouble() < 0.20)
			{
				leetguard = true;
			}
				
			if (leetguard)
			{
				SetStr(500, 800);
				SetDex(300, 500);
				SetInt(50, 100);
				ActiveSpeed = 0.1;
				PassiveSpeed = 0;

				SetHits(300, 600);

				SetDamage(45, 65);

				SetDamageType(ResistanceType.Physical, 100);

				SetResistance(ResistanceType.Physical, 50, 70);
				SetResistance(ResistanceType.Fire, 50, 70);
				SetResistance(ResistanceType.Cold, 50, 70);
				SetResistance(ResistanceType.Poison, 50, 70);
				SetResistance(ResistanceType.Energy, 50, 70);

				SetSkill(SkillName.Swords, 100.0, 120.0);
				SetSkill(SkillName.Fencing, 100.0, 120.0);
				SetSkill(SkillName.Macing, 100.0, 120.0);
				SetSkill(SkillName.Tactics, 100.0, 120.0);				
				SetSkill(SkillName.Tactics, 100.0, 120.0);
				SetSkill(SkillName.MagicResist, 100.0, 120.0);
				SetSkill(SkillName.Tactics, 100.0, 120.0);
				SetSkill(SkillName.Parry, 100.0, 120.0);
				SetSkill(SkillName.Anatomy, 100.0, 120.0);
				SetSkill(SkillName.Healing, 100.0, 120.0);
				SetSkill(SkillName.Magery, 100.0, 120.0);
				SetSkill(SkillName.EvalInt, 100.0, 120.0);
				SetSkill(SkillName.DetectHidden, 90.0, 120.0);
				Fame = 10000;
				Karma = 5000;
				VirtualArmor = 30;
			}
			else
			{
				SetStr(200, 400);
				SetDex(100, 200);
				SetInt(50, 100);
				ActiveSpeed = 0.2;
				PassiveSpeed = 0.1;

				SetHits(200, 300);

				SetDamage(30, 40);

				SetDamageType(ResistanceType.Physical, 100);

				SetResistance(ResistanceType.Physical, 40, 50);
				SetResistance(ResistanceType.Fire, 40, 50);
				SetResistance(ResistanceType.Cold, 40, 50);
				SetResistance(ResistanceType.Poison, 40, 50);
				SetResistance(ResistanceType.Energy, 40, 50);

				SetSkill(SkillName.Swords, 89.0, 100.0);
				SetSkill(SkillName.Fencing, 89.0, 100.0);
				SetSkill(SkillName.Macing, 89.0, 100.0);
				SetSkill(SkillName.Tactics, 89.0, 100.0);
				SetSkill(SkillName.MagicResist, 89.0, 100.0);
				SetSkill(SkillName.Tactics, 89.0, 100.0);
				SetSkill(SkillName.Parry, 89.0, 100.0);
				SetSkill(SkillName.Anatomy, 85.0, 100.0);
				SetSkill(SkillName.Healing, 85.0, 100.0);
				SetSkill(SkillName.Magery, 85.0, 100.0);
				SetSkill(SkillName.EvalInt, 85.0, 100.0);
				SetSkill(SkillName.DetectHidden, 50.0, 100.0);
				Fame = 5000;
				Karma = 1000;
				VirtualArmor = 30;
			}
			
			Utility.AssignRandomHair( this );

			for (int i = 0; i < 10; i++)
			{
				PackItem( new GreaterCurePotion() );
				PackItem( new GreaterHealPotion() );
				PackItem( new TotalRefreshPotion() );
			}

			PackItem(new Bandage(Utility.RandomMinMax(10, 40)));
			PackItem(new Bola(Utility.RandomMinMax(1, 3)));
			
		}
		
		public override void OnAfterSpawn()
		{
			base.OnAfterSpawn();

			Region reg = Region.Find( this.Location, this.Map );

			string World = Server.Misc.Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y );

			int clothColor = 0;
			int shieldType = 0;
			int helmType = 0;
			int cloakColor = 0;

			Item weapon = new VikingSword(); weapon.Delete();

			if ( this.Map == Map.Trammel )
			{
				Title = "[Sosarian Guard]";
				if ( Female = Utility.RandomBool() ) 
				{ 
					Body = 401; //606 for elf
					Name = NameList.RandomName( "female" );	
				}
				else 
				{ 
					Body = 400; 	//605 for elf		
					Name = NameList.RandomName( "male" ); 
				}				
			}
			else if ( this.Map == Map.Felucca )
			{
				Title = "[Lodorian Guard]";
				Race = Race.Elf;
				if ( Female = Utility.RandomBool() ) 
				{ 
					Body = 606; //606 for elf
					Name = NameList.RandomName( "female" );	
				}
				else 
				{ 
					Body = 605; 	//605 for elf		
					Name = NameList.RandomName( "male" ); 
				}					
			}
			else 
			{
				Title = "[Guard]";				
				if ( Female = Utility.RandomBool() ) 
				{ 
					Body = 401; //606 for elf
					Name = NameList.RandomName( "female" );	
				}
				else 
				{ 
					Body = 400; 	//605 for elf		
					Name = NameList.RandomName( "male" ); 
				}	
			}

			if (leetguard)
			{
				clothColor = 0x2F;		shieldType = 0x1B76;	helmType = 0x1412;		cloakColor = 0x3AE;		weapon = new Longsword();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Village of Whisper" )
			{
				clothColor = 0x96D;		shieldType = 0x1B72;	helmType = 0x140E;		cloakColor = 0x972;		weapon = new Longsword();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Town of Glacial Hills" )
			{
				clothColor = 0x482;		shieldType = 0x1B74;	helmType = 0x1412;		cloakColor = 0x542;		weapon = new Kryss();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Village of Springvale" )
			{
				clothColor = 0x595;		shieldType = 0;			helmType = 0x140E;		cloakColor = 0x593;		weapon = new Pike();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the City of Elidor" )
			{
				clothColor = 0x665;		shieldType = 0x1B7B;	helmType = 0x1412;		cloakColor = 0x664;		weapon = new Katana();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Village of Islegem" )
			{
				clothColor = 0x7D1;		shieldType = 0;			helmType = 0x140E;		cloakColor = 0x7D6;		weapon = new Spear();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "Greensky Village" )
			{
				clothColor = 0x7D7;		shieldType = 0;			helmType = 0x1412;		cloakColor = 0x7DA;		weapon = new Bardiche();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Port of Dusk" )
			{
				clothColor = 0x601;		shieldType = 0x1B76;	helmType = 0x140E;		cloakColor = 0x600;		weapon = new Cutlass();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Port of Starguide" )
			{
				clothColor = 0x751;		shieldType = 0;			helmType = 0x1412;		cloakColor = 0x758;		weapon = new BladedStaff();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Village of Portshine" )
			{
				clothColor = 0x847;		shieldType = 0x1B7A;	helmType = 0x140E;		cloakColor = 0x851;		weapon = new Mace();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Ranger Outpost" )
			{
				clothColor = 0x598;		shieldType = 0;			helmType = 0x140E;		cloakColor = 0x83F;		weapon = new Spear();
			}
			else if ( World == "the Land of Lodoria" ) // ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the City of Lodoria" || Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Castle of Knowledge" || Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Lodoria City Park" || Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Village of Lodoria" || Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Lodoria Cemetery" )
			{
				clothColor = 0x6E4;		shieldType = 0x1BC4;	helmType = 0x1412;		cloakColor = 0x6E7;		weapon = new Scimitar();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Lunar City of Dawn" )
			{
				clothColor = 0x9C4;		shieldType = 0x1B76;	helmType = 0x140E;		cloakColor = 0x9C4;		weapon = new DiamondMace();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "The Town of Devil Guard" || Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "The Farmland of Devil Guard" )
			{
				clothColor = 0x430;		shieldType = 0;			helmType = 0x140E;		cloakColor = 0;			weapon = new LargeBattleAxe();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Town of Moon" )
			{
				clothColor = 0x8AF;		shieldType = 0x1B72;	helmType = 0x1412;		cloakColor = 0x972;		weapon = new Longsword();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Village of Grey" )
			{
				clothColor = 0;			shieldType = 0;			helmType = 0x140E;		cloakColor = 0x763;		weapon = new Halberd();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the City of Montor" )
			{
				clothColor = 0x96F;		shieldType = 0x1B74;	helmType = 0x1412;		cloakColor = 0x529;		weapon = new Broadsword();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Village of Fawn" )
			{
				clothColor = 0x59D;		shieldType = 0;			helmType = 0x140E;		cloakColor = 0x59C;		weapon = new DoubleAxe();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Village of Yew" )
			{
				clothColor = 0x83C;		shieldType = 0;			helmType = 0x1412;		cloakColor = 0x850;		weapon = new Spear();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "Iceclad Fisherman's Village" || Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Town of Mountain Crest" || Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "Glacial Coast Village" )
			{
				clothColor = 0x482;		shieldType = 0;			helmType = 0x140E;		cloakColor = 0x47E;		weapon = new Bardiche();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Undercity of Umbra" )
			{
				clothColor = 0x964;		shieldType = 0x1BC3;	helmType = 0x140E;		cloakColor = 0x966;		weapon = new BoneHarvester();
			}
			else if ( World == "the Island of Umber Veil" )
			{
				clothColor = 0xA5D;		shieldType = 0;			helmType = 0x140E;		cloakColor = 0x96D;		weapon = new Halberd();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the City of Kuldara" )
			{
				clothColor = 0x965;		shieldType = 0x1BC3;	helmType = 0x140E;		cloakColor = 0x845;		weapon = new Maul();
			}
			else if ( World == "the Isles of Dread" )
			{
				clothColor = 0x978;		shieldType = 0;			helmType = 0x2645;		cloakColor = 0x973;		weapon = new OrnateAxe();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Village of Barako" )
			{
				clothColor = 0x515;		shieldType = 0x1B72;	helmType = 0x2645;		cloakColor = 0x58D;		weapon = new WarMace();
			}
			else if ( World == "the Savaged Empire" ) // ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Village of Kurak" )
			{
				clothColor = 0x515;		shieldType = 0;			helmType = 0x140E;		cloakColor = 0x59D;		weapon = new Spear();
			}
			else if ( World == "the Serpent Island" ) // ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the City of Furnace" )
			{
				clothColor = 0x515;		shieldType = 0;			helmType = 0x2FBB;		cloakColor = 0;			weapon = new Halberd();
			}
			else if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "Sarth Abbey" )
			{
				clothColor = 0x3C5;		shieldType = 0x1B74;	helmType = 0x1544;		cloakColor = 0x3AE;		weapon = new Dagger();
			}
			else // if ( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the City of Britain" || Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Britain Castle Grounds" || Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "Lord British Castle" || Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Britain Dungeons" )
			{
				clothColor = 0x9C4;		shieldType = 0x1BC4;	helmType = 0x140E;		cloakColor = 0x845;		weapon = new VikingSword();
			}

			weapon.Movable = true;
			((BaseWeapon)weapon).MaxHitPoints = 250;
			((BaseWeapon)weapon).HitPoints = 100;
			((BaseWeapon)weapon).MinDamage = 10;
			((BaseWeapon)weapon).MaxDamage = 25;
			AddItem( weapon );

			AddItem( new PlateChest() );
			if ( World == "the Serpent Island" ){ AddItem( new RingmailArms() ); } else { AddItem( new PlateArms() ); } // FOR GARGOYLES
			AddItem( new PlateLegs() );
			AddItem( new PlateGorget() );
			AddItem( new PlateGloves() );
			AddItem( new Boots( ) );

			if ( helmType > 0 )
			{
				PlateHelm helm = new PlateHelm();
					helm.ItemID = helmType;
					helm.Name = "helm";
					AddItem( helm );
			}
			if ( shieldType > 0 )
			{
				ChaosShield shield = new ChaosShield();
					shield.ItemID = shieldType;
					shield.Name = "shield";
					AddItem( shield );
			}

			MorphingTime.ColorMyClothes( this, clothColor );

			if ( cloakColor > 0 )
			{
				Cloak cloak = new Cloak();
					cloak.Hue = cloakColor;
					AddItem( cloak );
			}

			Server.Misc.MorphingTime.CheckMorph( this );
		}		
		
		public override void OnGaveMeleeAttack( Mobile defender )
		{
			switch ( Utility.Random( 15 ))		   
			{
				case 0: Say("Die villain!"); break;
				case 1: Say("I will bring you justice!"); break;
				case 2: Say("So, " + defender.Name + "? Your evil ends here!"); break;
				case 3: Say("We have been told to watch for " + defender.Name + "!"); break;
				case 4: Say("Fellow guardsmen, " + defender.Name + " is here!"); break;
				case 5: Say("We have ways of dealing with the likes of " + defender.Name + "!"); break;
				case 6: Say("Give up! We do not fear " + defender.Name + "!"); break;
				case 7: Say("So, " + defender.Name + "? I sentence you to death!"); break;
			};
		}		
		

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
        public override bool CanHeal { get { return true; } }

		public override void OnThink()
		{
			base.OnThink();
			
			// Use bandages
			if ( (this.IsHurt() || this.Poisoned) && m_Bandaging == false )
			{
				Bandage m_Band = (Bandage)this.Backpack.FindItemByType( typeof ( Bandage ) );
				
				if ( m_Band != null )
				{
					m_Bandaging = true;
					
					if ( BandageContext.BeginHeal( this, this ) != null )
						m_Band.Consume();
					BandageTimer bt = new BandageTimer( this );
					bt.Start();
				}
			}
			
			if (this.Combatant != null && this.Combatant.Mounted)
			{
				Server.Ability.TossBola(this);
			}
			
		}

		private class BandageTimer : Timer 
		{ 
			private BlueGuard pk;

			public BandageTimer( BlueGuard o ) : base( TimeSpan.FromSeconds( 4 ) ) 
			{ 
				pk = o;
				Priority = TimerPriority.OneSecond; 
			} 
		
 			protected override void OnTick() 
			{ 
				pk.m_Bandaging = false; 
			} 
		}



		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( dropped is PirateBounty )
			{
				if ( IntelligentAction.GetMyEnemies( from, this, false ) == true )
				{
					string sSay = "You shouldn't be carrying that around with you.";
					this.PrivateOverheadMessage(MessageType.Regular, 1153, false, sSay, from.NetState);
				}
				else
				{
					PirateBounty bounty = (PirateBounty)dropped;
					int fame = (int)(bounty.BountyValue/5);
					int karma = -1*fame;
					int gold = bounty.BountyValue;
					string sMessage = "";
					string sReward = "Here is " + gold.ToString() + " gold for you.";

					switch ( Utility.RandomMinMax( 0, 9 ) )
					{
						case 0:	sReward = "Here is " + gold.ToString() + " gold for you.";							break;
						case 1:	sReward = "Take this " + gold.ToString() + " gold for your trouble.";				break;
						case 2:	sReward = "The reward is " + gold.ToString() + " gold.";							break;
						case 3:	sReward = "Here is " + gold.ToString() + " gold for the bounty.";					break;
						case 4:	sReward = "The bounty is " + gold.ToString() + " gold for this one.";				break;
						case 5:	sReward = "Here is your reward of " + gold.ToString() + " gold";					break;
						case 6:	sReward = "You can have this " + gold.ToString() + " gold for the bounty.";			break;
						case 7:	sReward = "There is a reward of " + gold.ToString() + " gold for this one.";		break;
						case 8:	sReward = "This one was worth " + gold.ToString() + " gold for their crimes.";		break;
						case 9:	sReward = "Their crimes called for a bounty of " + gold.ToString() + " gold.";		break;
					}

					Titles.AwardKarma( from, karma, true );
					Titles.AwardFame( from, fame, true );
					from.SendSound( 0x2E6 );
					from.AddToBackpack ( new Gold( gold ) );

					switch ( Utility.RandomMinMax( 0, 9 ) )
					{
						case 0:	sMessage = "We have been looking for this pirate. " + sReward;	break;
						case 1:	sMessage = "I have heard of this pirate before. " + sReward;	break;
						case 2:	sMessage = "I never thought I would see this pirate brought to justice. " + sReward;	break;
						case 3:	sMessage = "This pirate will plunder no more. " + sReward;	break;
						case 4:	sMessage = "Our galleons are safer now. " + sReward;	break;
						case 5:	sMessage = "The sea is safer because of you. " + sReward;	break;
						case 6:	sMessage = "The sailors at the docks will not believe this. " + sReward;	break;
						case 7:	sMessage = "I have only heard stories about this pirate. " + sReward;	break;
						case 8:	sMessage = "How did you come across this pirate? " + sReward;	break;
						case 9:	sMessage = "Where did you find this pirate? " + sReward;	break;
					}
					this.PrivateOverheadMessage(MessageType.Regular, 1153, false, sMessage, from.NetState);
					dropped.Delete();
					return true;
				}
			}
			else if ( dropped is Head && !from.Blessed )
			{
				if ( IntelligentAction.GetMyEnemies( from, this, false ) == true )
				{
					string sSay = "You shouldn't be carrying that around with you.";
					this.PrivateOverheadMessage(MessageType.Regular, 1153, false, sSay, from.NetState);
				}
				else
				{
					Head head = (Head)dropped;
					int karma = 0;
					int gold = 0;
					string sMessage = "";
					string sReward = "Here is " + gold.ToString() + " gold for you.";

					if ( head.m_Job == "Thief" )
					{
						karma = Utility.RandomMinMax( 40, 60 );
						gold = Utility.RandomMinMax( 80, 120 );
					}
					else if ( head.m_Job == "Bandit" )
					{
						karma = Utility.RandomMinMax( 20, 30 );
						gold = Utility.RandomMinMax( 30, 60 );
					}
					else if ( head.m_Job == "Brigand" )
					{
						karma = Utility.RandomMinMax( 30, 40 );
						gold = Utility.RandomMinMax( 50, 100 );
					}
					else if ( head.m_Job == "Pirate" )
					{
						karma = Utility.RandomMinMax( 90, 110 );
						gold = Utility.RandomMinMax( 120, 190 );
					}
					else if ( head.m_Job == "Assassin" )
					{
						karma = Utility.RandomMinMax( 60, 1000 );
						gold = Utility.RandomMinMax( 200, 300 );
					}
					else if ( head.m_Job == "Mounted Player Killer" )
					{
						karma = Utility.RandomMinMax( 5000, 14000 );
						gold = Utility.RandomMinMax( 1000, 3500 );
					}
					else if ( head.m_Job == "Player Killer" )
					{
						karma = Utility.RandomMinMax( 500, 2000 );
						gold = Utility.RandomMinMax( 500, 1500 );
					}
					else if ( head.m_Job == "Mage" )
					{
						karma = Utility.RandomMinMax( 50, 100 );
						gold = Utility.RandomMinMax( 80, 200 );
					}
					else if ( head.m_Job == "Bard" )
					{
						karma = Utility.RandomMinMax( 50, 100 );
						gold = Utility.RandomMinMax( 80, 200 );
					}
					else if ( head.m_Job == "MageLord" )
					{
						karma = Utility.RandomMinMax( 100, 200 );
						gold = Utility.RandomMinMax( 150, 350 );
					}
					else if ( head.m_Job == "Monk" )
					{
						karma = Utility.RandomMinMax( 200, 500 );
						gold = Utility.RandomMinMax( 50, 80 );
					}
					else if ( head.m_Job == "Executioner" )
					{
						karma = Utility.RandomMinMax( 100, 200 );
						gold = Utility.RandomMinMax( 100, 150 );
					}
					else if ( head.m_Job == "Warrior" )
					{
						karma = Utility.RandomMinMax( 50, 100 );
						gold = Utility.RandomMinMax( 50, 100 );
					}
					else if ( head.m_Job == "Knight" )
					{
						karma = Utility.RandomMinMax( 200, 500 );
						gold = Utility.RandomMinMax( 200, 300 );
					}
					else if ( head.m_Job == "Cultist" )
					{
						karma = Utility.RandomMinMax( 200, 500 );
						gold = Utility.RandomMinMax( 50, 100 );
					}
					else if ( head.m_Job == "Controller" )
					{
						karma = Utility.RandomMinMax( 200, 500 );
						gold = Utility.RandomMinMax( 200, 500 );
					}					

					switch ( Utility.RandomMinMax( 0, 9 ) )
					{
						case 0:	sReward = "Here is " + gold.ToString() + " gold for you.";							break;
						case 1:	sReward = "Take this " + gold.ToString() + " gold for your trouble.";				break;
						case 2:	sReward = "The reward is " + gold.ToString() + " gold.";							break;
						case 3:	sReward = "Here is " + gold.ToString() + " gold for the bounty.";					break;
						case 4:	sReward = "The bounty is " + gold.ToString() + " gold for this one.";				break;
						case 5:	sReward = "Here is your reward of " + gold.ToString() + " gold";					break;
						case 6:	sReward = "You can have this " + gold.ToString() + " gold for the bounty.";			break;
						case 7:	sReward = "There is a reward of " + gold.ToString() + " gold for this one.";		break;
						case 8:	sReward = "This one was worth " + gold.ToString() + " gold for their crimes.";		break;
						case 9:	sReward = "Their crimes called for a bounty of " + gold.ToString() + " gold.";		break;
					}


					if ( head.m_Job == "Thief" || head.m_Job == "Bandit" || head.m_Job == "Brigand" )
					{
						Titles.AwardKarma( from, karma, true );
						from.SendSound( 0x2E6 );
						from.AddToBackpack ( new Gold( gold ) );

						switch ( Utility.RandomMinMax( 0, 9 ) )
						{
							case 0:	sMessage = "We have been looking for this rogue. " + sReward;	break;
							case 1:	sMessage = "I have heard of this thief before. " + sReward;	break;
							case 2:	sMessage = "I never thought I would see this bandit brought to justice. " + sReward;	break;
							case 3:	sMessage = "This rouge will steal no more. " + sReward;	break;
							case 4:	sMessage = "Our gold purses are safer now. " + sReward;	break;
							case 5:	sMessage = "The land is safer because of you. " + sReward;	break;
							case 6:	sMessage = "The others at the guard house will not believe this. " + sReward;	break;
							case 7:	sMessage = "I have only heard stories about this rogue. " + sReward;	break;
							case 8:	sMessage = "How did you come across this thief? " + sReward;	break;
							case 9:	sMessage = "Where did you find this sneak? " + sReward;	break;
						}
						this.PrivateOverheadMessage(MessageType.Regular, 1153, false, sMessage, from.NetState);
						dropped.Delete();
						return true;
					}
					else if ( head.m_Job == "Pirate" )
					{
						Titles.AwardKarma( from, karma, true );
						from.SendSound( 0x2E6 );
						from.AddToBackpack ( new Gold( gold ) );

						switch ( Utility.RandomMinMax( 0, 9 ) )
						{
							case 0:	sMessage = "We have been looking for this pirate. " + sReward;	break;
							case 1:	sMessage = "I have heard of this pirate before. " + sReward;	break;
							case 2:	sMessage = "I never thought I would see this pirate brought to justice. " + sReward;	break;
							case 3:	sMessage = "This pirate will plunder no more. " + sReward;	break;
							case 4:	sMessage = "Our galleons are safer now. " + sReward;	break;
							case 5:	sMessage = "The sea is safer because of you. " + sReward;	break;
							case 6:	sMessage = "The sailors at the docks will not believe this. " + sReward;	break;
							case 7:	sMessage = "I have only heard stories about this pirate. " + sReward;	break;
							case 8:	sMessage = "How did you come across this pirate? " + sReward;	break;
							case 9:	sMessage = "Where did you find this pirate? " + sReward;	break;
						}
						this.PrivateOverheadMessage(MessageType.Regular, 1153, false, sMessage, from.NetState);
						dropped.Delete();
						return true;
					}
					else if ( head.m_Job == "Assassin" || head.m_Job == "Player Killer" || head.m_Job == "Mounted Player Killer" )
					{
						Titles.AwardKarma( from, karma, true );
						from.SendSound( 0x2E6 );
						from.AddToBackpack ( new Gold( gold ) );

						switch ( Utility.RandomMinMax( 0, 9 ) )
						{
							case 0:	sMessage = "We have been living in fear of this one. " + sReward;	break;
							case 1:	sMessage = "I have heard others speak of this assassin. " + sReward;	break;
							case 2:	sMessage = "I never thought this assassin existed. " + sReward;	break;
							case 3:	sMessage = "This assassin will kill no more. " + sReward;	break;
							case 4:	sMessage = "Our nobles are safer now. " + sReward;	break;
							case 5:	sMessage = "The shadows are less feared because of you. " + sReward;	break;
							case 6:	sMessage = "Those in the tavern will not believe this. " + sReward;	break;
							case 7:	sMessage = "I have only heard rumors about this assassin. " + sReward;	break;
							case 8:	sMessage = "It is good to see this assassin did not best you. " + sReward;	break;
							case 9:	sMessage = "How did you survive this assassin? " + sReward;	break;
						}
						this.PrivateOverheadMessage(MessageType.Regular, 1153, false, sMessage, from.NetState);
						dropped.Delete();
						return true;
					}
					else
					{
						this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I assume they done you harm. Let me rid you of this thing.", from.NetState);
						dropped.Delete();
						return true;
					}
				}
			}
			
		return base.OnDragDrop( from, dropped );			
		}
		
			public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{ 
			base.GetContextMenuEntries( from, list ); 
			list.Add( new SpeechGumpEntry( from, this ) ); 
		} 

		public class SpeechGumpEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SpeechGumpEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{
			    if( !( m_Mobile is PlayerMobile ) )
				return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				{
					if ( ! mobile.HasGump( typeof( SpeechGump ) ) )
					{
						mobile.SendGump(new SpeechGump( "The Duties Of The Guard", SpeechFunctions.SpeechText( m_Giver.Name, m_Mobile.Name, "Guard" ) ));
					}
				}

				ArrayList wanted = new ArrayList();
				int w = 0;
				foreach ( Item item in World.Items.Values )
				{
					if ( item is CharacterDatabase )
					{
						CharacterDatabase DB = (CharacterDatabase)item;

						if ( DB.CharacterWanted != null && DB.CharacterWanted != "" )
						{
							wanted.Add( item );
							w++;
						}
					}
				}
				int wChoice = Utility.RandomMinMax( 1, w );
				int c = 0;
				for ( int i = 0; i < wanted.Count; ++i )
				{
					c++;
					if ( c == wChoice )
					{
						CharacterDatabase DB = ( CharacterDatabase )wanted[ i ];
						GuardNote note = new GuardNote();
						note.ScrollText = DB.CharacterWanted;
						m_Mobile.AddToBackpack( note );
						m_Giver.Say("Here is a note citizen. Be on the lookout.");
					}
				}
            }
        }	
		
		public BlueGuard( Serial serial ) : base( serial ) 
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
			AIFullSpeedActive = true; // Force full speed
			AIFullSpeedPassive = false;
		} 		
		
		
	}	
}   
