using Attendance.Application.Dto.Userdto;
using Attendance.Application.Interface;
using Attendance.Domain.Entity;
using Attendance.Domain.Interface;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Attendance.Application.Service
{
    public class Userservice : IuserService
    {
        private readonly IUserRepo repo;
        private readonly IMapper mapper;
        private readonly IConfiguration config;


        public Userservice(IUserRepo repo,IMapper mapper, IConfiguration configuration)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.config = configuration;
        }

        public async Task<getdto> Delete(int id)
        {
            try
            {
                var result = await repo.Delete(id);
                var data = new getdto
                {
                    Id = result.Id,
                    Username = result.Username,
                    Password = result.Password,
                    Email = result.Email,
                };
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Userservice.Delete failed: {ex.Message}", ex);
            }
        }

        public async Task<List<Postdto>> Getall(string role)
        {
            try
            {
                var data = await repo.Getall(role);

                var returndata = data.Select(x => new Postdto
                {
                    Id = x.Id,
                    Username = x.Username,
                    Password = x.Password,
                    Email = x.Email,
                    RoleId = x.RoleId,

                    Fullname = x.Userdetails?.Fullname,
                    DOB = x.Userdetails?.DOB,
                    Gender = x.Userdetails?.Gender,
                    Phone = x.Userdetails?.Phone,
                    Address = x.Userdetails?.Address,
                    Department = x.Userdetails?.Department,
                    Year = x.Userdetails?.Year

                }).ToList();
                return returndata;
            }
            catch (Exception ex)
            {
                throw new Exception($"Userservice.Getall failed: {ex.Message}", ex);
            }
        }

        public async Task<Postdto> GetbyId(int id)
        {
            var result = await repo.GetbyId(id);
            var data = new Postdto
            {
                Id = result.Id,
                Username = result.Username,
                Password = result.Password,
                Email = result.Email,
                RoleId = result.RoleId,
                Fullname = result.Userdetails.Fullname,
                DOB = result.Userdetails.DOB,
                Gender=result.Userdetails.Gender,
                Phone=result.Userdetails.Phone,
                Address=result.Userdetails.Address,
                Department=result.Userdetails.Department,
                Year=result.Userdetails.Year
            };
            return data;
        }

        public async Task<getdto> Getuser(int id)
        {
            try
            {
                var result = await repo.GetbyId(id);
                var user = new getdto
                {
                    Id = result.Id,
                    Username = result.Username,
                    Password = result.Password,
                    Email = result.Email,

                };
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Userservice.Getuser failed: {ex.Message}", ex);
            }
        }



public async Task<claimdto> Login(Logindto data)
    {
        try
        {
            var user = new User
            {
                Username = data.Username,
                Password = data.Password
            };

            var result = await repo.Login(user);

            if (result == null)
            {
                return null;
            }

            // 🔥 Create Claims
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, result.Username),
            new Claim(ClaimTypes.Role, result.Role.Name),
            new Claim("Id", result.Id.ToString())
        };

            // 🔥 Read JWT settings
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 🔥 Create Token
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            // 🔥 Return with token
            var auth = new claimdto
            {
                Id = result.Id,
                Username = result.Username,
                Role = result.Role.Name,
                Token = jwt   // ✅ IMPORTANT
            };

            return auth;
        }
        catch (Exception ex)
        {
            throw new Exception($"Userservice.Login failed: {ex.Message}", ex);
        }
    }

        public async Task<getdto> Postbyadmin(getdto dto)
        {
            var data = new User { 
            Username = dto.Username,
            Password = dto.Password,
            Email = dto.Email,
            RoleId = dto.RoleId,
            
            };
            var result=await repo.Postbyadmin(data);
            var returndata = new getdto {
                Username = result.Username,
                Password = result.Password,
                Email = result.Email,
                RoleId = result.RoleId,


            };
            return returndata;
        }

        public async Task<Postdto> Posttuser(Postdto data)
        {
            try
            {
                var result = new User
                {
                    Id = data.Id,
                    Username = data.Username,
                    Password = data.Password,
                    Email = data.Email,
                    RoleId = data.RoleId,
                    Userdetails = new Userdetails
                    {
                        Fullname = data.Fullname,
                        DOB = data.DOB,
                        Gender = data.Gender,
                        Phone = data.Phone,
                        Address = data.Address,
                        Department = data.Department,
                        Year = data.Year



                    }


                };
                var user = await repo.Post(result);
                var exchange = new Postdto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    RoleId = user.RoleId,


                };
                return exchange;
            }
            catch (Exception ex)
            {
                throw new Exception($"Userservice.Posttuser failed: {ex.Message}", ex);
            }
        }

        public async Task<Userdetaildto> Postuserdetail(Userdetaildto data)
        {
            var Userdetails = new Userdetails
            {
                UserId = data.UserId,
                Fullname = data.Fullname,
                DOB = data.DOB,
                Gender = data.Gender,
                Phone = data.Phone,
                Address = data.Address,
                Department = data.Department,
                Year = data.Year
            };
            await repo.Postuserdetail(Userdetails);
            return data;


        }

        public async Task<Postdto> Update(Postdto data)
        {
            try
            {
                var user = new User
                {
                    Id = data.Id,
                    Username = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    RoleId = 1,

                    Userdetails = new Userdetails
                    {
                        Fullname = data.Fullname,
                        DOB = data.DOB,
                        Gender = data.Gender,
                        Phone = data.Phone,
                        Address = data.Address,
                        Department = data.Department,
                        Year = data.Year
                    }
                };

                var result = await repo.Update(user);
                var returndata = new Postdto {

                    Id = result.Id,
                    Username = result.Username,
                    Email = result.Email,
                    Password = result.Password,
                    RoleId = result.RoleId,
                    Fullname = result.Userdetails.Fullname,
                    DOB = result.Userdetails.DOB,
                    Gender = result.Userdetails.Gender,
                    Phone = result.Userdetails.Phone,
                    Address = result.Userdetails.Address,
                    Department = result.Userdetails.Department,
                    Year = result.Userdetails.Year

                };

                return returndata ;
            }
            catch (Exception ex)
            {
                throw new Exception($"Userservice.Update failed: {ex.Message}", ex);
            }
        }

    }
}


