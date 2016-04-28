using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Aktører;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Post;

namespace difi_sdp_klient_v1._6.eksempler
{
    public class LagForsendelse
    {
        public void OppretteForsendelse()
        {
            var hoveddokument = new Dokument(
                    tittel: "Dokumenttittel", 
                    dokumentsti: "/Dokumenter/Hoveddokument.pdf", 
                    mimeType: "application/pdf", 
                    språkkode: "NO", 
                    filnavn: "filnavn"
                );

            var dokumentpakke = new Dokumentpakke(hoveddokument);

            var vedleggssti = "/Dokumenter/Vedlegg.pdf";
            var vedlegg = new Dokument(
                tittel: "tittel", 
                dokumentsti: vedleggssti, 
                mimeType: "application/pdf", 
                språkkode: "NO", 
                filnavn: "filnavn");

            dokumentpakke.LeggTilVedlegg(vedlegg);

            Avsender avsender = null; //Som initiert tidligere
            PostInfo postInfo = null; //Som initiert tidligere
            var forsendelse = new Forsendelse(avsender,postInfo,dokumentpakke);
        }
    }
}
