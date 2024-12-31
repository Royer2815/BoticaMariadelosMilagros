using System;
using System.Collections.Generic;


namespace CapaAplicacion
{
    public class AplicacionAutenticacion
    {
        private Dictionary<string, string> usuarios = new Dictionary<string, string>(); // Simulando un registro sencillo  

        public void RegistrarUsuario(string usuario, string contraseña)
        {
            if (!usuarios.ContainsKey(usuario))
            {
                usuarios.Add(usuario, contraseña);
                Console.WriteLine("Usuario registrado: " + usuario);
            }
            else
            {
                Console.WriteLine("El usuario ya existe.");
            }
        }

        public bool AutenticarUsuario(string usuario, string contraseña)
        {
            return usuarios.TryGetValue(usuario, out var pass) && pass == contraseña;
        }
    }
}