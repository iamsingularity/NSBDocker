# NServiceBus Sample running in Docker

This sample is a simple console app using NServiceBus running on mono in a docker container.

### How to use

You will need docker and docker composer installed and working on your machine.

1. git clone this repository
2. change directory to the repository
3. `docker-compose pull`
4. `docker-compose build`
5. `docker-compose up`

You should see the following output.

```
...
app_1     | TestingConsoleApp.MyHandler. Info. Hello from MyHandler.
app_1     | NServiceBus.Unicast.UnicastBus. Info. Initiating shutdown..
...
app_1     | NServiceBus.Unicast.UnicastBut. Info. Shutdown complete..
nsb_app_1 exited with code 0
```

To re-run the sample.

1. `docker-compose down`
2. `docker-compose up`