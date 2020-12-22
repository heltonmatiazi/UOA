using Server.Accounting;
using Server.Commands.Generic;
using Server.Commands;
using Server.ContextMenus;
using Server.Engines.CannedEvil;
using Server.Engines.Craft;
using Server.Engines.Plants;
using Server.Engines.VeteranRewards;
using Server.Ethics;
using Server.Factions.AI;
using Server.Factions;
using Server.Guilds;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Multis;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using Server.Spells.Fifth;
using Server.Spells.First;
using Server.Spells.Fourth;
using Server.Spells.Second;
using Server.Spells.Seventh;
using Server.Spells.Sixth;
using Server.Spells.Third;
using Server.Spells;
using Server.Targeting;
using Server.Targets;
using Server;
using System.Collections.Generic;
using System.Collections;
using System.Data.Odbc;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System;


// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class AmethystWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 1 ); }


		[Constructable]
		public AmethystWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the amethyst wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "amethyst", "monster", 0 );


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "amethyst scales" );
   			c.DropItem(scale);
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public AmethystWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;


namespace Server.Mobiles
{
	[CorpseName( "a nightmare corpse" )]
	public class AncientNightmare : BaseCreature
	{
		public override bool HasBreath{ get{ return true; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }


		[Constructable]
		public AncientNightmare() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ancient nightmare";
			Body = 795;
			BaseSoundID = 0xA8;


			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );


			SetHits( 298, 315 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );


			SetSkill( SkillName.EvalInt, 10.4, 50.0 );
			SetSkill( SkillName.Magery, 10.4, 50.0 );
			SetSkill( SkillName.MagicResist, 85.3, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 80.5, 92.5 );


			Fame = 14000;
			Karma = -14000;


			VirtualArmor = 60;


			PackItem( new SulfurousAsh( Utility.RandomMinMax( 13, 19 ) ) );


			AddItem( new LightSource() );
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Potions );
		}


		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Hellish; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 5 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }


		public AncientNightmare( Serial serial ) : base( serial )
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
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Engines.CannedEvil;// using System.Collections.Generic;


namespace Server.Factions
{
	public abstract class BaseFactionGuard : BaseCreature
	{
		private Faction m_Faction;
		private Town m_Town;
		private Orders m_Orders;


		public override bool BardImmune{ get{ return true; } }


		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set{ Unregister(); m_Faction = value; Register(); }
		}


		public Orders Orders
		{
			get{ return m_Orders; }
		}


		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public Town Town
		{
			get{ return m_Town; }
			set{ Unregister(); m_Town = value; Register(); }
		}


		public void Register()
		{
			if ( m_Town != null && m_Faction != null )
				m_Town.RegisterGuard( this );
		}


		public void Unregister()
		{
			if ( m_Town != null )
				m_Town.UnregisterGuard( this );
		}


		public abstract GuardAI GuardAI{ get; }


		protected override BaseAI ForcedAI
		{
			get { return new FactionGuardAI( this ); }
		}


		public override TimeSpan ReacquireDelay{ get{ return TimeSpan.FromSeconds( 2.0 ); } }
 
		public override bool IsEnemy( Mobile m )
		{
			Faction ourFaction = m_Faction;
			Faction theirFaction = Faction.Find( m );


			if ( theirFaction == null && m is BaseFactionGuard )
				theirFaction = ((BaseFactionGuard)m).Faction;


			if ( ourFaction != null && theirFaction != null && ourFaction != theirFaction )
			{
				ReactionType reactionType = Orders.GetReaction( theirFaction ).Type;


				if ( reactionType == ReactionType.Attack )
					return true;


				if ( theirFaction != null )
				{
					List<AggressorInfo> list = m.Aggressed;


					for ( int i = 0; i < list.Count; ++i )
					{
						AggressorInfo ai = list[i];


						if ( ai.Defender is BaseFactionGuard )
						{
							BaseFactionGuard bf = (BaseFactionGuard)ai.Defender;


							if ( bf.Faction == ourFaction )
								return true;
						}
					}
				}
			}


			return false;
		}
 
		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m.Player && m.Alive && InRange( m, 10 ) && !InRange( oldLocation, 10 ) && InLOS( m ) && m_Orders.GetReaction( Faction.Find( m ) ).Type == ReactionType.Warn )
			{
				Direction = GetDirectionTo( m );


				string warning = null;


				switch ( Utility.Random( 6 ) )
				{
					case 0: warning = "I warn you, {0}, you would do well to leave this area before someone shows you the world of gray."; break;
					case 1: warning = "It would be wise to leave this area, {0}, lest your head become my commanders' trophy."; break;
					case 2: warning = "You are bold, {0}, for one of the meager {1}. Leave now, lest you be taught the taste of dirt."; break;
					case 3: warning = "Your presence here is an insult, {0}. Be gone now, knave."; break;
					case 4: warning = "Dost thou wish to be hung by your toes, {0}? Nay? Then come no closer."; break;
					case 5: warning = "Hey, {0}. Yeah, you. Get out of here before I beat you with a stick."; break;
				}


				Faction faction = Faction.Find( m );


				Say( warning, m.Name, faction == null ? "civilians" : faction.Definition.FriendlyName );
			}
		}


		private const int ListenRange = 12;


		public override bool HandlesOnSpeech( Mobile from )
		{
			if ( InRange( from, ListenRange ) )
				return true;


			return base.HandlesOnSpeech( from );
		}


		private DateTime m_OrdersEnd;


		private void ChangeReaction( Faction faction, ReactionType type )
		{
			if ( faction == null )
			{
				switch ( type )
				{
					case ReactionType.Ignore:	Say( 1005179 ); break; // Civilians will now be ignored.
					case ReactionType.Warn:		Say( 1005180 ); break; // Civilians will now be warned of their impending deaths.
					case ReactionType.Attack:	return;
				}
			}
			else
			{
				TextDefinition def = null;


				switch ( type )
				{
					case ReactionType.Ignore:	def = faction.Definition.GuardIgnore; break;
					case ReactionType.Warn:		def = faction.Definition.GuardWarn; break;
					case ReactionType.Attack:	def = faction.Definition.GuardAttack; break;
				}


				if ( def != null && def.Number > 0 )
					Say( def.Number );
				else if ( def != null && def.String != null )
					Say( def.String );
			}


			m_Orders.SetReaction( faction, type );
		}


		private bool WasNamed( string speech )
		{
			string name = this.Name;


			return ( name != null && Insensitive.StartsWith( speech, name ) );
		}
 
		public override void OnSpeech( SpeechEventArgs e )
		{
			base.OnSpeech( e );


			Mobile from = e.Mobile;


			if ( !e.Handled && InRange( from, ListenRange ) && from.Alive )
			{
				if ( e.HasKeyword( 0xE6 ) && (Insensitive.Equals( e.Speech, "orders" ) || WasNamed( e.Speech )) ) // *orders*
				{
					if ( m_Town == null || !m_Town.IsSheriff( from ) )
					{
						this.Say( 1042189 ); // I don't work for you!
					}
					else if ( Town.FromRegion( this.Region ) == m_Town )
					{
						this.Say( 1042180 ); // Your orders, sire?
						m_OrdersEnd = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
					}
				}
				else if ( DateTime.Now < m_OrdersEnd )
				{
					if ( m_Town != null && m_Town.IsSheriff( from ) && Town.FromRegion( this.Region ) == m_Town )
					{
						m_OrdersEnd = DateTime.Now + TimeSpan.FromSeconds( 10.0 );


						bool understood = true;
						ReactionType newType = 0;


						if ( Insensitive.Contains( e.Speech, "attack" ) )
							newType = ReactionType.Attack;
						else if ( Insensitive.Contains( e.Speech, "warn" ) )
							newType = ReactionType.Warn;
						else if ( Insensitive.Contains( e.Speech, "ignore" ) )
							newType = ReactionType.Ignore;
						else
							understood = false;


						if ( understood )
						{
							understood = false;


							if ( Insensitive.Contains( e.Speech, "civil" ) )
							{
								ChangeReaction( null, newType );
								understood = true;
							}


							List<Faction> factions = Faction.Factions;


							for ( int i = 0; i < factions.Count; ++i )
							{
								Faction faction = factions[i];


								if ( faction != m_Faction && Insensitive.Contains( e.Speech, faction.Definition.Keyword ) )
								{
									ChangeReaction( faction, newType );
									understood = true;
								}
							}
						}
						else if ( Insensitive.Contains( e.Speech, "patrol" ) )
						{
							Home = Location;
							RangeHome = 6;
							Combatant = null;
							m_Orders.Movement = MovementType.Patrol;
							Say( 1005146 ); // This spot looks like it needs protection!  I shall guard it with my life.
							understood = true;
						}
						else if ( Insensitive.Contains( e.Speech, "follow" ) )
						{
							Home = Location;
							RangeHome = 6;
							Combatant = null;
							m_Orders.Follow = from;
							m_Orders.Movement = MovementType.Follow;
							Say( 1005144 ); // Yes, Sire.
							understood = true;
						}


						if ( !understood )
							Say( 1042183 ); // I'm sorry, I don't understand your orders...
					}
				}
			}
		}


		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );


			if ( m_Faction != null && Map == Faction.Facet )
				list.Add( 1060846, m_Faction.Definition.PropName ); // Guard: ~1_val~
		}


		public override void OnSingleClick( Mobile from )
		{
			if ( m_Faction != null && Map == Faction.Facet )
			{
				string text = String.Concat( "(Guard, ", m_Faction.Definition.FriendlyName, ")" );


				int hue = ( Faction.Find( from ) == m_Faction ? 98 : 38 );


				PrivateOverheadMessage( MessageType.Label, hue, true, text, from.NetState );
			}


			base.OnSingleClick( from );
		}


		public virtual void GenerateRandomHair()
		{
			Utility.AssignRandomHair( this );
			Utility.AssignRandomFacialHair( this, HairHue );
		}


		private static Type[] m_StrongPotions = new Type[]
		{
			typeof( GreaterHealPotion ), typeof( GreaterHealPotion ), typeof( GreaterHealPotion ),
			typeof( GreaterCurePotion ), typeof( GreaterCurePotion ), typeof( GreaterCurePotion ),
			typeof( GreaterStrengthPotion ), typeof( GreaterStrengthPotion ),
			typeof( GreaterAgilityPotion ), typeof( GreaterAgilityPotion ),
			typeof( TotalRefreshPotion ), typeof( TotalRefreshPotion ),
			typeof( GreaterExplosionPotion )
		};


		private static Type[] m_WeakPotions = new Type[]
		{
			typeof( HealPotion ), typeof( HealPotion ), typeof( HealPotion ),
			typeof( CurePotion ), typeof( CurePotion ), typeof( CurePotion ),
			typeof( StrengthPotion ), typeof( StrengthPotion ),
			typeof( AgilityPotion ), typeof( AgilityPotion ),
			typeof( RefreshPotion ), typeof( RefreshPotion ),
			typeof( ExplosionPotion )
		};


		public void PackStrongPotions( int min, int max )
		{
			PackStrongPotions( Utility.RandomMinMax( min, max ) );
		}


		public void PackStrongPotions( int count )
		{
			for ( int i = 0; i < count; ++i )
				PackStrongPotion();
		}


		public void PackStrongPotion()
		{
			PackItem( Loot.Construct( m_StrongPotions ) );
		}


		public void PackWeakPotions( int min, int max )
		{
			PackWeakPotions( Utility.RandomMinMax( min, max ) );
		}


		public void PackWeakPotions( int count )
		{
			for ( int i = 0; i < count; ++i )
				PackWeakPotion();
		}


		public void PackWeakPotion()
		{
			PackItem( Loot.Construct( m_WeakPotions ) );
		}


		public Item Immovable( Item item )
		{
			item.Movable = false;
			return item;
		}


		public Item Newbied( Item item )
		{
			item.LootType = LootType.Newbied;
			return item;
		}


		public Item Rehued( Item item, int hue )
		{
			item.Hue = hue;
			return item;
		}


		public Item Layered( Item item, Layer layer )
		{
			item.Layer = layer;
			return item;
		}


		public Item Resourced( BaseWeapon weapon, CraftResource resource )
		{
			weapon.Resource = resource;
			return weapon;
		}


		public Item Resourced( BaseArmor armor, CraftResource resource )
		{
			armor.Resource = resource;
			return armor;
		}


		public override void OnAfterDelete()
		{
			base.OnAfterDelete();
			Unregister();
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			c.Delete();
		}


		public virtual void GenerateBody( bool isFemale, bool randomHair )
		{
			Hue = Server.Misc.RandomThings.GetRandomSkinColor();


			if ( isFemale )
			{
				Female = true;
				Body = 401;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Female = false;
				Body = 400;
				Name = NameList.RandomName( "male" );
			}


			if ( randomHair )
				GenerateRandomHair();
		}


		public override bool ClickTitle{ get{ return false; } }


		public BaseFactionGuard( string title ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			m_Orders = new Orders( this );
			Title = title;


			RangeHome = 6;
		}


		public BaseFactionGuard( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			Faction.WriteReference( writer, m_Faction );
			Town.WriteReference( writer, m_Town );


			m_Orders.Serialize( writer );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			m_Faction = Faction.ReadReference( reader );
			m_Town = Town.ReadReference( reader );
			m_Orders = new Orders( this, reader );


			Timer.DelayCall( TimeSpan.Zero, new TimerCallback( Register ) );
		}
	}


	public class VirtualMount : IMount
	{
		private VirtualMountItem m_Item;


		public Mobile Rider
		{
			get{ return m_Item.Rider; }
			set{}
		}


		public VirtualMount( VirtualMountItem item )
		{
			m_Item = item;
		}


		public virtual void OnRiderDamaged( int amount, Mobile from, bool willKill )
		{
		}
	}


	public class VirtualMountItem : Item, IMountItem
	{
		private Mobile m_Rider;
		private VirtualMount m_Mount;


		public Mobile Rider{ get{ return m_Rider; } }


		public VirtualMountItem( Mobile mob ) : base( 0x3EA0 )
		{
			Layer = Layer.Mount;


			m_Rider = mob;
			m_Mount = new VirtualMount( this );
		}


		public IMount Mount
		{
			get{ return m_Mount; }
		}


		public VirtualMountItem( Serial serial ) : base( serial )
		{
			m_Mount = new VirtualMount( this );
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			writer.Write( (Mobile) m_Rider );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			m_Rider = reader.ReadMobile();


			if ( m_Rider == null )
				Delete();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Network;// using Server.Regions;


namespace Server.Factions
{
	public enum AllowedPlacing
	{
		Everywhere,


		AnyFactionTown,
		ControlledFactionTown,
		FactionStronghold
	}


	public abstract class BaseFactionTrap : BaseTrap
	{
		private Faction m_Faction;
		private Mobile m_Placer;
		private DateTime m_TimeOfPlacement;


		private Timer m_Concealing;


		[CommandProperty( AccessLevel.GameMaster )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set{ m_Faction = value; }
		}


		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Placer
		{
			get{ return m_Placer; }
			set{ m_Placer = value; }
		}


		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime TimeOfPlacement
		{
			get{ return m_TimeOfPlacement; }
			set{ m_TimeOfPlacement = value; }
		}


		public virtual int EffectSound{ get{ return 0; } }


		public virtual int SilverFromDisarm{ get{ return 100; } }


		public virtual int MessageHue{ get{ return 0; } }


		public virtual int AttackMessage{ get{ return 0; } }
		public virtual int DisarmMessage{ get{ return 0; } }


		public virtual AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.Everywhere; } }


		public virtual TimeSpan ConcealPeriod
		{
			get{ return TimeSpan.FromMinutes( 1.0 ); }
		}


		public virtual TimeSpan DecayPeriod
		{
			get
			{
				if ( Core.AOS )
					return TimeSpan.FromDays( 1.0 );


				return TimeSpan.MaxValue; // no decay
			}
		}


		public override void OnTrigger( Mobile from )
		{
			if ( !IsEnemy( from ) )
				return;


			Conceal();


			DoVisibleEffect();
			Effects.PlaySound( this.Location, this.Map, this.EffectSound );
			DoAttackEffect( from );


			int silverToAward = ( from.Alive ? 20 : 40 );


			if ( silverToAward > 0 && m_Placer != null && m_Faction != null )
			{
				PlayerState victimState = PlayerState.Find( from );


				if ( victimState != null && victimState.CanGiveSilverTo( m_Placer ) && victimState.KillPoints > 0 )
				{
					int silverGiven = m_Faction.AwardSilver( m_Placer, silverToAward );


					if ( silverGiven > 0 )
					{
						// TODO: Get real message
						if ( from.Alive )
							m_Placer.SendMessage( "You have earned {0} silver pieces because {1} fell for your trap.", silverGiven, from.Name );
						else
							m_Placer.SendLocalizedMessage( 1042736, String.Format( "{0} silver\t{1}", silverGiven, from.Name ) ); // You have earned ~1_SILVER_AMOUNT~ pieces for vanquishing ~2_PLAYER_NAME~!
					}


					victimState.OnGivenSilverTo( m_Placer );
				}
			}


			from.LocalOverheadMessage( MessageType.Regular, MessageHue, AttackMessage );
		}


		public abstract void DoVisibleEffect();
		public abstract void DoAttackEffect( Mobile m );
        
		public virtual int IsValidLocation()
		{
			return IsValidLocation( GetWorldLocation(), Map );
		}


		public virtual int IsValidLocation( Point3D p, Map m )
		{
			if( m == null )
				return 502956; // You cannot place a trap on that.


			if( Core.ML )
			{
				foreach( Item item in m.GetItemsInRange( p, 0 ) )
				{
					if( item is BaseFactionTrap && ((BaseFactionTrap)item).Faction == this.Faction )
						return 1075263; // There is already a trap belonging to your faction at this location.;
				}
			}


			switch( AllowedPlacing )
			{
				case AllowedPlacing.FactionStronghold:
				{
					StrongholdRegion region = (StrongholdRegion) Region.Find( p, m ).GetRegion( typeof( StrongholdRegion ) );


					if ( region != null && region.Faction == m_Faction )
						return 0;


					return 1010355; // This trap can only be placed in your stronghold
				}
				case AllowedPlacing.AnyFactionTown:
				{
					Town town = Town.FromRegion( Region.Find( p, m ) );


					if ( town != null )
						return 0;


					return 1010356; // This trap can only be placed in a faction town
				}
				case AllowedPlacing.ControlledFactionTown:
				{
					Town town = Town.FromRegion( Region.Find( p, m ) );


					if ( town != null && town.Owner == m_Faction )
						return 0;


					return 1010357; // This trap can only be placed in a town your faction controls
				}
			}


			return 0;
		}


		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			base.OnMovement( m, oldLocation );


			if ( !CheckDecay() && CheckRange( m.Location, oldLocation, 6 ) )
			{
				if ( Faction.Find( m ) != null && ((m.Skills[SkillName.DetectHidden].Value - 80.0) / 20.0) > Utility.RandomDouble() )
					PrivateOverheadLocalizedMessage( m, 1010154, MessageHue, "", "" ); // [Faction Trap]
			}
		}


		public void PrivateOverheadLocalizedMessage( Mobile to, int number, int hue, string name, string args )
		{
			if ( to == null )
				return;


			NetState ns = to.NetState;


			if ( ns != null )
				ns.Send( new MessageLocalized( Serial, ItemID, MessageType.Regular, hue, 3, number, name, args ) );
		}


		public BaseFactionTrap( Faction f, Mobile m, int itemID ) : base( itemID )
		{
			Visible = false;


			m_Faction = f;
			m_TimeOfPlacement = DateTime.Now;
			m_Placer = m;
		}


		public BaseFactionTrap( Serial serial ) : base( serial )
		{
		}


		public virtual bool CheckDecay()
		{
			TimeSpan decayPeriod = DecayPeriod;


			if ( decayPeriod == TimeSpan.MaxValue )
				return false;


			if ( (m_TimeOfPlacement + decayPeriod) < DateTime.Now )
			{
				Timer.DelayCall( TimeSpan.Zero, new TimerCallback( Delete ) );
				return true;
			}


			return false;
		}


		public virtual void BeginConceal()
		{
			if ( m_Concealing != null )
				m_Concealing.Stop();


			m_Concealing = Timer.DelayCall( ConcealPeriod, new TimerCallback( Conceal ) );
		}


		public virtual void Conceal()
		{
			if ( m_Concealing != null )
				m_Concealing.Stop();


			m_Concealing = null;


			if ( !Deleted )
				Visible = false;
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			Faction.WriteReference( writer, m_Faction );
			writer.Write( (Mobile) m_Placer );
			writer.Write( (DateTime) m_TimeOfPlacement );


			if ( Visible )
				BeginConceal();
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			m_Faction = Faction.ReadReference( reader );
			m_Placer = reader.ReadMobile();
			m_TimeOfPlacement = reader.ReadDateTime();


			if ( Visible )
				BeginConceal();


			CheckDecay();
		}


		public override void OnDelete()
		{
			if ( m_Faction != null && m_Faction.Traps.Contains( this ) )
				m_Faction.Traps.Remove( this );


			base.OnDelete();
		}


		public virtual bool IsEnemy( Mobile mob )
		{
			if ( mob.Hidden && mob.AccessLevel > AccessLevel.Player )
				return false;


			if ( !mob.Alive || mob.IsDeadBondedPet )
				return false;


			Faction faction = Faction.Find( mob, true );


			if ( faction == null && mob is BaseFactionGuard )
				faction = ((BaseFactionGuard)mob).Faction;


			if ( faction == null )
				return false;


			return ( faction != m_Faction );
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Targeting;// using Server.Items;// using Server;// using Server.Engines.Craft;


namespace Server.Factions
{
	public abstract class BaseFactionTrapDeed : Item, ICraftable
	{
		public abstract Type TrapType{ get; }


		private Faction m_Faction;


		[CommandProperty( AccessLevel.GameMaster )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set
			{
				m_Faction = value;


				if ( m_Faction != null )
					Hue = m_Faction.Definition.HuePrimary;
			}
		}


		public BaseFactionTrapDeed( int itemID ) : base( itemID )
		{
			Weight = 1.0;
			LootType = LootType.Blessed;
		}


		public BaseFactionTrapDeed( bool createdFromDeed ) : this( 0x14F0 )
		{
		}


		public BaseFactionTrapDeed( Serial serial ) : base( serial )
		{
		}


		public virtual BaseFactionTrap Construct( Mobile from )
		{
			try{ return Activator.CreateInstance( TrapType, new object[]{ m_Faction, from } ) as BaseFactionTrap; }
			catch{ return null; }
		}


		public override void OnDoubleClick( Mobile from )
		{
			Faction faction = Faction.Find( from );


			if ( faction == null )
				from.SendLocalizedMessage( 1010353, "", 0x23 ); // Only faction members may place faction traps
			else if ( faction != m_Faction )
				from.SendLocalizedMessage( 1010354, "", 0x23 ); // You may only place faction traps created by your faction
			else if( faction.Traps.Count >= faction.MaximumTraps )
				from.SendLocalizedMessage( 1010358, "", 0x23 ); // Your faction already has the maximum number of traps placed
			else 
			{
				BaseFactionTrap trap = Construct( from );


				if ( trap == null )
					return;


				int message = trap.IsValidLocation( from.Location, from.Map );


				if ( message > 0 )
				{
					from.SendLocalizedMessage( message, "", 0x23 );
					trap.Delete();
				}
				else
				{
					from.SendLocalizedMessage( 1010360 ); // You arm the trap and carefully hide it from view
					trap.MoveToWorld( from.Location, from.Map );
					faction.Traps.Add( trap );
					Delete();
				}
			}
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			Faction.WriteReference( writer, m_Faction );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			m_Faction = Faction.ReadReference( reader );
		}
		#region ICraftable Members


		public int OnCraft( int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			ItemID = 0x14F0;
			Faction = Faction.Find( from );


			return 1;
		}


		#endregion
	}
}
// using System;// using System.Collections.Generic;// using Server;// using Server.Mobiles;


namespace Server.Factions
{
	public abstract class BaseFactionVendor : BaseVendor
	{
		private Town m_Town;
		private Faction m_Faction;


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Town Town
		{
			get{ return m_Town; }
			set{ Unregister(); m_Town = value; Register(); }
		}


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set{ Unregister(); m_Faction = value; Register(); }
		}


		public void Register()
		{
			if ( m_Town != null && m_Faction != null )
				m_Town.RegisterVendor( this );
		}


		public override bool OnMoveOver( Mobile m )
		{
			if ( Core.ML )
				return true;


			return base.OnMoveOver( m );
		}


		public void Unregister()
		{
			if ( m_Town != null )
				m_Town.UnregisterVendor( this );
		}


		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }


		public override void InitSBInfo()
		{
		}


		public override void OnAfterDelete()
		{
			base.OnAfterDelete();


			Unregister();
		}


		public override bool CheckVendorAccess( Mobile from )
		{
			return true;
		}


		public BaseFactionVendor( Town town, Faction faction, string title ) : base( title )
		{
			Frozen = true;
			CantWalk = true;
			Female = false;
			BodyValue = 400;
			Name = NameList.RandomName( "male" );


			RangeHome = 0;


			m_Town = town;
			m_Faction = faction;
			Register();
		}


		public BaseFactionVendor( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			Town.WriteReference( writer, m_Town );
			Faction.WriteReference( writer, m_Faction );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			switch ( version )
			{
				case 0:
				{
					m_Town = Town.ReadReference( reader );
					m_Faction = Faction.ReadReference( reader );
					Register();
					break;
				}
			}


			Frozen = true;
		}
	}
}
// using System;// using System.Collections.Generic;


namespace Server.Factions
{
	public abstract class BaseMonolith : BaseSystemController
	{
		private Town m_Town;
		private Faction m_Faction;
		private Sigil m_Sigil;


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Sigil Sigil
		{
			get{ return m_Sigil; }
			set
			{
				if ( m_Sigil == value )
					return;


				m_Sigil = value;


				if ( m_Sigil != null && m_Sigil.LastMonolith != null && m_Sigil.LastMonolith != this && m_Sigil.LastMonolith.Sigil == m_Sigil )
					m_Sigil.LastMonolith.Sigil = null;


				if ( m_Sigil != null )
					m_Sigil.LastMonolith = this;


				UpdateSigil();
			}
		}


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Town Town
		{
			get{ return m_Town; }
			set
			{
				m_Town = value;
				OnTownChanged();
			}
		}


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set
			{
				m_Faction = value;
				Hue = ( m_Faction == null ? 0 : m_Faction.Definition.HuePrimary );
			}
		}


		public override void OnLocationChange( Point3D oldLocation )
		{
			base.OnLocationChange( oldLocation );
			UpdateSigil();
		}


		public override void OnMapChange()
		{
			base.OnMapChange();
			UpdateSigil();
		}


		public virtual void UpdateSigil()
		{
			if ( m_Sigil == null || m_Sigil.Deleted )
				return;


			m_Sigil.MoveToWorld( new Point3D( X, Y, Z + 18 ), Map );
		}


		public virtual void OnTownChanged()
		{
		}


		public BaseMonolith( Town town, Faction faction ) : base( 0x1183 )
		{
			Movable = false;
			Town = town;
			Faction = faction;
			m_Monoliths.Add( this );
		}


		public BaseMonolith( Serial serial ) : base( serial )
		{
			m_Monoliths.Add( this );
		}


		public override void OnAfterDelete()
		{
			base.OnAfterDelete();
			m_Monoliths.Remove( this );
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			Town.WriteReference( writer, m_Town );
			Faction.WriteReference( writer, m_Faction );


			writer.Write( (Item) m_Sigil );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			switch ( version )
			{
				case 0:
				{
					Town = Town.ReadReference( reader );
					Faction = Faction.ReadReference( reader );
					m_Sigil = reader.ReadItem() as Sigil;
					break;
				}
			}
		}


		private static List<BaseMonolith> m_Monoliths = new List<BaseMonolith>();


		public static List<BaseMonolith> Monoliths
		{
			get{ return m_Monoliths; }
			set{ m_Monoliths = value; }
		}
	}
}
// using Server;// using System;// using Server.Misc;// using Server.Mobiles;

namespace Server.Factions
{
	public abstract class BaseSystemController : Item
	{
		private int m_LabelNumber;


		public virtual int DefaultLabelNumber{ get{ return base.LabelNumber; } }
		public new virtual string DefaultName{ get{ return null; } }


		public override int LabelNumber
		{
			get
			{
				if ( m_LabelNumber > 0 )
					return m_LabelNumber;


				return DefaultLabelNumber;
			}
		}


		public virtual void AssignName( TextDefinition name )
		{
			if ( name != null && name.Number > 0 )
			{
				m_LabelNumber = name.Number;
				Name = null;
			}
			else if ( name != null && name.String != null )
			{
				m_LabelNumber = 0;
				Name = name.String;
			}
			else
			{
				m_LabelNumber = 0;
				Name = DefaultName;
			}


			InvalidateProperties();
		}


		public BaseSystemController( int itemID ) : base( itemID )
		{
		}


		public BaseSystemController( Serial serial ) : base( serial )
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
// using System;// using Server;// using Server.Items;// using Server.Misc;


namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class BlackDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }


		[Constructable]
		public BlackDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a black dragon";
			Body = 12;
			Hue = 0x966;
			BaseSoundID = 362;


			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );


			SetHits( 478, 495 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );


			SetSkill( SkillName.EvalInt, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );


			Fame = 15000;
			Karma = -15000;


			VirtualArmor = 60;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();


				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Black", "", c, 25, 0 );
				}
			}
		}


		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Black ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public BlackDragon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Spells;


namespace Server.Ethics.Hero
{
	public sealed class Bless : Power
	{
		public Bless()
		{
			m_Definition = new PowerDefinition(
					15,
					"Bless",
					"Erstok Ontawl",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			from.Mobile.BeginTarget( 12, true, Targeting.TargetFlags.None, new TargetStateCallback( Power_OnTarget ), from );
			from.Mobile.SendMessage( "Where do you wish to bless?" );
		}


		private void Power_OnTarget( Mobile fromMobile, object obj, object state )
		{
			Player from = state as Player;


			IPoint3D p = obj as IPoint3D;


			if ( p == null )
				return;


			if ( !CheckInvoke( from ) )
				return;


			bool powerFunctioned = false;


			SpellHelper.GetSurfaceTop( ref p );


			foreach ( Mobile mob in from.Mobile.GetMobilesInRange( 6 ) )
			{
				if ( mob != from.Mobile && SpellHelper.ValidIndirectTarget( from.Mobile, mob ) )
					continue;


				if ( mob.GetStatMod( "Holy Bless" ) != null )
					continue;


				if ( !from.Mobile.CanBeBeneficial( mob, false ) )
					continue;


				from.Mobile.DoBeneficial( mob );


				mob.AddStatMod( new StatMod( StatType.All, "Holy Bless", 10, TimeSpan.FromMinutes( 30.0 ) ) );


				mob.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Waist );
				mob.PlaySound( 0x1EA );


				powerFunctioned = true;
			}


			if ( powerFunctioned )
			{
				SpellHelper.Turn( from.Mobile, p );


				Effects.PlaySound( p, from.Mobile.Map, 0x299 );


				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You consecrate the area." );


				FinishInvoke( from );
			}
			else
			{
				from.Mobile.FixedEffect( 0x3735, 6, 30 );
				from.Mobile.PlaySound( 0x5C );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;// using Server.Spells;


namespace Server.Ethics.Evil
{
	public sealed class Blight : Power
	{
		public Blight()
		{
			m_Definition = new PowerDefinition(
					15,
					"Blight",
					"Velgo Ontawl",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			from.Mobile.BeginTarget( 12, true, Targeting.TargetFlags.None, new TargetStateCallback( Power_OnTarget ), from );
			from.Mobile.SendMessage( "Where do you wish to blight?" );
		}


		private void Power_OnTarget( Mobile fromMobile, object obj, object state )
		{
			Player from = state as Player;


			IPoint3D p = obj as IPoint3D;


			if ( p == null )
				return;


			if ( !CheckInvoke( from ) )
				return;


			bool powerFunctioned = false;


			SpellHelper.GetSurfaceTop( ref p );


			foreach ( Mobile mob in from.Mobile.GetMobilesInRange( 6 ) )
			{
				if ( mob == from.Mobile || !SpellHelper.ValidIndirectTarget( from.Mobile, mob ) )
					continue;


				if ( mob.GetStatMod( "Holy Curse" ) != null )
					continue;


				if ( !from.Mobile.CanBeHarmful( mob, false ) )
					continue;


				from.Mobile.DoHarmful( mob, true );


				mob.AddStatMod( new StatMod( StatType.All, "Holy Curse", -10, TimeSpan.FromMinutes( 30.0 ) ) );


				mob.FixedParticles( 0x374A, 10, 15, 5028, EffectLayer.Waist );
				mob.PlaySound( 0x1FB );


				powerFunctioned = true;
			}


			if ( powerFunctioned )
			{
				SpellHelper.Turn( from.Mobile, p );


				Effects.PlaySound( p, from.Mobile.Map, 0x1FB );


				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You curse the area." );


				FinishInvoke( from );
			}
			else
			{
				from.Mobile.FixedEffect( 0x3735, 6, 30 );
				from.Mobile.PlaySound( 0x5C );
			}
		}
	}
}// using System;// using Server;// using Server.Items;// using Server.Misc;


namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class BlueDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 13 ); }


		[Constructable]
		public BlueDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a blue dragon";
			Body = 12;
			Hue = 0x1F4;
			BaseSoundID = 362;


			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );


			SetHits( 478, 495 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Energy, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Fire, 35, 45 );


			SetSkill( SkillName.EvalInt, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );


			Fame = 15000;
			Karma = -15000;


			VirtualArmor = 60;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();


				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Blue", "", c, 25, 0 );
				}
			}
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}


		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Blue ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public BlueDragon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;


namespace Server.Factions
{
	public class Britain : Town
	{
		public Britain()
		{
			Definition =
				new TownDefinition(
					0,
					0x1869,
					"Britain",
					"Britain",
					new TextDefinition( 1011433, "BRITAIN" ),
					new TextDefinition( 1011561, "TOWN STONE FOR BRITAIN" ),
					new TextDefinition( 1041034, "The Faction Sigil Monolith of Britain" ),
					new TextDefinition( 1041404, "The Faction Town Sigil Monolith of Britain" ),
					new TextDefinition( 1041413, "Faction Town Stone of Britain" ),
					new TextDefinition( 1041395, "Faction Town Sigil of Britain" ),
					new TextDefinition( 1041386, "Corrupted Faction Town Sigil of Britain" ),
					new Point3D( 1592, 1680, 10 ),
					new Point3D( 1588, 1676, 10 ) );
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a bullradon corpse" )]
	public class Bullradon : BaseCreature
	{
		[Constructable]
		public Bullradon() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a bullradon";
			Body = 0x11C;


			SetStr( 146, 175 );
			SetDex( 111, 150 );
			SetInt( 46, 60 );


			SetHits( 131, 160 );
			SetMana( 0 );


			SetDamage( 6, 11 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 50, 70 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Poison, 40, 60 );
			SetResistance( ResistanceType.Energy, 30, 50 );


			SetSkill( SkillName.MagicResist, 37.6, 42.5 );
			SetSkill( SkillName.Tactics, 70.6, 83.0 );
			SetSkill( SkillName.Wrestling, 50.1, 57.5 );


			Fame = 2000;
			Karma = -2000;


			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 68.7;
		}


		public override int GetAngerSound()
		{
			return 0x4F8;
		}


		public override int GetIdleSound()
		{
			return 0x4F7;
		}


		public override int GetAttackSound()
		{
			return 0x4F6;
		}


		public override int GetHurtSound()
		{
			return 0x4F9;
		}


		public override int GetDeathSound()
		{
			return 0x4F5;
		}


		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 15; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }


		public Bullradon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 0x11C;
		}
	}
}// using System;// using System.Xml;// using Server;// using Server.Regions;// using Server.Mobiles;



namespace Server.Mobiles
{
	[CorpseName( "a cave bear corpse" )]
	public class CaveBear : BaseCreature
	{
		[Constructable]
		public CaveBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a cave bear";
			Body = 190;
			BaseSoundID = 0xA3;


			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );


			SetHits( 176, 193 );
			SetMana( 0 );


			SetDamage( 14, 19 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );


			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.Wrestling, 65.1, 90.0 );


			Fame = 1500;
			Karma = 0;


			VirtualArmor = 35;


			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}


		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }


		public CaveBear( Serial serial ) : base( serial )
		{
		}


		public override void Serialize(GenericWriter writer)
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
// using System;// using System.Collections;// using Server;// using Server.Items;


namespace Server.Engines.MyRunUO
{
	public class Config
	{
		// Is MyRunUO enabled?
		public static bool Enabled = false;


		// Details required for database connection string
		public static string DatabaseDriver			= "{MySQL ODBC 3.51 Driver}";
		public static string DatabaseServer			= "localhost";
		public static string DatabaseName			= "MyRunUO";
		public static string DatabaseUserID			= "username";
		public static string DatabasePassword		= "password";


		// Should the database use transactions? This is recommended
		public static bool UseTransactions = true;


		// Use optimized table loading techniques? (LOAD DATA INFILE)
		public static bool LoadDataInFile = true;


		// This must be enabled if the database server is on a remote machine.
		public static bool DatabaseNonLocal = ( DatabaseServer != "localhost" );


		// Text encoding used
		public static Encoding EncodingIO = Encoding.ASCII;


		// Database communication is done in a separate thread. This value is the 'priority' of that thread, or, how much CPU it will try to use
		public static ThreadPriority DatabaseThreadPriority = ThreadPriority.BelowNormal;


		// Any character with an AccessLevel equal to or higher than this will not be displayed
		public static AccessLevel HiddenAccessLevel	= AccessLevel.Counselor;


		// Export character database every 30 minutes
		public static TimeSpan CharacterUpdateInterval = TimeSpan.FromMinutes( 30.0 );


		// Export online list database every 5 minutes
		public static TimeSpan StatusUpdateInterval = TimeSpan.FromMinutes( 5.0 );


		public static string CompileConnectionString()
		{
			string connectionString = String.Format( "DRIVER={0};SERVER={1};DATABASE={2};UID={3};PASSWORD={4};",
				DatabaseDriver, DatabaseServer, DatabaseName, DatabaseUserID, DatabasePassword );


			return connectionString;
		}
	}
}
// using System;// using Server;


namespace Server.Factions
{
	public class CouncilOfMages : Faction
	{
		private static Faction m_Instance;


		public static Faction Instance{ get{ return m_Instance; } }


		public CouncilOfMages()
		{
			m_Instance = this;


			Definition =
				new FactionDefinition(
					1,
					1325, // blue
					1310, // bluish white
					1325, // join stone : blue
					1325, // broadcast : blue
					0x77, 0x3EB1, // war horse
					"Council of Mages", "council", "CoM",
					new TextDefinition( 1011535, "COUNCIL OF MAGES" ),
					new TextDefinition( 1060770, "Council of Mages faction" ),
					new TextDefinition( 1011422, "<center>COUNCIL OF MAGES</center>" ),
					new TextDefinition( 1011449,
						"The council of Mages have their roots in the city of Moonglow, where " +
						"they once convened. They began as a small movement, dedicated to " +
						"calling forth the Stranger, who saved the lands once before.  A " +
						"series of war and murders and misbegotten trials by those loyal to " +
						"Lord British has caused the group to take up the banner of war." ),
					new TextDefinition( 1011455, "This city is controlled by the Council of Mages." ),
					new TextDefinition( 1042253, "This sigil has been corrupted by the Council of Mages" ),
					new TextDefinition( 1041044, "The faction signup stone for the Council of Mages" ),
					new TextDefinition( 1041382, "The Faction Stone of the Council of Mages" ),
					new TextDefinition( 1011464, ": Council of Mages" ),
					new TextDefinition( 1005187, "Members of the Council of Mages will now be ignored." ),
					new TextDefinition( 1005188, "Members of the Council of Mages will now be warned to leave." ),
					new TextDefinition( 1005189, "Members of the Council of Mages will now be beaten with a stick." ),
					new StrongholdDefinition(
						new Rectangle2D[]
						{
							new Rectangle2D( 5192, 3934, 1, 1 ) // WIZARD
						},
						new Point3D( 3750, 2241, 20 ),
						new Point3D( 3795, 2259, 20 ),
						new Point3D[]
						{
							new Point3D( 3793, 2255, 20 ),
							new Point3D( 3793, 2252, 20 ),
							new Point3D( 3793, 2249, 20 ),
							new Point3D( 3793, 2246, 20 ),
							new Point3D( 3797, 2255, 20 ),
							new Point3D( 3797, 2252, 20 ),
							new Point3D( 3797, 2249, 20 ),
							new Point3D( 3797, 2246, 20 )
						} ),
					new RankDefinition[]
					{
						new RankDefinition( 10, 991, 8, new TextDefinition( 1060789, "Inquisitor of the Council" ) ),
						new RankDefinition(  9, 950, 7, new TextDefinition( 1060788, "Archon of Principle" ) ),
						new RankDefinition(  8, 900, 6, new TextDefinition( 1060787, "Luminary" ) ),
						new RankDefinition(  7, 800, 6, new TextDefinition( 1060787, "Luminary" ) ),
						new RankDefinition(  6, 700, 5, new TextDefinition( 1060786, "Diviner" ) ),
						new RankDefinition(  5, 600, 5, new TextDefinition( 1060786, "Diviner" ) ),
						new RankDefinition(  4, 500, 5, new TextDefinition( 1060786, "Diviner" ) ),
						new RankDefinition(  3, 400, 4, new TextDefinition( 1060785, "Mystic" ) ),
						new RankDefinition(  2, 200, 4, new TextDefinition( 1060785, "Mystic" ) ),
						new RankDefinition(  1,   0, 4, new TextDefinition( 1060785, "Mystic" ) )
					},
					new GuardDefinition[]
					{
						new GuardDefinition( typeof( FactionHenchman ),		0x1403, 5000, 1000, 10,		new TextDefinition( 1011526, "HENCHMAN" ),		new TextDefinition( 1011510, "Hire Henchman" ) ),
						new GuardDefinition( typeof( FactionMercenary ),	0x0F62, 6000, 2000, 10,		new TextDefinition( 1011527, "MERCENARY" ),		new TextDefinition( 1011511, "Hire Mercenary" ) ),
						new GuardDefinition( typeof( FactionSorceress ),	0x0E89, 7000, 3000, 10,		new TextDefinition( 1011507, "SORCERESS" ),		new TextDefinition( 1011501, "Hire Sorceress" ) ),
						new GuardDefinition( typeof( FactionWizard ),		0x13F8, 8000, 4000, 10,		new TextDefinition( 1011508, "ELDER WIZARD" ),	new TextDefinition( 1011502, "Hire Elder Wizard" ) ),
					}
				);
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;


namespace Server.Mobiles
{
	[CorpseName( "a dark unicorn corpse" )]
	public class DarkUnicorn : BaseCreature
	{
		[Constructable]
		public DarkUnicorn() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dark unicorn";
			Body = 27;
			BaseSoundID = 0xA8;


			SetStr( 596, 625 );
			SetDex( 186, 205 );
			SetInt( 186, 225 );


			SetHits( 398, 415 );


			SetDamage( 22, 28 );


			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );


			SetSkill( SkillName.EvalInt, 30.4, 70.0 );
			SetSkill( SkillName.Magery, 30.4, 70.0 );
			SetSkill( SkillName.MagicResist, 105.3, 120.0 );
			SetSkill( SkillName.Tactics, 117.6, 120.0 );
			SetSkill( SkillName.Wrestling, 100.5, 112.5 );


			Fame = 19000;
			Karma = -19000;


			VirtualArmor = 70;


			AddItem( new LightSource() );
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Potions );
		}


		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;


			return base.GetAngerSound();
		}


		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 5 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }


		public DarkUnicorn( Serial serial ) : base( serial )
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


			if ( BaseSoundID == 0x16A )
				BaseSoundID = 0xA8;
		}
	}
}
// using System;// using System.Threading;// using System.Collections;// using System.Data;// using System.Data.Odbc;


namespace Server.Engines.MyRunUO
{
	public class DatabaseCommandQueue
	{
		private Queue m_Queue;
		private ManualResetEvent m_Sync;
		private Thread m_Thread;


		private bool m_HasCompleted;


		private string m_CompletionString;
		private string m_ConnectionString;


		public bool HasCompleted
		{
			get{ return m_HasCompleted; }
		}


		public void Enqueue( object obj )
		{
			lock ( m_Queue.SyncRoot )
			{
				m_Queue.Enqueue( obj );
				try{ m_Sync.Set(); }
				catch{}
			}
		}


		public DatabaseCommandQueue( string completionString, string threadName ) : this( Config.CompileConnectionString(), completionString, threadName )
		{
		}


		public DatabaseCommandQueue( string connectionString, string completionString, string threadName )
		{
			m_CompletionString = completionString;
			m_ConnectionString = connectionString;


			m_Queue = Queue.Synchronized( new Queue() );


			m_Queue.Enqueue( null ); // signal connect


			/*m_Queue.Enqueue( "DELETE FROM myrunuo_characters" );
			m_Queue.Enqueue( "DELETE FROM myrunuo_characters_layers" );
			m_Queue.Enqueue( "DELETE FROM myrunuo_characters_skills" );
			m_Queue.Enqueue( "DELETE FROM myrunuo_guilds" );
			m_Queue.Enqueue( "DELETE FROM myrunuo_guilds_wars" );*/


			m_Sync = new ManualResetEvent( true );


			m_Thread = new Thread( new ThreadStart( Thread_Start ) );
			m_Thread.Name = threadName;//"MyRunUO Database Command Queue";
			m_Thread.Priority = Config.DatabaseThreadPriority;
			m_Thread.Start();
		}


		private void Thread_Start()
		{
			bool connected = false;


			OdbcConnection connection = null;
			OdbcCommand command = null;
			OdbcTransaction transact = null;


			DateTime start = DateTime.Now;


			bool shouldWriteException = true;


			while ( true )
			{
				m_Sync.WaitOne();


				while ( m_Queue.Count > 0 )
				{
					try
					{
						object obj = m_Queue.Dequeue();


						if ( obj == null )
						{
							if ( connected )
							{
								if ( transact != null )
								{
									try{ transact.Commit(); }
									catch ( Exception commitException )
									{
										Console.WriteLine( "MyRunUO: Exception caught when committing transaction" );
										Console.WriteLine( commitException );


										try
										{
											transact.Rollback();
											Console.WriteLine( "MyRunUO: Transaction has been rolled back" );
										}
										catch ( Exception rollbackException )
										{
											Console.WriteLine( "MyRunUO: Exception caught when rolling back transaction" );
											Console.WriteLine( rollbackException );
										}
									}
								}


								try{ connection.Close(); }
								catch{}


								try{ connection.Dispose(); }
								catch{}


								try{ command.Dispose(); }
								catch{}


								try{ m_Sync.Close(); }
								catch{}


								Console.WriteLine( m_CompletionString, (DateTime.Now - start).TotalSeconds );
								m_HasCompleted = true;


								return;
							}
							else
							{
								try
								{
									connected = true;
									connection = new OdbcConnection( m_ConnectionString );
									connection.Open();
									command = connection.CreateCommand();


									if ( Config.UseTransactions )
									{
										transact = connection.BeginTransaction();
										command.Transaction = transact;
									}
								}
								catch ( Exception e )
								{
									try{ if ( transact != null ) transact.Rollback(); }
									catch{}


									try{ if ( connection != null ) connection.Close(); }
									catch{}


									try{ if ( connection != null ) connection.Dispose(); }
									catch{}


									try{ if ( command != null ) command.Dispose(); }
									catch{}


									try{ m_Sync.Close(); }
									catch{}


									Console.WriteLine( "MyRunUO: Unable to connect to the database" );
									Console.WriteLine( e );
									m_HasCompleted = true;
									return;
								}
							}
						}
						else if ( obj is string )
						{
							command.CommandText = (string)obj;
							command.ExecuteNonQuery();
						}
						else
						{
							string[] parms = (string[])obj;


							command.CommandText = parms[0];


							if ( command.ExecuteScalar() == null )
							{
								command.CommandText = parms[1];
								command.ExecuteNonQuery();
							}
						}
					}
					catch ( Exception e )
					{
						if ( shouldWriteException )
						{
							Console.WriteLine( "MyRunUO: Exception caught in database thread" );
							Console.WriteLine( e );
							shouldWriteException = false;
						}
					}
				}


				lock ( m_Queue.SyncRoot )
				{
					if ( m_Queue.Count == 0 )
						m_Sync.Reset();
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class DeepSeaDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }


		[Constructable]
		public DeepSeaDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the sea wyrm";
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = 1365;
			BaseSoundID = 362;
			CanSwim = true;


			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );


			SetHits( 478, 495 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );


			SetSkill( SkillName.EvalInt, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );


			Fame = 15000;
			Karma = -15000;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;


			VirtualArmor = 60;


			if ( 1 == Utility.RandomMinMax( 0, 2 ) )
			{
				switch ( Utility.RandomMinMax( 0, 5 ) )
				{
					case 0: PackItem( new SeaweedLegs() ); break;
					case 1: PackItem( new SeaweedGloves() ); break;
					case 2: PackItem( new SeaweedGorget() ); break;
					case 3: PackItem( new SeaweedArms() ); break;
					case 4: PackItem( new SeaweedChest() ); break;
					case 5: PackItem( new SeaweedHelm() ); break;
				}
			}
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H


		public override bool BleedImmune{ get{ return true; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override MeatType MeatType{ get{ return MeatType.Fish; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Spined; } else { return HideType.Draconic; } } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Blue ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override bool CanAngerOnTame { get { return true; } }


		public DeepSeaDragon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class DesertWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 50; } }
		public override int BreathFireDamage{ get{ return 50; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x96D; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } }
		public override int BreathEffectSound{ get{ return 0x654; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 8 ); }


		[Constructable]
		public DesertWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the desert wyrm";
			BaseSoundID = 362;
			Hue = 1719;
			Body = Server.Misc.MyServerSettings.WyrmBody();


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Yellow; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public DesertWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;


namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class Dragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }


		[Constructable]
		public Dragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a red dragon";
			Body = 59;
			BaseSoundID = 362;


			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );


			SetHits( 478, 495 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );


			SetSkill( SkillName.EvalInt, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );


			Fame = 15000;
			Karma = -15000;


			VirtualArmor = 60;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();


				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Red", "", c, 25, 0x845 );
				}
			}
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}


		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public Dragon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Mobiles;


namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class ElderBlackBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}


		[Constructable]
		public ElderBlackBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder black bear";
			Body = 177;
			BaseSoundID = 0xA3;


			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );


			SetHits( 176, 193 );
			SetMana( 0 );


			SetDamage( 14, 19 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );


			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.Wrestling, 65.1, 90.0 );


			Fame = 1500;
			Karma = 0;


			VirtualArmor = 35;


			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}


		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }


		public ElderBlackBear( Serial serial ) : base( serial )
		{
		}


		public override void Serialize(GenericWriter writer)
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
// using System;// using Server.Mobiles;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class ElderBrownBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}


		[Constructable]
		public ElderBrownBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder brown bear";
			Body = 34;
			BaseSoundID = 0xA3;


			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );


			SetHits( 176, 193 );
			SetMana( 0 );


			SetDamage( 14, 19 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );


			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.Wrestling, 65.1, 90.0 );


			Fame = 1500;
			Karma = 0;


			VirtualArmor = 35;


			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}


		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }


		public ElderBrownBear( Serial serial ) : base( serial )
		{
		}


		public override void Serialize(GenericWriter writer)
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
// using System;// using Server.Mobiles;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class ElderPolarBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}


		[Constructable]
		public ElderPolarBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder polar bear";
			Body = 179;
			BaseSoundID = 0xA3;


			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );


			SetHits( 176, 193 );
			SetMana( 0 );


			SetDamage( 14, 19 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );


			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.Wrestling, 65.1, 90.0 );


			Fame = 1500;
			Karma = 0;


			VirtualArmor = 35;


			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}


		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.White; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }


		public ElderPolarBear( Serial serial ) : base( serial )
		{
		}


		public override void Serialize(GenericWriter writer)
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
// using System;// using System.Net;// using System.Collections;// using Server;// using Server.Mobiles;// using System.Collections.Generic;


namespace Server.Factions
{
	public class Election
	{
		public static readonly TimeSpan PendingPeriod = TimeSpan.FromDays( 5.0 );
		public static readonly TimeSpan CampaignPeriod = TimeSpan.FromDays( 1.0 );
		public static readonly TimeSpan VotingPeriod = TimeSpan.FromDays( 3.0 );


		public const int MaxCandidates = 10;
		public const int CandidateRank = 5;


		private Faction m_Faction;
		private List<Candidate> m_Candidates;


		private ElectionState m_State;
		private DateTime m_LastStateTime;


		public Faction Faction{ get{ return m_Faction; } }


		public List<Candidate> Candidates { get { return m_Candidates; } }


		public ElectionState State{ get{ return m_State; } set{ m_State = value; m_LastStateTime = DateTime.Now; } }
		public DateTime LastStateTime{ get{ return m_LastStateTime; } }


		[CommandProperty( AccessLevel.GameMaster )]
		public ElectionState CurrentState{ get{ return m_State; } }


		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public TimeSpan NextStateTime
		{
			get
			{
				TimeSpan period;


				switch ( m_State )
				{
					default:
					case ElectionState.Pending: period = PendingPeriod; break;
					case ElectionState.Election: period = VotingPeriod; break;
					case ElectionState.Campaign: period = CampaignPeriod; break;
				}


				TimeSpan until = (m_LastStateTime + period) - DateTime.Now;


				if ( until < TimeSpan.Zero )
					until = TimeSpan.Zero;


				return until;
			}
			set
			{
				TimeSpan period;


				switch ( m_State )
				{
					default:
					case ElectionState.Pending: period = PendingPeriod; break;
					case ElectionState.Election: period = VotingPeriod; break;
					case ElectionState.Campaign: period = CampaignPeriod; break;
				}


				m_LastStateTime = DateTime.Now - period + value;
			}
		}


		private Timer m_Timer;


		public void StartTimer()
		{
			m_Timer = Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), TimeSpan.FromMinutes( 1.0 ), new TimerCallback( Slice ) );
		}


		public Election( Faction faction )
		{
			m_Faction = faction;
			m_Candidates = new List<Candidate>();


			StartTimer();
		}


		public Election( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 0:
				{
					m_Faction = Faction.ReadReference( reader );


					m_LastStateTime = reader.ReadDateTime();
					m_State = (ElectionState)reader.ReadEncodedInt();


					m_Candidates = new List<Candidate>();


					int count = reader.ReadEncodedInt();


					for ( int i = 0; i < count; ++i )
					{
						Candidate cd = new Candidate( reader );


						if ( cd.Mobile != null )
							m_Candidates.Add( cd );
					}


					break;
				}
			}


			StartTimer();
		}


		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 ); // version


			Faction.WriteReference( writer, m_Faction );


			writer.Write( (DateTime) m_LastStateTime );
			writer.WriteEncodedInt( (int) m_State );


			writer.WriteEncodedInt( m_Candidates.Count );


			for ( int i = 0; i < m_Candidates.Count; ++i )
				m_Candidates[i].Serialize( writer );
		}


		public void AddCandidate( Mobile mob )
		{
			if ( IsCandidate( mob ) )
				return;


			m_Candidates.Add( new Candidate( mob ) );
			mob.SendLocalizedMessage( 1010117 ); // You are now running for office.
		}


		public void RemoveVoter( Mobile mob )
		{
			if ( m_State == ElectionState.Election )
			{
				for ( int i = 0; i < m_Candidates.Count; ++i )
				{
					List<Voter> voters = m_Candidates[i].Voters;


					for ( int j = 0; j < voters.Count; ++j )
					{
						Voter voter = voters[j];


						if ( voter.From == mob )
							voters.RemoveAt( j-- );
					}
				}
			}
		}


		public void RemoveCandidate( Mobile mob )
		{
			Candidate cd = FindCandidate( mob );


			if ( cd == null )
				return;


			m_Candidates.Remove( cd );
			mob.SendLocalizedMessage( 1038031 );


			if ( m_State == ElectionState.Election )
			{
				if ( m_Candidates.Count == 1 )
				{
					m_Faction.Broadcast( 1038031 ); // There are no longer any valid candidates in the Faction Commander election.


					Candidate winner = m_Candidates[0];


					Mobile winMob = winner.Mobile;
					PlayerState pl = PlayerState.Find( winMob );


					if ( pl == null || pl.Faction != m_Faction || winMob == m_Faction.Commander )
					{
						m_Faction.Broadcast( 1038026 ); // Faction leadership has not changed.
					}
					else
					{
						m_Faction.Broadcast( 1038028 ); // The faction has a new commander.
						m_Faction.Commander = winMob;
					}


					m_Candidates.Clear();
					State = ElectionState.Pending;
				}
				else if ( m_Candidates.Count == 0 ) // well, I guess this'll never happen
				{
					m_Faction.Broadcast( 1038031 ); // There are no longer any valid candidates in the Faction Commander election.


					m_Candidates.Clear();
					State = ElectionState.Pending;
				}
			}
		}


		public bool IsCandidate( Mobile mob )
		{
			return ( FindCandidate( mob ) != null );
		}


		public bool CanVote( Mobile mob )
		{
			return ( m_State == ElectionState.Election && !HasVoted( mob ) );
		}


		public bool HasVoted( Mobile mob )
		{
			return ( FindVoter( mob ) != null );
		}


		public Candidate FindCandidate( Mobile mob )
		{
			for ( int i = 0; i < m_Candidates.Count; ++i )
			{
				if ( m_Candidates[i].Mobile == mob )
					return m_Candidates[i];
			}


			return null;
		}


		public Candidate FindVoter( Mobile mob )
		{
			for ( int i = 0; i < m_Candidates.Count; ++i )
			{
				List<Voter> voters = m_Candidates[i].Voters;


				for ( int j = 0; j < voters.Count; ++j )
				{
					Voter voter = voters[j];


					if ( voter.From == mob )
						return m_Candidates[i];
				}
			}


			return null;
		}


		public bool CanBeCandidate( Mobile mob )
		{
			if ( IsCandidate( mob ) )
				return false;


			if ( m_Candidates.Count >= MaxCandidates )
				return false;


			if ( m_State != ElectionState.Campaign )
				return false; // sanity..


			PlayerState pl = PlayerState.Find( mob );


			return ( pl != null && pl.Faction == m_Faction && pl.Rank.Rank >= CandidateRank );
		}


		public void Slice()
		{
			if ( m_Faction.Election != this )
			{
				if ( m_Timer != null )
					m_Timer.Stop();


				m_Timer = null;


				return;
			}


			switch ( m_State )
			{
				case ElectionState.Pending:
				{
					if ( (m_LastStateTime + PendingPeriod) > DateTime.Now )
						break;


					m_Faction.Broadcast( 1038023 ); // Campaigning for the Faction Commander election has begun.


					m_Candidates.Clear();
					State = ElectionState.Campaign;


					break;
				}
				case ElectionState.Campaign:
				{
					if ( (m_LastStateTime + CampaignPeriod) > DateTime.Now )
						break;


					if ( m_Candidates.Count == 0 )
					{
						m_Faction.Broadcast( 1038025 ); // Nobody ran for office.
						State = ElectionState.Pending;
					}
					else if ( m_Candidates.Count == 1 )
					{
						m_Faction.Broadcast( 1038029 ); // Only one member ran for office.


						Candidate winner = m_Candidates[0];


						Mobile mob = winner.Mobile;
						PlayerState pl = PlayerState.Find( mob );


						if ( pl == null || pl.Faction != m_Faction || mob == m_Faction.Commander )
						{
							m_Faction.Broadcast( 1038026 ); // Faction leadership has not changed.
						}
						else
						{
							m_Faction.Broadcast( 1038028 ); // The faction has a new commander.
							m_Faction.Commander = mob;
						}


						m_Candidates.Clear();
						State = ElectionState.Pending;
					}
					else
					{
						m_Faction.Broadcast( 1038030 );
						State = ElectionState.Election;
					}


					break;
				}
				case ElectionState.Election:
				{
					if ( (m_LastStateTime + VotingPeriod) > DateTime.Now )
						break;


					m_Faction.Broadcast( 1038024 ); // The results for the Faction Commander election are in


					Candidate winner = null;


					for ( int i = 0; i < m_Candidates.Count; ++i )
					{
						Candidate cd = m_Candidates[i];


						PlayerState pl = PlayerState.Find( cd.Mobile );


						if ( pl == null || pl.Faction != m_Faction )
							continue;


						//cd.CleanMuleVotes();


						if ( winner == null || cd.Votes > winner.Votes )
							winner = cd;
					}


					if ( winner == null )
					{
						m_Faction.Broadcast( 1038026 ); // Faction leadership has not changed.
					}
					else if ( winner.Mobile == m_Faction.Commander )
					{
						m_Faction.Broadcast( 1038027 ); // The incumbent won the election.
					}
					else
					{
						m_Faction.Broadcast( 1038028 ); // The faction has a new commander.
						m_Faction.Commander = winner.Mobile;
					}


					m_Candidates.Clear();
					State = ElectionState.Pending;


					break;
				}
			}
		}
	}


	public class Voter
	{
		private Mobile m_From;
		private Mobile m_Candidate;


		private IPAddress m_Address;
		private DateTime m_Time;


		public Mobile From
		{
			get{ return m_From; }
		}


		public Mobile Candidate
		{
			get{ return m_Candidate; }
		}


		public IPAddress Address
		{
			get{ return m_Address; }
		}


		public DateTime Time
		{
			get{ return m_Time; }
		}


		public object[] AcquireFields()
		{
			TimeSpan gameTime = TimeSpan.Zero;


			if ( m_From is PlayerMobile )
				gameTime = ((PlayerMobile)m_From).GameTime;


			int kp = 0;


			PlayerState pl = PlayerState.Find( m_From );


			if ( pl != null )
				kp = pl.KillPoints;


			int sk = m_From.Skills.Total;


			int factorSkills = 50 + ( (sk * 100 ) / 10000 );
			int factorKillPts = 100 + (kp*2);
			int factorGameTime = 50 + (int) ( (gameTime.Ticks * 100) / TimeSpan.TicksPerDay );


			int totalFactor = ( factorSkills * factorKillPts * Math.Max( factorGameTime, 100 ) ) / 10000;


			if ( totalFactor > 100 )
				totalFactor = 100;
			else if ( totalFactor < 0 )
				totalFactor = 0;


			return new object[]{ m_From, m_Address, m_Time, totalFactor };
		}


		public Voter( Mobile from, Mobile candidate )
		{
			m_From = from;
			m_Candidate = candidate;


			if ( m_From.NetState != null )
				m_Address = m_From.NetState.Address;
			else
				m_Address = IPAddress.None;


			m_Time = DateTime.Now;
		}


		public Voter( GenericReader reader, Mobile candidate )
		{
			m_Candidate = candidate;


			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 0:
				{
					m_From = reader.ReadMobile();
					m_Address = Utility.Intern( reader.ReadIPAddress() );
					m_Time = reader.ReadDateTime();


					break;
				}
			}
		}


		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 );


			writer.Write( (Mobile) m_From );
			writer.Write( (IPAddress) m_Address );
			writer.Write( (DateTime) m_Time );
		}
	}


	public class Candidate
	{
		private Mobile m_Mobile;
		private List<Voter> m_Voters;


		public Mobile Mobile{ get{ return m_Mobile; } }
		public List<Voter> Voters { get { return m_Voters; } }


		public int Votes{ get{ return m_Voters.Count; } }


		public void CleanMuleVotes()
		{
			for ( int i = 0; i < m_Voters.Count; ++i )
			{
				Voter voter = (Voter)m_Voters[i];


				if ( (int)voter.AcquireFields()[3] < 90 )
					m_Voters.RemoveAt( i-- );
			}
		}


		public Candidate( Mobile mob )
		{
			m_Mobile = mob;
			m_Voters = new List<Voter>();
		}


		public Candidate( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 1:
				{
					m_Mobile = reader.ReadMobile();


					int count = reader.ReadEncodedInt();
					m_Voters = new List<Voter>( count );


					for ( int i = 0; i < count; ++i )
					{
						Voter voter = new Voter( reader, m_Mobile );


						if ( voter.From != null )
							m_Voters.Add( voter );
					}


					break;
				}
				case 0:
				{
					m_Mobile = reader.ReadMobile();


					List<Mobile> mobs = reader.ReadStrongMobileList();
					m_Voters = new List<Voter>( mobs.Count );


					for ( int i = 0; i < mobs.Count; ++i )
						m_Voters.Add( new Voter( mobs[i], m_Mobile ) );


					break;
				}
			}
		}


		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 1 ); // version


			writer.Write( (Mobile) m_Mobile );


			writer.WriteEncodedInt( (int) m_Voters.Count );


			for ( int i = 0; i < m_Voters.Count; ++i )
				((Voter)m_Voters[i]).Serialize( writer );
		}
	}


	public enum ElectionState
	{
		Pending,
		Campaign,
		Election
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;


namespace Server.Factions
{
	public class ElectionGump : FactionGump
	{
		private PlayerMobile m_From;
		private Election m_Election;


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			switch ( info.ButtonID )
			{
				case 0: // back
				{
					m_From.SendGump( new FactionStoneGump( m_From, m_Election.Faction ) );
					break;
				}
				case 1: // vote
				{
					if ( m_Election.State == ElectionState.Election )
						m_From.SendGump( new VoteGump( m_From, m_Election ) );


					break;
				}
				case 2: // campaign
				{
					if ( m_Election.CanBeCandidate( m_From ) )
						m_Election.AddCandidate( m_From );


					break;
				}
			}
		}


		public ElectionGump( PlayerMobile from, Election election ) : base( 50, 50 )
		{
			m_From = from;
			m_Election = election;


			AddPage( 0 );


			AddBackground( 0, 0, 420, 180, 5054 );
			AddBackground( 10, 10, 400, 160, 3000 );


			AddHtmlText( 20, 20, 380, 20, election.Faction.Definition.Header, false, false );


			// NOTE: Gump not entirely OSI-accurate, intentionally so


			switch ( election.State )
			{
				case ElectionState.Pending:
				{
					TimeSpan toGo = ( election.LastStateTime + Election.PendingPeriod ) - DateTime.Now;
					int days = (int) (toGo.TotalDays + 0.5);


					AddHtmlLocalized( 20, 40, 380, 20, 1038034, false, false ); // A new election campaign is pending


					if ( days > 0 )
					{
						AddHtmlLocalized( 20, 60, 280, 20, 1018062, false, false ); // Days until next election :
						AddLabel( 300, 60, 0, days.ToString() );
					}
					else
					{
						AddHtmlLocalized( 20, 60, 280, 20, 1018059, false, false ); // Election campaigning begins tonight.
					}


					break;
				}
				case ElectionState.Campaign:
				{
					TimeSpan toGo = ( election.LastStateTime + Election.CampaignPeriod ) - DateTime.Now;
					int days = (int) (toGo.TotalDays + 0.5);


					AddHtmlLocalized( 20, 40, 380, 20, 1018058, false, false ); // There is an election campaign in progress.


					if ( days > 0 )
					{
						AddHtmlLocalized( 20, 60, 280, 20, 1038033, false, false ); // Days to go:
						AddLabel( 300, 60, 0, days.ToString() );
					}
					else
					{
						AddHtmlLocalized( 20, 60, 280, 20, 1018061, false, false ); // Campaign in progress. Voting begins tonight.
					}


					if ( m_Election.CanBeCandidate( m_From ) )
					{
						AddButton( 20, 110, 4005, 4007, 2, GumpButtonType.Reply, 0 );
						AddHtmlLocalized( 55, 110, 350, 20, 1011427, false, false ); // CAMPAIGN FOR LEADERSHIP
					}
					else
					{
						PlayerState pl = PlayerState.Find( m_From );


						if ( pl == null || pl.Rank.Rank < Election.CandidateRank )
							AddHtmlLocalized( 20, 100, 380, 20, 1010118, false, false ); // You must have a higher rank to run for office
					}


					break;
				}
				case ElectionState.Election:
				{
					TimeSpan toGo = ( election.LastStateTime + Election.VotingPeriod ) - DateTime.Now;
					int days = (int) Math.Ceiling( toGo.TotalDays );


					AddHtmlLocalized( 20, 40, 380, 20, 1018060, false, false ); // There is an election vote in progress.


					AddHtmlLocalized( 20, 60, 280, 20, 1038033, false, false );
					AddLabel( 300, 60, 0, days.ToString() );


					AddHtmlLocalized( 55, 100, 380, 20, 1011428, false, false ); // VOTE FOR LEADERSHIP
					AddButton( 20, 100, 4005, 4007, 1, GumpButtonType.Reply, 0 );


					break;
				}
			}


			AddButton( 20, 140, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 55, 140, 350, 20, 1011012, false, false ); // CANCEL
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;


namespace Server.Factions
{
	public class ElectionManagementGump : Gump
	{
		public string Right( string text )
		{
			return String.Format( "<DIV ALIGN=RIGHT>{0}</DIV>", text );
		}


		public string Center( string text )
		{
			return String.Format( "<CENTER>{0}</CENTER>", text );
		}


		public string Color( string text, int color )
		{
			return String.Format( "<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text );
		}


		public static string FormatTimeSpan( TimeSpan ts )
		{
			return String.Format( "{0:D2}:{1:D2}:{2:D2}:{3:D2}", ts.Days, ts.Hours % 24, ts.Minutes % 60, ts.Seconds % 60 );
		}


		public const int LabelColor = 0xFFFFFF;


		private Election m_Election;
		private Candidate m_Candidate;
		private int m_Page;


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;
			int bid = info.ButtonID;


			if ( m_Candidate == null )
			{
				if ( bid == 0 )
				{
				}
				else if ( bid == 1 )
				{
				}
				else
				{
					bid -= 2;


					if ( bid >= 0 && bid < m_Election.Candidates.Count )
						from.SendGump( new ElectionManagementGump( m_Election, m_Election.Candidates[bid], 0 ) );
				}
			}
			else
			{
				if ( bid == 0 )
				{
					from.SendGump( new ElectionManagementGump( m_Election ) );
				}
				else if ( bid == 1 )
				{
					m_Election.RemoveCandidate( m_Candidate.Mobile );
					from.SendGump( new ElectionManagementGump( m_Election ) );
				}
				else if ( bid == 2 && m_Page > 0 )
				{
					from.SendGump( new ElectionManagementGump( m_Election, m_Candidate, m_Page - 1 ) );
				}
				else if ( bid == 3 && (m_Page + 1) * 10 < m_Candidate.Voters.Count )
				{
					from.SendGump( new ElectionManagementGump( m_Election, m_Candidate, m_Page + 1 ) );
				}
				else
				{
					bid -= 4;


					if ( bid >= 0 && bid < m_Candidate.Voters.Count )
					{
						m_Candidate.Voters.RemoveAt( bid );
						from.SendGump( new ElectionManagementGump( m_Election, m_Candidate, m_Page ) );
					}
				}
			}
		}


		public ElectionManagementGump( Election election ) : this( election, null, 0 )
		{
		}


		public ElectionManagementGump( Election election, Candidate candidate, int page ) : base( 40, 40 )
		{
			m_Election = election;
			m_Candidate = candidate;
			m_Page = page;


			AddPage( 0 );


			if ( candidate != null )
			{
				AddBackground( 0, 0, 448, 354, 9270 );
				AddAlphaRegion( 10, 10, 428, 334 );


				AddHtml( 10, 10, 428, 20, Color( Center( "Candidate Management" ), LabelColor ), false, false );


				AddHtml(  45, 35, 100, 20, Color( "Player Name:", LabelColor ), false, false );
				AddHtml( 145, 35, 100, 20, Color( candidate.Mobile == null ? "null" : candidate.Mobile.Name, LabelColor ), false, false );


				AddHtml(  45, 55, 100, 20, Color( "Vote Count:", LabelColor ), false, false );
				AddHtml( 145, 55, 100, 20, Color( candidate.Votes.ToString(), LabelColor ), false, false );


				AddButton( 12, 73, 4005, 4007, 1, GumpButtonType.Reply, 0 );
				AddHtml(  45, 75, 100, 20, Color( "Drop Candidate", LabelColor ), false, false );


				AddImageTiled( 13, 99, 422, 242, 9264 );
				AddImageTiled( 14, 100, 420, 240, 9274 );
				AddAlphaRegion( 14, 100, 420, 240 );


				AddHtml( 14, 100, 420, 20, Color( Center( "Voters" ), LabelColor ), false, false );


				if ( page > 0 )
					AddButton( 397, 104, 0x15E3, 0x15E7, 2, GumpButtonType.Reply, 0 );
				else
					AddImage( 397, 104, 0x25EA );


				if ( (page + 1) * 10 < candidate.Voters.Count )
					AddButton( 414, 104, 0x15E1, 0x15E5, 3, GumpButtonType.Reply, 0 );
				else
					AddImage( 414, 104, 0x25E6 );


				AddHtml( 14, 120, 30, 20, Color( Center( "DEL" ), LabelColor ), false, false );
				AddHtml( 47, 120, 150, 20, Color( "Name", LabelColor ), false, false );
				AddHtml( 195, 120, 100, 20, Color( Center( "Address" ), LabelColor ), false, false );
				AddHtml( 295, 120, 80, 20, Color( Center( "Time" ), LabelColor ), false, false );
				AddHtml( 355, 120, 60, 20, Color( Center( "Legit" ), LabelColor ), false, false );


				int idx = 0;


				for ( int i = page*10; i >= 0 && i < candidate.Voters.Count && i < (page+1)*10; ++i, ++idx )
				{
					Voter voter = (Voter)candidate.Voters[i];


					AddButton( 13, 138 + (idx * 20), 4002, 4004, 4 + i, GumpButtonType.Reply, 0 );


					object[] fields = voter.AcquireFields();


					int x = 45;


					for ( int j = 0; j < fields.Length; ++j )
					{
						object obj = fields[j];


						if ( obj is Mobile )
						{
							AddHtml( x + 2, 140 + (idx * 20), 150, 20, Color( ((Mobile)obj).Name, LabelColor ), false, false );
							x += 150;
						}
						else if ( obj is System.Net.IPAddress )
						{
							AddHtml( x, 140 + (idx * 20), 100, 20, Color( Center( obj.ToString() ), LabelColor ), false, false );
							x += 100;
						}
						else if ( obj is DateTime )
						{
							AddHtml( x, 140 + (idx * 20), 80, 20, Color( Center( FormatTimeSpan( ((DateTime)obj) - election.LastStateTime ) ), LabelColor ), false, false );
							x += 80;
						}
						else if ( obj is int )
						{
							AddHtml( x, 140 + (idx * 20), 60, 20, Color( Center( (int)obj + "%" ), LabelColor ), false, false );
							x += 60;
						}
					}
				}
			}
			else
			{
				AddBackground( 0, 0, 288, 334, 9270 );
				AddAlphaRegion( 10, 10, 268, 314 );


				AddHtml( 10, 10, 268, 20, Color( Center( "Election Management" ), LabelColor ), false, false );


				AddHtml(  45, 35, 100, 20, Color( "Current State:", LabelColor ), false, false );
				AddHtml( 145, 35, 100, 20, Color( election.State.ToString(), LabelColor ), false, false );


				AddButton( 12, 53, 4005, 4007, 1, GumpButtonType.Reply, 0 );
				AddHtml(  45, 55, 100, 20, Color( "Transition Time:", LabelColor ), false, false );
				AddHtml( 145, 55, 100, 20, Color( FormatTimeSpan( election.NextStateTime ), LabelColor ), false, false );


				AddImageTiled( 13, 79, 262, 242, 9264 );
				AddImageTiled( 14, 80, 260, 240, 9274 );
				AddAlphaRegion( 14, 80, 260, 240 );


				AddHtml( 14, 80, 260, 20, Color( Center( "Candidates" ), LabelColor ), false, false );
				AddHtml( 14, 100, 30, 20, Color( Center( "-->" ), LabelColor ), false, false );
				AddHtml( 47, 100, 150, 20, Color( "Name", LabelColor ), false, false );
				AddHtml( 195, 100, 80, 20, Color( Center( "Votes" ), LabelColor ), false, false );


				for ( int i = 0; i < election.Candidates.Count; ++i )
				{
					Candidate cd = election.Candidates[i];
					Mobile mob = cd.Mobile;


					if ( mob == null )
						continue;


					AddButton( 13, 118 + (i * 20), 4005, 4007, 2 + i, GumpButtonType.Reply, 0 );
					AddHtml( 47, 120 + (i * 20), 150, 20, Color( mob.Name, LabelColor ), false, false );
					AddHtml( 195, 120 + (i * 20), 80, 20, Color( Center( cd.Votes.ToString() ), LabelColor ), false, false );
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class EmeraldWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }


		[Constructable]
		public EmeraldWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the emerald wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "emerald", "monster", 0 );


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "emerald scales" );
   			c.DropItem(scale);
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public EmeraldWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.Network;


namespace Server.Ethics
{
	public abstract class Ethic
	{
		public static readonly bool Enabled = false;


		public static Ethic Find( Item item )
		{
			if ( ( item.SavedFlags & 0x100 ) != 0 )
			{
				if ( item.Hue == Hero.Definition.PrimaryHue )
					return Hero;


				item.SavedFlags &= ~0x100;
			}


			if ( ( item.SavedFlags & 0x200 ) != 0 )
			{
				if ( item.Hue == Evil.Definition.PrimaryHue )
					return Evil;


				item.SavedFlags &= ~0x200;
			}


			return null;
		}


		public static bool CheckTrade( Mobile from, Mobile to, Mobile newOwner, Item item )
		{
			Ethic itemEthic = Find( item );


			if ( itemEthic == null || Find( newOwner ) == itemEthic )
				return true;


			if ( itemEthic == Hero )
				( from == newOwner ? to : from ).SendMessage( "Only heros may receive this item." );
			else if ( itemEthic == Evil )
				( from == newOwner ? to : from ).SendMessage( "Only the evil may receive this item." );


			return false;
		}


		public static bool CheckEquip( Mobile from, Item item )
		{
			Ethic itemEthic = Find( item );


			if ( itemEthic == null || Find( from ) == itemEthic )
				return true;


			if ( itemEthic == Hero )
				from.SendMessage( "Only heros may wear this item." );
			else if ( itemEthic == Evil )
				from.SendMessage( "Only the evil may wear this item." );


			return false;
		}


		public static bool IsImbued( Item item )
		{
			return IsImbued( item, false );
		}


		public static bool IsImbued( Item item, bool recurse )
		{
			if ( Find( item ) != null )
				return true;


			if ( recurse )
			{
				foreach ( Item child in item.Items )
				{
					if ( IsImbued( child, true ) )
						return true;
				}
			}


			return false;
		}


		public static void Initialize()
		{
			if( Enabled )
				EventSink.Speech += new SpeechEventHandler( EventSink_Speech );
		}


		public static void EventSink_Speech( SpeechEventArgs e )
		{
			if ( e.Blocked || e.Handled )
				return;


			Player pl = Player.Find( e.Mobile );


			if ( pl == null )
			{
				for ( int i = 0; i < Ethics.Length; ++i )
				{
					Ethic ethic = Ethics[i];


					if ( !ethic.IsEligible( e.Mobile ) )
						continue;


					if ( !Insensitive.Equals( ethic.Definition.JoinPhrase.String, e.Speech ) )
						continue;


					bool isNearAnkh = false;


					foreach ( Item item in e.Mobile.GetItemsInRange( 2 ) )
					{
						if ( item is Items.AnkhNorth || item is Items.AnkhWest )
						{
							isNearAnkh = true;
							break;
						}
					}


					if ( !isNearAnkh )
						continue;


					pl = new Player( ethic, e.Mobile );


					pl.Attach();


					e.Mobile.FixedEffect( 0x373A, 10, 30 );
					e.Mobile.PlaySound( 0x209 );


					e.Handled = true;
					break;
				}
			}
			else
			{
				Ethic ethic = pl.Ethic;


				for ( int i = 0; i < ethic.Definition.Powers.Length; ++i )
				{
					Power power = ethic.Definition.Powers[i];


					if ( !Insensitive.Equals( power.Definition.Phrase.String, e.Speech ) )
						continue;


					if ( !power.CheckInvoke( pl ) )
						continue;


					power.BeginInvoke( pl );
					e.Handled = true;


					break;
				}
			}
		}


		protected EthicDefinition m_Definition;


		protected PlayerCollection m_Players;


		public EthicDefinition Definition
		{
			get { return m_Definition; }
		}


		public PlayerCollection Players
		{
			get { return m_Players; }
		}


		public static Ethic Find( Mobile mob )
		{
			return Find( mob, false, false );
		}


		public static Ethic Find( Mobile mob, bool inherit )
		{
			return Find( mob, inherit, false );
		}


		public static Ethic Find( Mobile mob, bool inherit, bool allegiance )
		{
			Player pl = Player.Find( mob );


			if ( pl != null )
				return pl.Ethic;


			if ( inherit && mob is BaseCreature )
			{
				BaseCreature bc = (BaseCreature) mob;


				if ( bc.Controlled )
					return Find( bc.ControlMaster, false );
				else if ( bc.Summoned )
					return Find( bc.SummonMaster, false );
				else if ( allegiance )
					return bc.EthicAllegiance;
			}


			return null;
		}


		public Ethic()
		{
			m_Players = new PlayerCollection();
		}


		public abstract bool IsEligible( Mobile mob );


		public virtual void Deserialize( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 0:
				{
					int playerCount = reader.ReadEncodedInt();


					for ( int i = 0; i < playerCount; ++i )
					{
						Player pl = new Player( this, reader );


						if ( pl.Mobile != null )
							Timer.DelayCall( TimeSpan.Zero, new TimerCallback( pl.CheckAttach ) );
					}


					break;
				}
			}
		}


		public virtual void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( 0 ); // version


			writer.WriteEncodedInt( m_Players.Count );


			for ( int i = 0; i < m_Players.Count; ++i )
				m_Players[i].Serialize( writer );
		}


		public static readonly Ethic Hero = new Hero.HeroEthic();
		public static readonly Ethic Evil = new Evil.EvilEthic();


		public static readonly Ethic[] Ethics = new Ethic[]
			{
				Hero,
				Evil
			};
	}
}
// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics
{
	public class EthicDefinition
	{
		private int m_PrimaryHue;


		private TextDefinition m_Title;
		private TextDefinition m_Adjunct;


		private TextDefinition m_JoinPhrase;


		private Power[] m_Powers;


		public int PrimaryHue { get { return m_PrimaryHue; } }


		public TextDefinition Title { get { return m_Title; } }
		public TextDefinition Adjunct { get { return m_Adjunct; } }


		public TextDefinition JoinPhrase { get { return m_JoinPhrase; } }


		public Power[] Powers { get { return m_Powers; } }


		public EthicDefinition( int primaryHue, TextDefinition title, TextDefinition adjunct, TextDefinition joinPhrase, Power[] powers )
		{
			m_PrimaryHue = primaryHue;


			m_Title = title;
			m_Adjunct = adjunct;


			m_JoinPhrase = joinPhrase;


			m_Powers = powers;
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;// using Server.Factions;


namespace Server.Ethics.Hero
{
	public sealed class HeroEthic : Ethic
	{
		public HeroEthic()
		{
			m_Definition = new EthicDefinition(
					0x482,
					"Hero", "(Hero)",
					"I will defend the virtues",
					new Power[]
					{
						new HolySense(),
						new HolyItem(),
						new SummonFamiliar(),
						new HolyBlade(),
						new Bless(),
						new HolyShield(),
						new HolySteed(),
						new HolyWord()
					}
				);
		}


		public override bool IsEligible( Mobile mob )
		{
			if ( mob.Kills >= 5 )
				return false;


			Faction fac = Faction.Find( mob );


			return ( fac is TrueBritannians || fac is CouncilOfMages );
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Factions;


namespace Server.Ethics.Evil
{
	public sealed class EvilEthic : Ethic
	{
		public EvilEthic()
		{
			m_Definition = new EthicDefinition(
					0x455,
					"Evil", "(Evil)",
					"I am evil incarnate",
					new Power[]
					{
						new UnholySense(),
						new UnholyItem(),
						new SummonFamiliar(),
						new VileBlade(),
						new Blight(),
						new UnholyShield(),
						new UnholySteed(),
						new UnholyWord()
					}
				);
		}


		public override bool IsEligible( Mobile mob )
		{
			Faction fac = Faction.Find( mob );


			return ( fac is Minax || fac is Shadowlords );
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Guilds;// using Server.Mobiles;// using Server.Prompts;// using Server.Targeting;// using Server.Accounting;// using Server.Commands;// using Server.Commands.Generic;


namespace Server.Factions
{
	[CustomEnum( new string[]{ "Minax", "Council of Mages", "True Britannians", "Shadowlords" } )]
	public abstract class Faction : IComparable
	{
		public int ZeroRankOffset;


		private FactionDefinition m_Definition;
		private FactionState m_State;
		private StrongholdRegion m_StrongholdRegion;


		public StrongholdRegion StrongholdRegion
		{
			get{ return m_StrongholdRegion; }
			set{ m_StrongholdRegion = value; }
		}


		public FactionDefinition Definition
		{
			get{ return m_Definition; }
			set
			{
				m_Definition = value;
				m_StrongholdRegion = new StrongholdRegion( this );
			}
		}


		public FactionState State
		{
			get{ return m_State; }
			set{ m_State = value; }
		}


		public Election Election
		{
			get{ return m_State.Election; }
			set{ m_State.Election = value; }
		}


		public Mobile Commander
		{
			get{ return m_State.Commander; }
			set{ m_State.Commander = value; }
		}


		public int Tithe
		{
			get{ return m_State.Tithe; }
			set{ m_State.Tithe = value; }
		}


		public int Silver
		{
			get{ return m_State.Silver; }
			set{ m_State.Silver = value; }
		}


		public List<PlayerState> Members
		{
			get{ return m_State.Members; }
			set{ m_State.Members = value; }
		}


		public static readonly TimeSpan LeavePeriod = TimeSpan.FromDays( 3.0 );


		public bool FactionMessageReady
		{
			get{ return m_State.FactionMessageReady; }
		}


		public void Broadcast( string text )
		{
			Broadcast( 0x3B2, text );
		}


		public void Broadcast( int hue, string text )
		{
			List<PlayerState> members = Members;


			for ( int i = 0; i < members.Count; ++i )
				members[i].Mobile.SendMessage( hue, text );
		}


		public void Broadcast( int number )
		{
			List<PlayerState> members = Members;


			for ( int i = 0; i < members.Count; ++i )
				members[i].Mobile.SendLocalizedMessage( number );
		}


		public void Broadcast( string format, params object[] args )
		{
			Broadcast( String.Format( format, args ) );
		}


		public void Broadcast( int hue, string format, params object[] args )
		{
			Broadcast( hue, String.Format( format, args ) );
		}


		public void BeginBroadcast( Mobile from )
		{
			from.SendLocalizedMessage( 1010265 ); // Enter Faction Message
			from.Prompt = new BroadcastPrompt( this );
		}


		public void EndBroadcast( Mobile from, string text )
		{
			if ( from.AccessLevel == AccessLevel.Player )
				m_State.RegisterBroadcast();


			Broadcast( Definition.HueBroadcast, "{0} [Commander] {1} : {2}", from.Name, Definition.FriendlyName, text );
		}


		private class BroadcastPrompt : Prompt
		{
			private Faction m_Faction;


			public BroadcastPrompt( Faction faction )
			{
				m_Faction = faction;
			}


			public override void OnResponse( Mobile from, string text )
			{
				m_Faction.EndBroadcast( from, text );
			}
		}


		public static void HandleAtrophy()
		{
			foreach ( Faction f in Factions )
			{
				if ( !f.State.IsAtrophyReady )
					return;
			}


			List<PlayerState> activePlayers = new List<PlayerState>();


			foreach ( Faction f in Factions )
			{
				foreach ( PlayerState ps in f.Members )
				{
					if ( ps.KillPoints > 0 && ps.IsActive )
						activePlayers.Add( ps );
				}
			}


			int distrib = 0;


			foreach ( Faction f in Factions )
				distrib += f.State.CheckAtrophy();


			if ( activePlayers.Count == 0 )
				return;


			for ( int i = 0; i < distrib; ++i )
				activePlayers[Utility.Random( activePlayers.Count )].KillPoints++;
		}


		public static void DistributePoints( int distrib ) {
			List<PlayerState> activePlayers = new List<PlayerState>();


			foreach ( Faction f in Factions ) {
				foreach ( PlayerState ps in f.Members ) {
					if ( ps.KillPoints > 0 && ps.IsActive ) {
						activePlayers.Add( ps );
					}
				}
			}


			if ( activePlayers.Count > 0 ) {
				for ( int i = 0; i < distrib; ++i ) {
					activePlayers[Utility.Random( activePlayers.Count )].KillPoints++;
				}
			}
		}


		public void BeginHonorLeadership( Mobile from )
		{
			from.SendLocalizedMessage( 502090 ); // Click on the player whom you wish to honor.
			from.BeginTarget( 12, false, TargetFlags.None, new TargetCallback( HonorLeadership_OnTarget ) );
		}


		public void HonorLeadership_OnTarget( Mobile from, object obj )
		{
			if ( obj is Mobile )
			{
				Mobile recv = (Mobile) obj;


				PlayerState giveState = PlayerState.Find( from );
				PlayerState recvState = PlayerState.Find( recv );


				if ( giveState == null )
					return;


				if ( recvState == null || recvState.Faction != giveState.Faction )
				{
					from.SendLocalizedMessage( 1042497 ); // Only faction mates can be honored this way.
				}
				else if ( giveState.KillPoints < 5 )
				{
					from.SendLocalizedMessage( 1042499 ); // You must have at least five kill points to honor them.
				}
				else
				{
					recvState.LastHonorTime = DateTime.Now;
					giveState.KillPoints -= 5;
					recvState.KillPoints += 4;


					// TODO: Confirm no message sent to giver
					recv.SendLocalizedMessage( 1042500 ); // You have been honored with four kill points.
				}
			}
			else
			{
				from.SendLocalizedMessage( 1042496 ); // You may only honor another player.
			}
		}


		public virtual void AddMember( Mobile mob )
		{
			Members.Insert( ZeroRankOffset, new PlayerState( mob, this, Members ) );


			mob.AddToBackpack( FactionItem.Imbue( new Robe(), this, false, Definition.HuePrimary ) );
			mob.SendLocalizedMessage( 1010374 ); // You have been granted a robe which signifies your faction


			mob.InvalidateProperties();
			mob.Delta( MobileDelta.Noto );


			mob.FixedEffect( 0x373A, 10, 30 );
			mob.PlaySound( 0x209 );
		}


		public static bool IsNearType( Mobile mob, Type type, int range )
		{
			bool mobs = type.IsSubclassOf( typeof( Mobile ) );
			bool items = type.IsSubclassOf( typeof( Item ) );


			IPooledEnumerable eable;


			if ( mobs )
				eable = mob.GetMobilesInRange( range );
			else if ( items )
				eable = mob.GetItemsInRange( range );
			else
				return false;


			foreach ( object obj in eable )
			{
				if ( type.IsAssignableFrom( obj.GetType() ) )
				{
					eable.Free();
					return true;
				}
			}


			eable.Free();
			return false;
		}


		public static bool IsNearType( Mobile mob, Type[] types, int range )
		{
			IPooledEnumerable eable = mob.GetObjectsInRange( range );


			foreach( object obj in eable )
			{
				Type objType = obj.GetType();


				for( int i = 0; i < types.Length; i++ )
				{
					if( types[i].IsAssignableFrom( objType ) )
					{
						eable.Free();
						return true;
					}
				}
			}


			eable.Free();
			return false;
		}


		public void RemovePlayerState( PlayerState pl )
		{
			if ( pl == null || !Members.Contains( pl ) )
				return;


			int killPoints = pl.KillPoints;


			if ( pl.RankIndex != -1 ) {
				while ( ( pl.RankIndex + 1 ) < ZeroRankOffset ) {
					PlayerState pNext = Members[pl.RankIndex+1] as PlayerState;
					Members[pl.RankIndex+1] = pl;
					Members[pl.RankIndex] = pNext;
					pl.RankIndex++;
					pNext.RankIndex--;
				}


				ZeroRankOffset--;
			}


			Members.Remove( pl );


			PlayerMobile pm = (PlayerMobile)pl.Mobile;
			if ( pm == null )
				return;


			Mobile mob = pl.Mobile;
			if ( pm.FactionPlayerState == pl ) {
				pm.FactionPlayerState = null;


				mob.InvalidateProperties();
				mob.Delta( MobileDelta.Noto );


				if ( Election.IsCandidate( mob ) )
					Election.RemoveCandidate( mob );


				if ( pl.Finance != null )
					pl.Finance.Finance = null;


				if ( pl.Sheriff != null )
					pl.Sheriff.Sheriff = null;


				Election.RemoveVoter( mob );


				if ( Commander == mob )
					Commander = null;


				pm.ValidateEquipment();
			}


			if ( killPoints > 0 )
				DistributePoints( killPoints );
		}


		public void RemoveMember( Mobile mob )
		{
			PlayerState pl = PlayerState.Find( mob );


			if ( pl == null || !Members.Contains( pl ) )
				return;


			int killPoints = pl.KillPoints;


			if( mob.Backpack != null )
			{
				//Ordinarily, through normal faction removal, this will never find any sigils.
				//Only with a leave delay less than the ReturnPeriod or a Faction Kick/Ban, will this ever do anything
				Item[] sigils = mob.Backpack.FindItemsByType( typeof( Sigil ) );


				for ( int i = 0; i < sigils.Length; ++i )
					((Sigil)sigils[i]).ReturnHome();
			}


			if ( pl.RankIndex != -1 ) {
				while ( ( pl.RankIndex + 1 ) < ZeroRankOffset ) {
					PlayerState pNext = Members[pl.RankIndex+1];
					Members[pl.RankIndex+1] = pl;
					Members[pl.RankIndex] = pNext;
					pl.RankIndex++;
					pNext.RankIndex--;
				}


				ZeroRankOffset--;
			}


			Members.Remove( pl );


			if ( mob is PlayerMobile )
				((PlayerMobile)mob).FactionPlayerState = null;


			mob.InvalidateProperties();
			mob.Delta( MobileDelta.Noto );


			if ( Election.IsCandidate( mob ) )
				Election.RemoveCandidate( mob );


			Election.RemoveVoter( mob );


			if ( pl.Finance != null )
				pl.Finance.Finance = null;


			if ( pl.Sheriff != null )
				pl.Sheriff.Sheriff = null;


			if ( Commander == mob )
				Commander = null;


			if ( mob is PlayerMobile )
				((PlayerMobile)mob).ValidateEquipment();


			if ( killPoints > 0 )
				DistributePoints( killPoints );
		}


		public void JoinGuilded( PlayerMobile mob, Guild guild )
		{
			if ( mob.Young )
			{
				guild.RemoveMember( mob );
				mob.SendLocalizedMessage( 1042283 ); // You have been kicked out of your guild!  Young players may not remain in a guild which is allied with a faction.
			}
			else if ( AlreadyHasCharInFaction( mob ) )
			{
				guild.RemoveMember( mob );
				mob.SendLocalizedMessage( 1005281 ); // You have been kicked out of your guild due to factional overlap
			}
			else if ( IsFactionBanned( mob ) )
			{
				guild.RemoveMember( mob );
				mob.SendLocalizedMessage( 1005052 ); // You are currently banned from the faction system
			}
			else
			{
				AddMember( mob );
				mob.SendLocalizedMessage( 1042756, true, " " + m_Definition.FriendlyName ); // You are now joining a faction:
			}
		}


		public void JoinAlone( Mobile mob )
		{
			AddMember( mob );
			mob.SendLocalizedMessage( 1005058 ); // You have joined the faction
		}


		private bool AlreadyHasCharInFaction( Mobile mob )
		{
			Account acct = mob.Account as Account;


			if ( acct != null )
			{
				for ( int i = 0; i < acct.Length; ++i )
				{
					Mobile c = acct[i];


					if ( Find( c ) != null )
						return true;
				}
			}


			return false;
		}


		public static bool IsFactionBanned( Mobile mob )
		{
			Account acct = mob.Account as Account;


			if ( acct == null )
				return false;


			return ( acct.GetTag( "FactionBanned" ) != null );
		}


		public void OnJoinAccepted( Mobile mob )
		{
			PlayerMobile pm = mob as PlayerMobile;


			if ( pm == null )
				return; // sanity


			PlayerState pl = PlayerState.Find( pm );


			if ( pm.Young )
				pm.SendLocalizedMessage( 1010104 ); // You cannot join a faction as a young player
			else if ( pl != null && pl.IsLeaving )
				pm.SendLocalizedMessage( 1005051 ); // You cannot use the faction stone until you have finished quitting your current faction
			else if ( AlreadyHasCharInFaction( pm ) )
				pm.SendLocalizedMessage( 1005059 ); // You cannot join a faction because you already declared your allegiance with another character
			else if ( IsFactionBanned( mob ) )
				pm.SendLocalizedMessage( 1005052 ); // You are currently banned from the faction system
			else if ( pm.Guild != null )
			{
				Guild guild = pm.Guild as Guild;


				if ( guild.Leader != pm )
					pm.SendLocalizedMessage( 1005057 ); // You cannot join a faction because you are in a guild and not the guildmaster
				else if ( !Guild.NewGuildSystem && guild.Type != GuildType.Regular )
					pm.SendLocalizedMessage( 1042161 ); // You cannot join a faction because your guild is an Order or Chaos type.
				else if ( !Guild.NewGuildSystem && guild.Enemies != null && guild.Enemies.Count > 0 )	//CAN join w/wars in new system
					pm.SendLocalizedMessage( 1005056 ); // You cannot join a faction with active Wars
				else if ( Guild.NewGuildSystem && guild.Alliance != null )
					pm.SendLocalizedMessage( 1080454 ); // Your guild cannot join a faction while in alliance with non-factioned guilds.
				else if ( !CanHandleInflux( guild.Members.Count ) )
					pm.SendLocalizedMessage( 1018031 ); // In the interest of faction stability, this faction declines to accept new members for now.
				else
				{
					List<Mobile> members = new List<Mobile>( guild.Members );


					for ( int i = 0; i < members.Count; ++i )
					{
						PlayerMobile member = members[i] as PlayerMobile;


						if ( member == null )
							continue;


						JoinGuilded( member, guild );
					}
				}
			}
			else if ( !CanHandleInflux( 1 ) )
			{
				pm.SendLocalizedMessage( 1018031 ); // In the interest of faction stability, this faction declines to accept new members for now.
			}
			else
			{
				JoinAlone( mob );
			}
		}


		public bool IsCommander( Mobile mob )
		{
			if ( mob == null )
				return false;


			return ( mob.AccessLevel >= AccessLevel.GameMaster || mob == Commander );
		}


		public Faction()
		{
			m_State = new FactionState( this );
		}


		public override string ToString()
		{
			return m_Definition.FriendlyName;
		}


		public int CompareTo( object obj )
		{
			return m_Definition.Sort - ((Faction)obj).m_Definition.Sort;
		}


		public static bool CheckLeaveTimer( Mobile mob )
		{
			PlayerState pl = PlayerState.Find( mob );


			if ( pl == null || !pl.IsLeaving )
				return false;


			if ( (pl.Leaving + LeavePeriod) >= DateTime.Now )
				return false;


			mob.SendLocalizedMessage( 1005163 ); // You have now quit your faction


			pl.Faction.RemoveMember( mob );


			return true;
		}


		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler( EventSink_Login );
			EventSink.Logout += new LogoutEventHandler( EventSink_Logout );


			Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), TimeSpan.FromMinutes( 10.0 ), new TimerCallback( HandleAtrophy ) );


			Timer.DelayCall( TimeSpan.FromSeconds( 30.0 ), TimeSpan.FromSeconds( 30.0 ), new TimerCallback( ProcessTick ) );


			CommandSystem.Register( "FactionElection", AccessLevel.GameMaster, new CommandEventHandler( FactionElection_OnCommand ) );
			CommandSystem.Register( "FactionCommander", AccessLevel.Administrator, new CommandEventHandler( FactionCommander_OnCommand ) );
			CommandSystem.Register( "FactionItemReset", AccessLevel.Administrator, new CommandEventHandler( FactionItemReset_OnCommand ) );
			CommandSystem.Register( "FactionReset", AccessLevel.Administrator, new CommandEventHandler( FactionReset_OnCommand ) );
			CommandSystem.Register( "FactionTownReset", AccessLevel.Administrator, new CommandEventHandler( FactionTownReset_OnCommand ) );
		}


		public static void FactionTownReset_OnCommand( CommandEventArgs e )
		{
			List<BaseMonolith> monoliths = BaseMonolith.Monoliths;


			for ( int i = 0; i < monoliths.Count; ++i )
				monoliths[i].Sigil = null;


			List<Town> towns = Town.Towns;


			for ( int i = 0; i < towns.Count; ++i )
			{
				towns[i].Silver = 0;
				towns[i].Sheriff = null;
				towns[i].Finance = null;
				towns[i].Tax = 0;
				towns[i].Owner = null;
			}


			List<Sigil> sigils = Sigil.Sigils;


			for ( int i = 0; i < sigils.Count; ++i )
			{
				sigils[i].Corrupted = null;
				sigils[i].Corrupting = null;
				sigils[i].LastStolen = DateTime.MinValue;
				sigils[i].GraceStart = DateTime.MinValue;
				sigils[i].CorruptionStart = DateTime.MinValue;
				sigils[i].PurificationStart = DateTime.MinValue;
				sigils[i].LastMonolith = null;
				sigils[i].ReturnHome();
			}


			List<Faction> factions = Faction.Factions;


			for ( int i = 0; i < factions.Count; ++i )
			{
				Faction f = factions[i];


				List<FactionItem> list = new List<FactionItem>( f.State.FactionItems );


				for ( int j = 0; j < list.Count; ++j )
				{
					FactionItem fi = list[j];


					if ( fi.Expiration == DateTime.MinValue )
						fi.Item.Delete();
					else
						fi.Detach();
				}
			}
		}


		public static void FactionReset_OnCommand( CommandEventArgs e )
		{
			List<BaseMonolith> monoliths = BaseMonolith.Monoliths;


			for ( int i = 0; i < monoliths.Count; ++i )
				monoliths[i].Sigil = null;


			List<Town> towns = Town.Towns;


			for ( int i = 0; i < towns.Count; ++i )
			{
				towns[i].Silver = 0;
				towns[i].Sheriff = null;
				towns[i].Finance = null;
				towns[i].Tax = 0;
				towns[i].Owner = null;
			}


			List<Sigil> sigils = Sigil.Sigils;


			for ( int i = 0; i < sigils.Count; ++i )
			{
				sigils[i].Corrupted = null;
				sigils[i].Corrupting = null;
				sigils[i].LastStolen = DateTime.MinValue;
				sigils[i].GraceStart = DateTime.MinValue;
				sigils[i].CorruptionStart = DateTime.MinValue;
				sigils[i].PurificationStart = DateTime.MinValue;
				sigils[i].LastMonolith = null;
				sigils[i].ReturnHome();
			}


			List<Faction> factions = Faction.Factions;


			for ( int i = 0; i < factions.Count; ++i )
			{
				Faction f = factions[i];


				List<PlayerState> playerStateList = new List<PlayerState>( f.Members );


				for( int j = 0; j < playerStateList.Count; ++j )
					f.RemoveMember( playerStateList[j].Mobile );


				List<FactionItem> factionItemList = new List<FactionItem>( f.State.FactionItems );


				for( int j = 0; j < factionItemList.Count; ++j )
				{
					FactionItem fi = (FactionItem)factionItemList[j];


					if ( fi.Expiration == DateTime.MinValue )
						fi.Item.Delete();
					else
						fi.Detach();
				}


				List<BaseFactionTrap> factionTrapList = new List<BaseFactionTrap>( f.Traps );


				for( int j = 0; j < factionTrapList.Count; ++j )
					factionTrapList[j].Delete();
			}
		}


		public static void FactionItemReset_OnCommand( CommandEventArgs e )
		{
			ArrayList pots = new ArrayList();


			foreach ( Item item in World.Items.Values )
			{
				if ( item is IFactionItem && !(item is HoodedShroudOfShadows) )
					pots.Add( item );
			}


			int[] hues = new int[Factions.Count * 2];


			for ( int i = 0; i < Factions.Count; ++i )
			{
				hues[0+(i*2)] = Factions[i].Definition.HuePrimary;
				hues[1+(i*2)] = Factions[i].Definition.HueSecondary;
			}


			int count = 0;


			for ( int i = 0; i < pots.Count; ++i )
			{
				Item item = (Item)pots[i];
				IFactionItem fci = (IFactionItem)item;


				if ( fci.FactionItemState != null || item.LootType != LootType.Blessed )
					continue;


				bool isHued = false;


				for ( int j = 0; j < hues.Length; ++j )
				{
					if ( item.Hue == hues[j] )
					{
						isHued = true;
						break;
					}
				}


				if ( isHued )
				{
					fci.FactionItemState = null;
					++count;
				}
			}


			e.Mobile.SendMessage( "{0} items reset", count );
		}


		public static void FactionCommander_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Target a player to make them the faction commander." );
			e.Mobile.BeginTarget( -1, false, TargetFlags.None, new TargetCallback( FactionCommander_OnTarget ) );
		}


		public static void FactionCommander_OnTarget( Mobile from, object obj )
		{
			if ( obj is PlayerMobile )
			{
				Mobile targ = (Mobile)obj;
				PlayerState pl = PlayerState.Find( targ );


				if ( pl != null )
				{
					pl.Faction.Commander = targ;
					from.SendMessage( "You have appointed them as the faction commander." );
				}
				else
				{
					from.SendMessage( "They are not in a faction." );
				}
			}
			else
			{
				from.SendMessage( "That is not a player." );
			}
		}


		public static void FactionElection_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Target a faction stone to open its election properties." );
			e.Mobile.BeginTarget( -1, false, TargetFlags.None, new TargetCallback( FactionElection_OnTarget ) );
		}


		public static void FactionElection_OnTarget( Mobile from, object obj )
		{
			if ( obj is FactionStone )
			{
				Faction faction = ((FactionStone)obj).Faction;


				if ( faction != null )
					from.SendGump( new ElectionManagementGump( faction.Election ) );
					//from.SendGump( new Gumps.PropertiesGump( from, faction.Election ) );
				else
					from.SendMessage( "That stone has no faction assigned." );
			}
			else
			{
				from.SendMessage( "That is not a faction stone." );
			}
		}


		public static void FactionKick_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Target a player to remove them from their faction." );
			e.Mobile.BeginTarget( -1, false, TargetFlags.None, new TargetCallback( FactionKick_OnTarget ) );
		}


		public static void FactionKick_OnTarget( Mobile from, object obj )
		{
			if ( obj is Mobile )
			{
				Mobile mob = (Mobile) obj;
				PlayerState pl = PlayerState.Find( (Mobile) mob );


				if ( pl != null )
				{
					pl.Faction.RemoveMember( mob );


					mob.SendMessage( "You have been kicked from your faction." );
					from.SendMessage( "They have been kicked from their faction." );
				}
				else
				{
					from.SendMessage( "They are not in a faction." );
				}
			}
			else
			{
				from.SendMessage( "That is not a player." );
			}
		}


		public static void ProcessTick()
		{
			List<Sigil> sigils = Sigil.Sigils;


			for ( int i = 0; i < sigils.Count; ++i )
			{
				Sigil sigil = sigils[i];


				if ( !sigil.IsBeingCorrupted && sigil.GraceStart != DateTime.MinValue && (sigil.GraceStart + Sigil.CorruptionGrace) < DateTime.Now )
				{
					if ( sigil.LastMonolith is StrongholdMonolith && ( sigil.Corrupted == null || sigil.LastMonolith.Faction != sigil.Corrupted ))
					{
						sigil.Corrupting = sigil.LastMonolith.Faction;
						sigil.CorruptionStart = DateTime.Now;
					}
					else
					{
						sigil.Corrupting = null;
						sigil.CorruptionStart = DateTime.MinValue;
					}


					sigil.GraceStart = DateTime.MinValue;
				}


				if ( sigil.LastMonolith == null || sigil.LastMonolith.Sigil == null )
				{
					if ( (sigil.LastStolen + Sigil.ReturnPeriod) < DateTime.Now )
						sigil.ReturnHome();
				}
				else
				{
					if ( sigil.IsBeingCorrupted && (sigil.CorruptionStart + Sigil.CorruptionPeriod) < DateTime.Now )
					{
						sigil.Corrupted = sigil.Corrupting;
						sigil.Corrupting = null;
						sigil.CorruptionStart = DateTime.MinValue;
						sigil.GraceStart = DateTime.MinValue;
					}
					else if ( sigil.IsPurifying && (sigil.PurificationStart + Sigil.PurificationPeriod) < DateTime.Now )
					{
						sigil.PurificationStart = DateTime.MinValue;
						sigil.Corrupted = null;
						sigil.Corrupting = null;
						sigil.CorruptionStart = DateTime.MinValue;
						sigil.GraceStart = DateTime.MinValue;
					}
				}
			}
		}


		public static void HandleDeath( Mobile mob )
		{
			HandleDeath( mob, null );
		}


		#region Skill Loss
		public const double SkillLossFactor = 1.0 / 3;
		public static readonly TimeSpan SkillLossPeriod = TimeSpan.FromMinutes( 20.0 );


		private static Dictionary<Mobile, SkillLossContext> m_SkillLoss = new Dictionary<Mobile, SkillLossContext>();


		private class SkillLossContext
		{
			public Timer m_Timer;
			public List<SkillMod> m_Mods;
		}


		public static bool InSkillLoss( Mobile mob )
		{
			return m_SkillLoss.ContainsKey( mob );
		}


		public static void ApplySkillLoss( Mobile mob )
		{
			if ( InSkillLoss( mob ) )
				return;


			SkillLossContext context = new SkillLossContext();
			m_SkillLoss[mob] = context;


			List<SkillMod> mods = context.m_Mods = new List<SkillMod>();


			for ( int i = 0; i < mob.Skills.Length; ++i )
			{
				Skill sk = mob.Skills[i];
				double baseValue = sk.Base;


				if ( baseValue > 0 )
				{
					SkillMod mod = new DefaultSkillMod( sk.SkillName, true, -(baseValue * SkillLossFactor) );


					mods.Add( mod );
					mob.AddSkillMod( mod );
				}
			}


			context.m_Timer = Timer.DelayCall( SkillLossPeriod, new TimerStateCallback( ClearSkillLoss_Callback ), mob );
		}


		private static void ClearSkillLoss_Callback( object state )
		{
			ClearSkillLoss( (Mobile) state );
		}


		public static bool ClearSkillLoss( Mobile mob )
		{
			SkillLossContext context;


			if ( !m_SkillLoss.TryGetValue( mob, out context ) )
				return false;


			m_SkillLoss.Remove( mob );


			List<SkillMod> mods = context.m_Mods;


			for ( int i = 0; i < mods.Count; ++i )
				mob.RemoveSkillMod( mods[i] );


			context.m_Timer.Stop();


			return true;
		}
		#endregion


		public int AwardSilver( Mobile mob, int silver )
		{
			if ( silver <= 0 )
				return 0;


			int tithed = ( silver * Tithe ) / 100;


			Silver += tithed;


			silver = silver - tithed;


			if ( silver > 0 )
				mob.AddToBackpack( new Silver( silver ) );


			return silver;
		}


		public virtual int MaximumTraps{ get{ return 15; } }


		public List<BaseFactionTrap> Traps
		{
			get{ return m_State.Traps; }
			set{ m_State.Traps = value; }
		}


		public const int StabilityFactor = 300; // 300% greater (3 times) than smallest faction
		public const int StabilityActivation = 200; // Stablity code goes into effect when largest faction has > 200 people


		public static Faction FindSmallestFaction()
		{
			List<Faction> factions = Factions;
			Faction smallest = null;


			for ( int i = 0; i < factions.Count; ++i )
			{
				Faction faction = factions[i];


				if ( smallest == null || faction.Members.Count < smallest.Members.Count )
					smallest = faction;
			}


			return smallest;
		}


		public static bool StabilityActive()
		{
			List<Faction> factions = Factions;


			for ( int i = 0; i < factions.Count; ++i )
			{
				Faction faction = factions[i];


				if ( faction.Members.Count > StabilityActivation )
					return true;
			}


			return false;
		}


		public bool CanHandleInflux( int influx )
		{
			if( !StabilityActive())
				return true;


			Faction smallest = FindSmallestFaction();


			if ( smallest == null )
				return true; // sanity


			if ( StabilityFactor > 0 && (((this.Members.Count + influx) * 100) / StabilityFactor) > smallest.Members.Count )
				return false;


			return true;
		}


		public static void HandleDeath( Mobile victim, Mobile killer )
		{
			if ( killer == null )
				killer = victim.FindMostRecentDamager( true );


			PlayerState killerState = PlayerState.Find( killer );


			Container pack = victim.Backpack;


			if ( pack != null )
			{
				Container killerPack = ( killer == null ? null : killer.Backpack );
				Item[] sigils = pack.FindItemsByType( typeof( Sigil ) );


				for ( int i = 0; i < sigils.Length; ++i )
				{
					Sigil sigil = (Sigil)sigils[i];


					if ( killerState != null && killerPack != null )
					{
						if ( killer.GetDistanceToSqrt( victim ) > 64 ) {
							sigil.ReturnHome();
							killer.SendLocalizedMessage( 1042230 ); // The sigil has gone back to its home location.
						}
						else if ( Sigil.ExistsOn( killer ) )
						{
							sigil.ReturnHome();
							killer.SendLocalizedMessage( 1010258 ); // The sigil has gone back to its home location because you already have a sigil.
						}
						else if ( !killerPack.TryDropItem( killer, sigil, false ) )
						{
							sigil.ReturnHome();
							killer.SendLocalizedMessage( 1010259 ); // The sigil has gone home because your backpack is full.
						}
					}
					else
					{
						sigil.ReturnHome();
					}
				}
			}


			if ( killerState == null )
				return;


			if ( victim is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)victim;
				Faction victimFaction = bc.FactionAllegiance;


				if ( bc.Map == Faction.Facet && victimFaction != null && killerState.Faction != victimFaction )
				{
					int silver = killerState.Faction.AwardSilver( killer, bc.FactionSilverWorth );


					if ( silver > 0 )
						killer.SendLocalizedMessage( 1042748, silver.ToString( "N0" ) ); // Thou hast earned ~1_AMOUNT~ silver for vanquishing the vile creature.
				}


				#region Ethics
				if ( bc.Map == Faction.Facet && bc.GetEthicAllegiance( killer ) == BaseCreature.Allegiance.Enemy )
				{
					Ethics.Player killerEPL = Ethics.Player.Find( killer );


					if ( killerEPL != null && ( 100 - killerEPL.Power ) > Utility.Random( 100 ) )
					{
						++killerEPL.Power;
						++killerEPL.History;
					}
				}
				#endregion


				return;
			}


			PlayerState victimState = PlayerState.Find( victim );


			if ( victimState == null )
				return;


			if ( killer == victim || killerState.Faction != victimState.Faction )
				ApplySkillLoss( victim );


			if ( killerState.Faction != victimState.Faction )
			{
				if ( victimState.KillPoints <= -6 )
				{
					killer.SendLocalizedMessage( 501693 ); // This victim is not worth enough to get kill points from. 


					#region Ethics
					Ethics.Player killerEPL = Ethics.Player.Find( killer );
					Ethics.Player victimEPL = Ethics.Player.Find( victim );


					if ( killerEPL != null && victimEPL != null && victimEPL.Power > 0 && victimState.CanGiveSilverTo( killer ) )
					{
						int powerTransfer = Math.Max( 1, victimEPL.Power / 5 );


						if ( powerTransfer > ( 100 - killerEPL.Power ) )
							powerTransfer = 100 - killerEPL.Power;


						if ( powerTransfer > 0 )
						{
							victimEPL.Power -= ( powerTransfer + 1 ) / 2;
							killerEPL.Power += powerTransfer;


							killerEPL.History += powerTransfer;


							victimState.OnGivenSilverTo( killer );
						}
					}
					#endregion
				}
				else
				{
					int award = Math.Max( victimState.KillPoints / 10, 1 );


					if ( award > 40 )
						award = 40;


					if ( victimState.CanGiveSilverTo( killer ) )
					{
						if ( victimState.KillPoints > 0 )
						{
							victimState.IsActive = true;


							if ( 1 > Utility.Random( 3 ) )
								killerState.IsActive = true;
							
							int silver = 0;


							silver = killerState.Faction.AwardSilver( killer, award * 40 );


							if ( silver > 0 )
								killer.SendLocalizedMessage( 1042736, String.Format( "{0:N0} silver\t{1}", silver, victim.Name ) ); // You have earned ~1_SILVER_AMOUNT~ pieces for vanquishing ~2_PLAYER_NAME~!
						}


						victimState.KillPoints -= award;
						killerState.KillPoints += award;


						int offset = ( award != 1 ? 0 : 2 ); // for pluralization


						string args = String.Format( "{0}\t{1}\t{2}", award, victim.Name, killer.Name );


						killer.SendLocalizedMessage( 1042737 + offset, args ); // Thou hast been honored with ~1_KILL_POINTS~ kill point(s) for vanquishing ~2_DEAD_PLAYER~!
						victim.SendLocalizedMessage( 1042738 + offset, args ); // Thou has lost ~1_KILL_POINTS~ kill point(s) to ~3_ATTACKER_NAME~ for being vanquished!


						#region Ethics
						Ethics.Player killerEPL = Ethics.Player.Find( killer );
						Ethics.Player victimEPL = Ethics.Player.Find( victim );


						if ( killerEPL != null && victimEPL != null && victimEPL.Power > 0 )
						{
							int powerTransfer = Math.Max( 1, victimEPL.Power / 5 );


							if ( powerTransfer > ( 100 - killerEPL.Power ) )
								powerTransfer = 100 - killerEPL.Power;


							if ( powerTransfer > 0 )
							{
								victimEPL.Power -= ( powerTransfer + 1 ) / 2;
								killerEPL.Power += powerTransfer;


								killerEPL.History += powerTransfer;
							}
						}
						#endregion


						victimState.OnGivenSilverTo( killer );
					}
					else
					{
						killer.SendLocalizedMessage( 1042231 ); // You have recently defeated this enemy and thus their death brings you no honor.
					}
				}
			}
		}


		private static void EventSink_Logout( LogoutEventArgs e )
		{
			Mobile mob = e.Mobile;


			Container pack = mob.Backpack;


			if ( pack == null )
				return;


			Item[] sigils = pack.FindItemsByType( typeof( Sigil ) );


			for ( int i = 0; i < sigils.Length; ++i )
				((Sigil)sigils[i]).ReturnHome();
		}


		private static void EventSink_Login( LoginEventArgs e )
		{
			Mobile mob = e.Mobile;


			CheckLeaveTimer( mob );
		}


		public static readonly Map Facet = Map.Felucca;


		public static void WriteReference( GenericWriter writer, Faction fact )
		{
			int idx = Factions.IndexOf( fact );


			writer.WriteEncodedInt( (int) (idx + 1) );
		}


		public static List<Faction> Factions{ get{ return Reflector.Factions; } }


		public static Faction ReadReference( GenericReader reader )
		{
			int idx = reader.ReadEncodedInt() - 1;


			if ( idx >= 0 && idx < Factions.Count )
				return Factions[idx];


			return null;
		}


		public static Faction Find( Mobile mob )
		{
			return Find( mob, false, false );
		}


		public static Faction Find( Mobile mob, bool inherit )
		{
			return Find( mob, inherit, false );
		}


		public static Faction Find( Mobile mob, bool inherit, bool creatureAllegiances )
		{
			PlayerState pl = PlayerState.Find( mob );


			if ( pl != null )
				return pl.Faction;


			if ( inherit && mob is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)mob;


				if ( bc.Controlled )
					return Find( bc.ControlMaster, false );
				else if ( bc.Summoned )
					return Find( bc.SummonMaster, false );
				else if ( creatureAllegiances && mob is BaseFactionGuard )
					return ((BaseFactionGuard)mob).Faction;
				else if ( creatureAllegiances )
					return bc.FactionAllegiance;
			}


			return null;
		}


		public static Faction Parse( string name )
		{
			List<Faction> factions = Factions;


			for ( int i = 0; i < factions.Count; ++i )
			{
				Faction faction = factions[i];


				if ( Insensitive.Equals( faction.Definition.FriendlyName, name ) )
					return faction;
			}


			return null;
		}
	}


	public enum FactionKickType
	{
		Kick,
		Ban,
		Unban
	}


	public class FactionKickCommand : BaseCommand
	{
		private FactionKickType m_KickType;


		public FactionKickCommand( FactionKickType kickType )
		{
			m_KickType = kickType;


			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.AllMobiles;
			ObjectTypes = ObjectTypes.Mobiles;


			switch ( m_KickType )
			{
				case FactionKickType.Kick:
				{
					Commands = new string[]{ "FactionKick" };
					Usage = "FactionKick";
					Description = "Kicks the targeted player out of his current faction. This does not prevent them from rejoining.";
					break;
				}
				case FactionKickType.Ban:
				{
					Commands = new string[]{ "FactionBan" };
					Usage = "FactionBan";
					Description = "Bans the account of a targeted player from joining factions. All players on the account are removed from their current faction, if any.";
					break;
				}
				case FactionKickType.Unban:
				{
					Commands = new string[]{ "FactionUnban" };
					Usage = "FactionUnban";
					Description = "Unbans the account of a targeted player from joining factions.";
					break;
				}
			}
		}


		public override void Execute( CommandEventArgs e, object obj )
		{
			Mobile mob = (Mobile)obj;


			switch ( m_KickType )
			{
				case FactionKickType.Kick:
				{
					PlayerState pl = PlayerState.Find( mob );


					if ( pl != null )
					{
						pl.Faction.RemoveMember( mob );
						mob.SendMessage( "You have been kicked from your faction." );
						AddResponse( "They have been kicked from their faction." );
					}
					else
					{
						LogFailure( "They are not in a faction." );
					}


					break;
				}
				case FactionKickType.Ban:
				{
					Account acct = mob.Account as Account;


					if ( acct != null )
					{
						if ( acct.GetTag( "FactionBanned" ) == null )
						{
							acct.SetTag( "FactionBanned", "true" );
							AddResponse( "The account has been banned from joining factions." );
						}
						else
						{
							AddResponse( "The account is already banned from joining factions." );
						}


						for ( int i = 0; i < acct.Length; ++i )
						{
							mob = acct[i];


							if ( mob != null )
							{
								PlayerState pl = PlayerState.Find( mob );


								if ( pl != null )
								{
									pl.Faction.RemoveMember( mob );
									mob.SendMessage( "You have been kicked from your faction." );
									AddResponse( "They have been kicked from their faction." );
								}
							}
						}
					}
					else
					{
						LogFailure( "They have no assigned account." );
					}


					break;
				}
				case FactionKickType.Unban:
				{
					Account acct = mob.Account as Account;


					if ( acct != null )
					{
						if ( acct.GetTag( "FactionBanned" ) == null )
						{
							AddResponse( "The account is not already banned from joining factions." );
						}
						else
						{
							acct.RemoveTag( "FactionBanned" );
							AddResponse( "The account may now freely join factions." );
						}
					}
					else
					{
						LogFailure( "They have no assigned account." );
					}


					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Factions
{
	public class FactionBerserker : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Melee | GuardAI.Curse | GuardAI.Bless; } }


		[Constructable]
		public FactionBerserker() : base( "the berserker" )
		{
			GenerateBody( false, false );


			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );


			VirtualArmor = 24;


			SetSkill( SkillName.Swords, 100.0, 110.0 );
			SetSkill( SkillName.Wrestling, 100.0, 110.0 );
			SetSkill( SkillName.Tactics, 100.0, 110.0 );
			SetSkill( SkillName.MagicResist, 100.0, 110.0 );
			SetSkill( SkillName.Healing, 100.0, 110.0 );
			SetSkill( SkillName.Anatomy, 100.0, 110.0 );


			SetSkill( SkillName.Magery, 100.0, 110.0 );
			SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Meditation, 100.0, 110.0 );


			AddItem( Immovable( Rehued( new BodySash(), 1645 ) ) );
			AddItem( Immovable( Rehued( new Kilt(), 1645 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1645 ) ) );
			AddItem( Newbied( new DoubleAxe() ) );


			HairItemID = 0x2047; // Afro
			HairHue = 0x29;


			FacialHairItemID = 0x204B; // Medium Short Beard
			FacialHairHue = 0x29;


			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}


		public FactionBerserker( Serial serial ) : base( serial )
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
// using System;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;


namespace Server.Factions
{
	public class FactionBoardVendor : BaseFactionVendor
	{
		public FactionBoardVendor( Town town, Faction faction ) : base( town, faction, "the LumberMan" ) // NOTE: title inconsistant, as OSI
		{
			SetSkill( SkillName.Carpentry, 85.0, 100.0 );
			SetSkill( SkillName.Lumberjacking, 60.0, 83.0 );
		}


		public override void InitSBInfo()
		{
			SBInfos.Add( new SBFactionBoard() );
		}


		public override void InitOutfit()
		{
			base.InitOutfit();


			AddItem( new HalfApron() );
		}


		public FactionBoardVendor( Serial serial ) : base( serial )
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


	public class SBFactionBoard : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();


		public SBFactionBoard()
		{
		}


		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }


		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				for ( int i = 0; i < 5; ++i )
					Add( new GenericBuyInfo( typeof( Board ), 3, 20, 0x1BD7, 0 ) );
			}
		}


		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
// using System;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;


namespace Server.Factions
{
	public class FactionBottleVendor : BaseFactionVendor
	{
		public FactionBottleVendor( Town town, Faction faction ) : base( town, faction, "the Bottle Seller" )
		{
			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.TasteID, 65.0, 88.0 );
		}


		public override void InitSBInfo()
		{
			SBInfos.Add( new SBFactionBottle() );
		}


		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals; }
		}


		public override void InitOutfit()
		{
			base.InitOutfit();


			AddItem( new Robe( Utility.RandomPinkHue() ) );
		}


		public FactionBottleVendor( Serial serial ) : base( serial )
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


	public class SBFactionBottle : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();


		public SBFactionBottle()
		{
		}


		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }


		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				for ( int i = 0; i < 5; ++i )
					Add( new GenericBuyInfo( typeof( Bottle ), 5, 20, 0xF0E, 0 ) );
			}
		}


		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Factions
{
	public class FactionDeathKnight : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Melee | GuardAI.Curse | GuardAI.Bless; } }


		[Constructable]
		public FactionDeathKnight() : base( "the death knight" )
		{
			GenerateBody( false, false );
			Hue = 1;


			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );


			VirtualArmor = 24;


			SetSkill( SkillName.Swords, 100.0, 110.0 );
			SetSkill( SkillName.Wrestling, 100.0, 110.0 );
			SetSkill( SkillName.Tactics, 100.0, 110.0 );
			SetSkill( SkillName.MagicResist, 100.0, 110.0 );
			SetSkill( SkillName.Healing, 100.0, 110.0 );
			SetSkill( SkillName.Anatomy, 100.0, 110.0 );


			SetSkill( SkillName.Magery, 100.0, 110.0 );
			SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Meditation, 100.0, 110.0 );


			Item shroud = new Item( 0x204E );
			shroud.Layer = Layer.OuterTorso;


			AddItem( Immovable( Rehued( shroud, 1109 ) ) );
			AddItem( Newbied( Rehued( new ExecutionersAxe(), 2211 ) ) );


			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}


		public FactionDeathKnight( Serial serial ) : base( serial )
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
// using System;


namespace Server.Factions
{
	public class FactionDefinition
	{
		private int m_Sort;


		private int m_HuePrimary;
		private int m_HueSecondary;
		private int m_HueJoin;
		private int m_HueBroadcast;


		private int m_WarHorseBody;
		private int m_WarHorseItem;


		private string m_FriendlyName;
		private string m_Keyword;
		private string m_Abbreviation;


		private TextDefinition m_Name;
		private TextDefinition m_PropName;
		private TextDefinition m_Header;
		private TextDefinition m_About;
		private TextDefinition m_CityControl;
		private TextDefinition m_SigilControl;
		private TextDefinition m_SignupName;
		private TextDefinition m_FactionStoneName;
		private TextDefinition m_OwnerLabel;


		private TextDefinition m_GuardIgnore, m_GuardWarn, m_GuardAttack;


		private StrongholdDefinition m_Stronghold;


		private RankDefinition[] m_Ranks;
		private GuardDefinition[] m_Guards;


		public int Sort{ get{ return m_Sort; } }


		public int HuePrimary{ get{ return m_HuePrimary; } }
		public int HueSecondary{ get{ return m_HueSecondary; } }
		public int HueJoin{ get{ return m_HueJoin; } }
		public int HueBroadcast{ get{ return m_HueBroadcast; } }


		public int WarHorseBody{ get{ return m_WarHorseBody; } }
		public int WarHorseItem{ get{ return m_WarHorseItem; } }


		public string FriendlyName{ get{ return m_FriendlyName; } }
		public string Keyword{ get{ return m_Keyword; } }
		public string Abbreviation{ get { return m_Abbreviation; } }


		public TextDefinition Name{ get{ return m_Name; } }
		public TextDefinition PropName{ get{ return m_PropName; } }
		public TextDefinition Header{ get{ return m_Header; } }
		public TextDefinition About{ get{ return m_About; } }
		public TextDefinition CityControl{ get{ return m_CityControl; } }
		public TextDefinition SigilControl{ get{ return m_SigilControl; } }
		public TextDefinition SignupName{ get{ return m_SignupName; } }
		public TextDefinition FactionStoneName{ get{ return m_FactionStoneName; } }
		public TextDefinition OwnerLabel{ get{ return m_OwnerLabel; } }


		public TextDefinition GuardIgnore{ get{ return m_GuardIgnore; } }
		public TextDefinition GuardWarn{ get{ return m_GuardWarn; } }
		public TextDefinition GuardAttack{ get{ return m_GuardAttack; } }


		public StrongholdDefinition Stronghold{ get{ return m_Stronghold; } }


		public RankDefinition[] Ranks{ get{ return m_Ranks; } }
		public GuardDefinition[] Guards{ get{ return m_Guards; } }


		public FactionDefinition( int sort, int huePrimary, int hueSecondary, int hueJoin, int hueBroadcast, int warHorseBody, int warHorseItem, string friendlyName, string keyword, string abbreviation, TextDefinition name, TextDefinition propName, TextDefinition header, TextDefinition about, TextDefinition cityControl, TextDefinition sigilControl, TextDefinition signupName, TextDefinition factionStoneName, TextDefinition ownerLabel, TextDefinition guardIgnore, TextDefinition guardWarn, TextDefinition guardAttack, StrongholdDefinition stronghold, RankDefinition[] ranks, GuardDefinition[] guards )
		{
			m_Sort = sort;
			m_HuePrimary = huePrimary;
			m_HueSecondary = hueSecondary;
			m_HueJoin = hueJoin;
			m_HueBroadcast = hueBroadcast;
			m_WarHorseBody = warHorseBody;
			m_WarHorseItem = warHorseItem;
			m_FriendlyName = friendlyName;
			m_Keyword = keyword;
			m_Abbreviation = abbreviation;
			m_Name = name;
			m_PropName = propName;
			m_Header = header;
			m_About = about;
			m_CityControl = cityControl;
			m_SigilControl = sigilControl;
			m_SignupName = signupName;
			m_FactionStoneName = factionStoneName;
			m_OwnerLabel = ownerLabel;
			m_GuardIgnore = guardIgnore;
			m_GuardWarn = guardWarn;
			m_GuardAttack = guardAttack;
			m_Stronghold = stronghold;
			m_Ranks = ranks;
			m_Guards = guards;
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;


namespace Server.Factions
{
	public class FactionDragoon : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Melee | GuardAI.Smart | GuardAI.Bless | GuardAI.Curse; } }


		[Constructable]
		public FactionDragoon() : base( "the dragoon" )
		{
			GenerateBody( false, false );


			SetStr( 151, 175 );
			SetDex( 61, 85 );
			SetInt( 151, 175 );


			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Energy, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 60 );


			VirtualArmor = 32;


			SetSkill( SkillName.Macing, 110.0, 120.0 );
			SetSkill( SkillName.Wrestling, 110.0, 120.0 );
			SetSkill( SkillName.Tactics, 110.0, 120.0 );
			SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			SetSkill( SkillName.Healing, 110.0, 120.0 );
			SetSkill( SkillName.Anatomy, 110.0, 120.0 );


			SetSkill( SkillName.Magery, 110.0, 120.0 );
			SetSkill( SkillName.EvalInt, 110.0, 120.0 );
			SetSkill( SkillName.Meditation, 110.0, 120.0 );


			AddItem( Immovable( Rehued( new Cloak(), 1645 ) ) );


			AddItem( Immovable( Rehued( new PlateChest(), 1645 ) ) );
			AddItem( Immovable( Rehued( new PlateLegs(), 1109 ) ) );
			AddItem( Immovable( Rehued( new PlateArms(), 1109 ) ) );
			AddItem( Immovable( Rehued( new PlateGloves(), 1109 ) ) );
			AddItem( Immovable( Rehued( new PlateGorget(), 1109 ) ) );
			AddItem( Immovable( Rehued( new PlateHelm(), 1109 ) ) );


			AddItem( Newbied( new WarHammer() ) );


			AddItem( Immovable( Rehued( new VirtualMountItem( this ), 1109 ) ) );


			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}


		public FactionDragoon( Serial serial ) : base( serial )
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
// using System;// using Server;


namespace Server.Factions
{
	public class FactionExplosionTrap : BaseFactionTrap
	{
		public override int LabelNumber{ get{ return 1044599; } } // faction explosion trap


		public override int AttackMessage{ get{ return 1010543; } } // You are enveloped in an explosion of fire!
		public override int DisarmMessage{ get{ return 1010539; } } // You carefully remove the pressure trigger and disable the trap.
		public override int EffectSound{ get{ return 0x307; } }
		public override int MessageHue{ get{ return 0x78; } }


		public override AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.AnyFactionTown; } }


		public override void DoVisibleEffect()
		{
			Effects.SendLocationEffect( GetWorldLocation(), Map, 0x36BD, 15, 10 );
		}


		public override void DoAttackEffect( Mobile m )
		{
			m.Damage( Utility.Dice( 6, 10, 40 ), m );
		}


		[Constructable]
		public FactionExplosionTrap() : this( null )
		{
		}


		public FactionExplosionTrap( Faction f ) : this( f, null )
		{
		}


		public FactionExplosionTrap( Faction f, Mobile m ) : base( f, m, 0x11C1 )
		{
		}


		public FactionExplosionTrap( Serial serial ) : base( serial )
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


	public class FactionExplosionTrapDeed : BaseFactionTrapDeed
	{
		public override Type TrapType{ get{ return typeof( FactionExplosionTrap ); } }
		public override int LabelNumber{ get{ return 1044603; } } // faction explosion trap deed


		public FactionExplosionTrapDeed() : base( 0x36D2 )
		{
		}
		
		public FactionExplosionTrapDeed( Serial serial ) : base( serial )
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
// using System;// using Server;


namespace Server.Factions
{
	public class FactionGasTrap : BaseFactionTrap
	{
		public override int LabelNumber{ get{ return 1044598; } } // faction gas trap


		public override int AttackMessage{ get{ return 1010542; } } // A noxious green cloud of poison gas envelops you!
		public override int DisarmMessage{ get{ return 502376; } } // The poison leaks harmlessly away due to your deft touch.
		public override int EffectSound{ get{ return 0x230; } }
		public override int MessageHue{ get{ return 0x44; } }


		public override AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.FactionStronghold; } }


		public override void DoVisibleEffect()
		{
			Effects.SendLocationEffect( this.Location, this.Map, 0x3709, 28, 10, 0x1D3, 5 );
		}


		public override void DoAttackEffect( Mobile m )
		{
			m.ApplyPoison( m, Poison.Lethal );
		}


		[Constructable]
		public FactionGasTrap() : this( null )
		{
		}


		public FactionGasTrap( Faction f ) : this( f, null )
		{
		}


		public FactionGasTrap( Faction f, Mobile m ) : base( f, m, 0x113C )
		{
		}


		public FactionGasTrap( Serial serial ) : base( serial )
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


	public class FactionGasTrapDeed : BaseFactionTrapDeed
	{
		public override Type TrapType{ get{ return typeof( FactionGasTrap ); } }
		public override int LabelNumber{ get{ return 1044602; } } // faction gas trap deed


		public FactionGasTrapDeed() : base( 0x11AB )
		{
		}
		
		public FactionGasTrapDeed( Serial serial ) : base( serial )
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
// using System;// using Server;// using Server.Gumps;// using Server.Network;


namespace Server.Factions
{
	public abstract class FactionGump : Gump
	{
		public virtual int ButtonTypes{ get{ return 10; } }


		public int ToButtonID( int type, int index )
		{
			return 1 + (index * ButtonTypes) + type;
		}


		public bool FromButtonID( int buttonID, out int type, out int index )
		{
			int offset = buttonID - 1;


			if ( offset >= 0 )
			{
				type = offset % ButtonTypes;
				index = offset / ButtonTypes;
				return true;
			}
			else
			{
				type = index = 0;
				return false;
			}
		}


		public static bool Exists( Mobile mob )
		{
			return ( mob.FindGump( typeof( FactionGump ) ) != null );
		}


		public void AddHtmlText( int x, int y, int width, int height, TextDefinition text, bool back, bool scroll )
		{
			if ( text != null && text.Number > 0 )
				AddHtmlLocalized( x, y, width, height, text.Number, back, scroll );
			else if ( text != null && text.String != null )
				AddHtml( x, y, width, height, text.String, back, scroll );
		}


		public FactionGump( int x, int y ) : base( x, y )
		{
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Factions
{
	public class FactionHenchman : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Melee; } }


		[Constructable]
		public FactionHenchman() : base( "the henchman" )
		{
			GenerateBody( false, true );


			SetStr( 91, 115 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );


			SetDamage( 10, 14 );


			SetResistance( ResistanceType.Physical, 10, 30 );
			SetResistance( ResistanceType.Fire, 10, 30 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Energy, 10, 30 );
			SetResistance( ResistanceType.Poison, 10, 30 );


			VirtualArmor = 8;


			SetSkill( SkillName.Fencing, 80.0, 90.0 );
			SetSkill( SkillName.Wrestling, 80.0, 90.0 );
			SetSkill( SkillName.Tactics, 80.0, 90.0 );
			SetSkill( SkillName.MagicResist, 80.0, 90.0 );
			SetSkill( SkillName.Healing, 80.0, 90.0 );
			SetSkill( SkillName.Anatomy, 80.0, 90.0 );


			AddItem( new StuddedChest() );
			AddItem( new StuddedLegs() );
			AddItem( new StuddedArms() );
			AddItem( new StuddedGloves() );
			AddItem( new StuddedGorget() );
			AddItem( new Boots() );
			AddItem( Newbied( new Spear() ) );


			PackItem( new Bandage( Utility.RandomMinMax( 10, 20 ) ) );
			PackWeakPotions( 1, 4 );
		}


		public FactionHenchman( Serial serial ) : base( serial )
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
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.Network;// using System.Collections.Generic;


namespace Server.Factions
{
	public class FactionHorseVendor : BaseFactionVendor
	{
		public FactionHorseVendor( Town town, Faction faction ) : base( town, faction, "the Horse Breeder" )
		{
			SetSkill( SkillName.AnimalLore, 64.0, 100.0 );
			SetSkill( SkillName.AnimalTaming, 90.0, 100.0 );
			SetSkill( SkillName.Veterinary, 65.0, 88.0 );	
		}


		public override void InitSBInfo()
		{
		}


		public override VendorShoeType ShoeType
		{
			get{ return Female ? VendorShoeType.ThighBoots : VendorShoeType.Boots; }
		}


		public override int GetShoeHue()
		{
			return 0;
		}


		public override void InitOutfit()
		{
			base.InitOutfit();


			AddItem( Utility.RandomBool() ? (Item)new QuarterStaff() : (Item)new ShepherdsCrook() );
		}


		public FactionHorseVendor( Serial serial ) : base( serial )
		{
		}


		public override void VendorBuy( Mobile from )
		{
			if ( this.Faction == null || Faction.Find( from, true ) != this.Faction )
				PrivateOverheadMessage( MessageType.Regular, 0x3B2, 1042201, from.NetState ); // You are not in my faction, I cannot sell you a horse!
			else if ( FactionGump.Exists( from ) )
				from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
			else if ( from is PlayerMobile )
				from.SendGump( new HorseBreederGump( (PlayerMobile) from, this.Faction ) );
		}


		public override void VendorSell( Mobile from )
		{
		}


        public override bool OnBuyItems( Mobile buyer, List<BuyItemResponse> list )
		{
			return false;
		}


        public override bool OnSellItems( Mobile seller, List<SellItemResponse> list )
		{
			return false;
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
// using System;// using Server;// using Server.Items;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using Server.Engines.Craft;


namespace Server.Factions
{
	public class FactionImbueGump : FactionGump
	{
		private Item m_Item;
		private Mobile m_Mobile;
		private Faction m_Faction;
		private CraftSystem m_CraftSystem;
		private BaseTool m_Tool;
		private object m_Notice;
		private int m_Quality;


		private FactionItemDefinition m_Definition;


		public FactionImbueGump( int quality, Item item, Mobile from, CraftSystem craftSystem, BaseTool tool, object notice, int availableSilver, Faction faction, FactionItemDefinition def ) : base( 100, 200 )			
		{	
			m_Item = item;
			m_Mobile = from;
			m_Faction = faction;
			m_CraftSystem = craftSystem;
			m_Tool = tool;
			m_Notice = notice;
			m_Quality = quality;
			m_Definition = def;


			AddPage( 0 );


			AddBackground( 0, 0, 320, 270, 5054 );
			AddBackground( 10, 10, 300, 250, 3000 );


			AddHtmlLocalized( 20, 20, 210, 25, 1011569, false, false ); // Imbue with Faction properties?


			AddHtmlLocalized( 20, 60, 170, 25, 1018302, false, false ); // Item quality: 
			AddHtmlLocalized( 175, 60, 100, 25, 1018305 - m_Quality, false, false ); //	Exceptional, Average, Low


			AddHtmlLocalized( 20, 80, 170, 25, 1011572, false, false ); // Item Cost : 
			AddLabel( 175, 80, 0x34, def.SilverCost.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddHtmlLocalized( 20, 100, 170, 25, 1011573, false, false ); // Your Silver : 
			AddLabel( 175, 100, 0x34, availableSilver.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddRadio( 20, 140, 210, 211, true, 1 );
			AddLabel( 55, 140, m_Faction.Definition.HuePrimary - 1, "*****" );
			AddHtmlLocalized( 150, 140, 150, 25, 1011570, false, false ); // Primary Color


			AddRadio( 20, 160, 210, 211, false, 2 );
			AddLabel( 55, 160, m_Faction.Definition.HueSecondary - 1, "*****" );
			AddHtmlLocalized( 150, 160, 150, 25, 1011571, false, false ); // Secondary Color


			AddHtmlLocalized( 55, 200, 200, 25, 1011011, false, false ); // CONTINUE
			AddButton( 20, 200, 4005, 4007, 1, GumpButtonType.Reply, 0 );


			AddHtmlLocalized( 55, 230, 200, 25, 1011012, false, false ); // CANCEL
			AddButton( 20, 230, 4005, 4007, 0, GumpButtonType.Reply, 0 );
		}


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
			{
				Container pack = m_Mobile.Backpack;


				if ( pack != null && m_Item.IsChildOf( pack ) )
				{
					if ( pack.ConsumeTotal( typeof( Silver ), m_Definition.SilverCost ) )
					{
						int hue;


						if ( m_Item is SpellScroll )
							hue = 0;
						else if ( info.IsSwitched( 1 ) )
							hue = m_Faction.Definition.HuePrimary;
						else
							hue = m_Faction.Definition.HueSecondary;


						FactionItem.Imbue( m_Item, m_Faction, true, hue );
					}
					else
					{
						m_Mobile.SendLocalizedMessage( 1042204 ); // You do not have enough silver.
					}
				}
			}


			if ( m_Tool != null && !m_Tool.Deleted && m_Tool.UsesRemaining > 0 )
				m_Mobile.SendGump( new CraftGump( m_Mobile, m_CraftSystem, m_Tool, m_Notice ) );
			else if ( m_Notice is string )
				m_Mobile.SendMessage( (string) m_Notice );
			else if ( m_Notice is int && ((int)m_Notice) > 0 )
				m_Mobile.SendLocalizedMessage( (int) m_Notice );
		}
	}
}
// using System;


namespace Server.Factions
{
	public interface IFactionItem
	{
		FactionItem FactionItemState{ get; set; }
	}


	public class FactionItem
	{
		public static readonly TimeSpan ExpirationPeriod = TimeSpan.FromDays( 21.0 );


		private Item m_Item;
		private Faction m_Faction;
		private DateTime m_Expiration;


		public Item Item{ get{ return m_Item; } }
		public Faction Faction{ get{ return m_Faction; } }
		public DateTime Expiration{ get{ return m_Expiration; } }


		public bool HasExpired
		{
			get
			{
				if ( m_Item == null || m_Item.Deleted )
					return true;


				return ( m_Expiration != DateTime.MinValue && DateTime.Now >= m_Expiration );
			}
		}


		public void StartExpiration()
		{
			m_Expiration = DateTime.Now + ExpirationPeriod;
		}


		public void CheckAttach()
		{
			if ( !HasExpired )
				Attach();
			else
				Detach();
		}


		public void Attach()
		{
			if ( m_Item is IFactionItem )
				((IFactionItem)m_Item).FactionItemState = this;


			if ( m_Faction != null )
				m_Faction.State.FactionItems.Add( this );
		}


		public void Detach()
		{
			if ( m_Item is IFactionItem )
				((IFactionItem)m_Item).FactionItemState = null;


			if ( m_Faction != null && m_Faction.State.FactionItems.Contains( this ) )
				m_Faction.State.FactionItems.Remove( this );
		}


		public FactionItem( Item item, Faction faction )
		{
			m_Item = item;
			m_Faction = faction;
		}


		public FactionItem( GenericReader reader, Faction faction )
		{
			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 0:
				{
					m_Item = reader.ReadItem();
					m_Expiration = reader.ReadDateTime();
					break;
				}
			}


			m_Faction = faction;
		}


		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 );


			writer.Write( (Item) m_Item );
			writer.Write( (DateTime) m_Expiration );
		}


		public static int GetMaxWearables( Mobile mob )
		{
			PlayerState pl = PlayerState.Find( mob );


			if ( pl == null )
				return 0;


			if ( pl.Faction.IsCommander( mob ) )
				return 9;


			return pl.Rank.MaxWearables;
		}


		public static FactionItem Find( Item item )
		{
			if ( item is IFactionItem )
			{
				FactionItem state = ((IFactionItem)item).FactionItemState;


				if ( state != null && state.HasExpired )
				{
					state.Detach();
					state = null;
				}


				return state;
			}


			return null;
		}


		public static Item Imbue( Item item, Faction faction, bool expire, int hue )
		{
			if ( !(item is IFactionItem) )
				return item;


			FactionItem state = Find( item );


			if ( state == null )
			{
				state = new FactionItem( item, faction );
				state.Attach();
			}


			if ( expire )
				state.StartExpiration();


			item.Hue = hue;
			return item;
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;


namespace Server.Factions
{
	public class FactionItemDefinition
	{
		private int m_SilverCost;
		private Type m_VendorType;


		public int SilverCost{ get{ return m_SilverCost; } }
		public Type VendorType{ get{ return m_VendorType; } }


		public FactionItemDefinition( int silverCost, Type vendorType )
		{
			m_SilverCost = silverCost;
			m_VendorType = vendorType;
		}


		private static FactionItemDefinition m_MetalArmor	= new FactionItemDefinition( 1000, typeof( Blacksmith ) );
		private static FactionItemDefinition m_Weapon		= new FactionItemDefinition( 1000, typeof( Blacksmith ) );
		private static FactionItemDefinition m_RangedWeapon	= new FactionItemDefinition( 1000, typeof( Bowyer ) );
		private static FactionItemDefinition m_LeatherArmor	= new FactionItemDefinition(  750, typeof( Tailor ) );
		private static FactionItemDefinition m_Clothing		= new FactionItemDefinition(  200, typeof( Tailor ) );
		private static FactionItemDefinition m_Scroll		= new FactionItemDefinition(  500, typeof( Mage ) );


		public static FactionItemDefinition Identify( Item item )
		{
			if ( item is BaseArmor )
			{
				if ( CraftResources.GetType( ((BaseArmor)item).Resource ) == CraftResourceType.Leather )
					return m_LeatherArmor;


				return m_MetalArmor;
			}


			if ( item is BaseRanged )
				return m_RangedWeapon;
			else if ( item is BaseWeapon )
				return m_Weapon;
			else if ( item is BaseClothing )
				return m_Clothing;
			else if ( item is SpellScroll )
				return m_Scroll;


			return null;
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Factions
{
	public class FactionKnight : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Melee | GuardAI.Smart | GuardAI.Curse | GuardAI.Bless; } }


		[Constructable]
		public FactionKnight() : base( "the knight" )
		{
			GenerateBody( false, false );


			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );


			VirtualArmor = 24;


			SetSkill( SkillName.Swords, 100.0, 110.0 );
			SetSkill( SkillName.Wrestling, 100.0, 110.0 );
			SetSkill( SkillName.Tactics, 100.0, 110.0 );
			SetSkill( SkillName.MagicResist, 100.0, 110.0 );
			SetSkill( SkillName.Healing, 100.0, 110.0 );
			SetSkill( SkillName.Anatomy, 100.0, 110.0 );


			SetSkill( SkillName.Magery, 100.0, 110.0 );
			SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Meditation, 100.0, 110.0 );


			AddItem( Immovable( Rehued( new ChainChest(), 2125 ) ) );
			AddItem( Immovable( Rehued( new ChainLegs(), 2125 ) ) );
			AddItem( Immovable( Rehued( new ChainCoif(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateArms(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateGloves(), 2125 ) ) );


			AddItem( Immovable( Rehued( new BodySash(), 1254 ) ) );
			AddItem( Immovable( Rehued( new Kilt(), 1254 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1254 ) ) );


			AddItem( Newbied( new Bardiche() ) );


			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}


		public FactionKnight( Serial serial ) : base( serial )
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
// using System;// using Server;// using Server.Items;


namespace Server.Factions
{
	public class FactionMercenary : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Melee | GuardAI.Smart; } }


		[Constructable]
		public FactionMercenary() : base( "the mercenary" )
		{
			GenerateBody( false, true );


			SetStr( 116, 125 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );


			SetResistance( ResistanceType.Physical, 20, 40 );
			SetResistance( ResistanceType.Fire, 20, 40 );
			SetResistance( ResistanceType.Cold, 20, 40 );
			SetResistance( ResistanceType.Energy, 20, 40 );
			SetResistance( ResistanceType.Poison, 20, 40 );


			VirtualArmor = 16;


			SetSkill( SkillName.Fencing, 90.0, 100.0 );
			SetSkill( SkillName.Wrestling, 90.0, 100.0 );
			SetSkill( SkillName.Tactics, 90.0, 100.0 );
			SetSkill( SkillName.MagicResist, 90.0, 100.0 );
			SetSkill( SkillName.Healing, 90.0, 100.0 );
			SetSkill( SkillName.Anatomy, 90.0, 100.0 );


			AddItem( new ChainChest() );
			AddItem( new ChainLegs() );
			AddItem( new RingmailArms() );
			AddItem( new RingmailGloves() );
			AddItem( new ChainCoif() );
			AddItem( new Boots() );
			AddItem( Newbied( new ShortSpear() ) );


			PackItem( new Bandage( Utility.RandomMinMax( 20, 30 ) ) );
			PackStrongPotions( 3, 8 );
		}


		public FactionMercenary( Serial serial ) : base( serial )
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
// using System;// using Server;// using Server.Items;


namespace Server.Factions
{
	public class FactionNecromancer : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Smart | GuardAI.Bless | GuardAI.Curse; } }


		[Constructable]
		public FactionNecromancer() : base( "the necromancer" )
		{
			GenerateBody( false, false );
			Hue = 1;


			SetStr( 151, 175 );
			SetDex( 61, 85 );
			SetInt( 151, 175 );


			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Energy, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 60 );


			VirtualArmor = 32;


			SetSkill( SkillName.Macing, 110.0, 120.0 );
			SetSkill( SkillName.Wrestling, 110.0, 120.0 );
			SetSkill( SkillName.Tactics, 110.0, 120.0 );
			SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			SetSkill( SkillName.Healing, 110.0, 120.0 );
			SetSkill( SkillName.Anatomy, 110.0, 120.0 );


			SetSkill( SkillName.Magery, 110.0, 120.0 );
			SetSkill( SkillName.EvalInt, 110.0, 120.0 );
			SetSkill( SkillName.Meditation, 110.0, 120.0 );


			Item shroud = new Item( 0x204E );
			shroud.Layer = Layer.OuterTorso;


			AddItem( Immovable( Rehued( shroud, 1109 ) ) );
			AddItem( Newbied( Rehued( new GnarledStaff(), 2211 ) ) );


			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}


		public FactionNecromancer( Serial serial ) : base( serial )
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
// using System;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;


namespace Server.Factions
{
	public class FactionOreVendor : BaseFactionVendor
	{
		public FactionOreVendor( Town town, Faction faction ) : base( town, faction, "the Ore Man" )
		{
			// NOTE: Skills verified
			SetSkill( SkillName.Carpentry, 85.0, 100.0 );
			SetSkill( SkillName.Lumberjacking, 60.0, 83.0 );
		}


		public override void InitSBInfo()
		{
			SBInfos.Add( new SBFactionOre() );
		}


		public override void InitOutfit()
		{
			base.InitOutfit();


			AddItem( new HalfApron() );
		}


		public FactionOreVendor( Serial serial ) : base( serial )
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


	public class SBFactionOre : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();


		public SBFactionOre()
		{
		}


		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }


		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				for ( int i = 0; i < 5; ++i )
					Add( new GenericBuyInfo( typeof( IronOre ), 16, 20, 0x19B8, 0 ) );
			}
		}


		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;


namespace Server.Factions
{
	public class FactionPaladin : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Melee | GuardAI.Smart | GuardAI.Curse | GuardAI.Bless; } }


		[Constructable]
		public FactionPaladin() : base( "the paladin" )
		{
			GenerateBody( false, false );


			SetStr( 151, 175 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );


			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Energy, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 60 );


			VirtualArmor = 32;


			SetSkill( SkillName.Swords, 110.0, 120.0 );
			SetSkill( SkillName.Wrestling, 110.0, 120.0 );
			SetSkill( SkillName.Tactics, 110.0, 120.0 );
			SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			SetSkill( SkillName.Healing, 110.0, 120.0 );
			SetSkill( SkillName.Anatomy, 110.0, 120.0 );


			SetSkill( SkillName.Magery, 110.0, 120.0 );
			SetSkill( SkillName.EvalInt, 110.0, 120.0 );
			SetSkill( SkillName.Meditation, 110.0, 120.0 );


			AddItem( Immovable( Rehued( new PlateChest(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateLegs(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateHelm(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateGorget(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateArms(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateGloves(), 2125 ) ) );


			AddItem( Immovable( Rehued( new BodySash(), 1254 ) ) );
			AddItem( Immovable( Rehued( new Cloak(), 1254 ) ) );


			AddItem( Newbied( new Halberd() ) );


			AddItem( Immovable( Rehued( new VirtualMountItem( this ), 1254 ) ) );


			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}


		public FactionPaladin( Serial serial ) : base( serial )
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
// using System;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;


namespace Server.Factions
{
	public class FactionReagentVendor : BaseFactionVendor
	{
		public FactionReagentVendor( Town town, Faction faction ) : base( town, faction, "the Reagent Man" )
		{
			SetSkill( SkillName.EvalInt, 65.0, 88.0 );
			SetSkill( SkillName.Inscribe, 60.0, 83.0 );
			SetSkill( SkillName.Magery, 64.0, 100.0 );
			SetSkill( SkillName.Meditation, 60.0, 83.0 );
			SetSkill( SkillName.MagicResist, 65.0, 88.0 );
			SetSkill( SkillName.Wrestling, 36.0, 68.0 );
		}


		public override void InitSBInfo()
		{
			SBInfos.Add( new SBFactionReagent() );
		}


		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals; }
		}


		public override void InitOutfit()
		{
			base.InitOutfit();


			AddItem( new Robe( Utility.RandomBlueHue() ) );
			AddItem( new GnarledStaff() );
		}


		public FactionReagentVendor( Serial serial ) : base( serial )
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


	public class SBFactionReagent : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();


		public SBFactionReagent()
		{
		}


		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }


		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				for ( int i = 0; i < 2; ++i )
				{
					Add( new GenericBuyInfo( typeof( BlackPearl ), 5, 20, 0xF7A, 0 ) );
					Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 20, 0xF7B, 0 ) );
					Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, 20, 0xF86, 0 ) );
					Add( new GenericBuyInfo( typeof( Garlic ), 3, 20, 0xF84, 0 ) );
					Add( new GenericBuyInfo( typeof( Ginseng ), 3, 20, 0xF85, 0 ) );
					Add( new GenericBuyInfo( typeof( Nightshade ), 3, 20, 0xF88, 0 ) );
					Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, 20, 0xF8D, 0 ) );
					Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, 20, 0xF8C, 0 ) );
				}
			}
		}


		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
// using System;// using Server;


namespace Server.Factions
{
	public class FactionSawTrap : BaseFactionTrap
	{
		public override int LabelNumber{ get{ return 1041047; } } // faction saw trap


		public override int AttackMessage{ get{ return 1010544; } } // The blade cuts deep into your skin!
		public override int DisarmMessage{ get{ return 1010540; } } // You carefully dismantle the saw mechanism and disable the trap.
		public override int EffectSound{ get{ return 0x218; } }
		public override int MessageHue{ get{ return 0x5A; } }


		public override AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.ControlledFactionTown; } }


		public override void DoVisibleEffect()
		{
			Effects.SendLocationEffect( this.Location, this.Map, 0x11AD, 25, 10 );
		}


		public override void DoAttackEffect( Mobile m )
		{
			m.Damage( Utility.Dice( 6, 10, 40 ), m );
		}


		[Constructable]
		public FactionSawTrap() : this( null )
		{
		}


		public FactionSawTrap( Serial serial ) : base( serial )
		{
		}


		public FactionSawTrap( Faction f ) : this( f, null )
		{
		}


		public FactionSawTrap( Faction f, Mobile m ) : base( f, m, 0x11AC )
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


	public class FactionSawTrapDeed : BaseFactionTrapDeed
	{
		public override Type TrapType{ get{ return typeof( FactionSawTrap ); } }
		public override int LabelNumber{ get{ return 1044604; } } // faction saw trap deed


		public FactionSawTrapDeed() : base( 0x1107 )
		{
		}
		
		public FactionSawTrapDeed( Serial serial ) : base( serial )
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
// using System;// using Server;// using Server.Items;


namespace Server.Factions
{
	public class FactionSorceress : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Bless | GuardAI.Curse; } }


		[Constructable]
		public FactionSorceress() : base( "the sorceress" )
		{
			GenerateBody( true, false );


			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 126, 150 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );


			VirtualArmor = 24;


			SetSkill( SkillName.Macing, 100.0, 110.0 );
			SetSkill( SkillName.Wrestling, 100.0, 110.0 );
			SetSkill( SkillName.Tactics, 100.0, 110.0 );
			SetSkill( SkillName.MagicResist, 100.0, 110.0 );
			SetSkill( SkillName.Healing, 100.0, 110.0 );
			SetSkill( SkillName.Anatomy, 100.0, 110.0 );


			SetSkill( SkillName.Magery, 100.0, 110.0 );
			SetSkill( SkillName.EvalInt, 100.0, 110.0 );
			SetSkill( SkillName.Meditation, 100.0, 110.0 );


			AddItem( Immovable( Rehued( new WizardsHat(), 1325 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1325 ) ) );
			AddItem( Immovable( Rehued( new LeatherGorget(), 1325 ) ) );
			AddItem( Immovable( Rehued( new LeatherGloves(), 1325 ) ) );
			AddItem( Immovable( Rehued( new LeatherLegs(), 1325 ) ) );
			AddItem( Immovable( Rehued( new Skirt(), 1325 ) ) );
			AddItem( Immovable( Rehued( new FemaleLeatherChest(), 1325 ) ) );
			AddItem( Newbied( Rehued( new QuarterStaff(), 1310 ) ) );


			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}


		public FactionSorceress( Serial serial ) : base( serial )
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
// using System;// using Server;


namespace Server.Factions
{
	public class FactionSpikeTrap : BaseFactionTrap
	{
		public override int LabelNumber{ get{ return 1044601; } } // faction spike trap


		public override int AttackMessage{ get{ return 1010545; } } // Large spikes in the ground spring up piercing your skin!
		public override int DisarmMessage{ get{ return 1010541; } } // You carefully dismantle the trigger on the spikes and disable the trap.
		public override int EffectSound{ get{ return 0x22E; } }
		public override int MessageHue{ get{ return 0x5A; } }


		public override AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.ControlledFactionTown; } }


		public override void DoVisibleEffect()
		{
			Effects.SendLocationEffect( this.Location, this.Map, 0x11A4, 12, 6 );
		}


		public override void DoAttackEffect( Mobile m )
		{
			m.Damage( Utility.Dice( 6, 10, 40 ), m );
		}


		[Constructable]
		public FactionSpikeTrap() : this( null )
		{
		}


		public FactionSpikeTrap( Faction f ) : this( f, null )
		{
		}


		public FactionSpikeTrap( Faction f, Mobile m ) : base( f, m, 0x11A0 )
		{
		}


		public FactionSpikeTrap( Serial serial ) : base( serial )
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


	public class FactionSpikeTrapDeed : BaseFactionTrapDeed
	{
		public override Type TrapType{ get{ return typeof( FactionSpikeTrap ); } }
		public override int LabelNumber{ get{ return 1044605; } } // faction spike trap deed


		public FactionSpikeTrapDeed() : base( 0x11A5 )
		{
		}
		
		public FactionSpikeTrapDeed( Serial serial ) : base( serial )
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
// using System;// using System.Collections.Generic;


namespace Server.Factions
{
	public class FactionState
	{
		private Faction m_Faction;
		private Mobile m_Commander;
		private int m_Tithe;
		private int m_Silver;
		private List<PlayerState> m_Members;
		private Election m_Election;
		private List<FactionItem> m_FactionItems;
		private List<BaseFactionTrap> m_FactionTraps;
		private DateTime m_LastAtrophy;


		private const int BroadcastsPerPeriod = 2;
		private static readonly TimeSpan BroadcastPeriod = TimeSpan.FromHours( 1.0 );


		private DateTime[] m_LastBroadcasts = new DateTime[BroadcastsPerPeriod];


		public DateTime LastAtrophy{ get{ return m_LastAtrophy; } set{ m_LastAtrophy = value; } }


		public bool FactionMessageReady
		{
			get
			{
				for ( int i = 0; i < m_LastBroadcasts.Length; ++i )
				{
					if ( DateTime.Now >= (m_LastBroadcasts[i] + BroadcastPeriod) )
						return true;
				}


				return false;
			}
		}


		public bool IsAtrophyReady{ get{ return DateTime.Now >= (m_LastAtrophy + TimeSpan.FromHours( 47.0 )); } }


		public int CheckAtrophy()
		{
			if ( DateTime.Now < (m_LastAtrophy + TimeSpan.FromHours( 47.0 )) )
				return 0;


			int distrib = 0;
			m_LastAtrophy = DateTime.Now;


			List<PlayerState> members = new List<PlayerState>( m_Members );


			for ( int i = 0; i < members.Count; ++i )
			{
				PlayerState ps = members[i];
					
				if ( ps.IsActive )
				{
					ps.IsActive = false;
					continue;
				}
				else if ( ps.KillPoints > 0 )
				{
					int atrophy = ( ps.KillPoints + 9 ) / 10;
					ps.KillPoints -= atrophy;
					distrib += atrophy;
				}
			}


			return distrib;
		}


		public void RegisterBroadcast()
		{
			for ( int i = 0; i < m_LastBroadcasts.Length; ++i )
			{
				if ( DateTime.Now >= (m_LastBroadcasts[i] + BroadcastPeriod) )
				{
					m_LastBroadcasts[i] = DateTime.Now;
					break;
				}
			}
		}


		public List<FactionItem> FactionItems
		{
			get{ return m_FactionItems; }
			set{ m_FactionItems = value; }
		}


		public List<BaseFactionTrap> Traps
		{
			get{ return m_FactionTraps; }
			set{ m_FactionTraps = value; }
		}


		public Election Election
		{
			get{ return m_Election; }
			set{ m_Election = value; }
		}


		public Mobile Commander
		{
			get{ return m_Commander; }
			set
			{
				if ( m_Commander != null )
					m_Commander.InvalidateProperties();


				m_Commander = value;


				if ( m_Commander != null )
				{
					m_Commander.SendLocalizedMessage( 1042227 ); // You have been elected Commander of your faction


					m_Commander.InvalidateProperties();


					PlayerState pl = PlayerState.Find( m_Commander );


					if ( pl != null && pl.Finance != null )
						pl.Finance.Finance = null;


					if ( pl != null && pl.Sheriff != null )
						pl.Sheriff.Sheriff = null;
				}
			}
		}


		public int Tithe
		{
			get{ return m_Tithe; }
			set{ m_Tithe = value; }
		}


		public int Silver
		{
			get{ return m_Silver; }
			set{ m_Silver = value; }
		}


		public List<PlayerState> Members
		{
			get{ return m_Members; }
			set{ m_Members = value; }
		}


		public FactionState( Faction faction )
		{
			m_Faction = faction;
			m_Tithe = 50;
			m_Members = new List<PlayerState>();
			m_Election = new Election( faction );
			m_FactionItems = new List<FactionItem>();
			m_FactionTraps = new List<BaseFactionTrap>();
		}


		public FactionState( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 5:
				{
					m_LastAtrophy = reader.ReadDateTime();
					goto case 4;
				}
				case 4:
				{
					int count = reader.ReadEncodedInt();


					for ( int i = 0; i < count; ++i )
					{
						DateTime time = reader.ReadDateTime();


						if ( i < m_LastBroadcasts.Length )
							m_LastBroadcasts[i] = time;
					}


					goto case 3;
				}
				case 3:
				case 2:
				case 1:
				{
					m_Election = new Election( reader );


					goto case 0;
				}
				case 0:
				{
					m_Faction = Faction.ReadReference( reader );


					m_Commander = reader.ReadMobile();


					if ( version < 5 )
						m_LastAtrophy = DateTime.Now;


					if ( version < 4 )
					{
						DateTime time = reader.ReadDateTime();


						if ( m_LastBroadcasts.Length > 0 )
							m_LastBroadcasts[0] = time;
					}


					m_Tithe = reader.ReadEncodedInt();
					m_Silver = reader.ReadEncodedInt();


					int memberCount = reader.ReadEncodedInt();


					m_Members = new List<PlayerState>();


					for ( int i = 0; i < memberCount; ++i )
					{
						PlayerState pl = new PlayerState( reader, m_Faction, m_Members );


						if ( pl.Mobile != null )
							m_Members.Add( pl );
					}


					m_Faction.State = this;
					
					m_Faction.ZeroRankOffset = m_Members.Count;
					m_Members.Sort();


					for ( int i = m_Members.Count - 1; i >= 0; i-- ) {
						PlayerState player = m_Members[i];


						if ( player.KillPoints <= 0 )
							m_Faction.ZeroRankOffset = i;
						else
							player.RankIndex = i;
					}


					m_FactionItems = new List<FactionItem>();


					if ( version >= 2 )
					{
						int factionItemCount = reader.ReadEncodedInt();


						for ( int i = 0; i < factionItemCount; ++i )
						{
							FactionItem factionItem = new FactionItem( reader, m_Faction );


							Timer.DelayCall( TimeSpan.Zero, new TimerCallback( factionItem.CheckAttach ) ); // sandbox attachment
						}
					}


					m_FactionTraps = new List<BaseFactionTrap>();


					if ( version >= 3 )
					{
						int factionTrapCount = reader.ReadEncodedInt();


						for ( int i = 0; i < factionTrapCount; ++i )
						{
							BaseFactionTrap trap = reader.ReadItem() as BaseFactionTrap;


							if ( trap != null && !trap.CheckDecay() )
								m_FactionTraps.Add( trap );
						}
					}


					break;
				}
			}


			if ( version < 1 )
				m_Election = new Election( m_Faction );
		}


		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 5 ); // version


			writer.Write( m_LastAtrophy );


			writer.WriteEncodedInt( (int) m_LastBroadcasts.Length );


			for ( int i = 0; i < m_LastBroadcasts.Length; ++i )
				writer.Write( (DateTime) m_LastBroadcasts[i] );


			m_Election.Serialize( writer );


			Faction.WriteReference( writer, m_Faction );


			writer.Write( (Mobile) m_Commander );


			writer.WriteEncodedInt( (int) m_Tithe );
			writer.WriteEncodedInt( (int) m_Silver );


			writer.WriteEncodedInt( (int) m_Members.Count );


			for ( int i = 0; i < m_Members.Count; ++i )
			{
				PlayerState pl = (PlayerState) m_Members[i];


				pl.Serialize( writer );
			}


			writer.WriteEncodedInt( (int) m_FactionItems.Count );


			for ( int i = 0; i < m_FactionItems.Count; ++i )
				m_FactionItems[i].Serialize( writer );


			writer.WriteEncodedInt( (int) m_FactionTraps.Count );


			for ( int i = 0; i < m_FactionTraps.Count; ++i )
				writer.Write( (Item) m_FactionTraps[i] );
		}
	}
}
// using System;// using Server;// using Server.Mobiles;// using Server.Network;


namespace Server.Factions
{
	public class FactionStone : BaseSystemController
	{
		private Faction m_Faction;


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set
			{
				m_Faction = value;


				AssignName( m_Faction == null ? null : m_Faction.Definition.FactionStoneName );
			}
		}


		public override string DefaultName { get { return "faction stone"; } }


		[Constructable]
		public FactionStone() : this( null )
		{
		}


		[Constructable]
		public FactionStone( Faction faction ) : base( 0xEDC )
		{
			Movable = false;
			Faction = faction;
		}


		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Faction == null )
				return;


			if ( !from.InRange( GetWorldLocation(), 2 ) )
			{
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			}
			else if ( FactionGump.Exists( from ) )
			{
				from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
			}
			else if ( from is PlayerMobile )
			{
				Faction existingFaction = Faction.Find( from );


				if ( existingFaction == m_Faction || from.AccessLevel >= AccessLevel.GameMaster )
				{
					PlayerState pl = PlayerState.Find( from );


					if ( pl != null && pl.IsLeaving )
						from.SendLocalizedMessage( 1005051 ); // You cannot use the faction stone until you have finished quitting your current faction
					else
						from.SendGump( new FactionStoneGump( (PlayerMobile) from, m_Faction ) );
				}
				else if ( existingFaction != null )
				{
					// TODO: Validate
					from.SendLocalizedMessage( 1005053 ); // This is not your faction stone!
				}
				else
				{
					from.SendGump( new JoinStoneGump( (PlayerMobile) from, m_Faction ) );
				}
			}
		}


		public FactionStone( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			Faction.WriteReference( writer, m_Faction );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			switch ( version )
			{
				case 0:
				{
					Faction = Faction.ReadReference( reader );
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using System.Collections.Generic;


namespace Server.Factions
{
	public class FactionStoneGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;


		public override int ButtonTypes{ get{ return 4; } }


		public FactionStoneGump( PlayerMobile from, Faction faction ) : base( 20, 30 )
		{
			m_From = from;
			m_Faction = faction;


			AddPage( 0 );


			AddBackground( 0, 0, 550, 440, 5054 );
			AddBackground( 10, 10, 530, 420, 3000 );


			#region General
			AddPage( 1 );


			AddHtmlText( 20, 30, 510, 20, faction.Definition.Header, false, false );


			AddHtmlLocalized( 20, 60, 100, 20, 1011429, false, false ); // Led By : 
			AddHtml( 125, 60, 200, 20, faction.Commander != null ? faction.Commander.Name : "Nobody", false, false );


			AddHtmlLocalized( 20, 80, 100, 20, 1011457, false, false ); // Tithe rate : 
			if ( faction.Tithe >= 0 && faction.Tithe <= 100 && (faction.Tithe % 10) == 0 )
				AddHtmlLocalized( 125, 80, 350, 20, 1011480 + (faction.Tithe / 10), false, false );
			else
				AddHtml( 125, 80, 350, 20, faction.Tithe + "%", false, false );


			AddHtmlLocalized( 20, 100, 100, 20, 1011458, false, false ); // Traps placed : 
			AddHtml( 125, 100, 50, 20, faction.Traps.Count.ToString(), false, false );


			AddHtmlLocalized( 55, 225, 200, 20, 1011428, false, false ); // VOTE FOR LEADERSHIP
			AddButton( 20, 225, 4005, 4007, ToButtonID( 0, 0 ), GumpButtonType.Reply, 0 );


			AddHtmlLocalized( 55, 150, 100, 20, 1011430, false, false ); // CITY STATUS
			AddButton( 20, 150, 4005, 4007, 0, GumpButtonType.Page, 2 );


			AddHtmlLocalized( 55, 175, 100, 20, 1011444, false, false ); // STATISTICS
			AddButton( 20, 175, 4005, 4007, 0, GumpButtonType.Page, 4 );


			bool isMerchantQualified = MerchantTitles.HasMerchantQualifications( from );


			PlayerState pl = PlayerState.Find( from );


			if ( pl != null && pl.MerchantTitle != MerchantTitle.None )
			{
				AddHtmlLocalized( 55, 200, 250, 20, 1011460, false, false ); // UNDECLARE FACTION MERCHANT
				AddButton( 20, 200, 4005, 4007, ToButtonID( 1, 0 ), GumpButtonType.Reply, 0 );
			}
			else if ( isMerchantQualified )
			{
				AddHtmlLocalized( 55, 200, 250, 20, 1011459, false, false ); // DECLARE FACTION MERCHANT
				AddButton( 20, 200, 4005, 4007, 0, GumpButtonType.Page, 5 );
			}
			else
			{
				AddHtmlLocalized( 55, 200, 250, 20, 1011467, false, false ); // MERCHANT OPTIONS
				AddImage( 20, 200, 4020 );
			}


			AddHtmlLocalized( 55, 250, 300, 20, 1011461, false, false ); // COMMANDER OPTIONS
			if ( faction.IsCommander( from ) )
				AddButton( 20, 250, 4005, 4007, 0, GumpButtonType.Page, 6 );
			else
				AddImage( 20, 250, 4020 );


			AddHtmlLocalized( 55, 275, 300, 20, 1011426, false, false ); // LEAVE THIS FACTION
			AddButton( 20, 275, 4005, 4007, ToButtonID( 0, 1 ), GumpButtonType.Reply, 0 );


			AddHtmlLocalized( 55, 300, 200, 20, 1011441, false, false ); // EXIT
			AddButton( 20, 300, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			#endregion


			#region City Status
			AddPage( 2 );


			AddHtmlLocalized( 20, 30, 250, 20, 1011430, false, false ); // CITY STATUS


			List<Town> towns = Town.Towns;


			for ( int i = 0; i < towns.Count; ++i )
			{
				Town town = towns[i];


				AddHtmlText( 40, 55 + (i * 30), 150, 20, town.Definition.TownName, false, false );


				if ( town.Owner == null )
				{
					AddHtmlLocalized( 200, 55 + (i * 30), 150, 20, 1011462, false, false ); // : Neutral
				}
				else
				{
					AddHtmlLocalized( 200, 55 + (i * 30), 150, 20, town.Owner.Definition.OwnerLabel, false, false );


					BaseMonolith monolith = town.Monolith;


					AddImage( 20, 60 + (i * 30), ( monolith != null && monolith.Sigil != null && monolith.Sigil.IsPurifying ) ? 0x938 : 0x939 );
				}
			}


			AddImage( 20, 300, 2361 );
			AddHtmlLocalized( 45, 295, 300, 20, 1011491, false, false ); // sigil may be recaptured


			AddImage( 20, 320, 2360 );
			AddHtmlLocalized( 45, 315, 300, 20, 1011492, false, false ); // sigil may not be recaptured


			AddHtmlLocalized( 55, 350, 100, 20, 1011447, false, false ); // BACK
			AddButton( 20, 350, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion


			#region Statistics
			AddPage( 4 );


			AddHtmlLocalized( 20, 30, 150, 20, 1011444, false, false ); // STATISTICS


			AddHtmlLocalized( 20, 100, 100, 20, 1011445, false, false ); // Name : 
			AddHtml( 120, 100, 150, 20, from.Name, false, false );


			AddHtmlLocalized( 20, 130, 100, 20, 1018064, false, false ); // score : 
			AddHtml( 120, 130, 100, 20, (pl != null ? pl.KillPoints : 0).ToString(), false, false );


			AddHtmlLocalized( 20, 160, 100, 20, 1011446, false, false ); // Rank : 
			AddHtml( 120, 160, 100, 20, (pl != null ? pl.Rank.Rank : 0).ToString(), false, false );


			AddHtmlLocalized( 55, 250, 100, 20, 1011447, false, false ); // BACK
			AddButton( 20, 250, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion


			#region Merchant Options
			if ( ( pl == null || pl.MerchantTitle == MerchantTitle.None ) && isMerchantQualified )
			{
				AddPage( 5 );


				AddHtmlLocalized( 20, 30, 250, 20, 1011467, false, false ); // MERCHANT OPTIONS


				AddHtmlLocalized( 20, 80, 300, 20, 1011473, false, false ); // Select the title you wish to display


				MerchantTitleInfo[] infos = MerchantTitles.Info;


				for ( int i = 0; i < infos.Length; ++i )
				{
					MerchantTitleInfo info = infos[i];


					if ( MerchantTitles.IsQualified( from, info ) )
						AddButton( 20, 100 + (i * 30), 4005, 4007, ToButtonID( 1, i + 1 ), GumpButtonType.Reply, 0 );
					else
						AddImage( 20, 100 + (i * 30), 4020 );


					AddHtmlText( 55, 100 + (i * 30), 200, 20, info.Label, false, false );
				}


				AddHtmlLocalized( 55, 340, 100, 20, 1011447, false, false ); // BACK
				AddButton( 20, 340, 4005, 4007, 0, GumpButtonType.Page, 1 );
			}
			#endregion


			#region Commander Options
			if ( faction.IsCommander( from ) )
			{
				#region General
				AddPage( 6 );


				AddHtmlLocalized( 20, 30, 200, 20, 1011461, false, false ); // COMMANDER OPTIONS


				AddHtmlLocalized( 20, 70, 120, 20, 1011457, false, false ); // Tithe rate : 
				if ( faction.Tithe >= 0 && faction.Tithe <= 100 && (faction.Tithe % 10) == 0 )
					AddHtmlLocalized( 140, 70, 250, 20, 1011480 + (faction.Tithe / 10), false, false );
				else
					AddHtml( 140, 70, 250, 20, faction.Tithe + "%", false, false );


				AddHtmlLocalized( 20, 100, 120, 20, 1011474, false, false ); // Silver available : 
				AddHtml( 140, 100, 50, 20, faction.Silver.ToString( "N0" ), false, false ); // NOTE: Added 'N0' formatting


				AddHtmlLocalized( 55, 130, 200, 20, 1011478, false, false ); // CHANGE TITHE RATE
				AddButton( 20, 130, 4005, 4007, 0, GumpButtonType.Page, 8 );


				AddHtmlLocalized( 55, 160, 200, 20, 1018301, false, false ); // TRANSFER SILVER
				if ( faction.Silver >= 10000 )
					AddButton( 20, 160, 4005, 4007, 0, GumpButtonType.Page, 7 );
				else
					AddImage( 20, 160, 4020 );


				AddHtmlLocalized( 55, 310, 100, 20, 1011447, false, false ); // BACK
				AddButton( 20, 310, 4005, 4007, 0, GumpButtonType.Page, 1 );
				#endregion


				#region Town Finance
				if ( faction.Silver >= 10000 )
				{
					AddPage( 7 );


					AddHtmlLocalized( 20, 30, 250, 20, 1011476, false, false ); // TOWN FINANCE


					AddHtmlLocalized( 20, 50, 400, 20, 1011477, false, false ); // Select a town to transfer 10000 silver to


					for ( int i = 0; i < towns.Count; ++i )
					{
						Town town = towns[i];


						AddHtmlText( 55, 75 + (i * 30), 200, 20, town.Definition.TownName, false, false );


						if ( town.Owner == faction )
							AddButton( 20, 75 + (i * 30), 4005, 4007, ToButtonID( 2, i ), GumpButtonType.Reply, 0 );
						else
							AddImage( 20, 75 + (i * 30), 4020 );
					}


					AddHtmlLocalized( 55, 310, 100, 20, 1011447, false, false ); // BACK
					AddButton( 20, 310, 4005, 4007, 0, GumpButtonType.Page, 1 );
				}
				#endregion


				#region Change Tithe Rate
				AddPage( 8 );


				AddHtmlLocalized( 20, 30, 400, 20, 1011479, false, false ); // Select the % for the new tithe rate


				int y = 55;


				for ( int i = 0; i <= 10; ++i )
				{
					if ( i == 5 )
						y += 5;


					AddHtmlLocalized( 55, y, 300, 20, 1011480 + i, false, false );
					AddButton( 20, y, 4005, 4007, ToButtonID( 3, i ), GumpButtonType.Reply, 0 );


					y += 20;


					if ( i == 5 )
						y += 5;
				}


				AddHtmlLocalized( 55, 310, 300, 20, 1011447, false, false ); // BACK
				AddButton( 20, 310, 4005, 4007, 0, GumpButtonType.Page, 1 );
				#endregion
			}
			#endregion
		}


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			int type, index;


			if ( !FromButtonID( info.ButtonID, out type, out index ) )
				return;


			switch ( type )
			{
				case 0: // general
				{
					switch ( index )
					{
						case 0: // vote
						{
							m_From.SendGump( new ElectionGump( m_From, m_Faction.Election ) );
							break;
						}
						case 1: // leave
						{
							m_From.SendGump( new LeaveFactionGump( m_From, m_Faction ) );
							break;
						}
					}


					break;
				}
				case 1: // merchant title
				{
					if ( index >= 0 && index <= MerchantTitles.Info.Length )
					{
						PlayerState pl = PlayerState.Find( m_From );


						MerchantTitle newTitle = (MerchantTitle)index;
						MerchantTitleInfo mti = MerchantTitles.GetInfo( newTitle );


						if ( mti == null )
						{
							m_From.SendLocalizedMessage( 1010120 ); // Your merchant title has been removed


							if ( pl != null )
								pl.MerchantTitle = newTitle;
						}
						else if ( MerchantTitles.IsQualified( m_From, mti ) )
						{
							m_From.SendLocalizedMessage( mti.Assigned );


							if ( pl != null )
								pl.MerchantTitle = newTitle;
						}
					}


					break;
				}
				case 2: // transfer silver
				{
					if ( !m_Faction.IsCommander( m_From ) )
						return;


					List<Town> towns = Town.Towns;


					if ( index >= 0 && index < towns.Count )
					{
						Town town = towns[index];


						if ( town.Owner == m_Faction )
						{
							if ( m_Faction.Silver >= 10000 )
							{
								m_Faction.Silver -= 10000;
								town.Silver += 10000;


								// 10k in silver has been received by:
								m_From.SendLocalizedMessage( 1042726, true, " " + town.Definition.FriendlyName );
							}
						}
					}


					break;
				}
				case 3: // change tithe
				{
					if ( !m_Faction.IsCommander( m_From ) )
						return;


					if ( index >= 0 && index <= 10 )
						m_Faction.Tithe = index*10;


					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Factions
{
	public class FactionTrapRemovalKit : Item
	{
		private int m_Charges;


		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; }
		}


		public override int LabelNumber{ get{ return 1041508; } } // a faction trap removal kit


		[Constructable]
		public FactionTrapRemovalKit() : base( 7867 )
		{
			LootType = LootType.Blessed;
			m_Charges = 25;
		}


		public void ConsumeCharge( Mobile consumer )
		{
			--m_Charges;


			if ( m_Charges <= 0 )
			{
				Delete();


				if ( consumer != null )
					consumer.SendLocalizedMessage( 1042531 ); // You have used all of the parts in your trap removal kit.
			}
		}


		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );


			// NOTE: OSI does not list uses remaining; intentional difference
			list.Add( 1060584, m_Charges.ToString() ); // uses remaining: ~1_val~
		}


		public FactionTrapRemovalKit( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 1 ); // version


			writer.WriteEncodedInt( (int) m_Charges );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			switch ( version )
			{
				case 1:
				{
					m_Charges = reader.ReadEncodedInt();
					break;
				}
				case 0:
				{
					m_Charges = 25;
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Mobiles;


namespace Server.Factions
{
	[CorpseName( "a war horse corpse" )]
	public class FactionWarHorse : BaseMount
	{
		private Faction m_Faction;


		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set
			{
				m_Faction = value;


				Body = ( m_Faction == null ? 0xE2 : m_Faction.Definition.WarHorseBody );
				ItemID = ( m_Faction == null ? 0x3EA0 : m_Faction.Definition.WarHorseItem );
			}
		}


		public const int SilverPrice = 500;
		public const int GoldPrice = 3000;


		[Constructable]
		public FactionWarHorse() : this( null )
		{
		}


		public FactionWarHorse( Faction faction ) : base( "a war horse", 0xE2, 0x3EA0, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0xA8;


			SetStr( 400 );
			SetDex( 125 );
			SetInt( 51, 55 );


			SetHits( 240 );
			SetMana( 0 );


			SetDamage( 5, 8 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );


			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 29.3, 44.0 );
			SetSkill( SkillName.Wrestling, 29.3, 44.0 );


			Fame = 300;
			Karma = 300;


			Tamable = true;
			ControlSlots = 1;


			Faction = faction;
		}


		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }


		public FactionWarHorse( Serial serial ) : base( serial )
		{
		}


		public override void OnDoubleClick( Mobile from )
		{
			PlayerState pl = PlayerState.Find( from );


			if ( pl == null )
				from.SendLocalizedMessage( 1010366 ); // You cannot mount a faction war horse!
			else if ( pl.Faction != this.Faction )
				from.SendLocalizedMessage( 1010367 ); // You cannot ride an opposing faction's war horse!
			else if ( pl.Rank.Rank < 2 )
				from.SendLocalizedMessage( 1010368 ); // You must achieve a faction rank of at least two before riding a war horse!
			else
				base.OnDoubleClick( from );
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			Faction.WriteReference( writer, m_Faction );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			switch ( version )
			{
				case 0:
				{
					Faction = Faction.ReadReference( reader );
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Factions
{
	public class FactionWizard : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Smart | GuardAI.Bless | GuardAI.Curse; } }


		[Constructable]
		public FactionWizard() : base( "the wizard" )
		{
			GenerateBody( false, false );


			SetStr( 151, 175 );
			SetDex( 61, 85 );
			SetInt( 151, 175 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Energy, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 60 );


			VirtualArmor = 32;


			SetSkill( SkillName.Macing, 110.0, 120.0 );
			SetSkill( SkillName.Wrestling, 110.0, 120.0 );
			SetSkill( SkillName.Tactics, 110.0, 120.0 );
			SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			SetSkill( SkillName.Healing, 110.0, 120.0 );
			SetSkill( SkillName.Anatomy, 110.0, 120.0 );


			SetSkill( SkillName.Magery, 110.0, 120.0 );
			SetSkill( SkillName.EvalInt, 110.0, 120.0 );
			SetSkill( SkillName.Meditation, 110.0, 120.0 );


			AddItem( Immovable( Rehued( new WizardsHat(), 1325 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1325 ) ) );
			AddItem( Immovable( Rehued( new Robe(), 1310 ) ) );
			AddItem( Immovable( Rehued( new LeatherGloves(), 1325 ) ) );
			AddItem( Newbied( Rehued( new GnarledStaff(), 1310 ) ) );


			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}


		public FactionWizard( Serial serial ) : base( serial )
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
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using Server.Targeting;// using System.Collections.Generic;


namespace Server.Factions
{
	public class FinanceGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;
		private Town m_Town;


		private static int[] m_PriceOffsets = new int[]
			{
				-30, -25, -20, -15, -10, -5,
				+50, +100, +150, +200, +250, +300
			};


		public override int ButtonTypes{ get{ return 2; } }


		public FinanceGump( PlayerMobile from, Faction faction, Town town ) : base( 50, 50 )
		{
			m_From = from;
			m_Faction = faction;
			m_Town = town;


			AddPage( 0 );


			AddBackground( 0, 0, 320, 410, 5054 );
			AddBackground( 10, 10, 300, 390, 3000 );


			#region General
			AddPage( 1 );


			AddHtmlLocalized( 20, 30, 260, 25, 1011541, false, false ); // FINANCE MINISTER


			AddHtmlLocalized( 55, 90, 200, 25, 1011539, false, false ); // CHANGE PRICES
			AddButton( 20, 90, 4005, 4007, 0, GumpButtonType.Page, 2 );


			AddHtmlLocalized( 55, 120, 200, 25, 1011540, false, false ); // BUY SHOPKEEPERS	
			AddButton( 20, 120, 4005, 4007, 0, GumpButtonType.Page, 3 );


			AddHtmlLocalized( 55, 150, 200, 25, 1011495, false, false ); // VIEW FINANCES
			AddButton( 20, 150, 4005, 4007, 0, GumpButtonType.Page, 4 );


			AddHtmlLocalized( 55, 360, 200, 25, 1011441, false, false ); // EXIT
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			#endregion


			#region Change Prices
			AddPage( 2 );


			AddHtmlLocalized( 20, 30, 200, 25, 1011539, false, false ); // CHANGE PRICES


			for ( int i = 0; i < m_PriceOffsets.Length; ++i )
			{
				int ofs = m_PriceOffsets[i];


				int x = 20 + ((i / 6) * 150);
				int y = 90 + ((i % 6) * 30);


				AddRadio( x, y, 208, 209, ( town.Tax == ofs ), i+1 );


				if ( ofs < 0 )
					AddLabel( x + 35, y, 0x26, String.Concat( "- ", -ofs, "%" ) );
				else
					AddLabel( x + 35, y, 0x12A, String.Concat( "+ ", ofs, "%" ) );
			}


			AddRadio( 20, 270, 208, 209, ( town.Tax == 0 ), 0 );
			AddHtmlLocalized( 55, 270, 90, 25, 1011542, false, false ); // normal


			AddHtmlLocalized( 55, 330, 200, 25, 1011509, false, false ); // Set Prices
			AddButton( 20, 330, 4005, 4007, ToButtonID( 0, 0 ), GumpButtonType.Reply, 0 );


			AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion


			#region Buy Shopkeepers
			AddPage( 3 );


			AddHtmlLocalized( 20, 30, 200, 25, 1011540, false, false ); // BUY SHOPKEEPERS


			List<VendorList> vendorLists = town.VendorLists;


			for ( int i = 0; i < vendorLists.Count; ++i )
			{
				VendorList list = vendorLists[i];


				AddButton( 20, 90 + (i * 40), 4005, 4007, 0, GumpButtonType.Page, 5 + i );
				AddItem( 55, 90 + (i * 40), list.Definition.ItemID );
				AddHtmlText( 100, 90 + (i * 40), 200, 25, list.Definition.Label, false, false );
			}


			AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false );	//	Previous page
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion


			#region View Finances
			AddPage( 4 );


			int financeUpkeep = town.FinanceUpkeep;
			int sheriffUpkeep = town.SheriffUpkeep;
			int dailyIncome = town.DailyIncome;
			int netCashFlow = town.NetCashFlow;


			AddHtmlLocalized( 20, 30, 300, 25, 1011524, false, false ); // FINANCE STATEMENT
	
			AddHtmlLocalized( 20, 80, 300, 25, 1011538, false, false ); // Current total money for town : 
			AddLabel( 20, 100, 0x44, town.Silver.ToString() );


			AddHtmlLocalized( 20, 130, 300, 25, 1011520, false, false ); // Finance Minister Upkeep : 
			AddLabel( 20, 150, 0x44, financeUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddHtmlLocalized( 20, 180, 300, 25, 1011521, false, false ); // Sheriff Upkeep : 
			AddLabel( 20, 200, 0x44, sheriffUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddHtmlLocalized( 20, 230, 300, 25, 1011522, false, false ); // Town Income : 
			AddLabel( 20, 250, 0x44, dailyIncome.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddHtmlLocalized( 20, 280, 300, 25, 1011523, false, false ); // Net Cash flow per day : 
			AddLabel( 20, 300, 0x44, netCashFlow.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion


			#region Shopkeeper Pages
			for ( int i = 0; i < vendorLists.Count; ++i )
			{
				VendorList vendorList = vendorLists[i];


				AddPage( 5 + i );


				AddHtmlText( 60, 30, 300, 25, vendorList.Definition.Header, false, false );
				AddItem( 20, 30, vendorList.Definition.ItemID );


				AddHtmlLocalized( 20, 90, 200, 25, 1011514, false, false ); // You have : 
				AddLabel( 230, 90, 0x26, vendorList.Vendors.Count.ToString() );


				AddHtmlLocalized( 20, 120, 200, 25, 1011515, false, false ); // Maximum : 
				AddLabel( 230, 120, 0x256, vendorList.Definition.Maximum.ToString() );


				AddHtmlLocalized( 20, 150, 200, 25, 1011516, false, false ); // Cost :
				AddLabel( 230, 150, 0x44, vendorList.Definition.Price.ToString( "N0" ) ); // NOTE: Added 'N0'


				AddHtmlLocalized( 20, 180, 200, 25, 1011517, false, false ); // Daily Pay :
				AddLabel( 230, 180, 0x37, vendorList.Definition.Upkeep.ToString( "N0" ) ); // NOTE: Added 'N0'


				AddHtmlLocalized( 20, 210, 200, 25, 1011518, false, false ); // Current Silver :
				AddLabel( 230, 210, 0x44, town.Silver.ToString( "N0" ) ); // NOTE: Added 'N0'


				AddHtmlLocalized( 20, 240, 200, 25, 1011519, false, false ); // Current Payroll :
				AddLabel( 230, 240, 0x44, financeUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'


				AddHtmlText( 55, 300, 200, 25, vendorList.Definition.Label, false, false );
				if ( town.Silver >= vendorList.Definition.Price )
					AddButton( 20, 300, 4005, 4007, ToButtonID( 1, i ), GumpButtonType.Reply, 0 );
				else
					AddImage( 20, 300, 4020 );


				AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
				AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 3 );
			}
			#endregion
		}


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( !m_Town.IsFinance( m_From ) || m_Town.Owner != m_Faction )
			{
				m_From.SendLocalizedMessage( 1010339 ); // You no longer control this city
				return;
			}


			int type, index;


			if ( !FromButtonID( info.ButtonID, out type, out index ) )
				return;


			switch ( type )
			{
				case 0: // general
				{
					switch ( index )
					{
						case 0: // set price
						{
							int[] switches = info.Switches;


							if ( switches.Length == 0 )
								break;


							int opt = switches[0];
							int newTax = 0;


							if ( opt >= 1 && opt <= m_PriceOffsets.Length )
								newTax = m_PriceOffsets[opt - 1];


							if ( m_Town.Tax == newTax )
								break;


							if ( m_From.AccessLevel == AccessLevel.Player && !m_Town.TaxChangeReady )
							{
								TimeSpan remaining = DateTime.Now - ( m_Town.LastTaxChange + Town.TaxChangePeriod );


								if ( remaining.TotalMinutes < 4 )
									m_From.SendLocalizedMessage( 1042165 ); // You must wait a short while before changing prices again.
								else if ( remaining.TotalMinutes < 10 )
									m_From.SendLocalizedMessage( 1042166 ); // You must wait several minutes before changing prices again.
								else if ( remaining.TotalHours < 1 )
									m_From.SendLocalizedMessage( 1042167 ); // You must wait up to an hour before changing prices again.
								else if ( remaining.TotalHours < 4 )
									m_From.SendLocalizedMessage( 1042168 ); // You must wait a few hours before changing prices again.
								else 
									m_From.SendLocalizedMessage( 1042169 ); // You must wait several hours before changing prices again.
							}
							else
							{
								m_Town.Tax = newTax;


								if ( m_From.AccessLevel == AccessLevel.Player )
									m_Town.LastTaxChange = DateTime.Now;
							}


							break;
						}
					}


					break;
				}
				case 1: // make vendor
				{
					List<VendorList> vendorLists = m_Town.VendorLists;


					if ( index >= 0 && index < vendorLists.Count )
					{
						VendorList vendorList = vendorLists[index];


						Town town = Town.FromRegion( m_From.Region );


						if ( Town.FromRegion( m_From.Region ) != m_Town )
						{
							m_From.SendLocalizedMessage( 1010305 ); // You must be in your controlled city to buy Items
						}
						else if ( vendorList.Vendors.Count >= vendorList.Definition.Maximum )
						{
							m_From.SendLocalizedMessage( 1010306 ); // You currently have too many of this enhancement type to place another
						}
						else if ( m_Town.Silver >= vendorList.Definition.Price )
						{
							BaseFactionVendor vendor = vendorList.Construct( m_Town, m_Faction );


							if ( vendor != null )
							{
								m_Town.Silver -= vendorList.Definition.Price;


								vendor.MoveToWorld( m_From.Location, m_From.Map );
								vendor.Home = vendor.Location;
							}
						}
					}


					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class GarnetWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }


		[Constructable]
		public GarnetWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the garnet wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "garnet", "monster", 0 );


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "garnet scales" );
   			c.DropItem(scale);
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public GarnetWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server.Commands;// using System.Collections.Generic;


namespace Server.Factions
{
	public class Generator
	{
		public static void Initialize()
		{
			CommandSystem.Register( "GenerateFactions", AccessLevel.Administrator, new CommandEventHandler( GenerateFactions_OnCommand ) );
		}


		public static void GenerateFactions_OnCommand( CommandEventArgs e )
		{
			new FactionPersistance();


			List<Faction> factions = Faction.Factions;


			foreach ( Faction faction in factions )
				Generate( faction );


			List<Town> towns = Town.Towns;


			foreach ( Town town in towns )
				Generate( town );
		}


		public static void Generate( Town town )
		{
			Map facet = Faction.Facet;


			TownDefinition def = town.Definition;


			if ( !CheckExistance( def.Monolith, facet, typeof( TownMonolith ) ) )
			{
				TownMonolith mono = new TownMonolith( town );
				mono.MoveToWorld( def.Monolith, facet );
				mono.Sigil = new Sigil( town );
			}


			if ( !CheckExistance( def.TownStone, facet, typeof( TownStone ) ) )
				new TownStone( town ).MoveToWorld( def.TownStone, facet );
		}


		public static void Generate( Faction faction )
		{
			Map facet = Faction.Facet;


			List<Town> towns = Town.Towns;


			StrongholdDefinition stronghold = faction.Definition.Stronghold;


			if ( !CheckExistance( stronghold.JoinStone, facet, typeof( JoinStone ) ) )
				new JoinStone( faction ).MoveToWorld( stronghold.JoinStone, facet );


			if ( !CheckExistance( stronghold.FactionStone, facet, typeof( FactionStone ) ) )
				new FactionStone( faction ).MoveToWorld( stronghold.FactionStone, facet );


			for ( int i = 0; i < stronghold.Monoliths.Length; ++i )
			{
				Point3D monolith = stronghold.Monoliths[i];


				if ( !CheckExistance( monolith, facet, typeof( StrongholdMonolith ) ) )
					new StrongholdMonolith( towns[i], faction ).MoveToWorld( monolith, facet );
			}
		}


		private static bool CheckExistance( Point3D loc, Map facet, Type type )
		{
			foreach ( Item item in facet.GetItemsInRange( loc, 0 ) )
			{
				if ( type.IsAssignableFrom( item.GetType() ) )
					return true;
			}


			return false;
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a beetle's corpse" )]
	public class GlowBeetle : BaseCreature
	{
		[Constructable]
		public GlowBeetle () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a glow beetle";
			Body = 0xA9;
			BaseSoundID = 0x388;


			SetStr( 156, 180 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );


			SetHits( 110, 150 );


			SetDamage( 7, 14 );


			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );


			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 90, 100 );


			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 75.0 );


			Fame = 4000;
			Karma = -4000;


			VirtualArmor = 26;


			AddItem( new LighterSource() );
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}


		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );


			if ( Utility.RandomMinMax( 1, 4 ) == 1 )
			{
				int goo = 0;


				foreach ( Item splash in this.GetItemsInRange( 10 ) ){ if ( splash is MonsterSplatter && splash.Name == "glowing goo" ){ goo++; } }


				if ( goo == 0 )
				{
					MonsterSplatter.AddSplatter( this.X, this.Y, this.Z, this.Map, this.Location, this, "glowing goo", 0xB93, 1 );
				}
			}
		}


		public GlowBeetle( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;


			Body = 0xA9;
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Network;


namespace Server.Mobiles
{
	[CorpseName( "a gorceratops corpse" )]
	public class Gorceratops : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}


		[Constructable]
		public Gorceratops () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gorceratops";
			Body = 0x11C;
			BaseSoundID = 0x4F5;
			Hue = Utility.RandomList( 0x7D7, 0x7D8, 0x7D9, 0x7DA, 0x7DB, 0x7DC );


			SetStr( 176, 205 );
			SetDex( 46, 65 );
			SetInt( 46, 70 );


			SetHits( 106, 123 );


			SetDamage( 8, 14 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 15 );
			SetResistance( ResistanceType.Energy, 5, 15 );


			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 50.1, 70.0 );


			Fame = 3500;
			Karma = -3500;


			VirtualArmor = 40;


			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 63.9;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}


		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Dinosaur; } }
		public override int Scales{ get{ return 4; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public Gorceratops( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 0x11C;
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Network;


namespace Server.Mobiles
{
	[CorpseName( "a gorgon corpse" )]
	public class Gorgon : BaseCreature
	{
		[Constructable]
		public Gorgon () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gorgon";
			Body = 0x11C;
			BaseSoundID = 362;
			Hue = 0x961;


			SetStr( 176, 205 );
			SetDex( 46, 65 );
			SetInt( 46, 70 );


			SetHits( 106, 123 );


			SetDamage( 8, 14 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 15 );
			SetResistance( ResistanceType.Energy, 5, 15 );


			SetSkill( SkillName.MagicResist, 45.1, 60.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 50.1, 70.0 );


			Fame = 3500;
			Karma = -3500;


			VirtualArmor = 40;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}


		public void TurnStone()
		{
			ArrayList list = new ArrayList();


			foreach ( Mobile m in this.GetMobilesInRange( 2 ) )
			{
				if ( m == this || !CanBeHarmful( m ) )
					continue;


				if ( m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team) )
					list.Add( m );
				else if ( m.Player )
					list.Add( m );
			}


			foreach ( Mobile m in list )
			{
				DoHarmful( m );


				m.PlaySound(0x16B);
				m.FixedEffect(0x376A, 6, 1);


				int duration = Utility.RandomMinMax(4, 8);
				m.Paralyze(TimeSpan.FromSeconds(duration));


				m.SendMessage( "You are petrified from the gorgon breath!" );
			}
		}


		public override void OnGaveMeleeAttack( Mobile m )
		{
			base.OnGaveMeleeAttack( m );


			if ( 1 == Utility.RandomMinMax( 1, 20 ) )
			{
				Container cont = m.Backpack;
				Item iStone = Server.Items.HiddenTrap.GetMyItem( m );


				if ( iStone != null )
				{
					if ( m.CheckSkill( SkillName.MagicResist, 0, 100 ) || Server.Items.HiddenTrap.IAmAWeaponSlayer( m, this ) )
					{
					}
					else if ( Server.Items.HiddenTrap.CheckInsuranceOnTrap( iStone, m ) == true )
					{
						m.LocalOverheadMessage(MessageType.Emote, 1150, true, "The gorgon almost turned one of your protected items to stone!");
					}
					else
					{
						m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "One of your items has been turned to stone!");
						m.PlaySound( 0x1FB );
						Item rock = new BrokenGear();
						rock.ItemID = iStone.ItemID;
						rock.Hue = 2101;
						rock.Weight = iStone.Weight * 3;
						rock.Name = "useless stone";
						iStone.Delete();
						m.AddToBackpack ( rock );
					}
				}
			}


			if ( 0.1 >= Utility.RandomDouble() )
				TurnStone();
		}


		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );


			if ( 0.1 >= Utility.RandomDouble() )
				TurnStone();
		}


		public Gorgon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 0x11C;
		}
	}
}
// using Server;// using System;// using Server.Misc;// using Server.Mobiles;


namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class GreenDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }


		[Constructable]
		public GreenDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a green dragon";
			Body = 12;
			Hue = 2001;
			BaseSoundID = 362;


			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );


			SetHits( 478, 495 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );


			SetSkill( SkillName.EvalInt, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );


			Fame = 15000;
			Karma = -15000;


			VirtualArmor = 60;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();


				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Green", "", c, 25, 0 );
				}
			}
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}


		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Green ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public GreenDragon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections;// using Server.Items;// using Server.Targeting;


namespace Server.Mobiles
{
	[CorpseName( "a griffon corpse" )]
	public class Griffon : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}


		[Constructable]
		public Griffon() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a griffon";
			Body = 0x31F;
			BaseSoundID = 0x2EE;


			SetStr( 196, 220 );
			SetDex( 186, 210 );
			SetInt( 151, 175 );


			SetHits( 158, 172 );


			SetDamage( 9, 15 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 10, 20 );


			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 90.0 );


			Fame = 3500;
			Karma = 3500;


			VirtualArmor = 32;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}


		public override int Meat{ get{ return 12; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 50; } }


		public Griffon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 0x31F;
		}
	}
}
// using System;// using Server.Mobiles;


namespace Server.Mobiles
{
	[CorpseName( "a grizzly bear corpse" )]
	[TypeAlias( "Server.Mobiles.Grizzlybear" )]
	public class GrizzlyBear : BaseCreature
	{
		[Constructable]
		public GrizzlyBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a grizzly bear";
			Body = 212;
			BaseSoundID = 0xA3;


			SetStr( 126, 155 );
			SetDex( 81, 105 );
			SetInt( 16, 40 );


			SetHits( 76, 93 );
			SetMana( 0 );


			SetDamage( 8, 13 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );


			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.Wrestling, 45.1, 70.0 );


			Fame = 1000;
			Karma = 0;


			VirtualArmor = 24;


			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 59.1;
		}


		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }


		public GrizzlyBear( Serial serial ) : base( serial )
		{
		}


		public override void Serialize(GenericWriter writer)
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
// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.Targeting;// using Server.Factions.AI;// using Server.Spells;// using Server.Spells.First;// using Server.Spells.Second;// using Server.Spells.Third;// using Server.Spells.Fourth;// using Server.Spells.Fifth;// using Server.Spells.Sixth;// using Server.Spells.Seventh;


namespace Server.Factions
{
	public enum GuardAI
	{
		Bless	= 0x01, // heal, cure, +stats
		Curse	= 0x02, // poison, -stats
		Melee	= 0x04, // weapons
		Magic	= 0x08, // damage spells
		Smart	= 0x10  // smart weapons/damage spells
	}


	public class ComboEntry
	{
		private Type m_Spell;
		private TimeSpan m_Hold;
		private int m_Chance;


		public Type Spell{ get{ return m_Spell; } }
		public TimeSpan Hold{ get{ return m_Hold; } }
		public int Chance{ get{ return m_Chance; } }


		public ComboEntry( Type spell ) : this( spell, 100, TimeSpan.Zero )
		{
		}


		public ComboEntry( Type spell, int chance ) : this( spell, chance, TimeSpan.Zero )
		{
		}


		public ComboEntry( Type spell, int chance, TimeSpan hold )
		{
			m_Spell = spell;
			m_Chance = chance;
			m_Hold = hold;
		}
	}


	public class SpellCombo
	{
		private int m_Mana;
		private ComboEntry[] m_Entries;


		public int Mana{ get{ return m_Mana; } }
		public ComboEntry[] Entries{ get{ return m_Entries; } }


		public SpellCombo( int mana, params ComboEntry[] entries )
		{
			m_Mana = mana;
			m_Entries = entries;
		}


		public static readonly SpellCombo Simple = new SpellCombo( 50,
			new ComboEntry( typeof( ParalyzeSpell ), 20 ),
			new ComboEntry( typeof( ExplosionSpell ), 100, TimeSpan.FromSeconds( 2.8 ) ),
			new ComboEntry( typeof( PoisonSpell ), 30 ),
			new ComboEntry( typeof( EnergyBoltSpell ) )
		);


		public static readonly SpellCombo Strong = new SpellCombo( 90,
			new ComboEntry( typeof( ParalyzeSpell ), 20 ),
			new ComboEntry( typeof( ExplosionSpell ), 50, TimeSpan.FromSeconds( 2.8 ) ),
			new ComboEntry( typeof( PoisonSpell ), 30 ),
			new ComboEntry( typeof( ExplosionSpell ), 100, TimeSpan.FromSeconds( 2.8 ) ),
			new ComboEntry( typeof( EnergyBoltSpell ) ),
			new ComboEntry( typeof( PoisonSpell ), 30 ),
			new ComboEntry( typeof( EnergyBoltSpell ) )
		);


		public static Spell Process( Mobile mob, Mobile targ, ref SpellCombo combo, ref int index, ref DateTime releaseTime )
		{
			while ( ++index < combo.m_Entries.Length )
			{
				ComboEntry entry = combo.m_Entries[index];


				if ( entry.Spell == typeof( PoisonSpell ) && targ.Poisoned )
					continue;


				if ( entry.Chance > Utility.Random( 100 ) )
				{
					releaseTime = DateTime.Now + entry.Hold;
					return (Spell) Activator.CreateInstance( entry.Spell, new object[]{ mob, null } );
				}
			}


			combo = null;
			index = -1;
			return null;
		}
	}


	public class FactionGuardAI : BaseAI
	{
		private BaseFactionGuard m_Guard;


		private BandageContext m_Bandage;
		private DateTime m_BandageStart;


		private SpellCombo m_Combo;
		private int m_ComboIndex = -1;
		private DateTime m_ReleaseTarget;


		private const int ManaReserve = 30;


		public bool IsAllowed( GuardAI flag )
		{
			return ( ( m_Guard.GuardAI & flag ) == flag );
		}


		public bool IsDamaged
		{
			get{ return ( m_Guard.Hits < m_Guard.HitsMax ); }
		}


		public bool IsPoisoned
		{
			get{ return m_Guard.Poisoned; }
		}


		public TimeSpan TimeUntilBandage
		{
			get
			{
				if ( m_Bandage != null && m_Bandage.Timer == null )
					m_Bandage = null;


				if ( m_Bandage == null )
					return TimeSpan.MaxValue;


				TimeSpan ts = ( m_BandageStart + m_Bandage.Timer.Delay ) - DateTime.Now;


				if ( ts < TimeSpan.FromSeconds( -1.0 ) )
				{
					m_Bandage = null;
					return TimeSpan.MaxValue;
				}


				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;


				return ts;
			}
		}


		public bool DequipWeapon()
		{
			Container pack = m_Guard.Backpack;


			if ( pack == null )
				return false;


			Item weapon = m_Guard.Weapon as Item;


			if ( weapon != null && weapon.Parent == m_Guard && !(weapon is Fists) )
			{
				pack.DropItem( weapon );
				return true;
			}


			return false;
		}


		public bool EquipWeapon()
		{
			Container pack = m_Guard.Backpack;


			if ( pack == null )
				return false;


			Item weapon = pack.FindItemByType( typeof( BaseWeapon ) );


			if ( weapon == null )
				return false;


			return m_Guard.EquipItem( weapon );
		}


		public bool StartBandage()
		{
			m_Bandage = null;


			Container pack = m_Guard.Backpack;


			if ( pack == null )
				return false;


			Item bandage = pack.FindItemByType( typeof( Bandage ) );


			if ( bandage == null )
				return false;


			m_Bandage = BandageContext.BeginHeal( m_Guard, m_Guard );
			m_BandageStart = DateTime.Now;
			return ( m_Bandage != null );
		}


		public bool UseItemByType( Type type )
		{
			Container pack = m_Guard.Backpack;


			if ( pack == null )
				return false;


			Item item = pack.FindItemByType( type );


			if ( item == null )
				return false;


			bool requip = DequipWeapon();


			item.OnDoubleClick( m_Guard );


			if ( requip )
				EquipWeapon();


			return true;
		}


		public int GetStatMod( Mobile mob, StatType type )
		{
			StatMod mod = mob.GetStatMod( String.Format( "[Magic] {0} Offset", type ) );


			if ( mod == null )
				return 0;


			return mod.Offset;
		}


		public Spell RandomOffenseSpell()
		{
			int maxCircle = (int)((m_Guard.Skills.Magery.Value + 20.0) / (100.0 / 7.0));


			if ( maxCircle < 1 )
				maxCircle = 1;


			switch ( Utility.Random( maxCircle*2 ) )
			{
				case  0: case  1: return new MagicArrowSpell( m_Guard, null );
				case  2: case  3: return new HarmSpell( m_Guard, null );
				case  4: case  5: return new FireballSpell( m_Guard, null );
				case  6: case  7: return new LightningSpell( m_Guard, null );
				case  8: return new MindBlastSpell( m_Guard, null );
				case  9: return new ParalyzeSpell( m_Guard, null );
				case 10: return new EnergyBoltSpell( m_Guard, null );
				case 11: return new ExplosionSpell( m_Guard, null );
				default: return new FlameStrikeSpell( m_Guard, null );
			}
		}


		public Mobile FindDispelTarget( bool activeOnly )
		{
			if ( m_Mobile.Deleted || m_Mobile.Int < 95 || CanDispel( m_Mobile ) || m_Mobile.AutoDispel )
				return null;


			if ( activeOnly )
			{
				List<AggressorInfo> aggressed = m_Mobile.Aggressed;
				List<AggressorInfo> aggressors = m_Mobile.Aggressors;


				Mobile active = null;
				double activePrio = 0.0;


				Mobile comb = m_Mobile.Combatant;


				if ( comb != null && !comb.Deleted && comb.Alive && !comb.IsDeadBondedPet && m_Mobile.InRange( comb, 12 ) && CanDispel( comb ) )
				{
					active = comb;
					activePrio = m_Mobile.GetDistanceToSqrt( comb );


					if ( activePrio <= 2 )
						return active;
				}


				for ( int i = 0; i < aggressed.Count; ++i )
				{
					AggressorInfo info = aggressed[i];
					Mobile m = info.Defender;


					if ( m != comb && m.Combatant == m_Mobile && m_Mobile.InRange( m, 12 ) && CanDispel( m ) )
					{
						double prio = m_Mobile.GetDistanceToSqrt( m );


						if ( active == null || prio < activePrio )
						{
							active = m;
							activePrio = prio;


							if ( activePrio <= 2 )
								return active;
						}
					}
				}


				for ( int i = 0; i < aggressors.Count; ++i )
				{
					AggressorInfo info = aggressors[i];
					Mobile m = info.Attacker;


					if ( m != comb && m.Combatant == m_Mobile && m_Mobile.InRange( m, 12 ) && CanDispel( m ) )
					{
						double prio = m_Mobile.GetDistanceToSqrt( m );


						if ( active == null || prio < activePrio )
						{
							active = m;
							activePrio = prio;


							if ( activePrio <= 2 )
								return active;
						}
					}
				}


				return active;
			}
			else
			{
				Map map = m_Mobile.Map;


				if ( map != null )
				{
					Mobile active = null, inactive = null;
					double actPrio = 0.0, inactPrio = 0.0;


					Mobile comb = m_Mobile.Combatant;


					if ( comb != null && !comb.Deleted && comb.Alive && !comb.IsDeadBondedPet && CanDispel( comb ) )
					{
						active = inactive = comb;
						actPrio = inactPrio = m_Mobile.GetDistanceToSqrt( comb );
					}


					foreach ( Mobile m in m_Mobile.GetMobilesInRange( 12 ) )
					{
						if ( m != m_Mobile && CanDispel( m ) )
						{
							double prio = m_Mobile.GetDistanceToSqrt( m );


							if ( !activeOnly && (inactive == null || prio < inactPrio) )
							{
								inactive = m;
								inactPrio = prio;
							}


							if ( (m_Mobile.Combatant == m || m.Combatant == m_Mobile) && (active == null || prio < actPrio) )
							{
								active = m;
								actPrio = prio;
							}
						}
					}


					return active != null ? active : inactive;
				}
			}


			return null;
		}


		public bool CanDispel( Mobile m )
		{
			return ( m is BaseCreature && ((BaseCreature)m).Summoned && m_Mobile.CanBeHarmful( m, false ) && !((BaseCreature)m).IsAnimatedDead );
		}


		public void RunTo( Mobile m )
		{
			/*if ( m.Paralyzed || m.Frozen )
			{
				if ( m_Mobile.InRange( m, 1 ) )
					RunFrom( m );
				else if ( !m_Mobile.InRange( m, m_Mobile.RangeFight > 2 ? m_Mobile.RangeFight : 2 ) && !MoveTo( m, true, 1 ) )
					OnFailedMove();
			}
			else
			{*/
				if ( !m_Mobile.InRange( m, m_Mobile.RangeFight ) )
				{
					if ( !MoveTo( m, true, 1 ) )
						OnFailedMove();
				}
				else if ( m_Mobile.InRange( m, m_Mobile.RangeFight - 1 ) )
				{
					RunFrom( m );
				}
			/*}*/
		}


		public void RunFrom( Mobile m )
		{
			Run( (m_Mobile.GetDirectionTo( m ) - 4) & Direction.Mask );
		}


		public void OnFailedMove()
		{
			/*if ( !m_Mobile.DisallowAllMoves && 20 > Utility.Random( 100 ) && IsAllowed( GuardAI.Magic ) )
			{
				if ( m_Mobile.Target != null )
					m_Mobile.Target.Cancel( m_Mobile, TargetCancelType.Canceled );


				new TeleportSpell( m_Mobile, null ).Cast();


				m_Mobile.DebugSay( "I am stuck, I'm going to try teleporting away" );
			}
			else*/ if ( AcquireFocusMob( m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true ) )
			{
				if ( m_Mobile.Debug )
					m_Mobile.DebugSay( "My move is blocked, so I am going to attack {0}", m_Mobile.FocusMob.Name );


				m_Mobile.Combatant = m_Mobile.FocusMob;
				Action = ActionType.Combat;
			}
			else
			{
				m_Mobile.DebugSay( "I am stuck" );
			}
		}


		public void Run( Direction d )
		{
			if ( (m_Mobile.Spell != null && m_Mobile.Spell.IsCasting) || m_Mobile.Paralyzed || m_Mobile.Frozen || m_Mobile.DisallowAllMoves )
				return;


			m_Mobile.Direction = d | Direction.Running;


			if ( !DoMove( m_Mobile.Direction, true ) )
				OnFailedMove();
		}


		public FactionGuardAI( BaseFactionGuard guard ) : base( guard )
		{
			m_Guard = guard;
		}


		public override bool Think()
		{
			if ( m_Mobile.Deleted )
				return false;


			Mobile combatant = m_Guard.Combatant;


			if ( combatant == null || combatant.Deleted || !combatant.Alive || combatant.IsDeadBondedPet || !m_Mobile.CanSee( combatant ) || !m_Mobile.CanBeHarmful( combatant, false ) || combatant.Map != m_Mobile.Map )
			{
				// Our combatant is deleted, dead, hidden, or we cannot hurt them
				// Try to find another combatant


				if ( AcquireFocusMob( m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true ) )
				{
					m_Mobile.Combatant = combatant = m_Mobile.FocusMob;
					m_Mobile.FocusMob = null;
				}
				else
				{
					m_Mobile.Combatant = combatant = null;
				}
			}


			if ( combatant != null && (!m_Mobile.InLOS( combatant ) || !m_Mobile.InRange( combatant, 12 )) )
			{
				if ( AcquireFocusMob( m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true ) )
				{
					m_Mobile.Combatant = combatant = m_Mobile.FocusMob;
					m_Mobile.FocusMob = null;
				}
				else if ( !m_Mobile.InRange( combatant, 36 ) )
				{
					m_Mobile.Combatant = combatant = null;
				}
			}


			Mobile dispelTarget = FindDispelTarget( true );


			if ( m_Guard.Target != null && m_ReleaseTarget == DateTime.MinValue )
				m_ReleaseTarget = DateTime.Now + TimeSpan.FromSeconds( 10.0 );


			if ( m_Guard.Target != null && DateTime.Now > m_ReleaseTarget )
			{
				Target targ = m_Guard.Target;


				Mobile toHarm = ( dispelTarget == null ? combatant : dispelTarget );


				if ( (targ.Flags & TargetFlags.Harmful) != 0 && toHarm != null )
				{
					if ( m_Guard.Map == toHarm.Map && ( targ.Range < 0 || m_Guard.InRange( toHarm, targ.Range ) ) && m_Guard.CanSee( toHarm ) && m_Guard.InLOS( toHarm ) )
						targ.Invoke( m_Guard, toHarm );
					else if ( targ is DispelSpell.InternalTarget )
						targ.Cancel( m_Guard, TargetCancelType.Canceled );
				}
				else if ( (targ.Flags & TargetFlags.Beneficial) != 0 )
				{
					targ.Invoke( m_Guard, m_Guard );
				}
				else
				{
					targ.Cancel( m_Guard, TargetCancelType.Canceled );
				}


				m_ReleaseTarget = DateTime.MinValue;
			}


			if ( dispelTarget != null )
			{
				if ( Action != ActionType.Combat )
					Action = ActionType.Combat;


				m_Guard.Warmode = true;


				RunFrom( dispelTarget );
			}
			else if ( combatant != null )
			{
				if ( Action != ActionType.Combat )
					Action = ActionType.Combat;


				m_Guard.Warmode = true;


				RunTo( combatant );
			}
			else if ( m_Guard.Orders.Movement != MovementType.Stand )
			{
				Mobile toFollow = null;


				if ( m_Guard.Town != null && m_Guard.Orders.Movement == MovementType.Follow )
				{
					toFollow = m_Guard.Orders.Follow;


					if ( toFollow == null )
						toFollow = m_Guard.Town.Sheriff;
				}


				if ( toFollow != null && toFollow.Map == m_Guard.Map && toFollow.InRange( m_Guard, m_Guard.RangePerception * 3 ) && Town.FromRegion( toFollow.Region ) == m_Guard.Town )
				{
					if ( Action != ActionType.Combat )
						Action = ActionType.Combat;


					if ( m_Mobile.CurrentSpeed != m_Mobile.ActiveSpeed )
						m_Mobile.CurrentSpeed = m_Mobile.ActiveSpeed;


					m_Guard.Warmode = true;


					RunTo( toFollow );
				}
				else
				{
					if ( Action != ActionType.Wander )
						Action = ActionType.Wander;


					if ( m_Mobile.CurrentSpeed != m_Mobile.PassiveSpeed )
						m_Mobile.CurrentSpeed = m_Mobile.PassiveSpeed;


					m_Guard.Warmode = false;


					WalkRandomInHome( 2, 2, 1 );
				}
			}
			else
			{
				if ( Action != ActionType.Wander )
					Action = ActionType.Wander;


				m_Guard.Warmode = false;
			}


			if ( (IsDamaged || IsPoisoned) && m_Guard.Skills.Healing.Base > 20.0 )
			{
				TimeSpan ts = TimeUntilBandage;


				if ( ts == TimeSpan.MaxValue )
					StartBandage();
			}


			if ( m_Mobile.Spell == null && DateTime.Now >= m_Mobile.NextSpellTime )
			{
				Spell spell = null;


				DateTime toRelease = DateTime.MinValue;


				if ( IsPoisoned )
				{
					Poison p = m_Guard.Poison;


					TimeSpan ts = TimeUntilBandage;


					if ( p != Poison.Lesser || ts == TimeSpan.MaxValue || TimeUntilBandage < TimeSpan.FromSeconds( 1.5 ) || (m_Guard.HitsMax - m_Guard.Hits) > Utility.Random( 250 ) )
					{
						if ( IsAllowed( GuardAI.Bless ) )
							spell = new CureSpell( m_Guard, null );
						else
							UseItemByType( typeof( BaseCurePotion ) );
					}
				}
				else if ( IsDamaged && (m_Guard.HitsMax - m_Guard.Hits) > Utility.Random( 200 ) )
				{
					if( IsAllowed( GuardAI.Magic ) && ((m_Guard.Hits * 100) / Math.Max( m_Guard.HitsMax, 1 )) < 10 && m_Guard.Home != Point3D.Zero && !Utility.InRange( m_Guard.Location, m_Guard.Home, 15 ) && m_Guard.Mana >= 11 )
					{
						spell = new RecallSpell( m_Guard, null, new RunebookEntry( m_Guard.Home, m_Guard.Map, "Guard's Home", null ), null  );
					}
					else if ( IsAllowed( GuardAI.Bless ) )
					{
						if ( m_Guard.Mana >= 11 && (m_Guard.Hits + 30) < m_Guard.HitsMax )
							spell = new GreaterHealSpell( m_Guard, null );
						else if ( (m_Guard.Hits + 10) < m_Guard.HitsMax && (m_Guard.Mana < 11 || (m_Guard.NextCombatTime - DateTime.Now) > TimeSpan.FromSeconds( 2.0 )) )
							spell = new HealSpell( m_Guard, null );
					}
					else if ( m_Guard.CanBeginAction( typeof( BaseHealPotion ) ) )
					{
						UseItemByType( typeof( BaseHealPotion ) );
					}
				}
				else if ( dispelTarget != null && (IsAllowed( GuardAI.Magic ) || IsAllowed( GuardAI.Bless ) || IsAllowed( GuardAI.Curse )) )
				{
					if ( !dispelTarget.Paralyzed && m_Guard.Mana > (ManaReserve + 20) && 40 > Utility.Random( 100 ) )
						spell = new ParalyzeSpell( m_Guard, null );
					else
						spell = new DispelSpell( m_Guard, null );
				}


				if ( combatant != null )
				{
					if ( m_Combo != null )
					{
						if ( spell == null )
						{
							spell = SpellCombo.Process( m_Guard, combatant, ref m_Combo, ref m_ComboIndex, ref toRelease );
						}
						else
						{
							m_Combo = null;
							m_ComboIndex = -1;
						}
					}
					else if ( 20 > Utility.Random( 100 ) && IsAllowed( GuardAI.Magic ) )
					{
						if ( 80 > Utility.Random( 100 ) )
						{
							m_Combo = ( IsAllowed( GuardAI.Smart ) ? SpellCombo.Simple : SpellCombo.Strong );
							m_ComboIndex = -1;


							if ( m_Guard.Mana >= (ManaReserve + m_Combo.Mana) )
								spell = SpellCombo.Process( m_Guard, combatant, ref m_Combo, ref m_ComboIndex, ref toRelease );
							else
							{
								m_Combo = null;


								if ( m_Guard.Mana >= (ManaReserve + 40) )
									spell = RandomOffenseSpell();
							}
						}
						else if ( m_Guard.Mana >= (ManaReserve + 40) )
						{
							spell = RandomOffenseSpell();
						}
					}


					if ( spell == null && 2 > Utility.Random( 100 ) && m_Guard.Mana >= (ManaReserve + 10) )
					{
						int strMod = GetStatMod( m_Guard, StatType.Str );
						int dexMod = GetStatMod( m_Guard, StatType.Dex );
						int intMod = GetStatMod( m_Guard, StatType.Int );


						List<Type> types = new List<Type>();


						if ( strMod <= 0 )
							types.Add( typeof( StrengthSpell ) );


						if ( dexMod <= 0 && IsAllowed( GuardAI.Melee ) )
							types.Add( typeof( AgilitySpell ) );


						if ( intMod <= 0 && IsAllowed( GuardAI.Magic ) )
							types.Add( typeof( CunningSpell ) );


						if ( IsAllowed( GuardAI.Bless ) )
						{
							if ( types.Count > 1 )
								spell = new BlessSpell( m_Guard, null );
							else if ( types.Count == 1 )
								spell = (Spell) Activator.CreateInstance( types[0], new object[]{ m_Guard, null } );
						}
						else if ( types.Count > 0 )
						{
							if ( types[0] == typeof( StrengthSpell ) )
								UseItemByType( typeof( BaseStrengthPotion ) );
							else if ( types[0] == typeof( AgilitySpell ) )
								UseItemByType( typeof( BaseAgilityPotion ) );
						}
					}


					if ( spell == null && 2 > Utility.Random( 100 ) && m_Guard.Mana >= (ManaReserve + 10) && IsAllowed( GuardAI.Curse ) )
					{
						if ( !combatant.Poisoned && 40 > Utility.Random( 100 ) )
						{
							spell = new PoisonSpell( m_Guard, null );
						}
						else
						{
							int strMod = GetStatMod( combatant, StatType.Str );
							int dexMod = GetStatMod( combatant, StatType.Dex );
							int intMod = GetStatMod( combatant, StatType.Int );


							List<Type> types = new List<Type>();


							if ( strMod >= 0 )
								types.Add( typeof( WeakenSpell ) );


							if ( dexMod >= 0 && IsAllowed( GuardAI.Melee ) )
								types.Add( typeof( ClumsySpell ) );


							if ( intMod >= 0 && IsAllowed( GuardAI.Magic ) )
								types.Add( typeof( FeeblemindSpell ) );


							if ( types.Count > 1 )
								spell = new CurseSpell( m_Guard, null );
							else if ( types.Count == 1 )
								spell = (Spell) Activator.CreateInstance( types[0], new object[]{ m_Guard, null } );
						}
					}
				}


				if ( spell != null && (m_Guard.HitsMax - m_Guard.Hits + 10) > Utility.Random( 100 ) )
				{
					Type type = null;


					if ( spell is GreaterHealSpell )
						type = typeof( BaseHealPotion );
					else if ( spell is CureSpell )
						type = typeof( BaseCurePotion );
					else if ( spell is StrengthSpell )
						type = typeof( BaseStrengthPotion );
					else if ( spell is AgilitySpell )
						type = typeof( BaseAgilityPotion );


					if ( type == typeof( BaseHealPotion ) && !m_Guard.CanBeginAction( type ) )
						type = null;


					if ( type != null && m_Guard.Target == null && UseItemByType( type ) )
					{
						if ( spell is GreaterHealSpell )
						{
							if ( (m_Guard.Hits + 30) > m_Guard.HitsMax && (m_Guard.Hits + 10) < m_Guard.HitsMax )
								spell = new HealSpell( m_Guard, null );
						}
						else
						{
							spell = null;
						}
					}
				}
				else if ( spell == null && m_Guard.Stam < (m_Guard.StamMax / 3) && IsAllowed( GuardAI.Melee ) )
				{
					UseItemByType( typeof( BaseRefreshPotion ) );
				}


				if ( spell == null || !spell.Cast() )
					EquipWeapon();
			}
			else if ( m_Mobile.Spell is Spell && ((Spell)m_Mobile.Spell).State == SpellState.Sequencing )
			{
				EquipWeapon();
			}


			return true;
		}
	}
}
// using System;// using Server;


namespace Server.Factions
{
	public class GuardDefinition
	{
		private Type m_Type;


		private int m_Price;
		private int m_Upkeep;
		private int m_Maximum;


		private int m_ItemID;


		private TextDefinition m_Header;
		private TextDefinition m_Label;


		public Type Type{ get{ return m_Type; } }


		public int Price{ get{ return m_Price; } }
		public int Upkeep{ get{ return m_Upkeep; } }
		public int Maximum{ get{ return m_Maximum; } }
		public int ItemID{ get{ return m_ItemID; } }


		public TextDefinition Header{ get{ return m_Header; } }
		public TextDefinition Label{ get{ return m_Label; } }


		public GuardDefinition( Type type, int itemID, int price, int upkeep, int maximum, TextDefinition header, TextDefinition label )
		{
			m_Type = type;


			m_Price = price;
			m_Upkeep = upkeep;
			m_Maximum = maximum;
			m_ItemID = itemID;


			m_Header = header;
			m_Label = label;
		}
	}
}
// using System;// using Server;// using System.Collections.Generic;


namespace Server.Factions
{
	public class GuardList
	{
		private GuardDefinition m_Definition;
		private List<BaseFactionGuard> m_Guards;


		public GuardDefinition Definition{ get{ return m_Definition; } }
		public List<BaseFactionGuard> Guards{ get{ return m_Guards; } }


		public BaseFactionGuard Construct()
		{
			try{ return Activator.CreateInstance( m_Definition.Type ) as BaseFactionGuard; }
			catch{ return null; }
		}


		public GuardList( GuardDefinition definition )
		{
			m_Definition = definition;
			m_Guards = new List<BaseFactionGuard>();
		}
	}
}
// using System;// using Server;


namespace Server.Mobiles
{
	[CorpseName( "a hippogriff corpse" )]
	public class Hippogriff : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}


		[Constructable]
		public Hippogriff() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a hippogriff";
			Body = 188;
			BaseSoundID = 0x2EE;


			SetStr( 196, 220 );
			SetDex( 186, 210 );
			SetInt( 151, 175 );


			SetHits( 158, 172 );


			SetDamage( 9, 15 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 10, 20 );


			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 90.0 );


			Fame = 3500;
			Karma = 3500;


			VirtualArmor = 32;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}


		public override int Meat{ get{ return 12; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 50; } }


		public Hippogriff( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 188;
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics.Hero
{
	public sealed class HolyBlade : Power
	{
		public HolyBlade()
		{
			m_Definition = new PowerDefinition(
					10,
					"Holy Blade",
					"Erstok Reyam",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
		}
	}
}// using System;// using Server;// using Server.Ethics;// using Server.Mobiles;


namespace Server.Mobiles
{
	[CorpseName( "a holy corpse" )]
	public class HolyFamiliar : BaseCreature
	{
		public override bool IsDispellable { get { return false; } }
		public override bool IsBondable { get { return false; } }


		[Constructable]
		public HolyFamiliar()
			: base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a silver wolf";
			Body = 225;
			Hue = 1154;
			BaseSoundID = 0xE5;


			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );


			SetHits( 58, 72 );
			SetMana( 0 );


			SetDamage( 11, 17 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 10, 15 );


			SetSkill( SkillName.MagicResist, 57.6, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );


			Fame = 2500;
			Karma = 2500;


			VirtualArmor = 22;


			Tamable = false;
			ControlSlots = 1;
		}


		public override int Meat { get { return 1; } }
		public override int Hides { get { return 7; } }
		public override FoodType FavoriteFood { get { return FoodType.Meat; } }
		public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }


		public HolyFamiliar( Serial serial )
			: base( serial )
		{
		}


		public override string ApplyNameSuffix( string suffix )
		{
			if ( suffix.Length == 0 )
				suffix = Ethic.Hero.Definition.Adjunct.String;
			else
				suffix = String.Concat( suffix, " ", Ethic.Hero.Definition.Adjunct.String );


			return base.ApplyNameSuffix( suffix );
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
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Items;


namespace Server.Ethics.Hero
{
	public sealed class HolyItem : Power
	{
		public HolyItem()
		{
			m_Definition = new PowerDefinition(
					5,
					"Holy Item",
					"Vidda K'balc",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			from.Mobile.BeginTarget( 12, false, Targeting.TargetFlags.None, new TargetStateCallback( Power_OnTarget ), from );
			from.Mobile.SendMessage( "Which item do you wish to imbue?" );
		}


		private void Power_OnTarget( Mobile fromMobile, object obj, object state )
		{
			Player from = state as Player;


			Item item = obj as Item;


			if ( item == null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that." );
				return;
			}


			if ( item.Parent != from.Mobile )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may only imbue items you are wearing." );
				return;
			}


			if ( ( item.SavedFlags & 0x300 ) != 0 )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "That has already beem imbued." );
				return;
			}


			bool canImbue = ( item is Spellbook || item is BaseClothing || item is BaseArmor || item is BaseWeapon ) && ( item.Name == null );


			if ( canImbue )
			{
				if ( !CheckInvoke( from ) )
					return;


				item.Hue = Ethic.Hero.Definition.PrimaryHue;
				item.SavedFlags |= 0x100;


				from.Mobile.FixedEffect( 0x375A, 10, 20 );
				from.Mobile.PlaySound( 0x209 );


				FinishInvoke( from );
			}
			else
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that." );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics.Hero
{
	public sealed class HolySense : Power
	{
		public HolySense()
		{
			m_Definition = new PowerDefinition(
					0,
					"Holy Sense",
					"Drewrok Erstok",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			Ethic opposition = Ethic.Evil;


			int enemyCount = 0;


			int maxRange = 18 + from.Power;


			Player primary = null;


			foreach ( Player pl in opposition.Players )
			{
				Mobile mob = pl.Mobile;


				if ( mob == null || mob.Map != from.Mobile.Map || !mob.Alive )
					continue;


				if ( !mob.InRange( from.Mobile, Math.Max( 18, maxRange - pl.Power ) ) )
					continue;


				if ( primary == null || pl.Power > primary.Power )
					primary = pl;


				++enemyCount;
			}


			StringBuilder sb = new StringBuilder();


			sb.Append( "You sense " );
			sb.Append( enemyCount == 0 ? "no" : enemyCount.ToString() );
			sb.Append( enemyCount == 1 ? " enemy" : " enemies" );


			if ( primary != null )
			{
				sb.Append( ", and a strong presense" );


				switch ( from.Mobile.GetDirectionTo( primary.Mobile ) )
				{
					case Direction.West:
						sb.Append( " to the west." );
						break;
					case Direction.East:
						sb.Append( " to the east." );
						break;
					case Direction.North:
						sb.Append( " to the north." );
						break;
					case Direction.South:
						sb.Append( " to the south." );
						break;


					case Direction.Up:
						sb.Append( " to the north-west." );
						break;
					case Direction.Down:
						sb.Append( " to the south-east." );
						break;
					case Direction.Left:
						sb.Append( " to the south-west." );
						break;
					case Direction.Right:
						sb.Append( " to the north-east." );
						break;
				}
			}
			else
			{
				sb.Append( '.' );
			}


			from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x59, false, sb.ToString() );


			FinishInvoke( from );
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics.Hero
{
	public sealed class HolyShield : Power
	{
		public HolyShield()
		{
			m_Definition = new PowerDefinition(
					20,
					"Holy Shield",
					"Erstok K'blac",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			if ( from.IsShielded )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You are already under the protection of a holy shield." );
				return;
			}


			from.BeginShield();


			from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You are now under the protection of a holy shield." );


			FinishInvoke( from );
		}
	}
}// using System;// using Server;// using Server.Ethics;// using Server.Mobiles;


namespace Server.Mobiles
{
	[CorpseName( "a holy corpse" )]
	public class HolySteed : BaseMount
	{
		public override bool IsDispellable { get{ return false; } }
		public override bool IsBondable { get { return false; } }


		public override bool HasBreath { get { return true; } }
		public override bool CanBreath { get { return true; } }


		[Constructable]
		public HolySteed()
			: base( "a silver steed", 0x75, 0x3EA8, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );


			SetHits( 298, 315 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );


			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 80.5, 92.5 );


			Fame = 14000;
			Karma = 14000;


			VirtualArmor = 60;


			Tamable = false;
			ControlSlots = 1;
		}


		public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }


		public HolySteed( Serial serial )
			: base( serial )
		{
		}


		public override string ApplyNameSuffix( string suffix )
		{
			if ( suffix.Length == 0 )
				suffix = Ethic.Hero.Definition.Adjunct.String;
			else
				suffix = String.Concat( suffix, " ", Ethic.Hero.Definition.Adjunct.String );


			return base.ApplyNameSuffix( suffix );
		}


		public override void OnDoubleClick( Mobile from )
		{
			if ( Ethic.Find( from ) != Ethic.Hero )
				from.SendMessage( "You may not ride this steed." );
			else
				base.OnDoubleClick( from );
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
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;


namespace Server.Ethics.Hero
{
	public sealed class HolySteed : Power
	{
		public HolySteed()
		{
			m_Definition = new PowerDefinition(
					30,
					"Holy Steed",
					"Trubechs Yeliab",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			if ( from.Steed != null && from.Steed.Deleted )
				from.Steed = null;


			if ( from.Steed != null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You already have a holy steed." );
				return;
			}


			if ( ( from.Mobile.Followers + 1 ) > from.Mobile.FollowersMax )
			{
				from.Mobile.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return;
			}


			Mobiles.HolySteed steed = new Mobiles.HolySteed();


			if ( Mobiles.BaseCreature.Summon( steed, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours( 1.0 ) ) )
			{
				from.Steed = steed;


				FinishInvoke( from );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics.Hero
{
	public sealed class HolyWord : Power
	{
		public HolyWord()
		{
			m_Definition = new PowerDefinition(
					100,
					"Holy Word",
					"Erstok Oostrac",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
		}
	}
}// using System;// using Server;// using Server.Mobiles;// using Server.Gumps;// using Server.Targeting;// using Server.Regions;


namespace Server.Factions
{
	public class HorseBreederGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;


		public HorseBreederGump( PlayerMobile from, Faction faction ) : base( 20, 30 )
		{
			m_From = from;
			m_Faction = faction;


			AddPage( 0 );


			AddBackground( 0, 0, 320, 280, 5054 );
			AddBackground( 10, 10, 300, 260, 3000 );


			AddHtmlText( 20, 30, 300, 25, faction.Definition.Header, false, false );


			AddHtmlLocalized( 20, 60, 300, 25, 1018306, false, false ); // Purchase a Faction War Horse
			AddItem( 70, 120, 0x3FFE );


			AddItem( 150, 120, 0xEF2 );
			AddLabel( 190, 122, 0x3E3, FactionWarHorse.SilverPrice.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddItem( 150, 150, 0xEEF );
			AddLabel( 190, 152, 0x3E3, FactionWarHorse.GoldPrice.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddHtmlLocalized( 55, 210, 200, 25, 1011011, false, false ); // CONTINUE
			AddButton( 20, 210, 4005, 4007, 1, GumpButtonType.Reply, 0 );


			AddHtmlLocalized( 55, 240, 200, 25, 1011012, false, false ); // CANCEL
			AddButton( 20, 240, 4005, 4007, 0, GumpButtonType.Reply, 0 );
		}


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID != 1 )
				return;


			if ( Faction.Find( m_From ) != m_Faction )
				return;


			Container pack = m_From.Backpack;


			if ( pack == null )
				return;


			FactionWarHorse horse = new FactionWarHorse( m_Faction );


			if ( (m_From.Followers + horse.ControlSlots) > m_From.FollowersMax )
			{
				// TODO: Message?
				horse.Delete();
			}
			else
			{
				if ( pack.GetAmount( typeof( Silver ) ) < FactionWarHorse.SilverPrice )
				{
					sender.Mobile.SendLocalizedMessage( 1042204 ); // You do not have enough silver.
					horse.Delete();
				}
				else if ( pack.GetAmount( typeof( Gold ) ) < FactionWarHorse.GoldPrice )
				{
					sender.Mobile.SendLocalizedMessage( 1042205 ); // You do not have enough gold.
					horse.Delete();
				}
				else if ( pack.ConsumeTotal( typeof( Silver ), FactionWarHorse.SilverPrice ) && pack.ConsumeTotal( typeof( Gold ), FactionWarHorse.GoldPrice ) )
				{
					horse.Controlled = true;
					horse.ControlMaster = m_From;


					horse.ControlOrder = OrderType.Follow;
					horse.ControlTarget = m_From;


					horse.MoveToWorld( m_From.Location, m_From.Map );
				}
				else
				{
					horse.Delete();
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class IceDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }


		[Constructable]
		public IceDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the ice wyrm";
			Body = 46;
			Hue = 1154;
			BaseSoundID = 362;


			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );


			SetHits( 478, 495 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );


			SetSkill( SkillName.EvalInt, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );


			Fame = 15000;
			Karma = -15000;


			VirtualArmor = 60;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;


			if ( 1 == Utility.RandomMinMax( 0, 2 ) )
			{
				switch ( Utility.RandomMinMax( 0, 5 ) )
				{
					case 0: PackItem( new IcySkinLegs() ); break;
					case 1: PackItem( new IcySkinGloves() ); break;
					case 2: PackItem( new IcySkinGorget() ); break;
					case 3: PackItem( new IcySkinArms() ); break;
					case 4: PackItem( new IcySkinChest() ); break;
					case 5: PackItem( new IcySkinHelm() ); break;
				}
			}


			AddItem( new LighterSource() );
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "ice scales" );
   			c.DropItem(scale);
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Frozen; } else { return HideType.Draconic; } } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public IceDragon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Mobiles;// using Server.Network;


namespace Server.Factions
{
	public class JoinStone : BaseSystemController
	{
		private Faction m_Faction;


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set
			{
				m_Faction = value;


				Hue = ( m_Faction == null ? 0 : m_Faction.Definition.HueJoin );
				AssignName( m_Faction == null ? null : m_Faction.Definition.SignupName );
			}
		}


		public override string DefaultName { get { return "faction signup stone"; } }


		[Constructable]
		public JoinStone() : this( null )
		{
		}


		[Constructable]
		public JoinStone( Faction faction ) : base( 0xEDC )
		{
			Movable = false;
			Faction = faction;
		}


		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Faction == null )
				return;


			if ( !from.InRange( GetWorldLocation(), 2 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else if ( FactionGump.Exists( from ) )
				from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
			else if ( Faction.Find( from ) == null && from is PlayerMobile )
				from.SendGump( new JoinStoneGump( (PlayerMobile) from, m_Faction ) );
		}


		public JoinStone( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			Faction.WriteReference( writer, m_Faction );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			switch ( version )
			{
				case 0:
				{
					Faction = Faction.ReadReference( reader );
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;


namespace Server.Factions
{
	public class JoinStoneGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;


		public JoinStoneGump( PlayerMobile from, Faction faction ) : base( 20, 30 )
		{
			m_From = from;
			m_Faction = faction;


			AddPage( 0 );


			AddBackground( 0, 0, 550, 440, 5054 );
			AddBackground( 10, 10, 530, 420, 3000 );


			AddHtmlText( 20, 30, 510, 20, faction.Definition.Header, false, false );
			AddHtmlText( 20, 130, 510, 100, faction.Definition.About, true, true );


			AddHtmlLocalized( 20, 60, 100, 20, 1011429, false, false ); // Led By : 
			AddHtml( 125, 60, 200, 20, faction.Commander != null ? faction.Commander.Name : "Nobody", false, false );


			AddHtmlLocalized( 20, 80, 100, 20, 1011457, false, false ); // Tithe rate : 
			if ( faction.Tithe >= 0 && faction.Tithe <= 100 && (faction.Tithe % 10) == 0 )
				AddHtmlLocalized( 125, 80, 350, 20, 1011480 + (faction.Tithe / 10), false, false );
			else
				AddHtml( 125, 80, 350, 20, faction.Tithe + "%", false, false );


			AddButton( 20, 400, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 55, 400, 200, 20, 1011425, false, false ); // JOIN THIS FACTION


			AddButton( 300, 400, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 335, 400, 200, 20, 1011012, false, false ); // CANCEL
		}


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
				m_Faction.OnJoinAccepted( m_From );
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class JungleWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }


		[Constructable]
		public JungleWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the jungle wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = 0x7D1;


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Green; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public JungleWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Gumps;// using Server.Mobiles;// using Server.Targeting;


namespace Server.Factions
{
	public class Keywords
	{
		public static void Initialize()
		{
			EventSink.Speech += new SpeechEventHandler( EventSink_Speech );
		}


		private static void ShowScore_Sandbox( object state )
		{
			PlayerState pl = (PlayerState)state;


			if ( pl != null )
				pl.Mobile.PublicOverheadMessage( MessageType.Regular, pl.Mobile.SpeechHue, true, pl.KillPoints.ToString( "N0" ) ); // NOTE: Added 'N0'
		}


		private static void EventSink_Speech( SpeechEventArgs e )
		{
			Mobile from = e.Mobile;
			int[] keywords = e.Keywords;


			for ( int i = 0; i < keywords.Length; ++i )
			{
				switch ( keywords[i] )
				{
					case 0x00E4: // *i wish to access the city treasury*
					{
						Town town = Town.FromRegion( from.Region );


						if ( town == null || !town.IsFinance( from ) || !from.Alive )
							break;


						if ( FactionGump.Exists( from ) )
							from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
						else if ( town.Owner != null && from is PlayerMobile )
							from.SendGump( new FinanceGump( (PlayerMobile)from, town.Owner, town ) );


						break;
					}
					case 0x0ED: // *i am sheriff*
					{
						Town town = Town.FromRegion( from.Region );


						if ( town == null || !town.IsSheriff( from ) || !from.Alive )
							break;


						if ( FactionGump.Exists( from ) )
							from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
						else if ( town.Owner != null )
							from.SendGump( new SheriffGump( (PlayerMobile)from, town.Owner, town ) );


						break;
					}
					case 0x00EF: // *you are fired*
					{
						Town town = Town.FromRegion( from.Region );


						if ( town == null )
							break;


						if ( town.IsFinance( from ) || town.IsSheriff( from ) )
							town.BeginOrderFiring( from );


						break;
					}
					case 0x00E5: // *i wish to resign as finance minister*
					{
						PlayerState pl = PlayerState.Find( from );


						if ( pl != null && pl.Finance != null )
						{
							pl.Finance.Finance = null;
							from.SendLocalizedMessage( 1005081 ); // You have been fired as Finance Minister
						}


						break;
					}
					case 0x00EE: // *i wish to resign as sheriff*
					{
						PlayerState pl = PlayerState.Find( from );


						if ( pl != null && pl.Sheriff != null )
						{
							pl.Sheriff.Sheriff = null;
							from.SendLocalizedMessage( 1010270 ); // You have been fired as Sheriff
						}


						break;
					}
					case 0x00E9: // *what is my faction term status*
					{
						PlayerState pl = PlayerState.Find( from );


						if ( pl != null && pl.IsLeaving )
						{
							if ( Faction.CheckLeaveTimer( from ) )
								break;


							TimeSpan remaining = ( pl.Leaving + Faction.LeavePeriod ) - DateTime.Now;


							if( remaining.TotalDays >= 1 )
								from.SendLocalizedMessage( 1042743, remaining.TotalDays.ToString( "N0" ) ) ;// Your term of service will come to an end in ~1_DAYS~ days.
							else if( remaining.TotalHours >= 1 )
								from.SendLocalizedMessage( 1042741, remaining.TotalHours.ToString( "N0" ) ); // Your term of service will come to an end in ~1_HOURS~ hours.
							else
								from.SendLocalizedMessage( 1042742 ); // Your term of service will come to an end in less than one hour.
						}
						else if ( pl != null )
						{
							from.SendLocalizedMessage( 1042233 ); // You are not in the process of quitting the faction.
						}


						break;
					}
					case 0x00EA: // *message faction*
					{
						Faction faction = Faction.Find( from );


						if ( faction == null || !faction.IsCommander( from ) )
							break;


						if ( from.AccessLevel == AccessLevel.Player && !faction.FactionMessageReady )
							from.SendLocalizedMessage( 1010264 ); // The required time has not yet passed since the last message was sent
						else
							faction.BeginBroadcast( from );


						break;
					}
					case 0x00EC: // *showscore*
					{
						PlayerState pl = PlayerState.Find( from );


						if ( pl != null )
							Timer.DelayCall( TimeSpan.Zero, new TimerStateCallback( ShowScore_Sandbox ), pl );


						break;
					}
					case 0x0178: // i honor your leadership
					{
						Faction faction = Faction.Find( from );


						if ( faction != null )
							faction.BeginHonorLeadership( from );


						break;
					}
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class LavaDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }


		[Constructable]
		public LavaDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the fire wyrm";
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = 0xB71;
			BaseSoundID = 362;


			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );


			SetHits( 478, 495 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 50 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );


			SetSkill( SkillName.EvalInt, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );


			Fame = 15000;
			Karma = -15000;


			VirtualArmor = 60;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;


			if ( 1 == Utility.RandomMinMax( 0, 2 ) )
			{
				switch ( Utility.RandomMinMax( 0, 5 ) )
				{
					case 0: PackItem( new LavaSkinLegs() ); break;
					case 1: PackItem( new LavaSkinGloves() ); break;
					case 2: PackItem( new LavaSkinGorget() ); break;
					case 3: PackItem( new LavaSkinArms() ); break;
					case 4: PackItem( new LavaSkinChest() ); break;
					case 5: PackItem( new LavaSkinHelm() ); break;
				}
			}
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Volcanic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public LavaDragon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using System.Collections;


namespace Server.Engines.MyRunUO
{
	public class LayerComparer : IComparer
	{
		private static Layer PlateArms = (Layer)255;
		private static Layer ChainTunic = (Layer)254;
		private static Layer LeatherShorts = (Layer)253;


		private static Layer[] m_DesiredLayerOrder = new Layer[]
		{
			Layer.Cloak,
			Layer.Bracelet,
			Layer.Ring,
			Layer.Shirt,
			Layer.Pants,
			Layer.InnerLegs,
			Layer.Shoes,
			LeatherShorts,
			Layer.Arms,
			Layer.InnerTorso,
			LeatherShorts,
			PlateArms,
			Layer.MiddleTorso,
			Layer.OuterLegs,
			Layer.Neck,
			Layer.Waist,
			Layer.Gloves,
			Layer.OuterTorso,
			Layer.OneHanded,
			Layer.TwoHanded,
			Layer.FacialHair,
			Layer.Hair,
			Layer.Helm,
			Layer.Talisman
		};


		private static int[] m_TranslationTable;


		public static int[] TranslationTable
		{
			get{ return m_TranslationTable; }
		}


		static LayerComparer()
		{
			m_TranslationTable = new int[256];


			for ( int i = 0; i < m_DesiredLayerOrder.Length; ++i )
				m_TranslationTable[(int)m_DesiredLayerOrder[i]] = m_DesiredLayerOrder.Length - i;
		}


		public static bool IsValid( Item item )
		{
			return ( m_TranslationTable[(int)item.Layer] > 0 );
		}


		public static readonly IComparer Instance = new LayerComparer();


		public LayerComparer()
		{
		}


		public Layer Fix( int itemID, Layer oldLayer )
		{
			if ( itemID == 0x1410 || itemID == 0x1417 ) // platemail arms
				return PlateArms;


			if ( itemID == 0x13BF || itemID == 0x13C4 ) // chainmail tunic
				return ChainTunic;


			if ( itemID == 0x1C08 || itemID == 0x1C09 ) // leather skirt
				return LeatherShorts;


			if ( itemID == 0x1C00 || itemID == 0x1C01 ) // leather shorts
				return LeatherShorts;


			return oldLayer;
		}


		public int Compare( object x, object y )
		{
			Item a = (Item)x;
			Item b = (Item)y;


			Layer aLayer = a.Layer;
			Layer bLayer = b.Layer;


			aLayer = Fix( a.ItemID, aLayer );
			bLayer = Fix( b.ItemID, bLayer );


			return m_TranslationTable[(int)bLayer] - m_TranslationTable[(int)aLayer];
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Guilds;// using Server.Mobiles;// using Server.Network;


namespace Server.Factions
{
	public class LeaveFactionGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;


		public LeaveFactionGump( PlayerMobile from, Faction faction ) : base( 20, 30 )
		{
			m_From = from;
			m_Faction = faction;


			AddBackground( 0, 0, 270, 120, 5054 );
			AddBackground( 10, 10, 250, 100, 3000 );


			if ( from.Guild is Guild && ((Guild)from.Guild).Leader == from )
				AddHtmlLocalized( 20, 15, 230, 60, 1018057, true, true ); // Are you sure you want your entire guild to leave this faction?
			else
				AddHtmlLocalized( 20, 15, 230, 60, 1018063, true, true ); // Are you sure you want to leave this faction?


			AddHtmlLocalized( 55, 80, 75, 20, 1011011, false, false ); // CONTINUE
			AddButton( 20, 80, 4005, 4007, 1, GumpButtonType.Reply, 0 );


			AddHtmlLocalized( 170, 80, 75, 20, 1011012, false, false ); // CANCEL
			AddButton( 135, 80, 4005, 4007, 2, GumpButtonType.Reply, 0 );
		}


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			switch ( info.ButtonID )
			{
				case 1: // continue
				{
					Guild guild = m_From.Guild as Guild;


					if ( guild == null )
					{
						PlayerState pl = PlayerState.Find( m_From );


						if ( pl != null )
						{
							pl.Leaving = DateTime.Now;


							if ( Faction.LeavePeriod == TimeSpan.FromDays( 3.0 ) )
								m_From.SendLocalizedMessage( 1005065 ); // You will be removed from the faction in 3 days
							else
								m_From.SendMessage( "You will be removed from the faction in {0} days.", Faction.LeavePeriod.TotalDays );
						}
					}
					else if ( guild.Leader != m_From )
					{
						m_From.SendLocalizedMessage( 1005061 ); // You cannot quit the faction because you are not the guild master
					}
					else
					{
						m_From.SendLocalizedMessage( 1042285 ); // Your guild is now quitting the faction.


						for ( int i = 0; i < guild.Members.Count; ++i )
						{
							Mobile mob = (Mobile) guild.Members[i];
							PlayerState pl = PlayerState.Find( mob );


							if ( pl != null )
							{
								pl.Leaving = DateTime.Now;


								if ( Faction.LeavePeriod == TimeSpan.FromDays( 3.0 ) )
									mob.SendLocalizedMessage( 1005060 ); // Your guild will quit the faction in 3 days
								else
									mob.SendMessage( "Your guild will quit the faction in {0} days.", Faction.LeavePeriod.TotalDays );
							}
						}
					}


					break;
				}
				case 2: // cancel
				{
					m_From.SendLocalizedMessage( 500737 ); // Canceled resignation.
					break;
				}
			}
		}
	}
}
// using Server;// using System;// using Server.Misc;// using Server.Mobiles;



namespace Server.Mobiles
{
	[CorpseName( "a feline corpse" )]
	public class Lion : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}


		[Constructable]
		public Lion() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a lion";
			Body = 187;
			BaseSoundID = 0x3EE;


			SetStr( 112, 160 );
			SetDex( 120, 190 );
			SetInt( 50, 76 );


			SetHits( 64, 88 );
			SetMana( 0 );


			SetDamage( 8, 16 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 5, 10 );


			SetSkill( SkillName.MagicResist, 15.1, 30.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.Wrestling, 45.1, 60.0 );


			Fame = 750;
			Karma = 0;


			VirtualArmor = 22;


			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 61.1;
		}


		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 10; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 5 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }


		public Lion(Serial serial) : base(serial)
		{
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
			Body = 187;
		}
	}
}
// using System;


namespace Server.Factions
{
	public class Magincia : Town
	{
		public Magincia()
		{
			Definition =
				new TownDefinition(
					7,
					0x1870,
					"Magincia",
					"Magincia",
					new TextDefinition( 1011440, "MAGINCIA" ),
					new TextDefinition( 1011568, "TOWN STONE FOR MAGINCIA" ),
					new TextDefinition( 1041041, "The Faction Sigil Monolith of Magincia" ),
					new TextDefinition( 1041411, "The Faction Town Sigil Monolith of Magincia" ),
					new TextDefinition( 1041420, "Faction Town Stone of Magincia" ),
					new TextDefinition( 1041402, "Faction Town Sigil of Magincia" ),
					new TextDefinition( 1041393, "Corrupted Faction Town Sigil of Magincia" ),
					new Point3D( 3714, 2235, 20 ),
					new Point3D( 3712, 2230, 20 ) );
		}
	}
}
// using System;


namespace Server.Factions
{
	public enum MerchantTitle
	{
		None,
		Scribe,
		Carpenter,
		Blacksmith,
		Bowyer,
		Tialor
	}


	public class MerchantTitleInfo
	{
		private SkillName m_Skill;
		private double m_Requirement;
		private TextDefinition m_Title;
		private TextDefinition m_Label;
		private TextDefinition m_Assigned;


		public SkillName Skill{ get{ return m_Skill; } }
		public double Requirement{ get{ return m_Requirement; } }
		public TextDefinition Title{ get{ return m_Title; } }
		public TextDefinition Label{ get{ return m_Label; } }
		public TextDefinition Assigned{ get{ return m_Assigned; } }


		public MerchantTitleInfo( SkillName skill, double requirement, TextDefinition title, TextDefinition label, TextDefinition assigned )
		{
			m_Skill = skill;
			m_Requirement = requirement;
			m_Title = title;
			m_Label = label;
			m_Assigned = assigned;
		}
	}


	public class MerchantTitles
	{
		private static MerchantTitleInfo[] m_Info = new MerchantTitleInfo[]
			{
				new MerchantTitleInfo( SkillName.Inscribe,		90.0,	new TextDefinition( 1060773, "Scribe" ),		new TextDefinition( 1011468, "SCRIBE" ),		new TextDefinition( 1010121, "You now have the faction title of scribe" ) ),
				new MerchantTitleInfo( SkillName.Carpentry,		90.0,	new TextDefinition( 1060774, "Carpenter" ),		new TextDefinition( 1011469, "CARPENTER" ),		new TextDefinition( 1010122, "You now have the faction title of carpenter" ) ),
				new MerchantTitleInfo( SkillName.Tinkering,		90.0,	new TextDefinition( 1022984, "Tinker" ),		new TextDefinition( 1011470, "TINKER" ),		new TextDefinition( 1010123, "You now have the faction title of tinker" ) ),
				new MerchantTitleInfo( SkillName.Blacksmith,	90.0,	new TextDefinition( 1023016, "Blacksmith" ),	new TextDefinition( 1011471, "BLACKSMITH" ),	new TextDefinition( 1010124, "You now have the faction title of blacksmith" ) ),
				new MerchantTitleInfo( SkillName.Fletching,		90.0,	new TextDefinition( 1023022, "Bowyer" ),		new TextDefinition( 1011472, "BOWYER" ),		new TextDefinition( 1010125, "You now have the faction title of Bowyer" ) ),
				new MerchantTitleInfo( SkillName.Tailoring,		90.0,	new TextDefinition( 1022982, "Tailor" ),		new TextDefinition( 1018300, "TAILOR" ),		new TextDefinition( 1042162, "You now have the faction title of Tailor" ) ),
			};


		public static MerchantTitleInfo[] Info{ get{ return m_Info; } }


		public static MerchantTitleInfo GetInfo( MerchantTitle title )
		{
			int idx = (int)title - 1;


			if ( idx >= 0 && idx < m_Info.Length )
				return m_Info[idx];


			return null;
		}


		public static bool HasMerchantQualifications( Mobile mob )
		{
			for ( int i = 0; i < m_Info.Length; ++i )
			{
				if ( IsQualified( mob, m_Info[i] ) )
					return true;
			}


			return false;
		}


		public static bool IsQualified( Mobile mob, MerchantTitle title )
		{
			return IsQualified( mob, GetInfo( title ) );
		}


		public static bool IsQualified( Mobile mob, MerchantTitleInfo info )
		{
			if ( mob == null || info == null )
				return false;


			return ( mob.Skills[info.Skill].Value >= info.Requirement );
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;


namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class MetalDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }


		[Constructable]
		public MetalDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a metallic dragon";
			Body = 59;
			BaseSoundID = 362;
			Hue = MaterialInfo.GetMaterialColor( "copper", "monster", Hue );


			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );


			SetHits( 478, 495 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );


			SetSkill( SkillName.EvalInt, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );


			Fame = 15000;
			Karma = -15000;


			VirtualArmor = 60;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}


		public override void OnAfterSpawn()
		{
			bool IsChromatic = false;
			switch ( Utility.RandomMinMax( 0, 20 ) )
			{
				case 0: Hue = MaterialInfo.GetMaterialColor( "jade", "monster", 0 ); IsChromatic = true; break;  // jade
				case 1: Hue = MaterialInfo.GetMaterialColor( "onyx", "monster", 0 ); IsChromatic = true; break;  // onyx
				case 2: Hue = MaterialInfo.GetMaterialColor( "quartz", "monster", 0 ); IsChromatic = true; break;  // quartz
				case 3: Hue = MaterialInfo.GetMaterialColor( "ruby", "monster", 0 ); IsChromatic = true; break;  // ruby
				case 4: Hue = MaterialInfo.GetMaterialColor( "sapphire", "monster", 0 ); IsChromatic = true; break;  // sapphire
				case 5: Hue = MaterialInfo.GetMaterialColor( "spinel", "monster", 0 ); IsChromatic = true; break;  // spinel
				case 6: Hue = MaterialInfo.GetMaterialColor( "topaz", "monster", 0 ); IsChromatic = true; break;  // topaz
				case 7: Hue = MaterialInfo.GetMaterialColor( "amethyst", "monster", 0 ); IsChromatic = true; break;  // amethyst
				case 8: Hue = MaterialInfo.GetMaterialColor( "emerald", "monster", 0 ); IsChromatic = true; break;  // emerald
				case 9: Hue = MaterialInfo.GetMaterialColor( "garnet", "monster", 0 ); IsChromatic = true; break;  // garnet
				case 10: Hue = MaterialInfo.GetMaterialColor( "silver", "monster", 0 ); break;  // silver
				case 11: Hue = MaterialInfo.GetMaterialColor( "star ruby", "monster", 0 ); IsChromatic = true; break; // star ruby
				case 12: Hue = MaterialInfo.GetMaterialColor( "copper", "monster", Hue ); break; // Copper
				case 13: Hue = MaterialInfo.GetMaterialColor( "verite", "monster", Hue ); break; // Verite
				case 14: Hue = MaterialInfo.GetMaterialColor( "valorite", "monster", Hue ); break; // Valorite
				case 15: Hue = MaterialInfo.GetMaterialColor( "agapite", "monster", Hue ); break; // Agapite
				case 16: Hue = MaterialInfo.GetMaterialColor( "bronze", "monster", Hue ); break; // Bronze
				case 17: Hue = MaterialInfo.GetMaterialColor( "dull copper", "monster", Hue ); break; // Dull Copper
				case 18: Hue = MaterialInfo.GetMaterialColor( "gold", "monster", Hue ); break; // Gold
				case 19: Hue = MaterialInfo.GetMaterialColor( "shadow iron", "monster", Hue ); break; // Shadow Iron
				case 20:
					if ( Worlds.IsExploringSeaAreas( this ) == true ){ Hue = MaterialInfo.GetMaterialColor( "nepturite", "monster", 0 ); }
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Savaged Empire" ){ Hue = MaterialInfo.GetMaterialColor( "steel", "monster", Hue ); }
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Serpent Island" ){ Hue = MaterialInfo.GetMaterialColor( "obsidian", "monster", Hue ); }
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Island of Umber Veil" ){ Hue = MaterialInfo.GetMaterialColor( "brass", "monster", Hue ); }
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" && this.Map == Map.TerMur ){ Hue = MaterialInfo.GetMaterialColor( "xormite", "monster", Hue ); }
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" ){ Hue = MaterialInfo.GetMaterialColor( "copper", "mithril", Hue ); }
					break; // Special
			}


			if ( IsChromatic ){ this.Name = "a chromatic dragon"; }


			base.OnAfterSpawn();
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			string metal = "Iron";


			if ( this.Hue == MaterialInfo.GetMaterialColor( "onyx", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "onyx scales" );
				c.DropItem(scale);
				metal = "Onyx";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "quartz", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "quartz scales" );
				c.DropItem(scale);
				metal = "Quartz";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "ruby", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "ruby scales" );
				c.DropItem(scale);
				metal = "Ruby";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "sapphire", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "sapphire scales" );
				c.DropItem(scale);
				metal = "Sapphire";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "spinel", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "spinel scales" );
				c.DropItem(scale);
				metal = "Spinel";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "topaz", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "topaz scales" );
				c.DropItem(scale);
				metal = "Topaz";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "amethyst", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "amethyst scales" );
				c.DropItem(scale);
				metal = "Amethyst";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "emerald", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "emerald scales" );
				c.DropItem(scale);
				metal = "Emerald";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "garnet", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "garnet scales" );
				c.DropItem(scale);
				metal = "Garnet";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "silver", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "silver scales" );
				c.DropItem(scale);
				metal = "Silver";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "star ruby", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "star ruby scales" );
				c.DropItem(scale);
				metal = "Star Ruby";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "jade", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "jade scales" );
				c.DropItem(scale);
				metal = "Jade";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "copper", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "copper scales" );
				c.DropItem(scale);
				metal = "Copper";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "verite", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "verite scales" );
				c.DropItem(scale);
				metal = "Verite";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "valorite", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "valorite scales" );
				c.DropItem(scale);
				metal = "Valorite";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "agapite", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "agapite scales" );
				c.DropItem(scale);
				metal = "Agapite";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "bronze", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "bronze scales" );
				c.DropItem(scale);
				metal = "Bronze";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "dull copper", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "dull copper scales" );
				c.DropItem(scale);
				metal = "Dull Copper";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "gold", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "gold scales" );
				c.DropItem(scale);
				metal = "Golden";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "shadow iron", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "shadow iron scales" );
				c.DropItem(scale);
				metal = "Shadow Iron";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "brass", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "brass scales" );
				c.DropItem(scale);
				metal = "Brass";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "steel", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "steel scales" );
				c.DropItem(scale);
				metal = "Steel";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "mithril", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "mithril scales" );
				c.DropItem(scale);
				metal = "Mithril";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "xormite", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "xormite scales" );
				c.DropItem(scale);
				metal = "Xormite";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "obsidian", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "obsidian scales" );
				c.DropItem(scale);
				metal = "Obsidian";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "nepturite", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "nepturite scales" );
				c.DropItem(scale);
				metal = "Nepturite";
			}


			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();


				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", metal, "", c, 25, 0 );
				}
			}
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}


		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public MetalDragon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;


namespace Server.Factions
{
	public class Minax : Faction
	{
		private static Faction m_Instance;


		public static Faction Instance{ get{ return m_Instance; } }


		public Minax()
		{
			m_Instance = this;


			Definition =
				new FactionDefinition(
					0,
					1645, // dark red
					1109, // shadow
					1645, // join stone : dark red
					1645, // broadcast : dark red
					0x78, 0x3EAF, // war horse
					"Minax", "minax", "Min",
					new TextDefinition( 1011534, "MINAX" ),
					new TextDefinition( 1060769, "Minax faction" ),
					new TextDefinition( 1011421, "<center>FOLLOWERS OF MINAX</center>" ),
					new TextDefinition( 1011448,
						"The followers of Minax have taken control in the old lands, " +
						"and intend to hold it for as long as they can. Allying themselves " +
						"with orcs, headless, gazers, trolls, and other beasts, they seek " +
						"revenge against Lord British, for slights both real and imagined, " +
						"though some of the followers wish only to wreak havoc on the " +
						"unsuspecting populace." ),
					new TextDefinition( 1011453, "This city is controlled by Minax." ),
					new TextDefinition( 1042252, "This sigil has been corrupted by the Followers of Minax" ),
					new TextDefinition( 1041043, "The faction signup stone for the Followers of Minax" ),
					new TextDefinition( 1041381, "The Faction Stone of Minax" ),
					new TextDefinition( 1011463, ": Minax" ),
					new TextDefinition( 1005190, "Followers of Minax will now be ignored." ),
					new TextDefinition( 1005191, "Followers of Minax will now be told to go away." ),
					new TextDefinition( 1005192, "Followers of Minax will now be hanged by their toes." ),
					new StrongholdDefinition(
						new Rectangle2D[]
						{
							new Rectangle2D( 5192, 3934, 1, 1 ) // WIZARD
						},
						new Point3D( 1172, 2593, 0 ),
						new Point3D( 1117, 2587, 18 ),
						new Point3D[]
						{
							new Point3D( 1113, 2601, 18 ),
							new Point3D( 1113, 2598, 18 ),
							new Point3D( 1113, 2595, 18 ),
							new Point3D( 1113, 2592, 18 ),
							new Point3D( 1116, 2601, 18 ),
							new Point3D( 1116, 2598, 18 ),
							new Point3D( 1116, 2595, 18 ),
							new Point3D( 1116, 2592, 18 )
						} ),
					new RankDefinition[]
					{
						new RankDefinition( 10, 991, 8, new TextDefinition( 1060784, "Avenger of Mondain" ) ),
						new RankDefinition(  9, 950, 7, new TextDefinition( 1060783, "Dread Knight" ) ),
						new RankDefinition(  8, 900, 6, new TextDefinition( 1060782, "Warlord" ) ),
						new RankDefinition(  7, 800, 6, new TextDefinition( 1060782, "Warlord" ) ),
						new RankDefinition(  6, 700, 5, new TextDefinition( 1060781, "Executioner" ) ),
						new RankDefinition(  5, 600, 5, new TextDefinition( 1060781, "Executioner" ) ),
						new RankDefinition(  4, 500, 5, new TextDefinition( 1060781, "Executioner" ) ),
						new RankDefinition(  3, 400, 4, new TextDefinition( 1060780, "Defiler" ) ),
						new RankDefinition(  2, 200, 4, new TextDefinition( 1060780, "Defiler" ) ),
						new RankDefinition(  1,   0, 4, new TextDefinition( 1060780, "Defiler" ) )
					},
					new GuardDefinition[]
					{
						new GuardDefinition( typeof( FactionHenchman ),		0x1403, 5000, 1000, 10,		new TextDefinition( 1011526, "HENCHMAN" ),		new TextDefinition( 1011510, "Hire Henchman" ) ),
						new GuardDefinition( typeof( FactionMercenary ),	0x0F62, 6000, 2000, 10,		new TextDefinition( 1011527, "MERCENARY" ),		new TextDefinition( 1011511, "Hire Mercenary" ) ),
						new GuardDefinition( typeof( FactionBerserker ),	0x0F4B, 7000, 3000, 10,		new TextDefinition( 1011505, "BERSERKER" ),		new TextDefinition( 1011499, "Hire Berserker" ) ),
						new GuardDefinition( typeof( FactionDragoon ),		0x1439, 8000, 4000, 10,		new TextDefinition( 1011506, "DRAGOON" ),		new TextDefinition( 1011500, "Hire Dragoon" ) ),
					}
				);
		}
	}
}
// using System;


namespace Server.Factions
{
	public class Minoc : Town
	{
		public Minoc()
		{
			Definition =
				new TownDefinition(
					2,
					0x186B,
					"Minoc",
					"Minoc",
					new TextDefinition( 1011437, "MINOC" ),
					new TextDefinition( 1011564, "TOWN STONE FOR MINOC" ),
					new TextDefinition( 1041036, "The Faction Sigil Monolith of Minoc" ),
					new TextDefinition( 1041406, "The Faction Town Sigil Monolith Minoc" ),
					new TextDefinition( 1041415, "Faction Town Stone of Minoc" ),
					new TextDefinition( 1041397, "Faction Town Sigil of Minoc" ),
					new TextDefinition( 1041388, "Corrupted Faction Town Sigil of Minoc" ),
					new Point3D( 2471, 439, 15 ),
					new Point3D( 2469, 445, 15 ) );
		}
	}
}
// using System;


namespace Server.Factions
{
	public class Moonglow : Town
	{
		public Moonglow()
		{
			Definition =
				new TownDefinition(
					3,
					0x186C,
					"Moonglow",
					"Moonglow",
					new TextDefinition( 1011435, "MOONGLOW" ),
					new TextDefinition( 1011563, "TOWN STONE FOR MOONGLOW" ),
					new TextDefinition( 1041037, "The Faction Sigil Monolith of Moonglow" ),
					new TextDefinition( 1041407, "The Faction Town Sigil Monolith of Moonglow" ),
					new TextDefinition( 1041416, "Faction Town Stone of Moonglow" ),
					new TextDefinition( 1041398, "Faction Town Sigil of Moonglow" ),
					new TextDefinition( 1041389, "Corrupted Faction Town Sigil of Moonglow" ),
					new Point3D( 4436, 1083, 0 ),
					new Point3D( 4432, 1086, 0 ) );
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class MountainWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 1 ); }


		[Constructable]
		public MountainWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the mountain wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = 0x360;


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Black; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public MountainWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using System.IO;// using System.Text;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Misc;// using Server.Items;// using Server.Guilds;// using Server.Mobiles;// using Server.Accounting;// using Server.Commands;


namespace Server.Engines.MyRunUO
{
	public class MyRunUO : Timer
	{
		private static double CpuInterval = 0.1; // Processor runs every 0.1 seconds
		private static double CpuPercent = 0.25; // Processor runs for 25% of Interval, or ~25ms. This should take around 25% cpu


		public static void Initialize()
		{
			if ( Config.Enabled )
			{
				Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), Config.CharacterUpdateInterval, new TimerCallback( Begin ) );


				CommandSystem.Register( "UpdateMyRunUO", AccessLevel.Administrator, new CommandEventHandler( UpdateMyRunUO_OnCommand ) );


				//CommandSystem.Register( "PublicChar", AccessLevel.Player, new CommandEventHandler( PublicChar_OnCommand ) );
				//CommandSystem.Register( "PrivateChar", AccessLevel.Player, new CommandEventHandler( PrivateChar_OnCommand ) );
			}
		}

/*
		[Usage( "PublicChar" )]
		[Description( "Enables showing extended character stats and skills in MyRunUO." )]
		public static void PublicChar_OnCommand( CommandEventArgs e )
		{
			PlayerMobile pm = e.Mobile as PlayerMobile;


			if ( pm != null )
			{
				if ( pm.PublicMyRunUO )
				{
					pm.SendMessage( "You have already chosen to show your skills and stats." );
				}
				else
				{
					pm.PublicMyRunUO = true;
					pm.SendMessage( "All of your skills and stats will now be shown publicly in MyRunUO." );
				}
			}
		}


		[Usage( "PrivateChar" )]
		[Description( "Disables showing extended character stats and skills in MyRunUO." )]
		public static void PrivateChar_OnCommand( CommandEventArgs e )
		{
			PlayerMobile pm = e.Mobile as PlayerMobile;


			if ( pm != null )
			{
				if ( !pm.PublicMyRunUO )
				{
					pm.SendMessage( "You have already chosen to not show your skills and stats." );
				}
				else
				{
					pm.PublicMyRunUO = false;
					pm.SendMessage( "Only a general level of your top three skills will be shown in MyRunUO." );
				}
			}
		}
*/

		[Usage( "UpdateMyRunUO" )]
		[Description( "Starts the process of updating the MyRunUO character and guild database." )]
		public static void UpdateMyRunUO_OnCommand( CommandEventArgs e )
		{
			if ( m_Command != null && m_Command.HasCompleted )
				m_Command = null;


			if ( m_Timer == null && m_Command == null )
			{
				Begin();
				e.Mobile.SendMessage( "MyRunUO update process has been started." );
			}
			else
			{
				e.Mobile.SendMessage( "MyRunUO database is already being updated." );
			}
		}


		public static void Begin()
		{
			if ( m_Command != null && m_Command.HasCompleted )
				m_Command = null;


			if ( m_Timer != null || m_Command != null )
				return;


			m_Timer = new MyRunUO();
			m_Timer.Start();
		}


		private static Timer m_Timer;


		private Stage m_Stage;
		private ArrayList m_List;
		private List<IAccount> m_Collecting;
		private int m_Index;


		private static DatabaseCommandQueue m_Command;


		private string m_SkillsPath;
		private string m_LayersPath;
		private string m_MobilesPath;


		private StreamWriter m_OpSkills;
		private StreamWriter m_OpLayers;
		private StreamWriter m_OpMobiles;


		private DateTime m_StartTime;


		public MyRunUO() : base( TimeSpan.FromSeconds( CpuInterval ), TimeSpan.FromSeconds( CpuInterval ) )
		{
			m_List = new ArrayList();
			m_Collecting = new List<IAccount>();


			m_StartTime = DateTime.Now;
			Console.WriteLine( "MyRunUO: Updating character database" );
		}


		protected override void OnTick()
		{
			bool shouldExit = false;


			try
			{
				shouldExit = Process( DateTime.Now + TimeSpan.FromSeconds( CpuInterval * CpuPercent ) );


				if ( shouldExit )
					Console.WriteLine( "MyRunUO: Database statements compiled in {0:F2} seconds", (DateTime.Now - m_StartTime).TotalSeconds );
			}
			catch ( Exception e )
			{
				Console.WriteLine( "MyRunUO: {0}: Exception cought while processing", m_Stage );
				Console.WriteLine( e );
				shouldExit = true;
			}


			if ( shouldExit )
			{
				m_Command.Enqueue( null );


				Stop();
				m_Timer = null;
			}
		}


		private enum Stage
		{
			CollectingMobiles,
			DumpingMobiles,
			CollectingGuilds,
			DumpingGuilds,
			Complete
		}


		public bool Process( DateTime endTime )
		{
			switch ( m_Stage )
			{
				case Stage.CollectingMobiles: CollectMobiles( endTime ); break;
				case Stage.DumpingMobiles: DumpMobiles( endTime ); break;
				case Stage.CollectingGuilds: CollectGuilds( endTime ); break;
				case Stage.DumpingGuilds: DumpGuilds( endTime ); break;
			}


			return ( m_Stage == Stage.Complete );
		}


		private static ArrayList m_MobilesToUpdate = new ArrayList();


		public static void QueueMobileUpdate( Mobile m )
		{
			if ( !Config.Enabled || Config.LoadDataInFile )
				return;


			m_MobilesToUpdate.Add( m );
		}


		public void CollectMobiles( DateTime endTime )
		{
			if ( Config.LoadDataInFile )
			{
				if ( m_Index == 0 )
					 m_Collecting.AddRange( Accounts.GetAccounts() );


				for ( int i = m_Index; i < m_Collecting.Count; ++i )
				{
					IAccount acct = m_Collecting[i];


					for ( int j = 0; j < acct.Length; ++j )
					{
						Mobile mob = acct[j];


						if ( mob != null && mob.AccessLevel < Config.HiddenAccessLevel )
							m_List.Add( mob );
					}


					++m_Index;


					if ( DateTime.Now >= endTime )
						break;
				}


				if ( m_Index == m_Collecting.Count )
				{
					m_Collecting = new List<IAccount>();
					m_Stage = Stage.DumpingMobiles;
					m_Index = 0;
				}
			}
			else
			{
				m_List = m_MobilesToUpdate;
				m_MobilesToUpdate = new ArrayList();
				m_Stage = Stage.DumpingMobiles;
				m_Index = 0;
			}
		}


		public void CheckConnection()
		{
			if ( m_Command == null )
			{
				m_Command = new DatabaseCommandQueue( "MyRunUO: Characeter database updated in {0:F1} seconds", "MyRunUO Character Database Thread" );


				if ( Config.LoadDataInFile )
				{
					m_OpSkills = GetUniqueWriter( "skills", out m_SkillsPath );
					m_OpLayers = GetUniqueWriter( "layers", out m_LayersPath );
					m_OpMobiles = GetUniqueWriter( "mobiles", out m_MobilesPath );


					m_Command.Enqueue( "TRUNCATE TABLE myrunuo_characters" );
					m_Command.Enqueue( "TRUNCATE TABLE myrunuo_characters_layers" );
					m_Command.Enqueue( "TRUNCATE TABLE myrunuo_characters_skills" );
				}


				m_Command.Enqueue( "TRUNCATE TABLE myrunuo_guilds" );
				m_Command.Enqueue( "TRUNCATE TABLE myrunuo_guilds_wars" );
			}
		}


		public void ExecuteNonQuery( string text )
		{
			m_Command.Enqueue( text );
		}


		public void ExecuteNonQuery( string format, params string[] args )
		{
			ExecuteNonQuery( String.Format( format, args ) );
		}


		public void ExecuteNonQueryIfNull( string select, string insert )
		{
			m_Command.Enqueue( new string[]{ select, insert } );
		}


		private void AppendCharEntity( string input, int charIndex, ref StringBuilder sb, char c )
		{
			if ( sb == null )
			{
				if ( charIndex > 0 )
					sb = new StringBuilder( input, 0, charIndex, input.Length + 20 );
				else
					sb = new StringBuilder( input.Length + 20 );
			}


			sb.Append( "&#" );
			sb.Append( (int)c );
			sb.Append( ";" );
		}


		private void AppendEntityRef( string input, int charIndex, ref StringBuilder sb, string ent )
		{
			if ( sb == null )
			{
				if ( charIndex > 0 )
					sb = new StringBuilder( input, 0, charIndex, input.Length + 20 );
				else
					sb = new StringBuilder( input.Length + 20 );
			}


			sb.Append( ent );
		}
 
		private string SafeString( string input )
		{
			if ( input == null )
				return "";


			StringBuilder sb = null;


			for ( int i = 0; i < input.Length; ++i )
			{
				char c = input[i];


				if ( c < 0x20 || c > 0x80 )
				{
					AppendCharEntity( input, i, ref sb, c );
				}
				else
				{
					switch ( c )
					{
						case '&':	AppendEntityRef( input, i, ref sb, "&amp;" ); break;
						case '>':	AppendEntityRef( input, i, ref sb, "&gt;" ); break;
						case '<':	AppendEntityRef( input, i, ref sb, "&lt;" ); break;
						case '"':	AppendEntityRef( input, i, ref sb, "&quot;" ); break;
						case '\'':
						case ':':
						case '/':
						case '\\':	AppendCharEntity( input, i, ref sb, c ); break;
						default:
						{
							if ( sb != null )
								sb.Append( c );


							break;
						}
					}
				}
			}


			if ( sb != null )
				return sb.ToString();


			return input;
		}


		public const char LineStart = '\"';
		public const string EntrySep = "\",\"";
		public const string LineEnd = "\"\n";


		public void InsertMobile( Mobile mob )
		{
			string guildTitle = mob.GuildTitle;


			if ( guildTitle == null || (guildTitle = guildTitle.Trim()).Length == 0 )
				guildTitle = "NULL";
			else
				guildTitle = SafeString( guildTitle );


			string notoTitle = SafeString( Titles.ComputeTitle( null, mob ) );
			string female = ( mob.Female ? "1" : "0" );
			
			bool pubBool = ( mob is PlayerMobile ) ;


			string pubString = ( pubBool ? "1" : "0" );


			string guildId = ( mob.Guild == null ? "NULL" : mob.Guild.Id.ToString() );


			if ( Config.LoadDataInFile )
			{
				m_OpMobiles.Write( LineStart );
				m_OpMobiles.Write( mob.Serial.Value );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( SafeString( mob.Name ) );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( mob.RawStr );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( mob.RawDex );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( mob.RawInt );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( female );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( mob.Kills );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( guildId );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( guildTitle );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( notoTitle );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( mob.Hue );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( pubString );
				m_OpMobiles.Write( LineEnd );
			}
			else
			{
				ExecuteNonQuery( "INSERT INTO myrunuo_characters (char_id, char_name, char_str, char_dex, char_int, char_female, char_counts, char_guild, char_guildtitle, char_nototitle, char_bodyhue, char_public ) VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8}, '{9}', {10}, {11})", mob.Serial.Value.ToString(), SafeString( mob.Name ), mob.RawStr.ToString(), mob.RawDex.ToString(), mob.RawInt.ToString(), female, mob.Kills.ToString(), guildId, guildTitle, notoTitle, mob.Hue.ToString(), pubString );
			}
		}


		public void InsertSkills( Mobile mob )
		{
			Skills skills = mob.Skills;
			string serial = mob.Serial.Value.ToString();


			for ( int i = 0; i < skills.Length; ++i )
			{
				Skill skill = skills[i];


				if ( skill.BaseFixedPoint > 0 )
				{
					if ( Config.LoadDataInFile )
					{
						m_OpSkills.Write( LineStart );
						m_OpSkills.Write( serial );
						m_OpSkills.Write( EntrySep );
						m_OpSkills.Write( i );
						m_OpSkills.Write( EntrySep );
						m_OpSkills.Write( skill.BaseFixedPoint );
						m_OpSkills.Write( LineEnd );
					}
					else
					{
						ExecuteNonQuery( "INSERT INTO myrunuo_characters_skills (char_id, skill_id, skill_value) VALUES ({0}, {1}, {2})", serial, i.ToString(), skill.BaseFixedPoint.ToString() );
					}
				}
			}
		}


		private ArrayList m_Items = new ArrayList();


		private void InsertItem( string serial, int index, int itemID, int hue )
		{
			if ( Config.LoadDataInFile )
			{
				m_OpLayers.Write( LineStart );
				m_OpLayers.Write( serial );
				m_OpLayers.Write( EntrySep );
				m_OpLayers.Write( index );
				m_OpLayers.Write( EntrySep );
				m_OpLayers.Write( itemID );
				m_OpLayers.Write( EntrySep );
				m_OpLayers.Write( hue );
				m_OpLayers.Write( LineEnd );
			}
			else
			{
				ExecuteNonQuery( "INSERT INTO myrunuo_characters_layers (char_id, layer_id, item_id, item_hue) VALUES ({0}, {1}, {2}, {3})", serial, index.ToString(), itemID.ToString(), hue.ToString() );
			}
		}


		public void InsertItems( Mobile mob )
		{
			ArrayList items = m_Items;
			items.AddRange( mob.Items );
			string serial = mob.Serial.Value.ToString();


			items.Sort( LayerComparer.Instance );


			int index = 0;


			bool hidePants = false;
			bool alive = mob.Alive;
			bool hideHair = !alive;


			for ( int i = 0; i < items.Count; ++i )
			{
				Item item = (Item)items[i];


				if ( !LayerComparer.IsValid( item ) )
					break;


				if ( !alive && item.ItemID != 8270 )
					continue;


				if ( item.ItemID == 0x1411 || item.ItemID == 0x141A ) // plate legs
					hidePants = true;
				else if ( hidePants && item.Layer == Layer.Pants )
					continue;


				if ( !hideHair && item.Layer == Layer.Helm )
					hideHair = true;


				InsertItem( serial, index++, item.ItemID, item.Hue );
			}


			if ( mob.FacialHairItemID != 0 && alive )
				InsertItem( serial, index++, mob.FacialHairItemID, mob.FacialHairHue );


			if ( mob.HairItemID != 0 && !hideHair )
				InsertItem( serial, index++, mob.HairItemID, mob.HairHue );


			items.Clear();
		}


		public void DeleteMobile( Mobile mob )
		{
			ExecuteNonQuery( "DELETE FROM myrunuo_characters WHERE char_id = {0}", mob.Serial.Value.ToString() );
			ExecuteNonQuery( "DELETE FROM myrunuo_characters_skills WHERE char_id = {0}", mob.Serial.Value.ToString() );
			ExecuteNonQuery( "DELETE FROM myrunuo_characters_layers WHERE char_id = {0}", mob.Serial.Value.ToString() );
		}


		public StreamWriter GetUniqueWriter( string type, out string filePath )
		{
			filePath = Path.Combine( Core.BaseDirectory, String.Format( "myrunuodb_{0}.txt", type ) ).Replace( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar );


			try
			{
				return new StreamWriter( filePath );
			}
			catch
			{
				for ( int i = 0; i < 100; ++i )
				{
					try
					{
						filePath = Path.Combine( Core.BaseDirectory, String.Format( "myrunuodb_{0}_{1}.txt", type, i ) ).Replace( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar );
						return new StreamWriter( filePath );
					}
					catch
					{
					}
				}
			}


			return null;
		}


		public void DumpMobiles( DateTime endTime )
		{
			CheckConnection();


			for ( int i = m_Index; i < m_List.Count; ++i )
			{
				Mobile mob = (Mobile)m_List[i];


				if ( mob is PlayerMobile )
					((PlayerMobile)mob).ChangedMyRunUO = false;


				if ( !mob.Deleted && mob.AccessLevel < Config.HiddenAccessLevel )
				{
					if ( !Config.LoadDataInFile )
						DeleteMobile( mob );


					InsertMobile( mob );
					InsertSkills( mob );
					InsertItems( mob );
				}
				else if ( !Config.LoadDataInFile )
				{
					DeleteMobile( mob );
				}


				++m_Index;


				if ( DateTime.Now >= endTime )
					break;
			}


			if ( m_Index == m_List.Count )
			{
				m_List.Clear();
				m_Stage = Stage.CollectingGuilds;
				m_Index = 0;


				if ( Config.LoadDataInFile )
				{
					m_OpSkills.Close();
					m_OpLayers.Close();
					m_OpMobiles.Close();


					ExecuteNonQuery( "LOAD DATA {0}INFILE '{1}' INTO TABLE myrunuo_characters FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'", Config.DatabaseNonLocal ? "LOCAL " : "", m_MobilesPath );
					ExecuteNonQuery( "LOAD DATA {0}INFILE '{1}' INTO TABLE myrunuo_characters_skills FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'", Config.DatabaseNonLocal ? "LOCAL " : "", m_SkillsPath );
					ExecuteNonQuery( "LOAD DATA {0}INFILE '{1}' INTO TABLE myrunuo_characters_layers FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'", Config.DatabaseNonLocal ? "LOCAL " : "", m_LayersPath );
				}
			}
		}


		public void CollectGuilds( DateTime endTime )
		{
			m_List.AddRange( Guild.List.Values );
			m_Stage = Stage.DumpingGuilds;
			m_Index = 0;
		}


		public void InsertGuild( Guild guild )
		{
			string guildType = "Standard";


			switch ( guild.Type )
			{
				case GuildType.Chaos: guildType = "Chaos"; break;
				case GuildType.Order: guildType = "Order"; break;
			}


			ExecuteNonQuery( "INSERT INTO myrunuo_guilds (guild_id, guild_name, guild_abbreviation, guild_website, guild_charter, guild_type, guild_wars, guild_members, guild_master) VALUES ({0}, '{1}', {2}, {3}, {4}, '{5}', {6}, {7}, {8})", guild.Id.ToString(), SafeString( guild.Name ), guild.Abbreviation == "none" ? "NULL" : "'" + SafeString( guild.Abbreviation ) + "'", guild.Website == null ? "NULL" : "'" + SafeString( guild.Website ) + "'", guild.Charter == null ? "NULL" : "'" + SafeString( guild.Charter ) + "'", guildType, guild.Enemies.Count.ToString(), guild.Members.Count.ToString(), guild.Leader.Serial.Value.ToString() );
		}


		public void InsertWars( Guild guild )
		{
			List<Guild> wars = guild.Enemies;


			string ourId = guild.Id.ToString();


			for ( int i = 0; i < wars.Count; ++i )
			{
				Guild them = wars[i];
				string theirId = them.Id.ToString();


				ExecuteNonQueryIfNull(
					String.Format( "SELECT guild_1 FROM myrunuo_guilds_wars WHERE (guild_1={0} AND guild_2={1}) OR (guild_1={1} AND guild_2={0})", ourId, theirId ),
					String.Format( "INSERT INTO myrunuo_guilds_wars (guild_1, guild_2) VALUES ({0}, {1})", ourId, theirId ) );
			}
		}


		public void DumpGuilds( DateTime endTime )
		{
			CheckConnection();


			for ( int i = m_Index; i < m_List.Count; ++i )
			{
				Guild guild = (Guild)m_List[i];


				if ( !guild.Disbanded )
				{
					InsertGuild( guild );
					InsertWars( guild );
				}


				++m_Index;


				if ( DateTime.Now >= endTime )
					break;
			}


			if ( m_Index == m_List.Count )
			{
				m_List.Clear();
				m_Stage = Stage.Complete;
				m_Index = 0;
			}
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Commands;// using Server.Network;


namespace Server.Engines.MyRunUO
{
	public class MyRunUOStatus
	{
		public static void Initialize()
		{
			if ( Config.Enabled )
			{
				Timer.DelayCall( TimeSpan.FromSeconds( 20.0 ), Config.StatusUpdateInterval, new TimerCallback( Begin ) );


				CommandSystem.Register( "UpdateWebStatus", AccessLevel.Administrator, new CommandEventHandler( UpdateWebStatus_OnCommand ) );
			}
		}


		[Usage( "UpdateWebStatus" )]
		[Description( "Starts the process of updating the MyRunUO online status database." )]
		public static void UpdateWebStatus_OnCommand( CommandEventArgs e )
		{
			if ( m_Command == null || m_Command.HasCompleted )
			{
				Begin();
				e.Mobile.SendMessage( "Web status update process has been started." );
			}
			else
			{
				e.Mobile.SendMessage( "Web status database is already being updated." );
			}
		}


		private static DatabaseCommandQueue m_Command;


		public static void Begin()
		{
			if ( m_Command != null && !m_Command.HasCompleted )
				return;


			DateTime start = DateTime.Now;
			Console.WriteLine( "MyRunUO: Updating status database" );


			try
			{
				m_Command = new DatabaseCommandQueue( "MyRunUO: Status database updated in {0:F1} seconds", "MyRunUO Status Database Thread" );


				m_Command.Enqueue( "DELETE FROM myrunuo_status" );


				List<NetState> online = NetState.Instances;


				for ( int i = 0; i < online.Count; ++i )
				{
					NetState ns = online[i];
					Mobile mob = ns.Mobile;


					if ( mob != null )
						m_Command.Enqueue( String.Format( "INSERT INTO myrunuo_status VALUES ({0})", mob.Serial.Value.ToString() ) );
				}
			}
			catch ( Exception e )
			{
				Console.WriteLine( "MyRunUO: Error updating status database" );
				Console.WriteLine( e );
			}


			if ( m_Command != null )
				m_Command.Enqueue( null );
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class NightWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 20; } }
		public override int BreathFireDamage{ get{ return 20; } }
		public override int BreathColdDamage{ get{ return 20; } }
		public override int BreathPoisonDamage{ get{ return 20; } }
		public override int BreathEnergyDamage{ get{ return 20; } }
		public override int BreathEffectHue{ get{ return 0x496; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override int BreathEffectItemID{ get{ return 0x37BC; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 23 ); }


		[Constructable]
		public NightWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the night wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = 0x8FD;


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Black; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public NightWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class OnyxWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 20; } }
		public override int BreathFireDamage{ get{ return 20; } }
		public override int BreathColdDamage{ get{ return 20; } }
		public override int BreathPoisonDamage{ get{ return 20; } }
		public override int BreathEnergyDamage{ get{ return 20; } }
		public override int BreathEffectHue{ get{ return 0x496; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override int BreathEffectItemID{ get{ return 0x37BC; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 23 ); }


		[Constructable]
		public OnyxWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the onyx wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "onyx", "monster", 0 );


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "onyx scales" );
   			c.DropItem(scale);
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public OnyxWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;


namespace Server.Factions.AI
{
	public enum ReactionType
	{
		Ignore,
		Warn,
		Attack
	}


	public enum MovementType
	{
		Stand,
		Patrol,
		Follow
	}


	public class Reaction
	{
		private Faction m_Faction;
		private ReactionType m_Type;


		public Faction Faction{ get{ return m_Faction; } }
		public ReactionType Type{ get{ return m_Type; } set{ m_Type = value; } }


		public Reaction( Faction faction, ReactionType type )
		{
			m_Faction = faction;
			m_Type = type;
		}


		public Reaction( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 0:
				{
					m_Faction = Faction.ReadReference( reader );
					m_Type = (ReactionType) reader.ReadEncodedInt();


					break;
				}
			}
		}


		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 ); // version


			Faction.WriteReference( writer, m_Faction );
			writer.WriteEncodedInt( (int) m_Type );
		}
	}


	public class Orders
	{
		private BaseFactionGuard m_Guard;


		private List<Reaction> m_Reactions;
		private MovementType m_Movement;
		private Mobile m_Follow;


		public BaseFactionGuard Guard{ get{ return m_Guard; } }


		public MovementType Movement{ get{ return m_Movement; } set{ m_Movement = value; } }
		public Mobile Follow{ get{ return m_Follow; } set{ m_Follow = value; } }


		public Reaction GetReaction( Faction faction )
		{
			Reaction reaction;


			for ( int i = 0; i < m_Reactions.Count; ++i )
			{
				reaction = m_Reactions[i];


				if ( reaction.Faction == faction )
					return reaction;
			}


			reaction = new Reaction( faction, ( faction == null || faction == m_Guard.Faction ) ? ReactionType.Ignore : ReactionType.Attack );
			m_Reactions.Add( reaction );


			return reaction;
		}


		public void SetReaction( Faction faction, ReactionType type )
		{
			Reaction reaction = GetReaction( faction );


			reaction.Type = type;
		}


		public Orders( BaseFactionGuard guard )
		{
			m_Guard = guard;
			m_Reactions = new List<Reaction>();
			m_Movement = MovementType.Patrol;
		}


		public Orders( BaseFactionGuard guard, GenericReader reader )
		{
			m_Guard = guard;


			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 1:
				{
					m_Follow = reader.ReadMobile();
					goto case 0;
				}
				case 0:
				{
					int count = reader.ReadEncodedInt();
					m_Reactions = new List<Reaction>( count );


					for ( int i = 0; i < count; ++i )
						m_Reactions.Add( new Reaction( reader ) );


					m_Movement = (MovementType)reader.ReadEncodedInt();


					break;
				}
			}
		}


		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 1 ); // version


			writer.Write( (Mobile) m_Follow );


			writer.WriteEncodedInt( (int) m_Reactions.Count );


			for ( int i = 0; i < m_Reactions.Count; ++i )
				m_Reactions[i].Serialize( writer );


			writer.WriteEncodedInt( (int) m_Movement );
		}
	}
}
// using System;// using Server;


namespace Server.Factions
{
	public class FactionPersistance : Item
	{
		private static FactionPersistance m_Instance;


		public static FactionPersistance Instance{ get{ return m_Instance; } }


		public override string DefaultName
		{
			get { return "Faction Persistance - Internal"; }
		}


		public FactionPersistance() : base( 1 )
		{
			Movable = false;


			if ( m_Instance == null || m_Instance.Deleted )
				m_Instance = this;
			else
				base.Delete();
		}


		private enum PersistedType
		{
			Terminator,
			Faction,
			Town
		}


		public FactionPersistance( Serial serial ) : base( serial )
		{
			m_Instance = this;
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			List<Faction> factions = Faction.Factions;


			for ( int i = 0; i < factions.Count; ++i )
			{
				writer.WriteEncodedInt( (int) PersistedType.Faction );
				factions[i].State.Serialize( writer );
			}


			List<Town> towns = Town.Towns;


			for ( int i = 0; i < towns.Count; ++i )
			{
				writer.WriteEncodedInt( (int) PersistedType.Town );
				towns[i].State.Serialize( writer );
			}


			writer.WriteEncodedInt( (int) PersistedType.Terminator );
		}


		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			switch ( version )
			{
				case 0:
				{
					PersistedType type;


					while ( (type = (PersistedType)reader.ReadEncodedInt()) != PersistedType.Terminator )
					{
						switch ( type )
						{
							case PersistedType.Faction: new FactionState( reader ); break;
							case PersistedType.Town: new TownState( reader ); break;
						}
					}


					break;
				}
			}
		}


		public override void Delete()
		{
		}
	}
}
// using System;


namespace Server.Ethics
{
	public class EthicsPersistance : Item
	{
		private static EthicsPersistance m_Instance;


		public static EthicsPersistance Instance { get { return m_Instance; } }


		public override string DefaultName
		{
			get { return "Ethics Persistance - Internal"; }
		}


		[Constructable]
		public EthicsPersistance()
			: base( 1 )
		{
			Movable = false;


			if ( m_Instance == null || m_Instance.Deleted )
				m_Instance = this;
			else
				base.Delete();
		}


		public EthicsPersistance( Serial serial )
			: base( serial )
		{
			m_Instance = this;
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			for ( int i = 0; i < Ethics.Ethic.Ethics.Length; ++i )
				Ethics.Ethic.Ethics[i].Serialize( writer );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			switch ( version )
			{
				case 0:
				{
					for ( int i = 0; i < Ethics.Ethic.Ethics.Length; ++i )
						Ethics.Ethic.Ethics[i].Deserialize( reader );


					break;
				}
			}
		}


		public override void Delete()
		{
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;


namespace Server.Ethics
{
	public class PlayerCollection : System.Collections.ObjectModel.Collection<Player>
	{
	}


	[PropertyObject]
	public class Player
	{
		public static Player Find( Mobile mob )
		{
			return Find( mob, false );
		}


		public static Player Find( Mobile mob, bool inherit )
		{
			PlayerMobile pm = mob as PlayerMobile;


			if ( pm == null )
			{
				if ( inherit && mob is BaseCreature )
				{
					BaseCreature bc = mob as BaseCreature;


					if ( bc != null && bc.Controlled )
						pm = bc.ControlMaster as PlayerMobile;
					else if ( bc != null && bc.Summoned )
						pm = bc.SummonMaster as PlayerMobile;
				}


				if ( pm == null )
					return null;
			}


			Player pl = pm.EthicPlayer;


			if ( pl != null && !pl.Ethic.IsEligible( pl.Mobile ) )
				pm.EthicPlayer = pl = null;


			return pl;
		}


		private Ethic m_Ethic;
		private Mobile m_Mobile;


		private int m_Power;
		private int m_History;


		private Mobile m_Steed;
		private Mobile m_Familiar;


		private DateTime m_Shield;


		public Ethic Ethic { get { return m_Ethic; } }
		public Mobile Mobile { get { return m_Mobile; } }


		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public int Power { get { return m_Power; } set { m_Power = value; } }


		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public int History { get { return m_History; } set { m_History = value; } }


		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public Mobile Steed { get { return m_Steed; } set { m_Steed = value; } }


		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public Mobile Familiar { get { return m_Familiar; } set { m_Familiar = value; } }


		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsShielded
		{
			get
			{
				if ( m_Shield == DateTime.MinValue )
					return false;


				if ( DateTime.Now < ( m_Shield + TimeSpan.FromHours( 1.0 ) ) )
					return true;


				FinishShield();
				return false;
			}
		}


		public void BeginShield()
		{
			m_Shield = DateTime.Now;
		}


		public void FinishShield()
		{
			m_Shield = DateTime.MinValue;
		}


		public Player( Ethic ethic, Mobile mobile )
		{
			m_Ethic = ethic;
			m_Mobile = mobile;


			m_Power = 5;
			m_History = 5;
		}


		public void CheckAttach()
		{
			if ( m_Ethic.IsEligible( m_Mobile ) )
				Attach();
		}


		public void Attach()
		{
			if ( m_Mobile is PlayerMobile )
				( m_Mobile as PlayerMobile ).EthicPlayer = this;


			m_Ethic.Players.Add( this );
		}


		public void Detach()
		{
			if ( m_Mobile is PlayerMobile )
				( m_Mobile as PlayerMobile ).EthicPlayer = null;


			m_Ethic.Players.Remove( this );
		}


		public Player( Ethic ethic, GenericReader reader )
		{
			m_Ethic = ethic;


			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 0:
				{
					m_Mobile = reader.ReadMobile();


					m_Power = reader.ReadEncodedInt();
					m_History = reader.ReadEncodedInt();


					m_Steed = reader.ReadMobile();
					m_Familiar = reader.ReadMobile();


					m_Shield = reader.ReadDeltaTime();


					break;
				}
			}
		}


		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( 0 ); // version


			writer.Write( m_Mobile );


			writer.WriteEncodedInt( m_Power );
			writer.WriteEncodedInt( m_History );


			writer.Write( m_Steed );
			writer.Write( m_Familiar );


			writer.WriteDeltaTime( m_Shield );
		}
	}
}// using System;// using Server;// using Server.Mobiles;// using System.Collections.Generic;


namespace Server.Factions
{
	public class PlayerState : IComparable
	{
		private Mobile m_Mobile;
		private Faction m_Faction;
		private List<PlayerState> m_Owner;
		private int m_KillPoints;
		private DateTime m_Leaving;
		private MerchantTitle m_MerchantTitle;
		private RankDefinition m_Rank;
		private List<SilverGivenEntry> m_SilverGiven;
		private bool m_IsActive;


		private Town m_Sheriff;
		private Town m_Finance;


		private DateTime m_LastHonorTime;


		public Mobile Mobile{ get{ return m_Mobile; } }
		public Faction Faction{ get{ return m_Faction; } }
		public List<PlayerState> Owner { get { return m_Owner; } }
		public MerchantTitle MerchantTitle{ get{ return m_MerchantTitle; } set{ m_MerchantTitle = value; Invalidate(); } }
		public Town Sheriff{ get{ return m_Sheriff; } set{ m_Sheriff = value; Invalidate(); } }
		public Town Finance{ get{ return m_Finance; } set{ m_Finance = value; Invalidate(); } }
		public List<SilverGivenEntry> SilverGiven { get { return m_SilverGiven; } }


		public int KillPoints { 
			get { return m_KillPoints; } 
			set { 
				if ( m_KillPoints != value ) {
					if ( value > m_KillPoints ) {
						if ( m_KillPoints <= 0 ) {
							if ( value <= 0 ) {
								m_KillPoints = value;
								Invalidate();
								return;
							}
							
							m_Owner.Remove( this );
							m_Owner.Insert( m_Faction.ZeroRankOffset, this );


							m_RankIndex = m_Faction.ZeroRankOffset;
							m_Faction.ZeroRankOffset++;
						}
						while ( ( m_RankIndex - 1 ) >= 0 ) {
							PlayerState p = m_Owner[m_RankIndex-1] as PlayerState;
							if ( value > p.KillPoints ) {
								m_Owner[m_RankIndex] = p;
								m_Owner[m_RankIndex-1] = this;
								RankIndex--;
								p.RankIndex++;
							}
							else
								break;
						}
					}
					else {
						if ( value <= 0 ) {
							if ( m_KillPoints <= 0 ) {
								m_KillPoints = value;
								Invalidate();
								return;
							}


							while ( ( m_RankIndex + 1 ) < m_Faction.ZeroRankOffset ) {
								PlayerState p = m_Owner[m_RankIndex+1] as PlayerState;
								m_Owner[m_RankIndex+1] = this;
								m_Owner[m_RankIndex] = p;
								RankIndex++;
								p.RankIndex--;
							}


							m_RankIndex = -1;
							m_Faction.ZeroRankOffset--;
						}
						else {
							while ( ( m_RankIndex + 1 ) < m_Faction.ZeroRankOffset ) {
								PlayerState p = m_Owner[m_RankIndex+1] as PlayerState;
								if ( value < p.KillPoints ) {
									m_Owner[m_RankIndex+1] = this;
									m_Owner[m_RankIndex] = p;
									RankIndex++;
									p.RankIndex--;
								}
								else
									break;
							}
						}
					}


					m_KillPoints = value;
					Invalidate();
				}
			}
		}


		private bool m_InvalidateRank = true;
		private int  m_RankIndex = -1;


		public int RankIndex { get { return m_RankIndex; } set { if ( m_RankIndex != value ) { m_RankIndex = value; m_InvalidateRank = true; } } }
		
		public RankDefinition Rank { 
			get { 
				if ( m_InvalidateRank ) {
					RankDefinition[] ranks = m_Faction.Definition.Ranks;
					int percent;


					if ( m_Owner.Count == 1 )
						percent = 1000;
					else if ( m_RankIndex == -1 )
						percent = 0;
					else
						percent = ( ( m_Faction.ZeroRankOffset - m_RankIndex ) * 1000 ) / m_Faction.ZeroRankOffset;


					for ( int i = 0; i < ranks.Length; i++ ) {
						RankDefinition check = ranks[i];


						if ( percent >= check.Required ) {
							m_Rank = check;
							m_InvalidateRank = false;
							break;
						}
					}


					Invalidate();
				}


				return m_Rank;
			}
		}


		public DateTime LastHonorTime{ get{ return m_LastHonorTime; } set{ m_LastHonorTime = value; } }
		public DateTime Leaving{ get{ return m_Leaving; } set{ m_Leaving = value; } }
		public bool IsLeaving{ get{ return ( m_Leaving > DateTime.MinValue ); } }


		public bool IsActive{ get{ return m_IsActive; } set{ m_IsActive = value; } }


		public bool CanGiveSilverTo( Mobile mob )
		{
			if ( m_SilverGiven == null )
				return true;


			for ( int i = 0; i < m_SilverGiven.Count; ++i )
			{
				SilverGivenEntry sge = m_SilverGiven[i];


				if ( sge.IsExpired )
					m_SilverGiven.RemoveAt( i-- );
				else if ( sge.GivenTo == mob )
					return false;
			}


			return true;
		}


		public void OnGivenSilverTo( Mobile mob )
		{
			if ( m_SilverGiven == null )
				m_SilverGiven = new List<SilverGivenEntry>();


			m_SilverGiven.Add( new SilverGivenEntry( mob ) );
		}


		public void Invalidate()
		{
			if ( m_Mobile is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)m_Mobile;
				pm.InvalidateProperties();
				pm.InvalidateMyRunUO();
			}
		}


		public void Attach()
		{
			if ( m_Mobile is PlayerMobile )
				((PlayerMobile)m_Mobile).FactionPlayerState = this;
		}


		public PlayerState( Mobile mob, Faction faction, List<PlayerState> owner )
		{
			m_Mobile = mob;
			m_Faction = faction;
			m_Owner = owner;


			Attach();
			Invalidate();
		}


		public PlayerState( GenericReader reader, Faction faction, List<PlayerState> owner )
		{
			m_Faction = faction;
			m_Owner = owner;


			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 1:
				{
					m_IsActive = reader.ReadBool();
					m_LastHonorTime = reader.ReadDateTime();
					goto case 0;
				}
				case 0:
				{
					m_Mobile = reader.ReadMobile();


					m_KillPoints = reader.ReadEncodedInt();
					m_MerchantTitle = (MerchantTitle)reader.ReadEncodedInt();


					m_Leaving = reader.ReadDateTime();


					break;
				}
			}


			Attach();
		}


		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 1 ); // version


			writer.Write( m_IsActive );
			writer.Write( m_LastHonorTime );


			writer.Write( (Mobile) m_Mobile );


			writer.WriteEncodedInt( (int) m_KillPoints );
			writer.WriteEncodedInt( (int) m_MerchantTitle );


			writer.Write( (DateTime) m_Leaving );
		}


		public static PlayerState Find( Mobile mob )
		{
			if ( mob is PlayerMobile )
				return ((PlayerMobile)mob).FactionPlayerState;


			return null;
		}


		public int CompareTo( object obj )
		{
			return ((PlayerState)obj).m_KillPoints - m_KillPoints;
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a beetle's corpse" )]
	public class PoisonBeetle : BaseCreature
	{
		[Constructable]
		public PoisonBeetle () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a poisonous beetle";
			Body = 0xA9;
			BaseSoundID = 0x388;
			Hue = 1167;


			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );


			SetHits( 80, 110 );


			SetDamage( 3, 10 );


			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Poison, 80 );


			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 20, 30 );


			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 75.0 );


			Fame = 3000;
			Karma = -3000;


			VirtualArmor = 16;


			Item Venom = new VenomSack();
				Venom.Name = "lethal venom sack";
				AddItem( Venom );
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}


		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.6; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }


		public PoisonBeetle( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;


			Body = 0xA9;
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics
{
	public abstract class Power
	{
		protected PowerDefinition m_Definition;


		public PowerDefinition Definition { get { return m_Definition; } }


		public virtual bool CheckInvoke( Player from )
		{
			if ( !from.Mobile.CheckAlive() )
				return false;


			if ( from.Power < m_Definition.Power )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You lack the power to invoke this ability." );
				return false;
			}


			return true;
		}


		public abstract void BeginInvoke( Player from );


		public virtual void FinishInvoke( Player from )
		{
			from.Power -= m_Definition.Power;
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics
{
	public class PowerDefinition
	{
		private int m_Power;


		private TextDefinition m_Name;
		private TextDefinition m_Phrase;
		private TextDefinition m_Description;


		public int Power { get { return m_Power; } }


		public TextDefinition Name { get { return m_Name; } }
		public TextDefinition Phrase { get { return m_Phrase; } }
		public TextDefinition Description { get { return m_Description; } }


		public PowerDefinition( int power, TextDefinition name, TextDefinition phrase, TextDefinition description )
		{
			m_Power = power;


			m_Name = name;
			m_Phrase = phrase;
			m_Description = description;
		}
	}
}// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class QuartzWyrm : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }


		[Constructable]
		public QuartzWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the quartz wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "quartz", "monster", 0 );


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );


			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "quartz scales" );
   			c.DropItem(scale);
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public QuartzWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.ContextMenus;

namespace Server.Factions
{
	public class RankDefinition
	{
		private int m_Rank;
		private int m_Required;
		private int m_MaxWearables;
		private TextDefinition m_Title;


		public int Rank{ get{ return m_Rank; } }
		public int Required{ get{ return m_Required; } }
		public int MaxWearables{ get{ return m_MaxWearables; } }
		public TextDefinition Title{ get{ return m_Title; } }


		public RankDefinition( int rank, int required, int maxWearables, TextDefinition title )
		{
			m_Rank = rank;
			m_Required = required;
			m_Title = title;
			m_MaxWearables = maxWearables;
		}
	}
}
// using System;// using Server.Items;// using Server.Mobiles;// using Server.Misc;



namespace Server.Mobiles
{
	[CorpseName( "a ravenous corpse" )]
	public class Ravenous : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}


		[Constructable]
		public Ravenous() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a ravenous";
			Body = 218;
			BaseSoundID = 0x5A;
			Hue = 0x84E;


			SetStr( 166, 190 );
			SetDex( 96, 115 );
			SetInt( 51, 60 );


			SetHits( 116, 130 );
			SetMana( 0 );


			SetDamage( 12, 30 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 30, 45 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 25, 35 );


			SetSkill( SkillName.MagicResist, 55.1, 70.0 );
			SetSkill( SkillName.Tactics, 60.1, 80.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );


			Fame = 3500;
			Karma = -3500;


			VirtualArmor = 40;


			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 90.7;
		}


		public override int GetAttackSound(){ return 0x622; }	// A
		public override int GetDeathSound(){ return 0x623; }	// D
		public override int GetHurtSound(){ return 0x624; }		// H


		public override HideType HideType{ get{ return HideType.Dinosaur; } }
		public override int Meat{ get{ return 4; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }


		public Ravenous(Serial serial) : base(serial)
		{
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
// using System;// using System.Reflection;// using System.Collections;// using Server;// using System.Collections.Generic;


namespace Server.Factions
{
	public class Reflector
	{
		private static List<Type> m_Types = new List<Type>();


		private static List<Town> m_Towns;


		public static List<Town> Towns
		{
			get
			{
				if ( m_Towns == null )
					ProcessTypes();


				return m_Towns;
			}
		}


		private static List<Faction> m_Factions;


		public static List<Faction> Factions
		{
			get
			{
				if ( m_Factions == null )
					Reflector.ProcessTypes();


				return m_Factions;
			}
		}


		public static void Configure()
		{
			EventSink.WorldSave += new WorldSaveEventHandler( EventSink_WorldSave );
		}


		private static void EventSink_WorldSave( WorldSaveEventArgs e )
		{
			m_Types.Clear();
		}


		public static void Serialize( GenericWriter writer, Type type )
		{
			int index = m_Types.IndexOf( type );


			writer.WriteEncodedInt( (int) (index + 1) );


			if ( index == -1 )
			{
				writer.Write( type == null ? null : type.FullName );
				m_Types.Add( type );
			}
		}


		public static Type Deserialize( GenericReader reader )
		{
			int index = reader.ReadEncodedInt();


			if ( index == 0 )
			{
				string typeName = reader.ReadString();


				if ( typeName == null )
					m_Types.Add( null );
				else
					m_Types.Add( ScriptCompiler.FindTypeByFullName( typeName, false ) );


				return m_Types[m_Types.Count - 1];
			}
			else
			{
				return m_Types[index - 1];
			}
		}


		private static object Construct( Type type )
		{
			try{ return Activator.CreateInstance( type ); }
			catch{ return null; }
		}


		private static void ProcessTypes()
		{
			m_Factions = new List<Faction>();
			m_Towns = new List<Town>();


			Assembly[] asms = ScriptCompiler.Assemblies;


			for ( int i = 0; i < asms.Length; ++i )
			{
				Assembly asm = asms[i];
				TypeCache tc = ScriptCompiler.GetTypeCache( asm );
				Type[] types = tc.Types;


				for ( int j = 0; j < types.Length; ++j )
				{
					Type type = types[j];


					if ( type.IsSubclassOf( typeof( Faction ) ) )
					{
						Faction faction = Construct( type ) as Faction;


						if ( faction != null )
							Faction.Factions.Add( faction );
					}
					else if ( type.IsSubclassOf( typeof( Town ) ) )
					{
						Town town = Construct( type ) as Town;


						if ( town != null )
							Town.Towns.Add( town );
					}
				}
			}
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class RubyWyrm : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }


		[Constructable]
		public RubyWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the ruby wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "ruby", "monster", 0 );


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );


			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "ruby scales" );
   			c.DropItem(scale);
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public RubyWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class SabretoothBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}


		[Constructable]
		public SabretoothBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a sabreclaw bear";
			Body = 34;
			BaseSoundID = 0xA3;


			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );


			SetHits( 176, 193 );
			SetMana( 0 );


			SetDamage( 14, 19 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );


			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.Wrestling, 65.1, 90.0 );


			Fame = 1500;
			Karma = 0;


			VirtualArmor = 35;


			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}


		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }


		public override int GetAngerSound()
		{
			return 0x518;
		}


		public override int GetIdleSound()
		{
			return 0x517;
		}


		public override int GetAttackSound()
		{
			return 0x516;
		}


		public override int GetHurtSound()
		{
			return 0x519;
		}


		public override int GetDeathSound()
		{
			return 0x515;
		}


		public SabretoothBear( Serial serial ) : base( serial )
		{
		}


		public override void Serialize(GenericWriter writer)
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
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Targeting;// using Server.Network;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class SapphireWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }


		[Constructable]
		public SapphireWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the sapphire wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "sapphire", "monster", 0 );


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );


			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "sapphire scales" );
   			c.DropItem(scale);
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public SapphireWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;


namespace Server.Factions
{
	public class Shadowlords : Faction
	{
		private static Faction m_Instance;


		public static Faction Instance{ get{ return m_Instance; } }


		public Shadowlords()
		{
			m_Instance = this;


			Definition =
				new FactionDefinition(
					3,
					1109, // shadow
					2211, // green
					1109, // join stone : shadow
					2211, // broadcast : green
					0x79, 0x3EB0, // war horse
					"Shadowlords", "shadow", "SL", 
					new TextDefinition( 1011537, "SHADOWLORDS" ),
					new TextDefinition( 1060772, "Shadowlords faction" ),
					new TextDefinition( 1011424, "<center>SHADES OF DARKNESS</center>" ),
					new TextDefinition( 1011451,
						"The Shadow Lords are a faction that has sprung up within the ranks of " +
						"Minax. Comprised mostly of undead and those who would seek to be " +
						"necromancers, they pose a threat to both the sides of good and evil. " +
						"Their plans have disrupted the hold Minax has over Felucca, and their " +
						"ultimate goal is to destroy all life." ),
					new TextDefinition( 1011456, "This city is controlled by the Shadow Lords." ),
					new TextDefinition( 1042255, "This sigil has been corrupted by the Shadowlords" ),
					new TextDefinition( 1041046, "The faction signup stone for the Shadowlords" ),
					new TextDefinition( 1041384, "The Faction Stone of the Shadowlords" ),
					new TextDefinition( 1011466, ": Shadowlords" ),
					new TextDefinition( 1005184, "Minions of the Shadowlords will now be ignored." ),
					new TextDefinition( 1005185, "Minions of the Shadowlords will now be warned of their impending deaths." ),
					new TextDefinition( 1005186, "Minions of the Shadowlords will now be attacked at will." ),
					new StrongholdDefinition(
						new Rectangle2D[]
						{
							new Rectangle2D( 5192, 3934, 1, 1 ) // WIZARD
						},
						new Point3D( 969, 768, 0 ),
						new Point3D( 947, 713, 0 ),
						new Point3D[]
						{
							new Point3D( 953, 713, 20 ),
							new Point3D( 953, 709, 20 ),
							new Point3D( 953, 705, 20 ),
							new Point3D( 953, 701, 20 ),
							new Point3D( 957, 713, 20 ),
							new Point3D( 957, 709, 20 ),
							new Point3D( 957, 705, 20 ),
							new Point3D( 957, 701, 20 )
						} ),
					new RankDefinition[]
					{
						new RankDefinition( 10, 991, 8, new TextDefinition( 1060799, "Purveyor of Darkness" ) ),
						new RankDefinition(  9, 950, 7, new TextDefinition( 1060798, "Agent of Evil" ) ),
						new RankDefinition(  8, 900, 6, new TextDefinition( 1060797, "Bringer of Sorrow" ) ),
						new RankDefinition(  7, 800, 6, new TextDefinition( 1060797, "Bringer of Sorrow" ) ),
						new RankDefinition(  6, 700, 5, new TextDefinition( 1060796, "Keeper of Lies" ) ),
						new RankDefinition(  5, 600, 5, new TextDefinition( 1060796, "Keeper of Lies" ) ),
						new RankDefinition(  4, 500, 5, new TextDefinition( 1060796, "Keeper of Lies" ) ),
						new RankDefinition(  3, 400, 4, new TextDefinition( 1060795, "Servant" ) ),
						new RankDefinition(  2, 200, 4, new TextDefinition( 1060795, "Servant" ) ),
						new RankDefinition(  1,   0, 4, new TextDefinition( 1060795, "Servant" ) )
					},
					new GuardDefinition[]
					{
						new GuardDefinition( typeof( FactionHenchman ),		0x1403, 5000, 1000, 10,		new TextDefinition( 1011526, "HENCHMAN" ),		new TextDefinition( 1011510, "Hire Henchman" ) ),
						new GuardDefinition( typeof( FactionMercenary ),	0x0F62, 6000, 2000, 10,		new TextDefinition( 1011527, "MERCENARY" ),		new TextDefinition( 1011511, "Hire Mercenary" ) ),
						new GuardDefinition( typeof( FactionDeathKnight ),	0x0F45, 7000, 3000, 10,		new TextDefinition( 1011512, "DEATH KNIGHT" ),	new TextDefinition( 1011503, "Hire Death Knight" ) ),
						new GuardDefinition( typeof( FactionNecromancer ),	0x13F8, 8000, 4000, 10,		new TextDefinition( 1011513, "SHADOW MAGE" ),	new TextDefinition( 1011504, "Hire Shadow Mage" ) ),
					}
				);
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using Server.Targeting;// using System.Collections.Generic;


namespace Server.Factions
{
	public class SheriffGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;
		private Town m_Town;


		private void CenterItem( int itemID, int x, int y, int w, int h )
		{
			Rectangle2D rc = ItemBounds.Table[itemID];
			AddItem( x + ((w - rc.Width) / 2) - rc.X, y + ((h - rc.Height) / 2) - rc.Y, itemID );
		}


		public SheriffGump( PlayerMobile from, Faction faction, Town town ) : base( 50, 50 )
		{
			m_From = from;
			m_Faction = faction;
			m_Town = town;


			AddPage( 0 );


			AddBackground( 0, 0, 320, 410, 5054 );
			AddBackground( 10, 10, 300, 390, 3000 );


			#region General
			AddPage( 1 );


			AddHtmlLocalized( 20, 30, 260, 25, 1011431, false, false ); // Sheriff


			AddHtmlLocalized( 55, 90, 200, 25, 1011494, false, false ); // HIRE GUARDS
			AddButton( 20, 90, 4005, 4007, 0, GumpButtonType.Page, 3 );


			AddHtmlLocalized( 55, 120, 200, 25, 1011495, false, false ); // VIEW FINANCES
			AddButton( 20, 120, 4005, 4007, 0, GumpButtonType.Page, 2 );


			AddHtmlLocalized( 55, 360, 200, 25, 1011441, false, false ); // Exit
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			#endregion


			#region Finances
			AddPage( 2 );


			int financeUpkeep = town.FinanceUpkeep;
			int sheriffUpkeep = town.SheriffUpkeep;
			int dailyIncome = town.DailyIncome;
			int netCashFlow = town.NetCashFlow;


			AddHtmlLocalized( 20, 30, 300, 25, 1011524, false, false ); // FINANCE STATEMENT
			
			AddHtmlLocalized( 20, 80, 300, 25, 1011538, false, false ); // Current total money for town : 
			AddLabel( 20, 100, 0x44, town.Silver.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddHtmlLocalized( 20, 130, 300, 25, 1011520, false, false ); // Finance Minister Upkeep : 
			AddLabel( 20, 150, 0x44, financeUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'
	
			AddHtmlLocalized( 20, 180, 300, 25, 1011521, false, false ); // Sheriff Upkeep : 
			AddLabel( 20, 200, 0x44, sheriffUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddHtmlLocalized( 20, 230, 300, 25, 1011522, false, false ); // Town Income : 
			AddLabel( 20, 250, 0x44, dailyIncome.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddHtmlLocalized( 20, 280, 300, 25, 1011523, false, false ); // Net Cash flow per day : 
			AddLabel( 20, 300, 0x44, netCashFlow.ToString( "N0" ) ); // NOTE: Added 'N0'


			AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion


			#region Hire Guards
			AddPage( 3 );


			AddHtmlLocalized( 20, 30, 300, 25, 1011494, false, false ); // HIRE GUARDS


			List<GuardList> guardLists = town.GuardLists;


			for ( int i = 0; i < guardLists.Count; ++i )
			{
				GuardList guardList = guardLists[i];
				int y = 90 + (i * 60);


				AddButton( 20, y, 4005, 4007, 0, GumpButtonType.Page, 4 + i );
				CenterItem( guardList.Definition.ItemID, 50, y - 20, 70, 60 );
				AddHtmlText( 120, y, 200, 25, guardList.Definition.Header, false, false );
			}


			AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion


			#region Guard Pages
			for ( int i = 0; i < guardLists.Count; ++i )
			{
				GuardList guardList = guardLists[i];


				AddPage( 4 + i );


				AddHtmlText( 90, 30, 300, 25, guardList.Definition.Header, false, false );
				CenterItem( guardList.Definition.ItemID, 10, 10, 80, 80 );


				AddHtmlLocalized( 20, 90, 200, 25, 1011514, false, false ); // You have : 
				AddLabel( 230, 90, 0x26, guardList.Guards.Count.ToString() );


				AddHtmlLocalized( 20, 120, 200, 25, 1011515, false, false ); // Maximum : 
				AddLabel( 230, 120, 0x12A, guardList.Definition.Maximum.ToString() );


				AddHtmlLocalized( 20, 150, 200, 25, 1011516, false, false ); // Cost : 
				AddLabel( 230, 150, 0x44, guardList.Definition.Price.ToString( "N0" ) ); // NOTE: Added 'N0'


				AddHtmlLocalized( 20, 180, 200, 25, 1011517, false, false ); // Daily Pay :
				AddLabel( 230, 180, 0x37, guardList.Definition.Upkeep.ToString( "N0" ) ); // NOTE: Added 'N0'


				AddHtmlLocalized( 20, 210, 200, 25, 1011518, false, false ); // Current Silver : 
				AddLabel( 230, 210, 0x44, town.Silver.ToString( "N0" ) ); // NOTE: Added 'N0'


				AddHtmlLocalized( 20, 240, 200, 25, 1011519, false, false ); // Current Payroll : 
				AddLabel( 230, 240, 0x44, sheriffUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'


				AddHtmlText( 55, 300, 200, 25, guardList.Definition.Label, false, false );
				AddButton( 20, 300, 4005, 4007, 1 + i, GumpButtonType.Reply, 0 );


				AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
				AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 3 );
			}
			#endregion
		}


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( !m_Town.IsSheriff( m_From ) || m_Town.Owner != m_Faction )
			{
				m_From.SendLocalizedMessage( 1010339 ); // You no longer control this city
				return;
			}


			int index = info.ButtonID - 1;


			if ( index >= 0 && index < m_Town.GuardLists.Count )
			{
				GuardList guardList = m_Town.GuardLists[index];
				Town town = Town.FromRegion( m_From.Region );


				if ( Town.FromRegion( m_From.Region ) != m_Town )
				{
					m_From.SendLocalizedMessage( 1010305 ); // You must be in your controlled city to buy Items
				}
				else if ( guardList.Guards.Count >= guardList.Definition.Maximum )
				{
					m_From.SendLocalizedMessage( 1010306 ); // You currently have too many of this enhancement type to place another
				}
				else if ( m_Town.Silver >= guardList.Definition.Price )
				{
					BaseFactionGuard guard = guardList.Construct();


					if ( guard != null )
					{
						guard.Faction = m_Faction;
						guard.Town = m_Town;


						m_Town.Silver -= guardList.Definition.Price;


						guard.MoveToWorld( m_From.Location, m_From.Map );
						guard.Home = guard.Location;
					}
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.Network;// using System.Collections.Generic;


namespace Server.Factions
{
	public class Sigil : BaseSystemController
	{
		public const int OwnershipHue = 0xB;


		// ?? time corrupting faction has to return the sigil before corruption time resets ?
		public static readonly TimeSpan CorruptionGrace = TimeSpan.FromMinutes( (Core.SE) ? 30.0 : 15.0 );


		// Sigil must be held at a stronghold for this amount of time in order to become corrupted
		public static readonly TimeSpan CorruptionPeriod = ( (Core.SE) ? TimeSpan.FromHours( 10.0 ) : TimeSpan.FromHours( 24.0 ) ); 


		// After a sigil has been corrupted it must be returned to the town within this period of time
		public static readonly TimeSpan ReturnPeriod = TimeSpan.FromHours( 1.0 );


		// Once it's been returned the corrupting faction owns the town for this period of time
		public static readonly TimeSpan PurificationPeriod = TimeSpan.FromDays( 3.0 );


		private BaseMonolith m_LastMonolith;


		private Town m_Town;
		private Faction m_Corrupted;
		private Faction m_Corrupting;


		private DateTime m_LastStolen;
		private DateTime m_GraceStart;
		private DateTime m_CorruptionStart;
		private DateTime m_PurificationStart;


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public DateTime LastStolen
		{
			get{ return m_LastStolen; }
			set{ m_LastStolen = value; }
		}


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public DateTime GraceStart
		{
			get{ return m_GraceStart; }
			set{ m_GraceStart = value; }
		}


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public DateTime CorruptionStart
		{
			get{ return m_CorruptionStart; }
			set{ m_CorruptionStart = value; }
		}


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public DateTime PurificationStart
		{
			get{ return m_PurificationStart; }
			set{ m_PurificationStart = value; }
		}


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Town Town
		{
			get{ return m_Town; }
			set{ m_Town = value; Update(); }
		}


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Corrupted
		{
			get{ return m_Corrupted; }
			set{ m_Corrupted = value; Update(); }
		}


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Corrupting
		{
			get{ return m_Corrupting; }
			set{ m_Corrupting = value; Update(); }
		}


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public BaseMonolith LastMonolith
		{
			get{ return m_LastMonolith; }
			set{ m_LastMonolith = value; }
		}


		[CommandProperty( AccessLevel.Counselor )]
		public bool IsBeingCorrupted
		{
			get{ return ( m_LastMonolith is StrongholdMonolith && m_LastMonolith.Faction == m_Corrupting && m_Corrupting != null ); }
		}


		[CommandProperty( AccessLevel.Counselor )]
		public bool IsCorrupted
		{
			get{ return ( m_Corrupted != null ); }
		}


		[CommandProperty( AccessLevel.Counselor )]
		public bool IsPurifying
		{
			get{ return ( m_PurificationStart != DateTime.MinValue ); }
		}


		[CommandProperty( AccessLevel.Counselor )]
		public bool IsCorrupting
		{
			get{ return ( m_Corrupting != null && m_Corrupting != m_Corrupted ); }
		}


		public void Update()
		{
			ItemID = ( m_Town == null ? 0x1869 : m_Town.Definition.SigilID );


			if ( m_Town == null )
				AssignName( null );
			else if ( IsCorrupted || IsPurifying )
				AssignName( m_Town.Definition.CorruptedSigilName );
			else
				AssignName( m_Town.Definition.SigilName );


			InvalidateProperties();
		}


		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );


			if ( IsCorrupted )
				TextDefinition.AddTo( list, m_Corrupted.Definition.SigilControl );
			else
				list.Add( 1042256 ); // This sigil is not corrupted.


			if ( IsCorrupting )
				list.Add( 1042257 ); // This sigil is in the process of being corrupted.
			else if ( IsPurifying )
				list.Add( 1042258 ); // This sigil has recently been corrupted, and is undergoing purification.
			else
				list.Add( 1042259 ); // This sigil is not in the process of being corrupted.
		}


		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );


			if ( IsCorrupted )
			{
				if ( m_Corrupted.Definition.SigilControl.Number > 0 )
					LabelTo( from, m_Corrupted.Definition.SigilControl.Number );
				else if ( m_Corrupted.Definition.SigilControl.String != null )
					LabelTo( from, m_Corrupted.Definition.SigilControl.String );
			}
			else
			{
				LabelTo( from, 1042256 ); // This sigil is not corrupted.
			}


			if ( IsCorrupting )
				LabelTo( from, 1042257 ); // This sigil is in the process of being corrupted.
			else if ( IsPurifying )
				LabelTo( from, 1042258 ); // This sigil has been recently corrupted, and is undergoing purification.
			else
				LabelTo( from, 1042259 ); // This sigil is not in the process of being corrupted.
		}


		public override bool CheckLift( Mobile from, Item item, ref LRReason reject )
		{
			from.SendLocalizedMessage( 1005225 ); // You must use the stealing skill to pick up the sigil
			return false;
		}


		private Mobile FindOwner( object parent )
		{
			if ( parent is Item )
				return ((Item)parent).RootParent as Mobile;


			if ( parent is Mobile )
				return (Mobile) parent;


			return null;
		}


		public override void OnAdded( object parent )
		{
			base.OnAdded( parent );


			Mobile mob = FindOwner( parent );


			if ( mob != null )
				mob.SolidHueOverride = OwnershipHue;
		}


		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );


			Mobile mob = FindOwner( parent );


			if ( mob != null )
				mob.SolidHueOverride = -1;
		}


		public Sigil( Town town ) : base( 0x1869 )
		{
			Movable = false;
			Town = town;


			m_Sigils.Add( this );
		}


		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.BeginTarget( 1, false, Targeting.TargetFlags.None, new TargetCallback( Sigil_OnTarget ) );
				from.SendLocalizedMessage( 1042251 ); // Click on a sigil monolith or player
			}
		}


		public static bool ExistsOn( Mobile mob )
		{
			Container pack = mob.Backpack;


			return ( pack != null && pack.FindItemByType( typeof( Sigil ) ) != null );
		}


		private void BeginCorrupting( Faction faction )
		{
			m_Corrupting = faction;
			m_CorruptionStart = DateTime.Now;
		}


		private void ClearCorrupting()
		{
			m_Corrupting = null;
			m_CorruptionStart = DateTime.MinValue;
		}


		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan TimeUntilCorruption
		{
			get
			{
				if ( !IsBeingCorrupted )
					return TimeSpan.Zero;


				TimeSpan ts = ( m_CorruptionStart + CorruptionPeriod ) - DateTime.Now;


				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;


				return ts;
			}
		}


		private void Sigil_OnTarget( Mobile from, object obj )
		{
			if ( Deleted || !IsChildOf( from.Backpack ) )
				return;


			#region Give To Mobile
			if ( obj is Mobile )
			{
				if ( obj is PlayerMobile )
				{
					PlayerMobile targ = (PlayerMobile)obj;


					Faction toFaction = Faction.Find( targ );
					Faction fromFaction = Faction.Find( from );


					if ( toFaction == null )
						from.SendLocalizedMessage( 1005223 ); // You cannot give the sigil to someone not in a faction
					else if ( fromFaction != toFaction )
						from.SendLocalizedMessage( 1005222 ); // You cannot give the sigil to someone not in your faction
					else if ( Sigil.ExistsOn( targ ) )
						from.SendLocalizedMessage( 1005220 ); // You cannot give this sigil to someone who already has a sigil
					else if( !targ.Alive )
						from.SendLocalizedMessage( 1042248 ); // You cannot give a sigil to a dead person.
					else if ( from.NetState != null && targ.NetState != null )
					{
						Container pack = targ.Backpack;


						if ( pack != null )
							pack.DropItem( this );
					}
				}
				else
				{
					from.SendLocalizedMessage( 1005221 ); //You cannot give the sigil to them
				}
			}
			#endregion
			else if ( obj is BaseMonolith )
			{
				#region Put in Stronghold
				if ( obj is StrongholdMonolith )
				{
					StrongholdMonolith m = (StrongholdMonolith)obj;


					if ( m.Faction == null || m.Faction != Faction.Find( from ) )
						from.SendLocalizedMessage( 1042246 ); // You can't place that on an enemy monolith
					else if ( m.Town == null || m.Town != m_Town )
						from.SendLocalizedMessage( 1042247 ); // That is not the correct faction monolith
					else
					{
						m.Sigil = this;


						Faction newController = m.Faction;
						Faction oldController = m_Corrupting;


						if ( oldController == null )
						{
							if ( m_Corrupted != newController )
								BeginCorrupting( newController );
						}
						else if ( m_GraceStart > DateTime.MinValue && (m_GraceStart + CorruptionGrace) < DateTime.Now )
						{
							if ( m_Corrupted != newController )
								BeginCorrupting( newController ); // grace time over, reset period
							else
								ClearCorrupting();


							m_GraceStart = DateTime.MinValue;
						}
						else if ( newController == oldController )
						{
							m_GraceStart = DateTime.MinValue; // returned within grace period
						}
						else if ( m_GraceStart == DateTime.MinValue )
						{
							m_GraceStart = DateTime.Now;
						}


						m_PurificationStart = DateTime.MinValue;
					}
				}
				#endregion


				#region Put in Town
				else if ( obj is TownMonolith )
				{
					TownMonolith m = (TownMonolith)obj;


					if ( m.Town == null || m.Town != m_Town )
						from.SendLocalizedMessage( 1042245 ); // This is not the correct town sigil monolith
					else if ( m_Corrupted == null || m_Corrupted != Faction.Find( from ) )
						from.SendLocalizedMessage( 1042244 ); // Your faction did not corrupt this sigil.  Take it to your stronghold.
					else
					{
						m.Sigil = this;


						m_Corrupting = null;
						m_PurificationStart = DateTime.Now;
						m_CorruptionStart = DateTime.MinValue;


						m_Town.Capture( m_Corrupted );
						m_Corrupted = null;
					}
				}
				#endregion
			}
			else
			{
				from.SendLocalizedMessage( 1005224 );	//	You can't use the sigil on that 
			}


			Update();
		}


		public Sigil( Serial serial ) : base( serial )
		{
			m_Sigils.Add( this );
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			Town.WriteReference( writer, m_Town );
			Faction.WriteReference( writer, m_Corrupted );
			Faction.WriteReference( writer, m_Corrupting );


			writer.Write( (Item) m_LastMonolith );


			writer.Write( m_LastStolen );
			writer.Write( m_GraceStart );
			writer.Write( m_CorruptionStart );
			writer.Write( m_PurificationStart );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			switch ( version )
			{
				case 0:
				{
					m_Town = Town.ReadReference( reader );
					m_Corrupted = Faction.ReadReference( reader );
					m_Corrupting = Faction.ReadReference( reader );


					m_LastMonolith = reader.ReadItem() as BaseMonolith;


					m_LastStolen = reader.ReadDateTime();
					m_GraceStart = reader.ReadDateTime();
					m_CorruptionStart = reader.ReadDateTime();
					m_PurificationStart = reader.ReadDateTime();


					Update();


					Mobile mob = RootParent as Mobile;


					if ( mob != null )
						mob.SolidHueOverride = OwnershipHue;


					break;
				}
			}
		}


		public bool ReturnHome()
		{
			BaseMonolith monolith = m_LastMonolith;


			if ( monolith == null && m_Town != null )
				monolith = m_Town.Monolith;


			if ( monolith != null && !monolith.Deleted )
				monolith.Sigil = this;


			return ( monolith != null && !monolith.Deleted );
		}


		public override void OnParentDeleted( object parent )
		{
			base.OnParentDeleted( parent );


			ReturnHome();
		}


		public override void OnAfterDelete()
		{
			base.OnAfterDelete();


			m_Sigils.Remove( this );
		}


		public override void Delete()
		{
			if ( ReturnHome() )
				return;


			base.Delete();
		}


		private static List<Sigil> m_Sigils = new List<Sigil>();


		public static List<Sigil> Sigils{ get{ return m_Sigils; } }
	}
}
// using System;// using Server;


namespace Server.Factions
{
	public class Silver : Item
	{
		public override double DefaultWeight
		{
			get { return 0.02; }
		}


		[Constructable]
		public Silver() : this( 1 )
		{
		}


		[Constructable]
		public Silver( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
		{
		}


		[Constructable]
		public Silver( int amount ) : base( 0xEF0 )
		{
			Stackable = true;
			Amount = amount;
		}


		public Silver( Serial serial ) : base( serial )
		{
		}


		public override int GetDropSound()
		{
			if ( Amount <= 1 )
				return 0x2E4;
			else if ( Amount <= 5 )
				return 0x2E5;
			else
				return 0x2E6;
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
// using System;


namespace Server.Factions
{
	public class SilverGivenEntry
	{
		public static readonly TimeSpan ExpirePeriod = TimeSpan.FromHours( 3.0 );


		private Mobile m_GivenTo;
		private DateTime m_TimeOfGift;


		public Mobile GivenTo{ get{ return m_GivenTo; } }
		public DateTime TimeOfGift{ get{ return m_TimeOfGift; } }


		public bool IsExpired{ get{ return ( m_TimeOfGift + ExpirePeriod ) < DateTime.Now; } }


		public SilverGivenEntry( Mobile givenTo )
		{
			m_GivenTo = givenTo;
			m_TimeOfGift = DateTime.Now;
		}
	}
}
// using System;


namespace Server.Factions
{
	public class SkaraBrae : Town
	{
		public SkaraBrae()
		{
			Definition =
				new TownDefinition(
					6,
					0x186F,
					"Skara Brae",
					"Skara Brae",
					new TextDefinition( 1011439, "SKARA BRAE" ),
					new TextDefinition( 1011567, "TOWN STONE FOR SKARA BRAE" ),
					new TextDefinition( 1041040, "The Faction Sigil Monolith of Skara Brae" ),
					new TextDefinition( 1041410, "The Faction Town Sigil Monolith of Skara Brae" ),
					new TextDefinition( 1041419, "Faction Town Stone of Skara Brae" ),
					new TextDefinition( 1041401, "Faction Town Sigil of Skara Brae" ),
					new TextDefinition( 1041392, "Corrupted Faction Town Sigil of Skara Brae" ),
					new Point3D( 576, 2200, 0 ),
					new Point3D( 572, 2196, 0 ) );
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class SpinelWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 1 ); }


		[Constructable]
		public SpinelWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the spinel wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "spinel", "monster", 0 );


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );


			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "spinel scales" );
   			c.DropItem(scale);
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public SpinelWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;


namespace Server.Mobiles
{
	[CorpseName( "a pile of stones" )]
	public class StoneDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }


		[Constructable]
		public StoneDragon () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a stone dragon";
			Body = 12;
			Hue = 2500;
			BaseSoundID = 268;


			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );


			SetHits( 478, 495 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 75, 85 );
			SetResistance( ResistanceType.Energy, 15, 20 );


			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );


			Fame = 15000;
			Karma = -15000;


			VirtualArmor = 60;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "marble scales" );
   			c.DropItem(scale);


			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();


				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Stone", "", c, 25, 0 );
				}
			}
		}


		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			reflect = true; // Every spell is reflected back to the caster
		}


		public override bool OnBeforeDeath()
		{
			this.Body = 0x33D;
			return base.OnBeforeDeath();
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}


		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override bool IsScaredOfScaryThings{ get{ return false; } }
		public override bool IsScaryToPets{ get{ return true; } }


		public StoneDragon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;


namespace Server.Factions
{
	public class StrongholdDefinition
	{
		private Rectangle2D[] m_Area;
		private Point3D m_JoinStone;
		private Point3D m_FactionStone;
		private Point3D[] m_Monoliths;


		public Rectangle2D[] Area{ get{ return m_Area; } }


		public Point3D JoinStone{ get{ return m_JoinStone; } }
		public Point3D FactionStone{ get{ return m_FactionStone; } }


		public Point3D[] Monoliths{ get{ return m_Monoliths; } }


		public StrongholdDefinition( Rectangle2D[] area, Point3D joinStone, Point3D factionStone, Point3D[] monoliths )
		{
			m_Area = area;
			m_JoinStone = joinStone;
			m_FactionStone = factionStone;
			m_Monoliths = monoliths;
		}
	}
}
// using System;


namespace Server.Factions
{
	public class StrongholdMonolith : BaseMonolith
	{
		public override int DefaultLabelNumber{ get{ return 1041042; } } // A Faction Sigil Monolith


		public override void OnTownChanged()
		{
			AssignName( Town == null ? null : Town.Definition.StrongholdMonolithName );
		}


		public StrongholdMonolith() : this( null, null )
		{
		}


		public StrongholdMonolith( Town town, Faction faction ) : base( town, faction )
		{
		}


		public StrongholdMonolith( Serial serial ) : base( serial )
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
// using System;// using System.Collections;// using Server;// using Server.Regions;


namespace Server.Factions
{
	public class StrongholdRegion : BaseRegion
	{
		private Faction m_Faction;


		public Faction Faction
		{
			get{ return m_Faction; }
			set{ m_Faction = value; }
		}


		public StrongholdRegion( Faction faction ) : base( faction.Definition.FriendlyName, Faction.Facet, Region.DefaultPriority, faction.Definition.Stronghold.Area )
		{
			m_Faction = faction;


			Register();
		}


		public override bool OnMoveInto( Mobile m, Direction d, Point3D newLocation, Point3D oldLocation )
		{
			if ( !base.OnMoveInto( m, d, newLocation, oldLocation ) )
				return false;


			if ( m.AccessLevel >= AccessLevel.Counselor || Contains( oldLocation ) )
				return true;


			return ( Faction.Find( m, true, true ) != null );
		}


		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return false;
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;


namespace Server.Ethics.Evil
{
	public sealed class SummonFamiliar : Power
	{
		public SummonFamiliar()
		{
			m_Definition = new PowerDefinition(
					5,
					"Summon Familiar",
					"Trubechs Vingir",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			if ( from.Familiar != null && from.Familiar.Deleted )
				from.Familiar = null;


			if ( from.Familiar != null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You already have an unholy familiar." );
				return;
			}


			if ( ( from.Mobile.Followers + 1 ) > from.Mobile.FollowersMax )
			{
				from.Mobile.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return;
			}


			UnholyFamiliar familiar = new UnholyFamiliar();


			if ( Mobiles.BaseCreature.Summon( familiar, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours( 1.0 ) ) )
			{
				from.Familiar = familiar;


				FinishInvoke( from );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;


namespace Server.Ethics.Hero
{
	public sealed class SummonFamiliar : Power
	{
		public SummonFamiliar()
		{
			m_Definition = new PowerDefinition(
					5,
					"Summon Familiar",
					"Trubechs Vingir",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			if ( from.Familiar != null && from.Familiar.Deleted )
				from.Familiar = null;


			if ( from.Familiar != null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You already have a holy familiar." );
				return;
			}


			if ( ( from.Mobile.Followers + 1 ) > from.Mobile.FollowersMax )
			{
				from.Mobile.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return;
			}


			HolyFamiliar familiar = new HolyFamiliar();


			if ( Mobiles.BaseCreature.Summon( familiar, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours( 1.0 ) ) )
			{
				from.Familiar = familiar;


				FinishInvoke( from );
			}
		}
	}
}// using System;// using Server;// using Server.Items;// using Server.Engines.Plants;


namespace Server.Mobiles
{
	[CorpseName( "a swamp drake corpse" )]
	public class SwampDrake : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 18 ); }


		[Constructable]
		public SwampDrake () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a swamp drake";
			Body = 55;
			BaseSoundID = 362;


			SetStr( 401, 430 );
			SetDex( 133, 152 );
			SetInt( 101, 140 );


			SetHits( 241, 258 );


			SetDamage( 11, 17 );


			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );


			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );


			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.1, 90.0 );
			SetSkill( SkillName.Wrestling, 65.1, 80.0 );


			Fame = 5500;
			Karma = -5500;


			VirtualArmor = 46;


			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 84.3;


			PackReg( 3 );


			if ( Utility.Random( 100 ) > 60 )
			{
				int seed_to_give = Utility.Random( 100 );


				if ( seed_to_give > 90 )
				{
					Seed reward;


					PlantType type;
					switch ( Utility.Random( 17 ) )
					{
						case 0: type = PlantType.CampionFlowers; break;
						case 1: type = PlantType.Poppies; break;
						case 2: type = PlantType.Snowdrops; break;
						case 3: type = PlantType.Bulrushes; break;
						case 4: type = PlantType.Lilies; break;
						case 5: type = PlantType.PampasGrass; break;
						case 6: type = PlantType.Rushes; break;
						case 7: type = PlantType.ElephantEarPlant; break;
						case 8: type = PlantType.Fern; break;
						case 9: type = PlantType.PonytailPalm; break;
						case 10: type = PlantType.SmallPalm; break;
						case 11: type = PlantType.CenturyPlant; break;
						case 12: type = PlantType.WaterPlant; break;
						case 13: type = PlantType.SnakePlant; break;
						case 14: type = PlantType.PricklyPearCactus; break;
						case 15: type = PlantType.BarrelCactus; break;
						default: type = PlantType.TribarrelCactus; break;
					}
						PlantHue hue;
						switch ( Utility.Random( 4 ) )
						{
							case 0: hue = PlantHue.Pink; break;
							case 1: hue = PlantHue.Magenta; break;
							case 2: hue = PlantHue.FireRed; break;
							default: hue = PlantHue.Aqua; break;
						}


						PackItem( new Seed( type, hue, false ) );
				}
				else if ( seed_to_give > 70 )
				{
					PackItem( Engines.Plants.Seed.RandomPeculiarSeed( Utility.RandomMinMax( 1, 4 ) ) );
				}
				else if ( seed_to_give > 40 )
				{
					PackItem( Engines.Plants.Seed.RandomBonsaiSeed() );
				}
				else
				{
					PackItem( new Engines.Plants.Seed() );
				}
			}
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
		}


		public override int TreasureMapLevel{ get{ return 2; } }
		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Green ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }


		public SwampDrake( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a beetle's corpse" )]
	public class TigerBeetle : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}


		[Constructable]
		public TigerBeetle () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a tiger beetle";
			Body = 0xA9;
			BaseSoundID = 0x388;


			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );


			SetHits( 80, 110 );


			SetDamage( 3, 10 );


			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 80 );


			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 20, 30 );


			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 75.0 );


			Fame = 3000;
			Karma = -3000;


			VirtualArmor = 16;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}


		public TigerBeetle( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;


			Body = 0xA9;
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class TopazWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }


		[Constructable]
		public TopazWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the topaz wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "topaz", "monster", 0 );


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );


			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "topaz scales" );
   			c.DropItem(scale);
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }


		public TopazWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Targeting;// using Server.Mobiles;// using Server.Commands;// using System.Collections.Generic;


namespace Server.Factions
{
	[CustomEnum( new string[]{ "Britain", "Magincia", "Minoc", "Moonglow", "Skara Brae", "Trinsic", "Vesper", "Yew" } )]
	public abstract class Town : IComparable
	{
		private TownDefinition m_Definition;
		private TownState m_State;


		public TownDefinition Definition
		{
			get{ return m_Definition; }
			set{ m_Definition = value; }
		}


		public TownState State
		{
			get{ return m_State; }
			set{ m_State = value; ConstructGuardLists(); }
		}


		public int Silver
		{
			get{ return m_State.Silver; }
			set{ m_State.Silver = value; }
		}


		public Faction Owner
		{
			get{ return m_State.Owner; }
			set{ Capture( value ); }
		}


		public Mobile Sheriff
		{
			get{ return m_State.Sheriff; }
			set{ m_State.Sheriff = value; }
		}


		public Mobile Finance
		{
			get{ return m_State.Finance; }
			set{ m_State.Finance = value; }
		}


		public int Tax
		{
			get{ return m_State.Tax; }
			set{ m_State.Tax = value; }
		}


		public DateTime LastTaxChange
		{
			get{ return m_State.LastTaxChange; }
			set{ m_State.LastTaxChange = value; }
		}


		public static readonly TimeSpan TaxChangePeriod = TimeSpan.FromHours( 12.0 );
		public static readonly TimeSpan IncomePeriod = TimeSpan.FromDays( 1.0 );


		public bool TaxChangeReady
		{
			get{ return ( m_State.LastTaxChange + TaxChangePeriod ) < DateTime.Now; }
		}


		public static Town FromRegion( Region reg )
		{
			if ( reg.Map != Faction.Facet )
				return null;


			List<Town> towns = Towns;


			for ( int i = 0; i < towns.Count; ++i )
			{
				Town town = towns[i];


				if ( reg.IsPartOf( town.Definition.Region ) )
					return town;
			}


			return null;
		}


		public int FinanceUpkeep
		{
			get
			{
				List<VendorList> vendorLists = VendorLists;
				int upkeep = 0;


				for ( int i = 0; i < vendorLists.Count; ++i )
					upkeep += vendorLists[i].Vendors.Count * vendorLists[i].Definition.Upkeep;


				return upkeep;
			}
		}


		public int SheriffUpkeep
		{
			get
			{
				List<GuardList> guardLists = GuardLists;
				int upkeep = 0;


				for ( int i = 0; i < guardLists.Count; ++i )
					upkeep += guardLists[i].Guards.Count * guardLists[i].Definition.Upkeep;


				return upkeep;
			}
		}


		public int DailyIncome
		{
			get{ return (10000 * (100 + m_State.Tax)) / 100; }
		}


		public int NetCashFlow
		{
			get{ return DailyIncome - FinanceUpkeep - SheriffUpkeep; }
		}


		public TownMonolith Monolith
		{
			get
			{
				List<BaseMonolith> monoliths = BaseMonolith.Monoliths;


				foreach ( BaseMonolith monolith in monoliths )
				{
					if ( monolith is TownMonolith )
					{
						TownMonolith townMonolith = (TownMonolith)monolith;


						if ( townMonolith.Town == this )
							return townMonolith;
					}
				}


				return null;
			}
		}


		public DateTime LastIncome
		{
			get{ return m_State.LastIncome; }
			set{ m_State.LastIncome = value; }
		}


		public void BeginOrderFiring( Mobile from )
		{
			bool isFinance = IsFinance( from );
			bool isSheriff = IsSheriff( from );
			string type = null;


			// NOTE: Messages not OSI-accurate, intentional
			if ( isFinance && isSheriff ) // GM only
				type = "vendor or guard";
			else if ( isFinance )
				type = "vendor";
			else if ( isSheriff )
				type = "guard";


			from.SendMessage( "Target the {0} you wish to dismiss.", type );
			from.BeginTarget( 12, false, TargetFlags.None, new TargetCallback( EndOrderFiring ) );
		}


		public void EndOrderFiring( Mobile from, object obj )
		{
			bool isFinance = IsFinance( from );
			bool isSheriff = IsSheriff( from );
			string type = null;


			if ( isFinance && isSheriff ) // GM only
				type = "vendor or guard";
			else if ( isFinance )
				type = "vendor";
			else if ( isSheriff )
				type = "guard";


			if ( obj is BaseFactionVendor )
			{
				BaseFactionVendor vendor = (BaseFactionVendor)obj;


				if ( vendor.Town == this && isFinance )
					vendor.Delete();
			}
			else if ( obj is BaseFactionGuard )
			{
				BaseFactionGuard guard = (BaseFactionGuard)obj;


				if ( guard.Town == this && isSheriff )
					guard.Delete();
			}
			else
			{
				from.SendMessage( "That is not a {0}!", type );
			}
		}


		private Timer m_IncomeTimer;


		public void StartIncomeTimer()
		{
			if ( m_IncomeTimer != null )
				m_IncomeTimer.Stop();


			m_IncomeTimer = Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), TimeSpan.FromMinutes( 1.0 ), new TimerCallback( CheckIncome ) );
		}


		public void StopIncomeTimer()
		{
			if ( m_IncomeTimer != null )
				m_IncomeTimer.Stop();


			m_IncomeTimer = null;
		}


		public void CheckIncome()
		{
			if ( (LastIncome + IncomePeriod) > DateTime.Now || Owner == null )
				return;


			ProcessIncome();
		}


		public void ProcessIncome()
		{
			LastIncome = DateTime.Now;


			int flow = NetCashFlow;


			if ( (Silver + flow) < 0 )
			{
				ArrayList toDelete = BuildFinanceList();


				while ( (Silver + flow) < 0 && toDelete.Count > 0 )
				{
					int index = Utility.Random( toDelete.Count );
					Mobile mob = (Mobile)toDelete[index];


					mob.Delete();


					toDelete.RemoveAt( index );
					flow = NetCashFlow;
				}
			}


			Silver += flow;
		}


		public ArrayList BuildFinanceList()
		{
			ArrayList list = new ArrayList();


			List<VendorList> vendorLists = VendorLists;


			for ( int i = 0; i < vendorLists.Count; ++i )
				list.AddRange( vendorLists[i].Vendors );


			List<GuardList> guardLists = GuardLists;


			for ( int i = 0; i < guardLists.Count; ++i )
				list.AddRange( guardLists[i].Guards );


			return list;
		}


		private List<VendorList> m_VendorLists;
		private List<GuardList> m_GuardLists;


		public List<VendorList> VendorLists
		{
			get{ return m_VendorLists; }
			set{ m_VendorLists = value; }
		}


		public List<GuardList> GuardLists
		{
			get{ return m_GuardLists; }
			set{ m_GuardLists = value; }
		}


		public void ConstructGuardLists()
		{
			GuardDefinition[] defs = ( Owner == null ? new GuardDefinition[0] : Owner.Definition.Guards );


			m_GuardLists = new List<GuardList>();


			for ( int i = 0; i < defs.Length; ++i )
				m_GuardLists.Add( new GuardList( defs[i] ) );
		}


		public GuardList FindGuardList( Type type )
		{
			List<GuardList> guardLists = GuardLists;


			for ( int i = 0; i < guardLists.Count; ++i )
			{
				GuardList guardList = guardLists[i];


				if ( guardList.Definition.Type == type )
					return guardList;
			}


			return null;
		}


		public void ConstructVendorLists()
		{
			VendorDefinition[] defs = VendorDefinition.Definitions;


			m_VendorLists = new List<VendorList>();


			for ( int i = 0; i < defs.Length; ++i )
				m_VendorLists.Add( new VendorList( defs[i] ) );
		}


		public VendorList FindVendorList( Type type )
		{
			List<VendorList> vendorLists = VendorLists;


			for ( int i = 0; i < vendorLists.Count; ++i )
			{
				VendorList vendorList = vendorLists[i];


				if ( vendorList.Definition.Type == type )
					return vendorList;
			}


			return null;
		}


		public bool RegisterGuard( BaseFactionGuard guard )
		{
			if ( guard == null )
				return false;


			GuardList guardList = FindGuardList( guard.GetType() );


			if ( guardList == null )
				return false;


			guardList.Guards.Add( guard );
			return true;
		}


		public bool UnregisterGuard( BaseFactionGuard guard )
		{
			if ( guard == null )
				return false;


			GuardList guardList = FindGuardList( guard.GetType() );


			if ( guardList == null )
				return false;


			if ( !guardList.Guards.Contains( guard ) )
				return false;


			guardList.Guards.Remove( guard );
			return true;
		}


		public bool RegisterVendor( BaseFactionVendor vendor )
		{
			if ( vendor == null )
				return false;


			VendorList vendorList = FindVendorList( vendor.GetType() );


			if ( vendorList == null )
				return false;


			vendorList.Vendors.Add( vendor );
			return true;
		}


		public bool UnregisterVendor( BaseFactionVendor vendor )
		{
			if ( vendor == null )
				return false;


			VendorList vendorList = FindVendorList( vendor.GetType() );


			if ( vendorList == null )
				return false;


			if ( !vendorList.Vendors.Contains( vendor ) )
				return false;


			vendorList.Vendors.Remove( vendor );
			return true;
		}


		public static void Initialize()
		{
			List<Town> towns = Towns;


			for ( int i = 0; i < towns.Count; ++i )
			{
				towns[i].Sheriff = towns[i].Sheriff;
				towns[i].Finance = towns[i].Finance;
			}


			CommandSystem.Register( "GrantTownSilver", AccessLevel.Administrator, new CommandEventHandler( GrantTownSilver_OnCommand ) );
		}


		public Town()
		{
			m_State = new TownState( this );
			ConstructVendorLists();
			ConstructGuardLists();
			StartIncomeTimer();
		}


		public bool IsSheriff( Mobile mob )
		{
			if ( mob == null || mob.Deleted )
				return false;


			return ( mob.AccessLevel >= AccessLevel.GameMaster || mob == Sheriff );
		}


		public bool IsFinance( Mobile mob )
		{
			if ( mob == null || mob.Deleted )
				return false;


			return ( mob.AccessLevel >= AccessLevel.GameMaster || mob == Finance );
		}


		public static List<Town> Towns { get { return Reflector.Towns; } }


		public const int SilverCaptureBonus = 10000;


		public void Capture( Faction f )
		{
			if ( m_State.Owner == f )
				return;


			if ( m_State.Owner == null ) // going from unowned to owned
			{
				LastIncome = DateTime.Now;
				f.Silver += SilverCaptureBonus;
			}
			else if ( f == null ) // going from owned to unowned
			{
				LastIncome = DateTime.MinValue;
			}
			else // otherwise changing hands, income timer doesn't change
			{
				f.Silver += SilverCaptureBonus;
			}


			m_State.Owner = f;


			Sheriff = null;
			Finance = null;


			TownMonolith monolith = this.Monolith;


			if ( monolith != null )
				monolith.Faction = f;


			List<VendorList> vendorLists = VendorLists;


			for ( int i = 0; i < vendorLists.Count; ++i )
			{
				VendorList vendorList = vendorLists[i];
				List<BaseFactionVendor> vendors = vendorList.Vendors;


				for ( int j = vendors.Count - 1; j >= 0; --j )
					vendors[j].Delete();
			}


			List<GuardList> guardLists = GuardLists;


			for ( int i = 0; i < guardLists.Count; ++i )
			{
				GuardList guardList = guardLists[i];
				List<BaseFactionGuard> guards = guardList.Guards;


				for ( int j = guards.Count - 1; j >= 0; --j )
					guards[j].Delete();
			}


			ConstructGuardLists();
		}


		public int CompareTo( object obj )
		{
			return m_Definition.Sort - ((Town)obj).m_Definition.Sort;
		}


		public override string ToString()
		{
			return m_Definition.FriendlyName;
		}


		public static void WriteReference( GenericWriter writer, Town town )
		{
			int idx = Towns.IndexOf( town );


			writer.WriteEncodedInt( (int) (idx + 1) );
		}


		public static Town ReadReference( GenericReader reader )
		{
			int idx = reader.ReadEncodedInt() - 1;


			if ( idx >= 0 && idx < Towns.Count )
				return Towns[idx];


			return null;
		}


		public static Town Parse( string name )
		{
			List<Town> towns = Towns;


			for ( int i = 0; i < towns.Count; ++i )
			{
				Town town = towns[i];


				if ( Insensitive.Equals( town.Definition.FriendlyName, name ) )
					return town;
			}


			return null;
		}


		public static void GrantTownSilver_OnCommand( CommandEventArgs e )
		{
			Town town = FromRegion( e.Mobile.Region );


			if ( town == null )
				e.Mobile.SendMessage( "You are not in a faction town." );
			else if ( e.Length == 0 )
				e.Mobile.SendMessage( "Format: GrantTownSilver <amount>" );
			else
			{
				town.Silver += e.GetInt32( 0 );
				e.Mobile.SendMessage( "You have granted {0:N0} silver to the town. It now has {1:N0} silver.", e.GetInt32( 0 ), town.Silver );
			}
		}
	}
}
// using System;


namespace Server.Factions
{
	public class TownDefinition
	{
		private int m_Sort;
		private int m_SigilID;


		private string m_Region;


		private string m_FriendlyName;


		private TextDefinition m_TownName;
		private TextDefinition m_TownStoneHeader;
		private TextDefinition m_StrongholdMonolithName;
		private TextDefinition m_TownMonolithName;
		private TextDefinition m_TownStoneName;
		private TextDefinition m_SigilName;
		private TextDefinition m_CorruptedSigilName;


		private Point3D m_Monolith;
		private Point3D m_TownStone;


		public int Sort{ get{ return m_Sort; } }
		public int SigilID{ get{ return m_SigilID; } }


		public string Region{ get{ return m_Region; } }
		public string FriendlyName{ get{ return m_FriendlyName; } }


		public TextDefinition TownName{ get{ return m_TownName; } }
		public TextDefinition TownStoneHeader{ get{ return m_TownStoneHeader; } }
		public TextDefinition StrongholdMonolithName{ get{ return m_StrongholdMonolithName; } }
		public TextDefinition TownMonolithName{ get{ return m_TownMonolithName; } }
		public TextDefinition TownStoneName{ get{ return m_TownStoneName; } }
		public TextDefinition SigilName{ get{ return m_SigilName; } }
		public TextDefinition CorruptedSigilName{ get{ return m_CorruptedSigilName; } }


		public Point3D Monolith{ get{ return m_Monolith; } }
		public Point3D TownStone{ get{ return m_TownStone; } }


		public TownDefinition( int sort, int sigilID, string region, string friendlyName, TextDefinition townName, TextDefinition townStoneHeader, TextDefinition strongholdMonolithName, TextDefinition townMonolithName, TextDefinition townStoneName, TextDefinition sigilName, TextDefinition corruptedSigilName, Point3D monolith, Point3D townStone )
		{
			m_Sort = sort;
			m_SigilID = sigilID;
			m_Region = region;
			m_FriendlyName = friendlyName;
			m_TownName = townName;
			m_TownStoneHeader = townStoneHeader;
			m_StrongholdMonolithName = strongholdMonolithName;
			m_TownMonolithName = townMonolithName;
			m_TownStoneName = townStoneName;
			m_SigilName = sigilName;
			m_CorruptedSigilName = corruptedSigilName;
			m_Monolith = monolith;
			m_TownStone = townStone;
		}
	}
}
// using System;


namespace Server.Factions
{
	public class TownMonolith : BaseMonolith
	{
		public override int DefaultLabelNumber{ get{ return 1041403; } } // A Faction Town Sigil Monolith


		public override void OnTownChanged()
		{
			AssignName( Town == null ? null : Town.Definition.TownMonolithName );
		}


		public TownMonolith() : this( null )
		{
		}


		public TownMonolith( Town town ) : base( town, null )
		{
		}


		public TownMonolith( Serial serial ) : base( serial )
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
// using System;


namespace Server.Factions
{
	public class TownState
	{
		private Town m_Town;
		private Faction m_Owner;


		private Mobile m_Sheriff;
		private Mobile m_Finance;


		private int m_Silver;
		private int m_Tax;


		private DateTime m_LastTaxChange;
		private DateTime m_LastIncome;


		public Town Town
		{
			get{ return m_Town; }
			set{ m_Town = value; }
		}


		public Faction Owner
		{
			get{ return m_Owner; }
			set{ m_Owner = value; }
		}


		public Mobile Sheriff
		{
			get{ return m_Sheriff; }
			set
			{
				if ( m_Sheriff != null )
				{
					PlayerState pl = PlayerState.Find( m_Sheriff );


					if ( pl != null )
						pl.Sheriff = null;
				}


				m_Sheriff = value;


				if ( m_Sheriff != null )
				{
					PlayerState pl = PlayerState.Find( m_Sheriff );


					if ( pl != null )
						pl.Sheriff = m_Town;
				}
			}
		}


		public Mobile Finance
		{
			get{ return m_Finance; }
			set
			{
				if ( m_Finance != null )
				{
					PlayerState pl = PlayerState.Find( m_Finance );


					if ( pl != null )
						pl.Finance = null;
				}


				m_Finance = value;


				if ( m_Finance != null )
				{
					PlayerState pl = PlayerState.Find( m_Finance );


					if ( pl != null )
						pl.Finance = m_Town;
				}
			}
		}


		public int Silver
		{
			get{ return m_Silver; }
			set{ m_Silver = value; }
		}


		public int Tax
		{
			get{ return m_Tax; }
			set{ m_Tax = value; }
		}


		public DateTime LastTaxChange
		{
			get{ return m_LastTaxChange; }
			set{ m_LastTaxChange = value; }
		}


		public DateTime LastIncome
		{
			get{ return m_LastIncome; }
			set{ m_LastIncome = value; }
		}


		public TownState( Town town )
		{
			m_Town = town;
		}


		public TownState( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();


			switch ( version )
			{
				case 3:
				{
					m_LastIncome = reader.ReadDateTime();


					goto case 2;
				}
				case 2:
				{
					m_Tax = reader.ReadEncodedInt();
					m_LastTaxChange = reader.ReadDateTime();


					goto case 1;
				}
				case 1:
				{
					m_Silver = reader.ReadEncodedInt();


					goto case 0;
				}
				case 0:
				{
					m_Town = Town.ReadReference( reader );
					m_Owner = Faction.ReadReference( reader );


					m_Sheriff = reader.ReadMobile();
					m_Finance = reader.ReadMobile();


					m_Town.State = this;


					break;
				}
			}
		}


		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 3 ); // version


			writer.Write( (DateTime) m_LastIncome );


			writer.WriteEncodedInt( (int) m_Tax );
			writer.Write( (DateTime) m_LastTaxChange );


			writer.WriteEncodedInt( (int) m_Silver );


			Town.WriteReference( writer, m_Town );
			Faction.WriteReference( writer, m_Owner );


			writer.Write( (Mobile) m_Sheriff );
			writer.Write( (Mobile) m_Finance );
		}
	}
}
// using System;// using Server;// using Server.Mobiles;// using Server.Network;


namespace Server.Factions
{
	public class TownStone : BaseSystemController
	{
		private Town m_Town;


		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Town Town
		{
			get{ return m_Town; }
			set
			{
				m_Town = value;


				AssignName( m_Town == null ? null : m_Town.Definition.TownStoneName );
			}
		}


		public override string DefaultName { get { return "faction town stone"; } }


		[Constructable]
		public TownStone() : this( null )
		{
		}


		[Constructable]
		public TownStone( Town town ) : base( 0xEDE )
		{
			Movable = false;
			Town = town;
		}


		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Town == null )
				return;


			Faction faction = Faction.Find( from );


			if ( faction == null && from.AccessLevel < AccessLevel.GameMaster )
				return; // TODO: Message?


			if ( m_Town.Owner == null || ( from.AccessLevel < AccessLevel.GameMaster && faction != m_Town.Owner ) )
				from.SendLocalizedMessage( 1010332 ); // Your faction does not control this town
			else if ( !m_Town.Owner.IsCommander( from ) )
				from.SendLocalizedMessage( 1005242 ); // Only faction Leaders can use townstones
			else if ( FactionGump.Exists( from ) )
				from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
			else if ( from is PlayerMobile )
				from.SendGump( new TownStoneGump( (PlayerMobile)from, m_Town.Owner, m_Town ) );
		}


		public TownStone( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );


			writer.Write( (int) 0 ); // version


			Town.WriteReference( writer, m_Town );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );


			int version = reader.ReadInt();


			switch ( version )
			{
				case 0:
				{
					Town = Town.ReadReference( reader );
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using Server.Targeting;


namespace Server.Factions
{
	public class TownStoneGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;
		private Town m_Town;


		public TownStoneGump( PlayerMobile from, Faction faction, Town town ) : base( 50, 50 )
		{
			m_From = from;
			m_Faction = faction;
			m_Town = town;


			AddPage( 0 );


			AddBackground( 0, 0, 320, 250, 5054 );
			AddBackground( 10, 10, 300, 230, 3000 );


			AddHtmlText( 25, 30, 250, 25, town.Definition.TownStoneHeader, false, false );


			AddHtmlLocalized( 55, 60, 150, 25, 1011557, false, false ); // Hire Sheriff
			AddButton( 20, 60, 4005, 4007, 1, GumpButtonType.Reply, 0 );


			AddHtmlLocalized( 55, 90, 150, 25, 1011559, false, false ); // Hire Finance Minister
			AddButton( 20, 90, 4005, 4007, 2, GumpButtonType.Reply, 0 );


			AddHtmlLocalized( 55, 120, 150, 25, 1011558, false, false ); // Fire Sheriff
			AddButton( 20, 120, 4005, 4007, 3, GumpButtonType.Reply, 0 );


			AddHtmlLocalized( 55, 150, 150, 25, 1011560, false, false ); // Fire Finance Minister
			AddButton( 20, 150, 4005, 4007, 4, GumpButtonType.Reply, 0 );


			AddHtmlLocalized( 55, 210, 150, 25, 1011441, false, false ); // EXIT
			AddButton( 20, 210, 4005, 4007, 0, GumpButtonType.Reply, 0 );
		}


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Town.Owner != m_Faction || !m_Faction.IsCommander( m_From ) )
			{
				m_From.SendLocalizedMessage( 1010339 ); // You no longer control this city
				return;
			}


			switch ( info.ButtonID )
			{
				case 1: // hire sheriff
				{
					if ( m_Town.Sheriff != null )
					{
						m_From.SendLocalizedMessage( 1010342 ); // You must fire your Sheriff before you can elect a new one
					}
					else
					{
						m_From.SendLocalizedMessage( 1010347 ); // Who shall be your new sheriff
						m_From.BeginTarget( 12, false, TargetFlags.None, new TargetCallback( HireSheriff_OnTarget ) );
					}


					break;
				}
				case 2: // hire finance minister
				{
					if ( m_Town.Finance != null )
					{
						m_From.SendLocalizedMessage( 1010345 ); // You must fire your finance minister before you can elect a new one
					}
					else
					{
						m_From.SendLocalizedMessage( 1010348 ); // Who shall be your new Minister of Finances?
						m_From.BeginTarget( 12, false, TargetFlags.None, new TargetCallback( HireFinanceMinister_OnTarget ) );
					}


					break;
				}
				case 3: // fire sheriff
				{
					if ( m_Town.Sheriff == null )
					{
						m_From.SendLocalizedMessage( 1010350 ); // You need to elect a sheriff before you can fire one
					}
					else
					{
						m_From.SendLocalizedMessage( 1010349 ); // You have fired your sheriff
						m_Town.Sheriff.SendLocalizedMessage( 1010270 ); // You have been fired as Sheriff
						m_Town.Sheriff = null;
					}


					break;
				}
				case 4: // fire finance minister
				{
					if ( m_Town.Finance == null )
					{
						m_From.SendLocalizedMessage( 1010352 ); // You need to elect a financial minister before you can fire one
					}
					else
					{
						m_From.SendLocalizedMessage( 1010351 ); // You have fired your financial Minister
						m_Town.Finance.SendLocalizedMessage( 1010151 ); // You have been fired as Finance Minister
						m_Town.Finance = null;
					}


					break;
				}
			}
		}


		private void HireSheriff_OnTarget( Mobile from, object obj )
		{
			if ( m_Town.Owner != m_Faction || !m_Faction.IsCommander( from ) )
			{
				from.SendLocalizedMessage( 1010339 ); // You no longer control this city
				return;
			}
			else if ( m_Town.Sheriff != null )
			{
				from.SendLocalizedMessage( 1010342 ); // You must fire your Sheriff before you can elect a new one
			}
			else if ( obj is Mobile )
			{
				Mobile targ = (Mobile)obj;
				PlayerState pl = PlayerState.Find( targ );


				if ( pl == null )
				{
					from.SendLocalizedMessage( 1010337 ); // You must pick someone in a faction
				}
				else if ( pl.Faction != m_Faction )
				{
					from.SendLocalizedMessage( 1010338 ); // You must pick someone in the correct faction
				}
				else if ( m_Faction.Commander == targ )
				{
					from.SendLocalizedMessage( 1010335 ); // You cannot elect a commander to a town position
				}
				else if ( pl.Sheriff != null || pl.Finance != null )
				{
					from.SendLocalizedMessage( 1005245 ); // You must pick someone who does not already hold a city post
				}
				else
				{
					m_Town.Sheriff = targ;
					targ.SendLocalizedMessage( 1010340 ); // You are now the Sheriff
					from.SendLocalizedMessage( 1010341 ); // You have elected a Sheriff
				}
			}
			else
			{
				from.SendLocalizedMessage( 1010334 ); // You must select a player to hold a city position!
			}
		}


		private void HireFinanceMinister_OnTarget( Mobile from, object obj )
		{
			if ( m_Town.Owner != m_Faction || !m_Faction.IsCommander( from ) )
			{
				from.SendLocalizedMessage( 1010339 ); // You no longer control this city
				return;
			}
			else if ( m_Town.Finance != null )
			{
				from.SendLocalizedMessage( 1010342 ); // You must fire your Sheriff before you can elect a new one
			}
			else if ( obj is Mobile )
			{
				Mobile targ = (Mobile)obj;
				PlayerState pl = PlayerState.Find( targ );


				if ( pl == null )
				{
					from.SendLocalizedMessage( 1010337 ); // You must pick someone in a faction
				}
				else if ( pl.Faction != m_Faction )
				{
					from.SendLocalizedMessage( 1010338 ); // You must pick someone in the correct faction
				}
				else if ( m_Faction.Commander == targ )
				{
					from.SendLocalizedMessage( 1010335 ); // You cannot elect a commander to a town position
				}
				else if ( pl.Sheriff != null || pl.Finance != null )
				{
					from.SendLocalizedMessage( 1005245 ); // You must pick someone who does not already hold a city post
				}
				else
				{
					m_Town.Finance = targ;
					targ.SendLocalizedMessage( 1010343 ); // You are now the Financial Minister
					from.SendLocalizedMessage( 1010344 ); // You have elected a Financial Minister
				}
			}
			else
			{
				from.SendLocalizedMessage( 1010334 ); // You must select a player to hold a city position!
			}
		}
	}
}
// using System;// using Server;// using Server.Network;// using System.Collections;// using System.Collections.Generic;// using Server.Items;// using Server.Gumps;// using Server.Misc;// using Server.Mobiles;


// using System;// using System.Collections.Generic;


namespace Server.Factions
{
	public class Trinsic : Town
	{
		public Trinsic()
		{
			Definition =
				new TownDefinition(
					1,
					0x186A,
					"Trinsic",
					"Trinsic",
					new TextDefinition( 1011434, "TRINSIC" ),
					new TextDefinition( 1011562, "TOWN STONE FOR TRINSIC" ),
					new TextDefinition( 1041035, "The Faction Sigil Monolith of Trinsic" ),
					new TextDefinition( 1041405, "The Faction Town Sigil Monolith of Trinsic" ),
					new TextDefinition( 1041414, "Faction Town Stone of Trinsic" ),
					new TextDefinition( 1041396, "Faction Town Sigil of Trinsic" ),
					new TextDefinition( 1041387, "Corrupted Faction Town Sigil of Trinsic" ),
					new Point3D( 1914, 2717, 20 ),
					new Point3D( 1909, 2720, 20 ) );
		}
	}
}
// using System;// using Server;


namespace Server.Factions
{
	public class TrueBritannians : Faction
	{
		private static Faction m_Instance;


		public static Faction Instance{ get{ return m_Instance; } }


		public TrueBritannians()
		{
			m_Instance = this;


			Definition =
				new FactionDefinition(
					2,
					1254, // dark purple
					2125, // gold
					2214, // join stone : gold
					2125, // broadcast : gold
					0x76, 0x3EB2, // war horse
					"True Britannians", "true", "TB", 
					new TextDefinition( 1011536, "LORD BRITISH" ),
					new TextDefinition( 1060771, "True Britannians faction" ),
					new TextDefinition( 1011423, "<center>TRUE BRITANNIANS</center>" ),
					new TextDefinition( 1011450,
						"True Britannians are loyal to the throne of Lord British. They refuse " +
						"to give up their homelands to the vile Minax, and detest the Shadowlords " +
						"for their evil ways. In addition, the Council of Mages threatens the " +
						"existence of their ruler, and as such they have armed themselves, and " +
						"prepare for war with all." ),
					new TextDefinition( 1011454, "This city is controlled by Lord British." ),
					new TextDefinition( 1042254, "This sigil has been corrupted by the True Britannians" ),
					new TextDefinition( 1041045, "The faction signup stone for the True Britannians" ),
					new TextDefinition( 1041383, "The Faction Stone of the True Britannians" ),
					new TextDefinition( 1011465, ": True Britannians" ),
					new TextDefinition( 1005181, "Followers of Lord British will now be ignored." ),
					new TextDefinition( 1005182, "Followers of Lord British will now be warned of their impending doom." ),
					new TextDefinition( 1005183, "Followers of Lord British will now be attacked on sight." ),
					new StrongholdDefinition(
						new Rectangle2D[]
						{
							new Rectangle2D( 5192, 3934, 1, 1 ) // WIZARD
						},
						new Point3D( 1419, 1622, 20 ),
						new Point3D( 1330, 1621, 50 ),
						new Point3D[]
						{
							new Point3D( 1328, 1627, 50 ),
							new Point3D( 1328, 1621, 50 ),
							new Point3D( 1334, 1627, 50 ),
							new Point3D( 1334, 1621, 50 ),
							new Point3D( 1340, 1627, 50 ),
							new Point3D( 1340, 1621, 50 ),
							new Point3D( 1345, 1621, 50 ),
							new Point3D( 1345, 1627, 50 )
						} ),
					new RankDefinition[]
					{
						new RankDefinition( 10, 991, 8, new TextDefinition( 1060794, "Knight of the Codex" ) ),
						new RankDefinition(  9, 950, 7, new TextDefinition( 1060793, "Knight of Virtue" ) ),
						new RankDefinition(  8, 900, 6, new TextDefinition( 1060792, "Crusader" ) ),
						new RankDefinition(  7, 800, 6, new TextDefinition( 1060792, "Crusader" ) ),
						new RankDefinition(  6, 700, 5, new TextDefinition( 1060791, "Sentinel" ) ),
						new RankDefinition(  5, 600, 5, new TextDefinition( 1060791, "Sentinel" ) ),
						new RankDefinition(  4, 500, 5, new TextDefinition( 1060791, "Sentinel" ) ),
						new RankDefinition(  3, 400, 4, new TextDefinition( 1060790, "Defender" ) ),
						new RankDefinition(  2, 200, 4, new TextDefinition( 1060790, "Defender" ) ),
						new RankDefinition(  1,   0, 4, new TextDefinition( 1060790, "Defender" ) )
					},
					new GuardDefinition[]
					{
						new GuardDefinition( typeof( FactionHenchman ),		0x1403, 5000, 1000, 10,		new TextDefinition( 1011526, "HENCHMAN" ),		new TextDefinition( 1011510, "Hire Henchman" ) ),
						new GuardDefinition( typeof( FactionMercenary ),	0x0F62, 6000, 2000, 10,		new TextDefinition( 1011527, "MERCENARY" ),		new TextDefinition( 1011511, "Hire Mercenary" ) ),
						new GuardDefinition( typeof( FactionKnight ),		0x0F4D, 7000, 3000, 10,		new TextDefinition( 1011528, "KNIGHT" ),		new TextDefinition( 1011497, "Hire Knight" ) ),
						new GuardDefinition( typeof( FactionPaladin ),		0x143F, 8000, 4000, 10,		new TextDefinition( 1011529, "PALADIN" ),		new TextDefinition( 1011498, "Hire Paladin" ) ),
					}
				);
		}
	}
}
// using System;// using Server;// using Server.Ethics;// using Server.Mobiles;


namespace Server.Mobiles
{
	[CorpseName( "an evil corpse" )]
	public class UnholyFamiliar : BaseCreature
	{
		public override bool IsDispellable { get { return false; } }
		public override bool IsBondable { get { return false; } }


		[Constructable]
		public UnholyFamiliar()
			: base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dark wolf";
			Body = 225;
			Hue = 1109;
			BaseSoundID = 0xE5;


			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );


			SetHits( 58, 72 );
			SetMana( 0 );


			SetDamage( 11, 17 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 10, 15 );


			SetSkill( SkillName.MagicResist, 57.6, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );


			Fame = 2500;
			Karma = 2500;


			VirtualArmor = 22;


			Tamable = false;
			ControlSlots = 1;
		}


		public override int Meat { get { return 1; } }
		public override int Hides { get { return 7; } }
		public override FoodType FavoriteFood { get { return FoodType.Meat; } }
		public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }


		public UnholyFamiliar( Serial serial )
			: base( serial )
		{
		}


		public override string ApplyNameSuffix( string suffix )
		{
			if ( suffix.Length == 0 )
				suffix = Ethic.Evil.Definition.Adjunct.String;
			else
				suffix = String.Concat( suffix, " ", Ethic.Evil.Definition.Adjunct.String );


			return base.ApplyNameSuffix( suffix );
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
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Items;


namespace Server.Ethics.Evil
{
	public sealed class UnholyItem : Power
	{
		public UnholyItem()
		{
			m_Definition = new PowerDefinition(
					5,
					"Unholy Item",
					"Vidda K'balc",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			from.Mobile.BeginTarget( 12, false, Targeting.TargetFlags.None, new TargetStateCallback( Power_OnTarget ), from );
			from.Mobile.SendMessage( "Which item do you wish to imbue?" );
		}


		private void Power_OnTarget( Mobile fromMobile, object obj, object state )
		{
			Player from = state as Player;


			Item item = obj as Item;


			if ( item == null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that." );
				return;
			}


			if ( item.Parent != from.Mobile )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may only imbue items you are wearing." );
				return;
			}


			if ( ( item.SavedFlags & 0x300 ) != 0 )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "That has already beem imbued." );
				return;
			}


			bool canImbue = ( item is Spellbook || item is BaseClothing || item is BaseArmor || item is BaseWeapon ) && ( item.Name == null );


			if ( canImbue )
			{
				if ( !CheckInvoke( from ) )
					return;


				item.Hue = Ethic.Evil.Definition.PrimaryHue;
				item.SavedFlags |= 0x200;


				from.Mobile.FixedEffect( 0x375A, 10, 20 );
				from.Mobile.PlaySound( 0x209 );


				FinishInvoke( from );
			}
			else
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that." );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics.Evil
{
	public sealed class UnholySense : Power
	{
		public UnholySense()
		{
			m_Definition = new PowerDefinition(
					0,
					"Unholy Sense",
					"Drewrok Velgo",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			Ethic opposition = Ethic.Hero;


			int enemyCount = 0;


			int maxRange = 18 + from.Power;


			Player primary = null;


			foreach ( Player pl in opposition.Players )
			{
				Mobile mob = pl.Mobile;


				if ( mob == null || mob.Map != from.Mobile.Map || !mob.Alive )
					continue;


				if ( !mob.InRange( from.Mobile, Math.Max( 18, maxRange - pl.Power ) ) )
					continue;


				if ( primary == null || pl.Power > primary.Power )
					primary = pl;


				++enemyCount;
			}


			StringBuilder sb = new StringBuilder();


			sb.Append( "You sense " );
			sb.Append( enemyCount == 0 ? "no" : enemyCount.ToString() );
			sb.Append( enemyCount == 1 ? " enemy" : " enemies" );


			if ( primary != null )
			{
				sb.Append( ", and a strong presense" );


				switch ( from.Mobile.GetDirectionTo( primary.Mobile ) )
				{
					case Direction.West:
						sb.Append( " to the west." );
						break;
					case Direction.East:
						sb.Append( " to the east." );
						break;
					case Direction.North:
						sb.Append( " to the north." );
						break;
					case Direction.South:
						sb.Append( " to the south." );
						break;


					case Direction.Up:
						sb.Append( " to the north-west." );
						break;
					case Direction.Down:
						sb.Append( " to the south-east." );
						break;
					case Direction.Left:
						sb.Append( " to the south-west." );
						break;
					case Direction.Right:
						sb.Append( " to the north-east." );
						break;
				}
			}
			else
			{
				sb.Append( '.' );
			}


			from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x59, false, sb.ToString() );


			FinishInvoke( from );
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics.Evil
{
	public sealed class UnholyShield : Power
	{
		public UnholyShield()
		{
			m_Definition = new PowerDefinition(
					20,
					"Unholy Shield",
					"Velgo K'blac",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			if ( from.IsShielded )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You are already under the protection of an unholy shield." );
				return;
			}


			from.BeginShield();


			from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You are now under the protection of an unholy shield." );


			FinishInvoke( from );
		}
	}
}// using System;// using Server;// using Server.Mobiles;// using Server.Ethics;


namespace Server.Mobiles
{
	[CorpseName( "an unholy corpse" )]
	public class UnholySteed : BaseMount
	{
		public override bool IsDispellable { get { return false; } }
		public override bool IsBondable { get { return false; } }


		public override bool HasBreath { get { return true; } }
		public override bool CanBreath { get { return true; } }


		[Constructable]
		public UnholySteed()
			: base( "a dark steed", 0x74, 0x3EA7, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );


			SetHits( 298, 315 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );


			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 80.5, 92.5 );


			Fame = 14000;
			Karma = -14000;


			VirtualArmor = 60;


			Tamable = false;
			ControlSlots = 1;
		}


		public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }


		public UnholySteed( Serial serial )
			: base( serial )
		{
		}


		public override string ApplyNameSuffix( string suffix )
		{
			if ( suffix.Length == 0 )
				suffix = Ethic.Evil.Definition.Adjunct.String;
			else
				suffix = String.Concat( suffix, " ", Ethic.Evil.Definition.Adjunct.String );


			return base.ApplyNameSuffix( suffix );
		}


		public override void OnDoubleClick( Mobile from )
		{
			if ( Ethic.Find( from ) != Ethic.Evil )
				from.SendMessage( "You may not ride this steed." );
			else
				base.OnDoubleClick( from );
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
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;


namespace Server.Ethics.Evil
{
	public sealed class UnholySteed : Power
	{
		public UnholySteed()
		{
			m_Definition = new PowerDefinition(
					30,
					"Unholy Steed",
					"Trubechs Yeliab",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
			if ( from.Steed != null && from.Steed.Deleted )
				from.Steed = null;


			if ( from.Steed != null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You already have an unholy steed." );
				return;
			}


			if ( ( from.Mobile.Followers + 1 ) > from.Mobile.FollowersMax )
			{
				from.Mobile.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return;
			}


			Mobiles.UnholySteed steed = new Mobiles.UnholySteed();


			if ( Mobiles.BaseCreature.Summon( steed, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours( 1.0 ) ) )
			{
				from.Steed = steed;


				FinishInvoke( from );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics.Evil
{
	public sealed class UnholyWord : Power
	{
		public UnholyWord()
		{
			m_Definition = new PowerDefinition(
					100,
					"Unholy Word",
					"Velgo Oostrac",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
		}
	}
}// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Gumps;// using Server.Mobiles;// using Server.Targeting;// using Server.Engines.CannedEvil;

namespace Server.Factions
{
	public class VendorDefinition
	{
		private Type m_Type;


		private int m_Price;
		private int m_Upkeep;
		private int m_Maximum;


		private int m_ItemID;


		private TextDefinition m_Header;
		private TextDefinition m_Label;


		public Type Type{ get{ return m_Type; } }


		public int Price{ get{ return m_Price; } }
		public int Upkeep{ get{ return m_Upkeep; } }
		public int Maximum{ get{ return m_Maximum; } }
		public int ItemID{ get{ return m_ItemID; } }


		public TextDefinition Header{ get{ return m_Header; } }
		public TextDefinition Label{ get{ return m_Label; } }


		public VendorDefinition( Type type, int itemID, int price, int upkeep, int maximum, TextDefinition header, TextDefinition label )
		{
			m_Type = type;


			m_Price = price;
			m_Upkeep = upkeep;
			m_Maximum = maximum;
			m_ItemID = itemID;


			m_Header = header;
			m_Label = label;
		}


		private static VendorDefinition[] m_Definitions = new VendorDefinition[]
			{
				new VendorDefinition( typeof( FactionBottleVendor ), 0xF0E,
					5000,
					1000,
					10,
					new TextDefinition( 1011549, "POTION BOTTLE VENDOR" ),
					new TextDefinition( 1011544, "Buy Potion Bottle Vendor" )
				),
				new VendorDefinition( typeof( FactionBoardVendor ), 0x1BD7,
					3000,
					500,
					10,
					new TextDefinition( 1011552, "WOOD VENDOR" ),
					new TextDefinition( 1011545, "Buy Wooden Board Vendor" )
				),
				new VendorDefinition( typeof( FactionOreVendor ), 0x19B8,
					3000,
					500,
					10,
					new TextDefinition( 1011553, "IRON ORE VENDOR" ),
					new TextDefinition( 1011546, "Buy Iron Ore Vendor" )
				),
				new VendorDefinition( typeof( FactionReagentVendor ), 0xF86,
					5000,
					1000,
					10,
					new TextDefinition( 1011554, "REAGENT VENDOR" ),
					new TextDefinition( 1011547, "Buy Reagent Vendor" )
				),
				new VendorDefinition( typeof( FactionHorseVendor ), 0x20DD,
					5000,
					1000,
					1,
					new TextDefinition( 1011556, "HORSE BREEDER" ),
					new TextDefinition( 1011555, "Buy Horse Breeder" )
				)
			};


		public static VendorDefinition[] Definitions{ get{ return m_Definitions; } }
	}
}
// using System;// using Server;// using System.Collections.Generic;


namespace Server.Factions
{
	public class VendorList
	{
		private VendorDefinition m_Definition;
		private List<BaseFactionVendor> m_Vendors;


		public VendorDefinition Definition{ get{ return m_Definition; } }
		public List<BaseFactionVendor> Vendors { get { return m_Vendors; } }


		public BaseFactionVendor Construct( Town town, Faction faction )
		{
			try{ return Activator.CreateInstance( m_Definition.Type, new object[]{ town, faction } ) as BaseFactionVendor; }
			catch{ return null; }
		}


		public VendorList( VendorDefinition definition )
		{
			m_Definition = definition;
			m_Vendors = new List<BaseFactionVendor>();
		}
	}
}
// using System;


namespace Server.Factions
{
	public class Vesper : Town
	{
		public Vesper()
		{
			Definition =
				new TownDefinition(
					5,
					0x186E,
					"Vesper",
					"Vesper",
					new TextDefinition( 1016413, "VESPER" ),
					new TextDefinition( 1011566, "TOWN STONE FOR VESPER" ),
					new TextDefinition( 1041039, "The Faction Sigil Monolith of Vesper" ),
					new TextDefinition( 1041409, "The Faction Town Sigil Monolith of Vesper" ),
					new TextDefinition( 1041418, "Faction Town Stone of Vesper" ),
					new TextDefinition( 1041400, "Faction Town Sigil of Vesper" ),
					new TextDefinition( 1041391, "Corrupted Faction Town Sigil of Vesper" ),
					new Point3D( 2982, 818, 0 ),
					new Point3D( 2985, 821, 0 ) );
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;


namespace Server.Ethics.Evil
{
	public sealed class VileBlade : Power
	{
		public VileBlade()
		{
			m_Definition = new PowerDefinition(
					10,
					"Vile Blade",
					"Velgo Reyam",
					""
				);
		}


		public override void BeginInvoke( Player from )
		{
		}
	}
}// using System;// using System.Collections;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;



namespace Server.Factions
{
	public class VoteGump : FactionGump
	{
		private PlayerMobile m_From;
		private Election m_Election;


		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 0 )
			{
				m_From.SendGump( new FactionStoneGump( m_From, m_Election.Faction ) );
			}
			else
			{
				if ( !m_Election.CanVote( m_From ) )
					return;


				int index = info.ButtonID - 1;


				if ( index >= 0 && index < m_Election.Candidates.Count )
					m_Election.Candidates[index].Voters.Add( new Voter( m_From, m_Election.Candidates[index].Mobile ) );


				m_From.SendGump( new VoteGump( m_From, m_Election ) );
			}
		}


		public VoteGump( PlayerMobile from, Election election ) : base( 50, 50 )
		{
			m_From = from;
			m_Election = election;


			bool canVote = election.CanVote( from );


			AddPage( 0 );


			AddBackground( 0, 0, 420, 350, 5054 );
			AddBackground( 10, 10, 400, 330, 3000 );


			AddHtmlText( 20, 20, 380, 20, election.Faction.Definition.Header, false, false );


			if ( canVote )
				AddHtmlLocalized( 20, 60, 380, 20, 1011428, false, false ); // VOTE FOR LEADERSHIP
			else
				AddHtmlLocalized( 20, 60, 380, 20, 1038032, false, false ); // You have already voted in this election.


			for ( int i = 0; i < election.Candidates.Count; ++i )
			{
				Candidate cd = election.Candidates[i];


				if ( canVote )
					AddButton( 20, 100 + (i * 20), 4005, 4007, i + 1, GumpButtonType.Reply, 0 );


				AddLabel( 55, 100 + (i * 20), 0, cd.Mobile.Name );
				AddLabel( 300, 100 + (i * 20), 0, cd.Votes.ToString() );
			}


			AddButton( 20, 310, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 55, 310, 100, 20, 1011012, false, false ); // CANCEL
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a water beetle corpse" )]
	public class WaterBeetle : BaseCreature
	{
		[Constructable]
		public WaterBeetle() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a water beetle";
			Body = 0xA9;
			Hue = 1365;
			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );


			CanSwim = true;


			SetHits( 80, 110 );


			SetDamage( 3, 10 );


			SetDamageType( ResistanceType.Physical, 100 );


			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 20, 30 );


			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 75.0 );


			Fame = 3000;
			Karma = -3000;


			VirtualArmor = 16;
		}


		public override bool BleedImmune{ get{ return true; } }


		public override int GetAngerSound()
		{
			return 0x21D;
		}


		public override int GetIdleSound()
		{
			return 0x21D;
		}


		public override int GetAttackSound()
		{
			return 0x162;
		}


		public override int GetHurtSound()
		{
			return 0x163;
		}


		public override int GetDeathSound()
		{
			return 0x21D;
		}


		public WaterBeetle( Serial serial ) : base( serial )
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


			Body = 0xA9;
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;


namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class WhiteDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }


		[Constructable]
		public WhiteDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a white dragon";
			Body = 12;
			Hue = 0x9C2;
			BaseSoundID = 362;


			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );


			SetHits( 478, 495 );


			SetDamage( 16, 22 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );


			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );


			SetSkill( SkillName.EvalInt, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 92.5 );


			Fame = 15000;
			Karma = -15000;


			VirtualArmor = 60;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}


		public override void OnDeath( Container c )
		{
			base.OnDeath( c );


			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();


				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "White", "", c, 25, 0 );
				}
			}
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}


		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.White ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public WhiteDragon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class WhiteWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }


		[Constructable]
		public WhiteWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the white wyrm";
			BaseSoundID = 362;
			Hue = 0x9C2;
			Body = Server.Misc.MyServerSettings.WyrmBody();


			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );


			SetHits( 433, 456 );


			SetDamage( 17, 25 );


			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );


			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );


			SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );


			Fame = 18000;
			Karma = -18000;


			VirtualArmor = 64;


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}


		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Frozen; } else { return HideType.Draconic; } } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.White; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public WhiteWyrm( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();


			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server.Items;


namespace Server.Mobiles
{
	[CorpseName( "a wyvern corpse" )]
	public class Wyvern : BaseCreature
	{
		[Constructable]
		public Wyvern () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a wyvern";
			Body = 62;
			BaseSoundID = 362;


			SetStr( 202, 240 );
			SetDex( 153, 172 );
			SetInt( 51, 90 );


			SetHits( 125, 141 );


			SetDamage( 8, 19 );


			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 50 );


			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 30, 40 );


			SetSkill( SkillName.Poisoning, 60.1, 80.0 );
			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.1, 90.0 );
			SetSkill( SkillName.Wrestling, 65.1, 80.0 );


			Fame = 4000;
			Karma = -4000;


			VirtualArmor = 40;
			
			Item Venom = new VenomSack();
				Venom.Name = "deadly venom sack";
				AddItem( Venom );


			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 63.9;
		}


		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.MedScrolls );
		}


		public override bool ReacquireOnMovement{ get{ return !Controlled; } }


		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 2; } }


		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }


		public override int GetAttackSound()
		{
			return 713;
		}


		public override int GetAngerSound()
		{
			return 718;
		}


		public override int GetDeathSound()
		{
			return 716;
		}


		public override int GetHurtSound()
		{
			return 721;
		}


		public override int GetIdleSound()
		{
			return 725;
		}


		public Wyvern( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}


		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;


namespace Server.Factions
{
	public class Yew : Town
	{
		public Yew()
		{
			Definition =
				new TownDefinition(
					4,
					0x186D,
					"Yew",
					"Yew",
					new TextDefinition( 1011438, "YEW" ),
					new TextDefinition( 1011565, "TOWN STONE FOR YEW" ),
					new TextDefinition( 1041038, "The Faction Sigil Monolith of Yew" ),
					new TextDefinition( 1041408, "The Faction Town Sigil Monolith of Yew" ),
					new TextDefinition( 1041417, "Faction Town Stone of Yew" ),
					new TextDefinition( 1041399, "Faction Town Sigil of Yew" ),
					new TextDefinition( 1041390, "Corrupted Faction Town Sigil of Yew" ),
					new Point3D( 548, 979, 0 ),
					new Point3D( 542, 980, 0 ) );
		}
	}
}