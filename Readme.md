
## Dotnet commands

dotnet build
dotnet publish -c Release


## Docker commands

aws ecr-public get-login-password --region us-east-1 | docker login --username AWS --password-stdin public.ecr.aws/y8k8e2i0
docker build -t weather_api -f .\src\WeatherApi\Dockerfile .
docker images
docker run -it --rm weather_api
docker tag weather_api:latest public.ecr.aws/y8k8e2i0/weather_api:latest
docker push public.ecr.aws/y8k8e2i0/weather_api:latest

## Openshift commands

oc apply -f .\k8s\deployment.yaml
oc get deployments

oc apply -f .\k8s\service.yaml
oc get services

oc apply -f .\k8s\route.yaml
oc get routes