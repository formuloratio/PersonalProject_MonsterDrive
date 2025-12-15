using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Instance", "bestScore", "hp", "maxHp", "coin", "goldCoin", "copperCoin", "carDT", "userCars", "enabled", "name")]
	public class ES3UserType_User : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_User() : base(typeof(User)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (User)obj;
			
			writer.WritePropertyByRef("Instance", User.Instance);
			writer.WriteProperty("bestScore", instance.bestScore, ES3Type_int.Instance);
			writer.WriteProperty("hp", instance.hp, ES3Type_int.Instance);
			writer.WriteProperty("maxHp", instance.maxHp, ES3Type_int.Instance);
			writer.WriteProperty("coin", instance.coin, ES3Type_int.Instance);
			writer.WriteProperty("goldCoin", instance.goldCoin, ES3Type_int.Instance);
			writer.WriteProperty("copperCoin", instance.copperCoin, ES3Type_int.Instance);
			writer.WritePropertyByRef("carDT", instance.carDT);
			writer.WriteProperty("userCars", instance.userCars, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<UserCar>)));
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (User)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Instance":
						User.Instance = reader.Read<User>();
						break;
					case "bestScore":
						instance.bestScore = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "hp":
						instance.hp = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "maxHp":
						instance.maxHp = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "coin":
						instance.coin = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "goldCoin":
						instance.goldCoin = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "copperCoin":
						instance.copperCoin = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "carDT":
						instance.carDT = reader.Read<CarData>();
						break;
					case "userCars":
						instance.userCars = reader.Read<System.Collections.Generic.List<UserCar>>();
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_UserArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_UserArray() : base(typeof(User[]), ES3UserType_User.Instance)
		{
			Instance = this;
		}
	}
}