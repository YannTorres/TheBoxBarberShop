using TheBoxBarberShop.Communication.Request.Users;
using TheBoxBarberShop.Communication.Response.Users;
using TheBoxBarberShop.Domain.Entities;
using TheBoxBarberShop.Domain.Repositories;
using TheBoxBarberShop.Domain.Security.Cryptography;
using TheBoxBarberShop.Domain.Security.Tokens;
using TheBoxBarberShop.Exceptions;

namespace TheBoxBarberShop.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IPasswordEncripter _passwordEncripter;
    //private readonly IUserReadOnlyRepository _repositoryReadOnly;
    //private readonly IUserWriteOnlyRepository _repositoryWriteOnly;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAcessTokenGenerator _tokenGenerator;
    public RegisterUserUseCase(
        IPasswordEncripter passwordEncripter,
        //IUserReadOnlyRepository repositoryReadOnly,
        //IUserWriteOnlyRepository repositoryWriteOnly,
        IUnitOfWork unitOfWork,
        IAcessTokenGenerator tokenGenerator
        )
    {
        _passwordEncripter = passwordEncripter;
        //_repositoryReadOnly = repositoryReadOnly;
        //_repositoryWriteOnly = repositoryWriteOnly;
        _unitOfWork = unitOfWork;
        _tokenGenerator = tokenGenerator;
    }
    public async Task<ResponseRegisterUserJson> Execute(RequestRegisteredUserJson request)
    {
        await Validate(request);

        var user = new User()
        {
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Password = request.Password,
        };
        user.Password = _passwordEncripter.Encript(user.Password);
        user.Id = Guid.NewGuid();

        await _unitOfWork.Commit();

        return new ResponseRegisterUserJson
        {
            Name = user.Name,
            Token = _tokenGenerator.Generate(user)
        };
    }

    private async Task Validate(RequestRegisteredUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        // var existEmail = await _repositoryReadOnly.ExistUserWithEmail(request.Email);

        // var existPhone = await _repositoryReadOnly.ExistUserWithPhone(request.Email);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ValidationException(errorMessages);
        }
    }
}
