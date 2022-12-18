using Business.Abstract;
using Core.Utilities.Abstract;
using Core.Utilities.Conrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Mail = userForRegisterDto.Mail,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                UserName = userForRegisterDto.UserName,
                BirthDate = userForRegisterDto.BirthDate,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);

            return new SuccessDataResult<User>(user, "Üye Olundu");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Mail);
         
            if (userToCheck.Result == null) 
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı.");
            }
            if (userToCheck.Result.Status)
            {
                return new ErrorDataResult<User>("Oturumunuz zaten açık");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Result.PasswordHash, userToCheck.Result.PasswordSalt))
            {
                return new ErrorDataResult<User>("Şifre Hatalı");
            }
            userToCheck.Result.Status=true;
            _userService.Update(userToCheck.Result);
            return new SuccessDataResult<User>(userToCheck.Result, "Giriş Başarılı");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Result != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Result);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu.");
        }

        public IResult Logout(UserForLogoutDto userForLogoutDto)
        {
            var userToCheck = _userService.GetByMail(userForLogoutDto.Mail);
            if (userToCheck.Result == null)
            {
                return new ErrorResult("Kullanıcı bulunamadı.");
            }
            if (!userToCheck.Result.Status)
            {
                return new ErrorResult("Kullanıcı zaten çevrimdışı");
            }
            userToCheck.Result.Status = false;
            _userService.Update(userToCheck.Result);
            return new SuccessResult("Oturum kapatıldı.");
        }
    }
}
