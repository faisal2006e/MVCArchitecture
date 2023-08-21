using Product.Models.Dtos;
using Product.Repository;
using Product.Repository.IRepository;
using Product.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Services
{
    public class AgreementService : IAgreementServices
    {
        private IAgreementRepository _agreementRepository;
        public AgreementService()
        {
            _agreementRepository = new AgreementRepository();
        }

        public AgreementDto AddAgreement(AgreementDto agreement)
        {
            // TestingData.agreementList.Add(agreement)
            // ;
            AgreementDto agreementdto = new AgreementDto();
            Agreement agreementData = new Agreement();
            AutoMapper.Mapper.Map(agreement, agreementData);
            AutoMapper.Mapper.Map(_agreementRepository.AddAgreement(agreementData), agreementdto);
            return agreementdto;
        }

        public bool DeleteAgreement(int agreementId)
        {
            return _agreementRepository.DeleteAgreement(agreementId);
        }


        public AgreementDto EditAgreement(AgreementDto agreement)
        {
            AgreementDto agreementdto = new AgreementDto();
            Agreement agreementData = new Agreement();
            AutoMapper.Mapper.Map(agreement, agreementData);
            AutoMapper.Mapper.Map(_agreementRepository.EditAgreement(agreementData), agreementdto);
            return agreementdto;
        }

        public List<AgreementDto> GetAllAgreement()
        {
            List<AgreementDto> agreementDto = new List<AgreementDto>() ;
            AutoMapper.Mapper.Map(_agreementRepository.GetAllAgreement(), agreementDto);
            return agreementDto;
        }


        public AgreementDto GetAgreementById(int agreementId)
        {
            AgreementDto agreementDto = new AgreementDto();
            AutoMapper.Mapper.Map(_agreementRepository.GetAgreementById(agreementId), agreementDto);
            return agreementDto;
        }

    }
}
