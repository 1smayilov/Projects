using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public  class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) // out - çölə veriləcək dəyər
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) // Alqoritm
            {
                passwordSalt = hmac.Key; // alqoritmin key dəyəri, hər istifadəçi üçün ayrıca salt(key) oluşturur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // string byte a çevrilərək heşləyir
            }
        }

        // təkrar girərkən aldığımız parolu yenidən heşliyəciyik və database - dəki hash ilə qarşılaştıracıyıq
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); 
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }
}
