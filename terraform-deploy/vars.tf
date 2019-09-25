variable "terraform_azure_service_principal_client_id" {
  type        = "string"
  description = "Service Principal Client ID"
  default     = "316bcf68-c2b4-432a-ab6c-31e008d6ac90"
}

variable "terraform_azure_service_principal_client_secret" {
  type        = "string"
  description = "Service Principal Client Secret"
  default     = "dc4638a0-ac82-4e6f-ae57-283c8cfed120"
}

variable "terraform_azure_service_principal_tenant_id" {
  type        = "string"
  description = "Service Principal Tenant Id"
  default     = "4fbac547-6c77-4a80-b3af-9bbf0a7196f4"
}

variable "terraform_azure_service_principal_subscription_id" {
  type        = "string"
  description = "Service Principal Subscription Id"
  default     = "54d0d43f-39ad-4605-b92b-6f5a4b27ee04"
}

variable "terraform_azure_region" {
  type        = "string"
  default     = "Central US"
}