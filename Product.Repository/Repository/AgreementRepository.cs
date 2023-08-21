using Product.Core;
using Product.Models.Dtos;
using Product.Repository.IRepository;
using Product.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository
{
    public class AgreementRepository : IAgreementRepository
    {
        private ProductDBEntities _db;
        public AgreementRepository()
        {
            _db = new ProductDBEntities();
        }

        public Agreement AddAgreement(Agreement agreement)
        {
            _db.Agreements.Add(agreement);
            _db.SaveChanges();

            return agreement;

        }

        public bool DeleteAgreement(int agreementId)
        {
            var getAgreement = _db.Agreements.Where(x => x.Id == agreementId).FirstOrDefault<Agreement>();
            if (getAgreement != null)
            {
                _db.Agreements.Remove(getAgreement);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Agreement EditAgreement(Agreement agreement)
        {
            var oldAgreement = _db.Agreements.FirstOrDefault(e => e.Id == agreement.Id);

            oldAgreement.UserId = agreement.UserId;
            oldAgreement.ProductGroupId = agreement.ProductGroupId;
            oldAgreement.ProductId = agreement.ProductId;
            oldAgreement.EffectiveDate = agreement.EffectiveDate;
            oldAgreement.ExpirationDate = agreement.ExpirationDate;
            oldAgreement.ProductPrice = agreement.ProductPrice;
            oldAgreement.NewPrice = agreement.NewPrice;
            oldAgreement.Active = agreement.Active;

            _db.SaveChanges();

            return agreement;
        }

        public List<Agreement> GetAllAgreement()
        {
            //using (var dbContext = new DBModel(CommonDeclarations.DBContextConnectionString))
            //{
            //    return dbContext.Agreements.ToList();
            //}
            return _db.Agreements.ToList<Agreement>();
        }

        public Agreement GetAgreementById(int agreementId)
        {
            return _db.Agreements.Where(x => x.Id == agreementId).FirstOrDefault<Agreement>();
        }
    }
}
