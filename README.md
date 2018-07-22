# Ubiquiti Unifi Data Exporter

### For what is this tool good for
In case you want export statistics or any other data from unifi controller, this exporter can be helpfull. Exporter can currently export data from `Windows` based and `CloudKey` based controller. Exporter can save data to `SQL Database`, directly to `Filesystem` or both of them. Exporter can be used as `Console application` or as `Windows service`. Exporter save data as `JSON` documents.

### Configuration
Before you use this exporter you have to change configuration in config (_`MalikP.Ubiquiti.DatabaseExporter.Service.exe.config`_) file.

**Setting defines if your password is encrypted or in plain text**<br />
`<add key="Use-Encrypted-Psswords" value="true|false"/>`

_In case you will use `false` bellow configs what describe password encryption need to use unencrypted password. Use when you do not have certificate to encrypt password. **Using plaintext passwords create security risk that password can be stolen by unatorized person**. **Using un-encrypted passwords is not recommended !**_<br />


**Certificate used to decrypt passwords**<br />
`<add key="Encryption-Certificate-Identifier" value="" />`

**Setting define where exporter save files**<br />
`<add key="Backup-Path" value="C:\UnifiBackup" />`

**Setting define ip address on which mongo db is listening** (_not change is needed_)<br />
`<add key="Mongo-Connection-String" value="mongodb://127.0.0.1:27117" />`

**Setting define connection string to Sql server**<br />
`<add key="Sql-Connection-String" value="Server=[SQL-SERVER];Database=[DATABASE-NAME];" />`
- `[SQL-SERVER]` - IP address or FQDN of SQL server
- `[DATABASE-NAME]` - name of database where exporter will save data

**Setting defines username|userId which will be used for SQL server connection**<br />
`<add key="Sql-User-Id" value="" />`

**Setting defines password which will be used for SQL server connection** (_have to be encrypted_) <br/>
`<add key="Sql-User-Password" value="" />`

**Setting defines if Filesystem exporter will be used or not**<br />
`<add key="Export-To-FS" value="true|false" />`

**Setting defines if SQL exporter will be used or not**<br />
`<add key="Export-To-DB" value="true|false" />`

**Setting defines if SSH tunel will be used or not** (_needed to set to true in case you want export data from cloud key_) <br />
`<add key="Use-SSH-Tunel" value="true|false" />`

**Setting defines IP address or FQDN of Ubiquiti unifi cloud key**<br />
`<add key="SSH-Tunel-Host" value="" />`

**Setting defines username used to login to Ubiquiti unifi cloud key**<br />
`<add key="SSH-Tunel-UserName" value="" />`

**Setting defines password which will be used for SSH connection** (_have to be encrypted_)<br />
`<add key="SSH-Tunel-Password" value="" />`

**Setting defines port forward source IP address in SSH tunel** (_change is not needed_)<br />
`<add key="SSH-Forward-Host-From" value="127.0.0.1" />`

**Setting defines port forward source port in SSH tunel** (_change is not needed_)<br />
`<add key="SSH-Forward-Port-From" value="27117" />`

**Setting defines port forward target IP address in SSH tunel** (_change is not needed_)<br />
`<add key="SSH-Forward-Host-To" value="127.0.0.1" />`

**Setting defines port forward target port in SSH tunel** (_change is not needed_)<br />
`<add key="SSH-Forward-Port-To" value="27117" />`

### How to get encrypted password
You can use attached tool which will encrypt your `plain text` password. Before you use `MalikP.Ubiquiti.DatabaseExporter.EncryptPasswordTool` update tool's (_`MalikP.Ubiquiti.DatabaseExporter.EncryptPasswordTool.exe.config`_) file.<br />

**Certificate used to decrypt passwords**<br />
`<add key="Encryption-Certificate-Identifier" value="" />`

Once tool's config is updated get your encrypted passwords:
`MalikP.Ubiquiti.DatabaseExporter.EncryptPasswordTool your_password`

_Your password should be also automatically copied into clipboard._
 
### Prepare SQL Database
If you want to use SQL Server Database to store your data you also have to create database and prepare schema of that database.
1. create empty SQL database
2. execute script located in project `~\src\MalikP.Ubiquiti.DatabaseExporter.Data\Scripts\InstallScript.sql`
3. done