Local


1)  Run mysql container 

        docker run --name quiz-mysql --network quiz -e MYSQL_ROOT_PASSWORD=test -p 6603:3306 -d mysql 

2)  Build Quiz Gateway Container
    
        docker run --name quiz-mysql --network quiz -e MYSQL_ROOT_PASSWORD=test -p 6603:3306 -d mysql

        docker build -t 9502070310/quiz-service .

    Http only 

        docker run -p 6604:80 -p 6605:443 -d --name quiz-service --network quiz -e DOTNET_URLS=http://+:80 9502070310/quiz-service

   Https 

        A)Create cert 

            dev-certs https -ep %USERPROFILE%\.aspnet\https\Quiz.Service.pfx -p test12345

            dotnet dev-certs https --trust

        B)  docker run --name quiz-service `
            -p 8000:80 `
            -p 8001:443 `
            --network quiz `
            -e ASPNETCORE_URLS="https://+;http://+" `
            -e ASPNETCORE_HTTPS_PORT=8001 `
            -e ASPNETCORE_Kestrel__Certificates__Default__Password="test12345" `
            -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/Quiz.Service.pfx `
            -v %USERPROFILE%\.aspnet\https:/https/ `
            9502070310/quiz-service

        C)  https://localhost:8001/api/Questions

3)  Build Quiz Client Container

        docker build -t 9502070310/quiz-microsite .

        docker run -p 6604:80 -p 6605:443 -d --name quiz-microsite --network quiz  9502070310/quiz-microsite
