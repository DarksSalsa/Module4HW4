using Shop.Data.Entities;

namespace Shop.Services.Abstractons
{
    public interface ISupplierService
    {
        Task<int> AddSupplierAsync(
            string companyName,
            string contactFName,
            string contactLName,
            string contactTitle,
            string address1,
            string address2,
            string city,
            string state,
            string postalCode,
            string country,
            string phone,
            string fax,
            string email,
            string url,
            string paymentMethods,
            string discountType,
            string notes,
            bool discountAvailable,
            string currentOrder,
            string logo,
            string customerId,
            string sizeURL);
        Task<bool> DeleteSupplierAsync(int supplierId);
        Task<bool> UpdateSupplerAsync(int supplierId, string property, string value);
        Task<SupplierModel> GetSupplierAsync(int supplierId);
    }
}
