using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Kvitteringer.Forretning;
using Difi.SikkerDigitalPost.Klient.XmlValidering;

namespace difi_sdp_klient_smoke
{
    internal class Program
    {
        /// <summary>
        /// Dette programmet er bare en virkelighetssjekk for å se at klientbiblioteket fungerer uten seriøse kompileringsfeil og at det ikke kommer noen store blundere av noen runtimefeil. Denne testen er dratt rett ut av sikker-digital-post-klient-dotnet smoke-tester
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var miljø = Miljø.FunksjoneltTestmiljø;
            
            new SmokeTestsHelper(miljø)
                .Create_Digital_Forsendelse_with_multiple_documents()
                .Send()
                .Expect_Message_Response_To_Be_TransportOkKvittering()
                .Fetch_Receipt()
                .Expect_Receipt_To_Be(typeof(Leveringskvittering))
                .ConfirmReceipt();
        }
    }
}
