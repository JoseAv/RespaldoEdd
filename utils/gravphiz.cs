using System.Diagnostics;

class Grafico {
    public static void GenerarImagen(string dotFilePath, string outputImagePath)
    {
        // Comando para ejecutar Graphviz
        string arguments = $"-Tpng \"{dotFilePath}\" -o \"{outputImagePath}\"";

        // Configurar el proceso
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "dot", // Asegúrate de que 'dot' está en el PATH
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        // Ejecutar el proceso
        using (Process process = new Process())
        {
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            // Verificar errores
            string error = process.StandardError.ReadToEnd();
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Error al ejecutar Graphviz:");
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine($"Diagrama generado en {outputImagePath}");
            }
        }
    }
}