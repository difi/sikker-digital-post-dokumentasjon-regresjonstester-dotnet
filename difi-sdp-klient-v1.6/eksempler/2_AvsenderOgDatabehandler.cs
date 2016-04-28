using System.Security.Cryptography.X509Certificates;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Aktører;

namespace difi_sdp_klient_v1._6.eksempler
{
    public class AvsenderOgDatabehandler
    {
        public void Initier()
        {
            var orgnummerAvsender = new Organisasjonsnummer("123456789");
            var avsender = new Avsender(orgnummerAvsender);

            var orgnummerDatabehandler = new Organisasjonsnummer("987654321");
            var avsendersertifikat = new X509Certificate2();
            var databehandler = new Databehandler(orgnummerDatabehandler, avsendersertifikat);

            avsender.Avsenderidentifikator = "Avsenderidentifikator I Organisasjon";
        }
    }
}
