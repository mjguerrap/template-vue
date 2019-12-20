using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Util
{
    public static class Extension
{
	/// <summary>
	/// Conversão de Arquivo diversos binarios
	/// </summary>
	/// <param name="files">HttpPostedFileBase[]</param>
	/// <returns>byte[]</returns>
	public static byte[] ToBytes(this HttpPostedFileBase[] files)
	{
		byte[] arraybytes = null;

		foreach (HttpPostedFileBase file in files)
		{
			long numeroBytes = file.InputStream.Length;
			using (BinaryReader br = new BinaryReader(file.InputStream))
			{
				arraybytes = br.ReadBytes((int)numeroBytes);
			}
		}

		return arraybytes;
	}

	/// <summary>
	/// Conversão de Arquivo diversos
	/// </summary>
	/// <param name="file">HttpPostedFileBase</param>
	/// <returns>byte[]</returns>
	public static byte[] ToBytes(this HttpPostedFileBase file)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			file.InputStream.CopyTo(memoryStream);
			return memoryStream.ToArray();
		}
	}

	/// <summary>
	/// Converte Texto em inteiro 
	/// Caso a convesão não seja valida retorna int.MinValue (-2.147.483.648)
	/// </summary>
	/// <param name="texto">string</param>
	/// <returns>int</returns>
	public static int ToInt(this string texto)
	{
		int aux;
		if (!int.TryParse(texto, out aux))
		{
			aux = int.MinValue;
		}
		return aux;
	}

	/// <summary>
	/// Converte Enum em inteiro 
	/// Caso não seja valida a conversao retorna -1
	/// </summary>
	/// <param name="value">System.Enum</param>
	/// <returns>int</returns>
	public static int ToInt(this System.Enum value)
	{
		int aux;
		if (value == null)
		{
			aux = -1;
		}
		else
		{
			var valor = Convert.ChangeType(value, value.GetTypeCode());
			if (valor == null || !int.TryParse(valor.ToString(), out aux))
			{
				aux = -1;
			}
		}
		return aux;
	}

	/// <summary>
	/// Converte texto em long
	/// Caso não seja valida a conversao retorna long.MinValue (-9.223.372.036.854.775.808)
	/// </summary>
	/// <param name="texto"></param>
	/// <returns></returns>
	public static long ToLong(this string texto)
	{
		long aux;
		if (!long.TryParse(texto, out aux))
		{
			aux = long.MinValue;
		}
		return aux;
	}

	/// <summary>
	/// Comparacao entre objetos verificando os valores de cada propriedade
	/// </summary>
	/// <typeparam name="T">Objeto</typeparam>
	/// <param name="objeto1">Objeto1</param>
	/// <param name="objeto2">Objeto2</param>
	/// <returns></returns>
	public static bool ToCompararObjetos<T>(this T objeto1, T objeto2) where T : class
	{
		Type type = typeof(T);

		PropertyInfo[] campos = type.GetProperties();

		for (int i = 0; i < campos.Length; i++)
		{
			object valorPropriedade1 = type.GetProperty(campos[i].Name).GetValue(objeto1, null);
			object valorPropriedade2 = type.GetProperty(campos[i].Name).GetValue(objeto2, null);
			if (valorPropriedade1 != valorPropriedade2 && (valorPropriedade1 == null || !valorPropriedade1.Equals(valorPropriedade2)))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// Converter Arry de Bytes em imagem
	/// Caso seja gerado algum "ArgumentException" o retorno será null.
	/// </summary>
	/// <param name="bytes">byte[] </param>
	/// <returns>Image</returns>
	public static Image ToByteArrayToImage(this byte[] bytes)
	{
		if (bytes == null)
		{
			return null;
		}
		using (MemoryStream ms = new MemoryStream(bytes))
		{
			return Image.FromStream(ms);
		}
	}

	/// <summary>
	/// Verificar se o paramentro está entre o intervalo informado
	/// </summary>
	/// <param name="value">int </param>
	/// <param name="inicio">int </param>
	/// <param name="fim">int</param>
	/// <returns>bool</returns>
	public static bool IsBetween(this int value, int inicio, int fim)
	{
		return value >= inicio && value <= fim;
	}

	/// <summary>
	/// Criptograva valor numerico para ser passado como parametro na URL
	/// </summary>
	/// <param name="id">int</param>
	/// <returns>int Criptografado</returns>
	public static int ToIdCrypt(this int id)
	{
		if (id.Equals(0))
		{
			return 0;
		}
		return Criptografia.CriptografarIdsParaUrl(id);
	}

	/// <summary>
	/// Criptograva valor numerico para ser passado como parametro na URL
	/// </summary>
	/// <param name="idCrypt">int Criptografado</param>
	/// <returns>int</returns>
	public static int ToIdDecrypt(this int idCrypt)
	{
		if (idCrypt == 0)
		{
			return 0;
		}
		return Criptografia.DescriptografarIdsParaUrl(idCrypt);
	}

	/// <summary>
	/// Criptograva valor numerico para ser passado como parametro na URL
	/// </summary>
	/// <param name="id">long</param>
	/// <returns>long Criptografado</returns>
	public static long ToIdCrypt(this long id)
	{
		if (id.Equals(0))
		{
			return 0;
		}
		return Criptografia.CriptografarIdsParaUrl(id);
	}

	/// <summary>
	/// Criptograva valor numerico para ser passado como parametro na URL
	/// </summary>
	/// <param name="idCrypt">long Criptografado</param>
	/// <returns>long</returns>
	public static long ToIdDecrypt(this long idCrypt)
	{
		if (idCrypt == 0)
		{
			return 0;
		}
		return Criptografia.DescriptografarIdsParaUrl(idCrypt);
	}

	/// <summary>
	/// Converte string em byte
	/// Caso não seja válido a conversão retorna o byte.MinValue (0)
	/// </summary>
	/// <param name="texto">string</param>
	/// <returns>byte</returns>
	public static byte ToByte(this string texto)
	{
		byte aux;
		if (!byte.TryParse(texto, out aux))
		{
			aux = byte.MinValue;
		}

		return aux;
	}

	/// <summary>
	/// Converte int em byte
	/// Caso não seja válido a conversão retorna o byte.MinValue (0)
	/// </summary>
	/// <param name="valor">int</param>
	/// <returns>byte</returns>
	public static byte ToByte(this int valor)
	{
		byte aux;
		if (!byte.TryParse(valor.ToString(), out aux))
		{
			aux = byte.MinValue;
		}

		return aux;
	}

	/// <summary>
	/// Converte Enum em Byte
	/// Caso não seja valida a conversao retorna 0
	/// </summary>
	/// <param name="value">System.Enum</param>
	/// <returns>int</returns>
	public static byte ToByte(this System.Enum value)
	{
		byte aux;
		if (value == null)
		{
			aux = 0;
		}
		else
		{
			var valor = Convert.ChangeType(value, value.GetTypeCode());
			if (valor == null || !byte.TryParse(valor.ToString(), out aux))
			{
				aux = 0;
			}
		}
		return aux;
	}

	/// <summary>
	/// Convert string de data em DateTime
	/// Caso seja uma data invalida será retornado DateTime.MinValue (0001-01-01 00:00:00:0000000) 
	/// </summary>
	/// <param name="datetime">string</param>
	/// <returns>DateTime</returns>
	public static DateTime ToDateTime(this string datetime)
	{
		DateTime datatmp;
		if (DateTime.TryParse(datetime, out datatmp))
		{
			return datatmp;
		}

		return DateTime.MinValue;

	}

	/// <summary>
	/// Convert DateTime em String formatada "dd/MM/yyyy"
	/// </summary>
	/// <param name="datetime"></param>
	/// <returns>string</returns>
	public static string ToDate(this DateTime datetime)
	{
		return datetime.ToString("dd/MM/yyyy");
	}

	/// <summary>
	/// Convert DateTime em String formatada "dd/MM/yyyy HH:mm"
	/// </summary>
	/// <param name="datetime"></param>
	/// <returns>string</returns>
	public static string ToDateTime(this DateTime datetime)
	{
		return datetime.ToString("dd/MM/yyyy HH:mm");
	}

	/// <summary>
	/// Convert a data fim para pesquisar no banco de dados datetime.AddDays(1).AddMilliseconds(-1)
	/// </summary>
	/// <param name="datetime"></param>
	/// <returns>DateTime</returns>
	public static DateTime ToDateTimeDataFim(this DateTime datetime)
	{
		return datetime.AddDays(1).AddMilliseconds(-1);
	}

	/// <summary>
	/// Convert a data fim para pesquisar no banco de dados datetime.AddDays(1).AddMilliseconds(-1)
	/// </summary>
	/// <param name="datetime"></param>
	/// <returns>DateTime</returns>
	public static DateTime ToDateTimeDataFim(this DateTime? datetime)
	{
		return ((DateTime)datetime).AddDays(1).AddMilliseconds(-1);
	}

	/// <summary>
	/// Retornar a Descrição do Enum para exibir em tela
	/// Caso não tenha descrição retorna o nome do enum utilizado
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="value"></param>
	/// <returns></returns>
	public static string GetEnumDisplayName<T>(this T value) where T : struct
	{

		if (string.IsNullOrEmpty(value.ToString()))
		{
			return null;
		}

		FieldInfo field = value.GetType().GetField(value.ToString());
		DescriptionAttribute[] attributes = (DescriptionAttribute[])field
			.GetCustomAttributes(typeof(DescriptionAttribute), false);
		if (attributes.Length > 0)
		{
			return attributes[0].Description;
		}
		return value.ToString();

	}

	/// <summary>
	/// Retorna a Description da class enum, quando não tem retorna o nome do Enum
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="value"></param>
	/// <returns></returns>
	public static string GetEnumDescription<T>(this T value)
	{
		AttributeCollection attributes = TypeDescriptor.GetAttributes(value);

		DescriptionAttribute myAttribute =
		  (DescriptionAttribute)attributes[typeof(DescriptionAttribute)];

		if (Equals(myAttribute.Description, ""))
		{
			return value.GetType().Name;
		}
		return myAttribute.Description;
	}

	/// <summary>
	/// Método para converter uma lista em um DataSet
	/// Efetuar a chamada deste metodo sempre dentro de um Using()
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <returns></returns>
	public static DataSet ToDataSet<T>(this IList<T> list)
	{
		Type elementType = typeof(T);

		using (DataTable t = new DataTable())
		{
			//add a column to table for each public property on T
			foreach (var propInfo in elementType.GetProperties())
			{
				t.Columns.Add(propInfo.Name, propInfo.PropertyType);
			}

			//go through each property on T and add each value to the table
			foreach (T item in list)
			{
				DataRow row = t.NewRow();
				foreach (var propInfo in elementType.GetProperties())
				{
					row[propInfo.Name] = propInfo.GetValue(item, null);
				}

				//This line was missing:
				t.Rows.Add(row);
			}
			DataSet ds = new DataSet();
			ds.Tables.Add(t);
			return ds;

		}
	}

	/// <summary>
	/// Método para converter uma lista em um DataTable
	/// Efetuar a chamada deste metodo sempre dentro de um Using()
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	/// <returns></returns>
	public static DataTable ToDataTable<T>(this IList<T> list)
	{
		Type elementType = typeof(T);
		//DataSet ds = new DataSet();
		DataTable t = new DataTable();

		//add a column to table for each public property on T
		foreach (var propInfo in elementType.GetProperties())
		{
			t.Columns.Add(propInfo.Name, Nullable.GetUnderlyingType(propInfo.PropertyType) ??
	propInfo.PropertyType);

		}
		//go through each property on T and add each value to the table
		foreach (T item in list)
		{
			DataRow row = t.NewRow();
			foreach (var propInfo in elementType.GetProperties())
			{
				row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
			}

			//This line was missing:
			t.Rows.Add(row);
		}
		return t;
	}

	/// <summary>
	/// Método para formatar o CPF com a mascara
	/// </summary>
	/// <param name="cpf"></param>
	/// <returns></returns>
	public static string GetCpf(this string cpf)
	{
		return cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
	}

	/// <summary>
	/// Método pra remover a mascara do CPF
	/// </summary>
	/// <param name="cpf"></param>
	/// <returns></returns>
	public static string SetCpf(this string cpf)
	{
		return cpf.Replace(".", "").Replace("-", "");
	}

	/// <summary>
	/// Método para formatar o CEP com a mascara
	/// </summary>
	/// <param name="cep"></param>
	/// <returns></returns>
	public static string GetCep(this string cep)
	{
		return cep.Insert(5, "-");
	}

	/// <summary>
	/// Método para incluir o traço no telefone
	/// </summary>
	/// <param name="tel"></param>
	/// <returns></returns>
	public static string GetTel(this int tel)
	{
		return string.Format("{0:#####-####}", tel.ToString());
	}

	/// <summary>
	/// Método para incluir o traço no telefone
	/// </summary>
	/// <param name="tel"></param>
	/// <returns></returns>
	public static string GetTel(this string tel)
	{
		return string.Format("{0:#####-####}", tel);
	}

}
}
