using System;
using Difi.SikkerDigitalPost.Klient;
using Difi.SikkerDigitalPost.Klient.Api;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Aktører;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Kvitteringer;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Kvitteringer.Forretning;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Kvitteringer.Transport;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Post;
using Difi.SikkerDigitalPost.Klient.Domene.Enums;
using Difi.SikkerDigitalPost.Klient.XmlValidering;

namespace difi_sdp_klient_v2.eksempler
{
    public class Klient
    {
        public void NyKlientOgSend()
        {
            var klientKonfig = new Klientkonfigurasjon(Miljø.FunksjoneltTestmiljø);

            Databehandler databehandler = null; //Som initiert tidligere
            Forsendelse forsendelse = null; //Som initiert tidligere

            var sdpKlient = new SikkerDigitalPostKlient(databehandler, klientKonfig);
            var transportkvittering = sdpKlient.Send(forsendelse);

            if (transportkvittering is TransportOkKvittering)
            {
                //Når alt går fint	
            }
            else if (transportkvittering is TransportFeiletKvittering)
            {
                var beskrivelse = ((TransportFeiletKvittering) transportkvittering).Beskrivelse;
            }

            ////////////////////////////////////////
            // Eksempel for henting av kvittering
            ////////////////////////////////////////
            
            var køId = "MpcId";
            var kvitteringsForespørsel = new Kvitteringsforespørsel(Prioritet.Prioritert, køId);
            Console.WriteLine(" > Henter kvittering på kø '{0}'...", kvitteringsForespørsel.Mpc);

            Kvittering kvittering = sdpKlient.HentKvittering(kvitteringsForespørsel);

            if (kvittering is TomKøKvittering)
            {
                Console.WriteLine("  - Kø '{0}' er tom. Stopper å hente meldinger. ", kvitteringsForespørsel.Mpc);
            }

            if (kvittering is TransportFeiletKvittering)
            {
                var feil = ((TransportFeiletKvittering) kvittering).Beskrivelse;
                Console.WriteLine("En feil skjedde under transport.");
            }

            if (kvittering is Leveringskvittering)
            {
                Console.WriteLine("  - En leveringskvittering ble hentet!");
            }

            if (kvittering is Åpningskvittering)
            {
                Console.WriteLine("  - Har du sett. Noen har åpnet et brev. Moro.");
            }

            if (kvittering is Returpostkvittering)
            {
                Console.WriteLine("  - Du har fått en returpostkvittering for fysisk post.");
            }

            if (kvittering is Mottakskvittering)
            {
                Console.WriteLine("  - Kvittering på sending av fysisk post mottatt.");
            }

            if (kvittering is Feilmelding)
            {
                var feil = (Feilmelding)kvittering;
                Console.WriteLine("  - En feilmelding ble hentet :" + feil.Detaljer, true);
            }

            //////////////////////////////////////////
            /// Bekreft
            /////////////////////////////////////////

            sdpKlient.Bekreft((Forretningskvittering)kvittering);
        }

        public void HentKvitteringer()
        {
            
        }
    }
}
