using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Aktører;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.FysiskPost;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Post;
using Difi.SikkerDigitalPost.Klient.Domene.Enums;

namespace difi_sdp_klient_v1._2.eksempler
{
    public class Postinfo
    {
        public void DigitalPostInfo()
        {
            var mottaker = new DigitalPostMottaker(personnummer, postkasseadresse, mottakersertifikat, orgnummerPostkasse);
            var postInfo = new DigitalPostInfo(mottaker, ikkeSensitivTittel, sikkerhetsnivå);
        }

        public void FysiskPostInfo()
        {
            var mottaker = new FysiskPostMottaker(navn, adresse, mottakersertifikat, orgnummerPostkasse);
            var postInfo = new FysiskPostInfo(mottaker, Posttype.A, Utskriftsfarge.SortHvitt, Posthåndtering.MakuleringMedMelding, returMottaker);
        }
    }
}
