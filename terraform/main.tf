terraform {
  required_version = ">= 1.9"
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }
  }
}

provider "aws" {
  region = var.aws_region
}

data "aws_ami" "amazon_linux_2023" {
  most_recent = true
  owners      = ["amazon"]
  filter {
    name   = "name"
    values = ["al2023-ami-*-x86_64"]
  }
  filter {
    name   = "virtualization-type"
    values = ["hvm"]
  }
}

resource "aws_security_group" "app_sg" {
  name        = "contoso-app-sg"
  description = "Allow HTTP and SSH"
  ingress {
    description = "HTTP"
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }
  ingress {
    description = "SSH"
    from_port   = 22
    to_port     = 22
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }
  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
  tags = {
    Name = "contoso-app-sg"
  }
}

resource "aws_instance" "app_server" {
  ami                    = data.aws_ami.amazon_linux_2023.id
  instance_type          = "t2.medium"
  vpc_security_group_ids = [aws_security_group.app_sg.id]

  user_data_replace_on_change = true

  user_data = <<-USERDATA
    #!/bin/bash
    set -e
    dnf update -y
    dnf install -y docker
    systemctl enable docker
    systemctl start docker
    sleep 10

    # Create docker network
    docker network create contoso-net

    # Start SQL Server container
    docker run -d \
      --name sql-server \
      --network contoso-net \
      --restart unless-stopped \
      -e "ACCEPT_EULA=Y" \
      -e "MSSQL_SA_PASSWORD=ContosoP@ssw0rd!" \
      -p 1433:1433 \
      mcr.microsoft.com/mssql/server:2022-latest

    # Wait for SQL Server to be ready
    echo "Waiting for SQL Server to start..."
    sleep 60

    # Start the Contoso University app
    docker run -d \
      --name contoso-university \
      --network contoso-net \
      --restart unless-stopped \
      -p 80:80 \
      -e "ASPNETCORE_ENVIRONMENT=Production" \
      -e "ASPNETCORE_URLS=http://+:80" \
      -e "ConnectionStrings__NetCoreContosoUniversityAppConnection=Server=sql-server,1433;Database=ContosoUniversity;User Id=sa;Password=ContosoP@ssw0rd!;TrustServerCertificate=True;" \
      -e "ApiBaseUrl=http://localhost:80" \
      ${var.docker_image}
  USERDATA

  tags = {
    Name = "contoso-university-app"
  }
}
