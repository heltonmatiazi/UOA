using System;
using System.Collections;
using Server.Items;
using Server.Regions;

namespace Server.Mobiles
{
    public class BaseUndead : BaseCreature
    {
        public bool sneaking = false;
        private bool ForcedActive = false;
		
        public override bool AlwaysMurderer { get { return true; } }

			public override bool BleedImmune { get { if (this.CanInfect) {return true;} else {return false;} } }
			public override Poison PoisonImmune { get { if (this.CanInfect) { return Poison.Lethal; }  else { return null; } } }
			public override Poison HitPoison { get { if (this.CanInfect) { return Poison.Lethal; } else {return null;} } }
        public override bool CanRummageCorpses { get { return true; } }
        private RotTimer m_Timer;


        public override bool ClickTitle { get { return false; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Spirit { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool LeaveCorpse { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Nocturnal { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool SemiVisible { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool LifeDrain { get; set; }

        public BaseUndead() : base(AIType.AI_Melee, FightMode.Closest, 25, 1, 0.2, 0.4)
        { }

        public BaseUndead(AIType ai, FightMode mode, int iRangePerception, int iRangeFight, double dActiveSpeed, double dPassiveSpeed) : base(ai, mode, iRangePerception, iRangeFight, dActiveSpeed, dPassiveSpeed)
        {
            LeaveCorpse = true;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.AccessLevel >= AccessLevel.GameMaster)
            {
                if (!ForcedActive && Blessed)
                {
                    ForcedActive = true;
                    Blessed = false;
                    Hidden = false;
                    sneaking = false;
                    if (NameMod == null) NameMod = Name + " (Forced)";
                }
                else if (ForcedActive)
                {
                    ForcedActive = false;
                    NameMod = null;
                }
                else base.OnDoubleClick(from);
            }
            else base.OnDoubleClick(from);
        }

        public override void AlterMeleeDamageFrom(Mobile from, ref int damage)
        {
            if (Spirit)
            {
                damage = 0;
            }
        }

        public override void AlterMeleeDamageTo(Mobile to, ref int damage)
        {
            if (to is PlayerMobile)
            {
                if (to.AccessLevel >= AccessLevel.GameMaster)
                    damage = 0;
            }
        }

        public override void AlterSpellDamageFrom(Mobile from, ref int damage)
        {
        }

        public override void AlterSpellDamageTo(Mobile to, ref int damage)
        {
            if (to is PlayerMobile)
            {
                if (to.AccessLevel >= AccessLevel.GameMaster)
                    damage = 0;
            }
        }

        protected override bool OnMove(Direction d)
        {
            if (!sneaking)
                RevealingAction();
            return true;
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            if (HitsMaxSeed < 10)
            {
                HitsMaxSeed = 10;
            }
            if (Hits < HitsMax / 6)
            {
                CantWalk = true;
            }
            if (attacker is PlayerMobile)
            {
                switch (Utility.Random(2))
                {
                    case 0:
                        Str -= 1;
                        //this.Say(" losing 1 Str from getting hit");
                        break;
                        //case 1: this.HitsMaxSeed -= Utility.RandomMinMax(1,10); break;
                }
				if ( (((BaseCreature)this).CanInfect) && 0.15 >= Utility.RandomDouble() )
					ProjectFear();
            }
        }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (defender is BaseCreature)
            {
                switch (Utility.Random(4))
                {
                    case 0:
                        Str -= 1;
                        //this.Say(" losing 1 Str from hitting");
                        break;
                }
            }
			
			if ( this.CanInfect && 0.15 >= Utility.RandomDouble() )
				ProjectFear();

			
        }
		
		public void ProjectFear()
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

					m.PlaySound(0x204);
					m.FixedEffect(0x376A, 6, 1);

					int duration = Utility.RandomMinMax(2, 4);
					m.Paralyze(TimeSpan.FromSeconds(duration));

					m.SendMessage( "The Contageon goes Airborne and tries to take hold!" );
					if (Utility.RandomDouble() < 0.33)
					{
						m.ApplyPoison( this, Poison.Deadly );
						m.SendMessage( "and you get infected!" );
					}
					else
					{
					m.SendMessage( "and you resist the virus!" );
					}
			}
		}
		
        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (!m.Hidden && InRange(m, 8) && InLOS(m))
            {
                if (IsEnemy(m) && m.AccessLevel < AccessLevel.Counselor)
                {
                    Combatant = m;
                    Warmode = true;
                }
            }
            //	//This deals with the Zombie's calls to other zombiex's in the area
            if (((m is BaseCreature && ((BaseCreature)m).CanInfect) || m is Zombiex) && Combatant != null)
            {
                if (m.Combatant == null)
                {
                    m.Combatant = Combatant;
                    m.Say("*Moan*");  // what does the zombie getting called say
                    Say("*MMooaann*"); // what does the zombie doing the calling say
                }
            }

            return;
        }

        public override bool IsEnemy(Mobile m)
        { 
	    if (m is PlayerMobile)
            {
				if (m.AccessLevel >= AccessLevel.GameMaster)
					return false;
				else if (this.Combatant == m || m.Combatant is Zombiex || m.Combatant is DeepDweller || m.Combatant is FailedExperiment)
					return true;
				else if ( ((PlayerMobile)m).IsZen && (m.Direction & Direction.Running) == 0 )
					return false;
				else if ((m == SummonMaster) || (m == ControlMaster))
					return false;
				else
					return true;
            }
            else if (m is BaseUndead || (m is BaseCreature && (((BaseCreature)m).CanInfect) ) || m is wOphidianWarrior || m is AcidSlug || m is wOphidianMatriarch || m is wOphidianMage || m is wOphidianKnight || m is wOphidianArchmage || m is OphidianWarrior || m is OphidianMatriarch || m is OphidianMage || m is OphidianKnight || m is OphidianArchmage || m is MonsterNestEntity || m is AncientLich || m is Bogle || m is LichLord || m is Shade || m is Spectre || m is Wraith || m is BoneKnight || m is ZenMorgan || m is Ghoul || m is Mummy || m is SkeletalKnight || m is Skeleton || m is Zombie || m is RevenantLion || m is RottingCorpse || m is SkeletalDragon || m is AirElemental || m is IceElemental || m is ToxicElemental || m is PoisonElemental || m is FireElemental || m is WaterElemental || m is EarthElemental || m is Efreet || m is SnowElemental || m is AgapiteElemental || m is BronzeElemental || m is CopperElemental || m is DullCopperElemental || m is GoldenElemental || m is ShadowIronElemental || m is ValoriteElemental || m is VeriteElemental || m is BloodElemental)
                return false;
			else if (m is BaseCreature && ( (((BaseCreature)m).ControlMaster) is PlayerMobile && !IsEnemy(((BaseCreature)m).ControlMaster)) ) 
				return false;
            return true;
        }

        public virtual void CheckNocturnal()
        {
            _LastActiveCheck = DateTime.UtcNow;

            int hours, minutes;
            if (!(Region is DungeonRegion))
            {
                Clock.GetTime(Map, X, Y, out hours, out minutes);

                // 00:00 AM - 00:59 AM : Witching hour
                // 01:00 AM - 03:59 AM : Middle of night
                // 04:00 AM - 07:59 AM : Early morning
                // 08:00 AM - 11:59 AM : Late morning
                // 12:00 PM - 12:59 PM : Noon
                // 01:00 PM - 03:59 PM : Afternoon
                // 04:00 PM - 07:59 PM : Early evening
                // 08:00 PM - 11:59 AM : Late at night

                if ((hours >= 18) || (hours <= 06))
                {
                    Blessed = false;
                    Hidden = false;
                    sneaking = false;
                    NameMod = null;
                }
                else if ((hours < 18) && (hours > 06) && (Combatant == null))
                {
                    Blessed = true;
                    Hidden = true;
                    sneaking = true;
                    if (NameMod == null) NameMod = Name + " (Resting)";
                }
            }
        }

        private DateTime _LastActiveCheck = DateTime.UtcNow;
        private TimeSpan _ActiveCheckDelay = TimeSpan.FromSeconds(5.0);

        public bool CanCheckActive()
        {
            if (_LastActiveCheck.Add(_ActiveCheckDelay) < DateTime.UtcNow)
                return true;
            return false;
        }

        public override void OnThink()
        {
            if ((ControlMaster == null) && (SummonMaster == null))
            {
                if (Nocturnal && !ForcedActive && CanCheckActive()) CheckNocturnal();

                if (SemiVisible && !ForcedActive)
                {
                    if (Combatant != null)
                    {
                        Hidden = false;
                        sneaking = false;
                        NameMod = null;
                    }
                    else
                    {
                        Hidden = true;
                        sneaking = true;
                        if (NameMod == null) NameMod = Name + " (Waiting)";
                    }
                }

                if ((LifeDrain == true) && (Combatant != null) && (0.1 >= Utility.RandomDouble())) DrainLife();
            }
            else  // how a summoned undead should act
            {
                Blessed = false;
                Hidden = false;
                sneaking = false;
                Spirit = false;
                Nocturnal = false;
                SemiVisible = false;
                LifeDrain = false;
                LeaveCorpse = true;
            }

            base.OnThink();
        }

        private class RotTimer : Timer
        {
            private Mobile m_Mobile;

            //Change timespan to change the rate of decay

            public RotTimer(Mobile m) : base(TimeSpan.FromMinutes(5.0))
            {
                m_Mobile = m;
            }

            protected override void OnTick()
            {
                RotTimer rotTimer = new RotTimer(m_Mobile);
                if (m_Mobile.Str < 2)
                {
                    m_Mobile.Kill();
                    Stop();
                }
                else
                {
                    if (m_Mobile.Hits > m_Mobile.HitsMax / 2)
                    {
                        m_Mobile.Hits -= m_Mobile.HitsMax / 100;
                        //m_Mobile.Say(" losing 1% Hits");
                    }

                    if (m_Mobile.Hits <= m_Mobile.HitsMax / 2)
                    {
                        m_Mobile.Hits -= 1;
                        //m_Mobile.Say(" losing 1 Hitpoint");
                    }

                    if (m_Mobile.Hits < m_Mobile.HitsMax / 4)
                    {
                        m_Mobile.CantWalk = true;
                        //m_Mobile.Say(" Cant Walk Anymore");
                    }

                    if (m_Mobile.Str > 100)
                    {
                        m_Mobile.Str -= m_Mobile.Str / 30;
                        //m_Mobile.Say(" losing 3.33% Str");
                    }

                    if (m_Mobile.Str <= 100)
                    {
                        m_Mobile.Str -= 1;
                        //m_Mobile.Say(" losing 1 Str point");
                    }
                    rotTimer.Start();
                }
            }
        }

        public void DrainLife()
        {
            ArrayList list = new ArrayList();

            foreach (Mobile m in GetMobilesInRange(2))
            {
                if (m == this || !CanBeHarmful(m))
                    continue;

                if (m.Player || m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != Team))
                    list.Add(m);
            }

            foreach (Mobile m in list)
            {
                DoHarmful(m);

                m.FixedParticles(0x374A, 10, 15, 5013, 0x496, 0, EffectLayer.Waist);
                m.PlaySound(0x231);

                m.SendMessage("You feel the life drain out of you!");

                int toDrain = Utility.RandomMinMax(4, 11);

                Hits += toDrain;
                m.Damage(toDrain, this);
            }
            list.Clear();
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);
            if (!LeaveCorpse)
                c.Delete();
        }

        public BaseUndead(Serial serial) : base(serial)
        { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1); // version
            writer.Write(Spirit);
            writer.Write(LeaveCorpse);
            writer.Write(Nocturnal);
            writer.Write(SemiVisible);
            writer.Write(LifeDrain);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            switch (version)
            {
                case 1:
                {
                    Spirit = reader.ReadBool();
                    LeaveCorpse = reader.ReadBool();
                    Nocturnal = reader.ReadBool();
                    SemiVisible = reader.ReadBool();
                    LifeDrain = reader.ReadBool();
                    goto case 0;
                }
                case 0:
                    break;
            }
        }
    }
}
