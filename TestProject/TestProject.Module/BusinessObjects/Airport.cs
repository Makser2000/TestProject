using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DisplayNameAttribute = DevExpress.Xpo.DisplayNameAttribute;
using MyLab;

namespace TestProject.Module.BusinessObjects
{

	[DefaultClassOptions]
	public class Airport : XPObject
	{
		public Airport(Session session)
			: base(session)
		{
		}
		public override void AfterConstruction()
		{
			base.AfterConstruction();
		}
		private string nameOfAirport;

		[DisplayName("Название аэропорта")]
		[RuleRequiredField]
		[RuleUniqueValue]
		public string NameOfAirport
		{
			get { return nameOfAirport; }
			set { SetPropertyValue("NameOfAirport", ref nameOfAirport, value); }
		}

		[DisplayName("Количество самолетов")]
		public int CountOfPlanes
		{
			get
			{
				return Planes.Count;
			}
		}

		[DisplayName("Количество пилотов")]
		public int CountOfPilots
		{
			get
			{
				return Pilots.Count;
			}
		}


		[DisplayName("Пилоты")]
		[Association]
		public XPCollection<Pilot> Pilots
		{
			get
			{
				return GetCollection<Pilot>("Pilots");
			}
		}

		[DisplayName("Самолеты")]
		[Association]
		public XPCollection<Plane> Planes
		{
			get
			{
				return GetCollection<Plane>("Planes");
			}
		}

		protected override void OnSaving()
		{
			if (Class1.CheckAirportAccordance(this,Planes)&&(Class1.CheckAirportAccordance(this, Pilots)))
			{
				base.OnSaving();
			}
			else throw new Exception("Ошибка");
		}
	}
}