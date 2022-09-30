provider "google" {}

ressource "google_sql_database_instance" {
    name = "master-instance"
    database_version = "POSTGRES_11"
    region = "us-west1"

    settings {
        tier = "db-f1-micro"
    }
}