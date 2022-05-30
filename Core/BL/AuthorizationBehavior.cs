using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Core.BL;
using Core.Exceptions;
using Core.Services.CurrentUserService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Bl
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public readonly ICurrentUserService _cus;
        public readonly AppDbContext _db;
        public AuthorizationBehavior(ICurrentUserService cus, AppDbContext db)
        {
            _cus = cus;
            _db = db;
        }
    
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var type = request.GetType();
            var attribute = type.GetCustomAttributes<AccessRightsAttribute>().FirstOrDefault();
            
            if (attribute == null)
                throw new Exception("Attribute not found.");

            var currentUser = _cus.GetUser();
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Login == currentUser.Login && user.Password == currentUser.Password);
            
            if (user == null || user.RevokedBy != null)
                throw new AuthorizationFailedException();

            if (attribute.Permission.Contains("Admin") && user.Admin == false)
                throw new AccessRightsException();
                     
            return await next();
        }
    }
}
