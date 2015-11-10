using System.Security.Cryptography.X509Certificates;
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
            var personnummer = "01013300002";
            var postkasseadresse = "ola.nordmann#2233";
            var mottakersertifikat = new X509Certificate2(); //sertifikat hentet fra Oppslagstjenesten
            var orgnummerPostkasse = "123456789";
            var mottaker = new DigitalPostMottaker(
                    personnummer, 
                    postkasseadresse, 
                    mottakersertifikat, 
                    orgnummerPostkasse
                );
            
            var ikkeSensitivTittel = "En tittel som ikke er sensitiv";
            var sikkerhetsnivå = Sikkerhetsnivå.Nivå3;
            var postInfo = new DigitalPostInfo(mottaker, ikkeSensitivTittel, sikkerhetsnivå);
            
        }

        public void FysiskPostInfo()
        {
            var navn = "Ola Nordmann";
            var adresse = new NorskAdresse("0001", "Oslo");
            var mottakersertifikat = new X509Certificate2(); // sertifikat hentet fra Oppslagstjenesten
            var orgnummerPostkasse = "123456789";
            var mottaker = new FysiskPostMottaker(navn, adresse, mottakersertifikat, orgnummerPostkasse);
            
            var returMottaker = new FysiskPostReturmottaker(
                "John Doe", 
                new NorskAdresse("0566", "Oslo")
                {
                    Adresselinje1 = "Returgata 22"
                });

            var postInfo = new FysiskPostInfo(
                        mottaker, 
                        Posttype.A, 
                        Utskriftsfarge.SortHvitt, 
                        Posthåndtering.MakuleringMedMelding, 
                        returMottaker
                    );
        }
    }
}
