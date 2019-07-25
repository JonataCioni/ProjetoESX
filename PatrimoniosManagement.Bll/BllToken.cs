using PatrimoniosManagement.Bll.Utils;
using PatrimoniosManagement.Bll.Utils.Enums;
using PatrimoniosManagement.Dal;
using System;
using System.Configuration;
using System.Linq;
using System.Text;

namespace PatrimoniosManagement.Bll
{
	public class BllToken
	{
		private DalUsuario dalUsuario;

		public BllToken()
		{
			this.dalUsuario = new DalUsuario();
		}

		public TokenResult Login(String Email, String Senha)
		{
			try
			{
				TokenResult loginResult = new TokenResult();
				if (!this.dalUsuario.Login(Email, Senha))
				{
					loginResult.MessageType = MessageType.NotPermition;
					loginResult.MessageString = Utils.Utils.GetDescriptionEnum(MessageType.NotPermition);
				}
				else
				{
					loginResult.MessageType = MessageType.Ok;
					loginResult.MessageString = Utils.Utils.GetDescriptionEnum(MessageType.Ok);
					Int32 tempoValidadeToken = Int32.Parse(ConfigurationSettings.AppSettings["TempoValidadeTokenMinutos"]);
					String token = Email + "|" + Senha + "|" + DateTime.Now.AddMinutes(tempoValidadeToken).ToString("yyyy-MM-dd HH:mm:ss");
					Byte[] ba = Encoding.ASCII.GetBytes(token);
					loginResult.Token = BitConverter.ToString(ba).Replace("-", "");
				}
				return loginResult;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public TokenResult ValidToken(String token)
		{
			TokenResult tokenResult = new TokenResult();
			Byte[] ba = StringToByteArray(token);
			String[] dados = Encoding.ASCII.GetString(ba).Split('|');
			DateTime dt = DateTime.Parse(dados[2]);
			if(this.dalUsuario.Login(dados[0], dados[1]) && dt >= DateTime.Now)
			{
				tokenResult.MessageType = MessageType.Ok;
				tokenResult.MessageString = Utils.Utils.GetDescriptionEnum(MessageType.Ok);
			}
			else if(this.dalUsuario.Login(dados[0], dados[1]) && dt < DateTime.Now)
			{
				tokenResult.MessageType = MessageType.TimeExpired;
				tokenResult.MessageString = Utils.Utils.GetDescriptionEnum(MessageType.TimeExpired);
			}
			if (!this.dalUsuario.Login(dados[0], dados[1]))
			{
				tokenResult.MessageType = MessageType.NotPermition;
				tokenResult.MessageString = Utils.Utils.GetDescriptionEnum(MessageType.NotPermition);
			}
			return tokenResult;
		}

		public static Byte[] StringToByteArray(string hex)
		{
			return Enumerable.Range(0, hex.Length)
							 .Where(x => x % 2 == 0)
							 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
							 .ToArray();
		}
	}
}
