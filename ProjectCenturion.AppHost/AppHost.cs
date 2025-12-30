var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ProjectCenturion_WorkerFunctions>("projectcenturion-workerfunctions");

builder.AddProject<Projects.ProjectCenturion_Leads>("projectcenturion-leads");

builder.Build().Run();