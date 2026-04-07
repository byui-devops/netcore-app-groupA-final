- [TODO - DevOps Project](#todo---devops-project)
  - [Purpose](#purpose)
  - [Steps](#steps)
  - [EXCELLENCE CRITERIA](#excellence-criteria)

---

# TODO - DevOps Project

---

## Purpose

- Git for version control by effectively:
  - Implementing _branching strategies_,
  - conducting code reviews (_Pull Requests_),
  - and collaborating in a team environment
- Implement automated _unit_ and _integration_ testing to enhance software quality, maintainability, and long-term reliability
- Create, deploy, and manage _containerized applications_ in a cloud environment to improve scalability, reliability, and resource efficiency
  - With **Docker**
- Design and implement automated Continuous Integration & Continuous Deployment _(CI/CD) pipelines_ to streamline software delivery and deployment processes
  - With **GitHub Actions**
- Utilize _Infrastructure as Code (IaC) to define_, provision, and manage cloud infrastructure programmatically,
  - With **Terraform**

---

## Steps

- ✅ Done
- ⌛ In Progress

<https://github.com/carloswm85/2026-ITM350-IT-Management-and-DevOps-ClassProject/blob/main/docs/itm350-devops/final-project-workplan.md#1-repository--source-control-setup>

Build pipeline, then release pipeline.

1. Repository & Source Control Setup
   1. Implement branching strategies
   2. Conduct code reviews (PR)
2. Project Initialization ✅
   1. From template project:
      1. Use <https://github.com/carloswm85/dotnet-template-kit/tree/dev-netcore10-lightweight>
3. Containerization (Docker)
   1. Create `Dockerfile`
   2. Pushed to Docker Hub
4. Testing Strategy (Quality Assurance, by level). Automated testing.
   1. Unit - **Required** ⌛
   2. Integration - **Required**
      1. What is it? Is it made on API and DB?
   3. System - **Not Required**
5. CI Pipeline (Build Automation)
   1. Using `GitHub Actions`
   2. Trigger the whole build process on PR or push: Restore dependencies, Build project, Run tests, Fail pipeline on errors
6. Docker Hub Integration
   - Create Docker Hub repository
   - Automate:
     - Build Docker image in CI
       - Push image to Docker Hub
   - Use secure credentials (GitHub Secrets)
7. Infrastructure as Code (IaC)
   1. Run in the release pipeline.
   2. Define AWS infrastructure:
      - EC2 instance
      - Security groups
      - Networking (basic VPC or default)
   3. Parameterize configuration
   4. Ensure no manual AWS setup required
8. CD Pipeline (Release Automation)
   1. Extend `GitHub Actions` pipeline:
      - Steps:
        - Provision infrastructure via Terraform
        - Pull Docker image from Docker Hub
        - Deploy container to EC2
      - Constraints:
        - No manual login to AWS allowed
        - Everything must run via pipeline
9. Deployment Validation
10. Deployment is done into:
    1. EC2 AWS
    2. Docker Hub
11. Documentation & Final Report

---

## EXCELLENCE CRITERIA

- _AUTOMATION_:
  - The project could be deployed to project without logging into AWS or Docker Hub
  - 100% automated.
- _QUALITY ASSURANCE_:
  - The quality of the deploy is proved and automated
  - Integration and unit tests are successfully automated
- _SOURCE CONTROL_:
  - The project utilizes the best practices with source control.
  - All changes include a pull request, main branch is locked down.
