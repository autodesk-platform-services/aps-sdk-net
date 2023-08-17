using Autodesk.ModelDerivative.Http;
using Autodesk.ModelDerivative.Model;



namespace Autodesk.ModelDerivative
{

internal static class Utils
{

   internal static string GetPathfromRegion(Region region)
   {
    switch(region)
    {
        case Region.US:
         return "/modelderivative/v2/designdata/";
        
        case Region.EMEA:
           return "/modelderivative/v2/regions/eu/designdata/";
        
        default:
        return "/modelderivative/v2/designdata/";

    }
   } 

}

}