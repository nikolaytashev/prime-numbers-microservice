# prime-numbers-microservice
Prime Numbers Microservice

Instructions to run in container
#open a terminal in the solution folder
docker build -f PrimeNumbersMicroservice/Dockerfile -t primenumbersmicroservice:final .
docker run -d -p 8080:80 --name PrimeNumbersMicroservice primenumbersmicroservice:final
#access the service on http://localhost:8080/swagger/index.html

#OR
#open a terminal in the solution folder
docker-compose up -d