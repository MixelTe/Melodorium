using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melodorium
{
	internal class JsonTolerantEnumConverter : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert.IsEnum;
		}

		public override JsonConverter CreateConverter(
			Type type,
			JsonSerializerOptions options)
		{
			JsonConverter converter = (JsonConverter)Activator.CreateInstance(
				typeof(JsonTolerantEnumConverterInner<>).MakeGenericType([type]),
				BindingFlags.Instance | BindingFlags.Public,
				binder: null,
				args: [options],
				culture: null)!;

			return converter;
		}

		private class JsonTolerantEnumConverterInner<T>(JsonSerializerOptions options) :
			JsonConverter<T> where T : struct, Enum
		{
			public override T Read(
				ref Utf8JsonReader reader,
				Type typeToConvert,
				JsonSerializerOptions options)
			{
				if (reader.TokenType != JsonTokenType.String)
					throw new JsonException();

				string? propertyName = reader.GetString();

				// For performance, parse with ignoreCase:false first.
				if (!Enum.TryParse(propertyName, ignoreCase: false, out T value) &&
					!Enum.TryParse(propertyName, ignoreCase: true, out value))
				{
					//throw new JsonException(
					//	$"Unable to convert \"{propertyName}\" to Enum \"{_type}\".");
					return new T();
				}
				return value;
			}

			public override void Write(
				Utf8JsonWriter writer,
				T value,
				JsonSerializerOptions options)
			{
				var propertyName = value.ToString();
				writer.WriteStringValue
					(options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);
			}
		}
	}
}
