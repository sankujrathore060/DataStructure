using System;
public class GBusCount{

	public static int[] GetInterestedCityCountVisitingGBusCount(string[] gBuesRoutes, int[] interestesCities){
		int[] citiesCount = new int[interestesCities.Length];
		for(int city =0; city < interestesCities.Length; city++){
			citiesCount[city] = 0;
		}
			
		for(int routes = 0; routes < gBuesRoutes.Length; routes+=2){
			int startStation = Convert.ToInt32(gBuesRoutes[routes]);
			int endStation = Convert.ToInt32(gBuesRoutes[routes + 1]);
			for(int city = 0; city < interestesCities.Length; city++){
				if(startStation  <= interestesCities[city] && interestesCities[city] <= endStation){
					citiesCount[city]++;
				}
			}
		}
		return citiesCount;
	}

	public static void Main(string[] args){
		int testCases = Convert.ToInt32(Console.ReadLine());
		for(int testCase = 0; testCase < testCases; testCase++){
			int totalGBuses = Convert.ToInt32(Console.ReadLine());
			
			string gBuesRouteInfo = Console.ReadLine();
			string[] gBuesRoutes = gBuesRouteInfo.Split(new char[]{' '});
			
			int noOfCitiesInterested = Convert.ToInt32(Console.ReadLine());
			
			int[] interestesCities = new int[noOfCitiesInterested];
			for(int city = 0; city < noOfCitiesInterested; city++){
				interestesCities[city] = Convert.ToInt32(Console.ReadLine());
			}
			int[] citiesCount = GetInterestedCityCountVisitingGBusCount(gBuesRoutes , interestesCities);
			string citiesInterested = string.Empty;
			
			for(int city =0; city < citiesCount.Length; city++){
				citiesInterested += (" " + citiesCount[city]);
			}
			Console.WriteLine("Case #{0}: {1}", testCase + 1,citiesInterested.Trim());
		}
	}
}