using System;
using System.Security.Cryptography.X509Certificates;
using ApiClientShared;
using ApiClientShared.Enums;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Aktører;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.FysiskPost;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Post;
using Difi.SikkerDigitalPost.Klient.Domene.Entiteter.Varsel;
using Difi.SikkerDigitalPost.Klient.Domene.Enums;
using Xunit;

namespace difi_sdp_klient_smoke
{
    internal static class DomainUtility
    {
        internal static readonly ResourceUtility ResourceUtility = new ResourceUtility("Difi.SikkerDigitalPost.Klient.Tester.testdata");

        internal static Dokumentpakke GetDokumentpakkeWithoutAttachments()
        {
            return new Dokumentpakke(GetHoveddokumentSimple());
        }
        
        internal static Dokument GetHoveddokumentSimple()
        {
            return new Dokument("Hoveddokument", new byte[] {0xb, 0x4, 0x4}, "text/plain");
        }

        internal static Avsender GetAvsender()
        {
            var orgnrBring = new Organisasjonsnummer("988015814");
            return new Avsender(orgnrBring);
        }

        internal static string GetPersonnummerMottaker()
        {
            return "01043100358";
        }

        internal static string GetDigipostadresseMottaker()
        {
            return "dangfart.utnes#1BK5";
        }

        internal static Organisasjonsnummer GetOrganisasjonsnummerPostkasse()
        {
            return new Organisasjonsnummer("984661185");
        }

        internal static DigitalPostMottaker GetDigitalPostMottaker()
        {
            return new DigitalPostMottaker(GetPersonnummerMottaker(), GetDigipostadresseMottaker(), GetMottakerCertificate(), GetOrganisasjonsnummerPostkasse());
        }

        internal static FysiskPostMottaker GetFysiskPostMottaker()
        {
            return new FysiskPostMottaker("Testbruker i Tester .NET", new NorskAdresse("0001", "Testekommunen"), GetMottakerCertificate(), GetOrganisasjonsnummerPostkasse());
        }

        internal static DigitalPostMottaker GetDigitalPostMottakerWithTestCertificate()
        {
            return new DigitalPostMottaker(GetPersonnummerMottaker(), GetDigipostadresseMottaker(), GetReceiverUnitTestsCertificate(), GetOrganisasjonsnummerPostkasse());
        }

        internal static FysiskPostReturmottaker GetFysiskPostReturMottaker()
        {
            return new FysiskPostReturmottaker("Testbruker i Tester .NET", new NorskAdresse("0001", "Testekommunen"));
        }

        internal static Databehandler GetDatabehandler()
        {
            return new Databehandler(GetAvsender().Organisasjonsnummer, GetAvsenderCertificate());
        }

        internal static DigitalPostInfo GetDigitalPostInfoSimple()
        {
            return new DigitalPostInfo(GetDigitalPostMottaker(), "Ikke-sensitiv tittel");
        }

        internal static FysiskPostInfo GetFysiskPostInfoSimple()
        {
            return new FysiskPostInfo(GetFysiskPostMottaker(), Posttype.A, Utskriftsfarge.Farge,
                Posthåndtering.DirekteRetur, GetFysiskPostReturMottaker());
        }

        internal static Forsendelse GetForsendelseSimple()
        {
            return new Forsendelse(GetAvsender(), GetDigitalPostInfoSimple(), GetDokumentpakkeWithoutAttachments(), Prioritet.Normal, Guid.NewGuid().ToString());
        }

        internal static Forsendelse GetFysiskPostSimple()
        {
            return new Forsendelse(GetAvsender(), GetFysiskPostInfoSimple(), GetDokumentpakkeWithoutAttachments(), Prioritet.Normal, Guid.NewGuid().ToString());
        }

        internal static X509Certificate2 GetAvsenderEnhetstesterSertifikat()
        {
            return GetEternalTestCertificateMedPrivateKey();
        }

        internal static X509Certificate2 GetReceiverUnitTestsCertificate()
        {
            return GetEternalTestCertificateWithoutPrivateKey();
        }

        private static X509Certificate2 GetEternalTestCertificateWithoutPrivateKey()
        {
            return new X509Certificate2(ResourceUtility.ReadAllBytes(true, "sertifikater", "enhetstester", "difi-enhetstester.cer"), "", X509KeyStorageFlags.Exportable);
        }

        private static X509Certificate2 GetEternalTestCertificateMedPrivateKey()
        {
            return new X509Certificate2(ResourceUtility.ReadAllBytes(true, "sertifikater", "enhetstester", "difi-enhetstester.p12"), "", X509KeyStorageFlags.Exportable);
        }

        internal static X509Certificate2 GetAvsenderCertificate()
        {
            string bringThumbprint = "2d7f30dd05d3b7fc7ae5973a73f849083b2040ed";
            return CertificateUtility.SenderCertificate(bringThumbprint, Language.Norwegian);
        }

        internal static X509Certificate2 GetMottakerCertificate()
        {
            var ru = new ResourceUtility("difi_sdp_klient_smoke");
            var readAllBytes = ru.ReadAllBytes(true, "testavsendersertifikat.pem");
            
            return new X509Certificate2(readAllBytes);
        }
    }
}
