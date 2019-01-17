# Geospacial Data Types and Microsoft.SqlServer.Types Version 10.0 vs 11.0+

In case you are using Geospacial data types like SQLGeometry in your projects you may encounter errors like this:

```
Could not load file or assembly 'Microsoft.SqlServer.Types, Version=10.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91' or one of its dependencies.
```

You can get around this by downloading the nuget package Microsoft.SqlServer.Types and adding the following to your app.config:

```
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
        <dependentAssembly> 
          <assemblyIdentity name="Microsoft.SqlServer.Types" publicKeyToken="89845dcd8080cc91" culture="neutral" /> 
          <bindingRedirect oldVersion="10.0.0.0-15.0.0.0" newVersion="14.0.0.0" /> 
        </dependentAssembly>
      </assemblyBinding>
```

You can use this project to recreate this issue. Make sure to restore nuget packages before running. (Requires SQL Server instance).