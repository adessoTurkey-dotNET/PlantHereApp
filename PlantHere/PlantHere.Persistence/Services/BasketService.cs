

using PlantHere.Application.CQRS.Basket.Commands.BuyBasket;
using PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem;
using PlantHere.Domain.Aggregate.BasketAggregate.Entities;
using PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects;

namespace PlantHere.Persistence.Services
{
    public class BasketService : Service<Basket>, IBasketService
    {
        private readonly IBasketRepository _basketReposity;
        private readonly IMapper _mapper;

        public BasketService(IRepository<Basket> repository, IUnitOfWork unitOfWork, IBasketRepository basketRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _basketReposity = basketRepository;
            _mapper = mapper;
        }

        public async Task<CustomResult<BuyBasketCommandResult>> BuyBasket(BuyBasketCommand buyBasketCommand)
        {
            var basket = await _basketReposity.GetBasketByUserId(buyBasketCommand.UserId);

            if (basket == null) throw new NotFoundException($"{typeof(Basket).Name}({buyBasketCommand.UserId}) Not Found");

            basket.BuyBasket(_mapper.Map<Address>(buyBasketCommand.Address), buyBasketCommand.Payment.CardTypeId, buyBasketCommand.Payment.CardNumber, buyBasketCommand.Payment.CardSecurityNumber, buyBasketCommand.Payment.CardHolderName);

            await _unitOfWork.CommitAsync();

            return CustomResult<BuyBasketCommandResult>.Success(200, new BuyBasketCommandResult());
        }

        public async Task<CustomResult<CreateBasketItemCommandResult>> CreateBasketItem(CreateBasketItemCommand createBasketItemCammand)
        {
            await _basketReposity.CreateBasketItem(createBasketItemCammand);
            await _unitOfWork.CommitAsync();
            return CustomResult<CreateBasketItemCommandResult>.Success(204, new CreateBasketItemCommandResult());
        }

        public async Task<CustomResult<DeleteBasketItemCommandResult>> DeleteBasketItem(DeleteBasketItemCommand deleteBasketItemCammand)
        {
            await _basketReposity.DeleteBasketItem(deleteBasketItemCammand);
            await _unitOfWork.CommitAsync();
            return CustomResult<DeleteBasketItemCommandResult>.Success(204, new DeleteBasketItemCommandResult());
        }

        public async Task<CustomResult<GetBasketByUserIdQueryResult>> GetBasketsByUserIdAsync(string userId)
        {
            var basket = await _basketReposity.GetBasketByUserId(userId);

            if (basket == null) throw new NotFoundException($"{typeof(Basket).Name}({userId}) Not Found");

            return CustomResult<GetBasketByUserIdQueryResult>.Success(200, _mapper.Map<GetBasketByUserIdQueryResult>(basket));
        }

        public async Task<bool> RemoveBasket(string userId)
        {
            var basket = await _basketReposity.GetBasketByUserId(userId);
            _basketReposity.Remove(basket);
            return true;
        }

        public async Task<CustomResult<UpdateBasketItemCommandResult>> UpdateBasketItem(UpdateBasketItemCommand updateBasketItemCammand)
        {
            await _basketReposity.UpdateBasketItem(updateBasketItemCammand);
            await _unitOfWork.CommitAsync();
            return CustomResult<UpdateBasketItemCommandResult>.Success(204, new UpdateBasketItemCommandResult());
        }
    }
}
