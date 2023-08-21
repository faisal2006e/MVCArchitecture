using Product.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.IServices
{
    public interface IAgreementServices
    {
        AgreementDto AddAgreement(AgreementDto agreement);
        bool DeleteAgreement(int agreementId);
        AgreementDto EditAgreement(AgreementDto agreement);
        List<AgreementDto> GetAllAgreement();
        AgreementDto GetAgreementById(int agreementId);
    }
    
}
