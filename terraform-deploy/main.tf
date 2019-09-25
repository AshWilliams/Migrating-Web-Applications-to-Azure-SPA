
# Configure the Azure Provider
provider "azurerm" {
  subscription_id = "${var.terraform_azure_service_principal_subscription_id}"
  client_id       = "${var.terraform_azure_service_principal_client_id}"
  client_secret   = "${var.terraform_azure_service_principal_client_secret}"
  tenant_id       = "${var.terraform_azure_service_principal_tenant_id}"
  version = "~> 1.31"
}

resource "azurerm_resource_group" "group" {
  name     = "TAILWINDSRGDEMOCHILE"
  location = var.terraform_azure_region

  tags = {
    environment = "UAT"
  }
}

# ACR
resource "azurerm_container_registry" "acr" {
  name                     = "TAILWINDSACR"
  resource_group_name      = "${azurerm_resource_group.group.name}"
  location                 = "${azurerm_resource_group.group.location}"
  sku                      = "Standard"
  admin_enabled            = true
}

# Create an App Service Plan with Linux
resource "azurerm_app_service_plan" "appserviceplan" {
  name                = "${azurerm_resource_group.group.name}-plan"
  location            = "${azurerm_resource_group.group.location}"
  resource_group_name = "${azurerm_resource_group.group.name}"

  # Define Linux as Host OS
  kind = "Linux"
  reserved = true
  # Choose size
  sku {
    tier = "Basic"
    size = "B3"
  }
}


# Create an Azure Web App for Containers in that App Service Plan
resource "azurerm_app_service" "tailwindfrontend" {
  name                = "${azurerm_resource_group.group.name}-frontend"
  location            = "${azurerm_resource_group.group.location}"
  resource_group_name = "${azurerm_resource_group.group.name}"
  app_service_plan_id = "${azurerm_app_service_plan.appserviceplan.id}"

  site_config {
    always_on        = true
    linux_fx_version = "DOCKER|${azurerm_container_registry.acr.login_server}/testdocker-alpine:v1"
  }
  
  app_settings = {
    WEBSITES_ENABLE_APP_SERVICE_STORAGE = "false"
    DOCKER_REGISTRY_SERVER_URL          = "https://${azurerm_container_registry.acr.login_server}"
    DOCKER_REGISTRY_SERVER_USERNAME     = "${azurerm_container_registry.acr.admin_username}"
    DOCKER_REGISTRY_SERVER_PASSWORD     = "${azurerm_container_registry.acr.admin_password}"
  }
}

# Create an Azure Web App for Containers in that App Service Plan
resource "azurerm_app_service" "tailwindapi" {
  name                = "${azurerm_resource_group.group.name}-api"
  location            = "${azurerm_resource_group.group.location}"
  resource_group_name = "${azurerm_resource_group.group.name}"
  app_service_plan_id = "${azurerm_app_service_plan.appserviceplan.id}"

  site_config {
    always_on        = true
    linux_fx_version = "DOCKER|${azurerm_container_registry.acr.login_server}/testdocker-alpine:v1"
  }

  app_settings  = {
    WEBSITES_ENABLE_APP_SERVICE_STORAGE = "false"
    DOCKER_REGISTRY_SERVER_URL          = "https://${azurerm_container_registry.acr.login_server}"
    DOCKER_REGISTRY_SERVER_USERNAME     = "${azurerm_container_registry.acr.admin_username}"
    DOCKER_REGISTRY_SERVER_PASSWORD     = "${azurerm_container_registry.acr.admin_password}"
  }
}