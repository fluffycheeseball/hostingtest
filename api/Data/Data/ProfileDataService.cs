using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Dapper;

using Data;

using Interfaces.Models;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;

using Serilog;

using static Interfaces.Constants.Constants;

namespace Services {
    public interface IProfileDataService {

        Task<List<UserProfile>> Get();

        Task<UserProfile?> Add(UserProfile? userProfile);

        Task<UserProfile?> GetById(int id);

        Task<int> DeleteById(int id);

        Task<int> Update(int id, JsonPatchDocument<UserProfile>? userProfilePatch);
        }

    public class ProfileDataService : IProfileDataService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly string _connectionString;

        public ProfileDataService(ILogger logger, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("SqlConnectionString");
        }

        public async Task<List<UserProfile>> Get()
        {
            using IDbConnection connection = GetConnection();
            var userProfileDtos = await connection.GetListAsync<UserProfileDto>();
            return userProfileDtos.Select(userProfileDto => _mapper.Map<UserProfile>(userProfileDto)).ToList();
        }

        public async Task<UserProfile?> GetById(int id)
        {
            using IDbConnection connection = GetConnection();
            using var transaction = connection.BeginTransaction();
            var userProfileDto = await connection.GetAsync<UserProfileDto>(id, transaction);
            if (userProfileDto == null) return null;
            return _mapper.Map<UserProfile>(userProfileDto);
        }

        public async Task<int> DeleteById(int id)
        {
            using IDbConnection connection = GetConnection();
            using var transaction = connection.BeginTransaction();
            var userProfileDto = await connection.GetAsync<UserProfileDto>(id);
            if (userProfileDto == null) return HttpBadRequest;
            var numberRecordsDeleted = await connection.DeleteAsync<UserProfileDto>(id);
            if (numberRecordsDeleted != 1)
            {
                return HttpInternalServerError;
            }

            return HttpOK;
        }

        public async Task<int> Update(int id, JsonPatchDocument<UserProfile>? userProfilePatch)
        {
            using IDbConnection connection = GetConnection();
            using var transaction = connection.BeginTransaction();
            var userProfileDto = await connection.GetAsync<UserProfileDto>(id, transaction);
            if (userProfileDto == null) return HttpBadRequest;
            var userProfile = _mapper.Map<UserProfile>(userProfileDto);
            userProfilePatch?.ApplyTo(userProfile);
            await connection.UpdateAsync(userProfileDto, transaction);
            return HttpOK;
        }

        public async Task<UserProfile?> Add(UserProfile? userProfile)
        {
            if (userProfile == null) return null;
            UserProfileDto userProfileDto = _mapper.Map<UserProfileDto>(userProfile);
            using IDbConnection conn = GetConnection();
            var id = await conn.InsertAsync(userProfileDto);
            if (id != null)
            {
                return await GetById(id.Value);
            }
            return null;
        }
    

    private IDbConnection GetConnection() {
            try {
                IDbConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
                } catch (Exception e) {
                _logger.Error(e, "Failed to connect to database with connection string " + _connectionString);
                throw;
                }
            }
        }
    }
