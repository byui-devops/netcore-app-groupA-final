output "app_url" {
  description = "Public URL of the running application"
  value       = "http://${aws_instance.app_server.public_dns}"
}

output "ec2_public_ip" {
  description = "Raw public IP of the EC2 instance"
  value       = aws_instance.app_server.public_ip
}
