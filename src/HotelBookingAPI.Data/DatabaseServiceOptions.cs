namespace HotelBookingAPI.Data;

public class DatabaseServiceOptions
{
    public string? Username { get; set; }

    public string? Password { get; init; }

    public string? ServiceName { get; set; } = "g3cb1be755ffe93_tmdev01_high.adb.oraclecloud.com";

    public string? Host { get; set; } = "adb.uk-london-1.oraclecloud.com";

    public string ConnectionString => $";User Id={Username};Password={Password};Data Source=(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host={Host}))(connect_data=(service_name={ServiceName}))(security=(ssl_server_dn_match=yes)));";

    public bool AreServiceOptionsValid =>
        !string.IsNullOrEmpty(Username) &&
        !string.IsNullOrEmpty(Password);
}