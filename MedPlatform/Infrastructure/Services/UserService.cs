using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    enum Roles : int
    {
        Doctor = 1,
        Caregiver = 2,
        Patient = 3
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
        }

        public string Authenticate(AuthenticateRequest model)
        {
            var user = _unitOfWork.UserRepository.Get(user => user.Username == model.Username && user.Password == model.Password).FirstOrDefault();

            if (user == null) return null;

            var token = generateJwtToken(user);

            return token;
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.UserRepository.Get();
        }

        public User GetById(int id)
        {
            return _unitOfWork.UserRepository.GetByID(id);
        }

        private string generateJwtToken(User user)
        {
            var id = 0;
            if (user.RoleId == (int) Roles.Doctor)
            {
                id = _unitOfWork.DoctorRepository.Get(d => d.UserId == user.UserId).FirstOrDefault().DoctorId;
            }
            else if (user.RoleId == (int) Roles.Caregiver)
            {
                id = _unitOfWork.CaregiverRepository.Get(c => c.UserId == user.UserId).FirstOrDefault().CaregiverId;
            }
            else if (user.RoleId == (int) Roles.Patient)
            {
                id = _unitOfWork.PatientRepository.Get(p => p.UserId == user.UserId).FirstOrDefault().PatientId;
            }       

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserId", user.UserId.ToString()), new Claim("RoleId", user.RoleId.ToString()), new Claim("Id", id.ToString()), new Claim("Username", user.Username.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
