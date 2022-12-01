# Como instalar a CLI: https://docs.dapr.io/getting-started/install-dapr-cli/

Invoke-WebRequest -useb https://raw.githubusercontent.com/dapr/cli/master/install/install.ps1 | Invoke-Expression

# Configurar o Dapr em modo self-hosted: https://docs.dapr.io/getting-started/install-dapr-selfhost/

dapr init

dapr --version

docker container ls