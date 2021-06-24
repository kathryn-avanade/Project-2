#App service for frontend 
terraform {
    required_providers {
        azurerm = {
            source  = "hashicorp/azurerm"
            version = "~> 2.46.0"
        }
    }
}

provider "azurerm" {
    features {}
}

resource "azurerm_resource_group" "this" {
  name     = var.rg_name
  location = var.location
}

resource "azurerm_app_service_plan" "this" {
   
    name     = var.app_service_plan_name
    location = var.location
    resource_group_name = var.rg_name
    kind                = "Windows"

    #include this line for linux machines 
    #reserved = true

    sku {
      tier = "Basic"
      size = "B1"
    }
}

resource "azurerm_app_service" "this" {
  name                = "katappservice"
  location            = var.location
  resource_group_name = var.rg_name
  app_service_plan_id = azurerm_app_service_plan.this.id
  
  
  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "LocalGit"
  }

  app_settings = {
    "SOME_KEY" = "some-value"
  }

  connection_string {
    name  = "Database"
    type  = "SQLServer"
    value = "Server=some-server.mydomain.com;Integrated Security=SSPI"
  }


}

#Now create the database and server
resource "azurerm_mysql_server" "example" {
  name                = "katdbserver"
  location            = var.location
  resource_group_name = var.rg_name
  
  administrator_login          = var.admin_name
  administrator_login_password = "password123!"
  sku_name   = "B_Gen5_2"
  storage_mb = 5120
  version    = "5.7"

  auto_grow_enabled                 = true
  backup_retention_days             = 7
  geo_redundant_backup_enabled      = false
  infrastructure_encryption_enabled = false
  public_network_access_enabled     = true
  ssl_enforcement_enabled           = true
  ssl_minimal_tls_version_enforced  = "TLS1_2"
}

resource "azurerm_storage_account" "example" {
  name                     = var.storage_account_name
  resource_group_name      = var.rg_name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_mysql_database" "example" {
  name                = "katdb"
  resource_group_name = var.rg_name
 
  server_name         = azurerm_mysql_server.example.name
  charset             = "utf8"
  collation           = "utf8_unicode_ci"
}

#Now create the function apps for the three services 

resource "azurerm_function_app" "app1" {
  name                      = "functionservice1"
  location                  =  var.location
  resource_group_name       = var.rg_name
  app_service_plan_id       = azurerm_app_service_plan.this.id
  storage_account_name       = var.storage_account_name
  storage_account_access_key = azurerm_storage_account.example.primary_access_key
  

}
resource "azurerm_function_app" "app2" {
  name                      = "functionservice2"
  location                  =  var.location
  resource_group_name       = var.rg_name
  app_service_plan_id       = azurerm_app_service_plan.this.id
  storage_account_name       = var.storage_account_name
  storage_account_access_key = azurerm_storage_account.example.primary_access_key
  

}
resource "azurerm_function_app" "app3" {
  name                      = "functionservice3"
  location                  =  var.location
  resource_group_name       = var.rg_name
  app_service_plan_id       = azurerm_app_service_plan.this.id
  storage_account_name       = var.storage_account_name
  storage_account_access_key = azurerm_storage_account.example.primary_access_key
  

}