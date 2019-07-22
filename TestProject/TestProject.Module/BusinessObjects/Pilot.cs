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
	public class Pilot : XPObject
	{
		public Pilot(Session session) : base(session) {}
		private Airport airport;
		private string fullName;

		[RuleRequiredField]
		[DisplayName("ФИО")]
		public string FullName
		{
			get { return fullName; }
			set { SetPropertyValue("FullName", ref fullName, value); }
		}

		[DisplayName("Количество самолетов")]
		public int CountOfPlanes
		{
			get
			{
				return Planes.Count;
			}
		}

		[DisplayName("Аэропорт")]
		[Association]
		public Airport Airport
		{
			get { return airport; }
			set { SetPropertyValue("Airport", ref airport, value); }
		}

		[DisplayName("Самолеты")]
		[Association]
		public XPCollection<Plane> Planes
		{
			get { return GetCollection<Plane>("Planes"); }
		}

		protected override void OnSaving()
		{
			if (Class1.CheckPlanesPilotsAccordance(this,Planes))
			{
				base.OnSaving(); 
			}
			else throw new Exception("Ошибка");
		}
	}
}