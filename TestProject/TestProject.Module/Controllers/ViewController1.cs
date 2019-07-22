using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using TestProject.Module.BusinessObjects;

namespace TestProject.Module.Controllers
{
	// For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
	public partial class ViewController1 : ViewController
	{
		public ViewController1()
		{
			InitializeComponent();
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
		}
		protected override void OnViewControlsCreated()
		{
			base.OnViewControlsCreated();
			// Access and customize the target View control.
		}
		protected override void OnDeactivated()
		{
			// Unsubscribe from previously subscribed events and release other references and resources.
			base.OnDeactivated();
		}

		private void simpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			string connectionString = MSSqlConnectionProvider.GetConnectionString("(local)", "TestProject");
			XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);
			Session session = new Session();
			for (int i = 1; i < 101; i++)
			{
				Airport a = new Airport(session);
				a.NameOfAirport = "Аэропорт" + i.ToString();
				Pilot b = new Pilot(session);
				b.FullName = "Пилот" +i.ToString();
				Pilot c = new Pilot(session);
				c.FullName = "Pilot" + i.ToString();
				Plane d = new Plane(session);
				d.NameOfPlane = "Самолет" + i.ToString();
				b.Planes.Add(d);
				c.Planes.Add(d);
				b.Airport = a;
				c.Airport = a;
				d.Airport = a;
				a.Save();
				b.Save();
				c.Save();
				d.Save();
			}
		}
	}
}
