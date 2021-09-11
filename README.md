# RickandMortyWeb

docker build -f WebApplication1\Dockerfile -t rickandmortapp .

docker run -d -p 8080:80 --name myapp rickandmortapp 

http://localhost:8080/api/RandMFriends