provider "google" {}

resource "google_sql_database_instance" "main" {
    name = "main-instance"
    database_version = "POSTGRES_11"
    region = "europe-west1"

    settings {
        tier = "db-f1-micro"
    }
}