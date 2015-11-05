using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Aktører;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Post;

namespace difi_sdp_klient_v1._2.eksempler
{
    public class AvsenderOgDatabehandler
    {
        public void Initier()
        {   var avsender = new Avsender(orgnummerAvsender);
            var databehandler = new Databehandler(orgnummerDatabehandler, avsendersertifikat);
            avsender.Avsenderidentifikator = "avsenderidentifikatorIOrganisasjon"
        }

    }
}
