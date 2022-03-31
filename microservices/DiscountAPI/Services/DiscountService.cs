using DiscountAPI.Entities;
using DiscountAPI.Protos;
using DiscountAPI.Repositories;

using Grpc.Core;

using System.Threading.Tasks;

namespace DiscountAPI.Services
{
    public class DiscountService: DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;

        public DiscountService(IDiscountRepository repository)
        {
            _repository=repository;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            Coupon coupon = new Coupon { Amount = request.Coupon.Amount, Description = request.Coupon.Description, Name = request.Coupon.ProductName };
            await _repository.CreateDiscount(coupon);
            request.Coupon.Id = coupon.Id;
            return request.Coupon;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted=await _repository.DeleteDiscount(request.ProductName);
            var response = new DeleteDiscountResponse
            {
                Success = deleted
            };

            return response;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetDiscount(request.ProductName);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));
            }

            var couponModel = new CouponModel { Id = coupon.Id, ProductName = coupon.Name, Amount = coupon.Amount, Description = coupon.Description };
            return couponModel;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = new Coupon
            {
                Id = request.Coupon.Id,
                Description = request.Coupon.Description,
                Name = request.Coupon.ProductName,
                Amount = request.Coupon.Amount
            };

            await _repository.UpdateDiscount(coupon);

            return request.Coupon;
        }
    }
}
