using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;

namespace Server.Items
{
	[Furniture]
	public class TombStone : Item
	{
		private string TombName = "";
		
		[Constructable]
		public TombStone( Mobile from, Mobile Killed ) : base( 0x116E )
		{
			
			if ( !(from is PlayerMobile))
				return;
			
			Weight = 75.0;
			Hue = 0x763;
			Movable = true;
			//Passable = false;
			ItemID = Utility.RandomList( 0xED4, 0xED5, 0xED6, 0xED7, 0xED8, 0xEDD, 0xEDE, 0x1165, 0x1166, 0x1167, 0x1168, 0x1169, 0x116A, 0x116B, 0x116C, 0x116D, 0x116E, 0x116F, 0x1170, 0x1171, 0x1172, 0x1173, 0x1174, 0x1175, 0x1176, 0x1177, 0x1178, 0x1179, 0x117A, 0x117B, 0x117C, 0x117D, 0x117E, 0x117F, 0x1180, 0x1181, 0x1182, 0x1183, 0x1184 );
			
			if (Killed == null)
				Killed = from;
			
			string Cause = "";
			string title = "";
			string killertitle = "";
			
            switch ( Utility.Random( 79 ) )
            {
                case 0: Cause = "Mangled"; break;
                case 1: Cause = "Delapitated"; break;
                case 2: Cause = "Liquified"; break;
                case 3: Cause = "Blown Up"; break;
                case 4: Cause = "Scared to Death"; break;
                case 5: Cause = "Trampled"; break;
                case 6: Cause = "Exfoliated"; break;
                case 7: Cause = "Immolated"; break;
                case 8: Cause = "Slaughtered"; break;
                case 9: Cause = "Executed"; break;
                case 10: Cause = "Wasted"; break;
                case 11: Cause = "Crucified"; break;
                case 12: Cause = "Dismembered"; break;
                case 13: Cause = "Cut in Half"; break;   
                case 14: Cause = "Processed"; break;
                case 15: Cause = "Eradicated"; break;
                case 16: Cause = "Slightly Used"; break;
                case 17: Cause = "Expelled"; break;
                case 18: Cause = "Taught a Valuable Life Lesson"; break; 
                case 19: Cause = "Humiliated"; break;
                case 20: Cause = "Tea-Bagged"; break;
                case 21: Cause = "Pierced"; break;   
                case 22: Cause = "Eviscerated"; break;
                case 23: Cause = "Kneed to the Head"; break;
                case 24: Cause = "Dismantled"; break;
                case 25: Cause = "Squashed"; break;
				case 26: Cause = "blames lag for his death"; break;
				case 27: Cause = "had his ears twisted"; break;
				case 28: Cause = "was given a poison apple"; break;
				case 29: Cause = "was talked to"; break;
				case 30: Cause = "nose-picked"; break;
				case 31: Cause = "corrected"; break;
				case 32: Cause = "smelted"; break;
				case 33: Cause = "tainted"; break;
				case 34: Cause = "put in his or her place"; break;
				case 35: Cause = "thrown"; break;
				case 36: Cause = "hit out of the park"; break;
				case 37: Cause = "jokered"; break;
				case 38: Cause = "died laughing from a joke told"; break;
				case 39: Cause = "opened a present given"; break;
				case 40: Cause = "fired up"; break;
				case 41: Cause = "bullied"; break;
				case 42: Cause = "softened up"; break;
				case 43: Cause = "taught to be cautious"; break;
				case 44: Cause = "eviscerated"; break;
				case 45: Cause = "punched"; break;
				case 46: Cause = "prodded"; break;
				case 47: Cause = "given an enema"; break;
				case 48: Cause = "encroached on"; break;
				case 49: Cause = "discovered"; break;
				case 50: Cause = "interupted"; break;
				case 51: Cause = "folded in two"; break;
				case 52: Cause = "called a bad name"; break;
				case 53: Cause = "frozen and shattered"; break;
				case 54: Cause = "ripened"; break;
				case 55: Cause = "laughed at"; break;
				case 56: Cause = "folded like an origami"; break;
				case 57: Cause = "folded in two"; break;
				case 58: Cause = "pissed on"; break;
				case 59: Cause = "sex changed"; break;
				case 60: Cause = "munched"; break;
				case 61: Cause = "farted on"; break;
				case 62: Cause = "given herpes"; break;
				case 63: Cause = "boxed"; break;
				case 64: Cause = "beamed"; break;
				case 65: Cause = "fireballed"; break;
				case 66: Cause = "skunked"; break;
				case 67: Cause = "slam dunked"; break;
				case 68: Cause = "grabbed by the pussy"; break;
				case 69: Cause = "molested"; break;
				case 70: Cause = "PwNd"; break;
				case 71: Cause = "fish-slapped"; break;
				case 72: Cause = "karate-chopped"; break;
				case 73: Cause = "windmilled"; break;
				case 74: Cause = "roundhoused"; break;
				case 75: Cause = "caught cheating on his wife"; break;
				case 76: Cause = "caught cheating in poker"; break;
				case 77: Cause = "cucked"; break;
				case 78: Cause = "not ready to be punched"; break;
				case 79: Cause = "abandoned as a child"; break;
				
            }
			
			if (from.Title == null || from.Title == "")
				title = GetPlayerInfo.GetSkillTitle( from );
			else
				title = from.Title;
			
			if (Killed.Title == null || Killed.Title == "")
				killertitle = "";
			else
				killertitle = Killed.Title	;		
			
			
			if (Killed == from)
				TombName = "Here Lies " + from.Name + " the " + title + " who was " + Cause + " by His Own Hands.";
			else
				TombName = "Here Lies " + from.Name + " the " + title + " who was " + Cause + " by " + Killed.Name + " " +killertitle;
			Name = TombName;
		}

		public TombStone(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
			writer.Write( (string)TombName );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			
			TombName = reader.ReadString();
			
			Name = TombName;
		}
	}
}