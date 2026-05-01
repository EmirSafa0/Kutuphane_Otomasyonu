using System;
using System.IO;
using System.Text.Json;

public class DbConfig
{
    public string Server { get; set; }
    public string Database { get; set; }
    public bool IntegratedSecurity { get; set; }
    public bool Encrypt { get; set; }
    public bool TrustServerCertificate { get; set; }
}

public static class ConfigHelper
{
    public static DbConfig GetConfig()
    {
        string json = File.ReadAllText("dbconfig.json");
        return JsonSerializer.Deserialize<DbConfig>(json);
    }
}

