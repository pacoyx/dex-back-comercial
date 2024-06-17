using System.Security.Cryptography;

public static class Utils
{
    public static string HashPassword(string password, byte[] salt)
    {

        // Usa PBKDF2 para hashear la contraseña
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
        {
            var hash = pbkdf2.GetBytes(20);

            // Combina la sal y el hash en un solo array
            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convierte el array de bytes a una cadena y devuélvelo
            return Convert.ToBase64String(hashBytes);
        }
    }

    public static byte[] GenerateSalt()
    {
        // Genera una sal aleatoria
        var salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    public static bool VerifyPassword(string enteredPassword, User user)
    {
        // Usa PBKDF2 para hashear la contraseña ingresada
        using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, user.Salt, 10000, HashAlgorithmName.SHA256))
        {
            var hash = pbkdf2.GetBytes(20);

            // Combina la sal y el hash en un solo array
            var enteredHashBytes = new byte[36];
            Array.Copy(user.Salt, 0, enteredHashBytes, 0, 16);
            Array.Copy(hash, 0, enteredHashBytes, 16, 20);

            // Convierte el array de bytes a una cadena
            var enteredHash = Convert.ToBase64String(enteredHashBytes);

            // Compara el hash ingresado con el hash almacenado
            return enteredHash == user.PasswordHash;
        }
    }
}