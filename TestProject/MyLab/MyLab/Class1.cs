using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLab
{
    public class Class1
    {
		public static bool CheckPlanesPilotsAccordance(dynamic Pilot,dynamic Planes)
		{
			bool res = true;
			foreach (dynamic Plane in Planes)
			{
				if (Pilot.Airport != Plane.Airport)
				{
					res = false;
					break;
				}
			}
			return res;
		}

		public static bool CheckAirportAccordance(dynamic a,dynamic x)
		{
			bool res = true;
			foreach(dynamic y in x)
			{
				if (a != y.Airport)
				{
					res = false;
					break;
				}
			}
			return res;
		}
	}

}
