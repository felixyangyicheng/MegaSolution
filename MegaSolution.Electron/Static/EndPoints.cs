using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Static
{
    public class EndPoints
    {
#if DEBUG
         public static string BaseUrl = "https://localhost:44321/";
#endif

        public static string ArtistEndpoint = $"{BaseUrl}api/artists";
        public static string ContractEndpoint = $"{BaseUrl}api/contracts";
        public static string ContractTypeEndpoint = $"{BaseUrl}api/contracttypes";
        public static string DiffusionPartnerEndpoint = $"{BaseUrl}api/diffusionpartners";
        public static string OfferEndpoint = $"{BaseUrl}api/offers";
        public static string ProfessionEndpoint = $"{BaseUrl}api/professions";
        public static string ProfessionSectorEndpoint = $"{BaseUrl}api/professionsectors";
        public static string StudioEndpoint = $"{BaseUrl}api/studios";

        public static string AdminRegisterEndpoint = $"{BaseUrl}api/users/adminregister/";
        public static string RegisterEndpoint = $"{BaseUrl}api/users/register/";
        public static string LoginEndpoint = $"{BaseUrl}api/users/login/";
    }
}
