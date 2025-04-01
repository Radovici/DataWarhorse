dotnet ef dbcontext scaffold "Server=radovici.ddns.net;Database=DataWarehouse;User Id=<user>;Password=<pw>;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer \
-o Models \
--context-dir Context \
-c DataWarehouseContext \
--context-namespace DataModels.EntityFramework.Contexts \
--namespace DataModels.EntityFramework.Models \
--data-annotations \
--exclude-tables Imported*,Loaded* \
--project DataModels.EntityFramework