# ITM 350 Final Project Report
## Week 12–14 | Group A | Ethan Trent

---

## 1. GitHub Repository

**Repository URL:** https://github.com/byui-devops/netcore-app-groupA-final

The project is version-controlled using GitHub. All work was completed using feature branches and pull requests merged into `main`. The following branches were used:

- `feature/devops-pipeline` — Added Dockerfile, CI/CD workflows, and Terraform IaC files (PR #3, merged)
- `feature/integration-tests` — Added 5 HTTP route integration tests and updated the build pipeline (PR #4, merged)

---

## 2. Docker Hub Image

**Docker Hub Image:** https://hub.docker.com/r/ethantrent/netcore-contoso-university

The Docker image is automatically built and pushed on every successful merge to `main`. The image is tagged `latest` and is publicly accessible on Docker Hub under the repository `ethantrent/netcore-contoso-university`.

---

## 3. Build Pipeline (CI)

**Workflow file:** `.github/workflows/build.yml`

**GitHub Actions Runs:** https://github.com/byui-devops/netcore-app-groupA-final/actions?query=workflow%3A%22Build%2C+Test+%26+Push%22

The **Build, Test & Push** pipeline is triggered on:
- Push to any branch
- Pull requests targeting `main`

### Pipeline Steps:
1. **Checkout code** — Pulls the latest source from GitHub
2. **Setup .NET** — Configures the .NET 8.0 SDK
3. **Restore dependencies** — Runs `dotnet restore`
4. **Build** — Compiles the application with `dotnet build`
5. **Run Unit Tests** — Executes unit tests in `NetCoreContosoUniversityApp.Tests`
6. **Run Integration Tests** — Executes HTTP route integration tests in `NetCoreContosoUniversityApp.IntegrationTests`
7. **Docker Build & Push** — Builds Docker image and pushes to Docker Hub (only on `main` branch)

All 14+ pipeline runs are logged and visible in GitHub Actions.

---

## 4. Release Pipeline (CD) with IaC

**Workflow file:** `.github/workflows/release.yml`

**GitHub Actions Runs:** https://github.com/byui-devops/netcore-app-groupA-final/actions?query=workflow%3A%22Release+to+AWS%22

The **Release to AWS** pipeline is triggered automatically when the Build, Test & Push workflow completes successfully on the `main` branch. No manual login to AWS is required.

### Pipeline Steps:
1. **Configure AWS credentials** — Uses GitHub Secrets (`AWS_ACCESS_KEY_ID`, `AWS_SECRET_ACCESS_KEY`, `AWS_SESSION_TOKEN`)
2. **Setup Terraform** — Installs Terraform via HashiCorp's official action
3. **Terraform Init** — Initializes the Terraform backend
4. **Import existing resources** — Detects and imports pre-existing AWS resources to prevent duplicates
5. **Terraform Plan** — Plans infrastructure changes
6. **Terraform Apply** — Provisions EC2 instance and security group automatically

### Infrastructure as Code (IaC):
All AWS infrastructure is defined in the `terraform/` directory:

| File | Purpose |
|------|---------|
| `terraform/main.tf` | EC2 instance, security group, Docker startup via user_data |
| `terraform/variables.tf` | Input variables (region, instance type, Docker image) |
| `terraform/outputs.tf` | Outputs EC2 public URL and IP |

**EC2 Endpoint:** http://ec2-54-90-130-47.compute-1.amazonaws.com

---

## 5. Testing

**Unit Tests:** `src/NetCoreContosoUniversityApp.Tests/`

The unit test project validates core business logic using xUnit.

**Integration Tests:** `src/NetCoreContosoUniversityApp.IntegrationTests/`

Five HTTP route integration tests were added to validate each major route of the Contoso University application:

| Test | Route | Expected Status |
|------|-------|----------------|
| `GetHome_ReturnsSuccess` | `GET /` | 200 OK |
| `GetStudents_ReturnsSuccess` | `GET /Students` | 200 OK |
| `GetCourses_ReturnsSuccess` | `GET /Courses` | 200 OK |
| `GetDepartments_ReturnsSuccess` | `GET /Departments` | 200 OK |
| `GetInstructors_ReturnsSuccess` | `GET /Instructors` | 200 OK |

Both test suites run automatically in the CI pipeline on every push.

---

## Summary

| Requirement | Status | Evidence |
|-------------|--------|---------|
| GitHub Repository | Complete | https://github.com/byui-devops/netcore-app-groupA-final |
| Unit Tests | Complete | `src/NetCoreContosoUniversityApp.Tests/` |
| Integration Tests (5) | Complete | `src/NetCoreContosoUniversityApp.IntegrationTests/` |
| Docker Image on Docker Hub | Complete | `ethantrent/netcore-contoso-university:latest` |
| Build Pipeline (CI) | Complete | `.github/workflows/build.yml` — 14+ runs |
| Release Pipeline (CD) | Complete | `.github/workflows/release.yml` — triggered automatically |
| IaC in Release Pipeline | Complete | `terraform/` — Terraform provisions EC2 on AWS |
| No Manual AWS Login | Complete | All credentials stored as GitHub Secrets |
| Feature Branches & PRs | Complete | PR #3 (devops-pipeline), PR #4 (integration-tests) |
