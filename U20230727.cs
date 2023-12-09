using System;

namespace MyApp// Note: actual namespace depends on the project name.
{
    internal class Program
    {
         static void Main(string[] args)
        {
            string filePath = "datos.bin";
            
            EscribirDatosAleatorios(filePath);
            LeerDatos(filePath);
            Console.ReadLine();
            static void EscribirDatosAleatorios (string filePath)
            {
                Random random = new Random();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                using (BinaryWriter writer = new BinaryWriter(fileStream))
                {
                    EscribeDatoEnPosicion (writer, 0, GenerarNumeroAleatorio(random));
                    EscribeDatoEnPosicion (writer, 1, GenerarNumeroAleatorio(random));
                    EscribeDatoEnPosicion (writer, 2, GenerarNumeroAleatorio(random));


                    Console.WriteLine("\nDatos escritos en el archivo.");

                }

            }

            static int GenerarNumeroAleatorio(Random random)
            {
                return random.Next(256);
            }

            static void EscribeDatoEnPosicion(BinaryWriter writer, int posicion, int dato)
            {
                long bytePosicion = posicion * sizeof(int);

                writer.Seek((int)bytePosicion, SeekOrigin.Begin);

                writer.Write(dato);
            }

            static void LeerDatos(string filePath)
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    Console.WriteLine("Dato en posición 0" + LeeDatosEnPosicion(reader, 0));
                    Console.WriteLine("Dato en posición 1" + LeeDatosEnPosicion(reader, 1));
                    Console.WriteLine("Dato en posición 2" + LeeDatosEnPosicion(reader, 2));
                }
            }

            static int LeeDatosEnPosicion(BinaryReader reader, int posicion)
            {
                long bytePosicion = posicion * sizeof(int);

                reader.BaseStream.Seek(bytePosicion, SeekOrigin.Begin);

                return reader.ReadInt32();
            }
        }
    }
}
