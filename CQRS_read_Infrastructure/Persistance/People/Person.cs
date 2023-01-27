﻿using System.Collections.Specialized;
using System.Text;
using System.Text.Json.Serialization;

namespace CQRS_read_Infrastructure.Persistance.People
{
	[Flags]
	public enum PersonClass
	{
		Comum,
		Admin
	}
	public class Person
	{
		public int Id { get; set; }
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public PersonClass Class { get; set; }
		public string Nome { get; set; }
		public int Idade { get; set; }

		public Person(int id, PersonClass personClass, string nome, int idade)
		{
			if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nome);
			Id = id;
			Class = personClass;
			Nome = nome;
			Idade = idade;
		} 
		public Person(PersonClass personClass, string nome, int idade)
		{ 
			Id  = -1;
			Class = personClass;
			Nome = nome;
			Idade = idade;
		}
		public override string ToString()
		{
			return $"{Class}:[Class]{Class},[Nome]{Nome},[Idade]{Idade}";
		}

	}
}
