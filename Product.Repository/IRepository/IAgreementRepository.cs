using Product.Models.Dtos;
using Product.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.IRepository
{
    public interface IAgreementRepository
    {
        Agreement AddAgreement(Agreement agreement);
        bool DeleteAgreement(int agreementId);
        Agreement EditAgreement(Agreement agreement);
        List<Agreement> GetAllAgreement();
        Agreement GetAgreementById(int agreementId);
    }
}
