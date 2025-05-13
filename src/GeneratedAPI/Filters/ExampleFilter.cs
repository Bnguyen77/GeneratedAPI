using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Reflection;
using System.Xml.XPath;

namespace GeneratedAPI.Filters
{
	public class ExampleSchemaFilter : ISchemaFilter
	{
		private readonly XPathDocument _xmlDoc;

		public ExampleSchemaFilter(string xmlPath)
		{
			if (File.Exists(xmlPath))
				_xmlDoc = new XPathDocument(xmlPath);
		}

		public void Apply(OpenApiSchema schema, SchemaFilterContext context)
		{
			if (_xmlDoc == null || schema.Properties == null) return;

			foreach (var prop in context.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
			{
				string memberName = $"P:{context.Type.FullName}.{prop.Name}";
				var node = _xmlDoc.CreateNavigator()
					?.SelectSingleNode($"/doc/members/member[@name='{memberName}']/summary");

				if (node != null && node.InnerXml.Contains("<example>"))
				{
					string example = node.InnerXml
						.Split("<example>")[1]
						.Split("</example>")[0]
						.Trim();

					if (!string.IsNullOrEmpty(example) && schema.Properties.ContainsKey(prop.Name))
					{
						schema.Properties[prop.Name].Example = new OpenApiString(example);
					}
				}
			}
		}
	}
}
