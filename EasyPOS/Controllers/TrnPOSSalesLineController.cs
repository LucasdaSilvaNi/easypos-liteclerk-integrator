using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnPOSSalesLineController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =================
        // List - Sales Line
        // =================
        public List<Entities.TrnSalesLineEntity> ListSalesLine(Int32 salesId)
        {
            var salesLines = from d in db.TrnSalesLines
                             where d.SalesId == salesId
                             select new Entities.TrnSalesLineEntity
                             {
                                 Id = d.Id,
                                 SalesId = d.SalesId,
                                 ItemId = d.ItemId,
                                 ItemDescription = d.MstItem.ItemDescription,
                                 UnitId = d.UnitId,
                                 Unit = d.MstUnit.Unit,
                                 Price = d.Price,
                                 DiscountId = d.DiscountId,
                                 DiscountRate = d.DiscountRate,
                                 DiscountAmount = d.DiscountAmount,
                                 NetPrice = d.NetPrice,
                                 Quantity = d.Quantity,
                                 Amount = d.Amount,
                                 TaxId = d.TaxId,
                                 Tax = d.MstTax.Tax,
                                 TaxRate = d.TaxRate,
                                 TaxAmount = d.TaxAmount,
                                 SalesAccountId = d.SalesAccountId,
                                 AssetAccountId = d.AssetAccountId,
                                 CostAccountId = d.CostAccountId,
                                 TaxAccountId = d.TaxAccountId,
                                 SalesLineTimeStamp = d.SalesLineTimeStamp.ToShortDateString(),
                                 UserId = d.UserId,
                                 Preparation = d.Preparation,
                                 Price1 = d.Price1,
                                 Price2 = d.Price2,
                                 Price2LessTax = d.Price2LessTax,
                                 PriceSplitPercentage = d.PriceSplitPercentage,
                             };

            return salesLines.ToList();
        }

        // =================
        // Add - Sales Line
        // =================
        public String[] AddSalesLine(Entities.TrnSalesLineEntity objSalesLine)
        {
            try
            {
                var currentSales = from d in db.TrnSales
                                   where d.Id == objSalesLine.SalesId
                                   select d;

                if (currentSales.Any() == false)
                {
                    return new String[] { "Sales transaction not found.", "0" };
                }

                var item = from d in db.MstItems where d.Id == objSalesLine.ItemId select d;
                if (item.Any() == false)
                {
                    return new String[] { "Item not found.", "0" };
                }

                var discount = from d in db.MstDiscounts where d.Id == objSalesLine.DiscountId select d;
                if (discount.Any() == false)
                {
                    return new String[] { "Discount not found.", "0" };
                }

                var tax = from d in db.MstTaxes where d.Id == objSalesLine.TaxId select d;
                if (tax.Any() == false)
                {
                    return new String[] { "Tax not found.", "0" };
                }



                Decimal netPrice = objSalesLine.Price - objSalesLine.DiscountAmount;

                Data.TrnSalesLine newSaleLine = new Data.TrnSalesLine
                {
                    SalesId = objSalesLine.SalesId,
                    ItemId = objSalesLine.ItemId,
                    UnitId = item.FirstOrDefault().UnitId,
                    Price = objSalesLine.Price,
                    DiscountId = objSalesLine.DiscountId,
                    DiscountRate = discount.FirstOrDefault().DiscountRate,
                    DiscountAmount = objSalesLine.DiscountAmount,
                    NetPrice = netPrice,
                    Quantity = objSalesLine.Quantity,
                    Amount = 0,
                    TaxId = objSalesLine.TaxId,
                    TaxRate = tax.FirstOrDefault().Rate,
                    TaxAmount = taxAmount,
                    SalesAccountId = 159,
                    AssetAccountId = 255,
                    CostAccountId = 238,
                    TaxAccountId = 87,
                    SalesLineTimeStamp = DateTime.Now.Date,
                    UserId = user.FirstOrDefault().Id,
                    Preparation = "",
                    Price1 = netPrice * quantity,
                    Price2 = amount,
                    Price2LessTax = amount,
                    PriceSplitPercentage = amount,
                };

                db.TrnSalesLines.InsertOnSubmit(newSaleLine);
                db.SubmitChanges();

                return new String[] { "", newSaleLine.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
