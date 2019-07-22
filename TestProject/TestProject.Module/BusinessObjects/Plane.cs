using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;
using DisplayNameAttribute = DevExpress.Xpo.DisplayNameAttribute;
using MyLab;

namespace TestProject.Module.BusinessObjects
{
	[DefaultClassOptions]
	public class Plane : XPObject
	{
		public Plane(Session session)
			: base(session)
		{
		}
		public override void AfterConstruction()
		{
			base.AfterConstruction();

		}
		private string nameOfPlane;
		private Airport airport;

		[RuleRequiredField]
		[RuleUniqueValue]
		[Size(199)]
		[DisplayName("Имя самолета")]
		[Appearance("Green Planes", Criteria = "Contains([NameOfPlane], 'a')||Contains([NameOfPlane], 'A')", FontColor = "Green", TargetItems = "NameOfPlane", Context = "ListView")]
		public string NameOfPlane
		{
			get { return nameOfPlane; }
			set { SetPropertyValue("NameOfPlane", ref nameOfPlane, value); }
		}

		[DisplayName("Количество пилотов")]
		public int CountOfPilots
		{
			get
			{
				return Pilots.Count;
			}
		}

		[DisplayName("Аэропорт")]
		[Association]
		public Airport Airport
		{
			get { return airport; }
			set { SetPropertyValue("Airport", ref airport, value); }
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

		protected override void OnSaving()
		{
			if (Class1.CheckPlanesPilotsAccordance(this, Pilots))
			{
				base.OnSaving();
			}
			else throw new Exception("Ошибка");
		}
	}
}